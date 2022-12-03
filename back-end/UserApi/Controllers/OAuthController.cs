﻿using System;
using Microsoft.AspNetCore.Mvc;
using UserApi.Service;

using UserApi.Models;
using UserApi.Service;
using UserApi.Common;
using UserApi.Utilities;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using UserApi.Models.DTOs;

namespace UserApi.Controllers
{

    [ApiController]
    [Route("oauth")]
    public class OAuthController : Controller
    {
        private IUserService userService;
        private IAuthorisedService authorisedService;

        public OAuthController(IUserService userService, IAuthorisedService authorisedService)
        {
            this.userService = userService;
            this.authorisedService = authorisedService;
        }

        [HttpGet("oauth_url")]
        public ActionResult<OAuthUrlResponseModel> RequestOAuthUrl([FromQuery] string callbackPath = "oob")
        {
            HttpResponseMessage responseMessage = authorisedService.GetOAuthUrl(callbackPath);
            if (responseMessage.IsSuccessStatusCode)
            {
                string result = responseMessage.Content.ReadAsStringAsync().Result;
                NameValueCollection querry = System.Web.HttpUtility.ParseQueryString(result);
                string oauth_token = !String.IsNullOrEmpty(querry["oauth_token"]) ? querry["oauth_token"]!.ToString() : "";
                string oauth_token_secret = !String.IsNullOrEmpty(querry["oauth_token_secret"]) ? querry["oauth_token_secret"]!.ToString() : "";
                if (!String.IsNullOrWhiteSpace(oauth_token) && !String.IsNullOrWhiteSpace(oauth_token_secret))
                {
                    return Ok(new OAuthUrlResponseModel(Secrets.OAuthHostUrl + Secrets.OAuthAuthMethod + "?oauth_token=" + oauth_token, oauth_token_secret));
                }
                return BadRequest("Authorised service error: authorised service did not provided crucial elements");
            }
            return BadRequest("Authorised service error: " + responseMessage.ReasonPhrase);
        }

        [HttpGet("access_token")]
        public ActionResult<OAuthAccesTokenResponseModel> SessionLogin([FromQuery] GetAccessTokenQueryParams getAccessTokenQueryParams)
        {
            var (oAuthToken, oAuthVerifier, oAuthTokenSecret) = getAccessTokenQueryParams;
            HttpResponseMessage responseMessage = authorisedService.GetAccesToken(oAuthToken, oAuthVerifier, oAuthTokenSecret);
            if (responseMessage.IsSuccessStatusCode)
            {
                string userApiToken = "";
                string result = responseMessage.Content.ReadAsStringAsync().Result;
                NameValueCollection querry = System.Web.HttpUtility.ParseQueryString(result);
                string oauth_token_acces = !String.IsNullOrEmpty(querry["oauth_token"]) ? querry["oauth_token"]!.ToString() : "";
                string oauth_token_acces_secret = !String.IsNullOrEmpty(querry["oauth_token_secret"]) ? querry["oauth_token_secret"]!.ToString() : "";
                if (!String.IsNullOrWhiteSpace(oauth_token_acces) && !String.IsNullOrWhiteSpace(oauth_token_acces_secret))
                {
                    HttpResponseMessage responseMessageUserId = userService.GetCurrentUser(oauth_token_acces, oauth_token_acces_secret, authorisedService);

                    if (responseMessageUserId.IsSuccessStatusCode)
                    {
                        string userId;
                        string resultUserId = responseMessageUserId.Content.ReadAsStringAsync().Result;
                        JObject jUserId = JObject.Parse(resultUserId);

                        if (jUserId.Count > 0)
                        {
                            userId = jUserId["id"]!.ToString();
                            userApiToken = OAuthTool.GenerateToken(userId, oauth_token_acces);
                        }
                    }

                    return Ok(new OAuthAccesTokenResponseModel(oauth_token_acces, oauth_token_acces_secret, userApiToken));
                }
                return BadRequest("Authorised service error: crucial elements not found");



            }
            return BadRequest("Authorised service error: " + responseMessage.ReasonPhrase);

        }

        [HttpPost("revoke_token")]
        public IActionResult SessionLogin([FromBody] RevokeTokenRequestDto revokeTokenRequestDto)
        {
            var (oauth_token, oauth_token_secret) = revokeTokenRequestDto;
            HttpResponseMessage responseMessage = authorisedService.PostRevokeToken(oauth_token, oauth_token_secret);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok();
            }
            return BadRequest("Authorised service error: " + responseMessage.ReasonPhrase);

        }
    }
}

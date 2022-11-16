﻿using UserApi.Models;

namespace UserApi.Service
{
    public interface IUserService 
    {
        ExampleModel Example();
        OAuthUrlModel OAuthUrl(string callbackUrl);
    }
}

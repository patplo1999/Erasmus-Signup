﻿using NoteApi.DbModels;
using System.Text.Json.Serialization;

namespace NoteApi.Models
{
    public class PlanNoteVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PlanId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;

        public PlanNoteVM(int userId, PlanNotePostVM postVm)
        {
            Id = -1;
            UserId = userId;
            PlanId = postVm.PlanId;
            Title = postVm.Title;
            Content = postVm.Content;
        }

        public PlanNoteVM(PlanNote dbModel)
        {
            Id = dbModel.NoteId;
            UserId = dbModel.Note.UserId;
            CreatedAt = dbModel.Note.CreatedAt;
            PlanId = dbModel.PlanId;
            Title = dbModel.Title;
            Content = dbModel.Content;
        }
    }
}

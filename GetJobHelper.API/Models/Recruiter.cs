using Data;
using System;
using System.Data;

namespace GetJobHelper.API.Models
{
    public class Recruiter : BaseModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Link { get; set; } 
        public bool MessageSend { get; set; }
        public bool Answered { get; set; }
    }
}

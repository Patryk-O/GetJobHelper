using GetJobHelper.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GetJobHelper.API.Extentions
{
    public static class ModelBuilderSeedExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Recruiter>().HasData(
    new Recruiter { Id = 1, Name = "Name_1", Link = "https://www.example.com/1", Created = new DateTime(2024, 4, 6, 20, 51, 23), Updated = new DateTime(2024, 4, 7, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 2, Name = "Name_2", Link = "https://www.example.com/2", Created = new DateTime(2024, 3, 27, 20, 51, 23), Updated = new DateTime(2024, 3, 28, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 3, Name = "Name_3", Link = "https://www.example.com/3", Created = new DateTime(2024, 3, 17, 20, 51, 23), Updated = new DateTime(2024, 3, 18, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 4, Name = "Name_4", Link = "https://www.example.com/4", Created = new DateTime(2024, 3, 7, 20, 51, 23), Updated = new DateTime(2024, 3, 8, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 5, Name = "Name_5", Link = "https://www.example.com/5", Created = new DateTime(2024, 2, 26, 20, 51, 23), Updated = new DateTime(2024, 2, 27, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 6, Name = "Name_6", Link = "https://www.example.com/6", Created = new DateTime(2024, 2, 16, 20, 51, 23), Updated = new DateTime(2024, 2, 17, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 7, Name = "Name_7", Link = "https://www.example.com/7", Created = new DateTime(2024, 2, 6, 20, 51, 23), Updated = new DateTime(2024, 2, 7, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 8, Name = "Name_8", Link = "https://www.example.com/8", Created = new DateTime(2024, 1, 27, 20, 51, 23), Updated = new DateTime(2024, 1, 28, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 9, Name = "Name_9", Link = "https://www.example.com/9", Created = new DateTime(2024, 1, 17, 20, 51, 23), Updated = new DateTime(2024, 1, 18, 20, 51, 23), MessageSend = true, Answered = true },
    new Recruiter { Id = 10, Name = "Name_10", Link = "https://www.example.com/10", Created = new DateTime(2024, 1, 7, 20, 51, 23), Updated = new DateTime(2024, 1, 8, 20, 51, 23), MessageSend = true, Answered = true }
        );

        }
    }
}

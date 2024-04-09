using Data;
using GetJobHelper.API.DBContexts;
using GetJobHelper.API.Models;
using GetJobHelper.API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GetJobHelper.API.Repositories
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly GetJobDBContext getJobDBContext;
        public RecruiterRepository(GetJobDBContext getJobDBContext)
        {
            this.getJobDBContext = getJobDBContext;
        }

        public async Task<ActionResult<RecruiterDTO>> CreateRecruiter(RecruiterDTO recruiterDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<RecruiterDTO>>> GetAllRecruitersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<RecruiterDTO>> GetRecruiterByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Recruiter>> UpdateRecruiter(int Id, RecruiterDTO recruiterDto)
        {
            throw new NotImplementedException();
        }
    }
}

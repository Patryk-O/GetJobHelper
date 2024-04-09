using Data;
using GetJobHelper.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetJobHelper.API.Repositories.Contracts
{
    public interface IRecruiterRepository
    {
        Task<ActionResult<IEnumerable<RecruiterDTO>>> GetAllRecruitersAsync();
        Task<ActionResult<RecruiterDTO>> GetRecruiterByIdAsync(int Id);
        Task<ActionResult<RecruiterDTO>> CreateRecruiter(RecruiterDTO recruiterDTO);
        Task<ActionResult<Recruiter>> UpdateRecruiter(int Id, RecruiterDTO recruiterDto);
    }
}

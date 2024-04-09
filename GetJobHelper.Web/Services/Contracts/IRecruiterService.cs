using Data;
using Microsoft.AspNetCore.Mvc;

namespace GetJobHelper.Web.Services.Contracts
{
    public interface IRecruiterService
    {
        Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync();
        Task<ActionResult<RecruiterDTO>> GetRecruiterByIdAsync(int Id);
        Task<ActionResult<RecruiterDTO>> CreateRecruiter(RecruiterDTO recruiterDTO);
        Task<ActionResult<RecruiterDTO>> UpdateRecruiter(int Id, RecruiterDTO recruiterDto);
    }
}

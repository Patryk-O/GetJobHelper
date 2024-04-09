using Data;
using GetJobHelper.Web.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace GetJobHelper.Web.Services
{
    public class RecruiterService : IRecruiterService
    {
        private readonly HttpClient httpClient;
        public RecruiterService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<ActionResult<RecruiterDTO>> CreateRecruiter(RecruiterDTO recruiterDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync()
        {
            try
            {
                var recruiters = await httpClient.GetFromJsonAsync<IEnumerable<RecruiterDTO>>("api/recruiter");
                return recruiters;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<ActionResult<RecruiterDTO>> GetRecruiterByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<RecruiterDTO>> UpdateRecruiter(int Id, RecruiterDTO recruiterDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> DeleteRecruiterAsync(int Id)
        {
            var response = await httpClient.DeleteAsync($"api/recruiter/Id?Id={Id}");
            if (response.IsSuccessStatusCode)
            {
                return new NoContentResult();
            }
            throw new Exception();
        }
    }
}

using Data;
using GetJobHelper.API.DBContexts;
using GetJobHelper.API.Models;
using GetJobHelper.API.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GetJobHelper.API.Controllers
{
    [Route("api/recruiter")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly GetJobDBContext _dBContexts;
        private readonly ILogger<RecruiterController> _logger;
        private readonly IRecruiterRepository _recruiterRepository;
        public RecruiterController(GetJobDBContext _dBContexts, ILogger<RecruiterController> logger, IRecruiterRepository recruiterRepository)
        {
            _logger = logger;
            _recruiterRepository = recruiterRepository;
            this._dBContexts = _dBContexts;
            _dBContexts.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<IEnumerable<RecruiterDTO>> GetAllRecruitersAsync()
        {
            var recruiters = await _dBContexts.Recruiters.Select(x => RecruiterToDTO(x)).ToListAsync();
            return recruiters;
            
        }

        [HttpGet("Id")]
        public async Task<ActionResult<RecruiterDTO>> GetRecruiterByIdAsync(int Id)
        {
            var recruiter = await _dBContexts.Recruiters.FirstOrDefaultAsync(x => x.Id == Id);
            if (recruiter == null)
            {
                return NotFound();
            }
            return Ok(RecruiterToDTO(recruiter));
        }

        [HttpPost]
        public async Task<ActionResult<RecruiterDTO>> CreateRecruiter(RecruiterDTO recruiterDTO)
        {
            var recruiter = new Recruiter 
            { 
                Id = recruiterDTO.Id,
                Name = recruiterDTO.Name,
                Link = recruiterDTO.Link,
                Created = DateTime.Now,
                Updated = DateTime.Now,
            };

            _dBContexts.Recruiters.Add(recruiter);
            await _dBContexts.SaveChangesAsync();
            _logger.LogInformation("New Recruiter Creater ID: {Id}", recruiter.Id);
            return CreatedAtAction(nameof(CreateRecruiter), new { id = recruiter.Id}, RecruiterToDTO(recruiter));
        }

        [HttpPut("Id")]
        public async Task<ActionResult<RecruiterDTO>> UpdateRecruiter(int Id, RecruiterDTO recruiterDto)
        {
            if (Id != recruiterDto.Id)
            {
                return BadRequest();
            }

            var recruiter = await _dBContexts.Recruiters.FindAsync(Id);
            if (recruiter == null)
            {
                return NotFound();
            }
            recruiter.Name = recruiterDto.Name;
            recruiter.Link = recruiterDto.Link;
            recruiter.Updated = DateTime.Now;

            try
            {
                await _dBContexts.SaveChangesAsync();
                _logger.LogInformation("Recruiter ID: {Id} has been changed", recruiter.Id);
            }
            catch (DbUpdateConcurrencyException ex) when (!RecruiterExist(Id))
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
            return  NoContent();
        }

        [HttpDelete("Id")]
        public async Task<ActionResult> DeleteRecruiter(int Id)
        {
            var recruiter = await _dBContexts.Recruiters.FindAsync(Id);
            if (recruiter == null)
            {
                return NotFound();
            }
            _dBContexts.Recruiters.Remove(recruiter);
            await _dBContexts.SaveChangesAsync();
            _logger.LogInformation($"Deleted recruiter {Id}", recruiter.Id);

            return NoContent();
        }

        private bool RecruiterExist(int Id)
        {
            return _dBContexts.Recruiters.Any(x => x.Id == Id);
        }

        private static RecruiterDTO RecruiterToDTO(Recruiter recruiter)
        {
         return new RecruiterDTO { Id = recruiter.Id, Name = recruiter.Name, Link = recruiter.Link, Answered = recruiter.Answered, MessageSend = recruiter.MessageSend };
        }
    }
}

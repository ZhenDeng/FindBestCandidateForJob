using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBestCandidateForJob.Models;
using FindBestCandidateForJob.Repository;
using FindBestCandidateForJob.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindBestCandidateForJob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobMatchApiController : ControllerBase
    {
        private readonly IJobMatchService service;

        public JobMatchApiController(IJobMatchService service)
        {
            this.service = service;
        }

        [HttpGet("GetMatcher")]
        public async Task<IActionResult> GetMatcher()
        {
            try
            {
                List<Candidate> candidates = await CandidateSeeder.Seed();
                List<Job> jobs = await JobSeeder.Seed();
                List<Job> qualified = this.service.JobMatch(candidates, jobs);
                return Ok(qualified);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
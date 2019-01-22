using System.Collections.Generic;
using FindBestCandidateForJob.Models;

namespace FindBestCandidateForJob.Services
{
    public interface IJobMatchService
    {
        List<Job> JobMatch(List<Candidate> candidates, List<Job> jobs);
    }
}
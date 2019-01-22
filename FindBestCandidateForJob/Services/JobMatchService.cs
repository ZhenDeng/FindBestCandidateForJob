using FindBestCandidateForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindBestCandidateForJob.Services
{
    public class JobMatchService : IJobMatchService
    {
        public List<Job> JobMatch(List<Candidate> candidates, List<Job> jobs)
        {
            int id = 0;
            int finalNumber;
            int index = 1;
            foreach (Job job in jobs)
            {
                string[] skills = job.skills.Split(',');
                finalNumber = 0;
                id = 0;
                foreach (Candidate candidate in candidates)
                {
                    string[] skillTags = candidate.skillTags.Split(',');
                    int identicalItems = skills.Intersect(skillTags).Count();
                    if (identicalItems > finalNumber)
                    {
                        finalNumber = identicalItems;
                        id = candidate.candidateId;
                    }
                }
                if (id != 0)
                {
                    job.qualifiedCandidate = candidates.Where(o => o.candidateId == id).FirstOrDefault().name;
                }
                else
                {
                    Candidate can = new Candidate()
                    {
                        candidateId = candidates.Count() + index,
                        name = "No Qualified Candidate",
                        skillTags = ""
                    };
                    job.qualifiedCandidate = can.name;
                    index++;
                }
            }

            return jobs;
        }
    }
}

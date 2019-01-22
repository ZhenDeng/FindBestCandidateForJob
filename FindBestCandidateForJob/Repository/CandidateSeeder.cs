using FindBestCandidateForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace FindBestCandidateForJob.Repository
{
    public class CandidateSeeder
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Candidate>> Seed()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Candidate>));
            var streamTask = client.GetStreamAsync("http://private-76432-jobadder1.apiary-mock.com/candidates");
            var repositories = serializer.ReadObject(await streamTask) as List<Candidate>;
            return repositories.OrderBy(o => o.candidateId).ToList();
        }
    }
}

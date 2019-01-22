using FindBestCandidateForJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace FindBestCandidateForJob.Repository
{
    public class JobSeeder
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<List<Job>> Seed()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Job>));
            var streamTask = client.GetStreamAsync("http://private-76432-jobadder1.apiary-mock.com/jobs");
            var repositories = serializer.ReadObject(await streamTask) as List<Job>;
            return repositories.OrderBy(o => o.jobId).ToList();
        }
    }
}

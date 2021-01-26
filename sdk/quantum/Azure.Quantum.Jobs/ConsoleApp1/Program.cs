using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Quantum.Jobs;
using Azure.Quantum.Jobs.Models;
using Newtonsoft.Json;
using Azure.Identity;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = MainAsync();
        }

        private static async Task MainAsync()
        {
            QuantumJobClient client = new QuantumJobClient(SubscriptionId.value, "sdk-review-rg", "workspace-ms", "westus", new DefaultAzureCredential(new DefaultAzureCredentialOptions()));

            await foreach (JobDetails job in client.GetJobsAsync(CancellationToken.None))
            {
                Console.WriteLine(JsonConvert.SerializeObject(job));
            }
        }
    }
}

// Create SubscriptionId.cs like so and put in your id:
// namespace Azure.Quantum.Jobs.Tests
// {
//     internal class SubscriptionId
//     {
//         public string value = "<yourid>";
//     }
// }

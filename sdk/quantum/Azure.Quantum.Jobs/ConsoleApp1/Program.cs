using System;
using System.Threading;
using Azure.Quantum.Jobs;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            QuantumJobsClient client = new QuantumJobsClient(SubscriptionId.value, "sdk-review-rg", "workspace-ms", "westus");
            var jobs = client.GetJobsClient().ListAsync(CancellationToken.None).Result;

            Console.WriteLine(JsonConvert.SerializeObject(jobs));
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

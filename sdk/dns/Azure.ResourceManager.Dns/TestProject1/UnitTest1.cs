using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Dns;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            string clientId = "8e6d47e0-7969-4fde-a62c-4fea4f165e98";
            string clientSecret = "lVa7Q~mDi9zRplCbDikYkNUpjjPw5XRiDdpol";
            string tenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            string subscription = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            string rgName = "Dns-RG-0000";
            string zoneName = "zone0000.com";


            var azureCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            var options = new DnsManagementClientOptions();

            // Uncomment the below line to get rid of AggregateExceptions.
            options.Retry.MaxRetries = 0;

            var dnsManagementClient = new DnsManagementClient(subscription, azureCredential, options);

            var response = await dnsManagementClient.Zones.GetAsync(rgName, zoneName);

            Console.WriteLine(response.GetRawResponse().Status);
            Assert.Pass();
        }
    }
}

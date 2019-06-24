using Azure.Messaging.EventHubs;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace SmokeTest
{

    class Program
    {
        static async Task<int> Main(string[] args)
        {                        
            Console.WriteLine("SMOKE TEST FOR TRACK 2 LIBRARIES");

            var keyVault = new KeyVaultTest("SmokeTestSecret", "smokeTestValue", Environment.GetEnvironmentVariable("DIR_TENANT_ID"), Environment.GetEnvironmentVariable("APP_CLIENT_ID"), Environment.GetEnvironmentVariable("CLIENT_SECRET"), Environment.GetEnvironmentVariable("KEY_VAULT_URI"));
            var kvResult = await keyVault.PerformFunctionalities();

            var blobStorage = new BlobStorageTest(Environment.GetEnvironmentVariable("BLOB_CONNECTION_STRING"), "mycontainer", "netSmokeTestBlob");
            var bsResult = await blobStorage.PerformFunctionalities();

            var eventHubs = new EventHubsTest(Environment.GetEnvironmentVariable("EVENT_HUBS_CONNECTION_STRING"));
            var ehResult = await eventHubs.PerformFunctionalities();

            if (!kvResult || !bsResult || !ehResult)
            {
                return 1;
            }

            return 0;
        }
    }
}

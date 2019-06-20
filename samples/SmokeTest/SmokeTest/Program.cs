using Azure.Messaging.EventHubs;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("SMOKE TEST FOR TRACK 2 LIBRARIES");
            await KeyVaultTest.performFunctionalities();
            await BlobStorage.performFunctionalities();
            await EventHubs.performFunctionalities();
                        
        }
    }
}

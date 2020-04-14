// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
// ------------------------------------
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("SMOKE TEST FOR TRACK 2 LIBRARIES");

            await KeyVaultTest.RunTests();
            await BlobStorageTest.RunTests();
            await EventHubsTest.RunTests();
            // Temporarily disable Cosmos DB smoke tests
            // await CosmosDBTest.RunTests();

            return 0;
        }
    }
}


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using SmokeTest.Samples;

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
            // Issue to re-enable:
            // https://github.com/Azure/azure-sdk-for-net/issues/11297
            // await CosmosDBTest.RunTests();

            Console.WriteLine();
            Console.WriteLine("LIBRARY TESTS COMPLETE");
            Console.WriteLine();
            Console.WriteLine("SMOKE TEST FOR TRACK 2 SAMPLES");

            await IotHubConnectionTests.RunTests();

            Console.WriteLine("SAMPLES TESTS COMPLETE");
            Console.WriteLine();
            return 0;
        }
    }
}

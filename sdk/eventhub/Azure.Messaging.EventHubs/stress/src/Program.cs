// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Stress
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var azResourceStrings = new AzureResourceConnectionStrings();
            var testsToRun = ParseArguments(args);

            // Determine which tests to run
            testsToRun.TryGetValue("BasicPublishReadTest", out var runBasicPublishReadTest);
            var azResourceNamesBPRT = new AzureResourceNames();

            testsToRun.TryGetValue("BasicEventProcessorTest", out var runBasicEventProcessorTest);
            testsToRun.TryGetValue("EventProducerTest", out var runEventProcessorTest);
            testsToRun.TryGetValue("ProcessorEmptyReadTest", out var runProcessorEmptyReadTest);
            var localRun = testsToRun.TryGetValue("local", out var local);

            var needBlobStorage = (runBasicEventProcessorTest || runProcessorEmptyReadTest);

            var instrumentationKey = string.Empty;

            // Set the necessary connection string inputs
            if (localRun)
            {
                Console.WriteLine($"need blob: {needBlobStorage}.");
                PromptForConnectionStrings(azResourceStrings, needBlobStorage);
            }
            else
            {
                var ENV_FILE = Environment.GetEnvironmentVariable("ENV_FILE");
                var environment = EnvironmentReader.LoadFromFile(ENV_FILE);

                environment.TryGetValue("EVENTHUB_NAMESPACE_CONNECTION_STRING", out azResourceStrings.EventHubsConnectionString);
                environment.TryGetValue("STORAGE_CONNECTION_STRING", out azResourceStrings.StorageConnectionString);

                environment.TryGetValue("EVENTHUB_NAME_BPRT", out azResourceNamesBPRT.EventHub);
            }

            // Run BasicPublishReadTest scenario
            if (runBasicPublishReadTest)
            {
                if (localRun)
                {
                    PromptForNames(azResourceNamesBPRT, false);
                }

            while (string.IsNullOrEmpty(instrumentationKey))
            {
                Console.Write("Please provide the instrumentation key for the App Insights resource: ");
                instrumentationKey = Console.ReadLine().Trim();
                Console.WriteLine();
            }

                int durationInHours = 72;
                var basicPublicReadTest = new BasicPublishReadTest();
                await basicPublicReadTest.Run(azResourceStrings.EventHubsConnectionString, azResourceNamesBPRT.EventHub, instrumentationKey, durationInHours);
            }

            // TODO: Run BasicEventProcessorTest scenario
            if (runBasicEventProcessorTest)
            {
                // var azResourceNamesBEPT = new AzureResourceNames();
                // if (localRun)
                // {
                //     PromptForNames(azResourceNamesBEPT, true);
                // }
                // else
                // {
                //     azResourceNamesBEPT.EventHub = Environment.GetEnvironmentVariable("EVENTHUB_NAME_BEPT");
                //     azResourceNamesBEPT.BlobContainer = Environment.GetEnvironmentVariable("BLOB_CONTAINER_BEPT");
                // }

                //await EventProcessorTest.Run();
            }

            // TODO: Run EventProducerTest scenario
            if (runEventProcessorTest)
            {
                // var azResourceNamesEPT = new AzureResourceNames();
                // if (localRun)
                // {
                //     PromptForNames(azResourceNamesEPT, false);
                // }
                // else
                // {
                //     azResourceNamesEPT.EventHub = Environment.GetEnvironmentVariable("EVENTHUB_NAME_EPT");
                // }

                // await ComplexEventProducerTest.Run(azResourceStrings.EventHubsConnectionString, azResourceNamesEPT.EventHub);
            }

            // TODO: Run ProcessorEmptyReadTest scenario
            if (runProcessorEmptyReadTest)
            {
                // var azResourceNamesPERT = new AzureResourceNames();
                // if (localRun)
                // {
                //     PromptForNames(azResourceNamesPERT, true);
                // }
                // else
                // {
                //     azResourceNamesPERT.EventHub = Environment.GetEnvironmentVariable("EVENTHUB_NAME_EPT");
                //     azResourceNamesPERT.BlobContainer = Environment.GetEnvironmentVariable("BLOB_CONTAINER_PERT");
                // }

                // await ProcessorEmptyReadTestRun.Run(azResourceStrings.EventHubsConnectionString, azResourceNamesPERT.EventHub, azResourceStrings.StorageConnectionString, azResourceNamesPERT.BlobContainer);
            }
        }

        private static void PromptForConnectionStrings(AzureResourceConnectionStrings azResourceStrings, bool needBlobStorage)
        {
            // Prompt for the Event Hubs connection string, if it wasn't passed.

            while (string.IsNullOrEmpty(azResourceStrings.EventHubsConnectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs namespace that you'd like to use and then press Enter: ");
                azResourceStrings.EventHubsConnectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            if (needBlobStorage)
            {
                // Prompt for the storage connection string, if it wasn't passed.

                while (string.IsNullOrEmpty(azResourceStrings.StorageConnectionString))
                {
                    Console.Write("Please provide the connection string for the Azure storage account that you'd like to use and then press Enter: ");
                    azResourceStrings.StorageConnectionString = Console.ReadLine().Trim();
                    Console.WriteLine();
                }
            }
        }

        private static void PromptForNames(AzureResourceNames azResourceNames, bool needBlobStorage)
        {
            // Prompt for the Event Hub name, if it wasn't passed.

            while (string.IsNullOrEmpty(azResourceNames.EventHub))
            {
                Console.Write("Please provide the name of the Event Hub that you'd like to use and then press Enter: ");
                azResourceNames.EventHub = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            if (needBlobStorage)
            {
                // Prompt for the blob container name, if it wasn't passed.

                while (string.IsNullOrEmpty(azResourceNames.BlobContainer))
                {
                    Console.Write("Please provide the name of the blob container that you'd like to use and then press Enter: ");
                    azResourceNames.BlobContainer = Console.ReadLine().Trim();
                    Console.WriteLine();
                }
            }
        }

        private static Dictionary<string,bool> ParseArguments(string[] args)
        {
            var testsToRun = new Dictionary<string, bool>();

            foreach (string scenario in args)
            {
                testsToRun.Add(scenario, true);
            }

            return testsToRun;
        }

        private class AzureResourceConnectionStrings
        {
            public string EventHubsConnectionString;
            public string StorageConnectionString;
        }

        private class AzureResourceNames
        {
            public string EventHub;
            public string BlobContainer;
        }
    }
}
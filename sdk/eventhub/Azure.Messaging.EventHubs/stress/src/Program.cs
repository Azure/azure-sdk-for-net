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
            var testsToRun = ParseArguments(args);

            // Determine which tests to run
            testsToRun.TryGetValue("EventProd", out var runEventProducerTest);
            testsToRun.TryGetValue("EventBuffProd", out var runEventBufferedProducerTest);
            testsToRun.TryGetValue("ConcurBuffProd", out var runConcurrentBufferedProducerTest);
            testsToRun.TryGetValue("BurstBuffProd", out var runBurstBufferedProducerTest);

            var ENV_FILE = Environment.GetEnvironmentVariable("ENV_FILE");
            var environment = EnvironmentReader.LoadFromFile(ENV_FILE);

            if (runEventProducerTest)
            {
                var testConfiguration = new ProducerConfiguration();
                environment.TryGetValue("EVENTHUB_NAMESPACE_CONNECTION_STRING", out testConfiguration.EventHubsConnectionString);
                environment.TryGetValue("APPINSIGHTS_INSTRUMENTATIONKEY", out testConfiguration.InstrumentationKey);
                environment.TryGetValue("EVENTHUB_NAME_EPT", out testConfiguration.EventHub);
                environment.TryGetValue("EVENTHUB_PARTITIONS_EPT", out testConfiguration.NumPartitions);
                PromptForResources(testConfiguration, "EventProducerTest");

                var testRun = new EventProducerTest(testConfiguration);
                await testRun.Run();
            }

            if (runEventBufferedProducerTest)
            {
                var testConfiguration = new ProducerConfiguration();
                environment.TryGetValue("EVENTHUB_NAMESPACE_CONNECTION_STRING", out testConfiguration.EventHubsConnectionString);
                environment.TryGetValue("APPINSIGHTS_INSTRUMENTATIONKEY", out testConfiguration.InstrumentationKey);
                environment.TryGetValue("EVENTHUB_NAME_EBPT", out testConfiguration.EventHub);
                environment.TryGetValue("EVENTHUB_PARTITIONS_EBPT", out testConfiguration.NumPartitions);
                PromptForResources(testConfiguration, "EventBufferedProducerTest");

                testConfiguration.ConcurrentSends = 1;

                var testRun = new BufferedProducerTest(testConfiguration);
                await testRun.Run();
            }

            if (runConcurrentBufferedProducerTest)
            {
                var testConfiguration = new ProducerConfiguration();
                environment.TryGetValue("EVENTHUB_NAMESPACE_CONNECTION_STRING", out testConfiguration.EventHubsConnectionString);
                environment.TryGetValue("APPINSIGHTS_INSTRUMENTATIONKEY", out testConfiguration.InstrumentationKey);
                environment.TryGetValue("EVENTHUB_NAME_CBPT", out testConfiguration.EventHub);
                environment.TryGetValue("EVENTHUB_PARTITIONS_CBPT", out testConfiguration.NumPartitions);
                PromptForResources(testConfiguration, "ConcurrentBufferedProducerTest");

                testConfiguration.ConcurrentSends = 5;

                var testRun = new BufferedProducerTest(testConfiguration);
                await testRun.Run();
            }

            if (runBurstBufferedProducerTest)
            {
                var testConfiguration = new ProducerConfiguration();
                environment.TryGetValue("EVENTHUB_NAMESPACE_CONNECTION_STRING", out testConfiguration.EventHubsConnectionString);
                environment.TryGetValue("APPINSIGHTS_INSTRUMENTATIONKEY", out testConfiguration.InstrumentationKey);
                environment.TryGetValue("EVENTHUB_NAME_BBPT", out testConfiguration.EventHub);
                environment.TryGetValue("EVENTHUB_PARTITIONS_BBPT", out testConfiguration.NumPartitions);
                PromptForResources(testConfiguration, "BurstBufferedProducerTest");

                testConfiguration.ConcurrentSends = 5;
                testConfiguration.ProducerPublishingDelay = TimeSpan.FromMinutes(15);

                var testRun = new BufferedProducerTest(testConfiguration);
                await testRun.Run();
            }
        }

        private static void PromptForResources(ProducerConfiguration testConfiguration, string testName)
        {
            // Prompt for the App Insights instrumentation key
            while (string.IsNullOrEmpty(testConfiguration.InstrumentationKey))
                {
                    Console.Write("Please provide the instrumentation key for the App Insights resource: ");
                    testConfiguration.InstrumentationKey = Console.ReadLine().Trim();
                }

            // Prompt for the Event Hubs connection string
            while (string.IsNullOrEmpty(testConfiguration.EventHubsConnectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs namespace that you'd like to use and then press Enter: ");
                testConfiguration.EventHubsConnectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // Prompt for the Event Hub names, if they weren't passed.

            while (string.IsNullOrEmpty(testConfiguration.EventHub))
            {
                Console.Write($"Please provide the name of the Event Hub that you'd like to use for the {testName} and then press Enter: ");
                testConfiguration.EventHub = Console.ReadLine().Trim();
                Console.WriteLine();
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
    }
}
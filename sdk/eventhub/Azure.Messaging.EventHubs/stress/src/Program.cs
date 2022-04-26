// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
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
            await CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunOptions);
        }

        private static async Task RunOptions(Options opts)
        {
            var environment = new Dictionary<string, string>();
            var appInsightsKey = String.Empty;
            var eventHubsConnectionString = String.Empty;
            var eventProducerTestConfig = new EventProducerTestConfig();
            var bufferedProducerTestConfig = new BufferedProducerTestConfig();
            var burstBufferedProducerTestConfig = new BufferedProducerTestConfig();
            var concurrentBufferedProducerTestConfig = new BufferedProducerTestConfig();

            foreach (var testRun in opts.Tests)
            {
                if (testRun == "EventProd" || testRun == "EventProducerTest")
                {
                    eventProducerTestConfig.Run = true;
                }
                if (testRun == "BuffProd" || testRun == "BufferedProducerTest")
                {
                    bufferedProducerTestConfig.Run = true;
                }
                if (testRun == "BurstBuffProd" || testRun == "BurstBufferedProducerTest")
                {
                    burstBufferedProducerTestConfig.Run = true;
                }
                if (testRun == "ConcurBuffProd" || testRun == "ConcurrentBufferedProducerTest")
                {
                    concurrentBufferedProducerTestConfig.Run = true;
                }
            }

            if (!(opts.Interactive))
            {
                environment = EnvironmentReader.LoadFromFile(Environment.GetEnvironmentVariable("ENV_FILE"));

                environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out appInsightsKey);
                environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out eventHubsConnectionString);
            }

            if (eventProducerTestConfig.Run)
            {
                if (opts.Interactive)
                {
                    eventProducerTestConfig.EventHubsConnectionString = PromptForResources("Event Hubs connection string", "event producer test");
                    eventProducerTestConfig.EventHub = PromptForResources("Event Hub name", "event producer test");
                    eventProducerTestConfig.InstrumentationKey = PromptForResources("App Insights instrumentation key", "event producer test");
                }
                else
                {
                    eventProducerTestConfig.InstrumentationKey = appInsightsKey;
                    eventProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                    environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventProducerTestConfig.EventHub);
                    environment.TryGetValue(EnvironmentVariables.EventHubPartitionsEventProducerTest, out eventProducerTestConfig.NumPartitions);
                }

                var testRun = new EventProducerTest(eventProducerTestConfig);
                await testRun.Run();
            }

            if (bufferedProducerTestConfig.Run)
            {
                if (opts.Interactive)
                {
                    bufferedProducerTestConfig.EventHubsConnectionString = PromptForResources("Event Hubs connection string", "buffered producer test");
                    bufferedProducerTestConfig.EventHub = PromptForResources("Event Hub name", "buffered producer test");
                    bufferedProducerTestConfig.InstrumentationKey = PromptForResources("App Insights instrumentation key", "buffered producer test");
                }
                else
                {
                    bufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                    bufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                    environment.TryGetValue(EnvironmentVariables.EventHubBufferedProducerTest, out bufferedProducerTestConfig.EventHub);
                    environment.TryGetValue(EnvironmentVariables.EventHubPartitionsBufferedProducerTest, out bufferedProducerTestConfig.NumPartitions);
                }

                bufferedProducerTestConfig.ConcurrentSends = 1;

                var testRun = new BufferedProducerTest(bufferedProducerTestConfig);
                await testRun.Run();
            }

            if (burstBufferedProducerTestConfig.Run)
            {
                if (opts.Interactive)
                {
                    burstBufferedProducerTestConfig.EventHubsConnectionString = PromptForResources("Event Hubs connection string", "burst buffered producer test");
                    burstBufferedProducerTestConfig.EventHub = PromptForResources("Event Hub name", "burst buffered producer test");
                    burstBufferedProducerTestConfig.InstrumentationKey = PromptForResources("App Insights instrumentation key", "burst buffered producer test");
                }
                else
                {
                    burstBufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                    burstBufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                    environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out burstBufferedProducerTestConfig.EventHub);
                    environment.TryGetValue(EnvironmentVariables.EventHubPartitionsBurstBufferedProducerTest, out burstBufferedProducerTestConfig.NumPartitions);
                }

                burstBufferedProducerTestConfig.ConcurrentSends = 5;
                burstBufferedProducerTestConfig.ProducerPublishingDelay = TimeSpan.FromMinutes(15);

                var testRun = new BufferedProducerTest(burstBufferedProducerTestConfig);
                await testRun.Run();
            }

            if (concurrentBufferedProducerTestConfig.Run)
            {
                if (opts.Interactive)
                {
                    concurrentBufferedProducerTestConfig.EventHubsConnectionString = PromptForResources("Event Hubs connection string", "concurrent buffered producer test");
                    concurrentBufferedProducerTestConfig.EventHub = PromptForResources("Event Hub name", "concurrent buffered producer test");
                    concurrentBufferedProducerTestConfig.InstrumentationKey = PromptForResources("App Insights instrumentation key", "concurrent buffered producer test");
                }
                else
                {
                    concurrentBufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                    concurrentBufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                    environment.TryGetValue(EnvironmentVariables.EventHubConcurrentBufferedProducerTest, out concurrentBufferedProducerTestConfig.EventHub);
                    environment.TryGetValue(EnvironmentVariables.EventHubPartitionsConcurrentBufferedProducerTest, out concurrentBufferedProducerTestConfig.NumPartitions);
                }
                concurrentBufferedProducerTestConfig.ConcurrentSends = 5;

                var testRun = new BufferedProducerTest(concurrentBufferedProducerTestConfig);
                await testRun.Run();
            }

            await Task.Delay(0);
        }

        private static string PromptForResources(string resourceName, string testName)
        {
            var output = String.Empty;
            while (string.IsNullOrEmpty(output))
            {
                Console.Write($"Please provide the {resourceName} for the {testName}: ");
                output = Console.ReadLine().Trim();
            }
            return output;
        }

        private class Options
        {
            [Option('i', "interactive", HelpText = "Set up stress tests in interactive mode.")]
            public bool Interactive { get; set; }

            [Option('t', "tests", Default= false, HelpText = "Enter which tests to run.")]
            public IEnumerable<string> Tests { get; set; }
        }
    }
}
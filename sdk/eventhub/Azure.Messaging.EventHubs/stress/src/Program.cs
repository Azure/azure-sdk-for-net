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
    /// <summary>
    ///   The main program thread that allows for both local and deployed test runs.
    ///   Determines which tests should be run and starts them in the background.
    /// </summary>
    ///
    public class Program
    {
        /// <summary>
        ///   Parses the command line arguments and runs the specified tests.
        /// </summary>
        ///
        /// <param name="args">The command line inputs.</param>
        ///
        public static async Task Main(string[] args)
        {
            // Parse command line arguments

            await CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunOptions).ConfigureAwait(false);
        }

        /// <summary>
        ///   Starts a background task for each test that needs to be run, and waits for all
        ///   test runs to completed before returning.
        /// </summary>
        ///
        /// <param name="opts">The parsed command line inputs.</param>
        ///
        private static async Task RunOptions(Options opts)
        {
            var environment = new Dictionary<string, string>();
            var appInsightsKey = String.Empty;
            var eventHubsConnectionString = String.Empty;
            var eventProducerTestConfig = new EventProducerTestConfig();
            var bufferedProducerTestConfig = new BufferedProducerTestConfig();
            var burstBufferedProducerTestConfig = new BufferedProducerTestConfig();
            var concurrentBufferedProducerTestConfig = new BufferedProducerTestConfig();

            var testRunTasks = new List<Task>();

            // Determine which tests should be run based on the command line args

            if (opts.All)
            {
                eventProducerTestConfig.Run = true;
                bufferedProducerTestConfig.Run = true;
                burstBufferedProducerTestConfig.Run = true;
                concurrentBufferedProducerTestConfig.Run = true;
            }

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

            // See if there are environment variables available to use in the .env file

            var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
            if (!(string.IsNullOrEmpty(environmentFile)))
            {
                environment = EnvironmentReader.LoadFromFile(environmentFile);
            }

            environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out appInsightsKey);
            environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out eventHubsConnectionString);

            // Prompt for needed resources if interactive mode is enabled

            if (opts.Interactive)
            {
                eventHubsConnectionString = _promptForResources("Event Hubs connection string", "all test runs", eventHubsConnectionString);
                appInsightsKey = _promptForResources("Application Insights key", "all test runs", appInsightsKey);
            }

            // Run the event producer test

            if (eventProducerTestConfig.Run)
            {
                eventProducerTestConfig.InstrumentationKey = appInsightsKey;
                eventProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventProducerTestConfig.EventHub);

                if (opts.Interactive)
                {
                    eventProducerTestConfig.EventHub = _promptForResources("Event Hub name", "event producer test", eventProducerTestConfig.EventHub);
                }

                var testRun = new EventProducerTest(eventProducerTestConfig);
                testRunTasks.Add(testRun.Run());
            }

            // Run the buffered producer test

            if (bufferedProducerTestConfig.Run)
            {
                bufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                bufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                environment.TryGetValue(EnvironmentVariables.EventHubBufferedProducerTest, out bufferedProducerTestConfig.EventHub);

                if (opts.Interactive)
                {
                    bufferedProducerTestConfig.EventHub = _promptForResources("Event Hub name", "buffered producer test", bufferedProducerTestConfig.EventHub);
                }

                bufferedProducerTestConfig.ConcurrentSends = 1;

                var testRun = new BufferedProducerTest(bufferedProducerTestConfig);
                testRunTasks.Add(testRun.Run());
            }

            // Run the burst buffered producer test

            if (burstBufferedProducerTestConfig.Run)
            {
                burstBufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                burstBufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out burstBufferedProducerTestConfig.EventHub);

                if (opts.Interactive)
                {
                    burstBufferedProducerTestConfig.EventHub = _promptForResources("Event Hub name", "burst buffered producer test", burstBufferedProducerTestConfig.EventHub);
                }

                burstBufferedProducerTestConfig.ConcurrentSends = 5;
                burstBufferedProducerTestConfig.ProducerPublishingDelay = TimeSpan.FromMinutes(15);

                var testRun = new BufferedProducerTest(burstBufferedProducerTestConfig);
                testRunTasks.Add(testRun.Run());
            }

            // Run the concurrent buffered producer test

            if (concurrentBufferedProducerTestConfig.Run)
            {
                concurrentBufferedProducerTestConfig.InstrumentationKey = appInsightsKey;
                concurrentBufferedProducerTestConfig.EventHubsConnectionString = eventHubsConnectionString;

                environment.TryGetValue(EnvironmentVariables.EventHubConcurrentBufferedProducerTest, out concurrentBufferedProducerTestConfig.EventHub);

                if (opts.Interactive)
                {
                    concurrentBufferedProducerTestConfig.EventHub = _promptForResources("Event Hub name", "concurrent buffered producer test", concurrentBufferedProducerTestConfig.EventHub);
                }

                concurrentBufferedProducerTestConfig.ConcurrentSends = 5;

                var testRun = new BufferedProducerTest(concurrentBufferedProducerTestConfig);
                testRunTasks.Add(testRun.Run());
            }

            // Wait for all test runs to complete

            await Task.WhenAll(testRunTasks).ConfigureAwait(false);
        }

        /// <summary>
        ///   Prompts the user using the command line for resources if they have not been provided yet.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the needed resource.</param>
        /// <param name="testName">Which test(s) for which the resource is needed.</param>
        /// <param name="currentValue">The current value of the resource.</param>
        ///
        private static string _promptForResources(string resourceName, string testName, string currentValue)
        {
            // If the resource hasn't been provided already, wait for it to be provided through the CLI

            while (string.IsNullOrEmpty(currentValue))
            {
                Console.Write($"Please provide the {resourceName} for {testName}: ");
                currentValue = Console.ReadLine().Trim();
            }
            return currentValue;
        }

        /// <summary>
        ///   The available command line options that can be parsed.
        /// </summary>
        ///
        private class Options
        {
            [Option('i', "interactive", HelpText = "Set up stress tests in interactive mode.")]
            public bool Interactive { get; set; }

            [Option("all", HelpText = "Run all available tests.")]
            public bool All { get; set; }

            [Option('t', "tests", HelpText = "Enter which tests to run.")]
            public IEnumerable<string> Tests { get; set; }
        }
    }
}
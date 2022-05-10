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
            // See if there are environment variables available to use in the .env file
            var environment = new Dictionary<string, string>();
            var appInsightsKey = String.Empty;
            var eventHubsConnectionString = String.Empty;
            var eventHubName = String.Empty;

            var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
            if (!(string.IsNullOrEmpty(environmentFile)))
            {
                environment = EnvironmentReader.LoadFromFile(environmentFile);
            }

            environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out appInsightsKey);
            environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out eventHubsConnectionString);
            environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);

            environment.TryGetValue(EnvironmentVariables.JobCompletionIndex, out var job_index);

            var testConfiguration = new EventProducerTestConfig();

            testConfiguration.EventHubsConnectionString = eventHubsConnectionString;
            testConfiguration.InstrumentationKey = appInsightsKey;
            testConfiguration.EventHub = eventHubName;
            var metrics = new Metrics(testConfiguration.InstrumentationKey);

            // Set up the cancellation source
            var roleTask = Task.CompletedTask;
            var roleCancellationSource = new CancellationTokenSource();
            var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
            roleCancellationSource.CancelAfter(runDuration);

            if (testConfiguration.Roles[int.Parse(job_index)] == "publisher")
            {
                var publisher = new Publisher(testConfiguration, metrics);
                roleTask = publisher.Start(roleCancellationSource.Token);
            }

            // if (testConfiguration.Roles[int.Parse(job_index)] == "bufferedpublisher")
            // {
            //     var publisher = new BufferedPublisher(testConfiguration, metrics);
            //     roleTask = publisher.Start(roleCancellationSource.Token);
            // }

            await roleTask;
        }

        /// <summary>
        ///   The available command line options that can be parsed.
        /// </summary>
        ///
        internal class Options
        {
            [Option('i', "interactive", HelpText = "Set up stress tests in interactive mode.")]
            public bool Interactive { get; set; }

            [Option("all", HelpText = "Run all available tests.")]
            public bool All { get; set; }

            [Option('t', "test", HelpText = "Enter which test to run.")]
            public string Test { get; set; }
        }
    }
}
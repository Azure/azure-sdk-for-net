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
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The main program thread that allows for both local and deployed test runs.
///   Determines which tests should be run and starts them in the background.
/// </summary>
///
public class Program
{
    /// <summary>
    ///   Parses the command line <see cref="Options" /> and runs the specified tests.
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
    ///   Starts a background task for each test and role that needs to be run in this process, and waits for all
    ///   test runs to completed before finishing the run.
    /// </summary>
    ///
    /// <param name="opts">The parsed command line inputs.</param>
    ///
    private static async Task RunOptions(Options opts)
    {
        // See if there are environment variables available to use in the .env file
        var environment = new Dictionary<string, string>();
        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        if (!(string.IsNullOrEmpty(environmentFile)))
        {
            environment = EnvironmentReader.LoadFromFile(environmentFile);
        }

        environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out var appInsightsKey);
        environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out var eventHubsConnectionString);

        // If not, and this is an interactive run, try and get them from the user.

        eventHubsConnectionString = PromptForResources("Event Hubs Connection String", "all test runs", eventHubsConnectionString, opts.Interactive);
        appInsightsKey = PromptForResources("Application Insights Instrumentation Key", "all test runs", appInsightsKey, opts.Interactive);

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.

        var testScenarioTasks = new List<Task>();
        var testsToRun = opts.All ? Enum.GetValues(typeof(TestScenario)) : new TestScenario[]{StringToTestScenario(opts.Test)};

        var testConfiguration = new TestConfiguration();
        testConfiguration.EventHubsConnectionString = eventHubsConnectionString;

        var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
        cancellationSource.CancelAfter(runDuration);

        var metrics = new Metrics(appInsightsKey);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);

        try
        {
            foreach (TestScenario t in testsToRun)
            {
                var testName = TestScenarioToString(t);
                metrics.Client.Context.GlobalProperties["TestName"] = testName;
                var eventHubName = string.Empty;
                var storageBlob = string.Empty;
                var storageConnectionString = string.Empty;

                switch (t)
                {
                    case TestScenario.BufferedProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubBufferedProducerTest, out eventHubName);
                        testConfiguration.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var bufferedProducerTest = new BufferedProducerTest(testConfiguration, metrics, opts.Role);
                        testScenarioTasks.Add(bufferedProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenario.BurstBufferedProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out eventHubName);
                        testConfiguration.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var burstBufferedProducerTest = new BurstBufferedProducerTest(testConfiguration, metrics, opts.Role);
                        testScenarioTasks.Add(burstBufferedProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenario.EventProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);
                        testConfiguration.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var eventProducerTest = new EventProducerTest(testConfiguration, metrics, opts.Role);
                        testScenarioTasks.Add(eventProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenario.ProcessorTest:
                        // Get the Event Hub name for this test
                        environment.TryGetValue(EnvironmentVariables.EventHubProcessorTest, out eventHubName);
                        testConfiguration.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        // Get the storage blob name for this test
                        environment.TryGetValue(EnvironmentVariables.StorageBlobProcessorTest, out storageBlob);
                        testConfiguration.BlobContainer = PromptForResources("Storage Blob Name", testName, storageBlob, opts.Interactive);

                        // Get the storage account connection string for this test
                        environment.TryGetValue(EnvironmentVariables.StorageAccountProcessorTest, out storageConnectionString);
                        testConfiguration.StorageConnectionString = PromptForResources("Storage Account Connection String", testName, storageConnectionString, opts.Interactive);

                        var processorTest = new ProcessorTest(testConfiguration, metrics, opts.Role);
                        testScenarioTasks.Add(processorTest.RunTestAsync(cancellationSource.Token));
                        break;
                }
            }

            var tasksWaiting = Task.WhenAll(testScenarioTasks);

            while (tasksWaiting.Status == TaskStatus.Running)
            {
                metrics.UpdateEnvironmentStatistics();

                await Task.Delay(TimeSpan.FromMinutes(5), cancellationSource.Token).ConfigureAwait(false);
            }

            await tasksWaiting.ConfigureAwait(false);
            // Wait for all tests scenarios to finish before returning.
        }
        catch (TaskCanceledException)
        {
            // Run is complete
        }
        catch (Exception ex) when
            (ex is OutOfMemoryException
            || ex is StackOverflowException
            || ex is ThreadAbortException)
        {
            throw;
        }
        catch (Exception ex)
        {
            metrics.Client.TrackException(ex);
        }
        finally
        {
            metrics.Client.Flush();
            await Task.Delay(60000).ConfigureAwait(false);
        }
    }

    public static string TestScenarioToString(TestScenario testScenario) => testScenario switch
    {
        TestScenario.BufferedProducerTest => "BufferedProducerTest",
        TestScenario.BurstBufferedProducerTest => "BurstBufferedProducerTest",
        TestScenario.EventProducerTest => "EventProducerTest",
        TestScenario.ProcessorTest => "ProcessorTest",
        _ => string.Empty,
    };

    public static TestScenario StringToTestScenario(string testScenario) => testScenario switch
    {
        "BufferedProducerTest" or "BuffProd"=> TestScenario.BufferedProducerTest,
        "BurstBufferedProducerTest" => TestScenario.BurstBufferedProducerTest,
        "EventProducerTest" or "EventProd"=> TestScenario.EventProducerTest,
        "ProcessorTest" or "Processor"=> TestScenario.ProcessorTest,
        _ => throw new ArgumentNullException(),
    };

    /// <summary>
    ///   Prompts the user using the command line for resources if they have not been provided yet.
    /// </summary>
    ///
    /// <param name="resourceName">The name of the needed resource.</param>
    /// <param name="testName">Which test(s) for which the resource is needed.</param>
    /// <param name="currentValue">The current value of the resource.</param>
    ///
    private static string PromptForResources(string resourceName, string testName, string currentValue, bool interactive)
    {
        // If the resource hasn't been provided already, wait for it to be provided through the CLI
        if (interactive)
        {
            while (string.IsNullOrEmpty(currentValue))
            {
                Console.Write($"Please provide the {resourceName} for {testName}: ");
                currentValue = Console.ReadLine().Trim();
            }
        }

        if (string.IsNullOrEmpty(currentValue))
        {
            throw new ArgumentNullException(resourceName);
        }

        return currentValue;
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

        [Option('t', "test", HelpText = "Enter which test to run for a single test run.")]
        public string Test { get; set; }

        [Option('r', "role", HelpText = "Enter which role.")]
        public string Role { get; set; }
    }
}

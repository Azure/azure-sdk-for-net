// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using CommandLine;
using System.Threading;
using System.Threading.Tasks;
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
        var testsToRun = opts.All ? Enum.GetValues(typeof(TestScenarioName)) : new TestScenarioName[]{StringToTestScenario(opts.Test)};

        var testParameters = new TestParameters();
        testParameters.EventHubsConnectionString = eventHubsConnectionString;

        var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(testParameters.DurationInHours);
        cancellationSource.CancelAfter(runDuration);

        var metrics = new Metrics(appInsightsKey);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);

        try
        {
            foreach (TestScenarioName testScenario in testsToRun)
            {
                var testName = testScenario.ToString();
                metrics.Client.Context.GlobalProperties["TestName"] = testName;
                var eventHubName = string.Empty;
                var storageBlob = string.Empty;
                var storageConnectionString = string.Empty;

                metrics.Client.TrackEvent("Starting a test run.");

                switch (testScenario)
                {
                    case TestScenarioName.BufferedProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubBufferedProducerTest, out eventHubName);
                        testParameters.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var bufferedProducerTest = new BufferedProducerTest(testParameters, metrics, opts.Role);
                        testScenarioTasks.Add(bufferedProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenarioName.BurstBufferedProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out eventHubName);
                        testParameters.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var burstBufferedProducerTest = new BurstBufferedProducerTest(testParameters, metrics, opts.Role);
                        testScenarioTasks.Add(burstBufferedProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenarioName.EventProducerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);
                        testParameters.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var eventProducerTest = new EventProducerTest(testParameters, metrics, opts.Role);
                        testScenarioTasks.Add(eventProducerTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenarioName.ProcessorTest:
                        // Get the Event Hub name for this test
                        environment.TryGetValue(EnvironmentVariables.EventHubProcessorTest, out eventHubName);
                        testParameters.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        // Get the storage blob name for this test
                        environment.TryGetValue(EnvironmentVariables.StorageBlobProcessorTest, out storageBlob);
                        testParameters.BlobContainer = PromptForResources("Storage Blob Name", testName, storageBlob, opts.Interactive);

                        // Get the storage account connection string for this test
                        environment.TryGetValue(EnvironmentVariables.StorageAccountProcessorTest, out storageConnectionString);
                        testParameters.StorageConnectionString = PromptForResources("Storage Account Connection String", testName, storageConnectionString, opts.Interactive);

                        var processorTest = new ProcessorTest(testParameters, metrics, opts.Role);
                        testScenarioTasks.Add(processorTest.RunTestAsync(cancellationSource.Token));
                        break;

                    case TestScenarioName.ConsumerTest:
                        environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out eventHubName);
                        testParameters.EventHub = PromptForResources("Event Hub", testName, eventHubName, opts.Interactive);

                        var consumerTest = new ConsumerTest(testParameters, metrics, opts.Role);
                        testScenarioTasks.Add(consumerTest.RunTestAsync(cancellationSource.Token));
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

            metrics.Client.TrackEvent("Test run is ending.");
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
            testParameters.Dispose();
            metrics.Client.Flush();
            await Task.Delay(60000).ConfigureAwait(false);
        }
    }

    /// <summary>
    ///   Converts a string into a <see cref="TestScenarioName"/> value.
    /// </summary>
    ///
    /// <param name="testScenario">The string to convert to a <see cref="TestScenarioName"/>.</param>
    ///
    /// <returns>The <see cref="TestScenarioName"/> of the string input.</returns>
    ///
    public static TestScenarioName StringToTestScenario(string testScenario) => testScenario switch
    {
        "BufferedProducerTest" or "BuffProd" => TestScenarioName.BufferedProducerTest,
        "BurstBufferedProducerTest" or "BurstBuffProd" => TestScenarioName.BurstBufferedProducerTest,
        "EventProducerTest" or "EventProd" => TestScenarioName.EventProducerTest,
        "ProcessorTest" or "Processor" => TestScenarioName.ProcessorTest,
        "ConsumerTest" or "Consumer" => TestScenarioName.ConsumerTest,
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
    /// <returns>The value of the <paramref name="resourceName"/> either previously provided or received through the command line.</returns>
    ///
    /// <exception cref="ArgumentNullException">Occurs when no resource was provided for the test through the environment file or the command line.</exception>
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

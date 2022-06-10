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
        var appInsightsKey = String.Empty;
        var eventHubsConnectionString = String.Empty;

        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        if (!(string.IsNullOrEmpty(environmentFile)))
        {
            environment = EnvironmentReader.LoadFromFile(environmentFile);
        }

        environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out appInsightsKey);
        environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out eventHubsConnectionString);

        // If not, and this is an interactive run, try and get them from the user.

        eventHubsConnectionString = PromptForResources("Event Hubs Connection String", "all test runs", eventHubsConnectionString, opts.Interactive);
        appInsightsKey = PromptForResources("Application Insights Instrumentation Key", "all test runs", appInsightsKey, opts.Interactive);

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.

        var roleConfiguration = new RoleConfiguration();
        var testScenarioTasks = new List<Task>();
        var metrics = new Metrics(appInsightsKey);

        var testConfiguration = new TestConfiguration();
        testConfiguration.EventHubsConnectionString = eventHubsConnectionString;

        var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
        cancellationSource.CancelAfter(runDuration);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);

        // If running the Event Producer Test scenario, gather resources and add a scenario run to the task list.
        if (opts.Test == RoleConfiguration.EventProducerTest || opts.Test == RoleConfiguration.EventProducerTestShort || opts.All)
        {
            // Get the needed resources for the event producer test: an event hub
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);
            eventHubName = PromptForResources("Event Hub", RoleConfiguration.EventProducerTest, eventHubName, opts.Interactive);
            testConfiguration.EventHub = eventHubName;

            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.EventProducerTest, out var roleList);
            testScenarioTasks.Add(RunScenario(roleList, testConfiguration, roleConfiguration, metrics, opts.Role, RoleConfiguration.EventProducerTest, cancellationSource.Token));
        }

        // If running the Buffered Producer Test scenario, gather resources and add a scenario run to the task list.
        if (opts.Test == RoleConfiguration.BufferedProducerTest || opts.Test == RoleConfiguration.BufferedProducerTestShort || opts.All)
        {
            // Get the needed resources for the buffered producer test: an event hub
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubBufferedProducerTest, out eventHubName);
            eventHubName = PromptForResources("Event Hub", RoleConfiguration.BufferedProducerTest, eventHubName, opts.Interactive);
            testConfiguration.EventHub = eventHubName;

            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.BufferedProducerTest, out var roleList);
            testScenarioTasks.Add(RunScenario(roleList, testConfiguration, roleConfiguration, metrics, opts.Role, RoleConfiguration.BufferedProducerTest, cancellationSource.Token));
        }

        // If running the Burst Buffered Producer Test scenario, gather resources and add a scenario run to the task list.
        if (opts.Test == RoleConfiguration.BurstBufferedProducerTest || opts.Test == RoleConfiguration.BurstBufferedProducerTestShort || opts.All)
        {
            // Get the needed resources for the buffered producer test: an event hub
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubBurstBufferedProducerTest, out eventHubName);
            eventHubName = PromptForResources("Event Hub", "Burst Buffered Producer Test", eventHubName, opts.Interactive);
            testConfiguration.EventHub = eventHubName;

            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.BurstBufferedProducerTest, out var roleList);
            testScenarioTasks.Add(RunScenario(roleList, testConfiguration, roleConfiguration, metrics, opts.Role, RoleConfiguration.BurstBufferedProducerTest, cancellationSource.Token));
        }

        // If running the Processor Test scenario, gather resources and add a scenario run to the task list.
        if (opts.Test == RoleConfiguration.EventProcessorTest || opts.Test == RoleConfiguration.EventProcessorTestShort || opts.All)
        {
            // Get the needed resources for the processor test: an event hub, storage account, and blob container name
            var eventHubName = String.Empty;
            var storageBlob = String.Empty;
            var storageConnectionString = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubProcessorTest, out eventHubName);
            eventHubName = PromptForResources("Event Hub", RoleConfiguration.EventProcessorTest, eventHubName, opts.Interactive);
            testConfiguration.EventHub = eventHubName;

            environment.TryGetValue(EnvironmentVariables.StorageBlobProcessorTest, out storageBlob);
            storageBlob = PromptForResources("Storage Blob Name", RoleConfiguration.EventProcessorTest, storageBlob, opts.Interactive);
            testConfiguration.BlobContainer = storageBlob;

            environment.TryGetValue(EnvironmentVariables.StorageAccountProcessorTest, out storageConnectionString);
            storageConnectionString = PromptForResources("Storage Account Connection String", RoleConfiguration.EventProcessorTest, storageConnectionString, opts.Interactive);
            testConfiguration.StorageConnectionString = storageConnectionString;

            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.EventProcessorTest, out var roleList);
            testScenarioTasks.Add(RunScenario(roleList, testConfiguration, roleConfiguration, metrics, opts.Role, RoleConfiguration.BurstBufferedProducerTest, cancellationSource.Token));
        }

        // Wait for all scenario runs to finish before returning.
        await Task.WhenAll(testScenarioTasks).ConfigureAwait(false);
    }

    /// <summary>
    ///   Runs all of the roles designated for this scenario. If this is a single-role instance, only one role is run, otherwise all roles
    ///   are run in parallel.
    /// </summary>
    ///
    /// <param name="roleList">The list of roles needed for the scenario being run.</param>
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> instance used to configure this test scenario run.</param>
    /// <param name="roleConfiguration">The <see cref="RoleConfiguration" /> instance used to configure the role being run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used by this role to send metrics to application insights.</param>
    /// <param name="testName">The name of the test scenario that is being run, for metrics purposes.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    private static async Task RunScenario(List<string> roleList,
                                           TestConfiguration testConfiguration,
                                           RoleConfiguration roleConfiguration,
                                           Metrics metrics,
                                           string roleString,
                                           string testName,
                                           CancellationToken cancellationToken)
    {
        var scenarioTasks = new List<Task>();
        try
        {
            // This means the job index environment variable was not set, so run all roles for this scenario in parallel.
            if (string.IsNullOrEmpty(roleString))
            {
                foreach (var role in roleList)
                {
                    scenarioTasks.Add(RunRole(role, testConfiguration, roleConfiguration, metrics, testName, cancellationToken));
                }
            }
            else
            {
                scenarioTasks.Add(RunRole(roleList[int.Parse(roleString)], testConfiguration, roleConfiguration, metrics, testName, cancellationToken));
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                UpdateEnvironmentStatistics(metrics);

                await Task.Delay(TimeSpan.FromMinutes(5), cancellationToken).ConfigureAwait(false);
            }

            await Task.WhenAll(scenarioTasks).ConfigureAwait(false);
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

    /// <summary>
    ///   Starts a background task for each test that needs to be run, and waits for all
    ///   test runs to completed before returning.
    /// </summary>
    ///
    /// <param name="roleList">The list of roles needed for the scenario being run.</param>
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> instance used to configure this test scenario run.</param>
    /// <param name="roleConfiguration">The <see cref="RoleConfiguration" /> instance used to configure the role being run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used by this role to send metrics to application insights.</param>
    /// <param name="testName">The name of the test scenario that is being run, for metrics purposes.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToke"/> instance to signal the request to cancel the operation.</param>
    ///
    private static async Task RunRole(string role,
                                      TestConfiguration testConfiguration,
                                      RoleConfiguration roleConfiguration,
                                      Metrics metrics,
                                      string testName,
                                      CancellationToken cancellationToken)
    {
        if (role == RoleConfiguration.Publisher)
        {
            var publisherConfiguration = new PublisherConfiguration();
            var publisher = new Publisher(publisherConfiguration, testConfiguration, metrics, testName);
            await publisher.Start(cancellationToken);
        }

        if (role == RoleConfiguration.BufferedPublisher)
        {
            var publisherConfiguration = new BufferedPublisherConfiguration();
            var publisher = new BufferedPublisher(testConfiguration, publisherConfiguration, metrics, testName);
            await publisher.Start(cancellationToken);
        }

        if (role == RoleConfiguration.Processor)
        {
            var partitionCount = _getPartitionCount(testConfiguration.EventHubsConnectionString, testConfiguration.EventHub);
            await partitionCount.ConfigureAwait(false);
            var processConfiguration = new ProcessorConfiguration();
            var processor = new Processor(testConfiguration, processConfiguration, metrics, partitionCount.Result, testName);
            await processor.Start(cancellationToken);
        }

        if (role == RoleConfiguration.BurstBufferedPublisher)
        {
            var publisherConfiguration = new BufferedPublisherConfiguration();
            publisherConfiguration.ProducerPublishingDelay = TimeSpan.FromMinutes(25);
            var publisher = new BufferedPublisher(testConfiguration, publisherConfiguration, metrics, testName);
            await publisher.Start(cancellationToken);
        }

        //return Task.CompletedTask;
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    /// <summary>
    ///   Collects garbage collection environment metrics and sends them to Application Insights.
    /// </summary>
    ///
    /// <param name="metrics">The <see cref="Metrics" /> instance to use to send metrics to Application Insights.</param>
    ///
    private static void UpdateEnvironmentStatistics(Metrics metrics)
    {
        metrics.Client.GetMetric(Metrics.GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
        metrics.Client.GetMetric(Metrics.GenerationOneCollections).TrackValue(GC.CollectionCount(1));
        metrics.Client.GetMetric(Metrics.GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
    }

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
    ///   Starts a background task for each test that needs to be run, and waits for all
    ///   test runs to completed before returning.
    /// </summary>
    ///
    /// <param name="eventHubsConnectionString">The connection string to connect to the Event Hubs namespace for this test.</param>
    /// <param name="eventHubName">The name of the Event Hub to send events to for this test.</param>
    ///
    private static async Task<int> _getPartitionCount(string eventHubsConnectionString, string eventHubName)
    {
        int partitionCount;

        await using (var producerClient = new EventHubProducerClient(eventHubsConnectionString, eventHubName))
        {
            partitionCount = (await producerClient.GetEventHubPropertiesAsync()).PartitionIds.Length;
        }

        return partitionCount;
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

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

namespace Azure.Messaging.EventHubs.Stress;

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

        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        if (!(string.IsNullOrEmpty(environmentFile)))
        {
            environment = EnvironmentReader.LoadFromFile(environmentFile);
        }

        environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out appInsightsKey);
        environment.TryGetValue(EnvironmentVariables.EventHubsConnectionString, out eventHubsConnectionString);

        // TODO get from interactive mode if needed

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.
        environment.TryGetValue(EnvironmentVariables.JobCompletionIndex, out var job_index);
        Console.WriteLine($"JOB INDEX: {job_index}");

        var roleConfiguration = new RoleConfiguration();

        var testScenarioTasks = new List<Task>();

        if (opts.Test == "EventProd" || opts.Test == "EventProducerTest" || opts.All)
        {
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);

            // TODO: check for interactive

            // Set up the test's configuration
            var testConfiguration = new TestConfiguration();
            testConfiguration.EventHubsConnectionString = eventHubsConnectionString;
            testConfiguration.EventHub = eventHubName;

            var cancellationSource = new CancellationTokenSource();
            var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
            cancellationSource.CancelAfter(runDuration);

            var metrics = new Metrics(appInsightsKey);
            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.EventProducerTest, out var roleList);

            testScenarioTasks.Add(_runScenario(roleList, testConfiguration, roleConfiguration, metrics, job_index, cancellationSource.Token));
        }

        if (opts.Test == "BuffProd" || opts.Test == "BufferedProducerTest" || opts.All)
        {
            // Get the resources for this specific test
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);

            // TODO: check for interactive

            // Set up the test's configuration
            var testConfiguration = new TestConfiguration();
            testConfiguration.EventHubsConnectionString = eventHubsConnectionString;
            testConfiguration.EventHub = eventHubName;

            var cancellationSource = new CancellationTokenSource();
            var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
            cancellationSource.CancelAfter(runDuration);

            var metrics = new Metrics(appInsightsKey);
            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.BufferedProducerTest, out var roleList);

            testScenarioTasks.Add(_runScenario(roleList, testConfiguration, roleConfiguration, metrics, job_index, cancellationSource.Token));
        }

        if (opts.Test == "Processor" || opts.Test == "EventProcessorTest" || opts.All)
        {
            // Get the resources for this specific test
            var eventHubName = String.Empty;
            environment.TryGetValue(EnvironmentVariables.EventHubEventProducerTest, out eventHubName);

            // TODO: check for interactive

            // Set up the test's configuration
            var testConfiguration = new TestConfiguration();
            testConfiguration.EventHubsConnectionString = eventHubsConnectionString;
            testConfiguration.EventHub = eventHubName;

            var cancellationSource = new CancellationTokenSource();
            var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
            cancellationSource.CancelAfter(runDuration);

            var metrics = new Metrics(appInsightsKey);
            roleConfiguration.TestScenarioRoles.TryGetValue(RoleConfiguration.BufferedProducerTest, out var roleList);

            testScenarioTasks.Add(_runScenario(roleList, testConfiguration, roleConfiguration, metrics, job_index, cancellationSource.Token));
        }

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
    /// <param name="jobIndex">If this is a single-role run, this is the value used to determine which role should be run.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToke"/> instance to signal the request to cancel the operation.</param>
    ///
    private static async Task _runScenario(List<string> roleList,
                                           TestConfiguration testConfiguration,
                                           RoleConfiguration roleConfiguration,
                                           Metrics metrics,
                                           string jobIndex,
                                           CancellationToken cancellationToken)
    {
        var scenarioTasks = new List<Task>();
        try
        {
            // This means the job index environment variable was not set, so run all roles for this scenario in parallel.
            if (string.IsNullOrEmpty(jobIndex))
            {
                foreach (var role in roleList)
                {
                    scenarioTasks.Add(_runRole(role, testConfiguration, roleConfiguration, metrics, cancellationToken));
                }
            }
            else
            {
                scenarioTasks.Add(_runRole(roleList[int.Parse(jobIndex)], testConfiguration, roleConfiguration, metrics, cancellationToken));
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                _updateEnvironmentStatistics(metrics);

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
    /// <param name="jobIndex">If this is a single-role run, this is the value used to determine which role should be run.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToke"/> instance to signal the request to cancel the operation.</param>
    ///
    private static async Task _runRole(string role, TestConfiguration testConfiguration, RoleConfiguration roleConfiguration, Metrics metrics, CancellationToken cancellationToken)
    {
        if (role == RoleConfiguration.Publisher)
        {
            var publisherConfiguration = new PublisherConfiguration();
            var publisher = new Publisher(publisherConfiguration, testConfiguration, metrics);
            await publisher.Start(cancellationToken);
        }

        if (role == RoleConfiguration.BufferedPublisher)
        {
            var publisherConfiguration = new BufferedPublisherConfiguration();
            var publisher = new BufferedPublisher(testConfiguration, publisherConfiguration, metrics);
            await publisher.Start(cancellationToken);
        }

        if (role == RoleConfiguration.Processor)
        {
            var partitionCount = _getPartitionCount(testConfiguration.EventHubsConnectionString, testConfiguration.EventHub);
            await partitionCount.ConfigureAwait(false);
            var processConfiguration = new ProcessorConfiguration();
            var processor = new Processor(testConfiguration, processConfiguration, metrics, partitionCount.Result);
            await processor.Start(cancellationToken);
        }

        //return Task.CompletedTask;
        await Task.Delay(TimeSpan.FromSeconds(1));
    }

    private static void _updateEnvironmentStatistics(Metrics metrics)
    {
        metrics.Client.GetMetric(metrics.GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
        metrics.Client.GetMetric(metrics.GenerationOneCollections).TrackValue(GC.CollectionCount(1));
        metrics.Client.GetMetric(metrics.GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
    }

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
    }
}
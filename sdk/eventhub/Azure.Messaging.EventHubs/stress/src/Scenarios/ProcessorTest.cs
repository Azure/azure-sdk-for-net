// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests;
using System.Linq;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the Processor test scenario.
/// <summary/>
///
public class ProcessorTest
{
    /// <summary>The <see cref="TestConfiguration"/> used to configure this test scenario.</summary>
    private readonly TestConfiguration _testConfiguration;

    // <summary>The index used to determine which role should be run if this is a distributed test run.</summary>
    private readonly string _jobIndex;

    /// <summary> The <see cref="Metrics"/> instance used to send metrics to application insights.</summary>
    private Metrics _metrics;

    /// <summary>The identifier of the <see cref="Processor"/> used by this instance.</summary>
    private string _identifier;

    /// <summary>The number of current handler calls happening within the same partition.</summary>
    private int[] _partitionHandlerCalls;

    /// <sumarry>The <see cref="EventTracking" instance used to validate events upon reading them.</summary>
    private EventTracking _eventProcessing = new EventTracking();

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    private static Role[] _roles = {Role.PartitionPublisher, Role.Processor, Role.Processor, Role.Processor};

    /// <summary>
    ///  Initializes a new <see cref="ProcessorTest"/> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration"/> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public ProcessorTest(TestConfiguration testConfiguration, Metrics metrics, string jobIndex = default)
    {
        _testConfiguration = testConfiguration;
        _jobIndex = jobIndex;
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = $"net-processor-{Guid.NewGuid().ToString()}";
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the Processor test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunTestAsync(CancellationToken cancellationToken)
    {
        var partitionCount = await _testConfiguration.GetEventHubPartitionCountAsync().ConfigureAwait(false);
        _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();

        var runAllRoles = !int.TryParse(_jobIndex, out var roleIndex);
        var testRunTasks = new List<Task>();

        if (runAllRoles)
        {
            foreach (Role role in _roles)
            {
                testRunTasks.Add(RunRoleAsync(role, roleIndex, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(_roles[roleIndex], roleIndex, cancellationToken));
        }

        await Task.WhenAll(testRunTasks).ConfigureAwait(false);
    }

    /// <summary>
    ///   Creates a role instance and runs that role.
    /// </summary>
    ///
    /// <param name="role">The <see cref="Role"/> to run.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunRoleAsync(Role role, int roleIndex, CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.Processor:
                var processorConfiguration = new ProcessorConfiguration();
                var partitionCount = await _testConfiguration.GetEventHubPartitionCountAsync().ConfigureAwait(false);
                var processor = new Processor(_testConfiguration, processorConfiguration, _metrics, partitionCount);
                _identifier = processor.Identifier;

                _metrics.Client.TrackEvent("Starting to process events");
                await processor.StartAsync(ProcessEventHandler, ProcessErrorHandler, cancellationToken).ConfigureAwait(false);
                _metrics.Client.TrackEvent("Stopping processing events");
                break;

            case Role.PartitionPublisher:
                var partitionPublisherConfiguration = new PartitionPublisherConfiguration();
                var partitionsCount = await _testConfiguration.GetEventHubPartitionCountAsync().ConfigureAwait(false);
                var partitionIds = await _testConfiguration.GetEventHubPartitionKeysAsync().ConfigureAwait(false);
                var partitions = EventTracking.GetAssignedPartitions(partitionsCount, roleIndex, partitionIds, _roles);

                var partitionPublisher = new PartitionPublisher(partitionPublisherConfiguration, _testConfiguration, _metrics, partitions);
                _metrics.Client.TrackEvent("Starting to publish events");
                await partitionPublisher.StartAsync(cancellationToken).ConfigureAwait(false);
                _metrics.Client.TrackEvent("Stopping publishing events.");
                break;

            default:
                break;
        }
    }

    /// <summary>
    ///   The method to pass to the <see cref="EventProcessorClient" /> instance as the <see cref="EventProcessorClient.ProcessEventAsync" />
    ///   event handler.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessEventArgs" /> used to pass information to the event handler.</param>
    ///
    private Task ProcessEventHandler(ProcessEventArgs args)
    {
        var partitionIndex = int.Parse(args.Partition.PartitionId);

        try
        {
            // There should only be one active call for a given partition; track any concurrent calls for this partition
            // and report them as an error.

            var activeCalls = Interlocked.Increment(ref _partitionHandlerCalls[partitionIndex]);

            if (activeCalls > 1)
            {
                if (!args.Data.Properties.TryGetValue(nameof(EventGenerator), out var duplicateId))
                {
                    duplicateId = "(unknown)";
                }

                _metrics.Client.TrackException(new InvalidOperationException($"The handler for processing events was invoked concurrently for processor: `{ _identifier }`,  partition: `{ args.Partition.PartitionId }`, event: `{ duplicateId }`.  Count: `{ activeCalls }`"));
            }

            // Increment total service operations metric
            if (args.HasEvent)
            {
                _metrics.Client.GetMetric(Metrics.EventsRead).TrackValue(1);

                _eventProcessing.ProcessEventAsync(args, _metrics);

                _metrics.Client.GetMetric(Metrics.EventsProcessed).TrackValue(1);
            }
        }
        catch (Exception ex)
        {
            _metrics.Client.TrackException(ex);
        }
        finally
        {
            _metrics.Client.GetMetric(Metrics.EventHandlerCalls, Metrics.Identifier).TrackValue(1, _identifier);
            Interlocked.Decrement(ref _partitionHandlerCalls[partitionIndex]);
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///   The method to pass to the <see cref="EventProcessorClient" /> instance as the <see cref="EventProcessorClient.ProcessErrorAsync" />
    ///   event handler.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessErrorEventArgs" /> used to pass information to the error handler.</param>
    ///
    private Task ProcessErrorHandler(ProcessErrorEventArgs args)
    {
        var exceptionProperties = new Dictionary<string, string>();
        _metrics.Client.TrackException(args.Exception);
        return Task.CompletedTask;
    }
}
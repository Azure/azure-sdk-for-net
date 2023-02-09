// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Concurrent;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the Processor test scenario.
/// <summary/>
///
public class ProcessorTest : TestScenario
{
    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "ConsumerTest";

    /// <summary>The identifier of the <see cref="Processor"/> used by this instance.</summary>
    private string _identifier;

    /// <summary>The number of current handler calls happening within the same partition.</summary>
    private int[] _partitionHandlerCalls;

    /// <summary>The ids of all of the partitions.</summary>
    private string[] _partitionIds;

    /// <summary>Holds the set of events that have been read by this instance. The key is the unique Id set by the producer.</summary>
    private ConcurrentDictionary<string, byte> _readEvents { get; } = new ConcurrentDictionary<string, byte>();

    /// <summary>Holds the last read sequence value for each partition this instance has read from so far.</summary>
    private ConcurrentDictionary<string, int> _lastReadPartitionSequence { get; } = new ConcurrentDictionary<string, int>();

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.PartitionPublisher, Role.Processor, Role.Processor, Role.Processor};

    /// <summary>
    ///  Initializes a new <see cref="ProcessorTest"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public ProcessorTest(TestParameters testParameters,
                         Metrics metrics) : base(testParameters, metrics, $"net-processor-{Guid.NewGuid().ToString()}")
    {
    }

    /// <summary>
    ///   Runs all of the roles required for this instance of the Processor test scenario.
    /// </summary>
    ///
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async override Task RunTestAsync(CancellationToken cancellationToken)
    {
        _partitionIds = await _testParameters.GetEventHubPartitionsAsync().ConfigureAwait(false);
        var partitionCount = _partitionIds.Length;
        _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();

        var testRunTasks = new List<Task>();

        if (_testParameters.RunAllRoles)
        {
            foreach (Role role in Roles)
            {
                testRunTasks.Add(RunRoleAsync(role, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(Roles[_testParameters.JobIndex], cancellationToken));
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
    internal override Task RunRoleAsync(Role role,
                              CancellationToken cancellationToken)
    {
        var partitionCount = _partitionIds.Length;
        switch (role)
        {
            case Role.Processor:
                var processorConfiguration = new ProcessorConfiguration();
                var processor = new Processor(_testParameters, processorConfiguration, _metrics, partitionCount);
                _identifier = processor.Identifier;
                _metrics.Client.TrackEvent("Starting to process events");
                return Task.Run(() => processor.RunAsync(ProcessEventHandler, ProcessErrorHandler, cancellationToken));

            case Role.PartitionPublisher:
                var partitionPublisherConfiguration = new PartitionPublisherConfiguration();
                var assignedPartitions = EventTracking.GetAssignedPartitions(partitionCount, _testParameters.JobIndex, _partitionIds, Roles);
                var partitionPublisher = new PartitionPublisher(partitionPublisherConfiguration, _testParameters, _metrics, assignedPartitions);
                _metrics.Client.TrackEvent("Starting to publish events");
                return Task.Run(() => partitionPublisher.RunAsync(cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
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

                EventTracking.ProcessEventAsync(args, _testParameters.Sha256Hash, _metrics, _lastReadPartitionSequence, _readEvents);

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
        exceptionProperties.Add(Metrics.PartitionId, args.PartitionId);
        _metrics.Client.TrackException(args.Exception, exceptionProperties);
        return Task.CompletedTask;
    }
}
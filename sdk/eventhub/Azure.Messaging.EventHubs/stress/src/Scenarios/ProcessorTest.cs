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

public class ProcessorTest
{
    private readonly TestConfiguration _testConfiguration;
    private readonly string _jobIndex;
    private Metrics _metrics;

    private string _identifier;

    /// <summary>The number of current handler calls happening within the same partition.</summary>
    private int[] _partitionHandlerCalls;

    private static Role[] _roles = {Role.BufferedPublisher, Role.BufferedPublisher};

    public ProcessorTest(TestConfiguration testConfiguration, Metrics metrics, string jobIndex = default)
    {
        _testConfiguration = testConfiguration;
        _jobIndex = jobIndex;
        _metrics = metrics;
        _metrics.Client.Context.GlobalProperties["TestRunID"] = $"net-burst-buff-{Guid.NewGuid().ToString()}";
    }

    public async Task RunTestAsync(CancellationToken cancellationToken)
    {
        var partitionCount = await _testConfiguration.GetEventHubPartitionCount().ConfigureAwait(false);
        _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();

        var runAllRoles = !int.TryParse(_jobIndex, out var roleIndex);
        var testRunTasks = new List<Task>();

        if (runAllRoles)
        {
            foreach (Role role in _roles)
            {
                testRunTasks.Add(RunRoleAsync(role, cancellationToken));
            }
        }
        else
        {
            testRunTasks.Add(RunRoleAsync(_roles[roleIndex], cancellationToken));
        }

        await Task.WhenAll(testRunTasks).ConfigureAwait(false);
    }

    public async Task RunRoleAsync(Role role, CancellationToken cancellationToken)
    {
        //GetEventHubPartitionKeysAsync
        switch (role)
        {
            case Role.Publisher:
                var publisherConfiguration = new PublisherConfiguration();
                var publisher = new Publisher(publisherConfiguration, _testConfiguration, _metrics);
                await publisher.Start(cancellationToken).ConfigureAwait(false);
                break;

            case Role.BufferedPublisher:
                var buffpublisherConfiguration = new BufferedPublisherConfiguration();
                var buffpublisher = new BufferedPublisher(_testConfiguration, buffpublisherConfiguration, _metrics);
                await buffpublisher.Start(cancellationToken).ConfigureAwait(false);
                break;

            case Role.Processor:
                var processorConfiguration = new ProcessorConfiguration();
                var partitionCount = await _testConfiguration.GetEventHubPartitionCount().ConfigureAwait(false);
                var processor = new Processor(_testConfiguration, processorConfiguration, _metrics, partitionCount);
                _identifier = processor.Identifier;
                await processor.Start(ProcessEventHandler, ProcessErrorHandler, cancellationToken).ConfigureAwait(false);
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
    /// <param name="args">The <see cref="ProcessErrorEventArgs" /> used to pass information to the errpr handler.</param>
    ///
    private Task ProcessErrorHandler(ProcessErrorEventArgs args)
    {
        var exceptionProperties = new Dictionary<string, string>();
        _metrics.Client.TrackException(args.Exception);
        return Task.CompletedTask;
    }

    private List<string> _getAssignedPartitions(int partitionCount, int roleIndex, string[] partitionIds)
    {
        var roleList = new List<Role>(_roles);

        var numPublishers = roleList.Where(role => (role == Role.Publisher || role == Role.BufferedPublisher)).Count();
        var thisPublisherIndex = (roleList.GetRange(0,roleIndex)).Where(role => (role == Role.Publisher || role == Role.BufferedPublisher)).Count();

        var baseNum = partitionCount/numPublishers;
        var remainder = partitionCount % numPublishers;

        var startPartition = 0;
        var endPartition = 0;

        if (thisPublisherIndex >= remainder)
        {
            startPartition = (baseNum*thisPublisherIndex) + remainder;
            endPartition = startPartition + baseNum;
        }
        else
        {
            startPartition = (baseNum*thisPublisherIndex) + thisPublisherIndex;
            endPartition = startPartition + baseNum + 1;
        }

        var assignedPartitions = new List<string>();

        for (int i = startPartition; i < endPartition; i++)
        {
            assignedPartitions.Add(partitionIds[i]);
        }

        return assignedPartitions;
    }

    
}
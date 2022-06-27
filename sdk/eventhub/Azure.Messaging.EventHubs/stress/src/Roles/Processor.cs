// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The role responsible for running a <see cref="EventProcessorClient" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many events are processed and read. It stops processing and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class Processor
{
    /// <summary>A unique identifier used to identify this processor instance.</summary>
    private string _identifier { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=').ToUpperInvariant();

    /// <summary>The number of current handler calls happening within the same partition.</summary>
    private int[] _partitionHandlerCalls { get; }

    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Processor" /> instance.</summary>
    private Metrics _metrics { get; }

    /// <summary>The <see cref="TestConfiguration" /> used to configure this test run.</summary>
    private TestConfiguration _testConfiguration { get; }

    /// <summary>The <see cref="ProcessorConfiguration" /> used to configure the instance of this role.</summary>
    private ProcessorConfiguration _processorConfiguration { get; }

    /// <summary>The name of the test being run for metrics collection.</summary>
    private readonly string _testName;

    /// <summary>
    ///   Initializes a new <see cref="Processor" \> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> used to configure the processor test scenario run.</param>
    /// <param name="processorConfiguration">The <see cref="ProcessorConfiguration" /> instance used to configure this instance of <see cref="Processor" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    /// <param name="partitionCount">The number of partitions in the Event Hub associated with this processor.</param>
    /// <param name="testName">The name of the test being run in order to organize metrics being collected.</param>
    ///
    public Processor(TestConfiguration testConfiguration,
                     ProcessorConfiguration processorConfiguration,
                     Metrics metrics,
                     int partitionCount,
                     string testName)
    {
        _testConfiguration = testConfiguration;
        _processorConfiguration = processorConfiguration;
        _metrics = metrics;
        _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();
        _testName = testName;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Processor"/> role. This role creates an <see cref="EventProcessorClient"/>
    ///   and monitors it while it processes events that have been sent to this test's event hub by an independent
    ///   <see cref="Publisher"/> role.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToke"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task Start(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = _identifier,
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,

                RetryOptions = new EventHubsRetryOptions
                {
                    TryTimeout = _processorConfiguration.ReadTimeout
                }
            };

            var processor = default(EventProcessorClient);

            try
            {
                var storageClient = new BlobContainerClient(_testConfiguration.StorageConnectionString, _testConfiguration.BlobContainer);
                processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, _testConfiguration.EventHubsConnectionString, _testConfiguration.EventHub, options);

                processor.ProcessEventAsync += ProcessEventHandler;
                processor.ProcessErrorAsync += ProcessErrorHandler;

                await processor.StartProcessingAsync(cancellationToken).ConfigureAwait(false);
                await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // No action needed.
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
                _metrics.Client.GetMetric(Metrics.ProcessorRestarted, Metrics.TestName).TrackValue(1, _testName);

                var exceptionProperties = new Dictionary<string, string>();
                exceptionProperties.Add(Metrics.TestName, _testName);
                _metrics.Client.TrackException(ex, exceptionProperties);
            }
            finally
            {
                // Constrain stopping the processor, just in case it has issues.  It should not be allowed
                // to hang, it should be abandoned so that processing can restart.

                using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(25));

                try
                {
                    if (processor != null)
                    {
                        await processor.StopProcessingAsync(cancellationSource.Token).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    _metrics.Client.GetMetric(Metrics.ProcessorRestarted, Metrics.TestName).TrackValue(1, _testName);

                    var exceptionProperties = new Dictionary<string, string>();
                    exceptionProperties.Add(Metrics.TestName, _testName);
                    _metrics.Client.TrackException(ex, exceptionProperties);
                }

                processor.ProcessEventAsync -= ProcessEventHandler;
                processor.ProcessErrorAsync -= ProcessErrorHandler;
            }
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

                var exceptionProperties = new Dictionary<string, string>();
                exceptionProperties.Add(Metrics.TestName, _testName);
                _metrics.Client.TrackException(new InvalidOperationException($"The handler for processing events was invoked concurrently for processor: `{ _identifier }`,  partition: `{ args.Partition.PartitionId }`, event: `{ duplicateId }`.  Count: `{ activeCalls }`"), exceptionProperties);
            }

            // increment total service operations metric
            if (args.HasEvent)
            {
                _metrics.Client.GetMetric(Metrics.EventsRead, Metrics.TestName).TrackValue(1, _testName);

                // TODO: event body and sequence validation

                _metrics.Client.GetMetric(Metrics.EventsProcessed, Metrics.TestName).TrackValue(1, _testName);
            }
        }
        catch (Exception ex)
        {
            var exceptionProperties = new Dictionary<string, string>();
            exceptionProperties.Add(Metrics.TestName, _testName);
            _metrics.Client.TrackException(ex, exceptionProperties);
        }
        finally
        {
            _metrics.Client.GetMetric(Metrics.EventHandlerCalls, Metrics.Identifier, Metrics.TestName).TrackValue(1, _identifier, _testName);
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
        exceptionProperties.Add(Metrics.TestName, _testName);
        _metrics.Client.TrackException(args.Exception, exceptionProperties);
        return Task.CompletedTask;
    }
}
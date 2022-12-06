// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
    public string Identifier { get; } = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=').ToUpperInvariant();

    /// <summary>The number of current handler calls happening within the same partition.</summary>
    private int[] _partitionHandlerCalls { get; }

    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Processor" /> instance.</summary>
    private Metrics _metrics { get; }

    /// <summary>The <see cref="TestParameters" /> used to run this test.</summary>
    private TestParameters _testParameters { get; }

    /// <summary>The <see cref="ProcessorConfiguration" /> used to configure the instance of this role.</summary>
    private ProcessorConfiguration _processorConfiguration { get; }

    /// <summary>
    ///   Initializes a new <see cref="Processor" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to run the processor test scenario.</param>
    /// <param name="processorConfiguration">The <see cref="ProcessorConfiguration" /> instance used to configure this instance of <see cref="Processor" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    /// <param name="partitionCount">The number of partitions in the Event Hub associated with this processor.</param>
    ///
    public Processor(TestParameters testParameters,
                     ProcessorConfiguration processorConfiguration,
                     Metrics metrics,
                     int partitionCount)
    {
        _testParameters = testParameters;
        _processorConfiguration = processorConfiguration;
        _metrics = metrics;
        _partitionHandlerCalls = Enumerable.Range(0, partitionCount).Select(index => 0).ToArray();
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Processor"/> role. This role creates an <see cref="EventProcessorClient"/>
    ///   and monitors it while it processes events that have been sent to this test's event hub by an independent
    ///   <see cref="Publisher"/> role.
    /// </summary>
    ///
    /// <param name="processEventHandler">The method to use for the <see cref="EventHubProcessorClient"/> process event handler.</param>
    /// <param name="processErrorHandler">The method to use for the <see cref="EventHubProcessorClient"/> process error handler.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(Func<ProcessEventArgs, Task> processEventHandler,
                               Func<ProcessErrorEventArgs, Task> processErrorHandler,
                               CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = Identifier,
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,

                RetryOptions = new EventHubsRetryOptions
                {
                    TryTimeout = _processorConfiguration.ReadTimeout
                }
            };

            var processor = default(EventProcessorClient);

            try
            {
                var storageClient = new BlobContainerClient(_testParameters.StorageConnectionString, _testParameters.BlobContainer);
                processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, _testParameters.EventHubsConnectionString, _testParameters.EventHub, options);

                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

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
                _metrics.Client.GetMetric(Metrics.ProcessorRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
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
                        _metrics.Client.TrackEvent("Stopping processing events");
                        await processor.StopProcessingAsync(cancellationSource.Token).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    _metrics.Client.GetMetric(Metrics.ProcessorRestarted).TrackValue(1);
                    _metrics.Client.TrackException(ex);
                }
                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }
        }
    }
}
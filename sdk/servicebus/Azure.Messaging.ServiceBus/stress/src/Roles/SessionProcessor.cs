// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The role responsible for running a <see cref="ServiceBusSessionProcessor" />, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" />. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are received and processed. It stops reading messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class SessionProcessor
{
    /// <summary>A unique identifier used to identify this processor instance.</summary>
    public string Identifier { get; } = Guid.NewGuid().ToString();

    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="SessionProcessor" /> instance.</summary>
    private Metrics _metrics;

    /// <summary>The <see cref="TestParameters" /> used to run this test.</summary>
    private TestParameters _testParameters;

    /// <summary>The <see cref="SessionProcessorConfiguration" /> used to configure the instance of this role.</summary>
    private SessionProcessorConfiguration _sessionProcessorConfiguration;

    /// <summary>
    ///   Initializes a new <see cref="SessionProcessor" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> used to configure the test scenario run.</param>
    /// <param name="sessionProcessorConfiguration">The <see cref="SessionProcessorConfiguration"/> instance used to configure this instance of <see cref="Receiver" />.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send metrics to Application Insights.</param>
    ///
    public SessionProcessor(TestParameters testParameters,
                     SessionProcessorConfiguration sessionProcessorConfiguration,
                     Metrics metrics)
    {
        _testParameters = testParameters;
        _sessionProcessorConfiguration = sessionProcessorConfiguration;
        _metrics = metrics;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="SessionProcessor"/> role. This role creates a <see cref="ServiceBusSessionProcessor"/>
    ///   and monitors it while it reads messages that have been sent to this test's Service Bus queue by independent
    ///   <see cref="Sender"/> role(s).
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(Func<ProcessSessionMessageEventArgs, Task> messageHandler, Func<ProcessErrorEventArgs, Task> errorHandler, CancellationToken cancellationToken)
    {
        await using var client = new ServiceBusClient(_testParameters.ServiceBusConnectionString);
        await using var processor = client.CreateSessionProcessor(_testParameters.QueueName);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                processor.ProcessMessageAsync += messageHandler;
                processor.ProcessErrorAsync += errorHandler;

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
                processor.ProcessMessageAsync -= messageHandler;
                processor.ProcessErrorAsync -= errorHandler;
            }
        }
    }
}
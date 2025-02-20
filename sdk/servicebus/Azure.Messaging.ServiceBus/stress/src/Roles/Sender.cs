// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The role responsible for running a <see cref="ServiceBusSender" />, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" />. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are processed and read. It stops sending messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class Sender
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Sender" /> instance.</summary>
    internal readonly Metrics _metrics;

    /// <summary>The <see cref="SenderConfiguration"/> used to configure the instance of this role.</summary>
    internal readonly SenderConfiguration _senderConfiguration;

    /// <summary>The <see cref="TestParameters"/> used to configure this test run.</summary>
    internal readonly TestParameters _testParameters;

    /// <summary>
    ///   Initializes a new <see cref="Sender"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the send and receive test scenario run.</param>
    /// <param name="senderConfiguration">The <see cref="SenderConfiguration" /> instance used to configure this instance of <see cref="Sender" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public Sender(TestParameters testParameters,
                  SenderConfiguration senderConfiguration,
                  Metrics metrics)
    {
        _metrics = metrics;
        _testParameters = testParameters;
        _senderConfiguration = senderConfiguration;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Sender" /> role. This role creates a <see cref="ServiceBusSender" />
    ///   and monitors it while it sends events to this test's dedicated Service Bus queue.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var sendTasks = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Create the Service Bus client and sender

            await using var client = new ServiceBusClient(_testParameters.ServiceBusConnectionString);
            var sender = client.CreateSender(_testParameters.QueueName, _senderConfiguration.options);

            try
            {
                // Start concurrent sending tasks

                for (var index = 0; index < _senderConfiguration.ConcurrentSends; ++index)
                {
                    sendTasks.Add(Task.Run(async () =>
                    {
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            await PerformSend(sender, cancellationToken).ConfigureAwait(false);

                            if ((_senderConfiguration.SendingDelay.HasValue) && (_senderConfiguration.SendingDelay.Value > TimeSpan.Zero))
                            {
                                await Task.Delay(_senderConfiguration.SendingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
                            }
                        }
                    }));
                }

                await Task.WhenAll(sendTasks).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // No action needed, the cancellation token has been cancelled.
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
                _metrics.Client.GetMetric(Metrics.SenderRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
        }
    }

    /// <summary>
    ///   Generates messages using the <see cref= "SenderConfiguration" /> instance associated with this role instance.
    ///   It then sends them to the Service Bus Queue. Any caught exceptions are sent to Application Insights.
    /// </summary>
    ///
    /// <param name="sender">The <see cref="ServiceBusSender" /> to use to send messages to for this test scenario run.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    internal virtual async Task PerformSend(ServiceBusSender sender,
                                      CancellationToken cancellationToken)
    {
        var batch = await sender.CreateMessageBatchAsync().ConfigureAwait(false);
        var messages = MessageBuilder.CreateMessages(_senderConfiguration.MaxNumberOfMessages,
                                                     batch.MaxSizeInBytes,
                                                     _senderConfiguration.LargeMessageRandomFactorPercent,
                                                     _senderConfiguration.MessageBodyMinBytes,
                                                     _senderConfiguration.MessageBodyMaxBytes);
        try
        {
            if (_senderConfiguration.UseBatches)
            {
                foreach (var message in messages)
                {
                    MessageTracking.AugmentMessage(message, _testParameters.Sha256Hash);
                    batch.TryAddMessage(message);
                }
                await sender.SendMessagesAsync(batch);
                _metrics.Client.GetMetric(Metrics.MessagesSent).TrackValue(batch.Count);
            }
            else
            {
                foreach (ServiceBusMessage message in messages)
                {
                    MessageTracking.AugmentMessage(message, _testParameters.Sha256Hash);
                    await sender.SendMessageAsync(message, cancellationToken).ConfigureAwait(false);
                    _metrics.Client.GetMetric(Metrics.MessagesSent).TrackValue(1);
                }
            }
        }
        catch (TaskCanceledException)
        {
            // Test is completed.
        }
        catch (Exception ex)
        {
            var exceptionProperties = new Dictionary<String, String>();
            // Track that the exception took place during the sending of an event
            exceptionProperties.Add("Process", "Send");
            _metrics.Client.TrackException(ex, exceptionProperties);
        }
    }
}
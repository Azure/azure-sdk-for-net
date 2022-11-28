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
///   The role responsible for running a <see cref="ServiceBusSender" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are processed and read. It stops sending messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class TransactionSender
{
    /// <summary>The <see cref="Metrics"/> instance associated with this <see cref="Sender"/> instance.</summary>
    private readonly Metrics _metrics;

    /// <summary>The <see cref="SenderConfiguration"/> used to configure the instance of this role.</summary>
    private readonly TransactionSenderConfiguration _transactionSenderConfiguration;

    /// <summary>The <see cref="TestParameters"/> used to configure this test run.</summary>
    private readonly TestParameters _testParameters;

    /// <summary>
    ///   Initializes a new <see cref="Sender"\> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the send and receive test scenario run.</param>
    /// <param name="transactionSenderConfiguration">The <see cref="TransactionSenderConfiguration" /> instance used to configure this instance of <see cref="Sender" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public TransactionSender(TestParameters testParameters,
                             TransactionSenderConfiguration transactionSenderConfiguration,
                             Metrics metrics)
    {
        _metrics = metrics;
        _testParameters = testParameters;
        _transactionSenderConfiguration = transactionSenderConfiguration;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Sender"/> role. This role creates a <see cref="ServiceBusSender"/>
    ///   and monitors it while it sends events to this test's dedicated Service Bus queue.
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var sendTasks = new List<Task>();

        while (!cancellationToken.IsCancellationRequested)
        {
            using var backgroundCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Create the Service Bus client and sender

            await using var client = new ServiceBusClient(_testParameters.ServiceBusConnectionString);
            var sender = client.CreateSender(_testParameters.QueueName);

            var batch = await sender.CreateMessageBatchAsync().ConfigureAwait(false);

            while (!cancellationToken.IsCancellationRequested)
            {
                var messages = MessageBuilder.CreateMessages(_senderConfiguration.MaxNumberOfMessages,
                                                             batch.MaxSizeInBytes,
                                                             _senderConfiguration.LargeMessageRandomFactorPercent,
                                                             _senderConfiguration.MessageBodyMinBytes,
                                                             _senderConfiguration.MessageBodyMaxBytes);
                try
                {                               
                    using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await TransactionSend(messages).ConfigureAwait(false);
                    }

                    if ((_transactionSenderConfiguration.SendingDelay.HasValue) && (_transactionSenderConfiguration.SendingDelay.Value > TimeSpan.Zero))
                    {
                        await Task.Delay(_transactionSenderConfiguration.SendingDelay.Value, backgroundCancellationSource.Token).ConfigureAwait(false);
                    }
                }
                catch (TaskCanceledException)
                {
                    // Test is ending.
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
                    // If this catch is hit, it means the sender has restarted, collect metrics.

                    _metrics.Client.GetMetric(Metrics.SenderRestarted).TrackValue(1);
                    _metrics.Client.TrackException(ex);
                }
            }
        }
    }

    private async Task TransactionSend(IEnumerable<ServiceBusMessage> messages)
    {
        foreach (var message in messages)
        {
            await sender.SendMessageAsync(messages, cancellationToken).ConfigureAwait(false);
        }
    }
}
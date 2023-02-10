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
///   The role responsible for running a <see cref="ServiceBusSender" /> with sessions, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" />. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are processed and read. It stops sending messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class SessionSender : Sender
{
    /// <summary>
    ///   Initializes a new <see cref="Sender"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the send and receive test scenario run.</param>
    /// <param name="senderConfiguration">The <see cref="SenderConfiguration" /> instance used to configure this instance of <see cref="Sender" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public SessionSender(TestParameters testParameters,
                             SenderConfiguration senderConfiguration,
                             Metrics metrics) : base(testParameters, senderConfiguration, metrics){}

    /// <summary>
    ///   Generates messages using the <see cref= "SenderConfiguration" /> instance associated with this role instance.
    ///   It then sends them to the Service Bus Queue. Any caught exceptions are sent to Application Insights.
    /// </summary>
    ///
    /// <param name="sender">The <see cref="ServiceBusSender" /> to use to send messages to for this test scenario run.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    internal override async Task PerformSend(ServiceBusSender sender,
                                      CancellationToken cancellationToken)
    {
        var sessionId = "currentSession";
        var batch = await sender.CreateMessageBatchAsync().ConfigureAwait(false);
        var messages = MessageBuilder.CreateMessages(_senderConfiguration.MaxNumberOfMessages,
                                                     batch.MaxSizeInBytes,
                                                     _senderConfiguration.LargeMessageRandomFactorPercent,
                                                     _senderConfiguration.MessageBodyMinBytes,
                                                     _senderConfiguration.MessageBodyMaxBytes,
                                                     sessionId);

        try
        {
            foreach (ServiceBusMessage message in messages)
            {
                MessageTracking.AugmentMessage(message, _testParameters.Sha256Hash);
                message.SessionId = sessionId;
                await sender.SendMessageAsync(message, cancellationToken).ConfigureAwait(false);
                _metrics.Client.GetMetric(Metrics.SessionMessagesSent).TrackValue(1);
            }
        }
        catch (TaskCanceledException)
        {
            // Run is completed.
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
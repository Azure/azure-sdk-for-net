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
///   The role responsible for running a <see cref="ServiceBusSessionReceiver" />, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" />. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are received and read. It stops reading messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class SessionReceiver
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Receiver" /> instance.</summary>
    private Metrics _metrics;

    /// <summary>The <see cref="TestParameters" /> used to run this test.</summary>
    private TestParameters _testParameters;

    /// <summary>The <see cref="ReceiverConfiguration" /> used to configure the instance of this role.</summary>
    private SessionReceiverConfiguration _sessionReceiverConfiguration;

    /// <summary>Holds the set of messages that have been read by this instance. The key is the event's unique Id set by the sender.</summary>
    private ConcurrentDictionary<string, byte> _readMessages;

    /// <summary>
    ///   Initializes a new <see cref="Receiver" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters" /> used to configure the test scenario run.</param>
    /// <param name="sessionReceiverConfiguration">The <see cref="SessionReceiverConfiguration" /> instance used to configure this instance of <see cref="Receiver" />.</param>
    /// <param name="metrics">The <see cref="Metrics" /> instance used to send metrics to Application Insights.</param>
    ///
    public SessionReceiver(TestParameters testParameters,
                     SessionReceiverConfiguration sessionReceiverConfiguration,
                     Metrics metrics)
    {
        _testParameters = testParameters;
        _sessionReceiverConfiguration = sessionReceiverConfiguration;
        _metrics = metrics;
        _readMessages = new ConcurrentDictionary<string, byte>();
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Receiver" /> role. This role creates an <see cref="ServiceBusSessionReceiver" />
    ///   and monitors it while it reads messages that have been sent to this test's Service Bus queue by independent
    ///   <see cref="Sender" /> role(s).
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        await using var client = new ServiceBusClient(_testParameters.ServiceBusConnectionString);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var receiver = await client.AcceptNextSessionAsync(_testParameters.QueueName);

                while (!cancellationToken.IsCancellationRequested)
                {
                    var message = await receiver.ReceiveMessageAsync().ConfigureAwait(false);
                    if (message != null)
                    {
                        _metrics.Client.GetMetric(Metrics.MessagesReceived).TrackValue(1);
                        MessageTracking.ReceiveSessionMessage(message, _testParameters.Sha256Hash, _metrics, _readMessages);
                        await receiver.CompleteMessageAsync(message).ConfigureAwait(false);
                        _metrics.Client.GetMetric(Metrics.MessagesCompleted).TrackValue(1);
                    }
                }
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
                _metrics.Client.GetMetric(Metrics.ReceiverRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
        }
    }
}
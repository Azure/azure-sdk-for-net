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
///   The role responsible for running a <see cref="ServiceBusReceiver" \>, and testing its performance over
///   a long period of time. It collects metrics about the run and sends them to application insights using a
///   <see cref="TelemetryClient" \>. The metrics collected are garbage collection information, any exceptions
///   thrown or heard, and how many messages are received and read. It stops reading messages and cleans up resources
///   at the end of the test run.
/// </summary>
///
internal class Receiver
{
    /// <summary>The <see cref="Metrics" /> instance associated with this <see cref="Receiver" /> instance.</summary>
    private Metrics _metrics { get; }

    /// <summary>The <see cref="TestParameters" /> used to run this test.</summary>
    private TestParameters _testParameters { get; }

    /// <summary>The <see cref="ReceiverConfiguration" /> used to configure the instance of this role.</summary>
    private ReceiverConfiguration _receiverConfiguration { get; }

    /// <summary>Holds the set of messages that have been read by this instance. The key is the event's unique Id set by the sender.</summary>
    private ConcurrentDictionary<string, byte> _readMessages { get; }

    /// <summary>
    ///   Initializes a new <see cref="Receiver" \> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> used to configure the test scenario run.</param>
    /// <param name="receiverConfiguration">The <see cref="ReceiverConfiguration"/> instance used to configure this instance of <see cref="Receiver" />.</param>
    /// <param name="metrics">The <see cref="Metrics"/> instance used to send metrics to Application Insights.</param>
    /// <param name="readEvents">The dictionary holding the key values of the unique Id's of all the events that have been read so far.</param>
    ///
    public Receiver(TestParameters testParameters,
                     ReceiverConfiguration receiverConfiguration,
                     Metrics metrics,
                     ConcurrentDictionary<string, byte> readEvents)
    {
        _testParameters = testParameters;
        _receiverConfiguration = receiverConfiguration;
        _metrics = metrics;
        _readMessages = readEvents;
    }

    /// <summary>
    ///   Starts an instance of a <see cref="Receiver"/> role. This role creates an <see cref="ServiceBusReceiver"/>
    ///   and monitors it while it reads messages that have been sent to this test's Service Bus queue by independent
    ///   <see cref="Sender"/> role(s).
    /// </summary>
    ///
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
    ///
    public async Task RunAsync(CancellationToken cancellationToken)
    {
        await using var client = new ServiceBusClient(_testParameters.ServiceBusConnectionString);
        var receiver = client.CreateReceiver(_testParameters.QueueName);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var message = await receiver.ReceiveMessageAsync().ConfigureAwait(false);
                _metrics.Client.GetMetric(Metrics.MessagesReceived).TrackValue(1);
                // TODO: check event
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
                // TODO: determine metrics
                //_metrics.Client.GetMetric(Metrics.ConsumerRestarted).TrackValue(1);
                _metrics.Client.TrackException(ex);
            }
        }
    }
}
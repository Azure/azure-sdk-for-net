// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the send receive test scenario.
/// <summary/>
///
public class SessionSendProcessTest : TestScenario
{
    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.SessionSender, Role.SessionProcessor};

    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "SessionSendProcessTest";

    /// <summary>The identifier of the <see cref="Processor"/> used by this instance.</summary>
    private string _identifier;

    /// <summary>Holds the set of messages that have been read by this instance. The key is the unique Id set by the sender.</summary>
    private ConcurrentDictionary<string, byte> _readMessages = new ConcurrentDictionary<string, byte>();

    /// <summary>
    ///  Initializes a new <see cref="SessionSendProcessTest" /> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public SessionSendProcessTest(TestParameters testParameters,
                                Metrics metrics,
                                string jobIndex = default) : base(testParameters, metrics, jobIndex, $"net-sb-session-send-process-{Guid.NewGuid().ToString()}")
    {
    }

    /// <summary>
    ///   Creates a role instance using all of the default configuration values and runs that role.
    /// </summary>
    ///
    /// <param name="role">The <see cref="Role" /> to run.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    internal override Task RunRoleAsync(Role role, CancellationToken cancellationToken)
    {
       switch (role)
        {
            case Role.SessionSender:
                var senderConfiguration = new SenderConfiguration();
                var sender = new SessionSender(_testParameters, senderConfiguration, _metrics);
                return Task.Run(() => sender.RunAsync(cancellationToken));

            case Role.SessionProcessor:
                var processorConfiguration = new SessionProcessorConfiguration();
                var processor = new SessionProcessor(_testParameters, processorConfiguration, _metrics);
                _identifier = processor.Identifier;
                return Task.Run(() => processor.RunAsync(MessageHandler, ErrorHandler, cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }

    /// <summary>
    ///   The method to pass to the <see cref="ServiceBusProcessor" /> instance as the <see cref="ServiceBusProcessor.ProcessMessageAsync" />
    ///   message handler.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessSessionMessageEventArgs" /> used to pass information to the message handler.</param>
    ///
    private Task MessageHandler(ProcessSessionMessageEventArgs args)
    {
        try
        {
            // Increment total service operations metric
            _metrics.Client.GetMetric(Metrics.MessagesRead).TrackValue(1);

            MessageTracking.ProcessSessionMessage(args, _testParameters.Sha256Hash, _metrics, _readMessages);

            string metricName = Metrics.SessionMessagesProcessed;
            string addedSession = $"{metricName}-SessionId-{args.SessionId}";

            _metrics.Client.GetMetric(Metrics.SessionMessagesProcessed).TrackValue(1);
            _metrics.Client.GetMetric(Metrics.TotalMessagesProcessed).TrackValue(1);
        }
        catch (Exception ex)
        {
            _metrics.Client.TrackException(ex);
        }
        finally
        {
            //_metrics.Client.GetMetric(Metrics.MessageHandlerCalls, Metrics.Identifier).TrackValue(1, _identifier);
        }

        return Task.CompletedTask;
    }

    /// <summary>
    ///   The method to pass to the <see cref="ServiceBusProcessor" /> instance as the <see cref="ServiceBusProcessor.ProcessErrorAsync" />
    ///   error handler.
    /// </summary>
    ///
    /// <param name="args">The <see cref="ProcessErrorEventArgs" /> used to pass information to the error handler.</param>
    ///
    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        _metrics.Client.TrackException(args.Exception);
        return Task.CompletedTask;
    }
}
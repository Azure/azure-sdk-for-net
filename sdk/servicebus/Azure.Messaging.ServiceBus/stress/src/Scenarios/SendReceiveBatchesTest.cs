// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the send receive test scenario.
/// <summary/>
///
public class SendReceiveBatchesTest : TestScenario
{
    /// <summary> The array of <see cref="Role" />s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.Sender, Role.Receiver};

    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "SendReceiveBatchesTest";

    /// <summary>
    ///  Initializes a new <see cref="SendReceiveTest" /> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public SendReceiveBatchesTest(TestParameters testParameters,
                                Metrics metrics,
                                string jobIndex = default) : base(testParameters, metrics, jobIndex, $"net-sb-send-receive-batches-{Guid.NewGuid().ToString()}")
    {
    }

    /// <summary>
    ///   Creates a role instance and runs that role.
    /// </summary>
    ///
    /// <param name="role">The <see cref="Role" /> to run.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> instance to signal the request to cancel the operation.</param>
    ///
    internal override Task RunRoleAsync(Role role,
                              CancellationToken cancellationToken)
    {
        switch (role)
        {
            case Role.Sender:
                var senderConfiguration = new SenderConfiguration();
                senderConfiguration.UseBatches = true;
                var sender = new Sender(_testParameters, senderConfiguration, _metrics);
                return Task.Run(() => sender.RunAsync(cancellationToken));

            case Role.Receiver:
                var receiverConfiguration = new ReceiverConfiguration();
                var receiver = new Receiver(_testParameters, receiverConfiguration, _metrics);
                return Task.Run(() => receiver.RunAsync(cancellationToken));

            default:
                throw new NotSupportedException($"Running role { role.ToString() } is not supported by this test scenario.");
        }
    }
}
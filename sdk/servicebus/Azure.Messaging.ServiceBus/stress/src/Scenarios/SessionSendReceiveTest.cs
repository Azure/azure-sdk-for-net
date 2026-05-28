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
public class SessionSendReceiveTest : TestScenario
{
    /// <summary> The array of <see cref="Role"  />s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.SessionSender, Role.SessionReceiver};

    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "SessionSendReceiveTest";

    /// <summary>
    ///  Initializes a new <see cref="SessionSendReceiveTest" /> instance.
    /// </summary>
    ///
    /// <param name="testConfiguration">The <see cref="TestConfiguration" /> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics" /> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public SessionSendReceiveTest(TestParameters testParameters,
                                Metrics metrics,
                                string jobIndex = default) : base(testParameters, metrics, jobIndex, $"net-sb-session-send-receive-{Guid.NewGuid().ToString()}")
    {
    }
}
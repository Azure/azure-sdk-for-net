// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the Event Producer test scenario.
/// <summary/>
///
public class EventProducerTest : TestScenario
{
    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "EventProducerTest";

    /// <summary> The array of <see cref="Role"/>s needed to run this test scenario.</summary>
    public override Role[] Roles { get; } = {Role.Publisher, Role.Publisher};

    /// <summary>
    ///  Initializes a new <see cref="EventProducerTest"/> instance.
    /// </summary>
    ///
    /// <param name="TestParameters">The <see cref="TestParameters"/> to use to configure this test run.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public EventProducerTest(TestParameters testParameters,
                             Metrics metrics) : base(testParameters, metrics, $"net-prod-{Guid.NewGuid().ToString()}")
    {
    }
}
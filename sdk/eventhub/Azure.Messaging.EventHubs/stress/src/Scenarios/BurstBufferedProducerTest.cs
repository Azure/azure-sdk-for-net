// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The test scenario responsible for running all of the roles needed for the burst Buffered Producer test scenario.
/// <summary/>
///
public class BurstBufferedProducerTest : TestScenario
{
    /// <summary> The name of this test.</summary>
    public override string Name { get; } = "BurstBufferedProducerTest";

    /// <summary> The set of <see cref="Role"/>s needed to run this test scenario.</summary>

    private static Role[] _roles { get; } = {Role.BufferedPublisher};

    /// <summary>
    ///  Initializes a new <see cref="BurstBufferedProducerTest"/> instance.
    /// </summary>
    ///
    /// <param name="testParameters">The <see cref="TestParameters"/> to use to run this test.</param>
    /// <param name="metrics">The <see cref="Metrics"/> to use to send metrics to Application Insights.</param>
    /// <param name="jobIndex">An optional index used to determine which role should be run if this is a distributed run.</param>
    ///
    public BurstBufferedProducerTest(TestParameters testParameters,
                                     Metrics metrics,
                                     string jobIndex = default) : base(testParameters, metrics, jobIndex, $"net-burst-buff-{Guid.NewGuid().ToString()}")
    {
    }
}
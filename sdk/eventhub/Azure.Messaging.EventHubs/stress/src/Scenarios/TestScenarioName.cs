// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Stress;

/// <summary>
///   The set of test scenarios that can be run.
/// </summary>
///
public enum TestScenarioName
{
    BufferedProducerTest,
    BurstBufferedProducerTest,
    EventProducerTest,
    ProcessorTest,
    ConsumerTest
}
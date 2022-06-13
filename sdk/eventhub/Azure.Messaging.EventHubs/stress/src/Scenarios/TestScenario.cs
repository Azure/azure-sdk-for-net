// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Stress;

public enum TestScenario
{
    BufferedProducerHashingTest,
    BufferedProducerTest,
    BurstBufferedProducerTest,
    DistributedTracingTest,
    EventProducerTest,
    ProcessorLoadBalancesTest,
    ProcessorTest,
    ProcessorPartitionOwnershipTest,
    BufferedCPU,
    ProducerCPU
}
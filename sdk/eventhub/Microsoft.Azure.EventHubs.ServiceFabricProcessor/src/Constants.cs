// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;

    class Constants
    {
        internal static readonly int RetryCount = 5;

        internal static readonly int FixedReceiverEpoch = 0;

        internal static readonly TimeSpan MetricReportingInterval = TimeSpan.FromMinutes(1.0);
        internal static readonly string DefaultUserLoadMetricName = "CountOfPartitions";

        internal static readonly TimeSpan ReliableDictionaryTimeout = TimeSpan.FromSeconds(10.0); // arbitrary
        internal static readonly string CheckpointDictionaryName = "EventProcessorCheckpointDictionary";
        internal static readonly string CheckpointPropertyVersion = "version";
        internal static readonly string CheckpointPropertyValid = "valid";
        internal static readonly string CheckpointPropertyOffsetV1 = "offsetV1";
        internal static readonly string CheckpointPropertySequenceNumberV1 = "sequenceNumberV1";
    }
}

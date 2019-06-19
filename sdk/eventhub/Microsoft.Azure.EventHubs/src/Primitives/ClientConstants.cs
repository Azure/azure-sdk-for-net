// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    static class ClientConstants
    {
        public const int TimerToleranceInSeconds = 5;
        public const int ServerBusyBaseSleepTimeInSecs = 4;

        // Message property names
        public const string EnqueuedTimeUtcName = "x-opt-enqueued-time";
        public const string SequenceNumberName = "x-opt-sequence-number";
        public const string OffsetName = "x-opt-offset";
        public const string PublisherName = "x-opt-publisher";
        public const string PartitionKeyName = "x-opt-partition-key";
        public const int MaxReceiverIdentifierLength = 64;
        public const int ReceiveHandlerDefaultBatchSize = 10;

        public const string SasTokenType = "servicebus.windows.net:sastoken";
        public const string JsonWebTokenType = "jwt";
        public const string AadEventHubsAudience = "https://eventhubs.azure.net/";

        public static TimeSpan DefaultOperationTimeout = TimeSpan.FromMinutes(1);
        public static TransportType DefaultTransportType = TransportType.Amqp;
    }
}

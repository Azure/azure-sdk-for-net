// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    static class TestConstants
    {
        internal const int MaxAttemptsCount = 5;

        internal const string ConnectionStringEnvironmentVariable = "azure-service-bus-dotnet/connectionstring";

        internal const string PartitionedQueueName = "partitioned-queue";
        internal const string NonPartitionedQueueName = "non-partitioned-queue";

        internal const string SessionPartitionedQueueName = "partitioned-session-queue";
        internal const string SessionNonPartitionedQueueName = "non-partitioned-session-queue";

        internal const string PartitionedTopicName = "partitioned-topic";
        internal const string NonPartitionedTopicName = "non-partitioned-topic";

        internal const string PartitionedSessionTopicName = "partitioned-session-topic";
        internal const string NonPartitionedSessionTopicName = "non-partitioned-session-topic";

        internal const string SubscriptionName = "subscription";
        internal const string SessionSubscriptionName = "session-subscription";

        internal const string SessionPrefix = "session";
    }
}
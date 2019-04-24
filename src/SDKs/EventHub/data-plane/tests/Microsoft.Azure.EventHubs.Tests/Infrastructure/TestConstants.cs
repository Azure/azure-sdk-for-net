// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;

    internal static class TestConstants
    {
        // Environment Variables
        internal const string EventHubsConnectionStringEnvironmentVariableName = "AZ_EVENT_HUBS_CONNECTION";
        internal const string StorageConnectionStringEnvironmentVariableName = "AZ_EVENT_HUBS_STORAGE_CONNECTION";

        // General
        internal const string DefultEventHubName = "eventhubs-sdk-test-hub";
        internal const string AlternateConsumerGroupName = "sdk-test-consumer";
        internal static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromSeconds(30);
    }
}
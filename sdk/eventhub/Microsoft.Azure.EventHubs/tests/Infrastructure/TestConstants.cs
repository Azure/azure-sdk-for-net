// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;

    internal static class TestConstants
    {
        // Environment Variables
        internal const string EventHubsSubscriptionEnvironmentVariableName = "EVENTHUB_SUBSCRIPTION_ID";
        internal const string EventHubsResourceGroupEnvironmentVariableName = "EVENTHUB_RESOURCE_GROUP";
        internal const string EventHubsTenantEnvironmentVariableName = "EVENTHUB_TENANT_ID";
        internal const string EventHubsClientEnvironmentVariableName = "EVENTHUB_CLIENT_ID";
        internal const string EventHubsSecretEnvironmentVariableName = "EVENTHUB_CLIENT_SECRET";

        // General
        internal static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromSeconds(180);
    }
}
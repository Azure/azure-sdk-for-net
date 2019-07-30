// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests
{
    using System;

    internal static class TestConstants
    {
        // Environment Variables
        internal const string EventHubsConnectionStringEnvironmentVariableName = "EVENT_HUBS_CONNECTION_STRING";
        internal const string StorageConnectionStringEnvironmentVariableName = "EVENT_HUBS_STORAGE_CONNECTION_STRING";      
        
        //Following 6 const copied from Track two TestEnvironment.cs
        internal const string EventHubsSubscriptionEnvironmentVariableName = "EVENT_HUBS_SUBSCRIPTION";
        internal const string EventHubsResourceGroupEnvironmentVariableName = "EVENT_HUBS_RESOURCEGROUP";
        internal const string EventHubsNamespaceEnvironmentVariableName = "EVENT_HUBS_NAMESPACE";
        internal const string EventHubsTenantEnvironmentVariableName = "EVENT_HUBS_TENANT";
        internal const string EventHubsClientEnvironmentVariableName = "EVENT_HUBS_CLIENT";
        internal const string EventHubsSecretEnvironmentVariableName = "EVENT_HUBS_SECRET";


        //Unused after Track two test infrastructure ported
        // General
        //internal const string DefultEventHubName = "eventhubs-sdk-test-hub";
        //internal const string AlternateConsumerGroupName = "sdk-test-consumer";
        //internal static readonly TimeSpan DefaultOperationTimeout = TimeSpan.FromSeconds(30);
    }
}
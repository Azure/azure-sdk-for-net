// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationManagementTestEnvironment : TestEnvironment
    {
        internal const string SubscriptionIdEnvironmentVariableName = "SUBSCRIPTION_ID";
        internal const string NotificationHubsResourceGroupNameEnvironmentVariableName = "NOTIFICATION_HUBS_RESOURCE_GROUP_NAME";
        internal const string NotificationHubsResourceIdEnvironmentVariableName = "NOTIFICATION_HUBS_RESOURCE_ID";
        internal const string NotificationHubsConnectionStringEnvironmentVariableName = "NOTIFICATION_HUBS_CONNECTION_STRING";

        public string NotificationHubsResourceGroupName => GetRecordedVariable(NotificationHubsResourceGroupNameEnvironmentVariableName);
        public string NotificationHubsResourceId => GetRecordedVariable(NotificationHubsResourceIdEnvironmentVariableName);
        public string NotificationHubsConnectionString => GetRecordedVariable(NotificationHubsConnectionStringEnvironmentVariableName);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Pipeline
{
    internal static class CommunicationEnvironmentVariableNames
    {
        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

        internal const string ToPhoneNumberEnvironmentVariableName = "TO_PHONE_NUMBER";
        internal const string FromPhoneNumberEnvironmentVariableName = "FROM_PHONE_NUMBER";

        internal const string SubscriptionIdEnvironmentVariableName = "SUBSCRIPTION_ID";
        internal const string NotificationHubsResourceGroupNameEnvironmentVariableName = "NOTIFICATION_HUBS_RESOURCE_GROUP_NAME";
        internal const string NotificationHubsResourceIdEnvironmentVariableName = "NOTIFICATION_HUBS_RESOURCE_ID";
        internal const string NotificationHubsConnectionStringEnvironmentVariableName = "NOTIFICATION_HUBS_CONNECTION_STRING";
    }
}
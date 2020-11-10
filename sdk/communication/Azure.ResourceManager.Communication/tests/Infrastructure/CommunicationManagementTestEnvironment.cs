// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationManagementTestEnvironment : TestEnvironment
    {
        public CommunicationManagementTestEnvironment() : base("communication")
        {
        }

        public string NotificationHubsResourceGroupName => GetRecordedVariable(CommunicationEnvironmentVariableNames.NotificationHubsResourceGroupNameEnvironmentVariableName);
        public string NotificationHubsResourceId => GetRecordedVariable(CommunicationEnvironmentVariableNames.NotificationHubsResourceIdEnvironmentVariableName);
        public string NotificationHubsConnectionString => GetRecordedVariable(CommunicationEnvironmentVariableNames.NotificationHubsConnectionStringEnvironmentVariableName);
    }
}

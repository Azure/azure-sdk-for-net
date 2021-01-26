// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Quantum.Jobs.Tests
{
    public class QuantumJobClientTestEnvironment : TestEnvironment
    {
        public new string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");
        public string ResourceGroupName => GetRecordedVariable("RESOURCE_GROUP_NAME");
        public string WorkspaceName => GetRecordedVariable("WORKSPACE_NAME");
        public string WorkspaceLocation => GetRecordedVariable("WORKSPACE_LOCATION");
    }
}

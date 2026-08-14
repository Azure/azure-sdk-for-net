// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ManagedOps.Tests
{
    public class ManagedOpsManagementTestEnvironment : TestEnvironment
    {
        // These values are obtained from the resource created in the sdk/managedops/test-resources.bicep file
        public string ChangeTrackingWorkspaceId => GetRecordedVariable("LOG_ANALYTICS_WORKSPACE_ID");
        public string AzureMonitorWorkspaceId => GetRecordedVariable("AZURE_MONITOR_WORKSPACE_ID");
        public string UserAssignedManagedIdentityId => GetRecordedVariable("USER_ASSIGNED_MANAGED_IDENTITY_ID");
    }
}

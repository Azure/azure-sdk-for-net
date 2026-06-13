// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Relationships.Tests
{
    public class RelationshipsManagementTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// ID of a pre-configured Service Group where the test principal has
        /// 'Relationship Administrator' or 'Service Group Member Relationship Contributor'
        /// assigned. Required for tests that write ServiceGroupMember relationships targeting
        /// a Service Group (LinkedAuthorizationFailed is thrown when this role is missing).
        /// Format: /providers/Microsoft.Management/serviceGroups/{name}
        /// </summary>
        public string ServiceGroupId => GetRecordedVariable("AZURE_SERVICE_GROUP_ID");
    }
}

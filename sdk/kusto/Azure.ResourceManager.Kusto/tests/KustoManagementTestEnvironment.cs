// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Kusto.Tests
{
    public class KustoManagementTestEnvironment : TestEnvironment
    {
        public string Id => GetRecordedVariable("ID");

        public string ClusterName => GetRecordedVariable("CLUSTER_NAME");
        public string DatabaseName => GetRecordedVariable("DATABASE_NAME");
        public string ScriptContentTableName => GetRecordedVariable("SCRIPT_CONTENT_TABLE_NAME");
        public string FollowingClusterName => GetRecordedVariable("FOLLOWING_CLUSTER_NAME");

        public ResourceIdentifier UserAssignedIdentityId => new(GetRecordedVariable("USER_ASSIGNED_IDENTITY_ID"));
        public Guid UserAssignedIdentityPrincipalId => Guid.Parse(GetRecordedVariable("USER_ASSIGNED_IDENTITY_PRINCIPAL_ID"));

        public string ScriptSasToken => GetRecordedVariable("STORAGE_ACCOUNT_SAS_TOKEN");
        public ResourceIdentifier StorageAccountId => new(GetRecordedVariable("STORAGE_ACCOUNT_ID"));
        public Uri ScriptUri => new(GetRecordedVariable("SCRIPT_URI"));
        public string ScriptUriTableName => GetRecordedVariable("SCRIPT_URI_TABLE_NAME");

        public ResourceIdentifier EventHubId => new(GetRecordedVariable("EVENT_HUB_ID"));
        public ResourceIdentifier IotHubId => new(GetRecordedVariable("IOT_HUB_ID"));
    }
}

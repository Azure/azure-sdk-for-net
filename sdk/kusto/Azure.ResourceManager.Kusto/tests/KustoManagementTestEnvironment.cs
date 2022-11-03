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

        public string ClusterName => GetRecordedVariable("KUSTO_CLUSTER_NAME");
        public string DatabaseName => GetRecordedVariable("KUSTO_DATABASE_NAME");
        public string FollowerClusterName => GetRecordedVariable("KUSTO_FOLLOWER_CLUSTER_NAME");

        public ResourceIdentifier UserAssignedIdentityId => new(GetRecordedVariable("USER_ASSIGNED_IDENTITY_ID"));
        public Uri KeyVaultUri => new(GetRecordedVariable("KEY_VAULT_URI"));
        public string KeyName => GetRecordedVariable("KEY_NAME");
        public string KeyVersion => GetRecordedVariable("KEY_VERSION");

        public ResourceIdentifier StorageAccountId => new(GetRecordedVariable("STORAGE_ACCOUNT_ID"));
        public Uri ScriptUri => new(GetRecordedVariable("SCRIPT_URI"));
        public string ScriptSasToken => GetVariable("SCRIPT_SAS_TOKEN");

        public ResourceIdentifier EventHubId => new(GetRecordedVariable("EVENT_HUB_ID"));
        public ResourceIdentifier IotHubId => new(GetRecordedVariable("IOT_HUB_ID"));
        public string PrivateEndpointName => GetRecordedVariable("PRIVATE_ENDPOINT_NAME");

        public string GenerateAssetName(string prefix)
        {
            return prefix + Id;
        }
    }
}

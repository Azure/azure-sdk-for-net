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
        public string TableName => GetRecordedVariable("TABLE_NAME");
        public string FollowingClusterName => GetRecordedVariable("FOLLOWING_CLUSTER_NAME");
        public Uri KeyVaultUri => new(GetRecordedVariable("KEY_VAULT_URI"));
        public string KeyName => GetRecordedVariable("KEY_NAME");
        public string KeyVersion => GetRecordedVariable("KEY_VERSION");
        public string PrivateEndpointName => GetRecordedVariable("PRIVATE_ENDPOINT_NAME");

        public string KustoTenantId => GetRecordedVariable("KUSTO_TENANT_ID");

        public ResourceIdentifier UserAssignedIdentityId => new(GetRecordedVariable("USER_ASSIGNED_IDENTITY_ID"));

        public string UserAssignedIdentityPrincipalId => GetRecordedVariable("USER_ASSIGNED_IDENTITY_PRINCIPAL_ID");

        public ResourceIdentifier EventHubId => new(GetRecordedVariable("EVENT_HUB_ID"));
        public ResourceIdentifier IotHubId => new(GetRecordedVariable("IOT_HUB_ID"));
        public ResourceIdentifier CosmosDbAccountId => new(GetRecordedVariable("COSMOSDB_ACCOUNT_ID"));
        public string CosmosDbDatabaseName => GetRecordedVariable("COSMOSDB_DATABASE_NAME");
        public string CosmosDbContainerName => GetRecordedVariable("COSMOSDB_CONTAINER_NAME");

        public ResourceIdentifier StorageAccountId => new(GetRecordedVariable("STORAGE_ACCOUNT_ID"));

        public string StorageAccountSasToken => GetRecordedVariable("STORAGE_ACCOUNT_SAS_TOKEN", options => options.IsSecret());
    }
}

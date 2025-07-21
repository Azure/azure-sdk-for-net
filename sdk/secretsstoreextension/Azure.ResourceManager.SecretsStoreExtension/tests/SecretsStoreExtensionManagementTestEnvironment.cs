// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.SecretsStoreExtension.Tests
{
    // Provides access to environment variables which are used during test run.
    // Constant values are defined in SseTestData.
    public class SecretsStoreExtensionManagementTestEnvironment : TestEnvironment
    {
        // Used to sanitize GUIDs in the log files.
        public const string NullGuid = "00000000-0000-0000-0000-000000000000";

        // Resource group in which the cluster, key vault, custom locations, and UAMI are defined.
        public string ClusterResourceGroup => GetRecordedVariable("CLUSTER_RESOURCE_GROUP");
        // Geographical location.
        public string SpcLocation => GetRecordedVariable("SPC_LOCATION", options => options.IsSecret());

        // Tenant which contains the cluster subscription.  The tests must be run while logged into this tenant.
        public Guid SpcTenantId => Guid.Parse(GetRecordedVariable("SPC_TENANT_ID", options => options.IsSecret(NullGuid)));
        // Subscription which contains the cluster resource group.
        public string SpcSubscriptionId => GetRecordedVariable("SPC_SUBSCRIPTION_ID", options => options.IsSecret(NullGuid));

        // UAMI which is used to retrieve the secrets from AKV.
        public Guid SpcClientId => Guid.Parse(GetRecordedVariable("SPC_CLIENT_ID", options => options.IsSecret(NullGuid)));
        // Key vault which stores the secrets to be synchronized to the cluster.
        public string SpcKeyVaultName => GetRecordedVariable("SPC_KEYVAULT_NAME", options => options.IsSecret());
    }
}

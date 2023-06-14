// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse.Tests.Helpers
{
    public class CommonTestFixture
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public AzureLocation Location { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public string LocationString { get; set; }

        /// <summary>
        /// Gets or sets storage account name.
        /// </summary>
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets storage account access key.
        /// </summary>
        public string StorageAccountKey { get; set; }

        /// <summary>
        /// Gets or sets data lake storage account url.
        /// </summary>
        public Uri DefaultDataLakeStorageAccountUrl { get; set; }

        /// <summary>
        /// Gets or sets data lake storage file system.
        /// </summary>
        public string DefaultDataLakeStorageFilesystem { get; set; }

        /// <summary>
        /// Gets or sets SSH user name.
        /// </summary>
        public string SshUsername { get; set; }

        /// <summary>
        /// Gets or sets SSH user password.
        /// </summary>
        public string SshPassword { get; set; }

        /// <summary>
        /// Gets or sets subscription id.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets performance level.
        /// </summary>
        public string PerformanceLevel { get; set; }

        /// <summary>
        /// Gets or sets node count.
        /// </summary>
        public int? NodeCount { get; set; }

        /// <summary>
        /// Gets or sets spark version.
        /// </summary>
        public string SparkVersion { get; set; }

        /// <summary>
        /// Gets or sets node size.
        /// </summary>
        public string NodeSize { get; set; }

        /// <summary>
        /// Gets or sets auto scale min node count.
        /// </summary>
        public int? AutoScaleMinNodeCount { get; set; }

        /// <summary>
        /// Gets or sets auto scale max node count.
        /// </summary>
        public int? AutoScaleMaxNodeCount { get; set; }

        /// <summary>
        /// Gets or sets auto pause delay in minute.
        /// </summary>
        public int? AutoPauseDelayInMinute { get; set; }

        /// <summary>
        /// Gets or sets start ip address.
        /// </summary>
        public IPAddress StartIpAddress { get; set; }

        /// <summary>
        /// Gets or sets end ip address.
        /// </summary>
        public IPAddress EndIpAddress { get; set; }

        /// <summary>
        /// Gets or sets resource provisioning state.
        /// </summary>
        public SynapseProvisioningState? provisioningState { get; set; }

        /// <summary>
        /// Gets or sets updated start ip address.
        /// </summary>
        public IPAddress UpdatedStartIpAddress { get; set; }

        /// <summary>
        /// Gets or sets updated end ip address.
        /// </summary>
        public IPAddress UpdatedEndIpAddress { get; set; }

        /// <summary>
        /// Gets or sets kusto sku.
        /// </summary>
        public SynapseDataSourceSku KustoSku { get; set; }

        /// <summary>
        /// Gets or sets updated kusto sku.
        /// </summary>
        public SynapseDataSourceSku UpdatedKustoSku { get; set; }

        /// <summary>
        /// Gets or sets kusto database soft delete period.
        /// </summary>
        public TimeSpan? SoftDeletePeriod { get; set; }

        /// <summary>
        /// Gets or sets kusto database hot cache period.
        /// </summary>
        public TimeSpan? HotCachePeriod { get; set; }

        /// <summary>
        /// Gets or sets kusto database updated soft delete period.
        /// </summary>
        public TimeSpan? UpdatedSoftDeletePeriod { get; set; }

        /// <summary>
        /// Gets or sets kusto database updated hot cache period.
        /// </summary>
        public TimeSpan? UpdatedHotCachePeriod { get; set; }

        public static ResourceType WorkspaceType = "Microsoft.Synapse/workspaces";
        public static ResourceType SqlpoolType = "Microsoft.Synapse/workspaces/sqlPools";
        public static ResourceType SparkpoolType = "Microsoft.Synapse/workspaces/bigDataPools";

        /// <summary>
        /// Ctor
        /// </summary>
        public CommonTestFixture()
        {
        }
    }
}

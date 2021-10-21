// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Microsoft.Azure.Management.Synapse.Tests
{
    public class CommonTestFixture : TestBase
    {
        /// <summary>
        /// Gets or sets resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets resource location.
        /// </summary>
        public string Location { get; set; }

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
        public string DefaultDataLakeStorageAccountUrl { get; set; }

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
        public string StartIpAddress { get; set; }

        /// <summary>
        /// Gets or sets end ip address.
        /// </summary>
        public string EndIpAddress { get; set; }

        /// <summary>
        /// Gets or sets updated start ip address.
        /// </summary>
        public string UpdatedStartIpAddress { get; set; }

        /// <summary>
        /// Gets or sets updated end ip address.
        /// </summary>
        public string UpdatedEndIpAddress { get; set; }

        /// <summary>
        /// Gets or sets kusto sku.
        /// </summary>
        public AzureSku KustoSku { get; set; }

        /// <summary>
        /// Gets or sets updated kusto sku.
        /// </summary>
        public AzureSku UpdatedKustoSku { get; set; }

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

        public const string WorkspaceType = "Microsoft.Synapse/workspaces";
        public const string SqlpoolType = "Microsoft.Synapse/workspaces/sqlPools";
        public const string SparkpoolType = "Microsoft.Synapse/workspaces/bigDataPools";

        /// <summary>
        /// Ctor
        /// </summary>
        public CommonTestFixture()
        {
            Location = "eastus2";
            ResourceGroupName = TestUtilities.GenerateName("synapsesdkrp");
            StorageAccountName = TestUtilities.GenerateName("synapsesdkstorage");
            SshUsername = TestUtilities.GenerateName("sshuser");
            SshPassword = TestUtilities.GenerateName("Password1!");
            DefaultDataLakeStorageFilesystem = TestUtilities.GenerateName("synapsesdkfilesys");
            PerformanceLevel = "DW200c";
            NodeCount = 3;
            NodeSize = "Small";
            SparkVersion = "2.4";
            AutoScaleMinNodeCount = 3;
            AutoScaleMaxNodeCount = 6;
            AutoPauseDelayInMinute = 15;
            StartIpAddress = "0.0.0.0";
            EndIpAddress = "255.255.255.255";
            UpdatedStartIpAddress = "10.0.0.0";
            UpdatedEndIpAddress = "255.0.0.0";
            KustoSku = new AzureSku
            {
                Name = "Storage optimized",
                Size = "Medium"
            };
            UpdatedKustoSku = new AzureSku
            {
                Name = "Storage optimized",
                Size = "Large"
            };
            SoftDeletePeriod = TimeSpan.FromDays(4);
            HotCachePeriod = TimeSpan.FromDays(2);
            UpdatedSoftDeletePeriod = TimeSpan.FromDays(6);
            UpdatedHotCachePeriod = TimeSpan.FromDays(3);
        }
    }
}

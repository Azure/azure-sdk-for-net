// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Data;
using System.Net;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Synapse.Models;

namespace Azure.ResourceManager.Synapse.Tests.Helpers
{
    public static class SynapseManagementTestUtilities
    {
        /// <summary>
        /// Create workspace create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static SynapseWorkspaceData PrepareWorkspaceCreateParams(this CommonTestFixture commonData)
        {
            return new SynapseWorkspaceData(commonData.Location)
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                DefaultDataLakeStorage = new SynapseDataLakeStorageAccountDetails
                {
                    AccountUri = commonData.DefaultDataLakeStorageAccountUrl,
                    Filesystem = commonData.DefaultDataLakeStorageFilesystem
                },
                SqlAdministratorLogin = commonData.SshUsername,
                SqlAdministratorLoginPassword = commonData.SshPassword
            };
        }

        public static SynapseIPFirewallRuleInfoData PrepareFirewallRuleParams(this CommonTestFixture commonData, IPAddress startIpAddress, IPAddress endIpAddress)
        {
            return new SynapseIPFirewallRuleInfoData()
            {
                StartIPAddress = startIpAddress,
                EndIPAddress = endIpAddress
            };
        }

        /// <summary>
        /// Create kustopool create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static SynapseKustoPoolData PrepareKustopoolCreateParams(this CommonTestFixture commonData)
        {
            return new SynapseKustoPoolData(commonData.Location, commonData.KustoSku)
            {
                Location = commonData.Location,
                Sku = commonData.KustoSku
            };
        }

        /// <summary>
        /// Create spark create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <param name="enableAutoScale"></param>
        /// <param name="enableAutoPause"></param>
        /// <returns></returns>
        public static SynapseBigDataPoolInfoData PrepareBigDatapoolCreateParams(this CommonTestFixture commonData, bool enableAutoScale, bool enableAutoPause)
        {
            return new SynapseBigDataPoolInfoData(commonData.Location)
            {
                Location = commonData.Location,
                NodeCount = enableAutoScale ? (int?)null : commonData.NodeCount,
                NodeSizeFamily = BigDataPoolNodeSizeFamily.MemoryOptimized,
                NodeSize = commonData.NodeSize,
                AutoScale = new BigDataPoolAutoScaleProperties
                {
                    IsEnabled = enableAutoScale,
                    MinNodeCount = commonData.AutoScaleMinNodeCount,
                    MaxNodeCount = commonData.AutoScaleMaxNodeCount
                },
                AutoPause = new BigDataPoolAutoPauseProperties
                {
                    IsEnabled = enableAutoPause,
                    DelayInMinutes = commonData.AutoPauseDelayInMinute
                },
                SparkVersion = commonData.SparkVersion
            };
        }

        /// <summary>
        /// Create sqlpool create parameters.
        /// </summary>
        /// <param name="commonData"></param>
        /// <returns></returns>
        public static SynapseSqlPoolData PrepareSqlpoolCreateParams(this CommonTestFixture commonData)
        {
            return new SynapseSqlPoolData(commonData.Location)
            {
                Sku = new SynapseSku
                {
                    Name = commonData.PerformanceLevel
                }
            };
        }

        public static SynapseReadWriteDatabase PrepareKustoDatabaseCreateParams(this CommonTestFixture commonData)
        {
            return new SynapseReadWriteDatabase
            {
                Location = commonData.Location,
                SoftDeletePeriod = commonData.SoftDeletePeriod,
                HotCachePeriod = commonData.HotCachePeriod
            };
        }
    }
}

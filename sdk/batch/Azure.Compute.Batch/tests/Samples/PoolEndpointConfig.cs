// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/pool-endpoint-configuration.md.
// Pool create + network/endpoint settings ported to Azure.ResourceManager.Batch.

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class PoolEndpointConfig
{
    public static async Task SetPortsBasicAsync()
    {
        #region Snippet:endpoint_config_basic
        ArmClient armClient = new ArmClient(new DefaultAzureCredential());

        ResourceIdentifier batchAccountResourceId =
            BatchAccountResource.CreateResourceIdentifier("subscriptionId", "resourceGroupName", "accountName");
        BatchAccountResource batchAccount = armClient.GetBatchAccountResource(batchAccountResourceId);

        BatchAccountPoolCollection poolCollection = batchAccount.GetBatchAccountPools();

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_D2_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "canonical",
                        Offer = "0001-com-ubuntu-server-jammy",
                        Sku = "22_04-lts",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.ubuntu 22.04")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 2 }
            },
            NetworkConfiguration = new BatchNetworkConfiguration()
            {
                EndpointInboundNatPools =
                {
                    new BatchInboundNatPool(
                        name: "RDP",
                        protocol: BatchInboundEndpointProtocol.Tcp,
                        backendPort: 3389,
                        frontendPortRangeStart: 7500,
                        frontendPortRangeEnd: 8000)
                    {
                        NetworkSecurityGroupRules =
                        {
                            new BatchNetworkSecurityGroupRule(
                                priority: 179,
                                access: BatchNetworkSecurityGroupRuleAccess.Allow,
                                sourceAddressPrefix: "198.168.100.7"),
                            new BatchNetworkSecurityGroupRule(
                                priority: 180,
                                access: BatchNetworkSecurityGroupRuleAccess.Deny,
                                sourceAddressPrefix: "*")
                        }
                    }
                }
            }
        };

        ArmOperation<BatchAccountPoolResource> pool = await poolCollection.CreateOrUpdateAsync(
            WaitUntil.Completed, "myPool", poolData);
        #endregion
        _ = pool;
    }

    public static async Task SetPortsRestrictiveAsync()
    {
        #region Snippet:endpoint_config_restrictive
        ArmClient armClient = new ArmClient(new DefaultAzureCredential());

        ResourceIdentifier batchAccountResourceId =
            BatchAccountResource.CreateResourceIdentifier("subscriptionId", "resourceGroupName", "accountName");
        BatchAccountResource batchAccount = armClient.GetBatchAccountResource(batchAccountResourceId);

        BatchAccountPoolCollection poolCollection = batchAccount.GetBatchAccountPools();

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_D2_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "canonical",
                        Offer = "0001-com-ubuntu-server-jammy",
                        Sku = "22_04-lts",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.ubuntu 22.04")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 2 }
            },
            NetworkConfiguration = new BatchNetworkConfiguration()
            {
                EndpointInboundNatPools =
                {
                    new BatchInboundNatPool(
                        name: "RDP",
                        protocol: BatchInboundEndpointProtocol.Tcp,
                        backendPort: 3389,
                        frontendPortRangeStart: 60000,
                        frontendPortRangeEnd: 60099)
                    {
                        NetworkSecurityGroupRules =
                        {
                            new BatchNetworkSecurityGroupRule(
                                priority: 162,
                                access: BatchNetworkSecurityGroupRuleAccess.Deny,
                                sourceAddressPrefix: "*")
                        }
                    }
                }
            }
        };

        ArmOperation<BatchAccountPoolResource> pool = await poolCollection.CreateOrUpdateAsync(
            WaitUntil.Completed, "myPool", poolData);
        #endregion

        _ = pool;
    }
}

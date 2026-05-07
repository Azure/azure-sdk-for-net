// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/managed-identity-pools.md

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Models;

namespace BatchDocSamples;

internal static class ManagedIdentityPools
{
    // Block 1: Create a pool with system-assigned managed identity is not actually
    // shown in the doc; the first snippet just creates a basic pool that the second
    // block will then be associated with an identity. This method matches the doc.
    public static void CreateBasicPool()
    {
        #region Snippet:managed_identity_pool_arm
        var credential = new DefaultAzureCredential();
        ArmClient _armClient = new ArmClient(credential);

        var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
        BatchAccountResource batchAccount = _armClient.GetBatchAccountResource(batchAccountIdentifier);

        var poolName = "HelloWorldPool";
        var imageReference = new BatchImageReference()
        {
            Publisher = "canonical",
            Offer = "0001-com-ubuntu-server-jammy",
            Sku = "22_04-lts",
            Version = "latest"
        };
        string nodeAgentSku = "batch.node.ubuntu 22.04";

        var batchAccountPoolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_DS1_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(imageReference, nodeAgentSku)
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings()
                {
                    TargetDedicatedNodes = 1
                }
            }
        };

        ArmOperation<BatchAccountPoolResource> armOperation = batchAccount.GetBatchAccountPools().CreateOrUpdate(
            WaitUntil.Completed, poolName, batchAccountPoolData);
        BatchAccountPoolResource pool = armOperation.Value;
        #endregion
        _ = pool;
    }

    // Block 2: Create a pool with a user-assigned managed identity (migrated to ARM).
    public static async Task CreatePoolWithUserAssignedIdentityAsync()
    {
        ArmClient armClient = Stubs.ArmClient;
        BatchAccountResource batchAccount = armClient.GetBatchAccountResource(
            ResourceIdentifier.Parse("your-batch-account-resource-id"));

        #region Snippet:managed_identity_pool_user_assigned
        var identityResourceId = new ResourceIdentifier(
            "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identity-name}");

        var poolData = new BatchAccountPoolData()
        {
            VmSize = "STANDARD_D2_V2",
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
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 1 }
            },
            Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            {
                UserAssignedIdentities =
                {
                    [identityResourceId] = new UserAssignedIdentity()
                }
            }
        };

        ArmOperation<BatchAccountPoolResource> op = await batchAccount.GetBatchAccountPools()
            .CreateOrUpdateAsync(WaitUntil.Completed, "myPool", poolData);
        #endregion
        _ = op;
    }
}

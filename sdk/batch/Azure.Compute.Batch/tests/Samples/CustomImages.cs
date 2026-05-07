// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-custom-images.md and batch-sig-images.md.
// Both originals used Microsoft.Azure.Batch's PoolOperations.CreatePool with a
// VirtualMachineImageId; ported to Azure.ResourceManager.Batch (ARM).

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class CustomImages
{
    private const string PoolId = "myCustomImagePool";
    private const string PoolVMSize = "STANDARD_D2_V2";
    private const int PoolNodeCount = 2;

    public static async Task CreateCustomImagePoolAsync()
    {
        ArmClient armClient = Stubs.ArmClient;
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:custom_images_pool_create
        BatchImageReference imageReference = new BatchImageReference()
        {
            Id = new ResourceIdentifier(
                "/subscriptions/{sub id}/resourceGroups/{resource group name}/providers/Microsoft.Compute/images/{image definition name}")
        };

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = PoolVMSize,
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: imageReference,
                    nodeAgentSkuId: "batch.node.windows amd64")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = PoolNodeCount }
            }
        };

        ArmOperation<BatchAccountPoolResource> pool = await batchAccount.GetBatchAccountPools()
            .CreateOrUpdateAsync(WaitUntil.Completed, PoolId, poolData);
        #endregion
    }
}

internal static class SigImages
{
    private const string PoolId = "mySigImagePool";
    private const string PoolVMSize = "STANDARD_D2_V2";
    private const int PoolNodeCount = 2;

    public static async Task CreateSigImagePoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:sig_images_pool_create
        BatchImageReference imageReference = new BatchImageReference()
        {
            Id = new ResourceIdentifier(
                "/subscriptions/{sub id}/resourceGroups/{resource group name}/providers/Microsoft.Compute/galleries/{gallery name}/images/{image definition name}/versions/{version id}")
        };

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = PoolVMSize,
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: imageReference,
                    nodeAgentSkuId: "batch.node.ubuntu 22.04")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = PoolNodeCount }
            }
        };

        ArmOperation<BatchAccountPoolResource> pool = await batchAccount.GetBatchAccountPools()
            .CreateOrUpdateAsync(WaitUntil.Completed, PoolId, poolData);
        #endregion
    }
}

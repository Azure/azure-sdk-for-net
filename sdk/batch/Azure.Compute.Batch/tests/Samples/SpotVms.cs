// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-spot-vms.md.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class SpotVms
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task CreateSpotPoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:spot_vms_pool_create
        BatchImageReference imageRef = new BatchImageReference()
        {
            Publisher = "Canonical",
            Offer = "ubuntu-24_04-lts",
            Sku = "server",
            Version = "latest"
        };

        // Create the pool
        BatchVmConfiguration vmConfiguration =
            new BatchVmConfiguration(imageRef, "batch.node.ubuntu 24.04");

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_D4s_v3",
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings()
                {
                    TargetDedicatedNodes = 5,
                    TargetLowPriorityNodes = 20
                }
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, "vmpool", poolData);
        #endregion
    }

    public static async Task ReadPoolNodeCountsAsync()
    {
        #region Snippet:spot_vms_pool_node_counts
        BatchPool pool1 = await batchClient.GetPoolAsync("vmpool");
        int? numDedicated = pool1.CurrentDedicatedNodes;
        int? numLowPri = pool1.CurrentLowPriorityNodes;
        #endregion
        _ = (numDedicated, numLowPri);
    }

    public static async Task ReadNodeIsDedicatedAsync()
    {
        #region Snippet:spot_vms_node_dedicated
        BatchNode poolNode = await batchClient.GetNodeAsync("vmpool", "tvm-1");
        bool? isNodeDedicated = poolNode.IsDedicated;
        #endregion
        _ = isNodeDedicated;
    }

    public static async Task ResizePoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();
        BatchAccountPoolResource pool = await batchAccount.GetBatchAccountPools().GetAsync("vmpool");

        #region Snippet:spot_vms_pool_resize
        BatchAccountPoolData poolData = pool.Data;
        poolData.ScaleSettings = new BatchAccountPoolScaleSettings()
        {
            FixedScale = new BatchAccountFixedScaleSettings()
            {
                TargetDedicatedNodes = 0,
                TargetLowPriorityNodes = 25
            }
        };
        await pool.UpdateAsync(poolData);
        #endregion
    }
}

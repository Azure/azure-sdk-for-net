// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-linux-nodes.md.
// The original block created a CloudPool from a discovered ImageInformation; ported
// to Azure.Compute.Batch (data-plane image discovery via GetSupportedImagesAsync) +
// Azure.ResourceManager.Batch (pool create).

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class LinuxNodes
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;

    public static async Task CreateLinuxPoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:linux_nodes_pool_create
        // Pool settings
        const string poolId = "LinuxNodesSamplePoolDotNet";
        const string vmSize = "STANDARD_D2_V3";
        const int nodeCount = 1;

        // Obtain a collection of all available node agent SKUs.
        // This allows us to select from a list of supported
        // VM image/node agent combinations.
        List<BatchSupportedImage> images = new List<BatchSupportedImage>();
        await foreach (BatchSupportedImage img in batchClient.GetSupportedImagesAsync())
        {
            images.Add(img);
        }

        // Find the appropriate image information
        BatchSupportedImage image = null;
        foreach (var img in images)
        {
            if (img.ImageReference.Publisher == "canonical" &&
                img.ImageReference.Offer == "0001-com-ubuntu-server-focal" &&
                img.ImageReference.Sku == "20_04-lts")
            {
                image = img;
                break;
            }
        }

        // Create the BatchVmConfiguration for use when actually creating the pool.
        // Note that the data-plane discovery uses Azure.Compute.Batch.BatchVmImageReference
        // but the ARM pool data type uses Azure.ResourceManager.Batch.Models.BatchImageReference.
        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: new BatchImageReference()
            {
                Publisher = image.ImageReference.Publisher,
                Offer = image.ImageReference.Offer,
                Sku = image.ImageReference.Sku,
                Version = image.ImageReference.Version
            },
            nodeAgentSkuId: image.NodeAgentSkuId);

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = vmSize,
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = nodeCount }
            }
        };

        // Commit the pool to the Batch service via Azure.ResourceManager.Batch.
        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static void BuildImageReference()
    {
        #region Snippet:linux_nodes_image_reference
        BatchImageReference imageReference = new BatchImageReference()
        {
            Publisher = "canonical",
            Offer = "0001-com-ubuntu-server-focal",
            Sku = "20_04-lts",
            Version = "latest"
        };
        #endregion
        _ = imageReference;
    }
}

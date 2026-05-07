// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-application-packages.md

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class ApplicationPackages
{
    // Block 1: Create pool with an application package reference.
    public static async Task CreatePoolWithAppPackageAsync()
    {
        #region Snippet:app_pkg_pool_create
        ArmClient armClient = new ArmClient(new DefaultAzureCredential());

        ResourceIdentifier batchAccountResourceId =
            BatchAccountResource.CreateResourceIdentifier("subscriptionId", "resourceGroupName", "accountName");
        BatchAccountResource batchAccount = armClient.GetBatchAccountResource(batchAccountResourceId);

        BatchAccountPoolCollection poolCollection = batchAccount.GetBatchAccountPools();

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "standard_d1_v2",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2019-datacenter-core",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.windows amd64")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 1 }
            }
        };

        // Specify the application and version to install on the compute nodes
        poolData.ApplicationPackages.Add(
            new Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference(
                new ResourceIdentifier($"{batchAccountResourceId}/applications/litware"))
            {
                Version = "1.1001.2b"
            });

        // Create the pool. As the nodes join the pool, the specified application package
        // is installed on each.
        ArmOperation<BatchAccountPoolResource> pool = await poolCollection.CreateOrUpdateAsync(
            WaitUntil.Completed, "myPool", poolData);
        #endregion
        _ = pool;
    }

    // Block 2: Task with application package reference.
    public static void TaskWithAppPackage()
    {
        #region Snippet:app_pkg_task
        BatchTaskCreateOptions task = new BatchTaskCreateOptions(
            "litwaretask001",
            "cmd /c %AZ_BATCH_APP_PACKAGE_LITWARE%\\litware.exe -args -here");

        task.ApplicationPackageReferences.Add(
            new Azure.Compute.Batch.BatchApplicationPackageReference("litware")
            {
                Version = "1.1001.2b"
            });
        #endregion
    }

    // Block 3: Blender task command line.
    public static void BlenderTask()
    {
        #region Snippet:app_pkg_blender_task
        string taskId = "blendertask01";
        string commandLine =
            @"cmd /c %AZ_BATCH_APP_PACKAGE_BLENDER%\blender.exe -args -here";
        BatchTaskCreateOptions blenderTask = new BatchTaskCreateOptions(taskId, commandLine);
        #endregion
        _ = blenderTask;
    }

    // Block 4: Update pool's application package.
    public static async Task UpdatePoolAppPackageAsync()
    {
        #region Snippet:app_pkg_pool_update
        ArmClient armClient = Stubs.ArmClient;
        string newVersion = "2.76b";

        ResourceIdentifier batchAccountResourceId =
            BatchAccountResource.CreateResourceIdentifier("subscriptionId", "resourceGroupName", "accountName");
        BatchAccountPoolResource boundPool = await armClient
            .GetBatchAccountPoolResource(BatchAccountPoolResource.CreateResourceIdentifier(
                "subscriptionId", "resourceGroupName", "accountName", "myPool"))
            .GetAsync();

        BatchAccountPoolData poolData = boundPool.Data;
        poolData.ApplicationPackages.Clear();
        poolData.ApplicationPackages.Add(
            new Azure.ResourceManager.Batch.Models.BatchApplicationPackageReference(
                new ResourceIdentifier($"{batchAccountResourceId}/applications/blender"))
            {
                Version = newVersion
            });

        await boundPool.UpdateAsync(poolData);
        #endregion
    }

    // Block 5: List applications and packages in a Batch account.
    public static async Task ListApplicationsAsync()
    {
        #region Snippet:app_pkg_list
        ArmClient armClient = Stubs.ArmClient;
        ResourceIdentifier batchAccountResourceId =
            BatchAccountResource.CreateResourceIdentifier("subscriptionId", "resourceGroupName", "accountName");
        BatchAccountResource batchAccount = armClient.GetBatchAccountResource(batchAccountResourceId);

        await foreach (BatchApplicationResource app in batchAccount.GetBatchApplications().GetAllAsync())
        {
            Console.WriteLine("ID: {0} | Display Name: {1}", app.Data.Name, app.Data.DisplayName);

            await foreach (BatchApplicationPackageResource package in app.GetBatchApplicationPackages().GetAllAsync())
            {
                Console.WriteLine("  {0}", package.Data.Name);
            }
        }
        #endregion
    }
}

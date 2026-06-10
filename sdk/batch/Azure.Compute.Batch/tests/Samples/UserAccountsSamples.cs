// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-user-accounts.md.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class UserAccountsSamples
{
    public static BatchTaskCreateOptions TaskWithAdminAutoUser()
    {
        BatchTaskCreateOptions task = new BatchTaskCreateOptions("1", "cmd.exe /c echo 1");
        #region Snippet:user_accounts_admin_autouser
        task.UserIdentity = new UserIdentity()
        {
            AutoUser = new AutoUserSpecification()
            {
                ElevationLevel = ElevationLevel.Admin,
                Scope = AutoUserScope.Task
            }
        };
        #endregion
        return task;
    }

    public static BatchTaskCreateOptions TaskWithPoolScopedAutoUser()
    {
        BatchTaskCreateOptions task = new BatchTaskCreateOptions("1", "cmd.exe /c echo 1");
        #region Snippet:user_accounts_pool_scope
        task.UserIdentity = new UserIdentity()
        {
            AutoUser = new AutoUserSpecification()
            {
                Scope = AutoUserScope.Pool
            }
        };
        #endregion
        return task;
    }

    public static async Task CreatePoolWithUserAccountsWindowsAsync(string poolId)
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:user_accounts_pool_windows
        Console.WriteLine("Creating pool [{0}]...", poolId);

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "standard_d2s_v3",
            DeploymentConfiguration = new BatchDeploymentConfiguration()
            {
                VmConfiguration = new BatchVmConfiguration(
                    imageReference: new BatchImageReference()
                    {
                        Publisher = "MicrosoftWindowsServer",
                        Offer = "WindowsServer",
                        Sku = "2022-datacenter-core",
                        Version = "latest"
                    },
                    nodeAgentSkuId: "batch.node.windows amd64")
            },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 2 }
            },
            UserAccounts =
            {
                new BatchUserAccount("adminUser", "A1bC2d") { ElevationLevel = BatchUserAccountElevationLevel.Admin },
                new BatchUserAccount("nonAdminUser", "A1bC2d") { ElevationLevel = BatchUserAccountElevationLevel.NonAdmin },
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static async Task CreatePoolWithUserAccountsLinuxAsync(string poolId)
    {
        BatchClient batchClient = Stubs.BatchClient;
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:user_accounts_pool_linux
        // Obtain a collection of all available node agent SKUs.
        List<BatchSupportedImage> images = new List<BatchSupportedImage>();
        await foreach (BatchSupportedImage img in batchClient.GetSupportedImagesAsync())
        {
            images.Add(img);
        }

        // Define a delegate specifying properties of the VM image to use.
        bool IsUbuntu2404(Azure.Compute.Batch.BatchVmImageReference imageRef) =>
            imageRef.Publisher == "Canonical" &&
            imageRef.Offer == "ubuntu-24_04-lts" &&
            imageRef.Sku.Contains("server");

        // Pick the first supported image that matches.
        BatchSupportedImage ubuntuImage = null;
        foreach (var img in images)
        {
            if (IsUbuntu2404(img.ImageReference)) { ubuntuImage = img; break; }
        }

        // Create the BatchVmConfiguration to use to create the pool.
        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: new BatchImageReference()
            {
                Publisher = ubuntuImage.ImageReference.Publisher,
                Offer = ubuntuImage.ImageReference.Offer,
                Sku = ubuntuImage.ImageReference.Sku,
                Version = ubuntuImage.ImageReference.Version
            },
            nodeAgentSkuId: ubuntuImage.NodeAgentSkuId);

        Console.WriteLine("Creating pool [{0}]...", poolId);

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_d2s_v3",
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 2 }
            },
            UserAccounts =
            {
                new BatchUserAccount("adminUser", "A1bC2d")
                {
                    ElevationLevel = BatchUserAccountElevationLevel.Admin,
                    LinuxUserConfiguration = new BatchLinuxUserConfiguration()
                    {
                        Uid = 12345,
                        Gid = 98765,
                        SshPrivateKey = Guid.NewGuid().ToString()
                    }
                },
                new BatchUserAccount("nonAdminUser", "A1bC2d")
                {
                    ElevationLevel = BatchUserAccountElevationLevel.NonAdmin,
                    LinuxUserConfiguration = new BatchLinuxUserConfiguration()
                    {
                        Uid = 45678,
                        Gid = 98765,
                        SshPrivateKey = Guid.NewGuid().ToString()
                    }
                },
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static BatchTaskCreateOptions TaskWithNamedUser()
    {
        const string AdminUserAccountName = "adminUser";
        #region Snippet:user_accounts_task_named
        BatchTaskCreateOptions task = new BatchTaskCreateOptions("1", "cmd.exe /c echo 1")
        {
            UserIdentity = new UserIdentity() { Username = AdminUserAccountName }
        };
        #endregion
        return task;
    }
}

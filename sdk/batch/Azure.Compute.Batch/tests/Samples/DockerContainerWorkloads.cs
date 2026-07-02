// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-docker-container-workloads.md.

using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Compute.Batch;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class DockerContainerWorkloads
{
    public static async Task CreatePoolWithoutPrefetchAsync(string poolId)
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:docker_pool_no_prefetch
        BatchImageReference imageReference = new BatchImageReference()
        {
            Publisher = "microsoft-dsvm",
            Offer = "ubuntu-hpc",
            Sku = "2204",
            Version = "latest"
        };

        // Specify container configuration. This is required even though there are no prefetched images.
        BatchVmContainerConfiguration containerConfig = new BatchVmContainerConfiguration("dockerCompatible");

        // VM configuration
        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: imageReference,
            nodeAgentSkuId: "batch.node.ubuntu 22.04")
        {
            ContainerConfiguration = containerConfig
        };

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "STANDARD_D2S_V3",
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 1 }
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static async Task CreatePoolWithDockerHubPrefetchAsync(string poolId)
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:docker_pool_dockerhub_prefetch
        BatchImageReference imageReference = new BatchImageReference()
        {
            Publisher = "microsoft-dsvm",
            Offer = "ubuntu-hpc",
            Sku = "2204",
            Version = "latest"
        };

        BatchVmContainerRegistry containerRegistry = new BatchVmContainerRegistry()
        {
            RegistryServer = "https://hub.docker.com",
            IdentityResourceId = new ResourceIdentifier("/subscriptions/SUB/resourceGroups/RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity-name")
        };

        // Specify container configuration, prefetching Docker images
        BatchVmContainerConfiguration containerConfig = new BatchVmContainerConfiguration("dockerCompatible")
        {
            ContainerImageNames = { "tensorflow/tensorflow:latest-gpu" },
            ContainerRegistries = { containerRegistry }
        };

        // VM configuration
        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: imageReference,
            nodeAgentSkuId: "batch.node.ubuntu 22.04")
        {
            ContainerConfiguration = containerConfig
        };

        // Set a native host command line start task
        BatchAccountPoolStartTask startTaskContainer = new BatchAccountPoolStartTask()
        {
            CommandLine = "<native-host-command-line>"
        };

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_NC6S_V3",
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            StartTask = startTaskContainer
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static async Task CreatePoolWithAcrPrefetchAsync(string poolId)
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();
        BatchImageReference imageReference = new BatchImageReference()
        {
            Publisher = "microsoft-dsvm",
            Offer = "ubuntu-hpc",
            Sku = "2204",
            Version = "latest"
        };

        #region Snippet:docker_pool_acr_prefetch
        // Specify a container registry
        BatchVmContainerRegistry containerRegistry = new BatchVmContainerRegistry()
        {
            RegistryServer = "myContainerRegistry.azurecr.io",
            IdentityResourceId = new ResourceIdentifier("/subscriptions/SUB/resourceGroups/RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity-name")
        };

        // Create container configuration, prefetching Docker images from the container registry
        BatchVmContainerConfiguration containerConfig = new BatchVmContainerConfiguration("dockerCompatible")
        {
            ContainerImageNames = { "myContainerRegistry.azurecr.io/tensorflow/tensorflow:latest-gpu" },
            ContainerRegistries = { containerRegistry }
        };

        // VM configuration
        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: imageReference,
            nodeAgentSkuId: "batch.node.ubuntu 22.04")
        {
            ContainerConfiguration = containerConfig
        };

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = "Standard_NC6S_V3",
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 2 }
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolId, poolData);
        #endregion
    }

    public static BatchVmContainerRegistry CreateAcrRegistryReference()
    {
        #region Snippet:docker_acr_registry
        BatchVmContainerRegistry containerRegistry = new BatchVmContainerRegistry()
        {
            RegistryServer = "myContainerRegistry.azurecr.io",
            IdentityResourceId = new ResourceIdentifier("/subscriptions/SUB/resourceGroups/RG/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity-name")
        };
        #endregion
        return containerRegistry;
    }

    public static BatchTaskCreateOptions CreateContainerTask()
    {
        #region Snippet:docker_container_task
        // Simple container task command
        string cmdLine = @"c:\app\myApp.exe";

        Azure.Compute.Batch.BatchTaskContainerSettings cmdContainerSettings = new Azure.Compute.Batch.BatchTaskContainerSettings("myimage")
        {
            ContainerRunOptions = @"--rm --workdir c:\app"
        };

        BatchTaskCreateOptions containerTask = new BatchTaskCreateOptions(
            id: "Task1",
            commandLine: cmdLine)
        {
            ContainerSettings = cmdContainerSettings
        };
        #endregion
        return containerTask;
    }
}

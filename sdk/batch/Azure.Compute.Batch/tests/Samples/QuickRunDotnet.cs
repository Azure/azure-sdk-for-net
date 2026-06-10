// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/quick-run-dotnet.md.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Compute.Batch;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace BatchDocSamples;

internal static class QuickRunDotnet
{
    private const string PoolId = "DotNetQuickstartPool";
    private const string PoolVMSize = "STANDARD_D2_V3";
    private const int PoolNodeCount = 2;
    private const string JobId = "DotNetQuickstartJob";

    public static void DeclareCredentials()
    {
        #region Snippet:quickrun_credentials
        // Batch account credentials
        const string BatchAccountName = "<batch account>";
        const string BatchAccountKey  = "<primary access key>";
        const string BatchAccountUrl  = "<account endpoint>";

        // Storage account credentials
        const string StorageAccountName = "<storage account name>";
        const string StorageAccountKey  = "<key1>";
        #endregion
        _ = (BatchAccountName, BatchAccountKey, BatchAccountUrl, StorageAccountName, StorageAccountKey);
    }

    public static async Task CreateBatchPoolAsync()
    {
        BatchAccountResource batchAccount = Stubs.GetBatchAccount();

        #region Snippet:quickrun_create_pool
        BatchImageReference imageReference = new BatchImageReference()
        {
            Publisher = "MicrosoftWindowsServer",
            Offer = "WindowsServer",
            Sku = "2016-datacenter-smalldisk",
            Version = "latest"
        };

        BatchVmConfiguration vmConfiguration = new BatchVmConfiguration(
            imageReference: imageReference,
            nodeAgentSkuId: "batch.node.windows amd64");

        BatchAccountPoolData poolData = new BatchAccountPoolData()
        {
            VmSize = PoolVMSize,
            DeploymentConfiguration = new BatchDeploymentConfiguration() { VmConfiguration = vmConfiguration },
            ScaleSettings = new BatchAccountPoolScaleSettings()
            {
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = PoolNodeCount }
            }
        };

        await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, PoolId, poolData);
        #endregion
    }

    public static async Task CreateBatchJobAsync()
    {
        BatchClient batchClient = Stubs.BatchClient;

        #region Snippet:quickrun_create_job
        BatchJobCreateOptions job = new BatchJobCreateOptions(JobId, new BatchPoolInfo() { PoolId = PoolId });
        await batchClient.CreateJobAsync(job);
        #endregion
    }

    public static async Task AddTasksAsync(IList<ResourceFile> inputFiles)
    {
        BatchClient batchClient = Stubs.BatchClient;
        List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();

        #region Snippet:quickrun_add_tasks
        for (int i = 0; i < inputFiles.Count; i++)
        {
            string taskId = String.Format("Task{0}", i);
            string inputFilename = inputFiles[i].FilePath;
            string taskCommandLine = String.Format("cmd /c type {0}", inputFilename);

            BatchTaskCreateOptions task = new BatchTaskCreateOptions(taskId, taskCommandLine)
            {
                ResourceFiles = { inputFiles[i] }
            };
            tasks.Add(task);
        }

        await batchClient.CreateTasksAsync(JobId, tasks);
        #endregion
    }

    public static async Task PrintTaskOutputAsync()
    {
        BatchClient batchClient = Stubs.BatchClient;

        #region Snippet:quickrun_print_output
        await foreach (BatchTask task in batchClient.GetTasksAsync(JobId))
        {
            string nodeId = task.NodeInfo?.NodeId ?? "<unknown>";
            Console.WriteLine("Task: {0}", task.Id);
            Console.WriteLine("Node: {0}", nodeId);
            Console.WriteLine("Standard out:");
            BinaryData stdout = await batchClient.GetTaskFileAsync(JobId, task.Id, "stdout.txt");
            Console.WriteLine(stdout.ToString());
        }
        #endregion
    }
}

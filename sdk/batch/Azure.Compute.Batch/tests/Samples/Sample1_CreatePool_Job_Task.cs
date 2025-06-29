// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;

namespace Azure.Compute.Batch.Tests.Samples
{
    /// <summary>
    ///   Class is used as code base for Sample1_CreatePool_Job_Task
    /// </summary>
    ///
    public class Sample1_CreatePool_Job_Task
    {
        /// <summary>
        ///   Code to create a Batch client and call operations for snippets.
        /// </summary>
        ///
        public async void BatchClientOperations()
        {
            #region Snippet:Batch_Sample01_CreateBatchClient

            var credential = new DefaultAzureCredential();
            BatchClient batchClient = new BatchClient(
            new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
            #endregion

            #region Snippet:Batch_Sample01_CreateBatchJob
            await batchClient.CreateJobAsync(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
            #endregion

            #region Snippet:Batch_Sample01_CreateBatchTask
            await batchClient.CreateTaskAsync("jobId", new BatchTaskCreateOptions("taskId", $"echo Hello world"));
            #endregion

            #region Snippet:Batch_Sample01_GetTasks
            var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(await reader.ReadLineAsync());
                }
            }
            #endregion
        }

        /// <summary>
        ///   Code to create a Batch mgmt client and call operatrions snippet.
        /// </summary>
        ///
        public async void BatchMgmtOperations()
        {
            #region Snippet:Batch_Sample01_CreateBatchMgmtClient

            var credential = new DefaultAzureCredential();
            ArmClient _armClient = new ArmClient(credential);
            #endregion

            #region Snippet:Batch_Sample01_GetBatchMgmtAccount
            var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
            BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();
            #endregion

            #region Snippet:Batch_Sample01_PoolCreation
            var poolName = "HelloWorldPool";
            var imageReference = new Azure.ResourceManager.Batch.Models.BatchImageReference()
            {
                Publisher = "canonical",
                Offer = "0001-com-ubuntu-server-jammy",
                Sku = "22_04-lts",
                Version = "latest"
            };
            string nodeAgentSku = "batch.node.ubuntu 22.04";

            ArmOperation<BatchAccountPoolResource> armOperation = await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(
                WaitUntil.Completed, poolName, new BatchAccountPoolData()
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
                });
            BatchAccountPoolResource pool = armOperation.Value;
            #endregion
        }
    }
}

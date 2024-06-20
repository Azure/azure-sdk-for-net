// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Compute.Batch.Tests.Snippets
{
    public class ReadMeSnippets
    {
        public void AzureNameKeyCredentialSnippet()
        {
            #region Snippet:Batch_Readme_AzureNameKeyCredential
            var credential = new AzureNamedKeyCredential("examplebatchaccount", "BatchAccountKey");
            BatchClient _batchClient = new BatchClient(
                new Uri("https://examplebatchaccount.eastus.batch.azure.com"),
                credential);
            #endregion
        }

        public void SyncOperations()
        {
            #region Snippet:Batch_Readme_EntraIDCredential

            var credential = new DefaultAzureCredential();
            BatchClient _batchClient = new BatchClient(
            new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
            #endregion

            #region Snippet:Batch_Readme_PoolCreation

            string poolID = "HelloWorldPool";

            ImageReference imageReference = new ImageReference()
            {
                Publisher = "MicrosoftWindowsServer",
                Offer = "WindowsServer",
                Sku = "2019-datacenter-smalldisk",
                Version = "latest"
            };

            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

            BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
            poolID, "STANDARD_D1_v2")
            {
                VirtualMachineConfiguration = virtualMachineConfiguration,
                TargetDedicatedNodes = 2,
            };

            // create pool
            _batchClient.CreatePool(batchPoolCreateOptions);
            #endregion

            #region Snippet:Batch_Readme_PoolRetreival
            BatchPool batchPool = _batchClient.GetPool(poolID);

            Console.WriteLine(batchPool.Id);
            Console.WriteLine(batchPool.Url);
            Console.WriteLine(batchPool.AllocationState);
            #endregion

            #region Snippet:Batch_Readme_ListPools
            foreach (BatchPool item in _batchClient.GetPools())
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_NodeRetreival
            BatchNode batchNode = _batchClient.GetNode("<poolId>", "<nodeId>");
            Console.WriteLine(batchNode.Id);
            Console.WriteLine(batchNode.Url);
            Console.WriteLine(batchNode.State);
            #endregion

            #region Snippet:Batch_Readme_ListNodes
            foreach (BatchNode item in _batchClient.GetNodes(poolID))
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_JobCreation
            _batchClient.CreateJob(new BatchJobCreateContent("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
            #endregion

            #region Snippet:Batch_Readme_JobRetreival
            BatchJob batchJob = _batchClient.GetJob("jobID");
            Console.WriteLine(batchJob.Id);
            Console.WriteLine(batchJob.State);
            #endregion

            #region Snippet:Batch_Readme_ListJobs
            foreach (BatchJob item in _batchClient.GetJobs())
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_TaskCreation
            _batchClient.CreateTask("jobId", new BatchTaskCreateContent("taskId", $"echo Hello world"));
            #endregion

            #region Snippet:Batch_Readme_TaskRetreival
            BatchTask batchTask = _batchClient.GetTask("<jobId>", "<taskId>");
            Console.WriteLine(batchTask.Id);
            Console.WriteLine(batchTask.State);
            #endregion

            #region Snippet:Batch_Readme_ListTasks
            var completedTasks = _batchClient.GetTasks("jobId", filter: "state eq 'completed'");
            foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = _batchClient.GetTaskFile("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(reader.ReadLine());
                }
            }
            #endregion
        }

        public async void ASyncOperations()
        {
            var credential = new DefaultAzureCredential();
            BatchClient _batchClient = new BatchClient(
            new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);

            #region Snippet:Batch_Readme_PoolCreationAsync

            string poolID = "HelloWorldPool";

            ImageReference imageReference = new ImageReference()
            {
                Publisher = "MicrosoftWindowsServer",
                Offer = "WindowsServer",
                Sku = "2019-datacenter-smalldisk",
                Version = "latest"
            };

            VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

            BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
            poolID, "STANDARD_D1_v2")
            {
                VirtualMachineConfiguration = virtualMachineConfiguration,
                TargetDedicatedNodes = 2,
            };

            // create pool
            await _batchClient.CreatePoolAsync(batchPoolCreateOptions);
            #endregion

            #region Snippet:Batch_Readme_PoolRetreivalAsync
            BatchPool batchPool = await _batchClient.GetPoolAsync(poolID);

            Console.WriteLine(batchPool.Id);
            Console.WriteLine(batchPool.Url);
            Console.WriteLine(batchPool.AllocationState);
            #endregion

            #region Snippet:Batch_Readme_ListPoolsAsync
            await foreach (BatchPool item in _batchClient.GetPoolsAsync())
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_NodeRetreivalAsync
            BatchNode batchNode = await _batchClient.GetNodeAsync("<poolId>", "<nodeId>");
            Console.WriteLine(batchNode.Id);
            Console.WriteLine(batchNode.Url);
            Console.WriteLine(batchNode.State);
            #endregion

            #region Snippet:Batch_Readme_ListNodesAsync
            await foreach (BatchNode item in _batchClient.GetNodesAsync(poolID))
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_JobCreationAsync
            await _batchClient.CreateJobAsync(new BatchJobCreateContent("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
            #endregion

            #region Snippet:Batch_Readme_JobRetreivalAsync
            BatchJob batchJob = await _batchClient.GetJobAsync("jobID");
            Console.WriteLine(batchJob.Id);
            Console.WriteLine(batchJob.State);
            #endregion

            #region Snippet:Batch_Readme_ListJobsAsync
            await foreach (BatchJob item in _batchClient.GetJobsAsync())
            {
                Console.WriteLine(item.Id);
            }
            #endregion

            #region Snippet:Batch_Readme_TaskCreationAsync
            await _batchClient.CreateTaskAsync("jobId", new BatchTaskCreateContent("taskId", $"echo Hello world"));
            #endregion

            #region Snippet:Batch_Readme_TaskRetreivalAsync
            BatchTask batchTask = await _batchClient.GetTaskAsync("<jobId>", "<taskId>");
            Console.WriteLine(batchTask.Id);
            Console.WriteLine(batchTask.State);
            #endregion

            #region Snippet:Batch_Readme_ListTasksAsync
            var completedTasks = _batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
            await foreach (BatchTask t in completedTasks)
            {
                var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                    t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                BinaryData fileContents = await _batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
                using (var reader = new StreamReader(fileContents.ToStream()))
                {
                    Console.WriteLine(reader.ReadLineAsync());
                }
            }
            #endregion
        }
    }
}

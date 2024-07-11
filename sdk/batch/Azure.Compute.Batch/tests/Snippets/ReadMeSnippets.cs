﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            var credential = new AzureNamedKeyCredential("<your account>", "BatchAccountKey");
            BatchClient _batchClient = new BatchClient(
                new Uri("https://<your account>.eastus.batch.azure.com"),
                credential);
            #endregion
        }

        public void DefaultAzureCredential()
        {
            #region Snippet:Batch_Readme_EntraIDCredential

            var credential = new DefaultAzureCredential();
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), credential);
            #endregion
        }

        public void PoolCreate()
        {
            #region Snippet:Batch_Readme_PoolCreation

            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

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
        }

        public void PoolRetrieve()
        {
            #region Snippet:Batch_Readme_PoolRetreival
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchPool batchPool = _batchClient.GetPool("poolID");

            Console.WriteLine(batchPool.Id);
            Console.WriteLine(batchPool.Url);
            Console.WriteLine(batchPool.AllocationState);
            #endregion
        }

        public void ListPools()
        {
            #region Snippet:Batch_Readme_ListPools
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchPool item in _batchClient.GetPools())
            {
                Console.WriteLine(item.Id);
            }
            #endregion
        }

        public void NodeRetreival()
        {
            #region Snippet:Batch_Readme_NodeRetreival
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchNode batchNode = _batchClient.GetNode("<poolId>", "<nodeId>");
            Console.WriteLine(batchNode.Id);
            Console.WriteLine(batchNode.Url);
            Console.WriteLine(batchNode.State);
            #endregion
        }

        public void ListNodes()
        {
            #region Snippet:Batch_Readme_ListNodes
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchNode item in _batchClient.GetNodes("poolID"))
            {
                Console.WriteLine(item.Id);
            }
            #endregion
        }

        public void JobCreation()
        {
            #region Snippet:Batch_Readme_JobCreation
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            _batchClient.CreateJob(new BatchJobCreateContent("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
            #endregion
        }

        public void JobRetreival()
        {
            #region Snippet:Batch_Readme_JobRetreival
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJob batchJob = _batchClient.GetJob("jobID");
            Console.WriteLine(batchJob.Id);
            Console.WriteLine(batchJob.State);
            #endregion
        }

        public void ListJobs()
        {
            #region Snippet:Batch_Readme_ListJobs
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchJob item in _batchClient.GetJobs())
            {
                Console.WriteLine(item.Id);
            }
            #endregion
        }

        public void TaskCreation()
        {
            #region Snippet:Batch_Readme_TaskCreation
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            _batchClient.CreateTask("jobId", new BatchTaskCreateContent("taskId", $"echo Hello world"));
            #endregion
        }

        public void TaskRetreival()
        {
            #region Snippet:Batch_Readme_TaskRetreival
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchTask batchTask = _batchClient.GetTask("<jobId>", "<taskId>");
            Console.WriteLine(batchTask.Id);
            Console.WriteLine(batchTask.State);
            #endregion
        }

        public void ListTasks()
        {
            #region Snippet:Batch_Readme_ListTasks
            BatchClient _batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

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
    }
}

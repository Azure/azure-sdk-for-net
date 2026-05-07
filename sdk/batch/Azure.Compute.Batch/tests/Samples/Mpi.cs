// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Snippets extracted from articles/batch/batch-mpi.md

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

internal static class Mpi
{
    private static readonly BatchClient batchClient = Stubs.BatchClient;
    private static readonly BatchClient myBatchClient = Stubs.BatchClient;

    // Block 1 + 2: Create pool with inter-node communication and a start task.
    public static async Task CreateMpiPoolAsync()
    {
        #region Snippet:mpi_pool_create
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
                FixedScale = new BatchAccountFixedScaleSettings() { TargetDedicatedNodes = 3 }
            },

            // Multi-instance tasks require inter-node communication, and those nodes
            // must run only one task at a time.
            InterNodeCommunication = InterNodeCommunicationState.Enabled,
            TaskSlotsPerNode = 1
        };
        #endregion

        #region Snippet:mpi_pool_starttask
        // Add a start task to the pool which we use for installing MS-MPI on
        // the nodes as they join the pool (or when they are restarted).
        poolData.StartTask = new BatchAccountPoolStartTask()
        {
            CommandLine = "cmd /c MSMpiSetup.exe -unattend -force",
            UserIdentity = new BatchUserIdentity()
            {
                AutoUser = new BatchAutoUserSpecification() { ElevationLevel = BatchUserAccountElevationLevel.Admin }
            },
            WaitForSuccess = true,
        };
        poolData.StartTask.ResourceFiles.Add(new BatchResourceFile()
        {
            HttpUri = new Uri("https://mystorageaccount.blob.core.windows.net/mycontainer/MSMpiSetup.exe"),
            FilePath = "MSMpiSetup.exe"
        });

        // Create the fully configured pool.
        ArmOperation<BatchAccountPoolResource> pool = await poolCollection.CreateOrUpdateAsync(
            WaitUntil.Completed, "MultiInstanceSamplePool", poolData);
        #endregion
    }

    // Block 3: Create a multi-instance task.
    public static async Task CreateMultiInstanceTaskAsync()
    {
        int numberOfNodes = 3;

        #region Snippet:mpi_task_create
        // Create the multi-instance task. Its command line is the "application command"
        // and will be executed *only* by the primary, and only after the primary and
        // subtasks execute the CoordinationCommandLine.
        BatchTaskCreateOptions myMultiInstanceTask = new BatchTaskCreateOptions(
            id: "mymultiinstancetask",
            commandLine: "cmd /c mpiexec.exe -wdir %AZ_BATCH_TASK_SHARED_DIR% MyMPIApplication.exe")
        {
            // Configure the task's MultiInstanceSettings. The CoordinationCommandLine will be executed by
            // the primary and all subtasks.
            MultiInstanceSettings = new MultiInstanceSettings(
                @"cmd /c start cmd /c ""%MSMPI_BIN%\smpd.exe"" -d")
            {
                NumberOfInstances = numberOfNodes
            }
        };

        myMultiInstanceTask.MultiInstanceSettings.CommonResourceFiles.Add(new ResourceFile()
        {
            HttpUri = new Uri("https://mystorageaccount.blob.core.windows.net/mycontainer/MyMPIApplication.exe"),
            FilePath = "MyMPIApplication.exe"
        });

        // Submit the task to the job. Batch will take care of splitting it into subtasks and
        // scheduling them for execution on the nodes.
        await myBatchClient.CreateTaskAsync("mybatchjob", myMultiInstanceTask);
        #endregion
    }

    // Block 4: Setting MultiInstanceSettings number of nodes only.
    public static void SetMultiInstanceNodeCount()
    {
        BatchTaskCreateOptions myMultiInstanceTask = new BatchTaskCreateOptions("t", "cmd");
        #region Snippet:mpi_set_node_count
        int numberOfNodes = 10;
        myMultiInstanceTask.MultiInstanceSettings = new MultiInstanceSettings("coord-cmd")
        {
            NumberOfInstances = numberOfNodes
        };
        #endregion
    }

    // Block 5: Subtask info iteration.
    public static async Task IterateSubtasksAsync()
    {
        #region Snippet:mpi_iterate_subtasks
        // Obtain the multi-instance task from the Batch service
        BatchTask myMultiInstanceTask = await batchClient.GetTaskAsync("mybatchjob", "mymultiinstancetask");

        // Now iterate over the subtasks for the task and print their stdout and stderr
        // output if the subtask has completed
        await foreach (BatchSubtask subtask in batchClient.GetSubTasksAsync("mybatchjob", "mymultiinstancetask"))
        {
            Console.WriteLine("subtask: {0}", subtask.Id);
            Console.WriteLine("exit code: {0}", subtask.ExitCode);

            if (subtask.State == BatchSubtaskState.Completed)
            {
                BatchNode node = await batchClient.GetNodeAsync(
                    subtask.NodeInfo.PoolId,
                    subtask.NodeInfo.NodeId);

                BinaryData stdOut = await batchClient.GetNodeFileAsync(
                    subtask.NodeInfo.PoolId, node.Id, $"{subtask.NodeInfo.TaskRootDirectory}/stdout.txt");
                BinaryData stdErr = await batchClient.GetNodeFileAsync(
                    subtask.NodeInfo.PoolId, node.Id, $"{subtask.NodeInfo.TaskRootDirectory}/stderr.txt");

                Console.WriteLine("node: {0}:", node.Id);
                Console.WriteLine("stdout.txt: {0}", stdOut);
                Console.WriteLine("stderr.txt: {0}", stdErr);
            }
            else
            {
                Console.WriteLine("\tSubtask {0} is in state {1}", subtask.Id, subtask.State);
            }
        }
        #endregion
    }
}

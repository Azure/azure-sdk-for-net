// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
using Azure.ResourceManager.Models;

namespace Azure.Compute.Batch.Tests.Samples
{
    public class MigrationSnippets
    {
        public void BatchMigrationException()
        {
            var credential = new DefaultAzureCredential();
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), credential);
            BatchPoolResizeOptions resizeOptions = new BatchPoolResizeOptions();
            #region Snippet:Batch_Migration_Exception
            try
            {
                batchClient.ResizePool("fakepool", resizeOptions);
            }
            catch (Azure.RequestFailedException e)
            {
                if ((e.ErrorCode == BatchErrorCode.PoolNotFound) &&
                    (e.Status == 404))
                {
                    // write out the summary message
                    Console.WriteLine(e.Message);

                    // additional message details
                    foreach (DictionaryEntry item in e.Data)
                    {
                        Console.WriteLine(item.Key);
                        Console.WriteLine(item.Value);
                    }
                }
            }
            #endregion
        }

        public void BatchDeletePoolOperation()
        {
            #region Snippet:Batch_Migration_DeletePool_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            DeletePoolOperation operation = batchClient.DeletePool("poolID");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDeletePool()
        {
            #region Snippet:Batch_Migration_DeletePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeletePool("poolID");
            #endregion
        }

        public void BatchPatchPool()
        {
            #region Snippet:Batch_Migration_PatchPool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchPoolUpdateOptions updateOptions = new BatchPoolUpdateOptions();
            updateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

            batchClient.UpdatePool("poolID", updateOptions);
            #endregion
        }

        public void BatchUpdatePool()
        {
            #region Snippet:Batch_Migration_UpdatePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchMetadataItem[] metadataItems = new BatchMetadataItem[] {
              new BatchMetadataItem("name", "value")};

            BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
                    new BatchApplicationPackageReference("applicationPackage")
                    {
                        Version = "1"
                    }
                };

            BatchCertificateReference[] certificateReferences = new BatchCertificateReference[] {
                    new BatchCertificateReference("thumbprint","thumbprintAlgorithm")
                    {
                        StoreLocation = "storeLocation",
                        StoreName = "storeName"
                    }
            };

            BatchPoolReplaceOptions replaceOptions = new BatchPoolReplaceOptions(certificateReferences, batchApplicationPackageReferences, metadataItems);
            batchClient.ReplacePoolProperties("poolID", replaceOptions);
            #endregion
        }

        public void BatchResizePool()
        {
            #region Snippet:Batch_Migration_ResizePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchPoolResizeOptions resizeOptions = new BatchPoolResizeOptions()
            {
                TargetDedicatedNodes = 1,
                ResizeTimeout = TimeSpan.FromMinutes(10),
            };

            batchClient.ResizePool("poolID", resizeOptions);
            #endregion
        }

        public void BatchStopResizePool()
        {
            #region Snippet:Batch_Migration_StopResizePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.StopPoolResize("poolId");
            #endregion
        }

        public void BatchEnableAutoScalePool()
        {
            #region Snippet:Batch_Migration_EnableAutoScalePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
            TimeSpan evalInterval = TimeSpan.FromMinutes(6);
            string poolASFormulaNew = "$TargetDedicated = 1;";

            BatchPoolEnableAutoScaleOptions batchPoolEnableAutoScaleOptions = new BatchPoolEnableAutoScaleOptions()
            {
                AutoScaleEvaluationInterval = evalInterval,
                AutoScaleFormula = poolASFormulaNew,
            };

            batchClient.EnablePoolAutoScale("poolId", batchPoolEnableAutoScaleOptions);
            #endregion
        }

        public void BatchDisableAutoScalePool()
        {
            #region Snippet:Batch_Migration_DisableAutoScalePool
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DisablePoolAutoScale("poolId");
            #endregion
        }

        public void BatchEvaluatePoolAutoScale()
        {
            #region Snippet:Batch_Migration_EvaluatePoolAutoScale
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            string poolASFormulaNew = "$TargetDedicated = 1;";
            BatchPoolEvaluateAutoScaleOptions batchPoolEvaluateAutoScaleOptions = new BatchPoolEvaluateAutoScaleOptions(poolASFormulaNew);
            AutoScaleRun eval = batchClient.EvaluatePoolAutoScale("poolId", batchPoolEvaluateAutoScaleOptions);
            #endregion
        }

        public void BatchGetPoolNodeCounts()
        {
            #region Snippet:Batch_Migration_GetPoolNodeCounts
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchPoolNodeCounts item in batchClient.GetPoolNodeCounts())
            {
                // do something
            }
            #endregion
        }

        public void BatchGetPoolUsageMetrics()
        {
            #region Snippet:Batch_Migration_GetPoolUsageMetrics
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchPoolUsageMetrics item in batchClient.GetPoolUsageMetrics())
            {
                // do something
            }
            #endregion
        }

        public void BatchGetSupportedImages()
        {
            #region Snippet:Batch_Migration_GetSupportedImages
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchSupportedImage item in batchClient.GetSupportedImages())
            {
                // do something
            }
            #endregion
        }

        public void PoolCreateManagementPlane()
        {
            #region Snippet:Batch_Migration_PoolCreateManagementPlane

            var credential = new DefaultAzureCredential();
            ArmClient _armClient = new ArmClient(credential);

            var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
            BatchAccountResource batchAccount = _armClient.GetBatchAccountResource(batchAccountIdentifier);

            var poolName = "HelloWorldPool";
            var imageReference = new Azure.ResourceManager.Batch.Models.BatchImageReference()
            {
                Publisher = "canonical",
                Offer = "0001-com-ubuntu-server-jammy",
                Sku = "22_04-lts",
                Version = "latest"
            };
            string nodeAgentSku = "batch.node.ubuntu 22.04";

            var batchAccountPoolData = new BatchAccountPoolData()
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
                },
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
                {
                    UserAssignedIdentities = {
            [new ResourceIdentifier("Your Identity Azure Resource Manager ResourceId")] = new Azure.ResourceManager.Models.UserAssignedIdentity(),
        },
                }
            };

            ArmOperation<BatchAccountPoolResource> armOperation = batchAccount.GetBatchAccountPools().CreateOrUpdate(
                WaitUntil.Completed, poolName, batchAccountPoolData);
            BatchAccountPoolResource pool = armOperation.Value;
            #endregion
        }

        public void BatchDeleteJobOperation()
        {
            #region Snippet:Batch_Migration_DeleteJob_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            DeleteJobOperation operation = batchClient.DeleteJob("jobID");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDeleteJob()
        {
            #region Snippet:Batch_Migration_DeleteJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteJob("jobID");
            #endregion
        }

        public void BatchReplaceJob()
        {
            #region Snippet:Batch_Migration_ReplaceJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJob job = batchClient.GetJob("jobID");
            job.AllTasksCompleteMode = BatchAllTasksCompleteMode.TerminateJob;
            batchClient.ReplaceJob("jobID", job);
            #endregion
        }

        public void BatchUpdateJob()
        {
            #region Snippet:Batch_Migration_UpdateJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobUpdateOptions batchUpdateOptions = new BatchJobUpdateOptions();
            batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

            batchClient.UpdateJob("jobID", batchUpdateOptions);
            #endregion
        }

        public void BatchDisableJobOperation()
        {
            #region Snippet:Batch_Migration_DisableJob_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobDisableOptions options = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
            DisableJobOperation operation = batchClient.DisableJob("jobID", options);

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDisableJob()
        {
            #region Snippet:Batch_Migration_DisableJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobDisableOptions options = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
            batchClient.DisableJob("jobID", options);
            #endregion
        }

        public void BatchEnableJob()
        {
            #region Snippet:Batch_Migration_EnableJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.EnableJob("jobID");
            #endregion
        }

        public void BatchEnableJobOperation()
        {
            #region Snippet:Batch_Migration_EnableJob_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            EnableJobOperation operation = batchClient.EnableJob("jobID");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchGetJobPreparationAndReleaseTaskStatuses()
        {
            #region Snippet:Batch_Migration_GetJobPreparationAndReleaseTaskStatuses
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchJobPreparationAndReleaseTaskStatus item in batchClient.GetJobPreparationAndReleaseTaskStatuses("jobID"))
            {
                // do something
            }
            #endregion
        }

        public void BatchGetJobTaskCounts()
        {
            #region Snippet:Batch_Migration_GetJobTaskCounts
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchTaskCountsResult batchTaskCountsResult = batchClient.GetJobTaskCounts("jobID");
            #endregion
        }

        public void BatchTerminateJobOperation()
        {
            #region Snippet:Batch_Migration_TerminateJob_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            TerminateJobOperation operation = batchClient.TerminateJob("jobID");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchTerminateJob()
        {
            #region Snippet:Batch_Migration_TerminateJob
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.TerminateJob("jobID");
            #endregion
        }

        public void BatchCreateJobSchedule()
        {
            #region Snippet:Batch_Migration_CreateJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration();

            BatchPoolInfo poolInfo = new BatchPoolInfo()
            {
                PoolId = "poolID",
            };
            BatchJobManagerTask batchJobManagerTask = new BatchJobManagerTask("task1", "cmd / c echo Hello World");

            BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo)
            {
                JobManagerTask = batchJobManagerTask,
            };

            BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions("jobScheduleId", schedule, jobSpecification);

            batchClient.CreateJobSchedule(jobSchedule);
            #endregion
        }

        public void BatchGetJobSchedule()
        {
            #region Snippet:Batch_Migration_GetJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");
            #endregion
        }

        public void BatchGetJobSchedules()
        {
            #region Snippet:Batch_Migration_GetJobSchedules
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchJobSchedule item in batchClient.GetJobSchedules())
            {
                // do something
            }
            #endregion
        }

        public void BatchDeleteJobScheduleOperation()
        {
            #region Snippet:Batch_Migration_DeleteJobSchedule_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            DeleteJobScheduleOperation operation = batchClient.DeleteJobSchedule("jobScheduleId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDeleteJobSchedule()
        {
            #region Snippet:Batch_Migration_DeleteJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteJobSchedule("jobScheduleId");
            #endregion
        }

        public void BatchReplaceJobSchedule()
        {
            #region Snippet:Batch_Migration_ReplaceJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");

            DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");
            batchJobSchedule.Schedule = new BatchJobScheduleConfiguration()
            {
                DoNotRunUntil = unboundDNRU,
            };
            batchClient.ReplaceJobSchedule("jobScheduleId", batchJobSchedule);
            #endregion
        }

        public void BatchUpdateJobSchedule()
        {
            #region Snippet:Batch_Migration_UpdateJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchJobScheduleUpdateOptions batchUpdateOptions = new BatchJobScheduleUpdateOptions();
            batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

            batchClient.UpdateJobSchedule("jobID", batchUpdateOptions);
            #endregion
        }

        public void BatchDisableJobSchedule()
        {
            #region Snippet:Batch_Migration_DisableJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DisableJobSchedule("jobScheduleId");
            #endregion
        }

        public void BatchEnableJobSchedule()
        {
            #region Snippet:Batch_Migration_EnableJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.EnableJobSchedule("jobScheduleId");
            #endregion
        }

        public void BatchTerminateJobScheduleOperation()
        {
            #region Snippet:Batch_Migration_TerminateJobSchedule_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            TerminateJobScheduleOperation operation = batchClient.TerminateJobSchedule("jobScheduleId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchTerminateJobSchedule()
        {
            #region Snippet:Batch_Migration_TerminateJobSchedule
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.TerminateJobSchedule("jobScheduleId");
            #endregion
        }

        public void BatchCreateTaskCollection()
        {
            #region Snippet:Batch_Migration_CreateTaskCollection
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchTaskGroup taskCollection = new BatchTaskGroup(
                new BatchTaskCreateOptions[]
                {
                    new BatchTaskCreateOptions("task1", "cmd / c echo Hello World"),
                    new BatchTaskCreateOptions("task2", "cmd / c echo Hello World")
                });

            BatchCreateTaskCollectionResult batchCreateTaskCollectionResult = batchClient.CreateTaskCollection("jobID", taskCollection);
            #endregion
        }

        public void BatchDeleteTask()
        {
            #region Snippet:Batch_Migration_DeleteTask
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteTask("jobId", "taskId");
            #endregion
        }

        public void BatchReplaceTask()
        {
            #region Snippet:Batch_Migration_ReplaceTask
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchTask task = batchClient.GetTask("jobId", "taskId");
            BatchTaskConstraints batchTaskConstraints = new BatchTaskConstraints()
            {
                MaxTaskRetryCount = 3,
            };

            task.Constraints = batchTaskConstraints;
            batchClient.ReplaceTask("jobID", "taskID", task);
            #endregion
        }

        public void BatchReactivateTask()
        {
            #region Snippet:Batch_Migration_ReactivateTask
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.ReactivateTask("jobID", "taskID");
            #endregion
        }

        public void BatchTerminateTask()
        {
            #region Snippet:Batch_Migration_TerminateTask
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.TerminateTask("jobID", "taskID");
            #endregion
        }

        public void BatchRebootNodeOperation()
        {
            #region Snippet:Batch_Migration_RebootNode_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            RebootNodeOperation operation = batchClient.RebootNode("poolId", "computeNodeId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchRebootNode()
        {
            #region Snippet:Batch_Migration_RebootNode
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.RebootNode("poolId", "computeNodeId");
            #endregion
        }

        public void BatchReimageNodeOperation()
        {
            #region Snippet:Batch_Migration_ReimageNode_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            ReimageNodeOperation operation = batchClient.ReimageNode("poolId", "computeNodeId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchReimageNode()
        {
            #region Snippet:Batch_Migration_ReimageNode
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            ReimageNodeOperation operation = batchClient.ReimageNode("poolId", "computeNodeId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchStartNodeOperation()
        {
            #region Snippet:Batch_Migration_StartNode_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            StartNodeOperation operation = batchClient.StartNode("poolId", "computeNodeId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchStartNode()
        {
            #region Snippet:Batch_Migration_StartNode
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.StartNode("poolId", "computeNodeId");
            #endregion
        }

        public void BatchDeallocateNodeOperation()
        {
            #region Snippet:Batch_Migration_DeallocateNode_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            DeallocateNodeOperation operation = batchClient.DeallocateNode("poolId", "computeNodeId");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDeallocateNode()
        {
            #region Snippet:Batch_Migration_DeallocateNode
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeallocateNode("poolId", "computeNodeId");
            #endregion
        }

        public void BatchCreateNodeUser()
        {
            #region Snippet:Batch_Migration_CreateNodeUser
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchNodeUserCreateOptions user = new BatchNodeUserCreateOptions("userName")
            {
                Password = "userPassWord"
            };
            batchClient.CreateNodeUser("poolID", "batchNodeID", user);
            #endregion
        }

        public void BatchDeleteNodeUser()
        {
            #region Snippet:Batch_Migration_DeleteNodeUser
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteNodeUser("poolID", "batchNodeID", "userName");
            #endregion
        }

        public void BatchGetNodeFile()
        {
            #region Snippet:Batch_Migration_GetNodeFile
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BinaryData fileContents = batchClient.GetNodeFile("poolId", "computeNodeId", "filePath");
            #endregion
        }

        public void BatchGetNodeFiles()
        {
            #region Snippet:Batch_Migration_GetNodeFiles
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchNodeFile item in batchClient.GetNodeFiles("jobId", "nodeId"))
            {
                // do something
            }
            #endregion
        }

        public void BatchDeleteNodeFile()
        {
            #region Snippet:Batch_Migration_DeleteNodeFile
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteNodeFile("jobId", "taskId", "filePath");
            #endregion
        }

        public void BatchGetNodeFileProperties()
        {
            #region Snippet:Batch_Migration_GetNodeFileProperties
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchFileProperties batchFileProperties = batchClient.GetNodeFileProperties("poolId", "nodeId", "filePath");
            #endregion
        }

        public void BatchGetNodeRemoteLoginSettings()
        {
            #region Snippet:Batch_Migration_GetNodeRemoteLoginSettings
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchNodeRemoteLoginSettings batchNodeRemoteLoginSettings = batchClient.GetNodeRemoteLoginSettings("poolId", "computeNodeId");
            #endregion
        }

        public void BatchUploadNodeLogs()
        {
            #region Snippet:Batch_Migration_UploadNodeLogs
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            UploadBatchServiceLogsOptions uploadBatchServiceLogsOptions = new UploadBatchServiceLogsOptions(new Uri("containerUrl"), DateTimeOffset.Parse("2026-05-01T00:00:00.0000000Z"));

            UploadBatchServiceLogsResult uploadBatchServiceLogsResult = batchClient.UploadNodeLogs("poolId", "computeNodeId", uploadBatchServiceLogsOptions);
            #endregion
        }

        public void BatchGetApplication()
        {
            #region Snippet:Batch_Migration_GetApplication
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchApplication application = batchClient.GetApplication("appID");
            #endregion
        }

        public void BatchGetApplications()
        {
            #region Snippet:Batch_Migration_GetApplications
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchApplication item in batchClient.GetApplications())
            {
                // do something
            }
            #endregion
        }

        public void BatchGetCertificate()
        {
            #region Snippet:Batch_Migration_GetCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            BatchCertificate cerCertificateResponse = batchClient.GetCertificate("ThumbprintAlgorithm", "Thumbprint");
            #endregion
        }

        public void BatchCreateCertificate()
        {
            #region Snippet:Batch_Migration_CreateCerCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
            byte[] certData = File.ReadAllBytes("certPath");
            BatchCertificate cerCertificate = new BatchCertificate("Thumbprint", "ThumbprintAlgorithm", BinaryData.FromBytes(certData))
            {
                CertificateFormat = BatchCertificateFormat.Cer,
                Password = "",
            };

            Response response = batchClient.CreateCertificate(cerCertificate);
            #endregion
        }

        public void BatchCreatePfxCerrtificate()
        {
            #region Snippet:Batch_Migration_CreatePfxCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            byte[] certData = File.ReadAllBytes("certPath");
            BatchCertificate cerCertificate = new BatchCertificate("Thumbprint", "ThumbprintAlgorithm", BinaryData.FromBytes(certData))
            {
                CertificateFormat = BatchCertificateFormat.Pfx,
                Password = "password",
            };

            Response response = batchClient.CreateCertificate(cerCertificate);
            #endregion
        }

        public void BatchListCerrtificate()
        {
            #region Snippet:Batch_Migration_ListCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            foreach (BatchCertificate item in batchClient.GetCertificates())
            {
                // do something
            }
            #endregion
        }

        public void BatchDeleteCerrtificateOperation()
        {
            #region Snippet:Batch_Migration_DeleteCertificate_Operation
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            DeleteCertificateOperation operation = batchClient.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");

            // Optional, wait for operation to complete
            operation.WaitForCompletion();
            #endregion
        }

        public void BatchDeleteCerrtificate()
        {
            #region Snippet:Batch_Migration_DeleteCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");
            #endregion
        }

        public void BatchCancelDeleteCerrtificate()
        {
            #region Snippet:Batch_Migration_CancelDeleteCertificate
            BatchClient batchClient = new BatchClient(
            new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

            batchClient.CancelCertificateDeletion("ThumbprintAlgorithm", "Thumbprint");
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Models = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Batch
{
    internal interface IProtocolLayer : IDisposable
    {
        Task<AzureOperationResponse<IPage<Models.CloudJobSchedule>, Models.JobScheduleListHeaders>> ListJobSchedules(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>> GetJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<bool, Models.JobScheduleExistsHeaders>> JobScheduleExists(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleAddHeaders>> AddJobSchedule(Models.JobScheduleAddParameter jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleUpdateHeaders>> UpdateJobSchedule(
            string jobScheduleId, 
            Models.JobSpecification jobSpecification, 
            IList<Models.MetadataItem> metadata, 
            Models.Schedule schedule, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobSchedulePatchHeaders>> PatchJobSchedule(
            string jobScheduleId, 
            Models.JobSpecification jobSpecification, 
            IList<Models.MetadataItem> metadata, 
            Models.Schedule schedule, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleEnableHeaders>> EnableJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleDisableHeaders>> DisableJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleTerminateHeaders>> TerminateJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobScheduleDeleteHeaders>> DeleteJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobAddHeaders>> AddJob(Models.JobAddParameter job, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListHeaders>> ListJobsAll(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListFromJobScheduleHeaders>> ListJobsBySchedule(
            string jobScheduleId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.JobPreparationAndReleaseTaskExecutionInformation>, Models.JobListPreparationAndReleaseTaskStatusHeaders>> ListJobPreparationAndReleaseTaskStatus(
            string jobId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>> GetJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.TaskCountsResult, Models.JobGetTaskCountsHeaders>> GetJobTaskCounts(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobPatchHeaders>> PatchJob(
            string jobId, 
            int? priority,
            int? maxParallelTasks,
            bool? allowTaskPreemption,
            Models.OnAllTasksComplete? onAllTasksComplete,
            Models.PoolInformation poolInfo, 
            Models.JobConstraints constraints,
            Models.JobNetworkConfiguration networkConfiguration,
            IList<Models.MetadataItem> metadata, 
            BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobUpdateHeaders>> UpdateJob(
            string jobId, 
            int? priority,
            Models.OnAllTasksComplete? onAllTasksComplete,
            Models.PoolInformation poolInfo, 
            Models.JobConstraints constraints,
            int? maxParallelTasks,
            bool? allowTaskPreemption,
            IList<Models.MetadataItem> metadata, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobEnableHeaders>> EnableJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobDisableHeaders>> DisableJob(string jobId, Common.DisableJobOption disableJobOption, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobTerminateHeaders>> TerminateJob(string jobId, string terminateReason, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.JobDeleteHeaders>> DeleteJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>> ListTasks(string jobId, string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>> GetTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromTaskHeaders>> ListNodeFilesByTask(
            string jobId,
            string taskId,
            bool? recursive,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.CloudTaskListSubtasksResult, Models.TaskListSubtasksHeaders>> ListSubtasks(
            string jobId,
            string taskId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.TaskAddHeaders>> AddTask(string jobId, Models.TaskAddParameter task, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.TaskTerminateHeaders>> TerminateTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.TaskDeleteHeaders>> DeleteTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.TaskReactivateHeaders>> ReactivateTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromTaskHeaders>> GetNodeFileByTask(
            string jobId,
            string taskId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromTaskHeaders>> GetNodeFilePropertiesByTask(string jobId, string taskId, string filePath, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>> ListPools(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.ImageInformation>, Models.AccountListSupportedImagesHeaders>> ListSupportedImages(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>> GetPool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<bool, Models.PoolExistsHeaders>> PoolExists(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolAddHeaders>> AddPool(Models.PoolAddParameter pool, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolUpdatePropertiesHeaders>> UpdatePool(
            string poolId,
            Models.StartTask startTask,
            Models.CertificateReference[] certRefs,
            Models.ApplicationPackageReference[] applicationPackageReferences,
            Models.MetadataItem[] metaData,
            Models.NodeCommunicationMode? targetNodeCommunicationMode,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolPatchHeaders>> PatchPool(
            string poolId,
            Models.StartTask startTask,
            Models.CertificateReference[] certificateReferences,
            Models.ApplicationPackageReference[] applicationPackageReferences,
            Models.MetadataItem[] metadata,
            Models.NodeCommunicationMode? targetNodeCommunicationMode,
            string displayName,
            string vmSize,
            int? taskSlotsPerNode,
            Models.TaskSchedulingPolicy taskSchedulingPolicy,
            bool? enableInterNodeCommunication,
            Models.VirtualMachineConfiguration virtualMachineConfiguration,
            Models.NetworkConfiguration networkConfiguration,
            IList<Models.UserAccount> userAccounts,
            IList<Models.MountConfiguration> mountConfiguration,
            Models.UpgradePolicy upgradePolicy,
            IDictionary<string, string> resourceTags,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolDeleteHeaders>> DeletePool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolResizeHeaders>> ResizePool(
            string poolId,
            int? targetDedicatedComputeNodes,
            int? targetLowPriorityComputeNodes,
            TimeSpan? resizeTimeout, 
            Common.ComputeNodeDeallocationOption? deallocationOption, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolStopResizeHeaders>> StopResizePool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolEnableAutoScaleHeaders>> EnableAutoScale(
            string poolId, 
            string autoscaleFormula, 
            TimeSpan? autoscaleEvaluationInterval, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolDisableAutoScaleHeaders>> DisableAutoScale(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.AutoScaleRun, Models.PoolEvaluateAutoScaleHeaders>> EvaluateAutoScale(string poolId, string autoscaleFomula, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>> ListComputeNodes(
            string poolId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.PoolRemoveNodesHeaders>> RemovePoolComputeNodes(
            string poolId, 
            IEnumerable<string> nodeIds, 
            Common.ComputeNodeDeallocationOption? deallocationOption, 
            TimeSpan? resizeTimeout, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeAddUserHeaders>> AddComputeNodeUser(
            string poolId, 
            string nodeId, 
            Models.ComputeNodeUser protoUser, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeUpdateUserHeaders>> UpdateComputeNodeUser(
            string poolId, 
            string nodeId, 
            string userName, 
            string password, 
            DateTime? expiryTime, 
            string sshPublicKey,
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeDeleteUserHeaders>> DeleteComputeNodeUser(string poolId, string nodeId, string userName, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.ComputeNodeGetRemoteLoginSettingsResult, Models.ComputeNodeGetRemoteLoginSettingsHeaders>> GetRemoteLoginSettings(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeRebootHeaders>> RebootComputeNode(string poolId, string nodeId, Common.ComputeNodeRebootOption? rebootOption, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeStartHeaders>> StartComputeNode(string poolId, string nodeId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeDeallocateHeaders>> DeallocateComputeNode(string poolId, string nodeId, Common.ComputeNodeDeallocateOption? deallocateOption, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeReimageHeaders>> ReimageComputeNode(string poolId, string nodeId, Common.ComputeNodeReimageOption? reimageOption, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.UploadBatchServiceLogsResult, Models.ComputeNodeUploadBatchServiceLogsHeaders>> UploadBatchServiceLogs(
            string poolId,
            string nodeId,
            string containerUrl,
            DateTime startTime,
            DateTime? endTime,
            ComputeNodeIdentityReference identityReference,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.FileDeleteFromTaskHeaders>> DeleteNodeFileByTask(string jobId, string taskId, string filePath, bool? recursive, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders>> GetComputeNode(string poolId, string nodeId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeEnableSchedulingHeaders>> EnableComputeNodeScheduling(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.ComputeNodeDisableSchedulingHeaders>> DisableComputeNodeScheduling(
            string poolId, 
            string computeNodeId,
            Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption, 
            BehaviorManager bhMgr, 
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.NodeVMExtension, Models.ComputeNodeExtensionGetHeaders>> GetComputeNodeExtension(string poolId, string nodeId, string extensionName, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>> ListComputeNodeExtensions(string poolId, string nodeId, string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.TaskUpdateHeaders>> UpdateTask(string jobId, string taskId, Models.TaskConstraints constraints, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.FileDeleteFromComputeNodeHeaders>> DeleteNodeFileByNode(string poolId, string nodeId, string filePath, bool? recursive, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromComputeNodeHeaders>> GetNodeFileByNode(
            string poolId,
            string nodeId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromComputeNodeHeaders>> GetNodeFilePropertiesByNode(string poolId, string nodeId, string filePath, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromComputeNodeHeaders>> ListNodeFilesByNode(
            string poolId,
            string nodeId,
            bool? recursive,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.Certificate, Models.CertificateGetHeaders>> GetCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.Certificate>, Models.CertificateListHeaders>> ListCertificates(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.CertificateAddHeaders>> AddCertificate(Models.CertificateAddParameter protoCert, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.CertificateDeleteHeaders>> DeleteCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationHeaderResponse<Models.CertificateCancelDeletionHeaders>> CancelDeleteCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.TaskAddCollectionResult, Models.TaskAddCollectionHeaders>> AddTaskCollection(string jobId, IEnumerable<Models.TaskAddParameter> tasks, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.PoolUsageMetrics>, Models.PoolListUsageMetricsHeaders>> ListPoolUsageMetrics(
            DateTime? startTime,
            DateTime? endTime,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.PoolNodeCounts>, Models.AccountListPoolNodeCountsHeaders>> ListPoolNodeCounts(
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken);

        Task<AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>> GetApplicationSummary(string applicationId, BehaviorManager bhMgr, CancellationToken cancellationToken);

        Task<AzureOperationResponse<IPage<Models.ApplicationSummary>, Models.ApplicationListHeaders>> ListApplicationSummaries(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken);
    }
} 

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Rest.Azure;
    using Protocol.BatchRequests;
    using Rest;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    internal class ProtocolLayer : IProtocolLayer
    {
        private Protocol.BatchServiceClient _client;
        private readonly bool _internalClient;

        private const int StreamCopyBufferSize = 4096; //This is the same as the default for Stream.CopyToAsync()

        private static Models.NodeFile CreateNodeFileFromHeadersType(string filePath, Models.IProtocolNodeFile protocolNodeFile)
        {
            Models.NodeFile file = new Models.NodeFile()
            {
                IsDirectory = protocolNodeFile.OcpBatchFileIsdirectory,
                Name = filePath,
                Properties = new Models.FileProperties()
                {
                    ContentLength = protocolNodeFile.ContentLength.GetValueOrDefault(),
                    ContentType = protocolNodeFile.ContentType,
                    CreationTime = protocolNodeFile.OcpCreationTime,
                    LastModified = protocolNodeFile.LastModified.GetValueOrDefault(),
                    FileMode = protocolNodeFile.OcpBatchFileMode
                },
                Url = protocolNodeFile.OcpBatchFileUrl
            };

            return file;
        }

        #region // constructors

        /// <summary>
        /// instantiate based on creds and base url
        /// </summary>
        internal ProtocolLayer(string baseUrl, ServiceClientCredentials credentials)
        {
            this._client = new Protocol.BatchServiceClient(credentials);
            this._client.BatchUrl = baseUrl;
            this._client.HttpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(InternalConstants.UserAgentProductName, typeof(ProtocolLayer).GetTypeInfo().Assembly.GetName().Version.ToString()));

            this._client.HttpClient.Timeout = Timeout.InfiniteTimeSpan; //Client side timeout will be set per-request
            this._client.SetRetryPolicy(null); //Set the retry policy to null to turn off inner-client retries
            this._internalClient = true;
        }

        /// <summary>
        /// instantiate based on customer provided rest proxy
        /// </summary>
        /// <param name="clientToUse"></param>
        internal ProtocolLayer(Protocol.BatchServiceClient clientToUse)
        {
            this._client = clientToUse;
            this._internalClient = false;
        }

        #endregion // constructors

        #region // IProtocolLayer

        public Task<AzureOperationResponse<IPage<Models.CloudJobSchedule>, Models.JobScheduleListHeaders>> ListJobSchedules(
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.CloudJobSchedule>, Models.JobScheduleListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new JobScheduleListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.ListWithHttpMessagesAsync(
                        request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new JobScheduleListNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>> GetJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.GetWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public async Task<AzureOperationResponse<bool, Models.JobScheduleExistsHeaders>> JobScheduleExists(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleExistsBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.ExistsWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            //Force disposal of the response because the HEAD request doesn't read the body stream, which leaves the connection open. Disposing forces a close of the connection
            using (var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false))
            {
                var result = new AzureOperationResponse<bool, Models.JobScheduleExistsHeaders>()
                {
                    Body = response.Body,
                    RequestId = response.RequestId,
                    Headers = response.Headers
                };

                return result;
            }
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleAddHeaders>> AddJobSchedule(Models.JobScheduleAddParameter cloudJobSchedule, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleAddBatchRequest(this._client, cloudJobSchedule, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.AddWithHttpMessagesAsync(
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleUpdateHeaders>> UpdateJobSchedule(
            string jobScheduleId,
            Models.JobSpecification jobSpecification,
            IList<Models.MetadataItem> metadata,
            Models.Schedule schedule,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.JobScheduleUpdateParameter(schedule, jobSpecification, metadata);
            var request = new JobScheduleUpdateBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.UpdateWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            Task<AzureOperationHeaderResponse<Models.JobScheduleUpdateHeaders>> asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobSchedulePatchHeaders>> PatchJobSchedule(
            string jobScheduleId,
            Models.JobSpecification jobSpecification,
            IList<Models.MetadataItem> metadata,
            Models.Schedule schedule,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.JobSchedulePatchParameter(schedule, jobSpecification, metadata);
            var request = new JobSchedulePatchBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.PatchWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleEnableHeaders>> EnableJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleEnableBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.EnableWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleDisableHeaders>> DisableJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleDisableBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.DisableWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleTerminateHeaders>> TerminateJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleTerminateBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.TerminateWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobScheduleDeleteHeaders>> DeleteJobSchedule(string jobScheduleId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobScheduleDeleteBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.JobSchedule.DeleteWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobAddHeaders>> AddJob(Models.JobAddParameter job, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobAddBatchRequest(this._client, job, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.AddWithHttpMessagesAsync(
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListHeaders>> ListJobsAll(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new JobListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListWithHttpMessagesAsync(
                        request.Options,
                        request.CustomHeaders,
                        lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new JobListNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListFromJobScheduleHeaders>> ListJobsBySchedule(
            string jobScheduleId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.CloudJob>, Models.JobListFromJobScheduleHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new JobListFromJobScheduleBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListFromJobScheduleWithHttpMessagesAsync(
                    jobScheduleId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new JobListFromJobScheduleNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListFromJobScheduleNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.JobPreparationAndReleaseTaskExecutionInformation>, Models.JobListPreparationAndReleaseTaskStatusHeaders>> ListJobPreparationAndReleaseTaskStatus(
            string jobId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.JobPreparationAndReleaseTaskExecutionInformation>, Models.JobListPreparationAndReleaseTaskStatusHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new JobListPreparationAndReleaseTaskStatusBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListPreparationAndReleaseTaskStatusWithHttpMessagesAsync(
                    jobId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new JobListPreparationAndReleaseTaskStatusNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.ListPreparationAndReleaseTaskStatusNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>> GetJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.GetWithHttpMessagesAsync(
                    jobId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.TaskCountsResult, Models.JobGetTaskCountsHeaders>> GetJobTaskCounts(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobGetTaskCountsBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.GetTaskCountsWithHttpMessagesAsync(
                jobId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobUpdateHeaders>> UpdateJob(
            string jobId,
            int? priority,
            Models.OnAllTasksComplete? onAllTasksComplete,
            Models.PoolInformation poolInfo,
            Models.JobConstraints constraints,
            int? maxParallelTasks,
            bool? allowTaskPreemption,
            IList<Models.MetadataItem> metadata,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.JobUpdateParameter(poolInfo, priority, maxParallelTasks, allowTaskPreemption, constraints, metadata, onAllTasksComplete);
            var request = new JobUpdateBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.UpdateWithHttpMessagesAsync(
                    jobId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobPatchHeaders>> PatchJob(
            string jobId,
            int? priority,
            int? maxParallelTasks,
            bool? allowTaskPreemption,
            Models.OnAllTasksComplete? onAllTasksComplete,
            Models.PoolInformation poolInfo,
            Models.JobConstraints constraints,
            Models.JobNetworkConfiguration networkConfiguration,
            IList<Models.MetadataItem> metadata,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.JobPatchParameter(priority, maxParallelTasks, allowTaskPreemption, onAllTasksComplete, constraints, poolInfo, networkConfiguration, metadata);
            var request = new JobPatchBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.PatchWithHttpMessagesAsync(
                    jobId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobEnableHeaders>> EnableJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobEnableBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.EnableWithHttpMessagesAsync(
                    jobId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobDisableHeaders>> DisableJob(string jobId, Common.DisableJobOption disableJobOption, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameter = UtilitiesInternal.MapEnum<Common.DisableJobOption, Protocol.Models.DisableJobOption>(disableJobOption);
            var request = new JobDisableBatchRequest(this._client, parameter, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.DisableWithHttpMessagesAsync(
                    jobId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobTerminateHeaders>> TerminateJob(string jobId, string terminateReason, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = terminateReason;
            var request = new JobTerminateBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.TerminateWithHttpMessagesAsync(
                    jobId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.JobDeleteHeaders>> DeleteJob(string jobId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new JobDeleteBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Job.DeleteWithHttpMessagesAsync(
                    jobId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>> ListTasks(string jobId, string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new TaskListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.ListWithHttpMessagesAsync(
                    jobId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new TaskListNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromTaskHeaders>> ListNodeFilesByTask(
            string jobId,
            string taskId,
            bool? recursive,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromTaskHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new FileListFromTaskBatchRequest(this._client, recursive, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.ListFromTaskWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new FileListFromTaskNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.ListFromTaskNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>> GetTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new TaskGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.GetWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.CloudTaskListSubtasksResult, Models.TaskListSubtasksHeaders>> ListSubtasks(
            string jobId,
            string taskId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<Models.CloudTaskListSubtasksResult, Models.TaskListSubtasksHeaders>> asyncTask;

            var request = new TaskListSubtasksBatchRequest(this._client, cancellationToken);

            bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.ListSubtasksWithHttpMessagesAsync(
                jobId,
                taskId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            //TODO: This branch exists in the hope that one day there will be a skiptoken for this API.
            //if (string.IsNullOrEmpty(skipToken))
            //{

            //}
            //else
            //{
            //    var request = new TaskListSubtasksNextBatchRequest(this._client, cancellationToken);
            //    request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.ListSubtasksNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomerHeaders, lambdaCancelToken);
            //    asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            //}

            return asyncTask;
        }

        // BUGBUG:  TODO:  fix this up with ranged GETs or whatever...
        public async Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromTaskHeaders>> GetNodeFileByTask(
            string jobId,
            string taskId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var request = new FileGetFromTaskBatchRequest(this._client, cancellationToken);

            if (byteRange != null)
            {
                request.Options.OcpRange = byteRange.GetOcpRangeHeader();
            }

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.GetFromTaskWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    filePath,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            await CopyStreamAsync(response.Body, stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = new AzureOperationResponse<Models.NodeFile, Models.FileGetFromTaskHeaders>()
            {
                Body = CreateNodeFileFromHeadersType(filePath, response.Headers),
                RequestId = response.RequestId,
                Headers = response.Headers,
            };

            return result;
        }

        public async Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromTaskHeaders>> GetNodeFilePropertiesByTask(
            string jobId,
            string taskId,
            string filePath,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var request = new FileGetNodeFilePropertiesFromTaskBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.GetPropertiesFromTaskWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    filePath,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            //Force disposal of the response because the HEAD request doesn't read the body stream, which leaves the connection open. Disposing forces a close of the connection
            using (var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false))
            {
                var result = new AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromTaskHeaders>()
                {
                    Body = CreateNodeFileFromHeadersType(filePath, response.Headers),
                    RequestId = response.RequestId,
                    Headers = response.Headers,
                };

                return result;
            }
        }

        public Task<AzureOperationHeaderResponse<Models.TaskAddHeaders>> AddTask(string jobId, Models.TaskAddParameter task, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new TaskAddBatchRequest(this._client, task, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.AddWithHttpMessagesAsync(
                    jobId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.TaskTerminateHeaders>> TerminateTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new TaskTerminateBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.TerminateWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.TaskDeleteHeaders>> DeleteTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new TaskDeleteBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.DeleteWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.TaskReactivateHeaders>> ReactivateTask(string jobId, string taskId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new TaskReactivateBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.ReactivateWithHttpMessagesAsync(
                    jobId,
                    taskId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }


        public Task<AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>> ListPools(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.CloudPool>, Models.PoolListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new PoolListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ListWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new PoolListNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>> GetPool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.GetWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public async Task<AzureOperationResponse<bool, Models.PoolExistsHeaders>> PoolExists(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolExistsBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ExistsWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            //Force disposal of the response because the HEAD request doesn't read the body stream, which leaves the connection open. Disposing forces a close of the connection
            using (var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false))
            {
                var result = new AzureOperationResponse<bool, Models.PoolExistsHeaders>()
                {
                    Body = response.Body,
                    RequestId = response.RequestId,
                    Headers = response.Headers
                };

                return result;
            }
        }

        public Task<AzureOperationHeaderResponse<Models.PoolAddHeaders>> AddPool(Models.PoolAddParameter pool, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolAddBatchRequest(this._client, pool, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.AddWithHttpMessagesAsync(
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolUpdatePropertiesHeaders>> UpdatePool(
            string poolId,
            Models.StartTask startTask,
            Models.CertificateReference[] certRefs,
            Models.ApplicationPackageReference[] applicationPackageReferences,
            Models.MetadataItem[] metaData,
            Models.NodeCommunicationMode? targetNodeCommunicationMode,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            // The REST API for UpdatePool for some reason requires mapping null to empty lists even though no other updates do
            // According to Pradeep this is fixed in OData 4
            certRefs = certRefs ?? new Models.CertificateReference[0];
            metaData = metaData ?? new Models.MetadataItem[0];
            applicationPackageReferences = applicationPackageReferences ?? new Models.ApplicationPackageReference[0];

            var parameters = new Models.PoolUpdatePropertiesParameter(certRefs, applicationPackageReferences, metaData, startTask, targetNodeCommunicationMode);
            var request = new PoolUpdatePropertiesBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.UpdatePropertiesWithHttpMessagesAsync(
                    poolId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolPatchHeaders>> PatchPool(
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
            CancellationToken cancellationToken)
        {
            var parameters = new Models.PoolPatchParameter(startTask, certificateReferences, applicationPackageReferences, metadata, targetNodeCommunicationMode, displayName,
            vmSize, taskSlotsPerNode, taskSchedulingPolicy, enableInterNodeCommunication, virtualMachineConfiguration, networkConfiguration, userAccounts, mountConfiguration,
            upgradePolicy, resourceTags);
            var request = new PoolPatchBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.PatchWithHttpMessagesAsync(
                    poolId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolDeleteHeaders>> DeletePool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolDeleteBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.DeleteWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolResizeHeaders>> ResizePool(
            string poolId,
            int? targetDedicatedComputeNodes,
            int? targetLowPriorityComputeNodes,
            TimeSpan? resizeTimeout,
            Common.ComputeNodeDeallocationOption? deallocationOption,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.PoolResizeParameter(
                targetDedicatedComputeNodes,
                targetLowPriorityComputeNodes,
                resizeTimeout,
                UtilitiesInternal.MapNullableEnum<Common.ComputeNodeDeallocationOption, Protocol.Models.ComputeNodeDeallocationOption>(deallocationOption));

            var request = new PoolResizeBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ResizeWithHttpMessagesAsync(
                    poolId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolStopResizeHeaders>> StopResizePool(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolStopResizeBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.StopResizeWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolEnableAutoScaleHeaders>> EnableAutoScale(
            string poolId,
            string autoscaleFormula,
            TimeSpan? autoscaleEvaluationInterval,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.PoolEnableAutoScaleParameter(autoscaleFormula, autoscaleEvaluationInterval);
            var request = new PoolEnableAutoScaleBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.EnableAutoScaleWithHttpMessagesAsync(
                    poolId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolDisableAutoScaleHeaders>> DisableAutoScale(string poolId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new PoolDisableAutoScaleBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.DisableAutoScaleWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.AutoScaleRun, Models.PoolEvaluateAutoScaleHeaders>> EvaluateAutoScale(string poolId, string autoscaleFomula, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = autoscaleFomula;
            var request = new PoolEvaluateAutoScaleBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.EvaluateAutoScaleWithHttpMessagesAsync(
                    poolId,
                    autoscaleFomula,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>> ListComputeNodes(
            string poolId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.ComputeNode>, Models.ComputeNodeListHeaders>> asyncTask;


            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new ComputeNodeListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.ListWithHttpMessagesAsync(
                    poolId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new ComputeNodeListNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.PoolRemoveNodesHeaders>> RemovePoolComputeNodes(
            string poolId,
            IEnumerable<string> computeNodeIds,
            Common.ComputeNodeDeallocationOption? deallocationOption,
            TimeSpan? resizeTimeout,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            //TODO: Ideally we wouldn't have to do this ToList stuff
            List<string> computeNodeIdList = computeNodeIds == null ? null : computeNodeIds.ToList();
            var parameters = new Models.NodeRemoveParameter(
                computeNodeIdList,
                resizeTimeout,
                UtilitiesInternal.MapNullableEnum<Common.ComputeNodeDeallocationOption, Protocol.Models.ComputeNodeDeallocationOption>(deallocationOption));

            var request = new PoolRemoveNodesBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.RemoveNodesWithHttpMessagesAsync(
                poolId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeAddUserHeaders>> AddComputeNodeUser(string poolId, string computeNodeId, Models.ComputeNodeUser protoUser, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeAddUserBatchRequest(this._client, protoUser, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.AddUserWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeUpdateUserHeaders>> UpdateComputeNodeUser(
            string poolId,
            string computeNodeId,
            string userName,
            string password,
            DateTime? expiryTime,
            string sshPublicKey,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var parameters = new Models.NodeUpdateUserParameter(password, expiryTime, sshPublicKey);

            var request = new ComputeNodeUpdateUserBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.UpdateUserWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                userName,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeDeleteUserHeaders>> DeleteComputeNodeUser(string poolId, string computeNodeId, string userName, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeDeleteUserBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.DeleteUserWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                userName,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.UploadBatchServiceLogsResult, Models.ComputeNodeUploadBatchServiceLogsHeaders>> UploadBatchServiceLogs(
            string poolId,
            string nodeId,
            string containerUrl,
            DateTime startTime,
            DateTime? endTime,
            ComputeNodeIdentityReference identityReference,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var identityRefModel = identityReference != null ? new Models.ComputeNodeIdentityReference(identityReference.ResourceId) : null;

            var parameters = new Models.UploadBatchServiceLogsConfiguration(containerUrl, startTime, endTime, identityRefModel);
            var request = new ComputeNodeUploadBatchServiceLogsBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.UploadBatchServiceLogsWithHttpMessagesAsync(
                poolId,
                nodeId,
                parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.ComputeNodeGetRemoteLoginSettingsResult, Models.ComputeNodeGetRemoteLoginSettingsHeaders>> GetRemoteLoginSettings(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeGetRemoteLoginSettingsBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.GetRemoteLoginSettingsWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeRebootHeaders>> RebootComputeNode(string poolId, string computeNodeId, Common.ComputeNodeRebootOption? rebootOption, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = UtilitiesInternal.MapNullableEnum<Common.ComputeNodeRebootOption, Protocol.Models.ComputeNodeRebootOption>(rebootOption);
            var request = new ComputeNodeRebootBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.RebootWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeStartHeaders>> StartComputeNode(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeStartBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.StartWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeDeallocateHeaders>> DeallocateComputeNode(string poolId, string computeNodeId, Common.ComputeNodeDeallocateOption? deallocateOption, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = UtilitiesInternal.MapNullableEnum<Common.ComputeNodeDeallocateOption, Protocol.Models.ComputeNodeDeallocateOption>(deallocateOption);
            var request = new ComputeNodeDeallocateBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.DeallocateWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeReimageHeaders>> ReimageComputeNode(string poolId, string computeNodeId, Common.ComputeNodeReimageOption? reimageOption, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = UtilitiesInternal.MapNullableEnum<Common.ComputeNodeReimageOption, Protocol.Models.ComputeNodeReimageOption>(reimageOption);
            var request = new ComputeNodeReimageBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.ReimageWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.FileDeleteFromTaskHeaders>> DeleteNodeFileByTask(string jobId, string taskId, string filePath, bool? recursive, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new FileDeleteFromTaskBatchRequest(this._client, recursive, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.DeleteFromTaskWithHttpMessagesAsync(
                jobId,
                taskId,
                filePath,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.ComputeNode, Models.ComputeNodeGetHeaders>> GetComputeNode(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.GetWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeEnableSchedulingHeaders>> EnableComputeNodeScheduling(string poolId, string computeNodeId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeEnableSchedulingBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.EnableSchedulingWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.ComputeNodeDisableSchedulingHeaders>> DisableComputeNodeScheduling(string poolId, string computeNodeId, Common.DisableComputeNodeSchedulingOption? disableComputeNodeSchedulingOption, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = UtilitiesInternal.MapNullableEnum<Common.DisableComputeNodeSchedulingOption, Models.DisableComputeNodeSchedulingOption>(disableComputeNodeSchedulingOption);

            var request = new ComputeNodeDisableSchedulingBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNode.DisableSchedulingWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.NodeVMExtension, Models.ComputeNodeExtensionGetHeaders>> GetComputeNodeExtension(string poolId, string nodeId, string extensionName, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ComputeNodeExtensionGetBatchRequest(_client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNodeExtension.GetWithHttpMessagesAsync(
                poolId,
                nodeId,
                extensionName,
                request.Options,
                request.CustomHeaders,
                cancellationToken
            );

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>> ListComputeNodeExtensions(
            string poolId,
            string computeNodeId,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.NodeVMExtension>, Models.ComputeNodeExtensionListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new ComputeNodeExtensionListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNodeExtension.ListWithHttpMessagesAsync(
                    poolId,
                    computeNodeId,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new ComputeNodeExtensionListNextBatchRequest(_client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.ComputeNodeExtension.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.TaskUpdateHeaders>> UpdateTask(string jobId, string taskId, Models.TaskConstraints taskConstraints, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var parameters = taskConstraints;
            var request = new TaskUpdateBatchRequest(this._client, parameters, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.UpdateWithHttpMessagesAsync(
                jobId,
                taskId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationHeaderResponse<Models.FileDeleteFromComputeNodeHeaders>> DeleteNodeFileByNode(string poolId, string computeNodeId, string filePath, bool? recursive, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new FileDeleteFromComputeNodeBatchRequest(this._client, recursive, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.DeleteFromComputeNodeWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                filePath,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        // BUGBUG:  TODO:  fix this up with ranged GETs or whatever...
        public async Task<AzureOperationResponse<Models.NodeFile, Models.FileGetFromComputeNodeHeaders>> GetNodeFileByNode(
            string poolId,
            string computeNodeId,
            string filePath,
            Stream stream,
            GetFileRequestByteRange byteRange,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var request = new FileGetFromComputeNodeBatchRequest(this._client, cancellationToken);

            if (byteRange != null)
            {
                request.Options.OcpRange = byteRange.GetOcpRangeHeader();
            }

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.GetFromComputeNodeWithHttpMessagesAsync(
                    poolId,
                    computeNodeId,
                    filePath,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false);

            await CopyStreamAsync(response.Body, stream, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);

            var result = new AzureOperationResponse<Models.NodeFile, Models.FileGetFromComputeNodeHeaders>()
            {
                Body = CreateNodeFileFromHeadersType(filePath, response.Headers),
                RequestId = response.RequestId,
                Headers = response.Headers
            };

            return result;
        }

        public async Task<AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromComputeNodeHeaders>> GetNodeFilePropertiesByNode(
            string poolId,
            string computeNodeId,
            string filePath,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var request = new FileGetNodeFilePropertiesFromComputeNodeBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.GetPropertiesFromComputeNodeWithHttpMessagesAsync(
                poolId,
                computeNodeId,
                filePath,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            //Force disposal of the response because the HEAD request doesn't read the body stream, which leaves the connection open. Disposing forces a close of the connection
            using (var response = await asyncTask.ConfigureAwait(continueOnCapturedContext: false))
            {
                var result = new AzureOperationResponse<Models.NodeFile, Models.FileGetPropertiesFromComputeNodeHeaders>()
                {
                    Body = CreateNodeFileFromHeadersType(filePath, response.Headers),
                    RequestId = response.RequestId,
                    Headers = response.Headers
                };

                return result;
            }
        }

        public Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromComputeNodeHeaders>> ListNodeFilesByNode(
            string poolId,
            string computeNodeId,
            bool? recursive,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.NodeFile>, Models.FileListFromComputeNodeHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new FileListFromComputeNodeBatchRequest(this._client, recursive, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.ListFromComputeNodeWithHttpMessagesAsync(
                    poolId,
                    computeNodeId,
                    request.Parameters,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new FileListFromComputeNodeNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.File.ListFromComputeNodeNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);
                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        [Obsolete("This operation is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.", false)]
        public Task<AzureOperationResponse<Models.Certificate, Models.CertificateGetHeaders>> GetCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new CertificateGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.GetWithHttpMessagesAsync(
                thumbprintAlgorithm,
                thumbprint,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.PoolUsageMetrics>, Models.PoolListUsageMetricsHeaders>> ListPoolUsageMetrics(
            DateTime? startTime,
            DateTime? endTime,
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.PoolUsageMetrics>, Models.PoolListUsageMetricsHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new PoolListPoolUsageMetricsBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.Options.StartTime = startTime;
                request.Options.EndTime = endTime;

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ListUsageMetricsWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new PoolListPoolUsageMetricsNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Pool.ListUsageMetricsNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.ImageInformation>, Models.AccountListSupportedImagesHeaders>> ListSupportedImages(
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.ImageInformation>, Models.AccountListSupportedImagesHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new AccountListSupportedImagesBatchRequest(this._client, cancellationToken);

                if (request.Options == null)
                {
                    request.Options = new Models.AccountListSupportedImagesOptions();
                }

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Account.ListSupportedImagesWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new AccountListSupportedImagesNextBatchRequest(this._client, cancellationToken);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Account.ListSupportedImagesNextWithHttpMessagesAsync(
                    skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        [Obsolete("This operation is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.", false)]
        public Task<AzureOperationResponse<IPage<Models.Certificate>, Models.CertificateListHeaders>> ListCertificates(string skipToken, BehaviorManager bhMgr, DetailLevel detailLevel, CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.Certificate>, Models.CertificateListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new CertificateListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.ListWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new CertificateListNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        [Obsolete("This operation is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.", false)]
        public Task<AzureOperationHeaderResponse<Models.CertificateAddHeaders>> AddCertificate(Models.CertificateAddParameter protoCert, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new CertificateAddBatchRequest(this._client, protoCert, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.AddWithHttpMessagesAsync(
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        [Obsolete("This operation is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.", false)]
        public Task<AzureOperationHeaderResponse<Models.CertificateDeleteHeaders>> DeleteCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new CertificateDeleteBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.DeleteWithHttpMessagesAsync(
                thumbprintAlgorithm,
                thumbprint,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        [Obsolete("This operation is deprecated and will be removed after February, 2024. Please use the Azure KeyVault Extension instead.", false)]
        public Task<AzureOperationHeaderResponse<Models.CertificateCancelDeletionHeaders>> CancelDeleteCertificate(string thumbprintAlgorithm, string thumbprint, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new CertificateCancelDeletionBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Certificate.CancelDeletionWithHttpMessagesAsync(
                thumbprintAlgorithm,
                thumbprint,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.TaskAddCollectionResult, Models.TaskAddCollectionHeaders>> AddTaskCollection(
            string jobId,
            IEnumerable<Models.TaskAddParameter> tasks,
            BehaviorManager bhMgr,
            CancellationToken cancellationToken)
        {
            var request = new TaskAddCollectionBatchRequest(this._client, tasks.ToList(), cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Task.AddCollectionWithHttpMessagesAsync(
                jobId,
                request.Parameters,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<Models.ApplicationSummary, Models.ApplicationGetHeaders>> GetApplicationSummary(string applicationId, BehaviorManager bhMgr, CancellationToken cancellationToken)
        {
            var request = new ApplicationGetBatchRequest(this._client, cancellationToken);

            request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Application.GetWithHttpMessagesAsync(
                applicationId,
                request.Options,
                request.CustomHeaders,
                lambdaCancelToken);

            var asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.ApplicationSummary>, Models.ApplicationListHeaders>> ListApplicationSummaries(
            string skipToken,
            BehaviorManager bhMgr,
            DetailLevel detailLevel,
            CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.ApplicationSummary>, Models.ApplicationListHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new ApplicationListBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Application.ListWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new ApplicationListNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Application.ListNextWithHttpMessagesAsync(skipToken, request.Options, request.CustomHeaders, lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        public Task<AzureOperationResponse<IPage<Models.PoolNodeCounts>, Models.AccountListPoolNodeCountsHeaders>> ListPoolNodeCounts(
                string skipToken,
                BehaviorManager bhMgr,
                DetailLevel detailLevel,
                CancellationToken cancellationToken)
        {
            Task<AzureOperationResponse<IPage<Models.PoolNodeCounts>, Models.AccountListPoolNodeCountsHeaders>> asyncTask;

            if (string.IsNullOrEmpty(skipToken))
            {
                var request = new AccountListPoolNodeCountsBatchRequest(this._client, cancellationToken);

                bhMgr = bhMgr.CreateBehaviorManagerWithDetailLevel(detailLevel);

                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Account.ListPoolNodeCountsWithHttpMessagesAsync(
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }
            else
            {
                var request = new AccountListPoolNodeCountsNextBatchRequest(this._client, cancellationToken);
                request.ServiceRequestFunc = (lambdaCancelToken) => request.RestClient.Account.ListPoolNodeCountsNextWithHttpMessagesAsync(
                    skipToken,
                    request.Options,
                    request.CustomHeaders,
                    lambdaCancelToken);

                asyncTask = ProcessAndExecuteBatchRequest(request, bhMgr);
            }

            return asyncTask;
        }

        #endregion // IProtocolLayer

        #region // internal/private

        private static async Task CopyStreamAsync(Stream inputStream, Stream outputStream, CancellationToken cancellationToken)
        {
            //Copy the stream to the target stream and dispose of it
            using (Stream responseStream = inputStream)
            {
                await responseStream.CopyToAsync(outputStream, StreamCopyBufferSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Applies and executes the RequestInterceptors found in behaviors collection.
        /// </summary>
        /// <returns></returns>
        private static void ExecuteRequestInterceptors<TResponse>(IBatchRequest<TResponse> request, IEnumerable<BatchClientBehavior> behaviors)
            where TResponse : class, IAzureOperationResponse
        {
            if (null != behaviors)
            {
                foreach (BatchClientBehavior curBehavior in behaviors)
                {
                    Protocol.RequestReplacementInterceptor replacementIntercept = curBehavior as Protocol.RequestReplacementInterceptor;

                    if (null != replacementIntercept)
                    {
                        IBatchRequest proxyObj = request;

                        // call the delegate and let custom code modify/replace the context and/or the request
                        replacementIntercept.ReplacementInterceptHandler(ref proxyObj);

                        // enforce that the returned object is the required type
                        ValidateReturnObject(request, typeof(IBatchRequest<TResponse>));

                        // any changes must be communicated back to the caller
                        request = (Protocol.IBatchRequest<TResponse>)proxyObj;
                    }
                }
            }
        }

        private static async Task<TResponse> ExecuteResponseInterceptors<TResponse>(
                TResponse originalResponse,
                Protocol.IBatchRequest<TResponse> request,
                IEnumerable<BatchClientBehavior> behaviors)
            where TResponse : class, IAzureOperationResponse
        {
            // now we have a response... maybe there are response interceptors?
            List<Protocol.ResponseInterceptor> allRespInterceptors = new List<Protocol.ResponseInterceptor>();

            // filter out the response interceptors
            foreach (BatchClientBehavior curBehavior in behaviors)
            {
                Protocol.ResponseInterceptor realRespIntr = curBehavior as Protocol.ResponseInterceptor;

                if (null != realRespIntr)
                {
                    allRespInterceptors.Add(realRespIntr);
                }
            }

            // start with original response and daisy-chain through interceptors
            TResponse response = originalResponse;

            // if there are any interceptors
            if (null != allRespInterceptors)
            {
                // call each response interceptor
                foreach (Protocol.ResponseInterceptor curRespInter in allRespInterceptors)
                {
                    // start next interceptor
                    Task<IAzureOperationResponse> fromIntercept = curRespInter.ResponseInterceptHandler(response, request);

                    // let interceptor complete
                    IAzureOperationResponse responseFromIntercept = await fromIntercept.ConfigureAwait(continueOnCapturedContext: false);

                    // enforce that the returned object is the required type
                    ValidateReturnObject(responseFromIntercept, typeof(TResponse));

                    // promote the interceptor response to official response
                    response = (TResponse)responseFromIntercept;
                }
            }

            // return possibly intercepted response
            return response;
        }

        /// <summary>
        /// Process and executes a BatchRequest.
        /// </summary>
        private static async Task<TResponse> ProcessAndExecuteBatchRequest<TResponse>(IBatchRequest<TResponse> request, BehaviorManager bhMgr)
            where TResponse : class, IAzureOperationResponse
        {
            // finalize the behaviors and get the master list
            IEnumerable<BatchClientBehavior> behaviors = bhMgr.MasterListOfBehaviors;

            ExecuteRequestInterceptors(request, behaviors);

            // at this point, the batch service call has not yet been started.
            // this means that the delegate in the request has not yet been called.

            //Execute the batch request
            Task<TResponse> requestTask = request.ExecuteRequestAsync();

            // wait for call to complete
            TResponse response = await requestTask.ConfigureAwait(continueOnCapturedContext: false);

            // execute the response interceptors
            Task<TResponse> finalResponseTask = ExecuteResponseInterceptors(response, request, behaviors);

            // wait for response interceptors
            TResponse finalResponse = await finalResponseTask.ConfigureAwait(continueOnCapturedContext: false);

            // return final result to caller
            return finalResponse;
        }

        /// <summary>
        /// Common validation that will throw if an incorrect instance is returned by a custom behavior.
        /// </summary>
        /// <param name="proxyObj"></param>
        /// <param name="expectedType"></param>
        private static void ValidateReturnObject(object proxyObj, Type expectedType)
        {
            // test that the returned value has the correct type
            if (!expectedType.GetTypeInfo().IsAssignableFrom(proxyObj.GetType().GetTypeInfo()))
            {
                Exception ex = UtilitiesInternal.IncorrectTypeReturned;

                throw ex;
            }
        }

        #endregion // internal/private

        #region // IDisposable

        /// <summary>
        /// A value indicating whether or not the ServiceClient has already
        /// been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Dispose the ProtocolLayer class. This function is not thread-safe.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
            {
                return;
            }

            if (disposing && this._internalClient)
            {
                this._client.Dispose();
            }

            this._client = null;
            this._disposed = true;
        }

        #endregion // IDisposable
    }
}
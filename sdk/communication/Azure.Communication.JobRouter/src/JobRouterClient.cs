﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

 namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// The Azure Communication Services Router client.
    /// </summary>
    public class JobRouterClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal JobRouterRestClient RestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="JobRouterClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public JobRouterClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterClient(string connectionString, JobRouterClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterClient(Uri endpoint, AzureKeyCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterClient(Uri endpoint, TokenCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        #endregion

        #region private constructors

        private JobRouterClient(ConnectionString connectionString, JobRouterClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private JobRouterClient(string endpoint, TokenCredential tokenCredential, JobRouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private JobRouterClient(string endpoint, AzureKeyCredential keyCredential, JobRouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private JobRouterClient(string endpoint, HttpPipeline httpPipeline, JobRouterClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new JobRouterRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="JobRouterClient"/> for mocking.</summary>
        protected JobRouterClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        #endregion

        #region Job

        #region Create job with classification policy

        /// <summary> Creates a new job to be routed with classification property. </summary>
        /// <param name="options"> Options for creating job with classification properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> CreateJobWithClassificationPolicyAsync(
            CreateJobWithClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new RouterJob
                {
                    ChannelId = options.ChannelId,
                    ClassificationPolicyId = options.ClassificationPolicyId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return await RestClient.UpsertJobAsync(
                        id:options.JobId,
                        patch: request,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new job to be routed with classification property. </summary>
        /// <param name="options"> Options for creating job with classification properties. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> CreateJobWithClassificationPolicy(
            CreateJobWithClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new RouterJob
                {
                    ChannelId = options.ChannelId,
                    ClassificationPolicyId = options.ClassificationPolicyId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return RestClient.UpsertJob(
                    id:options.JobId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create job with classification policy

        #region Create job with direct queue assignment

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="options"> Options for creating job with direct queue assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> CreateJobAsync(
            CreateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob
                {
                    ChannelId = options.ChannelId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return await RestClient.UpsertJobAsync(
                        id: options.JobId,
                        patch: request,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="options"> Options for creating job with direct queue assignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> CreateJob(
            CreateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob
                {
                    ChannelId = options.ChannelId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return RestClient.UpsertJob(
                    id: options.JobId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create job with direct queue assignment

        /// <summary> Update an existing job. </summary>
        /// <param name="options"> Options for updating a job. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> UpdateJobAsync(
            UpdateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob                {
                    ChannelId = options.ChannelId,
                    ClassificationPolicyId = options.ClassificationPolicyId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    DispositionCode = options.DispositionCode,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return await RestClient.UpsertJobAsync(
                        id: options.JobId,
                        patch: request,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update an existing job. </summary>
        /// <param name="options"> Options for updating a job. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> UpdateJob(
            UpdateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob
                {
                    ChannelId = options.ChannelId,
                    ClassificationPolicyId = options.ClassificationPolicyId,
                    ChannelReference = options.ChannelReference,
                    QueueId = options.QueueId,
                    Priority = options.Priority,
                    DispositionCode = options.DispositionCode,
                    MatchingMode = options.MatchingMode,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var workerSelector in options.RequestedWorkerSelectors)
                {
                    request.RequestedWorkerSelectors.Add(workerSelector);
                }

                foreach (var note in options.Notes)
                {
                    request.Notes.Add(note);
                }

                return RestClient.UpsertJob(
                    id: options.JobId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateJobAsync(
            string jobId,
            RequestContent content,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertJobAsync(
                        id: jobId,
                        content: content,
                        context: context)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from job. </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateJob(
            string jobId,
            RequestContent content,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                return RestClient.UpsertJob(
                    id: jobId,
                    content: content,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing job by Id. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = await RestClient.GetJobAsync(jobId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(job.Value, job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing job by Id. </summary>
        /// <param name="jobId"> The Id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> GetJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = RestClient.GetJob(jobId, cancellationToken);
                return Response.FromValue(job.Value, job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Reclassify a job. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ReclassifyJobResult>> ReclassifyJobAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.ReclassifyJobActionAsync(
                    id: jobId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ReclassifyJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Reclassify a job. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ReclassifyJobResult> ReclassifyJob(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var response = RestClient.ReclassifyJobAction(
                    id: jobId,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new ReclassifyJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="options"> Options for cancelling a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CancelJobResult>> CancelJobAsync(
            CancelJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.CancelJobActionAsync(
                        id: options.JobId,
                        note: options.Note,
                        dispositionCode: options.DispositionCode,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(new CancelJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="options"> Options for cancelling a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CancelJobResult> CancelJob(
            CancelJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CancelJobAction(
                    id: options.JobId,
                    note: options.Note,
                    dispositionCode: options.DispositionCode,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new CancelJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="options"> Options for completing a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CompleteJobResult>> CompleteJobAsync(
            CompleteJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.CompleteJobActionAsync(
                        id: options.JobId,
                        assignmentId: options.AssignmentId,
                        note: options.Note,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(new CompleteJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="options"> Options for completing a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CompleteJobResult> CompleteJob(
            CompleteJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CompleteJobAction(
                    id: options.JobId,
                    assignmentId: options.AssignmentId,
                    note: options.Note,
                    cancellationToken: cancellationToken);

                return Response.FromValue(new CompleteJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="options"> Options for closing a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CloseJobResult>> CloseJobAsync(
            CloseJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.CloseJobActionAsync(
                        id: options.JobId,
                        assignmentId: options.AssignmentId,
                        dispositionCode: options.DispositionCode,
                        closeAt: options.CloseAt,
                        note: options.Note,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(new CloseJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="options"> Options for closing a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CloseJobResult> CloseJob(
            CloseJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CloseJobAction(
                    id: options.JobId,
                    assignmentId: options.AssignmentId,
                    dispositionCode: options.DispositionCode,
                    closeAt: options.CloseAt,
                    note: options.Note,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new CloseJobResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="options"> Options for filter while retrieving jobs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterJobItem> GetJobsAsync(
            GetJobsOptions options = default,
            CancellationToken cancellationToken = default)
        {
            async Task<Page<RouterJobItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<RouterJobCollection> response = await RestClient.ListJobsAsync(
                            status: options?.Status,
                            queueId: options?.QueueId,
                            channelId: options?.ChannelId,
                            classificationPolicyId: options?.ClassificationPolicyId,
                            scheduledBefore: options?.ScheduledBefore,
                            scheduledAfter: options?.ScheduledAfter,
                            maxpagesize: maxPageSize,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterJobItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<RouterJobCollection> response = await RestClient
                        .ListJobsNextPageAsync(
                            nextLink: nextLink,
                            status: options?.Status,
                            queueId: options?.QueueId,
                            channelId: options?.ChannelId,
                            classificationPolicyId: options?.ClassificationPolicyId,
                            scheduledBefore: options?.ScheduledBefore,
                            scheduledAfter: options?.ScheduledAfter,
                            maxpagesize: maxPageSize,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="options"> Options for filter while retrieving jobs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterJobItem> GetJobs(
            GetJobsOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Page<RouterJobItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<RouterJobCollection> response = RestClient.ListJobs(
                        status: options?.Status,
                        queueId: options?.QueueId,
                        channelId: options?.ChannelId,
                        classificationPolicyId: options?.ClassificationPolicyId,
                        scheduledBefore: options?.ScheduledBefore,
                        scheduledAfter: options?.ScheduledAfter,
                        maxpagesize: maxPageSize,
                        cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterJobItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<RouterJobCollection> response = RestClient
                        .ListJobsNextPage(
                            nextLink: nextLink,
                            status: options?.Status,
                            queueId: options?.QueueId,
                            channelId: options?.ChannelId,
                            classificationPolicyId: options?.ClassificationPolicyId,
                            scheduledBefore: options?.ScheduledBefore,
                            scheduledAfter: options?.ScheduledAfter,
                            maxpagesize: maxPageSize,
                            cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets a jobs position details. </summary>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<Models.RouterJobPositionDetails>> GetQueuePositionAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueuePosition)}");
            scope.Start();
            try
            {
                Response<Models.RouterJobPositionDetails> job = await RestClient.GetInQueuePositionAsync(jobId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(job.Value, job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a jobs position details. </summary>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<Models.RouterJobPositionDetails> GetQueuePosition(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueuePosition)}");
            scope.Start();
            try
            {
                Response<Models.RouterJobPositionDetails> job = RestClient.GetInQueuePosition(jobId, cancellationToken);
                return Response.FromValue(job.Value, job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a job and all of its traces. </summary>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeleteJob)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteJobAsync(id: jobId, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a job and all of its traces. </summary>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeleteJob)}");
            scope.Start();
            try
            {
                return RestClient.DeleteJob(id: jobId, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Job

        #region Offer

        /// <summary> Accepts an offer to work on a job and returns a 409/Conflict if another agent accepted the job already. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="offerId"> The Id of the Job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="offerId"/> or <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<AcceptJobOfferResult>> AcceptJobOfferAsync(
            string workerId,
            string offerId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(AcceptJobOffer)}");
            scope.Start();
            try
            {
                var response = await RestClient.AcceptJobActionAsync(
                        workerId: workerId,
                        offerId: offerId,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Accepts an offer to work on a job and returns a 409/Conflict if another agent accepted the job already. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="offerId"> The Id of the Job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="offerId"/> or <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<AcceptJobOfferResult> AcceptJobOffer(
            string workerId,
            string offerId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(AcceptJobOffer)}");
            scope.Start();
            try
            {
                var response = RestClient.AcceptJobAction(
                    workerId: workerId,
                    offerId: offerId,
                    cancellationToken: cancellationToken);

                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="options"> The options for declining a job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DeclineJobOfferResult>> DeclineJobOfferAsync(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                var response = await RestClient.DeclineJobActionAsync(
                        workerId: options.WorkerId,
                        offerId: options.OfferId,
                        declineJobOfferRequest: new DeclineJobOfferRequest { RetryOfferAt = options.RetryOfferAt },
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(new DeclineJobOfferResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="options"> The options for declining a job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DeclineJobOfferResult> DeclineJobOffer(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                var response = RestClient.DeclineJobAction(
                    workerId: options.WorkerId,
                    offerId: options.OfferId,
                    declineJobOfferRequest: new DeclineJobOfferRequest { RetryOfferAt = options.RetryOfferAt },
                    cancellationToken: cancellationToken);

                return Response.FromValue(new DeclineJobOfferResult(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Offer

        #region Queue

        /// <summary> Retrieves queue statistics by Id. </summary>
        /// <param name="queueId"> Id of the queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueueStatistics>> GetQueueStatisticsAsync(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueueStatistics)}");
            scope.Start();
            try
            {
                Response<RouterQueueStatistics> queue = await RestClient.GetQueueStatisticsAsync(queueId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves queue statistics by Id. </summary>
        /// <param name="queueId"> Id of the queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        public virtual Response<RouterQueueStatistics> GetQueueStatistics(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueueStatistics)}");
            scope.Start();
            try
            {
                Response<RouterQueueStatistics> queue = RestClient.GetQueueStatistics(queueId, cancellationToken);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Queue

        #region Worker

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for creating a router worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> CreateWorkerAsync(
            CreateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = options.TotalCapacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                foreach (var queueAssignment in options.QueueIds)
                {
                    request.QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var channel in options.ChannelConfigurations)
                {
                    request.ChannelConfigurations[channel.Key] = new ChannelConfiguration(channel.Value.CapacityCostPerJob)
                        {
                            MaxNumberOfJobs = channel.Value.MaxNumberOfJobs
                        };
                }

                var response = await RestClient.UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        patch: request,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for creating a router worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> CreateWorker(
            CreateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = options.TotalCapacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                foreach (var queueAssignment in options.QueueIds)
                {
                    request.QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var channel in options.ChannelConfigurations)
                {
                    request.ChannelConfigurations[channel.Key] = new ChannelConfiguration(channel.Value.CapacityCostPerJob)
                    {
                        MaxNumberOfJobs = channel.Value.MaxNumberOfJobs
                    };
                }

                var response = RestClient.UpsertWorker(
                    workerId: options.WorkerId,
                    patch: request,
                    cancellationToken: cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> UpdateWorkerAsync(
            UpdateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = options.TotalCapacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                foreach (var queueAssignment in options.QueueIds)
                {
                    request.QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var channel in options.ChannelConfigurations)
                {
                    request.ChannelConfigurations[channel.Key] = new ChannelConfiguration(channel.Value.CapacityCostPerJob)
                    {
                        MaxNumberOfJobs = channel.Value.MaxNumberOfJobs
                    };
                }

                var response = await RestClient.UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        patch: request,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> UpdateWorker(
            UpdateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = options.TotalCapacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                foreach (var queueAssignment in options.QueueIds)
                {
                    request.QueueAssignments[queueAssignment.Key] = new RouterQueueAssignment();
                }

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                foreach (var channel in options.ChannelConfigurations)
                {
                    request.ChannelConfigurations[channel.Key] = new ChannelConfiguration(channel.Value.CapacityCostPerJob)
                    {
                        MaxNumberOfJobs = channel.Value.MaxNumberOfJobs
                    };
                }

                var response = RestClient.UpsertWorker(
                    workerId: options.WorkerId,
                    patch: request,
                    cancellationToken: cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from worker. </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateWorkerAsync(
            string workerId,
            RequestContent content,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertWorkerAsync(
                        workerId: workerId,
                        content: content,
                        context: context)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from worker. </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateWorker(
            string workerId,
            RequestContent content,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                return RestClient.UpsertWorker(
                    workerId: workerId,
                    content: content,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Unassign a job from a worker. </summary>
        /// <param name="options"> Options for unassigning a job from a worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<UnassignJobResult>> UnassignJobAsync(UnassignJobOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UnassignJobAsync)}");
            scope.Start();
            try
            {
                var response = await RestClient.UnassignJobActionAsync(
                        id: options.JobId,
                        assignmentId: options.AssignmentId,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Unassign a job from a worker. </summary>
        /// <param name="options"> Options for unassigning a job from a worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<UnassignJobResult> UnassignJob(UnassignJobOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UnassignJob)}");
            scope.Start();
            try
            {
                var response = RestClient.UnassignJobAction(
                    id: options.JobId,
                    assignmentId: options.AssignmentId,
                    cancellationToken: cancellationToken);

                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing workers. Pass status and Channel Id to filter workers further. </summary>
        /// <param name="options"> Options for filtering while retrieving router workers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterWorkerItem> GetWorkersAsync(
            GetWorkersOptions options = default,
            CancellationToken cancellationToken = default)
        {
            async Task<Page<RouterWorkerItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<RouterWorkerCollection> response = await RestClient.ListWorkersAsync(
                        state: options?.State,
                        channelId: options?.ChannelId,
                        queueId: options?.QueueId,
                        hasCapacity: options?.HasCapacity,
                        maxpagesize: maxPageSize,
                        cancellationToken:  cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterWorkerItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<RouterWorkerCollection> response = await RestClient
                        .ListWorkersNextPageAsync(
                            nextLink: nextLink,
                            state: options?.State,
                            channelId: options?.ChannelId,
                            queueId: options?.QueueId,
                            hasCapacity: options?.HasCapacity,
                            maxpagesize: maxPageSize,
                            cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves existing workers. Pass status and Channel Id to filter workers further. </summary>
        /// <param name="options"> Options for filtering while retrieving router workers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterWorkerItem> GetWorkers(
            GetWorkersOptions options = default,
            CancellationToken cancellationToken = default)
        {
            Page<RouterWorkerItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<RouterWorkerCollection> response = RestClient.ListWorkers(
                        state: options?.State,
                        channelId: options?.ChannelId,
                        queueId: options?.QueueId,
                        hasCapacity: options?.HasCapacity,
                        maxpagesize: maxPageSize,
                        cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterWorkerItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<RouterWorkerCollection> response = RestClient
                        .ListWorkersNextPage(
                            nextLink: nextLink,
                            state: options?.State,
                            channelId: options?.ChannelId,
                            queueId: options?.QueueId,
                            hasCapacity: options?.HasCapacity,
                            maxpagesize: maxPageSize,
                            cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves an existing worker by Id. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> GetWorkerAsync(string workerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorker)}");
            scope.Start();
            try
            {
                Response<RouterWorker> worker = await RestClient.GetWorkerAsync(workerId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(worker.Value, worker.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing worker by Id. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> GetWorker(string workerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetWorker)}");
            scope.Start();
            try
            {
                Response<RouterWorker> worker = RestClient.GetWorker(workerId, cancellationToken);
                return Response.FromValue(worker.Value, worker.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes an existing worker by Id. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteWorkerAsync(string workerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeleteWorker)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteWorkerAsync(workerId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes an existing worker by Id. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteWorker(string workerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeleteWorker)}");
            scope.Start();
            try
            {
                return RestClient.DeleteWorker(workerId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Worker
    }
}

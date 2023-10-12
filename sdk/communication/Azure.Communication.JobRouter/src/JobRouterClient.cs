﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            : this(new Uri(connectionString.GetRequired("endpoint"), UriKind.Absolute), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private JobRouterClient(string endpoint, TokenCredential tokenCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private JobRouterClient(string endpoint, AzureKeyCredential keyCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private JobRouterClient(Uri endpoint, HttpPipeline httpPipeline, JobRouterClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new JobRouterRestClient(endpoint, options, httpPipeline);
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

                var response = await RestClient.UpsertJobAsync(
                        id:options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: new RequestConditions(),
                        context: new RequestContext(){ CancellationToken = cancellationToken })
                    .ConfigureAwait(false);

                return Response.FromValue(RouterJob.FromResponse(response), response);
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

                var response = RestClient.UpsertJob(
                    id:options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: new RequestConditions(),
                    context: new RequestContext(){ CancellationToken = cancellationToken });

                return Response.FromValue(RouterJob.FromResponse(response), response);
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

                var response = await RestClient.UpsertJobAsync(
                        id: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: new RequestConditions(),
                        context: new RequestContext() { CancellationToken = cancellationToken })
                    .ConfigureAwait(false);

                return Response.FromValue(RouterJob.FromResponse(response), response);
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

                var response = RestClient.UpsertJob(
                    id: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: new RequestConditions(),
                    context: new RequestContext() { CancellationToken = cancellationToken });

                return Response.FromValue(RouterJob.FromResponse(response), response);
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> UpdateJobAsync(
            UpdateJobOptions options,
            RequestConditions requestConditions = null,
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

                var response = await RestClient.UpsertJobAsync(
                        id: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: new RequestContext(){ CancellationToken = cancellationToken })
                    .ConfigureAwait(false);

                return Response.FromValue(RouterJob.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update an existing job. </summary>
        /// <param name="options"> Options for updating a job. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> UpdateJob(
            UpdateJobOptions options,
            RequestConditions requestConditions = null,
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

                var response = RestClient.UpsertJob(
                    id: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: new RequestContext() { CancellationToken = cancellationToken });

                return Response.FromValue(RouterJob.FromResponse(response), response);
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateJobAsync(
            string jobId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertJobAsync(
                        id: jobId,
                        content: content,
                        requestConditions: requestConditions ?? new RequestConditions(),
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateJob(
            string jobId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                return RestClient.UpsertJob(
                    id: jobId,
                    content: content,
                    requestConditions: requestConditions ?? new RequestConditions(),
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
        public virtual async Task<Response> ReclassifyJobAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return await RestClient.ReclassifyJobAsync(
                    id: jobId,
                    reclassifyJobRequest: new Dictionary<string, string>(),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
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
        public virtual Response ReclassifyJob(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return RestClient.ReclassifyJob(
                    id: jobId,
                    reclassifyJobRequest: new Dictionary<string, string>(),
                    cancellationToken: cancellationToken);
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
        public virtual async Task<Response> CancelJobAsync(
            CancelJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return await RestClient.CancelJobAsync(
                        id: options.JobId,
                        cancelJobRequest: new CancelJobRequest(options.Note, options.DispositionCode),
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response CancelJob(
            CancelJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return RestClient.CancelJob(
                    id: options.JobId,
                    cancelJobRequest: new CancelJobRequest(options.Note, options.DispositionCode),
                    cancellationToken: cancellationToken);
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
        public virtual async Task<Response> CompleteJobAsync(
            CompleteJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return await RestClient.CompleteJobAsync(
                        id: options.JobId,
                        completeJobRequest: new CompleteJobRequest(options.AssignmentId, options.Note),
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response CompleteJob(
            CompleteJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return RestClient.CompleteJob(
                    id: options.JobId,
                    completeJobRequest: new CompleteJobRequest(options.AssignmentId, options.Note),
                    cancellationToken: cancellationToken);
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
        public virtual async Task<Response> CloseJobAsync(
            CloseJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                return await RestClient.CloseJobAsync(
                        id: options.JobId,
                        closeJobRequest: new CloseJobRequest(options.AssignmentId, options.DispositionCode, options.CloseAt, options.Note),
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response CloseJob(
            CloseJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                return RestClient.CloseJob(
                    id: options.JobId,
                    closeJobRequest: new CloseJobRequest(options.AssignmentId, options.DispositionCode, options.CloseAt, options.Note),
                    cancellationToken: cancellationToken);
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
            // todo: add client diagnostic
            return RestClient.GetJobsAsync(
                    status: options?.Status,
                    queueId: options?.QueueId,
                    channelId: options?.ChannelId,
                    classificationPolicyId: options?.ClassificationPolicyId,
                    scheduledBefore: options?.ScheduledBefore,
                    scheduledAfter: options?.ScheduledAfter,
                    cancellationToken: cancellationToken);
        }

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="options"> Options for filter while retrieving jobs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterJobItem> GetJobs(
            GetJobsOptions options = default,
            CancellationToken cancellationToken = default)
        {
            return RestClient.GetJobs(
                status: options?.Status,
                queueId: options?.QueueId,
                channelId: options?.ChannelId,
                classificationPolicyId: options?.ClassificationPolicyId,
                scheduledBefore: options?.ScheduledBefore,
                scheduledAfter: options?.ScheduledAfter,
                cancellationToken: cancellationToken);
        }

        /// <summary> Gets a jobs position details. </summary>
        /// <param name="jobId"> The String to use. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJobPositionDetails>> GetQueuePositionAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueuePosition)}");
            scope.Start();
            try
            {
                return await RestClient.GetQueuePositionAsync(jobId, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<RouterJobPositionDetails> GetQueuePosition(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(GetQueuePosition)}");
            scope.Start();
            try
            {
                return RestClient.GetQueuePosition(jobId, cancellationToken);
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
                return await RestClient.DeleteJobAsync(id: jobId, context: new RequestContext(){ CancellationToken = cancellationToken }).ConfigureAwait(false);
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
                return RestClient.DeleteJob(id: jobId, context: new RequestContext() { CancellationToken = cancellationToken });
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
                var response = await RestClient.AcceptJobAsync(
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
                var response = RestClient.AcceptJob(
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
        public virtual async Task<Response> DeclineJobOfferAsync(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                return await RestClient.DeclineJobAsync(
                        workerId: options.WorkerId,
                        offerId: options.OfferId,
                        declineJobOfferRequest: new DeclineJobOfferRequest { RetryOfferAt = options.RetryOfferAt },
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response DeclineJobOffer(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                return RestClient.DeclineJob(
                    workerId: options.WorkerId,
                    offerId: options.OfferId,
                    declineJobOfferRequest: new DeclineJobOfferRequest { RetryOfferAt = options.RetryOfferAt },
                    cancellationToken: cancellationToken);
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

                foreach (var queueAssignment in options.QueueAssignments)
                {
                    request.QueueAssignments[queueAssignment.Key] = queueAssignment.Value;
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
                    request.ChannelConfigurations[channel.Key] = channel.Value;
                }

                var response = await RestClient.UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        content: request.ToRequestContent(),
                        requestConditions: new RequestConditions(),
                        context: new RequestContext(){ CancellationToken = cancellationToken })
                    .ConfigureAwait(false);

                return Response.FromValue(RouterWorker.FromResponse(response), response);
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

                foreach (var queueAssignment in options.QueueAssignments)
                {
                    request.QueueAssignments[queueAssignment.Key] = queueAssignment.Value;
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
                    request.ChannelConfigurations[channel.Key] = channel.Value;
                }

                var response = RestClient.UpsertWorker(
                    workerId: options.WorkerId,
                    content: request.ToRequestContent(),
                    requestConditions: new RequestConditions(),
                    context: new RequestContext() { CancellationToken = cancellationToken });

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> UpdateWorkerAsync(
            UpdateWorkerOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = options?.TotalCapacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                foreach (var queueAssignment in options.QueueAssignments)
                {
                    request.QueueAssignments[queueAssignment.Key] = queueAssignment.Value;
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
                    request.ChannelConfigurations[channel.Key] = channel.Value;
                }

                var response = await RestClient.UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: new RequestContext(){ CancellationToken = cancellationToken })
                    .ConfigureAwait(false);

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> UpdateWorker(
            UpdateWorkerOptions options,
            RequestConditions requestConditions = null,
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

                foreach (var queueAssignment in options.QueueAssignments)
                {
                    request.QueueAssignments[queueAssignment.Key] = queueAssignment.Value;
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
                    request.ChannelConfigurations[channel.Key] = channel.Value;
                }

                var response = RestClient.UpsertWorker(
                    workerId: options.WorkerId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: new RequestContext() { CancellationToken = cancellationToken });

                return Response.FromValue(RouterWorker.FromResponse(response), response);
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateWorkerAsync(
            string workerId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertWorkerAsync(
                        workerId: workerId,
                        content: content,
                        requestConditions: requestConditions ?? new RequestConditions(),
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateWorker(
            string workerId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                return RestClient.UpsertWorker(
                    workerId: workerId,
                    content: content,
                    requestConditions: requestConditions ?? new RequestConditions(),
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
                var response = await RestClient.UnassignJobAsync(
                        id: options.JobId,
                        assignmentId: options.AssignmentId,
                        unassignJobRequest: new UnassignJobRequest(options.SuspendMatching),
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
                var response = RestClient.UnassignJob(
                    id: options.JobId,
                    assignmentId: options.AssignmentId,
                    unassignJobRequest: new UnassignJobRequest(options.SuspendMatching),
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
            // todo: add client diagnostic
            return RestClient.GetWorkersAsync(
                    state: options?.State,
                    channelId: options?.ChannelId,
                    queueId: options?.QueueId,
                    hasCapacity: options?.HasCapacity,
                    cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves existing workers. Pass status and Channel Id to filter workers further. </summary>
        /// <param name="options"> Options for filtering while retrieving router workers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterWorkerItem> GetWorkers(
            GetWorkersOptions options = default,
            CancellationToken cancellationToken = default)
        {
            // todo: add client diagnostic
            return RestClient.GetWorkers(
                state: options?.State,
                channelId: options?.ChannelId,
                queueId: options?.QueueId,
                hasCapacity: options?.HasCapacity,
                cancellationToken: cancellationToken);
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
                return await RestClient.DeleteWorkerAsync(workerId, context: new RequestContext() { CancellationToken = cancellationToken }).ConfigureAwait(false);
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
                return RestClient.DeleteWorker(workerId, context: new RequestContext() { CancellationToken = cancellationToken });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Worker

        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return new RequestContext();
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}

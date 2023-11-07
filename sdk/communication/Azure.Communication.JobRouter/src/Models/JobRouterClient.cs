// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Collections.Generic;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("JobRouterClient", typeof(Uri))]
    [CodeGenSuppress("JobRouterClient", typeof(Uri), typeof(JobRouterClientOptions))]
    [CodeGenSuppress("CreateGetJobsNextPageRequest", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetWorkersNextPageRequest", typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(bool), typeof(RequestContext))]
    public partial class JobRouterClient
    {
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

        #region internal constructors

        /// <summary> Initializes a new instance of JobRouterClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterClient(Uri endpoint) : this(endpoint, new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of JobRouterClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterClient(Uri endpoint, JobRouterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
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

        /// <summary>Initializes a new instance of <see cref="JobRouterClient"/> for mocking.</summary>
        protected JobRouterClient()
        {
            ClientDiagnostics = null;
        }

        /// <summary> Initializes a new instance of JobRouterAdministrationRestClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        private JobRouterClient(Uri endpoint, HttpPipeline pipeline, JobRouterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
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

                var response = await UpsertJobAsync(
                        jobId: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
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

                var response = UpsertJob(
                    jobId: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJob)}");
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

                var response = await UpsertJobAsync(
                        jobId: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateJob)}");
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

                var response = UpsertJob(
                    jobId: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

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
        /// <param name="job"> Job to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> UpdateJobAsync(
            RouterJob job, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                var response = await UpsertJobAsync(
                        jobId: job.Id,
                        content: job.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
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
        /// <param name="job"> Job to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> UpdateJob(
            RouterJob job, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                var response = UpsertJob(
                    jobId: job.Id,
                    content: job.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterJob.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a router job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateJobAsync(string jobId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertJobRequest(jobId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a router job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UpdateJob(string jobId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertJobRequest(jobId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Reclassify a job. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> ReclassifyJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return await ReclassifyJobAsync(jobId: jobId,
                        options: new Dictionary<string, string>(),
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response ReclassifyJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return ReclassifyJob(
                    jobId: jobId,
                    options: new Dictionary<string, string>(),
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Job

        #region Worker

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for creating a router worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> CreateWorkerAsync(
            CreateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker
                {
                    Capacity = options.Capacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                request.Queues.AddRange(options.Queues);
                request.Channels.AddRange(options.Channels);

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                var response = await UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CreateWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker
                {
                    Capacity = options.Capacity,
                    AvailableForOffers = options?.AvailableForOffers
                };

                request.Queues.AddRange(options.Queues);
                request.Channels.AddRange(options.Channels);

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                foreach (var tag in options.Tags)
                {
                    request.Tags[tag.Key] = tag.Value;
                }

                var response = UpsertWorker(
                    workerId: options.WorkerId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update a worker to process jobs. </summary>
        /// <param name="worker"> Worker to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> UpdateWorkerAsync(
            RouterWorker worker, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                var response = await UpsertWorkerAsync(
                        workerId: worker.Id,
                        content: worker.ToRequestContent(),
                        requestConditions: requestConditions ?? new RequestConditions(),
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Update a worker to process jobs. </summary>
        /// <param name="worker"> Worker to update. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> UpdateWorker(
            RouterWorker worker, RequestConditions requestConditions = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                var response = UpsertWorker(
                    workerId: worker.Id,
                    content: worker.ToRequestContent(),
                    requestConditions: requestConditions ?? new RequestConditions(),
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a worker.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateWorkerAsync(string workerId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(workerId, nameof(workerId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertWorkerRequest(workerId, content, requestConditions, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Updates a worker.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workerId"> Id of the worker. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UpdateWorker(string workerId, RequestContent content, RequestConditions requestConditions = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(workerId, nameof(workerId));
            Argument.AssertNotNull(content, nameof(content));

            Argument.AssertNull(requestConditions?.IfNoneMatch, nameof(requestConditions), "Service does not support the If-None-Match header for this operation.");
            Argument.AssertNull(requestConditions?.IfModifiedSince, nameof(requestConditions), "Service does not support the If-Modified-Since header for this operation.");

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUpsertWorkerRequest(workerId, content, requestConditions, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion Worker

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetJobsNextPageRequest(string nextLink, int? maxpagesize, string status, string queueId, string channelId, string classificationPolicyId, DateTimeOffset? scheduledBefore, DateTimeOffset? scheduledAfter, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetWorkersNextPageRequest(string nextLink, int? maxpagesize, string state, string channelId, string queueId, bool? hasCapacity, RequestContext context)
#pragma warning restore CA1801 // Review unused parameters
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        // /// <summary> Un-assign a job. </summary>
        // /// <param name="id"> Id of the job to un-assign. </param>
        // /// <param name="assignmentId"> Id of the assignment to un-assign. </param>
        // /// <param name="unassignJobRequest"> Request body for unassign route. </param>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="assignmentId"/> is null. </exception>
        // /// <exception cref="ArgumentException"> <paramref name="id"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        // /// <include file="../Generated/Docs/JobRouterClient.xml" path="doc/members/member[@name='UnassignJobAsync(string,string,UnassignJobRequest,CancellationToken)']/*" />
        // internal virtual async Task<Response<UnassignJobResult>> UnassignJobAsync(string id, string assignmentId, UnassignJobRequest unassignJobRequest = null, CancellationToken cancellationToken = default)
        // {
        //     Argument.AssertNotNullOrEmpty(id, nameof(id));
        //     Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));
        //
        //     RequestContext context = FromCancellationToken(cancellationToken);
        //     Response response = await UnassignJobAsync(id, assignmentId, unassignJobRequest?.ToRequestContent(), context).ConfigureAwait(false);
        //     return Response.FromValue(UnassignJobResult.FromResponse(response), response);
        // }
        //
        // /// <summary> Un-assign a job. </summary>
        // /// <param name="id"> Id of the job to un-assign. </param>
        // /// <param name="assignmentId"> Id of the assignment to un-assign. </param>
        // /// <param name="unassignJobRequest"> Request body for unassign route. </param>
        // /// <param name="cancellationToken"> The cancellation token to use. </param>
        // /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="assignmentId"/> is null. </exception>
        // /// <exception cref="ArgumentException"> <paramref name="id"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        // /// <include file="../Generated/Docs/JobRouterClient.xml" path="doc/members/member[@name='UnassignJob(string,string,UnassignJobRequest,CancellationToken)']/*" />
        // internal virtual Response<UnassignJobResult> UnassignJob(string id, string assignmentId, UnassignJobRequest unassignJobRequest = null, CancellationToken cancellationToken = default)
        // {
        //     Argument.AssertNotNullOrEmpty(id, nameof(id));
        //     Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));
        //
        //     RequestContext context = FromCancellationToken(cancellationToken);
        //     Response response = UnassignJob(id, assignmentId, unassignJobRequest?.ToRequestContent(), context);
        //     return Response.FromValue(UnassignJobResult.FromResponse(response), response);
        // }
    }
}

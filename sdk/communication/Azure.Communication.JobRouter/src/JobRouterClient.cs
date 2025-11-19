// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;
using Autorest.CSharp.Core;

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
        /// <param name="connectionString">Connection string acquired from your Communication resource. </param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterClient(string connectionString, JobRouterClientOptions options = default)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterClient"/>.</summary>
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
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
        /// <param name="endpoint"> The <see cref="Uri"/> endpoint of your Communication resource. </param>
        /// <param name="credential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential. </param>
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
            _tokenCredential = tokenCredential;
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
        /// <param name="jobId"> The id of a job. </param>
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
        /// <param name="jobId"> The id of a job. </param>
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
        /// <param name="jobId"> The id of a job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> ReclassifyJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            return (await ReclassifyJobAsync(jobId: jobId,
                options: new ReclassifyJobOptions(),
                cancellationToken: cancellationToken)
                .ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary> Reclassify a job. </summary>
        /// <param name="jobId"> The id of a job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response ReclassifyJob(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            return (ReclassifyJob(
                jobId: jobId,
                options: new ReclassifyJobOptions(),
                cancellationToken: cancellationToken)).GetRawResponse();
        }

        /// <summary>
        /// [Protocol Method] Reclassify a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReclassifyJobAsync(string,ReclassifyJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> ReclassifyJobAsync(string jobId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.ReclassifyJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReclassifyJobRequest(jobId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Reclassify a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ReclassifyJob(string,ReclassifyJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response ReclassifyJob(string jobId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.ReclassifyJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateReclassifyJobRequest(jobId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="options"> Options for closing job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response> CloseJobAsync(CloseJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return (await CloseJobAsync(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="options"> Options for closing job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response CloseJob(CloseJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return CloseJob(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken).GetRawResponse();
        }

        /// <summary>
        /// [Protocol Method] Closes a completed job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CloseJobAsync(string,string,CloseJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CloseJobAsync(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CloseJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCloseJobRequest(jobId, assignmentId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Closes a completed job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CloseJob(string,string,CloseJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CloseJob(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CloseJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCloseJobRequest(jobId, assignmentId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="options"> Options for cancelling job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response> CancelJobAsync(CancelJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return (await CancelJobAsync(
                jobId: options.JobId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="options"> Options for cancelling job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response CancelJob(CancelJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return CancelJob(
                jobId: options.JobId,
                options: options,
                cancellationToken: cancellationToken).GetRawResponse();
        }

        /// <summary>
        /// [Protocol Method] Submits request to cancel an existing job by Id while supplying free-form cancellation reason.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CancelJobAsync(string,CancelJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CancelJobAsync(string jobId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CancelJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelJobRequest(jobId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Submits request to cancel an existing job by Id while supplying free-form cancellation reason.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CancelJob(string,CancelJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CancelJob(string jobId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CancelJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCancelJobRequest(jobId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="options"> Options for completing job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response> CompleteJobAsync(CompleteJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return (await CompleteJobAsync(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="options"> Options for completing job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response CompleteJob(CompleteJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return CompleteJob(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken).GetRawResponse();
        }

        /// <summary>
        /// [Protocol Method] Completes an assigned job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CompleteJobAsync(string,string,CompleteJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> CompleteJobAsync(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CompleteJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCompleteJobRequest(jobId, assignmentId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Completes an assigned job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CompleteJob(string,string,CompleteJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response CompleteJob(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.CompleteJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCompleteJobRequest(jobId, assignmentId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="options"> Options for declining offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response> DeclineJobOfferAsync(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return (await DeclineJobOfferAsync(
                workerId: options.WorkerId,
                offerId: options.OfferId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false)).GetRawResponse();
        }

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="options"> Options for declining offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response DeclineJobOffer(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return DeclineJobOffer(
                workerId: options.WorkerId,
                offerId: options.OfferId,
                options: options,
                cancellationToken: cancellationToken).GetRawResponse();
        }

        /// <summary>
        /// [Protocol Method] Declines an offer to work on a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeclineJobOfferAsync(string,string,DeclineJobOfferOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workerId"> Id of a worker. </param>
        /// <param name="offerId"> Id of an offer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="offerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workerId"/> or <paramref name="offerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> DeclineJobOfferAsync(string workerId, string offerId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(workerId, nameof(workerId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.DeclineJobOffer");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeclineJobOfferRequest(workerId, offerId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Declines an offer to work on a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeclineJobOffer(string,string,DeclineJobOfferOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="workerId"> Id of a worker. </param>
        /// <param name="offerId"> Id of an offer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> or <paramref name="offerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workerId"/> or <paramref name="offerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response DeclineJobOffer(string workerId, string offerId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(workerId, nameof(workerId));
            Argument.AssertNotNullOrEmpty(offerId, nameof(offerId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.DeclineJobOffer");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeclineJobOfferRequest(workerId, offerId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Unassign a job. </summary>
        /// <param name="options"> Options for unassigning a job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<UnassignJobResult>> UnassignJobAsync(UnassignJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return (await UnassignJobAsync(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken).ConfigureAwait(false));
        }

        /// <summary> Unassign a job. </summary>
        /// <param name="options"> Options for unassigning a job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<UnassignJobResult> UnassignJob(UnassignJobOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            return UnassignJob(
                jobId: options.JobId,
                assignmentId: options.AssignmentId,
                options: options,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// [Protocol Method] Unassign a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UnassignJobAsync(string,string,UnassignJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UnassignJobAsync(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.UnassignJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignJobRequest(jobId, assignmentId, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Unassign a job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="UnassignJob(string,string,UnassignJobOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UnassignJob(string jobId, string assignmentId, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            using var scope = ClientDiagnostics.CreateScope("JobRouterClient.UnassignJob");
            scope.Start();
            try
            {
                using HttpMessage message = CreateUnassignJobRequest(jobId, assignmentId, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves list of jobs based on filter parameters. </summary>
        /// <param name="status"> If specified, filter jobs by status. </param>
        /// <param name="queueId"> If specified, filter jobs by queue. </param>
        /// <param name="channelId"> If specified, filter jobs by channel. </param>
        /// <param name="classificationPolicyId"> If specified, filter jobs by classificationPolicy. </param>
        /// <param name="scheduledBefore"> If specified, filter on jobs that was scheduled before or at given timestamp. Range: (-Inf, scheduledBefore]. </param>
        /// <param name="scheduledAfter"> If specified, filter on jobs that was scheduled at or after given value. Range: [scheduledAfter, +Inf). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<RouterJob> GetJobsAsync(RouterJobStatusSelector? status = null,
            string queueId = null, string channelId = null, string classificationPolicyId = null,
            DateTimeOffset? scheduledBefore = null, DateTimeOffset? scheduledAfter = null,
            CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetJobsRequest(pageSizeHint, status?.ToString(), queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetJobsNextPageRequest(nextLink, pageSizeHint, status?.ToString(), queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => RouterJob.DeserializeRouterJob(e), ClientDiagnostics, _pipeline, "JobRouterClient.GetJobs", "value", "nextLink", context);
        }

        /// <summary> Retrieves list of jobs based on filter parameters. </summary>
        /// <param name="status"> If specified, filter jobs by status. </param>
        /// <param name="queueId"> If specified, filter jobs by queue. </param>
        /// <param name="channelId"> If specified, filter jobs by channel. </param>
        /// <param name="classificationPolicyId"> If specified, filter jobs by classificationPolicy. </param>
        /// <param name="scheduledBefore"> If specified, filter on jobs that was scheduled before or at given timestamp. Range: (-Inf, scheduledBefore]. </param>
        /// <param name="scheduledAfter"> If specified, filter on jobs that was scheduled at or after given value. Range: [scheduledAfter, +Inf). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<RouterJob> GetJobs(RouterJobStatusSelector? status = null, string queueId = null,
            string channelId = null, string classificationPolicyId = null, DateTimeOffset? scheduledBefore = null,
            DateTimeOffset? scheduledAfter = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetJobsRequest(pageSizeHint, status?.ToString(), queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetJobsNextPageRequest(nextLink, pageSizeHint, status?.ToString(), queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => RouterJob.DeserializeRouterJob(e), ClientDiagnostics, _pipeline, "JobRouterClient.GetJobs", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Retrieves list of jobs based on filter parameters.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobsAsync(int?,RouterJobStatusSelector?,string,string,string,DateTimeOffset?,DateTimeOffset?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="status"> If specified, filter jobs by status. Allowed values: "all" | "pendingClassification" | "queued" | "assigned" | "completed" | "closed" | "cancelled" | "classificationFailed" | "created" | "pendingSchedule" | "scheduled" | "scheduleFailed" | "waitingForActivation" | "active". </param>
        /// <param name="queueId"> If specified, filter jobs by queue. </param>
        /// <param name="channelId"> If specified, filter jobs by channel. </param>
        /// <param name="classificationPolicyId"> If specified, filter jobs by classificationPolicy. </param>
        /// <param name="scheduledBefore"> If specified, filter on jobs that was scheduled before or at given timestamp. Range: (-Inf, scheduledBefore]. </param>
        /// <param name="scheduledAfter"> If specified, filter on jobs that was scheduled at or after given value. Range: [scheduledAfter, +Inf). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetJobsAsync(string status, string queueId, string channelId, string classificationPolicyId, DateTimeOffset? scheduledBefore, DateTimeOffset? scheduledAfter, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetJobsRequest(pageSizeHint, status, queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetJobsNextPageRequest(nextLink, pageSizeHint, status, queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "JobRouterClient.GetJobs", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Retrieves list of jobs based on filter parameters.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetJobs(int?,RouterJobStatusSelector?,string,string,string,DateTimeOffset?,DateTimeOffset?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="status"> If specified, filter jobs by status. Allowed values: "all" | "pendingClassification" | "queued" | "assigned" | "completed" | "closed" | "cancelled" | "classificationFailed" | "created" | "pendingSchedule" | "scheduled" | "scheduleFailed" | "waitingForActivation" | "active". </param>
        /// <param name="queueId"> If specified, filter jobs by queue. </param>
        /// <param name="channelId"> If specified, filter jobs by channel. </param>
        /// <param name="classificationPolicyId"> If specified, filter jobs by classificationPolicy. </param>
        /// <param name="scheduledBefore"> If specified, filter on jobs that was scheduled before or at given timestamp. Range: (-Inf, scheduledBefore]. </param>
        /// <param name="scheduledAfter"> If specified, filter on jobs that was scheduled at or after given value. Range: [scheduledAfter, +Inf). </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetJobs(string status, string queueId, string channelId, string classificationPolicyId, DateTimeOffset? scheduledBefore, DateTimeOffset? scheduledAfter, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetJobsRequest(pageSizeHint, status, queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetJobsNextPageRequest(nextLink, pageSizeHint, status, queueId, channelId, classificationPolicyId, scheduledBefore, scheduledAfter, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "JobRouterClient.GetJobs", "value", "nextLink", context);
        }

        #endregion Job

        #region Worker

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for creating a router worker. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                    AvailableForOffers = options?.AvailableForOffers,
                    MaxConcurrentOffers = options?.MaxConcurrentOffers,
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
                    AvailableForOffers = options?.AvailableForOffers,
                    MaxConcurrentOffers = options?.MaxConcurrentOffers,
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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
        /// <param name="workerId"> Id of a worker. </param>
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
        /// <param name="workerId"> Id of a worker. </param>
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

        /// <summary> Retrieves existing workers. </summary>
        /// <param name="state"> If specified, select workers by worker state. </param>
        /// <param name="channelId"> If specified, select workers who have a channel configuration with this channel. </param>
        /// <param name="queueId"> If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity"> If set to true, select only workers who have capacity for the channel specified by `channelId` or for any channel if `channelId` not specified. If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<RouterWorker> GetWorkersAsync(RouterWorkerStateSelector? state = null, string channelId = null, string queueId = null, bool? hasCapacity = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWorkersRequest(pageSizeHint, state?.ToString(), channelId, queueId, hasCapacity, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWorkersNextPageRequest(nextLink, pageSizeHint, state?.ToString(), channelId, queueId, hasCapacity, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => RouterWorker.DeserializeRouterWorker(e), ClientDiagnostics, _pipeline, "JobRouterClient.GetWorkers", "value", "nextLink", context);
        }

        /// <summary> Retrieves existing workers. </summary>
        /// <param name="state"> If specified, select workers by worker state. </param>
        /// <param name="channelId"> If specified, select workers who have a channel configuration with this channel. </param>
        /// <param name="queueId"> If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity"> If set to true, select only workers who have capacity for the channel specified by `channelId` or for any channel if `channelId` not specified. If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<RouterWorker> GetWorkers(RouterWorkerStateSelector? state = null, string channelId = null, string queueId = null, bool? hasCapacity = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWorkersRequest(pageSizeHint, state?.ToString(), channelId, queueId, hasCapacity, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWorkersNextPageRequest(nextLink, pageSizeHint, state?.ToString(), channelId, queueId, hasCapacity, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => RouterWorker.DeserializeRouterWorker(e), ClientDiagnostics, _pipeline, "JobRouterClient.GetWorkers", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Retrieves existing workers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWorkersAsync(int?,RouterWorkerStateSelector?,string,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="state"> If specified, select workers by worker state. Allowed values: "active" | "draining" | "inactive" | "all". </param>
        /// <param name="channelId"> If specified, select workers who have a channel configuration with this channel. </param>
        /// <param name="queueId"> If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity"> If set to true, select only workers who have capacity for the channel specified by `channelId` or for any channel if `channelId` not specified. If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual AsyncPageable<BinaryData> GetWorkersAsync(string state, string channelId, string queueId, bool? hasCapacity, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWorkersRequest(pageSizeHint, state, channelId, queueId, hasCapacity, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWorkersNextPageRequest(nextLink, pageSizeHint, state, channelId, queueId, hasCapacity, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "JobRouterClient.GetWorkers", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Retrieves existing workers.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWorkers(int?,RouterWorkerStateSelector?,string,string,bool?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="state"> If specified, select workers by worker state. Allowed values: "active" | "draining" | "inactive" | "all". </param>
        /// <param name="channelId"> If specified, select workers who have a channel configuration with this channel. </param>
        /// <param name="queueId"> If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity"> If set to true, select only workers who have capacity for the channel specified by `channelId` or for any channel if `channelId` not specified. If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        public virtual Pageable<BinaryData> GetWorkers(string state, string channelId, string queueId, bool? hasCapacity, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWorkersRequest(pageSizeHint, state, channelId, queueId, hasCapacity, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWorkersNextPageRequest(nextLink, pageSizeHint, state, channelId, queueId, hasCapacity, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "JobRouterClient.GetWorkers", "value", "nextLink", context);
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
    }
}

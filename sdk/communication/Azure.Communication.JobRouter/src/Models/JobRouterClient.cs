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
                        id: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
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
                    id: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
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
                        id: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
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
                    id: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
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
        /// <param name="options"> Options for updating a job. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> UpdateJobAsync(
            UpdateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
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

                var response = await UpsertJobAsync(
                        id: options.JobId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
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
        /// <param name="options"> Options for updating a job. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> UpdateJob(
            UpdateJobOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateJob)}");
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

                var response = UpsertJob(
                    id: options.JobId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterJob.FromResponse(response), response);
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

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return await ReclassifyJobAsync(
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

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                return ReclassifyJob(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return await CancelJobAsync(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return CancelJob(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return await CompleteJobAsync(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return CompleteJob(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                return await CloseJobAsync(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                return CloseJob(
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

        #endregion Job

        #region Offer

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="options"> The options for declining a job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeclineJobOfferAsync(DeclineJobOfferOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                return await DeclineJobOfferAsync(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(DeclineJobOffer)}");
            scope.Start();
            try
            {
                return DeclineJobOffer(
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

                var response = await UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
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

                var response = UpsertWorker(
                    workerId: options.WorkerId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterWorker.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Create or update a worker to process jobs. </summary>
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> UpdateWorkerAsync(
            UpdateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
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

                var response = await UpsertWorkerAsync(
                        workerId: options.WorkerId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
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
        /// <param name="options"> Options for updating a router worker. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> UpdateWorker(
            UpdateWorkerOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UpdateWorker)}");
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

                var response = UpsertWorker(
                    workerId: options.WorkerId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterWorker.FromResponse(response), response);
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UnassignJobAsync)}");
            scope.Start();
            try
            {
                var response = await UnassignJobAsync(
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterClient)}.{nameof(UnassignJob)}");
            scope.Start();
            try
            {
                var response = UnassignJob(
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

        /// <summary> Un-assign a job. </summary>
        /// <param name="id"> Id of the job to un-assign. </param>
        /// <param name="assignmentId"> Id of the assignment to un-assign. </param>
        /// <param name="unassignJobRequest"> Request body for unassign route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="../Generated/Docs/JobRouterClient.xml" path="doc/members/member[@name='UnassignJobAsync(string,string,UnassignJobRequest,CancellationToken)']/*" />
        internal virtual async Task<Response<UnassignJobResult>> UnassignJobAsync(string id, string assignmentId, UnassignJobRequest unassignJobRequest = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await UnassignJobAsync(id, assignmentId, unassignJobRequest?.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(UnassignJobResult.FromResponse(response), response);
        }

        /// <summary> Un-assign a job. </summary>
        /// <param name="id"> Id of the job to un-assign. </param>
        /// <param name="assignmentId"> Id of the assignment to un-assign. </param>
        /// <param name="unassignJobRequest"> Request body for unassign route. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="../Generated/Docs/JobRouterClient.xml" path="doc/members/member[@name='UnassignJob(string,string,UnassignJobRequest,CancellationToken)']/*" />
        internal virtual Response<UnassignJobResult> UnassignJob(string id, string assignmentId, UnassignJobRequest unassignJobRequest = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = UnassignJob(id, assignmentId, unassignJobRequest?.ToRequestContent(), context);
            return Response.FromValue(UnassignJobResult.FromResponse(response), response);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.JobRouter
{
    [CodeGenSuppress("CreateGetExceptionPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetClassificationPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetQueuesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("CreateGetDistributionPoliciesNextPageRequest", typeof(string), typeof(int?), typeof(RequestContext))]
    public partial class JobRouterAdministrationClient
    {
        #region public constructors

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public JobRouterAdministrationClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(string connectionString, JobRouterClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(Uri endpoint, AzureKeyCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="JobRouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public JobRouterAdministrationClient(Uri endpoint, TokenCredential credential, JobRouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new JobRouterClientOptions())
        {
        }

        #endregion public constructors

        #region private constructors

        private JobRouterAdministrationClient(ConnectionString connectionString, JobRouterClientOptions options)
            : this(new Uri(connectionString.GetRequired("endpoint"), UriKind.Absolute), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private JobRouterAdministrationClient(string endpoint, TokenCredential tokenCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private JobRouterAdministrationClient(string endpoint, AzureKeyCredential keyCredential, JobRouterClientOptions options)
            : this(new Uri(endpoint, UriKind.Absolute), options.BuildHttpPipeline(keyCredential), options)
        {
        }

        /// <summary>Initializes a new instance of <see cref="JobRouterAdministrationClient"/> for mocking.</summary>
        protected JobRouterAdministrationClient()
        {
            ClientDiagnostics = null;
        }

        #endregion private constructors

        #region ClassificationPolicy

        /// <summary> Creates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> CreateClassificationPolicyAsync(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule,
                };

                request.QueueSelectors.AddRange(options.QueueSelectors);
                request.WorkerSelectors.AddRange(options.WorkerSelectors);

                var result = await UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ClassificationPolicy.FromResponse(result), result);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> CreateClassificationPolicy(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule,
                };

                request.QueueSelectors.AddRange(options.QueueSelectors);
                request.WorkerSelectors.AddRange(options.WorkerSelectors);

                var result = UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ClassificationPolicy.FromResponse(result), result);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates classification policy. </summary>
        /// <param name="options"> (Optional) Options for updating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> UpdateClassificationPolicyAsync(
            UpdateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule
                };

                request.QueueSelectors.AddRange(options.QueueSelectors);
                request.WorkerSelectors.AddRange(options.WorkerSelectors);

                var response = await UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ClassificationPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for updating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> UpdateClassificationPolicy(
            UpdateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    PrioritizationRule = options.PrioritizationRule
                };

                request.QueueSelectors.AddRange(options.QueueSelectors);
                request.WorkerSelectors.AddRange(options.WorkerSelectors);

                var response = UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ClassificationPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion ClassificationPolicy

        #region DistributionPolicy

        /// <summary> Creates a distribution policy. </summary>
        /// <param name="options"> Additional options that can be used while creating distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> CreateDistributionPolicyAsync(
            CreateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = await UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a distribution policy. </summary>
        /// <param name="options"> Additional options that can be used while creating distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> CreateDistributionPolicy(
            CreateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a distribution policy. </summary>
        /// <param name="options"> (Optional) Options for the distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> UpdateDistributionPolicyAsync(
            UpdateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferExpiresAfter = options.OfferExpiresAfter,
                    Mode = options.Mode,
                };

                var response = await UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates a distribution policy. </summary>
        /// <param name="options"> (Optional) Options for the distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> UpdateDistributionPolicy(
            UpdateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferExpiresAfter = options.OfferExpiresAfter,
                    Mode = options.Mode,
                };

                var response = UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion DistributionPolicy

        #region ExceptionPolicy

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="options"> (Optional) Options for creating an exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> CreateExceptionPolicyAsync(
            CreateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                foreach (var rule in options.ExceptionRules)
                {
                    request.ExceptionRules[rule.Key] = rule.Value;
                }

                var response = await UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="options"> (Optional) Options for creating an exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> CreateExceptionPolicy(
            CreateExceptionPolicyOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                foreach (var rule in options.ExceptionRules)
                {
                    request.ExceptionRules[rule.Key] = rule.Value;
                }

                var response = UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="options"> Options for updating exception policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> UpdateExceptionPolicyAsync(
            UpdateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                foreach (var rule in options.ExceptionRules)
                {
                    request.ExceptionRules[rule.Key] = rule.Value;
                }

                var response = await UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="options"> Options for updating exception policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> UpdateExceptionPolicy(
            UpdateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name
                };

                foreach (var rule in options.ExceptionRules)
                {
                    request.ExceptionRules[rule.Key] = rule.Value;
                }

                var response = UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion ExceptionPolicy

        #region Queue

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for creating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> CreateQueueAsync(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = await UpsertQueueAsync(
                        id: options.QueueId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for creating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterQueue> CreateQueue(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = UpsertQueue(
                    id: options.QueueId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for updating a job queue. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> UpdateQueueAsync(
            UpdateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = await UpsertQueueAsync(
                        id: options.QueueId,
                        content: request.ToRequestContent(),
                        requestConditions: options.RequestConditions,
                        context: FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for updating a queue. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7396. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterQueue> UpdateQueue(
            UpdateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var request = new RouterQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                foreach (var label in options.Labels)
                {
                    request.Labels[label.Key] = label.Value;
                }

                var response = UpsertQueue(
                    id: options.QueueId,
                    content: request.ToRequestContent(),
                    requestConditions: options.RequestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Queue

        /// <summary> Initializes a new instance of JobRouterAdministrationRestClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        internal JobRouterAdministrationClient(Uri endpoint, HttpPipeline pipeline, JobRouterClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new JobRouterClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = pipeline;
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

#pragma warning disable CA1801 // Review unused parameters
        // Temporary work around before fix: https://github.com/Azure/autorest.csharp/issues/2323
        internal HttpMessage CreateGetExceptionPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetClassificationPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetQueuesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
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
        internal HttpMessage CreateGetDistributionPoliciesNextPageRequest(string nextLink, int? maxpagesize, RequestContext context)
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// The Azure Communication Services Router Administration client.
    /// </summary>
    public class JobRouterAdministrationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal JobRouterAdministrationRestClient RestClient { get; }

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

        private JobRouterAdministrationClient(Uri endpoint, HttpPipeline httpPipeline, JobRouterClientOptions options)
        {
            RestClient = new JobRouterAdministrationRestClient(endpoint, options, httpPipeline);
        }

        /// <summary>Initializes a new instance of <see cref="JobRouterAdministrationClient"/> for mocking.</summary>
        protected JobRouterAdministrationClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        #endregion private constructors

        #region ClassificationPolicy

        /// <summary> Creates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> CreateClassificationPolicyAsync(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
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

                var result = await RestClient.UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
                        content: request.ToRequestContent(),
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
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

                var result = RestClient.UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    content: request.ToRequestContent(),
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
        /// <param name="options"> (Optional) Options for updating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> UpdateClassificationPolicyAsync(
            UpdateClassificationPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
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

                var response = await RestClient.UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions,
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
        /// <param name="options"> (Optional) Options for updating classification policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> UpdateClassificationPolicy(
            UpdateClassificationPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
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

                var response = RestClient.UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ClassificationPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from classification policy. </summary>
        /// <param name="classificationPolicyId"> Id of the classification policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateClassificationPolicyAsync(
            string classificationPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertClassificationPolicyAsync(
                        id: classificationPolicyId,
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

        /// <summary> Protocol method to use to remove properties from classification policy. </summary>
        /// <param name="classificationPolicyId"> Id of the classification policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateClassificationPolicy(
            string classificationPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.UpsertClassificationPolicy(
                    id: classificationPolicyId,
                    content: content,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing classification policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ClassificationPolicyItem> GetClassificationPoliciesAsync(CancellationToken cancellationToken = default)
        {
            // todo: add diagnostic
            return RestClient.GetClassificationPoliciesAsync(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves existing classification policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ClassificationPolicyItem> GetClassificationPolicies(CancellationToken cancellationToken = default)
        {
            // todo: add diagnostic
            return RestClient.GetClassificationPolicies(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves an existing classification policy by Id. </summary>
        /// <param name="classificationPolicyId"> The Id of the classification policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> GetClassificationPolicyAsync(string classificationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.GetClassificationPolicyAsync(classificationPolicyId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing classification policy by Id. </summary>
        /// <param name="classificationPolicyId"> The Id of the classification policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> GetClassificationPolicy(string classificationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.GetClassificationPolicy(classificationPolicyId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a Classification Policy by Id. </summary>
        /// <param name="classificationPolicyId"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteClassificationPolicyAsync(string classificationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteClassificationPolicyAsync(classificationPolicyId, FromCancellationToken(cancellationToken)).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a Classification Policy by Id. </summary>
        /// <param name="classificationPolicyId"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteClassificationPolicy(string classificationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteClassificationPolicy(classificationPolicyId, FromCancellationToken(cancellationToken));
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = await RestClient.UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
                        content: request.ToRequestContent(),
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferExpiresAfter, options.Mode)
                {
                    Name = options?.Name,
                };

                var response = RestClient.UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    content: request.ToRequestContent(),
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> UpdateDistributionPolicyAsync(
            UpdateDistributionPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferExpiresAfter = options.OfferExpiresAfter,
                    Mode = options.Mode,
                };

                var response = await RestClient.UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions,
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
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> UpdateDistributionPolicy(
            UpdateDistributionPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferExpiresAfter = options.OfferExpiresAfter,
                    Mode = options.Mode,
                };

                var response = RestClient.UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(DistributionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from distribution policy. </summary>
        /// <param name="distributionPolicyId"> Id of the distribution policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateDistributionPolicyAsync(
            string distributionPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertDistributionPolicyAsync(
                        id: distributionPolicyId,
                        content: content,
                        requestConditions: requestConditions,
                        context: context)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from distribution policy. </summary>
        /// <param name="distributionPolicyId"> Id of the distribution policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateDistributionPolicy(
            string distributionPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.UpsertDistributionPolicy(
                    id: distributionPolicyId,
                    content: content,
                    requestConditions: requestConditions,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing distribution policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<DistributionPolicyItem> GetDistributionPoliciesAsync(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostic
            return RestClient.GetDistributionPoliciesAsync(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves existing distribution policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DistributionPolicyItem> GetDistributionPolicies(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostic
            return RestClient.GetDistributionPolicies(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves an existing distribution policy by Id. </summary>
        /// <param name="distributionPolicyId"> The Id of the distribution Policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> GetDistributionPolicyAsync(string distributionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.GetDistributionPolicyAsync(distributionPolicyId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing distribution policy by Id. </summary>
        /// <param name="distributionPolicyId"> The Id of the distribution policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> GetDistributionPolicy(string distributionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.GetDistributionPolicy(distributionPolicyId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete a distribution policy by Id. </summary>
        /// <param name="distributionPolicyId"> The Id of the Distribution Policy</param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteDistributionPolicyAsync(string distributionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteDistributionPolicyAsync(distributionPolicyId, FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete a distribution policy by Id. </summary>
        /// <param name="distributionPolicyId"> The id of the Distribution policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteDistributionPolicy(string distributionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteDistributionPolicy(distributionPolicyId, FromCancellationToken(cancellationToken));
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
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

                var response = await RestClient.UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
                        content: request.ToRequestContent(),
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
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

                var response = RestClient.UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    content: request.ToRequestContent(),
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
        /// <param name="options"> Options for updating exception policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> UpdateExceptionPolicyAsync(
            UpdateExceptionPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
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

                var response = await RestClient.UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions,
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
        /// <param name="options"> Options for updating exception policy. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> UpdateExceptionPolicy(
            UpdateExceptionPolicyOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
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

                var response = RestClient.UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(ExceptionPolicy.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from exception policy. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateExceptionPolicyAsync(
            string exceptionPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertExceptionPolicyAsync(
                        id: exceptionPolicyId,
                        content: content,
                        requestConditions: requestConditions,
                        context: context)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from exception policy. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateExceptionPolicy(
            string exceptionPolicyId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.UpsertExceptionPolicy(
                    id: exceptionPolicyId,
                    content: content,
                    requestConditions: requestConditions,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing exception policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ExceptionPolicyItem> GetExceptionPoliciesAsync(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostic
            return RestClient.GetExceptionPoliciesAsync(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves existing exception policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ExceptionPolicyItem> GetExceptionPolicies(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostics
            return RestClient.GetExceptionPolicies(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves an existing exception policy by Id. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> GetExceptionPolicyAsync(string exceptionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetExceptionPolicy)}");
            scope.Start();
            try
            {
                Response<ExceptionPolicy> exceptionPolicy = await RestClient.GetExceptionPolicyAsync(exceptionPolicyId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ExceptionPolicy(exceptionPolicy.Value.Id, exceptionPolicy.Value.Name, exceptionPolicy.Value.ExceptionRules), exceptionPolicy.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing exception policy by Id. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> GetExceptionPolicy(string exceptionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetExceptionPolicy)}");
            scope.Start();
            try
            {
                Response<ExceptionPolicy> exceptionPolicy = RestClient.GetExceptionPolicy(exceptionPolicyId, cancellationToken);
                return Response.FromValue(new ExceptionPolicy(exceptionPolicy.Value.Id, exceptionPolicy.Value.Name, exceptionPolicy.Value.ExceptionRules), exceptionPolicy.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a exception policy by Id. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteExceptionPolicyAsync(string exceptionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteExceptionPolicyAsync(exceptionPolicyId, FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a exception policy by Id. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteExceptionPolicy(string exceptionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteExceptionPolicy(exceptionPolicyId, FromCancellationToken(cancellationToken));
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
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

                var response = await RestClient.UpsertQueueAsync(
                        id: options.QueueId,
                        content: request.ToRequestContent(),
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(CreateQueue)}");
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

                var response = RestClient.UpsertQueue(
                    id: options.QueueId,
                    content: request.ToRequestContent(),
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
        /// <param name="options"> Options for updating a job queue. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> UpdateQueueAsync(
            UpdateQueueOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
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

                var response = await RestClient.UpsertQueueAsync(
                        id: options.QueueId,
                        content: request.ToRequestContent(),
                        requestConditions: requestConditions,
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
        /// <param name="options"> Options for updating a queue. Uses merge-patch semantics: https://datatracker.ietf.org/doc/html/rfc7386. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterQueue> UpdateQueue(
            UpdateQueueOptions options,
            RequestConditions requestConditions = null,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
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

                var response = RestClient.UpsertQueue(
                    id: options.QueueId,
                    content: request.ToRequestContent(),
                    requestConditions: requestConditions,
                    context: FromCancellationToken(cancellationToken));

                return Response.FromValue(RouterQueue.FromResponse(response), response);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Protocol method to use to remove properties from worker. </summary>
        /// <param name="queueId"> Id of the queue. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> UpdateQueueAsync(
            string queueId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                return await RestClient.UpsertQueueAsync(
                        id: queueId,
                        content: content,
                        requestConditions: requestConditions,
                        context: context)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="queueId"> Id of the queue. </param>
        /// <param name="content"> Request content payload. </param>
        /// <param name="requestConditions"> The content to send as the request conditions of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response UpdateQueue(
            string queueId,
            RequestContent content,
            RequestConditions requestConditions = null,
            RequestContext context = null)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                return RestClient.UpsertQueue(
                    id: queueId,
                    content: content,
                    requestConditions: requestConditions,
                    context: context);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing queues. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterQueueItem> GetQueuesAsync(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostic
            return RestClient.GetQueuesAsync(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves existing queues. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterQueueItem> GetQueues(CancellationToken cancellationToken = default)
        {
            // todo: fix diagnostic
            return RestClient.GetQueues(cancellationToken: cancellationToken);
        }

        /// <summary> Retrieves an existing queue by Id. </summary>
        /// <param name="queueId"> Id of the queue to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterQueue>> GetQueueAsync(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<RouterQueue> queue = await RestClient.GetQueueAsync(queueId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing queue by Id. </summary>
        /// <param name="queueId"> Id of the queue to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        public virtual Response<RouterQueue> GetQueue(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<RouterQueue> queue = RestClient.GetQueue(queueId, cancellationToken);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a queue by Id. </summary>
        /// <param name="queueId"> Id of the queue to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteQueueAsync(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteQueueAsync(queueId, FromCancellationToken(cancellationToken))
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a queue by Id. </summary>
        /// <param name="queueId"> Id of the queue to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteQueue(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(JobRouterAdministrationClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return RestClient.DeleteQueue(queueId, FromCancellationToken(cancellationToken));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Queue

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

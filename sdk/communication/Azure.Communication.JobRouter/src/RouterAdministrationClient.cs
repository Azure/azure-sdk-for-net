// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// The Azure Communication Services Router Administration client.
    /// </summary>
    public class RouterAdministrationClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal JobRouterAdministrationRestClient RestClient { get; }

        #region public constructors

        /// <summary> Initializes a new instance of <see cref="RouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public RouterAdministrationClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterAdministrationClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterAdministrationClient(string connectionString, RouterClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterAdministrationClient(Uri endpoint, AzureKeyCredential credential, RouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterAdministrationClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="credential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterAdministrationClient(Uri endpoint, TokenCredential credential, RouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(credential, nameof(credential)),
                options ?? new RouterClientOptions())
        {
        }

        #endregion public constructors

        #region private constructors

        private RouterAdministrationClient(ConnectionString connectionString, RouterClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private RouterAdministrationClient(string endpoint, TokenCredential tokenCredential, RouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private RouterAdministrationClient(string endpoint, AzureKeyCredential keyCredential, RouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private RouterAdministrationClient(string endpoint, HttpPipeline httpPipeline, RouterClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new JobRouterAdministrationRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        /// <summary>Initializes a new instance of <see cref="RouterAdministrationClient"/> for mocking.</summary>
        protected RouterAdministrationClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        #endregion private constructors

        #region ClassificationPolicy

        /// <summary> Creates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy.. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> CreateClassificationPolicyAsync(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    QueueSelectors = options.QueueSelectors,
                    WorkerSelectors = options.WorkerSelectors,
                    PrioritizationRule = options.PrioritizationRule,
                };

                return await RestClient.UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
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

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for creating classification policy.. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> CreateClassificationPolicy(
            CreateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    QueueSelectors = options.QueueSelectors,
                    WorkerSelectors = options.WorkerSelectors,
                    PrioritizationRule = options.PrioritizationRule,
                };

                return RestClient.UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates classification policy. </summary>
        /// <param name="options"> (Optional) Options for updating classification policy.. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> UpdateClassificationPolicyAsync(
            UpdateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    QueueSelectors = options.QueueSelectors,
                    WorkerSelectors = options.WorkerSelectors,
                    PrioritizationRule = options.PrioritizationRule
                };

                return await RestClient.UpsertClassificationPolicyAsync(
                        id: options.ClassificationPolicyId,
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

        /// <summary> Creates or updates a classification policy. </summary>
        /// <param name="options"> (Optional) Options for updating classification policy.. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> UpdateClassificationPolicy(
            UpdateClassificationPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = options.Name,
                    FallbackQueueId = options.FallbackQueueId,
                    QueueSelectors = options.QueueSelectors,
                    WorkerSelectors = options.WorkerSelectors,
                };

                return RestClient.UpsertClassificationPolicy(
                    id: options.ClassificationPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
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
            async Task<Page<ClassificationPolicyItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesAsync(maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ClassificationPolicyItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves existing classification policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ClassificationPolicyItem> GetClassificationPolicies(CancellationToken cancellationToken = default)
        {
            Page<ClassificationPolicyItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ClassificationPolicyItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves an existing classification policy by Id. </summary>
        /// <param name="classificationPolicyId"> The Id of the classification policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> GetClassificationPolicyAsync(string classificationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicy)}");
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetClassificationPolicy)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteClassificationPolicyAsync(classificationPolicyId, cancellationToken).ConfigureAwait(false);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteClassificationPolicy(classificationPolicyId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferTtl, options.Mode)
                {
                    Name = options?.Name,
                };

                return await RestClient.UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
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

        /// <summary> Creates a distribution policy. </summary>
        /// <param name="options"> Additional options that can be used while creating distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> CreateDistributionPolicy(
            CreateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(options.OfferTtl, options.Mode)
                {
                    Name = options?.Name,
                };

                return RestClient.UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferTtl = options.OfferTtl,
                    Mode = options.Mode,
                };

                return await RestClient.UpsertDistributionPolicyAsync(
                        id: options.DistributionPolicyId,
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

        /// <summary> Updates a distribution policy. </summary>
        /// <param name="options"> (Optional) Options for the distribution policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> UpdateDistributionPolicy(
            UpdateDistributionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy()
                {
                    Name = options.Name,
                    OfferTtl = options.OfferTtl,
                    Mode = options.Mode,
                };

                return RestClient.UpsertDistributionPolicy(
                    id: options.DistributionPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
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
            async Task<Page<DistributionPolicyItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesAsync(maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DistributionPolicyItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves existing distribution policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DistributionPolicyItem> GetDistributionPolicies(CancellationToken cancellationToken = default)
        {
            Page<DistributionPolicyItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DistributionPolicyItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves an existing distribution policy by Id. </summary>
        /// <param name="distributionPolicyId"> The Id of the distribution Policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> GetDistributionPolicyAsync(string distributionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicy)}");
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetDistributionPolicy)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteDistributionPolicyAsync(distributionPolicyId, cancellationToken)
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteDistributionPolicy(distributionPolicyId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name,
                    ExceptionRules = options.ExceptionRules,
                };

                return await RestClient.UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
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

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="options"> (Optional) Options for creating an exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> CreateExceptionPolicy(
            CreateExceptionPolicyOptions options = default,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name,
                    ExceptionRules = options.ExceptionRules,
                };

                return RestClient.UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="options"> Options for updating exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> UpdateExceptionPolicyAsync(
            UpdateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name,
                    ExceptionRules = options.ExceptionRules,
                };

                return await RestClient.UpsertExceptionPolicyAsync(
                        id: options.ExceptionPolicyId,
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

        /// <summary> Creates or updates a exception policy. </summary>
        /// <param name="options"> Options for updating exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> UpdateExceptionPolicy(
            UpdateExceptionPolicyOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = options.Name,
                    ExceptionRules = options.ExceptionRules,
                };

                return RestClient.UpsertExceptionPolicy(
                    id: options.ExceptionPolicyId,
                    patch: request,
                    cancellationToken: cancellationToken);
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
            async Task<Page<ExceptionPolicyItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesAsync(maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ExceptionPolicyItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken).ConfigureAwait(false);
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

        /// <summary> Retrieves existing exception policies. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ExceptionPolicyItem> GetExceptionPolicies(CancellationToken cancellationToken = default)
        {
            Page<ExceptionPolicyItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = RestClient.ListExceptionPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ExceptionPolicyItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = RestClient.ListExceptionPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
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

        /// <summary> Retrieves an existing exception policy by Id. </summary>
        /// <param name="exceptionPolicyId"> Id of the exception policy to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> GetExceptionPolicyAsync(string exceptionPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicy)}");
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetExceptionPolicy)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteExceptionPolicyAsync(exceptionPolicyId, cancellationToken)
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteExceptionPolicy(exceptionPolicyId, cancellationToken);
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
        public virtual async Task<Response<JobQueue>> CreateQueueAsync(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    Labels = options.Labels,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                return await RestClient.UpsertQueueAsync(
                        id: options.QueueId,
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

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for creating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<JobQueue> CreateQueue(
            CreateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(CreateQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    Labels = options.Labels,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                return RestClient.UpsertQueue(
                    id: options.QueueId,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for updating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<JobQueue>> UpdateQueueAsync(
            UpdateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    Labels = options.Labels,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                return await RestClient.UpsertQueueAsync(
                        id: options.QueueId,
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

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="options"> Options for updating a job queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<JobQueue> UpdateQueue(
            UpdateQueueOptions options,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(UpdateQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue()
                {
                    DistributionPolicyId = options.DistributionPolicyId,
                    Name = options.Name,
                    Labels = options.Labels,
                    ExceptionPolicyId = options.ExceptionPolicyId,
                };

                return RestClient.UpsertQueue(
                    id: options.QueueId,
                    patch: request,
                    cancellationToken: cancellationToken);
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
        public virtual AsyncPageable<JobQueueItem> GetQueuesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<JobQueueItem>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesAsync(maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<JobQueueItem>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesNextPageAsync(nextLink, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves existing queues. </summary>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<JobQueueItem> GetQueues(CancellationToken cancellationToken = default)
        {
            Page<JobQueueItem> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = RestClient.ListQueues(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<JobQueueItem> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response =
                        RestClient.ListQueuesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value,
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves an existing queue by Id. </summary>
        /// <param name="queueId"> Id of the queue to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<JobQueue>> GetQueueAsync(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<JobQueue> queue = await RestClient.GetQueueAsync(queueId, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<JobQueue> GetQueue(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<JobQueue> queue = RestClient.GetQueue(queueId, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteQueueAsync(queueId, cancellationToken)
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterAdministrationClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return RestClient.DeleteQueue(queueId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Queue
    }
}

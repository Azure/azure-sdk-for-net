﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
    public class RouterClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        internal JobRouterRestClient RestClient { get; }

        #region public constructors - all arguments need null check

        /// <summary> Initializes a new instance of <see cref="RouterClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        public RouterClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterClient"/>.</summary>
        /// <param name="connectionString">Connection string acquired from the Azure Communication Services resource.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterClient(string connectionString, RouterClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterClient(Uri endpoint, AzureKeyCredential keyCredential, RouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new RouterClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="RouterClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The TokenCredential used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public RouterClient(Uri endpoint, TokenCredential tokenCredential, RouterClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new RouterClientOptions())
        {
        }

        #endregion

        #region private constructors

        private RouterClient(ConnectionString connectionString, RouterClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        {
        }

        private RouterClient(string endpoint, TokenCredential tokenCredential, RouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        {
        }

        private RouterClient(string endpoint, AzureKeyCredential keyCredential, RouterClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        {
        }

        private RouterClient(string endpoint, HttpPipeline httpPipeline, RouterClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            RestClient = new JobRouterRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="RouterClient"/> for mocking.</summary>
        protected RouterClient()
        {
            _clientDiagnostics = null;
            RestClient = null;
        }

        #region ClassificationPolicy

        /// <summary> Creates or updates classification policy. </summary>
        /// <param name="id"> Unique identifier of this policy. </param>
        /// <param name="name"> (Optional) Friendly name of this policy. </param>
        /// <param name="queueSelectors"> (Optional) The rules to select a queue for a given job. </param>
        /// <param name="workerSelectors"> (Optional) The rules to attach worker label selectors to a given job. </param>
        /// <param name="prioritizationRule"> (Optional) The rules to determine a priority score for a given job. </param>
        /// <param name="fallbackQueueId"> (Optional) The fallback queue to select if the rules do not find a match. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> SetClassificationPolicyAsync(
            string id,
            string name = null,
            IEnumerable<QueueSelectorAttachment> queueSelectors = null,
            IEnumerable<WorkerSelectorAttachment> workerSelectors = null,
            RouterRule prioritizationRule = null,
            string fallbackQueueId = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = name,
                    FallbackQueueId = fallbackQueueId,
                    QueueSelectors = queueSelectors.ToList(),
                    WorkerSelectors = workerSelectors.ToList(),
                    PrioritizationRule = prioritizationRule
                };

                return await RestClient.UpsertClassificationPolicyAsync(
                        id: id,
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
        /// <param name="id"> Unique identifier of this policy. </param>
        /// <param name="name"> (Optional) Friendly name of this policy. </param>
        /// <param name="queueSelectors"> (Optional) The rules to select a queue for a given job. </param>
        /// <param name="workerSelectors"> (Optional) The rules to attach worker label selectors to a given job. </param>
        /// <param name="prioritizationRule"> (Optional) The rules to determine a priority score for a given job. </param>
        /// <param name="fallbackQueueId"> (Optional) The default queue to select if the rules do not find a match. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> SetClassificationPolicy(
            string id,
            string name = null,
            IEnumerable<QueueSelectorAttachment> queueSelectors = null,
            IEnumerable<WorkerSelectorAttachment> workerSelectors = null,
            RouterRule prioritizationRule = null,
            string fallbackQueueId = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new ClassificationPolicy()
                {
                    Name = name,
                    FallbackQueueId = fallbackQueueId,
                    QueueSelectors = queueSelectors.ToList(),
                    WorkerSelectors = workerSelectors.ToList(),
                    PrioritizationRule = prioritizationRule
                };

                return RestClient.UpsertClassificationPolicy(
                    id:id,
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
        public virtual AsyncPageable<PagedClassificationPolicy> GetClassificationPoliciesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedClassificationPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesAsync(maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelectors, x.PrioritizationRule, x.WorkerSelectors)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<PagedClassificationPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelectors, x.PrioritizationRule, x.WorkerSelectors)),
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
        public virtual Pageable<PagedClassificationPolicy> GetClassificationPolicies(CancellationToken cancellationToken = default)
        {
            Page<PagedClassificationPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelectors, x.PrioritizationRule, x.WorkerSelectors)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<PagedClassificationPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelectors, x.PrioritizationRule, x.WorkerSelectors)),
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
        /// <param name="id"> The Id of the classification policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ClassificationPolicy>> GetClassificationPolicyAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.GetClassificationPolicyAsync(id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing classification policy by Id. </summary>
        /// <param name="id"> The Id of the classification policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ClassificationPolicy> GetClassificationPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.GetClassificationPolicy(id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a Classification Policy by Id. </summary>
        /// <param name="id"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteClassificationPolicyAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteClassificationPolicyAsync(id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a Classification Policy by Id. </summary>
        /// <param name="id"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteClassificationPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteClassificationPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteClassificationPolicy(id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion ClassificationPolicy

        #region DistributionPolicy

        /// <summary> Creates or updates a distribution policy. </summary>
        /// <param name="id"> The Id of this policy. </param>
        /// <param name="offerTtlSeconds"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The policy governing the specific distribution method. </param>
        /// <param name="name"> (Optional) The human readable name of the policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerTtlSeconds"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> SetDistributionPolicyAsync(
            string id,
            double offerTtlSeconds,
            DistributionMode mode,
            string name = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNull(offerTtlSeconds, nameof(offerTtlSeconds));
            Argument.AssertNotNull(mode, nameof(mode));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(offerTtlSeconds, mode)
                {
                    Name = name,
                };

                return await RestClient.UpsertDistributionPolicyAsync(
                        id: id,
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

        /// <summary> Creates or updates a distribution policy. </summary>
        /// <param name="id"> The Id of this policy. </param>
        /// <param name="offerTtlSeconds"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The policy governing the specific distribution method. </param>
        /// <param name="name"> (Optional) The human readable name of the policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerTtlSeconds"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> SetDistributionPolicy(
            string id,
            double offerTtlSeconds,
            DistributionMode mode,
            string name = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNull(offerTtlSeconds, nameof(offerTtlSeconds));
            Argument.AssertNotNull(mode, nameof(mode));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new DistributionPolicy(offerTtlSeconds, mode)
                {
                    Name = name,
                };

                return RestClient.UpsertDistributionPolicy(
                    id: id,
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
        public virtual AsyncPageable<PagedDistributionPolicy> GetDistributionPoliciesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedDistributionPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesAsync(maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedDistributionPolicy(x.Id, x.Name, x.OfferTtlSeconds, x.Mode)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<PagedDistributionPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedDistributionPolicy(x.Id, x.Name, x.OfferTtlSeconds, x.Mode)),
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
        public virtual Pageable<PagedDistributionPolicy> GetDistributionPolicies(CancellationToken cancellationToken = default)
        {
            Page<PagedDistributionPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedDistributionPolicy(x.Id, x.Name, x.OfferTtlSeconds, x.Mode)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<PagedDistributionPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedDistributionPolicy(x.Id, x.Name, x.OfferTtlSeconds, x.Mode)),
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
        /// <param name="id"> The Id of the distribution Policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DistributionPolicy>> GetDistributionPolicyAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.GetDistributionPolicyAsync(id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing distribution policy by Id. </summary>
        /// <param name="id"> The Id of the distribution policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DistributionPolicy> GetDistributionPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.GetDistributionPolicy(id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete a distribution policy by Id. </summary>
        /// <param name="id"> The Id of the Distribution Policy</param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteDistributionPolicyAsync(string id,  CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteDistributionPolicyAsync(id, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete a distribution policy by Id. </summary>
        /// <param name="id"> The id of the Distribution policy </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteDistributionPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteDistributionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteDistributionPolicy(id, cancellationToken);
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
        /// <param name="id"> The id of the exception policy. </param>
        /// <param name="name"> (Optional) The name of the exception policy. </param>
        /// <param name="rules"> (Optional) A collection of exception rules on the exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> SetExceptionPolicyAsync(
            string id,
            string name = null,
            IDictionary<string, ExceptionRule> rules = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = name,
                    ExceptionRules = rules
                };

                return await RestClient.UpsertExceptionPolicyAsync(
                        id: id,
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
        /// <param name="id"> The id of the exception policy. </param>
        /// <param name="name"> (Optional) The name of the exception policy. </param>
        /// <param name="rules"> (Optional) A collection of exception rules on the exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> SetExceptionPolicy(
            string id,
            string name = null,
            IDictionary<string, ExceptionRule> rules = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new ExceptionPolicy()
                {
                    Name = name,
                    ExceptionRules = rules
                };

                return RestClient.UpsertExceptionPolicy(
                    id: id,
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
        public virtual AsyncPageable<PagedExceptionPolicy> GetExceptionPoliciesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedExceptionPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesAsync(maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<PagedExceptionPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesNextPageAsync(nextLink, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
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
        public virtual Pageable<PagedExceptionPolicy> GetExceptionPolicies(CancellationToken cancellationToken = default)
        {
            Page<PagedExceptionPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = RestClient.ListExceptionPolicies(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<PagedExceptionPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = RestClient.ListExceptionPoliciesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="id"> Id of the exception policy to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<ExceptionPolicy>> GetExceptionPolicyAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicy)}");
            scope.Start();
            try
            {
                Response<ExceptionPolicy> exceptionPolicy = await RestClient.GetExceptionPolicyAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ExceptionPolicy(exceptionPolicy.Value.Id, exceptionPolicy.Value.Name, exceptionPolicy.Value.ExceptionRules), exceptionPolicy.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing exception policy by Id. </summary>
        /// <param name="id"> Id of the exception policy to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<ExceptionPolicy> GetExceptionPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicy)}");
            scope.Start();
            try
            {
                Response<ExceptionPolicy> exceptionPolicy = RestClient.GetExceptionPolicy(id, cancellationToken);
                return Response.FromValue(new ExceptionPolicy(exceptionPolicy.Value.Id, exceptionPolicy.Value.Name, exceptionPolicy.Value.ExceptionRules), exceptionPolicy.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a exception policy by Id. </summary>
        /// <param name="id"> Id of the exception policy to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteExceptionPolicyAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteExceptionPolicyAsync(id, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a exception policy by Id. </summary>
        /// <param name="id"> Id of the exception policy to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteExceptionPolicy(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteExceptionPolicy)}");
            scope.Start();
            try
            {
                return RestClient.DeleteExceptionPolicy(id, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion ExceptionPolicy

        #region Job

        #region Create or update job with classification policy

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="id"> Id of the job </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="classificationPolicyId"> The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="queueId"> (Optional) If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="tags"> (Optional) A set of non-identifying attributes attached to this job. </param>
        /// <param name="notes"> (Optional) Notes attached to a job, sorted by timestamp. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> SetJobWithClassificationPolicyAsync(
            string id,
            string channelId,
            string classificationPolicyId,
            LabelCollection labels = default,
            string channelReference = default,
            string queueId = default,
            int? priority = default,
            IEnumerable<WorkerSelector> workerSelectors = default,
            LabelCollection tags = default,
            IDictionary<DateTimeOffset, string> notes = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new RouterJob()
                {
                    ChannelId = channelId,
                    ClassificationPolicyId = classificationPolicyId,
                    Labels = labels,
                    ChannelReference = channelReference,
                    QueueId = queueId,
                    Priority = priority,
                    RequestedWorkerSelectors = workerSelectors.ToList(),
                    Tags = tags,
                    Notes = notes != null ? new SortedDictionary<DateTimeOffset, string>(notes) : new SortedDictionary<DateTimeOffset, string>(),
                };

                return await RestClient.UpsertJobAsync(
                        id:id,
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
        /// <param name="id"> Id of the job </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="classificationPolicyId"> The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="queueId"> (Optional) If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="tags"> (Optional) A set of non-identifying attributes attached to this job. </param>
        /// <param name="notes"> (Optional) Notes attached to a job, sorted by timestamp. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="classificationPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> SetJobWithClassificationPolicy(
            string id,
            string channelId,
            string classificationPolicyId,
            LabelCollection labels = default,
            string channelReference = default,
            string queueId = default,
            int? priority = default,
            IEnumerable<WorkerSelector> workerSelectors = default,
            LabelCollection tags = default,
            IDictionary<DateTimeOffset, string> notes = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(classificationPolicyId, nameof(classificationPolicyId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new RouterJob()
                {
                    ChannelId = channelId,
                    ClassificationPolicyId = classificationPolicyId,
                    Labels = labels,
                    ChannelReference = channelReference,
                    QueueId = queueId,
                    Priority = priority,
                    RequestedWorkerSelectors = workerSelectors.ToList(),
                    Tags = tags,
                    Notes = notes != null ? new SortedDictionary<DateTimeOffset, string>(notes) : new SortedDictionary<DateTimeOffset, string>(),
                };

                return RestClient.UpsertJob(
                    id:id,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create or update job with classification policy

        #region Create or update job

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="id"> Id of the job </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="queueId"> If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="tags"> (Optional) A set of non-identifying attributes attached to this job. </param>
        /// <param name="notes"> (Optional) Notes attached to a job, sorted by timestamp. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> SetJobAsync(
            string id,
            string channelId,
            string queueId,
            LabelCollection labels = default,
            string channelReference = default,
            int? priority = default,
            IEnumerable<WorkerSelector> workerSelectors = default,
            LabelCollection tags = default,
            IDictionary<DateTimeOffset, string> notes = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob()
                {
                    ChannelId = channelId,
                    Labels = labels,
                    ChannelReference = channelReference,
                    QueueId = queueId,
                    Priority = priority,
                    RequestedWorkerSelectors = workerSelectors.ToList(),
                    Tags = tags,
                    Notes = notes != null ? new SortedDictionary<DateTimeOffset, string>(notes) : new SortedDictionary<DateTimeOffset, string>(),
                };

                return await RestClient.UpsertJobAsync(
                        id: id,
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
        /// <param name="id"> Id of the job </param>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="queueId"> If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="tags"> (Optional) A set of non-identifying attributes attached to this job. </param>
        /// <param name="notes"> (Optional) Notes attached to a job, sorted by timestamp. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> SetJob(
            string id,
            string channelId,
            string queueId,
            LabelCollection labels = default,
            string channelReference = default,
            int? priority = default,
            IEnumerable<WorkerSelector> workerSelectors = default,
            LabelCollection tags = default,
            IDictionary<DateTimeOffset, string> notes = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetJob)}");
            scope.Start();
            try
            {
                var request = new RouterJob()
                {
                    ChannelId = channelId,
                    Labels = labels,
                    ChannelReference = channelReference,
                    QueueId = queueId,
                    Priority = priority,
                    RequestedWorkerSelectors = workerSelectors.ToList(),
                    Tags = tags,
                    Notes = notes != null ? new SortedDictionary<DateTimeOffset, string>(notes) : new SortedDictionary<DateTimeOffset, string>(),
                };

                return RestClient.UpsertJob(
                    id: id,
                    patch: request,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create or update job

        /// <summary> Retrieves an existing job by Id. </summary>
        /// <param name="id"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> GetJobAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = await RestClient.GetJobAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(job.Value, job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing job by Id. </summary>
        /// <param name="id"> The Id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> GetJob(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = RestClient.GetJob(id, cancellationToken);
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
        public virtual async Task<Response<ReclassifyJobResponse>> ReclassifyJobAsync(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.ReclassifyJobActionAsync(
                    id: jobId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ReclassifyJobResponse(response.Value), response.GetRawResponse());
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
        public virtual Response<ReclassifyJobResponse> ReclassifyJob(
            string jobId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var response = RestClient.ReclassifyJobAction(
                    id: jobId,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new ReclassifyJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="dispositionCode"> (Optional) Customer supplied disposition code for specifying any short label </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., cancellation reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CancelJobResponse>> CancelJobAsync(
            string jobId,
            string dispositionCode = default,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.CancelJobActionAsync(
                        id: jobId,
                        note: note,
                        dispositionCode: dispositionCode,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(new CancelJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Submits request to cancel an existing job by Id while supplying free-form cancellation reason. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="dispositionCode"> (Optional) Customer supplied disposition code for specifying any short label </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., cancellation reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CancelJobResponse> CancelJob(
            string jobId,
            string dispositionCode = default,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CancelJobAction(
                    id: jobId,
                    note: note,
                    dispositionCode: dispositionCode,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new CancelJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="assignmentId"> The id used to assign the job to a worker. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., completion reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CompleteJobResponse>> CompleteJobAsync(
            string jobId,
            string assignmentId,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.CompleteJobActionAsync(
                        id: jobId,
                        assignmentId: assignmentId,
                        note: note,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(new CompleteJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Completes an assigned job. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="assignmentId"> The id used to assign the job to the worker. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., completion reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CompleteJobResponse> CompleteJob(
            string jobId,
            string assignmentId,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CompleteJobAction(
                    id: jobId,
                    assignmentId: assignmentId,
                    note: note,
                    cancellationToken: cancellationToken);

                return Response.FromValue(new CompleteJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="assignmentId"> The assignment within which the job is to be closed. </param>
        /// <param name="dispositionCode"> (Optional) Indicates the outcome of the job, populate this field with your own custom values. </param>
        /// <param name="closeTime"> (Optional) If provided, the future time at which to release the capacity. If not provided capacity will be released immediately. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., close reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CloseJobResponse>> CloseJobAsync(
            string jobId,
            string assignmentId,
            string dispositionCode = default,
            DateTimeOffset? closeTime = default,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                var closeJob = new CloseJobRequest(assignmentId)
                {
                    CloseTime = closeTime,
                    DispositionCode = dispositionCode,
                    Note = note,
                };

                var response = await RestClient.CloseJobActionAsync(
                        id: jobId,
                        assignmentId: assignmentId,
                        dispositionCode: dispositionCode,
                        closeTime: closeTime,
                        note: note,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(new CloseJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Closes a completed job. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="assignmentId"> The assignment within which the job is to be closed. </param>
        /// <param name="dispositionCode"> (Optional) Indicates the outcome of the job, populate this field with your own custom values. </param>
        /// <param name="closeTime"> (Optional) If provided, the future time at which to release the capacity. If not provided capacity will be released immediately. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., close reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CloseJobResponse> CloseJob(
            string jobId,
            string assignmentId,
            string dispositionCode = default,
            DateTimeOffset? closeTime = default,
            string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                var response = RestClient.CloseJobAction(
                    id: jobId,
                    assignmentId: assignmentId,
                    dispositionCode: dispositionCode,
                    closeTime: closeTime,
                    note: note,
                    cancellationToken: cancellationToken);
                return Response.FromValue(new CloseJobResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="status"> (Optional) If specified, filter jobs by status. </param>
        /// <param name="queueId"> (Optional) If specified, filter jobs by queue. </param>
        /// <param name="channelId"> (Optional) If specified, filter jobs by channel. </param>
        /// <param name="maxPageSize">(Optional) The maximum number of results to be returned per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<PagedJob> GetJobsAsync(
            JobStateSelector? status = default,
            string queueId = default,
            string channelId = default,
            int? maxPageSize = default,
            CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedJob>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient.ListJobsAsync(
                            status: status,
                            queueId: queueId,
                            channelId: channelId,
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

            async Task<Page<PagedJob>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient
                        .ListJobsNextPageAsync(
                            nextLink: nextLink,
                            status: status,
                            queueId: queueId,
                            channelId: channelId,
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
        /// <param name="status"> (Optional) If specified, filter jobs by status. </param>
        /// <param name="queueId"> (Optional) If specified, filter jobs by queue. </param>
        /// <param name="channelId"> (Optional) If specified, filter jobs by channel. </param>
        /// <param name="maxPageSize">(Optional) The maximum number of results to be returned per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<PagedJob> GetJobs(
            JobStateSelector? status = default,
            string queueId = default,
            string channelId = default,
            int? maxPageSize = default,
            CancellationToken cancellationToken = default)
        {
            Page<PagedJob> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient.ListJobs(
                        status: status,
                        queueId: queueId,
                        channelId: channelId,
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

            Page<PagedJob> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient
                        .ListJobsNextPage(
                            nextLink: nextLink,
                            status: status,
                            queueId: queueId,
                            channelId: channelId,
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
        public virtual async Task<Response<JobPositionDetails>> GetInQueuePositionAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetInQueuePosition)}");
            scope.Start();
            try
            {
                Response<JobPositionDetails> job = await RestClient.GetInQueuePositionAsync(jobId, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<JobPositionDetails> GetInQueuePosition(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetInQueuePosition)}");
            scope.Start();
            try
            {
                Response<JobPositionDetails> job = RestClient.GetInQueuePosition(jobId, cancellationToken);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteJob)}");
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteJob)}");
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
        public virtual async Task<Response<AcceptJobOfferResponse>> AcceptJobAsync(
            string workerId,
            string offerId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(AcceptJob)}");
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
        public virtual Response<AcceptJobOfferResponse> AcceptJob(
            string workerId,
            string offerId,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(AcceptJob)}");
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
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="offerId"> The Id of the Job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="offerId"/> or <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DeclineJobOfferResponse>> DeclineJobAsync(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeclineJob)}");
            scope.Start();
            try
            {
                var response = await RestClient.DeclineJobActionAsync(
                        workerId: workerId,
                        offerId: offerId,
                        cancellationToken: cancellationToken)
                    .ConfigureAwait(false);

                return Response.FromValue(new DeclineJobOfferResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Declines an offer to work on a job. </summary>
        /// <param name="workerId"> The Id of the Worker. </param>
        /// <param name="offerId"> The Id of the Job offer. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="offerId"/> or <paramref name="workerId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DeclineJobOfferResponse> DeclineJob(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeclineJob)}");
            scope.Start();
            try
            {
                var response = RestClient.DeclineJobAction(
                    workerId: workerId,
                    offerId: offerId,
                    cancellationToken: cancellationToken);

                return Response.FromValue(new DeclineJobOfferResponse(response.Value), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Offer

        #region Queue

        /// <summary> Creates or updates a queue. </summary>
        /// <param name="id">  The id of this queue. </param>
        /// <param name="distributionPolicyId"> The ID of the distribution policy that will determine how a job is distributed to workers. </param>
        /// <param name="name"> (Optional) The name of this queue. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue to assign a job. </param>
        /// <param name="exceptionPolicyId"> (Optional) The ID of the exception policy that determines various job escalation rules. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<JobQueue>> SetQueueAsync(
            string id,
            string distributionPolicyId,
            string name = default,
            LabelCollection labels = default,
            string exceptionPolicyId = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue(distributionPolicyId)
                {
                    Name = name,
                    Labels = labels,
                    ExceptionPolicyId = exceptionPolicyId
                };

                return await RestClient.UpsertQueueAsync(
                        id:id,
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
        /// <param name="id"> The id of this queue. </param>
        /// <param name="distributionPolicyId">  The ID of the distribution policy that will determine how a job is distributed to workers. </param>
        /// <param name="name"> (Optional) The name of this queue. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue to assign a job. </param>
        /// <param name="exceptionPolicyId"> (Optional) The ID of the exception policy that determines various job escalation rules. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="distributionPolicyId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<JobQueue> SetQueue(string id, string distributionPolicyId, string name = default, LabelCollection labels = default, string exceptionPolicyId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetQueue)}");
            scope.Start();
            try
            {
                var request = new JobQueue(distributionPolicyId)
                {
                    Name = name,
                    Labels = labels,
                    ExceptionPolicyId = exceptionPolicyId
                };

                return RestClient.UpsertQueue(
                    id: id,
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
        public virtual AsyncPageable<PagedQueue> GetQueuesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedQueue>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesAsync(maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedQueue(x.Id, x.Name, x.DistributionPolicyId, x._labels, x.ExceptionPolicyId)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<PagedQueue>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesNextPageAsync(nextLink, maxPageSize, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedQueue(x.Id, x.Name, x.DistributionPolicyId, x._labels, x.ExceptionPolicyId)),
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
        public virtual Pageable<PagedQueue> GetQueues(CancellationToken cancellationToken = default)
        {
            Page<PagedQueue> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = RestClient.ListQueues(maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedQueue(x.Id, x.Name, x.DistributionPolicyId, x._labels, x.ExceptionPolicyId)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<PagedQueue> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response =
                        RestClient.ListQueuesNextPage(nextLink, maxPageSize, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new PagedQueue(x.Id, x.Name, x.DistributionPolicyId, x._labels, x.ExceptionPolicyId)),
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
        /// <param name="id"> Id of the queue to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<JobQueue>> GetQueueAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<JobQueue> queue = await RestClient.GetQueueAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing queue by Id. </summary>
        /// <param name="id"> Id of the queue to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public virtual Response<JobQueue> GetQueue(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueue)}");
            scope.Start();
            try
            {
                Response<JobQueue> queue = RestClient.GetQueue(id, cancellationToken);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves queue statistics by Id. </summary>
        /// <param name="id"> Id of the queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<QueueStatistics>> GetQueueStatisticsAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueueStatistics)}");
            scope.Start();
            try
            {
                Response<QueueStatistics> queue = await RestClient.GetQueueStatisticsAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves queue statistics by Id. </summary>
        /// <param name="id"> Id of the queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        public virtual Response<QueueStatistics> GetQueueStatistics(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueueStatistics)}");
            scope.Start();
            try
            {
                Response<QueueStatistics> queue = RestClient.GetQueueStatistics(id, cancellationToken);
                return Response.FromValue(queue.Value, queue.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a queue by Id. </summary>
        /// <param name="id"> Id of the queue to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteQueueAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteQueueAsync(id, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a queue by Id. </summary>
        /// <param name="id"> Id of the queue to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteQueue(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteQueue)}");
            scope.Start();
            try
            {
                return RestClient.DeleteQueue(id, cancellationToken);
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
        /// <param name="id"> Unique key that identifies this worker. </param>
        /// <param name="totalCapacity"> Total capacity that can be consumed by engaged sockets under this worker. </param>
        /// <param name="queueIds"> (Optional) The queue IDs to assign for this worker. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the distribution policy to match the worker according to specific rules. </param>
        /// <param name="channelConfigurations"> (Optional) A collection of channels and cost that define how the worker can do concurrent work. </param>
        /// /// <param name="availableForOffers"> A flag indicating this worker is open to receive offers or not. </param>
        /// /// <param name="tags"> (Optional) A set of key/value pairs used by the distribution policy to match the worker according to specific rules. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> SetWorkerAsync(
            string id,
            int totalCapacity = default,
            IEnumerable<string> queueIds = default,
            LabelCollection labels = default,
            IDictionary<string, ChannelConfiguration> channelConfigurations = default,
            bool availableForOffers = default,
            LabelCollection tags = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = totalCapacity,
                    QueueAssignments = queueIds?.ToDictionary(x => x, x => new QueueAssignment()),
                    Labels = labels,
                    ChannelConfigurations = channelConfigurations,
                    AvailableForOffers = availableForOffers,
                    Tags = tags
                };

                var response = await RestClient.UpsertWorkerAsync(
                        workerId: id,
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
        /// <param name="id"> Unique key that identifies this worker. </param>
        /// <param name="totalCapacity"> Total capacity that can be consumed by engaged sockets under this worker. </param>
        /// <param name="queueIds"> (Optional) The queue IDs to assign for this worker. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the distribution policy to match the worker according to specific rules. </param>
        /// <param name="channelConfigurations"> (Optional) A collection of channels and cost that define how the worker can do concurrent work. </param>
        /// /// <param name="availableForOffers"> A flag indicating this worker is open to receive offers or not. </param>
        /// /// <param name="tags"> (Optional) A set of key/value pairs used by the distribution policy to match the worker according to specific rules. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> SetWorker(
            string id,
            int totalCapacity = default,
            IEnumerable<string> queueIds = default,
            LabelCollection labels = default,
            IDictionary<string, ChannelConfiguration> channelConfigurations = default,
            bool availableForOffers = default,
            LabelCollection tags = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetWorker)}");
            scope.Start();
            try
            {
                var request = new RouterWorker()
                {
                    TotalCapacity = totalCapacity,
                    QueueAssignments = queueIds?.ToDictionary(x => x, x => new QueueAssignment()),
                    Labels = labels,
                    ChannelConfigurations = channelConfigurations,
                    AvailableForOffers = availableForOffers,
                    Tags = tags
                };

                var response = RestClient.UpsertWorker(
                    workerId: id,
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

        /// <summary> Retrieves existing workers. Pass status and Channel Id to filter workers further. </summary>
        /// <param name="status">(Optional) If specified, filter workers by worker status.</param>
        /// <param name="channelId"> Worker available in the particular channel. </param>
        /// <param name="queueId"> (Optional) If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity">
        /// (Optional) If set to true, select only workers who have capacity for the channel specified by <paramref name="channelId"/> or for any channel if <paramref name="channelId"/> not specified.
        /// If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false.
        /// </param>
        /// <param name="maxPageSize"> The maximum number of results to be returned per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<PagedWorker> GetWorkersAsync(
            WorkerStateSelector? status = default,
            string channelId = default,
            string queueId = default,
            bool? hasCapacity = default,
            int? maxPageSize = default,
            CancellationToken cancellationToken = default)
        {
            async Task<Page<PagedWorker>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = await RestClient.ListWorkersAsync(
                        status: status,
                        channelId: channelId,
                        queueId: queueId,
                        hasCapacity: hasCapacity,
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

            async Task<Page<PagedWorker>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = await RestClient
                        .ListWorkersNextPageAsync(nextLink, status, channelId, queueId, hasCapacity, maxPageSize, cancellationToken)
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
        /// <param name="status">(Optional) If specified, filter workers by worker status.</param>
        /// <param name="channelId"> Worker available in the particular channel. </param>
        /// <param name="queueId"> (Optional) If specified, select workers who are assigned to this queue. </param>
        /// <param name="hasCapacity">
        /// (Optional) If set to true, select only workers who have capacity for the channel specified by <paramref name="channelId"/> or for any channel if <paramref name="channelId"/> not specified.
        /// If set to false, then will return all workers including workers without any capacity for jobs. Defaults to false.
        /// </param>
        /// <param name="maxPageSize"> The maximum number of results to be returned per page. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<PagedWorker> GetWorkers(
            WorkerStateSelector? status = default,
            string channelId = default,
            string queueId = default,
            bool? hasCapacity = default,
            int? maxPageSize = default,
            CancellationToken cancellationToken = default)
        {
            Page<PagedWorker> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = RestClient.ListWorkers(
                        status,
                        channelId,
                        queueId,
                        hasCapacity,
                        maxPageSize,
                        cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<PagedWorker> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = RestClient
                        .ListWorkersNextPage(nextLink, status, channelId, queueId, hasCapacity, maxPageSize, cancellationToken);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorker)}");
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorker)}");
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

        #endregion Worker
    }
}

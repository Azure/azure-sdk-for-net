﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.JobRouter.Models;

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

        /// <summary> Creates or updates a channel. </summary>
        /// <param name="id"> The id of the channel. </param>
        /// <param name="name"> (Optional) The name of the channel. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<UpsertChannelResponse>> SetChannelAsync(string id, string name = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetChannel)}");
            scope.Start();
            try
            {
                var body = new UpsertChannelRequest(id)
                {
                    Name = name
                };

                return await RestClient.CreateOrUpdateChannelAsync(body, null, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a channel. </summary>
        /// <param name="id"> The id of the channel. </param>
        /// <param name="name"> (Optional) The name of the channel. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        ///  <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<UpsertChannelResponse> SetChannel(string id, string name = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetChannel)}");
            scope.Start();
            try
            {
                var body = new UpsertChannelRequest(id)
                {
                    Name = name
                };

                return RestClient.CreateOrUpdateChannel(body, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves channels. </summary>
        /// <param name="type"> (Optional) Specifies "ManagedChannels" or "CustomChannels", left blank returns all channels. </param>
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterChannel> GetChannelsAsync(string type = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RouterChannel>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannels)}");
                scope.Start();
                try
                {
                    Response<ChannelCollection> response = await RestClient
                        .ListChannelsAsync(type, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterChannel(x.Id, x.Name, x.AcsManaged)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterChannel>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannels)}");
                scope.Start();
                try
                {
                    Response<ChannelCollection> response = await RestClient
                        .ListChannelsNextPageAsync(nextLink, type, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterChannel(x.Id, x.Name, x.AcsManaged)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Retrieves channels. </summary>
        /// <param name="type"> (Optional) Specifies "ManagedChannels" or "CustomChannels", left blank returns all channels. </param>
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterChannel> GetChannels(string type = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<RouterChannel> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannels)}");
                scope.Start();
                try
                {
                    Response<ChannelCollection> response =  RestClient
                        .ListChannels(type, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterChannel(x.Id, x.Name, x.AcsManaged)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterChannel> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannels)}");
                scope.Start();
                try
                {
                    Response<ChannelCollection> response = RestClient
                        .ListChannelsNextPage(nextLink, type, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterChannel(x.Id, x.Name, x.AcsManaged)),
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

        /// <summary> Retrieves an existing channel by Id. </summary>
        /// <param name="id"> Id of the channel to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterChannel>> GetChannelAsync(string id,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannel)}");
            scope.Start();
            try
            {
                Response<RouterChannel> response = await RestClient.GetChannelAsync(id, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves an existing channel by Id. </summary>
        /// <param name="id"> Id of the channel to retrieve. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterChannel> GetChannel(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetChannel)}");
            scope.Start();
            try
            {
                Response<RouterChannel> response = RestClient.GetChannel(id, cancellationToken);
                return response;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a channel by Id. </summary>
        /// <param name="id"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeleteChannelAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteChannel)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteChannelAsync(id, null, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a channel by Id. </summary>
        /// <param name="id"> Id of the channel to delete. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeleteChannel(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeleteChannel)}");
            scope.Start();
            try
            {
                return RestClient.DeleteChannel(id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates classification policy. </summary>
        /// <param name="id"> Unique identifier of this policy. </param>
        /// <param name="name"> (Optional) Friendly name of this policy. </param>
        /// <param name="queueSelector"> (Optional) The rules to select a queue for a given job. </param>
        /// <param name="workerSelectors"> (Optional) The rules to attach worker label selectors to a given job. </param>
        /// <param name="prioritizationRule"> (Optional) The rules to determine a priority score for a given job. </param>
        /// <param name="fallbackQueueId"> (Optional) The fallback queue to select if the rules do not find a match. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<UpsertClassificationPolicyResponse>> SetClassificationPolicyAsync(
            string id, string name = null, QueueSelector queueSelector = null, IEnumerable<LabelSelectorAttachment> workerSelectors = null, RouterRule prioritizationRule = null, string fallbackQueueId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertClassificationPolicyRequest(id)
                {
                    Name = name,
                    FallbackQueueId = fallbackQueueId,
                    QueueSelector = queueSelector,
                    WorkerSelectors = workerSelectors,
                    PrioritizationRule = prioritizationRule
                };

                return await RestClient.CreateOrUpdateClassificationPolicyAsync(request, cancellationToken)
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
        /// <param name="queueSelector"> (Optional) The rules to select a queue for a given job. </param>
        /// <param name="workerSelectors"> (Optional) The rules to attach worker label selectors to a given job. </param>
        /// <param name="prioritizationRule"> (Optional) The rules to determine a priority score for a given job. </param>
        /// <param name="fallbackQueueId"> (Optional) The default queue to select if the rules do not find a match. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<UpsertClassificationPolicyResponse> SetClassificationPolicy(
            string id, string name = null, QueueSelector queueSelector = null, IEnumerable<LabelSelectorAttachment> workerSelectors = null, RouterRule prioritizationRule = null, string fallbackQueueId = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertClassificationPolicyRequest(id)
                {
                    Name = name,
                    FallbackQueueId = fallbackQueueId,
                    QueueSelector = queueSelector,
                    WorkerSelectors = workerSelectors,
                    PrioritizationRule = prioritizationRule
                };

                return RestClient.CreateOrUpdateClassificationPolicy(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing classification policies. </summary>
        /// <param name="continuationToken"> (Optional) The token used to request the next page. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ClassificationPolicy> GetClassificationPoliciesAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ClassificationPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesAsync(maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelector, x.PrioritizationRule, x.WorkerSelectors)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ClassificationPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = await RestClient
                        .ListClassificationPoliciesNextPageAsync(nextLink, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelector, x.PrioritizationRule, x.WorkerSelectors)),
                        response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="continuationToken"> (Optional) The token used to request the next page. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ClassificationPolicy> GetClassificationPolicies(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<ClassificationPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPolicies(maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelector, x.PrioritizationRule, x.WorkerSelectors)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ClassificationPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetClassificationPolicies)}");
                scope.Start();
                try
                {
                    Response<ClassificationPolicyCollection> response = RestClient
                        .ListClassificationPoliciesNextPage(nextLink, maxPageSize, continuationToken,
                            cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ClassificationPolicy(x.Id, x.Name, x.FallbackQueueId, x.QueueSelector, x.PrioritizationRule, x.WorkerSelectors)),
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
                return await RestClient.DeleteClassificationPolicyAsync(id, null, cancellationToken).ConfigureAwait(false);
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
                return RestClient.DeleteClassificationPolicy(id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a distribution policy. </summary>
        /// <param name="id"> The Id of this policy. </param>
        /// <param name="offerTTL"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The policy governing the specific distribution method. </param>
        /// <param name="name"> (Optional) The human readable name of the policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerTTL"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<UpsertDistributionPolicyResponse>> SetDistributionPolicyAsync(string id, TimeSpan offerTTL, DistributionMode mode, string name = default,  CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNull(offerTTL.ToString(), nameof(offerTTL));
            Argument.AssertNotNull(mode, nameof(mode));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertDistributionPolicyRequest(id, offerTTL, mode);
                request.Name = name;

                return await RestClient.CreateOrUpdateDistributionPolicyAsync(request, cancellationToken)
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
        /// <param name="offerTTL"> The amount of time before an offer expires. </param>
        /// <param name="mode"> The policy governing the specific distribution method. </param>
        /// <param name="name"> (Optional) The human readable name of the policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="offerTTL"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<UpsertDistributionPolicyResponse> SetDistributionPolicy(string id, TimeSpan offerTTL, DistributionMode mode, string name = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNull(offerTTL.ToString(), nameof(offerTTL));
            Argument.AssertNotNull(mode, nameof(mode));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetDistributionPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertDistributionPolicyRequest(id, offerTTL, mode);
                request.Name = name;

                return RestClient.CreateOrUpdateDistributionPolicy(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing distribution policies. </summary>
        /// <param name="continuationToken"> (Optional) The token used to request the next page. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<DistributionPolicy> GetDistributionPoliciesAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DistributionPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesAsync(maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new DistributionPolicy(x.Id, x.Name, x.OfferTTL, x.Mode)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<DistributionPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = await RestClient
                        .ListDistributionPoliciesNextPageAsync(nextLink, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new DistributionPolicy(x.Id, x.Name, x.OfferTTL, x.Mode)),
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
        /// <param name="continuationToken"> (Optional) The token used to request the next page. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DistributionPolicy> GetDistributionPolicies(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<DistributionPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPolicies(maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new DistributionPolicy(x.Id, x.Name, x.OfferTTL, x.Mode)),
                        response.Value.NextLink,
                        response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<DistributionPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetDistributionPolicies)}");
                scope.Start();
                try
                {
                    Response<DistributionPolicyCollection> response = RestClient
                        .ListDistributionPoliciesNextPage(nextLink, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new DistributionPolicy(x.Id, x.Name, x.OfferTTL, x.Mode)),
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
                Response<DistributionPolicy> distributionPolicy = await RestClient.GetDistributionPolicyAsync(id, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DistributionPolicy(distributionPolicy.Value.Id, distributionPolicy.Value.Name, distributionPolicy.Value.OfferTTL, distributionPolicy.Value.Mode), distributionPolicy.GetRawResponse());
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
                Response<DistributionPolicy> distributionPolicy = RestClient.GetDistributionPolicy(id, cancellationToken);
                return Response.FromValue(new DistributionPolicy(distributionPolicy.Value.Id, distributionPolicy.Value.Name, distributionPolicy.Value.OfferTTL, distributionPolicy.Value.Mode), distributionPolicy.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Delete a distribution policy by Id. </summary>
        /// <param name="id"> The Id of the Distribution Policy </param>
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
                return await RestClient.DeleteDistributionPolicyAsync(id, null, cancellationToken)
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
                return RestClient.DeleteDistributionPolicy(id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new exception policy. </summary>
        /// <param name="id"> The id of the exception policy. </param>
        /// <param name="name"> (Optional) The name of the exception policy. </param>
        /// <param name="rules"> (Optional) A collection of exception rules on the exception policy. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<UpsertExceptionPolicyResponse>> SetExceptionPolicyAsync(string id, string name = null, IEnumerable<ExceptionRule> rules = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertExceptionPolicyRequest(id);
                request.Name = name;
                request.ExceptionRules = rules;

                return await RestClient.CreateOrUpdateExceptionPolicyAsync(request, cancellationToken)
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
        public virtual Response<UpsertExceptionPolicyResponse> SetExceptionPolicy(string id, string name = null, IEnumerable<ExceptionRule> rules = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetExceptionPolicy)}");
            scope.Start();
            try
            {
                var request = new UpsertExceptionPolicyRequest(id);
                request.Name = name;
                request.ExceptionRules = rules;

                return RestClient.CreateOrUpdateExceptionPolicy(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing exception policies. </summary>
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<ExceptionPolicy> GetExceptionPoliciesAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ExceptionPolicy>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterChannel)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesAsync(maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ExceptionPolicy>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = await RestClient.ListExceptionPoliciesNextPageAsync(nextLink, maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new ExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<ExceptionPolicy> GetExceptionPolicies(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<ExceptionPolicy> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterChannel)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response =
                        RestClient.ListExceptionPolicies(maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ExceptionPolicy> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetExceptionPolicies)}");
                scope.Start();

                try
                {
                    Response<ExceptionPolicyCollection> response = RestClient.ListExceptionPoliciesNextPage(nextLink, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new ExceptionPolicy(x.Id, x.Name, x.ExceptionRules)), response.Value.NextLink, response.GetRawResponse());
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
                return await RestClient.DeleteExceptionPolicyAsync(id, null, cancellationToken)
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
                return RestClient.DeleteExceptionPolicy(id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #region Create job with classification policy

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// /// <param name="classificationPolicyId"> The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="queueId"> (Optional) If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CreateJobResponse>> CreateJobWithClassificationPolicyAsync(
            string channelId,
            string classificationPolicyId,
            LabelCollection labels = default,
            string channelReference = null,
            string queueId = null,
            int? priority = null,
            IEnumerable<LabelSelector> workerSelectors = default,
           CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new CreateJobRequest(channelId);

                request.WorkerSelectors = workerSelectors;
                request.Labels = labels;
                request.ChannelReference = channelReference;
                request.ClassificationPolicyId = classificationPolicyId;
                request.QueueId = queueId;
                request.Priority = priority;

                return await RestClient.CreateJobAsync(request, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// /// <param name="classificationPolicyId"> The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="queueId"> (Optional) If classification policy does not specify a queue selector or a default queue id, then you must specify a queue. Otherwise, queue will be selected based on classification policy. </param>
        /// <param name="priority"> (Optional) The integer value of priority of this job. If priority is not defined then use prioritization rule from the classification policy if its specified. Otherwise defaults to 1. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CreateJobResponse> CreateJobWithClassificationPolicy(
            string channelId,
            string classificationPolicyId,
            LabelCollection labels = default,
            string channelReference = null,
            string queueId = null,
            int? priority = null,
            IEnumerable<LabelSelector> workerSelectors = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CreateJobWithClassificationPolicy)}");
            scope.Start();
            try
            {
                var request = new CreateJobRequest(channelId);

                request.WorkerSelectors = workerSelectors;
                request.Labels = labels;
                request.ChannelReference = channelReference;
                request.ClassificationPolicyId = classificationPolicyId;
                request.QueueId = queueId;
                request.Priority = priority;

                return RestClient.CreateJob(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create job with classification policy

        #region Create job

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="queueId"> Id of queue where the job will be en-queued.  </param>
        /// <param name="priority"> Priority associated with job. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<CreateJobResponse>> CreateJobAsync(
            string channelId,
            string queueId,
            int? priority = null,
            string channelReference = null,
            LabelCollection labels = default,
            IEnumerable<LabelSelector> workerSelectors = default,
           CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CreateJob)}");
            scope.Start();
            try
            {
                var request = new CreateJobRequest(channelId);

                request.WorkerSelectors = workerSelectors;
                request.Labels = labels;
                request.ChannelReference = channelReference;
                request.QueueId = queueId;
                request.Priority = priority;

                return await RestClient.CreateJobAsync(request, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a new job to be routed. </summary>
        /// <param name="channelId"> The channel or modality upon which this job will be executed. </param>
        /// <param name="queueId"> Id of queue where the job will be en-queued.  </param>
        /// <param name="priority"> Priority associated with job. </param>
        /// <param name="channelReference"> (Optional) Reference to an external parent context, eg. call ID. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="workerSelectors"> (Optional) A collection of label selectors a worker must satisfy in order to process this job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="channelId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<CreateJobResponse> CreateJob(
            string channelId,
            string queueId,
            int? priority = null,
            string channelReference = null,
            LabelCollection labels = default,
            IEnumerable<LabelSelector> workerSelectors = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(channelId, nameof(channelId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CreateJob)}");
            scope.Start();
            try
            {
                var request = new CreateJobRequest(channelId);

                request.WorkerSelectors = workerSelectors;
                request.Labels = labels;
                request.ChannelReference = channelReference;
                request.QueueId = queueId;
                request.Priority = priority;

                return RestClient.CreateJob(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        #endregion Create job

        /// <summary> Retrieves an existing job by Id. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> GetJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = await RestClient.GetJobAsync(jobId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new RouterJob(job.Value.Id, job.Value.ChannelReference, job.Value.JobStatus,
                    job.Value.EnqueueTimeUtc, job.Value.ChannelId, job.Value.ClassificationPolicyId, job.Value.QueueId, job.Value.Priority,
                    job.Value.DispositionCode, job.Value.WorkerSelectors, job.Value.Labels, job.Value.Assignments, job.Value.Notes), job.GetRawResponse());
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJob)}");
            scope.Start();
            try
            {
                Response<RouterJob> job = RestClient.GetJob(jobId, cancellationToken);
                return Response.FromValue(new RouterJob(job.Value.Id, job.Value.ChannelReference, job.Value.JobStatus,
                    job.Value.EnqueueTimeUtc, job.Value.ChannelId, job.Value.ClassificationPolicyId, job.Value.QueueId, job.Value.Priority,
                    job.Value.DispositionCode, job.Value.WorkerSelectors, job.Value.Labels, job.Value.Assignments, job.Value.Notes), job.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing jobs by queue. </summary>
        /// <param name="queueId"> The Id of the Queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterJob> GetEnqueuedJobsAsync(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            async Task<Page<RouterJob>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetEnqueuedJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient.ListEnqueuedJobsAsync(queueId, maxPageSize, null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference, x.JobStatus,
                        x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority, x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterJob>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetEnqueuedJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient
                        .ListEnqueuedJobsNextPageAsync(nextLink, queueId, maxPageSize, null, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference,
                            x.JobStatus,
                            x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority,
                            x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)), response.Value.NextLink,
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

        /// <summary> Retrieves existing jobs by queue. </summary>
        /// <param name="queueId"> The Id of the Queue. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterJob> GetEnqueuedJobs(string queueId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            Page<RouterJob> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetEnqueuedJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient.ListEnqueuedJobs(queueId, maxPageSize, null, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference, x.JobStatus,
                        x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority, x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterJob> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetEnqueuedJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient
                        .ListEnqueuedJobsNextPage(nextLink, queueId, maxPageSize, null, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference,
                            x.JobStatus,
                            x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority,
                            x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)), response.Value.NextLink,
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

        /// <summary> Updates the labels of an existing job by Id. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="labels"> A LabelCollection containing key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., update reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="labels"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> UpdateJobLabelsAsync(string jobId, LabelCollection labels,
            string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNull(labels, nameof(labels));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(UpdateJobLabels)}");
            scope.Start();
            try
            {
                var response = await RestClient.UpdateJobLabelsAsync(jobId,
                        labels.ToDictionary(x => x.Key, x => x.Value), note, cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId,
                        response.Value.QueueId,
                        response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors,
                        response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates the labels of an existing job by Id. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="labels"> A LabelCollection containing key/value pairs used by the classification policy to determine queue, priority and required abilities. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., update reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="labels"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> UpdateJobLabels(string jobId, LabelCollection labels, string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNull(labels, nameof(labels));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(UpdateJobLabels)}");
            scope.Start();
            try
            {
                var response = RestClient.UpdateJobLabels(jobId, labels.ToDictionary(x => x.Key, x => x.Value), note,
                    cancellationToken);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId,
                        response.Value.QueueId,
                        response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors,
                        response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates an existing job by Id and forcing it to be reclassified. </summary>
        /// <param name="jobId"> The id of the job. </param>
        /// <param name="classificationPolicyId"> (Optional) The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labelsToUpdate"> (Optional) Update or insert labels associate to a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterJob>> ReclassifyJobAsync(string jobId, string classificationPolicyId = default, LabelCollection labelsToUpdate = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var request = new ReclassifyJobRequest();
               request.ClassificationPolicyId = classificationPolicyId;
                request.LabelsToUpsert = labelsToUpdate;

                var response = await RestClient.ReclassifyJobAsync(jobId, request, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId, response.Value.QueueId,
                        response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors, response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Updates an existing job by Id and forcing it to be reclassified. </summary>
        /// <param name="jobId"> The Id of the Job. </param>
        /// <param name="classificationPolicyId"> (Optional) The classification policy that will determine queue, priority and required abilities. </param>
        /// <param name="labelsToUpdate"> (Optional) Update or insert labels associate to a job. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/></exception>
        ///<exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterJob> ReclassifyJob(string jobId, string classificationPolicyId = default, LabelCollection labelsToUpdate = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReclassifyJob)}");
            scope.Start();
            try
            {
                var request = new ReclassifyJobRequest();
                request.ClassificationPolicyId = classificationPolicyId;
                request.LabelsToUpsert = labelsToUpdate;

                var response = RestClient.ReclassifyJob(jobId, request, cancellationToken);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId, response.Value.QueueId,
                        response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors, response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing job&apos;s queueId, priority, requiredAbilities and labels.
        /// The following attributes can be updated:
        /// 1. QueuedId: (Optional) Can be used to assign a job to particular queue.
        /// 2. Priority: (Optional) Can be used to set job priority.
        /// 3. RequiredAbilities: (Optional) Can be used to set required abilities on a job. Note, that all previous abilities will be overridden.
        /// </summary>
        /// <param name="jobId"> The Id of the job to be updated. </param>
        /// <param name="queueId"> (Optional) Updated QueueId. </param>
        /// <param name="priority"> (Optional) Updated Priority. </param>
        /// <param name="workerSelectors"> (Optional) Updated WorkerSelectors. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., update reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> or <paramref name="queueId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workerSelectors"/> or <paramref name="workerSelectors"/> is null. </exception>
        public virtual async Task<Response<RouterJob>> UpdateJobClassificationAsync(string jobId,
            string queueId = default, int priority = default, List<LabelSelector> workerSelectors = default, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            Argument.AssertNotNull(workerSelectors, nameof(workerSelectors));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(UpdateJobClassification)}");
            scope.Start();
            try
            {
                var response = await RestClient.UpdateJobClassificationAsync(jobId, queueId, priority, workerSelectors, note, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId, response.Value.QueueId, response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors, response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing job&apos;s queueId, priority, requiredAbilities and labels.
        /// The following attributes can be updated:
        /// 1. QueuedId: (Optional) Can be used to assign a job to particular queue.
        /// 2. Priority: (Optional) Can be used to set job priority.
        /// 3. RequiredAbilities: (Optional) Can be used to set required abilities on a job. Note, that all previous abilities will be overridden.
        /// </summary>
        /// <param name="jobId"> The Id of the job to be updated. </param>
        /// <param name="queueId"> (Optional) Updated QueueId. </param>
        /// <param name="priority"> (Optional) Updated Priority. </param>
        /// <param name="workerSelectors"> (Optional) Updated WorkerSelectors. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., update reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> or <paramref name="queueId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="workerSelectors"/> or <paramref name="workerSelectors"/> is null. </exception>
        public virtual Response<RouterJob> UpdateJobClassification(string jobId,
            string queueId = default, int priority = default, List<LabelSelector> workerSelectors = default, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));
            Argument.AssertNotNull(workerSelectors, nameof(workerSelectors));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(UpdateJobClassification)}");
            scope.Start();
            try
            {
                var response = RestClient.UpdateJobClassification(jobId, queueId, priority, workerSelectors, note, cancellationToken);
                return Response.FromValue(
                    new RouterJob(response.Value.Id, response.Value.ChannelReference, response.Value.JobStatus,
                        response.Value.EnqueueTimeUtc, response.Value.ChannelId, response.Value.ClassificationPolicyId, response.Value.QueueId, response.Value.Priority, response.Value.DispositionCode, response.Value.WorkerSelectors, response.Value.Labels, response.Value.Assignments, response.Value.Notes),
                    response.GetRawResponse());
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
        public virtual async Task<Response> CancelJobAsync(string jobId, string dispositionCode = default, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return await RestClient.CancelJobAsync(jobId, note, dispositionCode, cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response CancelJob(string jobId, string dispositionCode = default, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CancelJob)}");
            scope.Start();
            try
            {
                return RestClient.CancelJob(jobId, note, dispositionCode, CancellationToken.None);
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
        public virtual async Task<Response> CompleteJobAsync(string jobId, string assignmentId, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return await RestClient.CompleteJobAsync(jobId, assignmentId, note, cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response CompleteJob(string jobId, string assignmentId, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CompleteJob)}");
            scope.Start();
            try
            {
                return RestClient.CompleteJob(jobId, assignmentId, note, cancellationToken);
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
        /// <param name="releaseTime"> (Optional) If provided, the future time at which to release the capacity. If not provided capacity will be released immediately. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., close reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> CloseJobAsync(string jobId, string assignmentId,
            string dispositionCode = null, DateTimeOffset? releaseTime = null, string note = default,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                var closeJob = new CloseJobRequest(assignmentId);
                closeJob.DispositionCode = dispositionCode;
                closeJob.ReleaseTime = releaseTime;
                return await RestClient.CloseJobAsync(jobId, assignmentId, dispositionCode, releaseTime, note, cancellationToken)
                    .ConfigureAwait(false);
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
        /// <param name="releaseTime"> (Optional) If provided, the future time at which to release the capacity. If not provided capacity will be released immediately. </param>
        /// <param name="note"> (Optional) Customer supplied note, e.g., close reason. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response CloseJob(string jobId, string assignmentId, string dispositionCode = null,
            DateTimeOffset? releaseTime = null, string note = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(CloseJob)}");
            scope.Start();
            try
            {
                return RestClient.CloseJob(jobId, assignmentId, dispositionCode, releaseTime, note, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="status">(Optional) If specified, filter jobs by status. </param>
        /// <param name="continuationToken"> The continuation token to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterJob> GetJobsAsync(JobStateSelector? status = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RouterJob>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient.ListJobsAsync(status, maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference, x.JobStatus,
                        x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority, x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterJob>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = await RestClient
                        .ListJobsNextPageAsync(nextLink, status, maxPageSize, null, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference,
                            x.JobStatus,
                            x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority,
                            x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)), response.Value.NextLink,
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

        // <summary> Retrieves list of jobs based on filters. </summary>
        /// <param name="status">(Optional) If specified, filter jobs by status.</param>
        /// <param name="continuationToken"> The continuation token to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterJob> GetJobs(JobStateSelector? status = null, string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<RouterJob> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient.ListJobs(status, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference, x.JobStatus,
                        x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority, x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterJob> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetJobs)}");
                scope.Start();

                try
                {
                    Response<JobCollection> response = RestClient
                        .ListJobsNextPage(nextLink, status, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterJob(x.Id, x.ChannelReference,
                            x.JobStatus,
                            x.EnqueueTimeUtc, x.ChannelId, x.ClassificationPolicyId, x.QueueId, x.Priority,
                            x.DispositionCode, x.WorkerSelectors, x.Labels, x.Assignments, x.Notes)), response.Value.NextLink,
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
                return Response.FromValue(new JobPositionDetails(job.Value.JobId, job.Value.Position, job.Value.QueueId, job.Value.QueueLength), job.GetRawResponse());
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
                return Response.FromValue(new JobPositionDetails(job.Value.JobId, job.Value.Position, job.Value.QueueId, job.Value.QueueLength), job.GetRawResponse());
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
        public virtual async Task<Response<AcceptJobOfferResponse>> AcceptJobAsync(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(AcceptJob)}");
            scope.Start();
            try
            {
                return await RestClient.AcceptJobAsync(offerId, workerId, cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response<AcceptJobOfferResponse> AcceptJob(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(AcceptJob)}");
            scope.Start();
            try
            {
                return RestClient.AcceptJob(offerId, workerId, cancellationToken);
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
        public virtual async Task<Response> DeclineJobAsync(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeclineJob)}");
            scope.Start();
            try
            {
                return await RestClient.DeclineJobAsync(offerId, workerId, cancellationToken)
                    .ConfigureAwait(false);
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
        public virtual Response DeclineJob(string workerId, string offerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(offerId, nameof(offerId));
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeclineJob)}");
            scope.Start();
            try
            {
                return RestClient.DeclineJob(offerId, workerId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

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
        public virtual async Task<Response<UpsertQueueResponse>> SetQueueAsync(string id, string distributionPolicyId, string name = default, LabelCollection labels = default, string exceptionPolicyId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetQueue)}");
            scope.Start();
            try
            {
                var request = new UpsertQueueRequest(id, distributionPolicyId)
                {
                    Name = name,
                    Labels = labels,
                    ExceptionPolicyId = exceptionPolicyId
                };

                return await RestClient.CreateOrUpdateQueueAsync(request, cancellationToken)
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
        public virtual Response<UpsertQueueResponse> SetQueue(string id, string distributionPolicyId, string name = default, LabelCollection labels = default, string exceptionPolicyId = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            Argument.AssertNotNullOrWhiteSpace(distributionPolicyId, nameof(distributionPolicyId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(SetQueue)}");
            scope.Start();
            try
            {
                var request = new UpsertQueueRequest(id, distributionPolicyId)
                {
                    Name = name,
                    Labels = labels,
                    ExceptionPolicyId = exceptionPolicyId
                };

                return RestClient.CreateOrUpdateQueue(request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Retrieves existing queues. </summary>
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<JobQueue> GetQueuesAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<JobQueue>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterChannel)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesAsync(maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new JobQueue(x.Id, x.Name, x.DistributionPolicyId, x.Labels, x.ExceptionPolicyId)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<JobQueue>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = await RestClient.ListQueuesNextPageAsync(nextLink, maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new JobQueue(x.Id, x.Name, x.DistributionPolicyId, x.Labels, x.ExceptionPolicyId)), response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="continuationToken"> (Optional) Token for pagination. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<JobQueue> GetQueues(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<JobQueue> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterChannel)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response = RestClient.ListQueues(maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new JobQueue(x.Id, x.Name, x.DistributionPolicyId, x.Labels, x.ExceptionPolicyId)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<JobQueue> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetQueues)}");
                scope.Start();

                try
                {
                    Response<QueueCollection> response =
                        RestClient.ListQueuesNextPage(nextLink, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new JobQueue(x.Id, x.Name, x.DistributionPolicyId, x.Labels, x.ExceptionPolicyId)), response.Value.NextLink, response.GetRawResponse());
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
                return Response.FromValue(new JobQueue(queue.Value.Id, queue.Value.Name, queue.Value.DistributionPolicyId, queue.Value.Labels, queue.Value.ExceptionPolicyId), queue.GetRawResponse());
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
                return Response.FromValue(new JobQueue(queue.Value.Id, queue.Value.Name, queue.Value.DistributionPolicyId, queue.Value.Labels, queue.Value.ExceptionPolicyId), queue.GetRawResponse());
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
                return await RestClient.DeleteQueueAsync(id, null, cancellationToken)
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
                return RestClient.DeleteQueue(id, null, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Registers a worker to process jobs. </summary>
        /// <param name="id"> Unique key that identifies this worker. </param>
        /// <param name="totalCapacity"> Total capacity that can be consumed by engaged sockets under this worker. </param>
        /// <param name="queueIds"> (Optional) The queue IDs to assign for this worker. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used by the distribution policy to match the worker according to specific rules. </param>
        /// <param name="channelConfigurations"> (Optional) A collection of channels and cost that define how the worker can do concurrent work. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<RouterWorker>> RegisterWorkerAsync(string id, int totalCapacity, IEnumerable<string> queueIds = default, LabelCollection labels = default, IEnumerable<ChannelConfiguration> channelConfigurations = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(RegisterWorker)}");
            scope.Start();
            try
            {
                var request = new RegisterWorkerRequest(id, totalCapacity);
                request.QueueAssignments = queueIds?.Select(queueId => new QueueAssignment(queueId)).ToList();
                request.Labels = labels;
                request.ChannelConfigurations = channelConfigurations;

                var response = await RestClient.RegisterWorkerAsync(request, cancellationToken)
                    .ConfigureAwait(false);
                return Response.FromValue(
                    new RouterWorker(response.Value.Id, response.Value.State, response.Value.QueueAssignments, response.Value.TotalCapacity, response.Value.Labels, response.Value.ChannelConfigurations, response.Value.Offers, response.Value.AssignedJobs),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Registers a worker to process jobs. </summary>
        /// <param name="id"> Unique key that identifies this worker. </param>
        /// <param name="totalCapacity"> Total capacity that can be consumed by engaged sockets under this worker. </param>
        /// <param name="queueIds"> (Optional) The queue IDs to assign for this worker. </param>
        /// <param name="labels"> (Optional) A set of key/value pairs used to match the worker according to specific rules. </param>
        /// <param name="channelConfigurations"> (Optional) A collection of channels and cost that define how the worker can do concurrent work. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<RouterWorker> RegisterWorker(string id, int totalCapacity, IEnumerable<string> queueIds = default, LabelCollection labels = default, IEnumerable<ChannelConfiguration> channelConfigurations = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(RegisterWorker)}");
            scope.Start();
            try
            {
                var request = new RegisterWorkerRequest(id, totalCapacity);
                request.QueueAssignments = queueIds?.Select(queueId => new QueueAssignment(queueId)).ToList();
                request.Labels = labels;
                request.ChannelConfigurations = channelConfigurations;

                var response = RestClient.RegisterWorker(request, cancellationToken);
                return Response.FromValue(
                    new RouterWorker(response.Value.Id, response.Value.State, response.Value.QueueAssignments, response.Value.TotalCapacity, response.Value.Labels, response.Value.ChannelConfigurations, response.Value.Offers, response.Value.AssignedJobs),
                    response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deregisters a worker from processing jobs. </summary>
        /// <param name="id"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> DeregisterWorkerAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeregisterWorker)}");
            scope.Start();
            try
            {
                return await RestClient.DeregisterWorkerAsync(id, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deregisters a worker from processing jobs. </summary>
        /// <param name="id"> The Id of the Worker. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response DeregisterWorker(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(id, nameof(id));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(DeregisterWorker)}");
            scope.Start();
            try
            {
                return RestClient.DeregisterWorker(id, cancellationToken);
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
        /// <param name="continuationToken"> Token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<RouterWorker> GetWorkersAsync(
            WorkerStateSelector? status = null,
            string channelId = null,
            string queueId = null,
            bool? hasCapacity = null,
            string continuationToken = null,
            CancellationToken cancellationToken = default)
        {
            async Task<Page<RouterWorker>> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = await RestClient.ListWorkersAsync(status, channelId, queueId, hasCapacity, maxPageSize, continuationToken, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterWorker(x.Id, x.State, x.QueueAssignments, x.TotalCapacity, x.Labels, x.ChannelConfigurations, x.Offers, x.AssignedJobs)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RouterWorker>> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = await RestClient
                        .ListWorkersNextPageAsync(nextLink, status, channelId, queueId, hasCapacity, maxPageSize, continuationToken, cancellationToken)
                        .ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterWorker(x.Id, x.State, x.QueueAssignments, x.TotalCapacity, x.Labels, x.ChannelConfigurations, x.Offers, x.AssignedJobs)),
                        response.Value.NextLink, response.GetRawResponse());
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
        /// <param name="continuationToken"> Token for pagination. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<RouterWorker> GetWorkers(
            WorkerStateSelector? status = null,
            string channelId = null,
            string queueId = null,
            bool? hasCapacity = null,
            string continuationToken = null,
            CancellationToken cancellationToken = default)
        {
            Page<RouterWorker> FirstPageFunc(int? maxPageSize)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = RestClient.ListWorkers(status, channelId, queueId, hasCapacity, maxPageSize,
                        continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterWorker(x.Id, x.State, x.QueueAssignments, x.TotalCapacity, x.Labels, x.ChannelConfigurations, x.Offers, x.AssignedJobs)),
                        response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RouterWorker> NextPageFunc(string nextLink, int? maxPageSize)
            {
                using DiagnosticScope scope =
                    _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(GetWorkers)}");
                scope.Start();

                try
                {
                    Response<WorkerCollection> response = RestClient
                        .ListWorkersNextPage(nextLink, status, channelId, queueId, hasCapacity, maxPageSize, continuationToken, cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(x => new RouterWorker(x.Id, x.State, x.QueueAssignments, x.TotalCapacity, x.Labels, x.ChannelConfigurations, x.Offers, x.AssignedJobs)),
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
                return Response.FromValue(new RouterWorker(worker.Value.Id, worker.Value.State, worker.Value.QueueAssignments, worker.Value.TotalCapacity, worker.Value.Labels, worker.Value.ChannelConfigurations, worker.Value.Offers, worker.Value.AssignedJobs), worker.GetRawResponse());
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
                return Response.FromValue(new RouterWorker(worker.Value.Id, worker.Value.State, worker.Value.QueueAssignments, worker.Value.TotalCapacity, worker.Value.Labels, worker.Value.ChannelConfigurations, worker.Value.Offers, worker.Value.AssignedJobs), worker.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Releases capacity consumed by a job within a workers socket collection. </summary>
        /// <param name="workerId"> The worker that is currently assigned to this this job. </param>
        /// <param name="assignmentId"> The Id of the assigned worker and Job. </param>
        /// <param name="releaseTime"> (Optional) If not provided, capacity will be released immediately. If provided, the future time at which to release the capacity. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. If provided, the future time at which to release the capacity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> ReleaseAssignmentAsync(string workerId, string assignmentId, DateTimeOffset? releaseTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReleaseAssignment)}");
            scope.Start();
            try
            {
                var request = new ReleaseAssignmentRequest();
                request.ReleaseTime = releaseTime;

                return await RestClient.ReleaseAssignmentAsync(workerId, assignmentId, request, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Releases capacity consumed by a job within a workers socket collection. </summary>
        /// <param name="workerId"> The worker that is currently assigned to this this job. </param>
        /// <param name="assignmentId"> The Id of the assigned worker and Job. </param>
        /// <param name="releaseTime"> (Optional) If not provided, capacity will be released immediately. If provided, the future time at which to release the capacity. </param>
        /// <param name="cancellationToken"> (Optional) The cancellation token to use. If provided, the future time at which to release the capacity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workerId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response ReleaseAssignment(string workerId, string assignmentId, DateTimeOffset? releaseTime = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrWhiteSpace(workerId, nameof(workerId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RouterClient)}.{nameof(ReleaseAssignment)}");
            scope.Start();
            try
            {
                var request = new ReleaseAssignmentRequest();
                request.ReleaseTime = releaseTime;

                return RestClient.ReleaseAssignment(workerId, assignmentId, request, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Specialized;
using System.Threading;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The Repository service client. </summary>
    public partial class ContainerRegistryClient
    {
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly RepositoryRestClient _restClient;

        /// <summary>
        /// <paramref name="endpoint"/>
        /// </summary>
        public ContainerRegistryClient(Uri endpoint) : this(endpoint, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="options"></param>
        public ContainerRegistryClient(Uri endpoint, ContainerRegistryClientOptions options)
        {
            // The HttpPipelineBuilder.Build method, builds up a pipeline with client options, and any number of additional policies.
            _pipeline = HttpPipelineBuilder.Build(options, new BasicAuthenticationPolicy());

            _clientDiagnostics = new ClientDiagnostics(options);

            _endpoint = endpoint;

            _restClient = new RepositoryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        ///// <summary> Initializes a new instance of RepositoryClient. </summary>
        ///// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        ///// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        ///// <param name="url"> Registry login URL. </param>
        //internal ContainerRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        //{
        //    _restClient = new RepositoryRestClient(clientDiagnostics, pipeline, url);
        //    _clientDiagnostics = clientDiagnostics;
        //    _pipeline = pipeline;
        //}

        /// <summary> List repositories. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<string> GetRepositoriesAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async (continuationToken, pageSizeHint) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, RepositoryGetListHeaders> response =
                        await _restClient.GetListAsync(
                            continuationToken,
                            pageSizeHint,
                            cancellationToken)
                       .ConfigureAwait(false);

                    string lastRepository = null;
                    if (!String.IsNullOrEmpty(response.Headers.Link))
                    {
                        Uri nextLink = new Uri(response.Headers.Link);
                        NameValueCollection queryParams = HttpUtility.ParseQueryString(nextLink.Query);
                        lastRepository = queryParams["last"];
                    }

                    return Page<string>.FromValues(response.Value.Names, lastRepository, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> List repositories. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<string> GetRepositories(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable((continuationToken, pageSizeHint) =>
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, RepositoryGetListHeaders> response =
                        _restClient.GetList(
                            continuationToken,
                            pageSizeHint,
                            cancellationToken);
                    Uri nextLink = new Uri(response.Headers.Link);
                    NameValueCollection queryParams = HttpUtility.ParseQueryString(nextLink.Query);
                    string lastSeenRepository = queryParams["last"];

                    return Page<string>.FromValues(response.Value.Names, lastSeenRepository, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }
    }
}

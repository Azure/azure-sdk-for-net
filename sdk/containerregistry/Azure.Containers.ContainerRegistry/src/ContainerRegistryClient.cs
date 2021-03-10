// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The Repository service client. </summary>
    public partial class ContainerRegistryClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal RepositoryRestClient RestClient { get; }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        /// <summary> Initializes a new instance of RepositoryClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        internal ContainerRegistryClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            RestClient = new RepositoryRestClient(clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> List repositories. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async AsyncPageable<string> GetRepositoriesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryClient.GetRepositories");
            scope.Start();
            try
            {
                return await RestClient.GetListAsync(last, n, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
                    ResponseWithHeaders<Repositories, RepositoryGetListHeaders> response = RestClient.GetList(continuationToken, pageSizeHint, cancellationToken);
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

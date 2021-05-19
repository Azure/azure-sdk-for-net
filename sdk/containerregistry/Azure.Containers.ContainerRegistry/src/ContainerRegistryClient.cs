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
    /// <summary> The registry service client. </summary>
    public partial class ContainerRegistryClient
    {
        private readonly Uri _endpoint;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly RepositoryRestClient _restClient;

        /// <summary>
        /// <paramref name="endpoint"/>
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, string username, string password) : this(endpoint, username, password,  new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="options"></param>
        public ContainerRegistryClient(Uri endpoint, string username, string password, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(options, nameof(options));

            _pipeline = HttpPipelineBuilder.Build(options, new BasicAuthenticationPolicy(username, password));

            _clientDiagnostics = new ClientDiagnostics(options);

            _endpoint = endpoint;

            _restClient = new RepositoryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

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
                    if (!string.IsNullOrEmpty(response.Headers.Link))
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

                    string lastRepository = null;
                    if (!string.IsNullOrEmpty(response.Headers.Link))
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
    }
}

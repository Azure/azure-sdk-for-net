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
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;

        private readonly AuthenticationRestClient _acrAuthClient;
        private readonly string AcrAadScope = "https://management.core.windows.net/.default";

        /// <summary>
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _endpoint = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, AcrAadScope, _acrAuthClient));
            _restClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
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
                    Response<Repositories> response =
                        await _restClient.GetRepositoriesAsync(
                            continuationToken,
                            pageSizeHint,
                            cancellationToken)
                       .ConfigureAwait(false);

                    string lastRepository = null;
                    if (!string.IsNullOrEmpty(response.Value.Link))
                    {
                        Uri nextLink = new Uri(response.Value.Link);
                        NameValueCollection queryParams = HttpUtility.ParseQueryString(nextLink.Query);
                        lastRepository = queryParams["last"];
                    }

                    return Page<string>.FromValues(response.Value.RepositoriesValue, lastRepository, response.GetRawResponse());
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
                    Response<Repositories> response =
                        _restClient.GetRepositories(
                            continuationToken,
                            pageSizeHint,
                            cancellationToken);

                    string lastRepository = null;
                    if (!string.IsNullOrEmpty(response.Value.Link))
                    {
                        Uri nextLink = new Uri(response.Value.Link);
                        NameValueCollection queryParams = HttpUtility.ParseQueryString(nextLink.Query);
                        lastRepository = queryParams["last"];
                    }

                    return Page<string>.FromValues(response.Value.RepositoriesValue, lastRepository, response.GetRawResponse());
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

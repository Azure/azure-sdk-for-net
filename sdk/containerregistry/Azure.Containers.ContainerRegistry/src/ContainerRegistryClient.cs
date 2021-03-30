// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
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

        /// <summary>
        /// Ge the service endpoint for this client.
        /// </summary>
        public Uri Endpoint {  get { return _endpoint; } }

        /// <summary> List repositories. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<string> GetRepositoriesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = await _restClient.GetRepositoriesAsync(last: null, n: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RepositoriesValue, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string continuationToken, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    string uriReference = ParseUriReferenceFromLinkHeader(continuationToken);
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = await _restClient.GetRepositoriesNextPageAsync(uriReference, last: null, n: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RepositoriesValue, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List repositories. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<string> GetRepositories(CancellationToken cancellationToken = default)
        {
            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = _restClient.GetRepositories(last: null, n: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.RepositoriesValue, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<string> NextPageFunc(string continuationToken, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositories)}");
                scope.Start();
                try
                {
                    string uriReference = ParseUriReferenceFromLinkHeader(continuationToken);
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = _restClient.GetRepositoriesNextPage(uriReference, last: null, n: null, cancellationToken);
                    return Page.FromValues(response.Value.RepositoriesValue, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        internal static string ParseUriReferenceFromLinkHeader(string linkValue)
        {
            // Per the Docker v2 HTTP API spec, the Link header is an RFC5988
            // compliant rel='next' with URL to next result set, if available.
            // See: https://docs.docker.com/registry/spec/api/
            //
            // The URI reference can be obtained from link-value as follows:
            //   Link       = "Link" ":" #link-value
            //   link-value = "<" URI-Reference ">" * (";" link-param )
            // See: https://tools.ietf.org/html/rfc5988#section-5

            return linkValue?.Substring(1, linkValue.IndexOf('>') - 1);
        }

        /// <summary> Delete the repository identified by `repostitory`. </summary>
        /// <param name="repository"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteRepositoryAsync(string repository, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(DeleteRepository)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteRepositoryAsync(repository, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository identified by `repostitory`. </summary>
        /// <param name="repository"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeleteRepositoryResult> DeleteRepository(string repository, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(DeleteRepository)}");
            scope.Start();
            try
            {
                return _restClient.DeleteRepository(repository, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

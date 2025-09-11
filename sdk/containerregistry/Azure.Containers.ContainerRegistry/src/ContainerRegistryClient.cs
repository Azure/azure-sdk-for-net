// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The Azure Container Registry service client. </summary>
    public partial class ContainerRegistryClient
    {
        internal const string DefaultScope = "https://containerregistry.azure.net";

        private readonly Uri _endpoint;
        private readonly string _registryName;
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly AuthenticationRestClient _acrAuthClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> is null. </exception>
        public ContainerRegistryClient(Uri endpoint) : this(endpoint, new ContainerRegistryAnonymousAccessCredential(), new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> is null. </exception>
        public ContainerRegistryClient(Uri endpoint, ContainerRegistryClientOptions options) : this(endpoint, new ContainerRegistryAnonymousAccessCredential(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryClient(Uri endpoint, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _endpoint = endpoint;
            _registryName = endpoint.Host.Split('.')[0];
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            string defaultScope = (options.Audience?.ToString() ?? DefaultScope) + "/.default";
            HttpPipelineOptions pipelineOptions = new HttpPipelineOptions(options)
            {
                RequestFailedDetailsParser = new ContainerRegistryRequestFailedDetailsParser()
            };
            pipelineOptions.PerRetryPolicies.Add(new ContainerRegistryChallengeAuthenticationPolicy(credential, defaultScope, _acrAuthClient));
            _pipeline = HttpPipelineBuilder.Build(pipelineOptions);
            _restClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        /// <summary>
        /// Gets the registry service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// The HttpPipeline.
        /// </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> List the names of the repositories in this registry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual AsyncPageable<string> GetRepositoryNamesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<string>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = await _restClient.GetRepositoriesAsync(last: null, n: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RepositoriesProperty, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<string>> NextPageFunc(string continuationToken, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
                scope.Start();
                try
                {
                    string uriReference = ParseUriReferenceFromLinkHeader(continuationToken);
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = await _restClient.GetRepositoriesNextPageAsync(uriReference, last: null, n: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RepositoriesProperty, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> List the names of the repositories in this registry. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Pageable<string> GetRepositoryNames(CancellationToken cancellationToken = default)
        {
            Page<string> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
                scope.Start();
                try
                {
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = _restClient.GetRepositories(last: null, n: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.RepositoriesProperty, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<string> NextPageFunc(string continuationToken, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
                scope.Start();
                try
                {
                    string uriReference = ParseUriReferenceFromLinkHeader(continuationToken);
                    ResponseWithHeaders<Repositories, ContainerRegistryGetRepositoriesHeaders> response = _restClient.GetRepositoriesNextPage(uriReference, last: null, n: null, cancellationToken);
                    return Page.FromValues(response.Value.RepositoriesProperty, response.Headers.Link, response.GetRawResponse());
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

        /// <summary> Delete the repository identified by `repository` and all associated artifacts.</summary>
        /// <param name="repositoryName"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response> DeleteRepositoryAsync(string repositoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(repositoryName, nameof(repositoryName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(DeleteRepository)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteRepositoryAsync(repositoryName, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository identified by `repository` and all associated artifacts.</summary>
        /// <param name="repositoryName"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response DeleteRepository(string repositoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(repositoryName, nameof(repositoryName));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(DeleteRepository)}");
            scope.Start();
            try
            {
                return _restClient.DeleteRepository(repositoryName, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create a new <see cref="ContainerRepository"/> object for calling service methods related to the repository specified by `repositoryName`.
        /// </summary>
        /// <param name="repositoryName"> The name of the repository to reference. </param>
        /// <returns> A new <see cref="ContainerRepository"/> for the desired repository. </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        public virtual ContainerRepository GetRepository(string repositoryName)
        {
            Argument.AssertNotNullOrEmpty(repositoryName, nameof(repositoryName));

            return new ContainerRepository(
                _endpoint,
                repositoryName,
                _clientDiagnostics,
                _restClient);
        }

        /// <summary>
        /// Create a new <see cref="RegistryArtifact"/> object for calling service methods related to the artifact specified by `repositoryName` and `tagOrDigest`.
        /// </summary>
        /// <param name="repositoryName"> The name of the repository to reference. </param>
        /// <param name="tagOrDigest"> Either a tag or a digest that uniquely identifies the artifact. </param>
        /// <returns> A new <see cref="RegistryArtifact"/> for the desired repository. </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tagOrDigest"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tagOrDigest"/> is empty. </exception>
        public virtual RegistryArtifact GetArtifact(string repositoryName, string tagOrDigest)
        {
            Argument.AssertNotNullOrEmpty(repositoryName, nameof(repositoryName));
            Argument.AssertNotNullOrEmpty(tagOrDigest, nameof(tagOrDigest));

            return new RegistryArtifact(
                _endpoint,
                repositoryName,
                tagOrDigest,
                _clientDiagnostics,
                _restClient);
        }

        /// <summary> Exchange AAD tokens for an ACR refresh Token. </summary>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="tenant"> AAD tenant associated to the AAD credentials. </param>
        /// <param name="refreshToken"> AAD refresh token. </param>
        /// <param name="accessToken"> AAD access token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> is null. </exception>
        public virtual async Task<Response<AcrRefreshToken>> ExchangeAadAccessTokenForAcrRefreshTokenAsync(
            string service,
            string tenant = null,
            string refreshToken = null,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(service, nameof(service));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(ExchangeAadAccessTokenForAcrRefreshTokenAsync)}");
            scope.Start();
            try
            {
                return await _acrAuthClient.ExchangeAadAccessTokenForAcrRefreshTokenAsync(PostContentSchemaGrantType.AccessToken, service, tenant, refreshToken, accessToken, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Exchange AAD tokens for an ACR refresh Token. </summary>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="tenant"> AAD tenant associated to the AAD credentials. </param>
        /// <param name="refreshToken"> AAD refresh token. </param>
        /// <param name="accessToken"> AAD access token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/> is null. </exception>
        public virtual Response<AcrRefreshToken> ExchangeAadAccessTokenForAcrRefreshToken(
            string service,
            string tenant = null,
            string refreshToken = null,
            string accessToken = null,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(service, nameof(service));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(ExchangeAadAccessTokenForAcrRefreshToken)}");
            scope.Start();
            try
            {
                return _acrAuthClient.ExchangeAadAccessTokenForAcrRefreshToken(PostContentSchemaGrantType.AccessToken, service, tenant, refreshToken, accessToken, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Exchange ACR Refresh token for an ACR Access Token. </summary>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="scope"> Which is expected to be a valid scope, and can be specified more than once for multiple scope requests. You obtained this from the Www-Authenticate response header from the challenge. </param>
        /// <param name="refreshToken"> Must be a valid ACR refresh token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/>, <paramref name="scope"/> or <paramref name="refreshToken"/> is null. </exception>
        public virtual async Task<Response<AcrAccessToken>> ExchangeAcrRefreshTokenForAcrAccessTokenAsync(
            string service,
            string scope,
            string refreshToken,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(service, nameof(service));
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(refreshToken, nameof(refreshToken));

            using DiagnosticScope diagnosticScope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(ExchangeAcrRefreshTokenForAcrAccessTokenAsync)}");
            diagnosticScope.Start();
            try
            {
                return await _acrAuthClient.ExchangeAcrRefreshTokenForAcrAccessTokenAsync(service, scope, refreshToken, TokenGrantType.RefreshToken, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                diagnosticScope.Failed(e);
                throw;
            }
        }

        /// <summary> Exchange ACR Refresh token for an ACR Access Token. </summary>
        /// <param name="service"> Indicates the name of your Azure container registry. </param>
        /// <param name="scope"> Which is expected to be a valid scope, and can be specified more than once for multiple scope requests. You obtained this from the Www-Authenticate response header from the challenge. </param>
        /// <param name="refreshToken"> Must be a valid ACR refresh token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="service"/>, <paramref name="scope"/> or <paramref name="refreshToken"/> is null. </exception>
        public virtual Response<AcrAccessToken> ExchangeAcrRefreshTokenForAcrAccessToken(
            string service,
            string scope,
            string refreshToken,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(service, nameof(service));
            Argument.AssertNotNullOrEmpty(scope, nameof(scope));
            Argument.AssertNotNullOrEmpty(refreshToken, nameof(refreshToken));

            using DiagnosticScope diagnosticScope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(ExchangeAcrRefreshTokenForAcrAccessToken)}");
            diagnosticScope.Start();
            try
            {
                return _acrAuthClient.ExchangeAcrRefreshTokenForAcrAccessToken(service, scope, refreshToken, TokenGrantType.RefreshToken, cancellationToken);
            }
            catch (Exception e)
            {
                diagnosticScope.Failed(e);
                throw;
            }
        }
    }
}

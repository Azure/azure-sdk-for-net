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
        private readonly Uri _registryEndpoint;
        private readonly string _registryName;
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly AuthenticationRestClient _acrAuthClient;
        private readonly string AcrAadScope = "https://management.core.windows.net/.default";

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called.
        /// </summary>
        /// <param name="registryEndpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="registryEndpoint"/> is null. </exception>
        public ContainerRegistryClient(Uri registryEndpoint) : this(registryEndpoint, new ContainerRegistryAnonymousAccessCredential(), new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContainerRegistryClient for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called.
        /// </summary>
        /// <param name="registryEndpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="registryEndpoint"/> is null. </exception>
        public ContainerRegistryClient(Uri registryEndpoint, ContainerRegistryClientOptions options) : this(registryEndpoint, new ContainerRegistryAnonymousAccessCredential(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="registryEndpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="registryEndpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryClient(Uri registryEndpoint, TokenCredential credential) : this(registryEndpoint, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContainerRegistryClient for managing container images and artifacts.
        /// </summary>
        /// <param name="registryEndpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="registryEndpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryClient(Uri registryEndpoint, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(registryEndpoint, nameof(registryEndpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _registryEndpoint = registryEndpoint;
            _registryName = registryEndpoint.Host.Split('.')[0];
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, registryEndpoint.AbsoluteUri);

            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, AcrAadScope, _acrAuthClient));
            _restClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, _registryEndpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryClient()
        {
        }

        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri RegistryEndpoint => _registryEndpoint;

        /// <summary>
        /// Gets the name of this container registry.
        /// </summary>
        public virtual string Name => _registryName;

        /// <summary>
        /// Gets the login server name for this container registry.
        /// </summary>
        public virtual string LoginServer => _registryEndpoint.Host;

        /// <summary> List repositories in this registry. </summary>
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
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

        /// <summary> List repositories in this registry. </summary>
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryClient)}.{nameof(GetRepositoryNames)}");
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
        /// <param name="repositoryName"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteRepositoryAsync(string repositoryName, CancellationToken cancellationToken = default)
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

        /// <summary> Delete the repository identified by `repostitory`. </summary>
        /// <param name="repositoryName"> Repository name (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<DeleteRepositoryResult> DeleteRepository(string repositoryName, CancellationToken cancellationToken = default)
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
        /// Create a new <see cref="ContainerRepository"/> object for the specified repository.
        /// </summary>
        /// <param name="repositoryName"> The name of the repository to reference. </param>
        /// <returns> A new <see cref="ContainerRepository"/> for the desired repository. </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="repositoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="repositoryName"/> is empty. </exception>
        public virtual ContainerRepository GetRepository(string repositoryName)
        {
            Argument.AssertNotNullOrEmpty(repositoryName, nameof(repositoryName));

            return new ContainerRepository(
                _registryEndpoint,
                repositoryName,
                _clientDiagnostics,
                _restClient);
        }

        /// <summary>
        /// Create a new <see cref="RegistryArtifact"/> object for the specified artifact.
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
                _registryEndpoint,
                repositoryName,
                tagOrDigest,
                _clientDiagnostics,
                _restClient);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> A helper class that groups information and operations about a repository in this container registry. </summary>
    public partial class ContainerRepository
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;

        private readonly Uri _registryEndpoint;
        private readonly string _name;

        /// <summary>
        /// Gets the Registry Uri.
        /// </summary>
        public virtual Uri RegistryEndpoint => _registryEndpoint;

        /// <summary>
        /// Gets the name of the repository.
        /// </summary>
        public virtual string Name => _name;

        /// <summary>
        /// </summary>
        internal ContainerRepository(Uri registryEndpoint, string name, ClientDiagnostics clientDiagnostics, ContainerRegistryRestClient restClient)
        {
            _name = name;
            _registryEndpoint = registryEndpoint;

            _clientDiagnostics = clientDiagnostics;
            _restClient = restClient;
        }

        /// <summary> Initializes a new instance of ContainerRepository for mocking. </summary>
        protected ContainerRepository()
        {
        }

        /// <summary>
        /// Create a new <see cref="RegistryArtifact"/> object for the specified artifact.
        /// </summary>
        /// <param name="tagOrDigest"> Either a tag or a digest that uniquely identifies the artifact. </param>
        /// <returns> A new <see cref="RegistryArtifact"/> for the desired repository. </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tagOrDigest"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tagOrDigest"/> is empty. </exception>
        public virtual RegistryArtifact GetArtifact(string tagOrDigest)
        {
            Argument.AssertNotNullOrEmpty(tagOrDigest, nameof(tagOrDigest));

            return new RegistryArtifact(
                _registryEndpoint,
                _name,
                tagOrDigest,
                _clientDiagnostics,
                _restClient);
        }

        #region Repository methods
        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<RepositoryProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetPropertiesAsync(Name, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<RepositoryProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetProperties(Name, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<RepositoryProperties>> SetPropertiesAsync(RepositoryProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.SetPropertiesAsync(Name, GetRepositoryWriteableProperties(value), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static RepositoryWriteableProperties GetRepositoryWriteableProperties(RepositoryProperties value)
        {
            return new RepositoryWriteableProperties()
            {
                CanDelete = value.CanDelete,
                CanList = value.CanList,
                CanRead = value.CanRead,
                CanWrite = value.CanWrite,
                TeleportEnabled = value.TeleportEnabled
            };
        }

        /// <summary>Update the repository properties.</summary>
        /// <param name="value"> Repository properties to set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<RepositoryProperties> SetProperties(RepositoryProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return _restClient.SetProperties(Name, GetRepositoryWriteableProperties(value), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteRepositoryAsync(Name, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<DeleteRepositoryResult> Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return _restClient.DeleteRepository(Name, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion

        #region Registry Artifact/Manifest methods
        /// <summary> Get the collection of registry artifacts for a repository. </summary>
        /// <param name="orderBy"> Requested order of manifests in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual AsyncPageable<ArtifactManifestProperties> GetManifestsAsync(ManifestOrderBy orderBy = ManifestOrderBy.None, CancellationToken cancellationToken = default)
        {
            async Task<Page<ArtifactManifestProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifests)}");
                scope.Start();
                try
                {
                    string order = orderBy == ManifestOrderBy.None ? null : orderBy.ToSerialString();
                    var response = await _restClient.GetManifestsAsync(Name, last: null, n: pageSizeHint, orderby: order, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ArtifactManifestProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifests)}");
                scope.Start();
                try
                {
                    string order = orderBy == ManifestOrderBy.None ? null : orderBy.ToSerialString();
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = await _restClient.GetManifestsNextPageAsync(uriReference, Name, last: null, n: null, orderby: order, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get the collection of tags for a repository. </summary>
        /// <param name="orderBy"> Requested order of manifests in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Pageable<ArtifactManifestProperties> GetManifests(ManifestOrderBy orderBy = ManifestOrderBy.None, CancellationToken cancellationToken = default)
        {
            Page<ArtifactManifestProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifests)}");
                scope.Start();
                try
                {
                    string order = orderBy == ManifestOrderBy.None ? null : orderBy.ToSerialString();
                    var response = _restClient.GetManifests(Name, last: null, n: pageSizeHint, orderby: order, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ArtifactManifestProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifests)}");
                scope.Start();
                try
                {
                    string order = orderBy == ManifestOrderBy.None ? null : orderBy.ToSerialString();
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = _restClient.GetManifestsNextPage(uriReference, Name, last: null, n: null, orderby: order, cancellationToken);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
        #endregion
    }
}

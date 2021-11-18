// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// A `repository` in a container registry is a logical grouping of images or artifacts that share the same name.  For example,
    /// different versions of a `hello-world` application could have tags `v1` and `v2`, and be grouped by the repository `hello-world`.
    /// <para>
    /// The <see cref="ContainerRepository"/> class is a helper class that groups information and operations about a repository in this
    /// container registry.
    /// </para>
    /// </summary>
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
        /// Create a new <see cref="RegistryArtifact"/> helper object for the artifact identified by <paramref name="tagOrDigest"/>.
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
        /// <summary> Get the properties of the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ContainerRepositoryProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Get the properties of the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ContainerRepositoryProperties> GetProperties(CancellationToken cancellationToken = default)
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

        /// <summary> Update the properties of the repository. </summary>
        /// <param name="value"> Repository properties object containing values to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ContainerRepositoryProperties>> UpdatePropertiesAsync(ContainerRepositoryProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(UpdateProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdatePropertiesAsync(Name, GetRepositoryWriteableProperties(value), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static RepositoryWriteableProperties GetRepositoryWriteableProperties(ContainerRepositoryProperties value)
        {
            return new RepositoryWriteableProperties()
            {
                CanDelete = value.CanDelete,
                CanList = value.CanList,
                CanRead = value.CanRead,
                CanWrite = value.CanWrite,
            };
        }

        /// <summary> Update the properties of the repository. </summary>
        /// <param name="value"> Repository properties object containing values to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ContainerRepositoryProperties> UpdateProperties(ContainerRepositoryProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(UpdateProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateProperties(Name, GetRepositoryWriteableProperties(value), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository and all artifacts that are part of its logical group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
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

        /// <summary> Delete the repository and all artifacts that are part of its logical group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response Delete(CancellationToken cancellationToken = default)
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

        /// <summary> List the manifests associated with this repository and the properties of each.
        /// This is useful for determining the collection of artifacts associated with this repository, as each artifact is uniquely identified by its manifest. </summary>
        /// <param name="orderBy"> Requested order of manifests in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual AsyncPageable<ArtifactManifestProperties> GetManifestPropertiesCollectionAsync(ArtifactManifestOrderBy orderBy = ArtifactManifestOrderBy.None, CancellationToken cancellationToken = default)
        {
            async Task<Page<ArtifactManifestProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifestPropertiesCollection)}");
                scope.Start();
                try
                {
                    string order = orderBy == ArtifactManifestOrderBy.None ? null : orderBy.ToSerialString();
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifestPropertiesCollection)}");
                scope.Start();
                try
                {
                    string order = orderBy == ArtifactManifestOrderBy.None ? null : orderBy.ToSerialString();
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

        /// <summary> List the manifests associated with this repository and the properties of each.
        /// This is useful for determining the collection of artifacts associated with this repository, as each artifact is uniquely identified by its manifest. </summary>
        /// <param name="orderBy"> Requested order of manifests in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Pageable<ArtifactManifestProperties> GetManifestPropertiesCollection(ArtifactManifestOrderBy orderBy = ArtifactManifestOrderBy.None, CancellationToken cancellationToken = default)
        {
            Page<ArtifactManifestProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifestPropertiesCollection)}");
                scope.Start();
                try
                {
                    string order = orderBy == ArtifactManifestOrderBy.None ? null : orderBy.ToSerialString();
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetManifestPropertiesCollection)}");
                scope.Start();
                try
                {
                    string order = orderBy == ArtifactManifestOrderBy.None ? null : orderBy.ToSerialString();
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

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> A helper class that groups information and operations about an image or artifact in this container registry. </summary>
    public partial class RegistryArtifact
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;

        private readonly Uri _registryUri;
        private readonly string _repositoryName;
        private readonly string _tagOrDigest;
        private readonly string _fullyQualifiedName;

        private string _digest;

        /// <summary>
        /// Gets the Registry Uri.
        /// </summary>
        public virtual Uri RegistryUri => _registryUri;

        /// <summary>
        /// Gets the name of the repository for this artifact.
        /// </summary>
        public virtual string RepositoryName => _repositoryName;

        /// <summary>
        /// Gets the tag or digest reference used to create this RegistryArtifact instance.
        /// </summary>
        public virtual string TagOrDigest => _tagOrDigest;

        /// <summary>
        /// Gets the fully qualified name of this artifact.
        /// </summary>
        public virtual string FullyQualifiedName => _fullyQualifiedName;

        /// <summary>
        /// </summary>
        internal RegistryArtifact(Uri registryUri, string repositoryName, string tagOrDigest, ClientDiagnostics clientDiagnostics, ContainerRegistryRestClient restClient)
        {
            _repositoryName = repositoryName;
            _tagOrDigest = tagOrDigest;
            _registryUri = registryUri;
            _fullyQualifiedName = $"{registryUri.Host}/{repositoryName}{(IsDigest(tagOrDigest) ? '@' : ':')}{tagOrDigest}";

            _clientDiagnostics = clientDiagnostics;
            _restClient = restClient;
        }

        /// <summary> Initializes a new instance of RegistryArtifact for mocking. </summary>
        protected RegistryArtifact()
        {
        }

        #region Registry Artifact/Manifest methods

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ArtifactManifestProperties>> GetManifestPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetManifestProperties)}");
            scope.Start();

            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.GetManifestPropertiesAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ArtifactManifestProperties> GetManifestProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetManifestProperties)}");
            scope.Start();

            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.GetManifestProperties(_repositoryName, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<string> GetDigestAsync(CancellationToken cancellationToken)
        {
            _digest ??= IsDigest(_tagOrDigest) ? _tagOrDigest :
                (await _restClient.GetTagPropertiesAsync(_repositoryName, _tagOrDigest, cancellationToken).ConfigureAwait(false)).Value.Digest;

            return _digest;
        }

        private string GetDigest(CancellationToken cancellationToken)
        {
            _digest ??= IsDigest(_tagOrDigest) ? _tagOrDigest :
                _restClient.GetTagProperties(_repositoryName, _tagOrDigest, cancellationToken).Value.Digest;

            return _digest;
        }

        private static bool IsDigest(string tagOrDigest)
        {
            return tagOrDigest.Contains(":");
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ArtifactManifestProperties>> SetManifestPropertiesAsync(ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.UpdateManifestPropertiesAsync(_repositoryName, digest, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ArtifactManifestProperties> SetManifestProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.UpdateManifestProperties(_repositoryName, digest, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.DeleteManifestAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.DeleteManifest(_repositoryName, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Tag methods
        /// <summary> Get the collection of tags for a repository. </summary>
        /// <param name="orderBy"> Requested order of tags in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual AsyncPageable<ArtifactTagProperties> GetTagsAsync(TagOrderBy orderBy = TagOrderBy.None, CancellationToken cancellationToken = default)
        {
            async Task<Page<ArtifactTagProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    string order = orderBy == TagOrderBy.None ? null : orderBy.ToSerialString();
                    var response = await _restClient.GetTagsAsync(_repositoryName, last: null, n: pageSizeHint, orderby: order, digest: digest, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<ArtifactTagProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    string order = orderBy == TagOrderBy.None ? null : orderBy.ToSerialString();
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = await _restClient.GetTagsNextPageAsync(uriReference, _repositoryName, last: null, n: null, orderby: order, digest: digest, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
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
        /// <param name="orderBy"> Requested order of tags in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Pageable<ArtifactTagProperties> GetTags(TagOrderBy orderBy = TagOrderBy.None, CancellationToken cancellationToken = default)
        {
            Page<ArtifactTagProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    string order = orderBy == TagOrderBy.None ? null : orderBy.ToSerialString();
                    var response = _restClient.GetTags(_repositoryName, last: null, n: pageSizeHint, orderby: order, digest: digest, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<ArtifactTagProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    string order = orderBy == TagOrderBy.None ? null : orderBy.ToSerialString();
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = _restClient.GetTagsNextPage(uriReference, _repositoryName, last: null, n: null, orderby: order, digest: digest, cancellationToken);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get tag properties by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ArtifactTagProperties>> GetTagPropertiesAsync(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetTagPropertiesAsync(_repositoryName, tag, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ArtifactTagProperties> GetTagProperties(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetTagProperties(_repositoryName, tag, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response<ArtifactTagProperties>> SetTagPropertiesAsync(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateTagAttributesAsync(_repositoryName, tag, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ArtifactTagProperties> SetTagProperties(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateTagAttributes(_repositoryName, tag, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the tag.  This removes the tag from the artifact and its manifest. </summary>
        /// <param name="tag"> Name of tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual async Task<Response> DeleteTagAsync(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(DeleteTag)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteTagAsync(_repositoryName, tag, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the tag.  This removes the tag from the artifact and its manifest. </summary>
        /// <param name="tag"> Name of tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response DeleteTag(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(DeleteTag)}");
            scope.Start();
            try
            {
                return _restClient.DeleteTag(_repositoryName, tag, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        #endregion
    }
}

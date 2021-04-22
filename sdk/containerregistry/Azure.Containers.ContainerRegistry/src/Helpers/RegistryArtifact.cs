// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The registry artifact service method helper object. </summary>
    public partial class RegistryArtifact
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;

        private readonly string _repository;
        private readonly string _tagOrDigest;
        private readonly string _fullyQualifiedName;

        private string _digest;

        /// <summary>
        /// Gets the name of the repository for this artifact.
        /// </summary>
        public virtual string Repository => _repository;

        /// <summary>
        /// Gets the fully qualified name of this artifact.
        /// </summary>
        public virtual string FullyQualifiedName => _fullyQualifiedName;

        /// <summary>
        /// </summary>
        internal RegistryArtifact(string repository, string tagOrDigest, Uri endpoint, ClientDiagnostics clientDiagnostics, ContainerRegistryRestClient restClient)
        {
            _repository = repository;
            _tagOrDigest = tagOrDigest;
            _fullyQualifiedName = $"{endpoint.Host}/{repository}{(IsDigest(tagOrDigest) ? '@' : ':')}{tagOrDigest}";

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
        public virtual async Task<Response<ManifestProperties>> GetManifestPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetManifestProperties)}");
            scope.Start();

            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.GetRegistryArtifactPropertiesAsync(_repository, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestProperties> GetManifestProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetManifestProperties)}");
            scope.Start();

            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.GetRegistryArtifactProperties(_repository, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<string> GetDigestAsync(CancellationToken cancellationToken)
        {
            if (_digest == null)
            {
                _digest = IsDigest(_tagOrDigest) ? _tagOrDigest :
                    (await _restClient.GetTagPropertiesAsync(_repository, _tagOrDigest, cancellationToken).ConfigureAwait(false)).Value.Digest;
            }

            return _digest;
        }

        private string GetDigest(CancellationToken cancellationToken)
        {
            if (_digest == null)
            {
                _digest = IsDigest(_tagOrDigest) ? _tagOrDigest : _restClient.GetTagProperties(_repository, _tagOrDigest, cancellationToken).Value.Digest;
            }

            return _digest;
        }

        private static bool IsDigest(string tagOrDigest)
        {
            return tagOrDigest.Contains(":");
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManifestProperties>> SetManifestPropertiesAsync(ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.UpdateManifestAttributesAsync(_repository, digest, value, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ManifestProperties> SetManifestProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.UpdateManifestAttributes(_repository, digest, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.DeleteManifestAsync(_repository, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.DeleteManifest(_repository, digest, cancellationToken);
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
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TagProperties> GetTagsAsync(GetTagsOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            async Task<Page<TagProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    var response = await _restClient.GetTagsAsync(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: digest, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<TagProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = await _restClient.GetTagsNextPageAsync(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: digest, cancellationToken).ConfigureAwait(false);
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
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TagProperties> GetTags(GetTagsOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            Page<TagProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    var response = _restClient.GetTags(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: digest, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<TagProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = _restClient.GetTagsNextPage(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: digest, cancellationToken);
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
        public virtual async Task<Response<TagProperties>> GetTagPropertiesAsync(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetTagPropertiesAsync(_repository, tag, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<TagProperties> GetTagProperties(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetTagProperties(_repository, tag, cancellationToken);
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
        public virtual async Task<Response<TagProperties>> SetTagPropertiesAsync(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateTagAttributesAsync(_repository, tag, value, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<TagProperties> SetTagProperties(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(SetTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateTagAttributes(_repository, tag, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Untag the artifact.  The artifact's tag will be deleted. </summary>
        /// <param name="tag"> Name of tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UntagAsync(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Untag)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteTagAsync(_repository, tag, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Untag the artifact.  The artifact's tag will be deleted. </summary>
        /// <param name="tag"> Name of tag to delete. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Untag(string tag, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tag, nameof(tag));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(Untag)}");
            scope.Start();
            try
            {
                return _restClient.DeleteTag(_repository, tag, cancellationToken);
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

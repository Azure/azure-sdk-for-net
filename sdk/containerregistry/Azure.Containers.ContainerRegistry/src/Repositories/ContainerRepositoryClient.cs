// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The repository service client. </summary>
    public partial class ContainerRepositoryClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRepositoryRestClient _restClient;
        private readonly ContainerRegistryRestClient _registryRestClient;

        private readonly AuthenticationRestClient _acrAuthClient;
        private readonly string AcrAadScope = "https://management.core.windows.net/.default";

        private readonly string _repository;

        /// <summary>
        /// </summary>
        public virtual Uri Endpoint { get; }

        /// <summary>
        /// </summary>
        public ContainerRepositoryClient(Uri endpoint, string repository, TokenCredential credential) : this(endpoint, repository, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        public ContainerRepositoryClient(Uri endpoint, string repository, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(repository, nameof(repository));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Endpoint = endpoint;
            _repository = repository;

            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, AcrAadScope, _acrAuthClient));
            _restClient = new ContainerRegistryRepositoryRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri);
            _registryRestClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, Endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRepositoryClient()
        {
        }

        #region Repository methods
        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RepositoryProperties>> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.GetPropertiesAsync(_repository, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get repository properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RepositoryProperties> GetProperties(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetProperties)}");
            scope.Start();
            try
            {
                return _restClient.GetProperties(_repository, cancellationToken);
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
        public virtual async Task<Response> SetPropertiesAsync(ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return await _restClient.SetPropertiesAsync(_repository, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>Update the repository properties.</summary>
        /// <param name="value"> Repository properties to set. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetProperties)}");
            scope.Start();
            try
            {
                return _restClient.SetProperties(_repository, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DeleteRepositoryResult>> DeleteAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return await _registryRestClient.DeleteRepositoryAsync(_repository, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete the repository. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DeleteRepositoryResult> Delete(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(Delete)}");
            scope.Start();
            try
            {
                return _registryRestClient.DeleteRepository(_repository, cancellationToken);
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
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<RegistryArtifactProperties> GetRegistryArtifactsAsync(GetRegistryArtifactOptions options = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<RegistryArtifactProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifacts)}");
                scope.Start();
                try
                {
                    var response = await _restClient.GetManifestsAsync(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            async Task<Page<RegistryArtifactProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifacts)}");
                scope.Start();
                try
                {
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = await _restClient.GetManifestsNextPageAsync(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), cancellationToken).ConfigureAwait(false);
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
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<RegistryArtifactProperties> GetRegistryArtifacts(GetRegistryArtifactOptions options = null, CancellationToken cancellationToken = default)
        {
            Page<RegistryArtifactProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifacts)}");
                scope.Start();
                try
                {
                    var response = _restClient.GetManifests(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.RegistryArtifacts, response.Headers.Link, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            Page<RegistryArtifactProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifacts)}");
                scope.Start();
                try
                {
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = _restClient.GetManifestsNextPage(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), cancellationToken);
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

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="tagOrDigest"> Either a tag or the digest identifying this registry artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RegistryArtifactProperties>> GetRegistryArtifactPropertiesAsync(string tagOrDigest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifactProperties)}");
            scope.Start();

            try
            {
                string digest = IsDigest(tagOrDigest) ? tagOrDigest :
                    (await _restClient.GetTagPropertiesAsync(_repository, tagOrDigest, cancellationToken).ConfigureAwait(false)).Value.Digest;

                return await _restClient.GetRegistryArtifactPropertiesAsync(_repository, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="tagOrDigest"> Either a tag or the digest identifying this registry artifact. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RegistryArtifactProperties> GetRegistryArtifactProperties(string tagOrDigest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetRegistryArtifactProperties)}");
            scope.Start();

            try
            {
                string digest = IsDigest(tagOrDigest) ? tagOrDigest : _restClient.GetTagProperties(_repository, tagOrDigest, cancellationToken).Value.Digest;

                return _restClient.GetRegistryArtifactProperties(_repository, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static bool IsDigest(string tagOrDigest)
        {
            return tagOrDigest.Contains(":");
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="digest"> Manifest digest. </param>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> SetManifestPropertiesAsync(string digest, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateManifestAttributesAsync(_repository, digest, value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="digest"> Manifest digest. </param>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response SetManifestProperties(string digest, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetManifestProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateManifestAttributes(_repository, digest, value, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="digest"> Manifest digest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteRegistryArtifactAsync(string digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(DeleteRegistryArtifact)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteManifestAsync(_repository, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="digest"> Manifest digest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteRegistryArtifact(string digest, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(DeleteRegistryArtifact)}");
            scope.Start();
            try
            {
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
        public virtual AsyncPageable<TagProperties> GetTagsAsync(GetTagOptions options = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TagProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    var response = await _restClient.GetTagsAsync(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = await _restClient.GetTagsNextPageAsync(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken).ConfigureAwait(false);
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
        public virtual Pageable<TagProperties> GetTags(GetTagOptions options = null, CancellationToken cancellationToken = default)
        {
            Page<TagProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    var response = _restClient.GetTags(_repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken: cancellationToken);
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTags)}");
                scope.Start();
                try
                {
                    string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
                    var response = _restClient.GetTagsNextPage(uriReference, _repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTagProperties)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(GetTagProperties)}");
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
        public virtual async Task<Response> SetTagPropertiesAsync(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetTagProperties)}");
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
        public virtual Response SetTagProperties(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(SetTagProperties)}");
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

        /// <summary> Delete tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteTagAsync(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(DeleteTag)}");
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

        /// <summary> Delete tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteTag(string tag, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepositoryClient)}.{nameof(DeleteTag)}");
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

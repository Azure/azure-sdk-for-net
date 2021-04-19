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
    public partial class RegistryArtifact
    {
        //private readonly ClientDiagnostics _clientDiagnostics = null;
        //private readonly ContainerRegistryRepositoryRestClient _restClient = null;

        #region Registry Artifact/Manifest methods

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManifestProperties>> GetManifestPropertiesAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();
            //Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifactProperties)}");
            //scope.Start();

            //try
            //{
            //    string digest = IsDigest(tagOrDigest) ? tagOrDigest :
            //        (await _restClient.GetTagPropertiesAsync(Repository, tagOrDigest, cancellationToken).ConfigureAwait(false)).Value.Digest;

            //    return await _restClient.GetRegistryArtifactPropertiesAsync(Repository, digest, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Get registry artifact properties by tag or digest. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestProperties> GetManifestProperties(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetRegistryArtifactProperties)}");
            //scope.Start();

            //try
            //{
            //    string digest = IsDigest(tagOrDigest) ? tagOrDigest : _restClient.GetTagProperties(Repository, tagOrDigest, cancellationToken).Value.Digest;

            //    return _restClient.GetRegistryArtifactProperties(Repository, digest, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
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
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();

            //Argument.AssertNotNull(digest, nameof(digest));
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetManifestProperties)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.UpdateManifestAttributesAsync(Repository, digest, value, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Update manifest attributes. </summary>
        /// <param name="value"> Manifest properties value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManifestProperties> SetManifestProperties(ContentProperties value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(digest, nameof(digest));
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetManifestProperties)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.UpdateManifestAttributes(Repository, digest, value, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            // TODO: request and cache the digest the first call we make.

            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();

            //Argument.AssertNotNull(digest, nameof(digest));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(DeleteRegistryArtifact)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.DeleteManifestAsync(Repository, digest, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete registry artifact. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(digest, nameof(digest));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(DeleteRegistryArtifact)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.DeleteManifest(Repository, digest, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        #endregion

        #region Tag methods
        /// <summary> Get the collection of tags for a repository. </summary>
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<TagProperties> GetTagsAsync(GetTagsOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            // TODO: Reimplement to take Digest!

            //async Task<Page<TagProperties>> FirstPageFunc(int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTags)}");
            //    scope.Start();
            //    try
            //    {
            //        var response = await _restClient.GetTagsAsync(Repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken: cancellationToken).ConfigureAwait(false);
            //        return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //async Task<Page<TagProperties>> NextPageFunc(string nextLink, int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTags)}");
            //    scope.Start();
            //    try
            //    {
            //        string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
            //        var response = await _restClient.GetTagsNextPageAsync(uriReference, Repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken).ConfigureAwait(false);
            //        return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get the collection of tags for a repository. </summary>
        /// <param name="options"> Options to override default collection getting behavior. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<TagProperties> GetTags(GetTagsOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Page<TagProperties> FirstPageFunc(int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTags)}");
            //    scope.Start();
            //    try
            //    {
            //        var response = _restClient.GetTags(Repository, last: null, n: pageSizeHint, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken: cancellationToken);
            //        return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //Page<TagProperties> NextPageFunc(string nextLink, int? pageSizeHint)
            //{
            //    using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTags)}");
            //    scope.Start();
            //    try
            //    {
            //        string uriReference = ContainerRegistryClient.ParseUriReferenceFromLinkHeader(nextLink);
            //        var response = _restClient.GetTagsNextPage(uriReference, Repository, last: null, n: null, orderby: options?.OrderBy.ToString(), digest: null, cancellationToken);
            //        return Page.FromValues(response.Value.Tags, response.Headers.Link, response.GetRawResponse());
            //    }
            //    catch (Exception e)
            //    {
            //        scope.Failed(e);
            //        throw;
            //    }
            //}

            //return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Get tag properties by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagProperties>> GetTagPropertiesAsync(string tag, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTagProperties)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.GetTagPropertiesAsync(Repository, tag, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Get tag attributes by tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagProperties> GetTagProperties(string tag, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(tag, nameof(tag));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(GetTagProperties)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.GetTagProperties(Repository, tag, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<TagProperties>> SetTagPropertiesAsync(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();

            //Argument.AssertNotNull(tag, nameof(tag));
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetTagProperties)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.UpdateTagAttributesAsync(Repository, tag, value, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<TagProperties> SetTagProperties(string tag, ContentProperties value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(tag, nameof(tag));
            //Argument.AssertNotNull(value, nameof(value));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(SetTagProperties)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.UpdateTagAttributes(Repository, tag, value, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UntagAsync(string tag, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1, cancellationToken).ConfigureAwait(false);
            throw new NotImplementedException();

            //Argument.AssertNotNull(tag, nameof(tag));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(DeleteTag)}");
            //scope.Start();
            //try
            //{
            //    return await _restClient.DeleteTagAsync(Repository, tag, cancellationToken).ConfigureAwait(false);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }

        /// <summary> Delete tag. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Untag(string tag, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();

            //Argument.AssertNotNull(tag, nameof(tag));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRepository)}.{nameof(DeleteTag)}");
            //scope.Start();
            //try
            //{
            //    return _restClient.DeleteTag(Repository, tag, cancellationToken);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
        }
        #endregion
    }
}

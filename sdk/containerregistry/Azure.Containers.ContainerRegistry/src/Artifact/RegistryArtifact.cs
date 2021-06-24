// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry.ResumableStorage;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> A helper class that groups information and operations about an image or artifact in this container registry. </summary>
    public partial class RegistryArtifact
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly ContainerRegistryBlobRestClient _blobRestClient;

        private readonly Uri _registryEndpoint;
        private readonly string _repositoryName;
        private readonly string _tagOrDigest;
        private readonly string _fullyQualifiedReference;

        private string _digest;

        /// <summary>
        /// Gets the Registry Uri.
        /// </summary>
        public virtual Uri RegistryEndpoint => _registryEndpoint;

        /// <summary>
        /// Gets the name of the repository for this artifact.
        /// </summary>
        public virtual string RepositoryName => _repositoryName;

        /// <summary>
        /// Gets the fully qualified name of this artifact.
        /// </summary>
        public virtual string FullyQualifiedReference => _fullyQualifiedReference;

        /// <summary>
        /// </summary>
        internal RegistryArtifact(Uri registryEndpoint, string repositoryName, string tagOrDigest, ClientDiagnostics clientDiagnostics, ContainerRegistryRestClient restClient, ContainerRegistryBlobRestClient blobRestClient)
        {
            _repositoryName = repositoryName;
            _tagOrDigest = tagOrDigest;
            _registryEndpoint = registryEndpoint;
            _fullyQualifiedReference = $"{registryEndpoint.Host}/{repositoryName}{(IsDigest(tagOrDigest) ? '@' : ':')}{tagOrDigest}";

            _clientDiagnostics = clientDiagnostics;
            _restClient = restClient;
            _blobRestClient = blobRestClient;
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
        public virtual async Task<Response<ArtifactManifestProperties>> UpdateManifestPropertiesAsync(ArtifactManifestProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(UpdateManifestProperties)}");
            scope.Start();
            try
            {
                string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                return await _restClient.UpdateManifestPropertiesAsync(_repositoryName, digest, GetManifestWriteableProperties(value), cancellationToken).ConfigureAwait(false);
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
        public virtual Response<ArtifactManifestProperties> UpdateManifestProperties(ArtifactManifestProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(UpdateManifestProperties)}");
            scope.Start();
            try
            {
                string digest = GetDigest(cancellationToken);
                return _restClient.UpdateManifestProperties(_repositoryName, digest, GetManifestWriteableProperties(value), cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static ManifestWriteableProperties GetManifestWriteableProperties(ArtifactManifestProperties value)
        {
            return new ManifestWriteableProperties()
            {
                CanDelete = value.CanDelete,
                CanList = value.CanList,
                CanRead = value.CanRead,
                CanWrite = value.CanWrite,
                QuarantineDetails = value.QuarantineDetails,
                QuarantineState = value.QuarantineState
            };
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
        public virtual AsyncPageable<ArtifactTagProperties> GetTagPropertiesCollectionAsync(ArtifactTagOrderBy orderBy = ArtifactTagOrderBy.None, CancellationToken cancellationToken = default)
        {
            async Task<Page<ArtifactTagProperties>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagPropertiesCollection)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    string order = orderBy == ArtifactTagOrderBy.None ? null : orderBy.ToSerialString();
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagPropertiesCollection)}");
                scope.Start();
                try
                {
                    string digest = await GetDigestAsync(cancellationToken).ConfigureAwait(false);
                    string order = orderBy == ArtifactTagOrderBy.None ? null : orderBy.ToSerialString();
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

        /// <summary> Get the collection of tags for a repository, including their full metadata. </summary>
        /// <param name="orderBy"> Requested order of tags in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Pageable<ArtifactTagProperties> GetTagPropertiesCollection(ArtifactTagOrderBy orderBy = ArtifactTagOrderBy.None, CancellationToken cancellationToken = default)
        {
            Page<ArtifactTagProperties> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagPropertiesCollection)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    string order = orderBy == ArtifactTagOrderBy.None ? null : orderBy.ToSerialString();
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
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(GetTagPropertiesCollection)}");
                scope.Start();
                try
                {
                    string digest = GetDigest(cancellationToken);
                    string order = orderBy == ArtifactTagOrderBy.None ? null : orderBy.ToSerialString();
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
        public virtual async Task<Response<ArtifactTagProperties>> UpdateTagPropertiesAsync(string tag, ArtifactTagProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(UpdateTagProperties)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateTagAttributesAsync(_repositoryName, tag, GetTagWriteableProperties(value), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static TagWriteableProperties GetTagWriteableProperties(ArtifactTagProperties value)
        {
            return new TagWriteableProperties()
            {
                CanDelete = value.CanDelete,
                CanList = value.CanList,
                CanRead = value.CanRead,
                CanWrite = value.CanWrite
            };
        }

        /// <summary> Update tag attributes. </summary>
        /// <param name="tag"> Tag name. </param>
        /// <param name="value"> Tag property value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="tag"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="tag"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="value"/> is null. </exception>
        /// <exception cref="RequestFailedException">Thrown when a failure is returned by the Container Registry service.</exception>
        public virtual Response<ArtifactTagProperties> UpdateTagProperties(string tag, ArtifactTagProperties value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(tag, nameof(tag));
            Argument.AssertNotNull(value, nameof(value));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(RegistryArtifact)}.{nameof(UpdateTagProperties)}");
            scope.Start();
            try
            {
                return _restClient.UpdateTagAttributes(_repositoryName, tag, GetTagWriteableProperties(value), cancellationToken);
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

        #region Push/Pull

        /// <summary>
        /// Push the artifact files in the path directory to the registry.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> PushAsync(string path, CancellationToken cancellationToken)
        {
            // TODO: Race condition here, do proper validation
            if (!Directory.Exists(path))
            {
                throw new Exception($"{path} not found");
            }

            var configFilePath = Path.Combine(path, "config.json");
            var manifestFilePath = Path.Combine(path, "manifest.json");

            // Upload the config file
            // TODO: Race condition here, do proper validation
            if (!File.Exists(configFilePath!))
            {
                throw new FileNotFoundException($"File not found.", configFilePath);
            }

            using (var fs = File.OpenRead(configFilePath))
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult = await _blobRestClient.StartUploadAsync(_fullyQualifiedReference, cancellationToken).ConfigureAwait(false);
                ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> uploadChunkResult = await _blobRestClient.UploadChunkAsync(startUploadResult.Headers.Location.Substring(1), fs, cancellationToken).ConfigureAwait(false);
                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult = await _blobRestClient.CompleteUploadAsync(ContentDescriptor.ComputeDigest(fs), startUploadResult.Headers.Location.Substring(1), fs, cancellationToken).ConfigureAwait(false);
            }

            // Upload each layer.
            foreach (var file in Directory.GetFiles(path))
            {
                if (file == manifestFilePath || file == configFilePath)
                {
                    continue;
                }

                using (var fs = File.OpenRead(file))
                {
                    ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult = await _blobRestClient.StartUploadAsync(_fullyQualifiedReference, cancellationToken).ConfigureAwait(false);
                    ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> uploadChunkResult = await _blobRestClient.UploadChunkAsync(startUploadResult.Headers.Location.Substring(1), fs, cancellationToken).ConfigureAwait(false);
                    ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult = await _blobRestClient.CompleteUploadAsync(ContentDescriptor.ComputeDigest(fs), startUploadResult.Headers.Location.Substring(1), fs, cancellationToken).ConfigureAwait(false);
                }
            }

            // Finally, upload the manifest.
            // TODO: Race condition here, do proper validation
            if (!File.Exists(manifestFilePath))
            {
                throw new FileNotFoundException($"File not found.", manifestFilePath);
            }

            DockerManifestV2 manifest = null;
            using (var fs = File.OpenRead(manifestFilePath))
            {
                manifest = DockerManifestV2.FromStream(fs);
            }

            return await _restClient.CreateManifestAsync(_repositoryName, _tagOrDigest, manifest, cancellationToken).ConfigureAwait(false);

            // TODO: What would make sense to return for response?
        }

        /// <summary>
        /// Pull this artifact to the specified directory.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        // TODO: provide another overload instead of setting cancellationToken default
        public virtual async Task<Response> PullToAsync(string path, CancellationToken cancellationToken = default)
        {
            // Get Manifest
            // TODO: should we expose the option to use the accept header string for this method?
            // /// <param name="accept"> Accept header string delimited by comma. For example, application/vnd.docker.distribution.manifest.v2+json. </param>
            Response<ImageManifest> manifest = await _restClient.GetManifestAsync(_repositoryName, _tagOrDigest, cancellationToken: cancellationToken).ConfigureAwait(false);

            // Get Attributes (need digest and mediaType)
            // TODO: we could cache these ... or if we could get digest and media type from the manifest itself, we wouldn't need them from the attributes/properties
            //ArtifactManifestProperties properties = await this.GetManifestPropertiesAsync(cancellationToken).ConfigureAwait(false);
            //var manifest = GetManifestSubtype(baseManifest, properties.MediaType);

            // TODO: is this the best way to do this?
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Download manifest
            // TODO: Actually, we've already downloaded it, now we're just writing it to file
            string manifestFile = Path.Combine(path, "manifest.json");

            // TODO: is Create the proper semantics here?  OpenWrite could write a shorter string to the file
            // and end up with a corrupted format.
            using (FileStream fs = File.Create(manifestFile))
            {
                // TODO: an extra allocation to new this each time
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };
                await JsonSerializer.SerializeAsync(fs, manifest.Value, manifest.Value.GetType(), options, cancellationToken).ConfigureAwait(false);
            }

            // Download config
            string configFile = Path.Combine(path, "config.json");
            ContentDescriptor configDescriptor = GetConfigDescriptor(manifest);
            if (configDescriptor != null)
            {
                await DownloadLayerAsync(_repositoryName, configDescriptor.Digest, configFile, cancellationToken).ConfigureAwait(false);
            }

            // Write Layers
            IList<ContentDescriptor> layerDescriptors = GetLayerDescriptors(manifest);
            if (layerDescriptors != null)
            {
                for (int i = 0; i < layerDescriptors.Count; i++)
                {
                    ContentDescriptor layerDescriptor = layerDescriptors[i];
                    // Trim "sha256:" from the digest
                    var fileName = layerDescriptor.Annotations?.Title ?? TrimSha(layerDescriptor.Digest);
                    fileName = Path.Combine(path, fileName);
                    await DownloadLayerAsync(_repositoryName, layerDescriptor.Digest, fileName, cancellationToken).ConfigureAwait(false);
                }
            }

            // TODO: need to return an appropriate response
            return manifest.GetRawResponse();
        }

        private static ContentDescriptor GetConfigDescriptor(ImageManifest manifest)
        {
            switch (manifest)
            {
                case OciManifest ociManifest:
                    return ociManifest.ConfigDescriptor;
                case DockerManifestV2 dockerManifestV2:
                    return dockerManifestV2.ConfigDescriptor;
            }

            return null;
        }

        private static IList<ContentDescriptor> GetLayerDescriptors(ImageManifest manifest)
        {
            switch (manifest)
            {
                case OciManifest ociManifest:
                    return ociManifest.Layers;
                case DockerManifestV2 dockerManifestV2:
                    return dockerManifestV2.Layers;
            }

            return null;
        }

        // TODO: Can we make this more performant?
        private static string TrimSha(string digest)
        {
            int index = digest.IndexOf(':');
            if (index > -1)
            {
                return digest.Substring(index + 1);
            }

            return digest;
        }

        private async Task DownloadLayerAsync(string repo, string digest, string filename, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            // TODO: we'll need to dispose the stream properly
            ResponseWithHeaders<Stream, ContainerRegistryBlobGetBlobHeaders> blobResult = await _blobRestClient.GetBlobAsync(repo, digest, cancellationToken).ConfigureAwait(false);

            using (FileStream fs = File.Create(filename))
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                await blobResult.Value.CopyToAsync(fs).ConfigureAwait(false);
            }
        }
        #endregion
    }
}

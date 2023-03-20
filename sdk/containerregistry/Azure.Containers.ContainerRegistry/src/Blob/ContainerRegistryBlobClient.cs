// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> The Azure Container Registry blob client, responsible for uploading and downloading
    /// blobs and manifests, the building blocks of artifacts. </summary>
    public class ContainerRegistryBlobClient
    {
        private const int DefaultChunkSize = 4 * 1024 * 1024; // 4MB

        private readonly Uri _endpoint;
        private readonly string _registryName;
        private readonly string _repositoryName;
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly IContainerRegistryAuthenticationClient _acrAuthClient;
        private readonly ContainerRegistryBlobRestClient _blobRestClient;
        private readonly int _maxRetries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="repositoryName">The name of the repository that logically groups the artifact parts.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="repositoryName"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName) :
            this(endpoint, repositoryName, new ContainerRegistryAnonymousAccessCredential(), new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="repositoryName">The name of the repository that logically groups the artifact parts.</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="repositoryName"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName, ContainerRegistryClientOptions options) :
            this(endpoint, repositoryName, new ContainerRegistryAnonymousAccessCredential(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repositoryName">The name of the repository that logically groups the artifact parts.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/>, <paramref name="credential"/>, or <paramref name="repositoryName"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName, TokenCredential credential) : this(endpoint, repositoryName, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repositoryName">The name of the repository that logically groups the artifact parts.</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/>, <paramref name="credential"/>, or <paramref name="repositoryName"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName, TokenCredential credential, ContainerRegistryClientOptions options) : this(endpoint, credential, repositoryName, null, options)
        {
        }

        internal ContainerRegistryBlobClient(
            Uri endpoint,
            TokenCredential credential,
            string repositoryName,
            IContainerRegistryAuthenticationClient authenticationClient,
            ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(repositoryName, nameof(repositoryName));

            _endpoint = endpoint;
            _registryName = endpoint.Host.Split('.')[0];
            _repositoryName = repositoryName;
            _maxRetries = options.Retry.MaxRetries;
            _maxChunkSize = options?.MaxChunkSize ?? DefaultChunkSize;
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = authenticationClient ?? new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            string defaultScope = (options.Audience?.ToString() ?? ContainerRegistryClient.DefaultScope) + "/.default";
            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, defaultScope, _acrAuthClient));
            _restClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
            _blobRestClient = new ContainerRegistryBlobRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of ContainerRegistryBlobClient for mocking. </summary>
        protected ContainerRegistryBlobClient()
        {
        }

        /// <summary>
        /// Gets the registry service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Gets the name of the repository that logically groups the artifact parts.
        /// </summary>
        public virtual string RepositoryName => _repositoryName;

        /// <summary>
        /// The HttpPipeline.
        /// </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        public virtual Response<UploadManifestResult> UploadManifest(OciImageManifest manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream stream = SerializeManifest(manifest);
                return UploadManifestInternalAsync(stream, tag, mediaType, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The <see cref="BinaryData"/> containing the serialized manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        public virtual Response<UploadManifestResult> UploadManifest(BinaryData manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            return UploadManifest(manifest.ToStream(), tag, mediaType, cancellationToken);
        }

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The <see cref="Stream"/> containing the serialized manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        internal virtual Response<UploadManifestResult> UploadManifest(Stream manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream manifestStream = CopyStreamAsync(manifest, false).EnsureCompleted();
                return UploadManifestInternalAsync(manifestStream, tag, mediaType, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(OciImageManifest manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream stream = SerializeManifest(manifest);
                return await UploadManifestInternalAsync(stream, tag, mediaType, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The <see cref="BinaryData"/> containing the serialized manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(BinaryData manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            return await UploadManifestAsync(manifest.ToStream(), tag, mediaType, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Uploads an artifact manifest.
        /// </summary>
        /// <param name="manifest">The <see cref="Stream"/> containing the serialized manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the manifest upload.</returns>
        internal virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(Stream manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream manifestStream = await CopyStreamAsync(manifest, true).ConfigureAwait(false);
                return await UploadManifestInternalAsync(manifestStream, tag, mediaType, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<UploadManifestResult>> UploadManifestInternalAsync(MemoryStream manifest, string tag, ManifestMediaType? mediaType, bool async, CancellationToken cancellationToken)
        {
            string contentDigest = BlobHelper.ComputeDigest(manifest);
            string tagOrDigest = tag ?? contentDigest;
            string contentType = mediaType.HasValue ? mediaType.ToString() : ManifestMediaType.OciImageManifest.ToString();

            ResponseWithHeaders<ContainerRegistryCreateManifestHeaders> response = async ?
                await _restClient.CreateManifestAsync(_repositoryName, tagOrDigest, manifest, contentType, cancellationToken).ConfigureAwait(false) :
                _restClient.CreateManifest(_repositoryName, tagOrDigest, manifest, contentType, cancellationToken);

            BlobHelper.ValidateDigest(contentDigest, response.Headers.DockerContentDigest);

            return Response.FromValue(new UploadManifestResult(response.Headers.DockerContentDigest), response.GetRawResponse());
        }

        /// <summary>
        /// Make a copy of the manifest stream so we can seek around it when computing its digest.
        /// </summary>
        /// <param name="stream">The stream to copy.</param>
        /// <param name="async">Whether the method was called from an async method.</param>
        /// <returns></returns>
        private static async Task<MemoryStream> CopyStreamAsync(Stream stream, bool async)
        {
            MemoryStream copy = new();

            if (async)
            {
                await stream.CopyToAsync(copy).ConfigureAwait(false);
            }
            else
            {
                stream.CopyTo(copy);
            }

            copy.Position = 0;

            return copy;
        }

        private static MemoryStream SerializeManifest(OciImageManifest manifest)
        {
            MemoryStream stream = new();
            Utf8JsonWriter jsonWriter = new(stream);
            ((IUtf8JsonSerializable)manifest).Write(jsonWriter);
            jsonWriter.Flush();

            stream.Position = 0;

            return stream;
        }

        private static OciImageManifest DeserializeManifest(Stream manifest)
        {
            using var document = JsonDocument.Parse(manifest);
            return OciImageManifest.DeserializeOciImageManifest(document.RootElement);
        }

        /// <summary>
        /// Upload a container registry blob.
        /// </summary>
        /// <param name="content">The blob content.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the blob upload.  The raw response associated with this result is the response from the final complete upload request.</returns>
        public virtual Response<UploadBlobResult> UploadBlob(BinaryData content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return UploadBlob(content.ToStream(), cancellationToken);
        }

        /// <summary>
        /// Upload a container registry blob.
        /// </summary>
        /// <param name="content">The stream containing the blob data.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the blob upload.  The raw response associated with this result is the response from the final complete upload request.</returns>
        public virtual Response<UploadBlobResult> UploadBlob(Stream content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult =
                    _blobRestClient.StartUpload(_repositoryName, cancellationToken);

                var result = UploadInChunksInternalAsync(startUploadResult.Headers.Location, content, _maxChunkSize, async: false, cancellationToken: cancellationToken).EnsureCompleted();

                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult =
                    _blobRestClient.CompleteUpload(result.Digest, result.Location, null, cancellationToken);

                BlobHelper.ValidateDigest(result.Digest, completeUploadResult.Headers.DockerContentDigest);

                return Response.FromValue(new UploadBlobResult(completeUploadResult.Headers.DockerContentDigest, result.SizeInBytes), completeUploadResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upload a container registry blob.
        /// </summary>
        /// <param name="content">The blob content.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the blob upload.  The raw response associated with this result is the response from the final complete upload request.</returns>
        public virtual async Task<Response<UploadBlobResult>> UploadBlobAsync(BinaryData content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            return await UploadBlobAsync(content.ToStream(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Upload a container registry blob.
        /// </summary>
        /// <param name="content">The stream containing the blob data.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The result of the blob upload.  The raw response associated with this result is the response from the final complete upload request.</returns>
        public virtual async Task<Response<UploadBlobResult>> UploadBlobAsync(Stream content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult =
                    await _blobRestClient.StartUploadAsync(_repositoryName, cancellationToken).ConfigureAwait(false);

                var result = await UploadInChunksInternalAsync(startUploadResult.Headers.Location, stream, _maxChunkSize, cancellationToken: cancellationToken).ConfigureAwait(false);

                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult =
                    await _blobRestClient.CompleteUploadAsync(result.Digest, result.Location, null, cancellationToken).ConfigureAwait(false);

                BlobHelper.ValidateDigest(result.Digest, completeUploadResult.Headers.DockerContentDigest);

                return Response.FromValue(new UploadBlobResult(completeUploadResult.Headers.DockerContentDigest, result.SizeInBytes), completeUploadResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<ChunkedUploadResult> UploadInChunksInternalAsync(string location, Stream content, int chunkSize, bool async = true, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> uploadChunkResult = null;

            // If the stream is seekable and smaller than the max chunk size, upload in a single chunk.
            if (TryGetLength(content, out long length) && length < chunkSize)
            {
                // Create a copy so we don't dispose the caller's stream when sending.
                using MemoryStream chunk = async ?
                    await CopyStreamAsync(content, true).ConfigureAwait(false) :
                    CopyStreamAsync(content, false).EnsureCompleted();

                string digest = BlobHelper.ComputeDigest(chunk);

                uploadChunkResult = async ?
                    await _blobRestClient.UploadChunkAsync(location, chunk, cancellationToken: cancellationToken).ConfigureAwait(false) :
                    _blobRestClient.UploadChunk(location, chunk, cancellationToken: cancellationToken);

                return new ChunkedUploadResult(digest, uploadChunkResult.Headers.Location, length);
            }

            // Otherwise, upload in multiple chunks.
            byte[] buffer = ArrayPool<byte>.Shared.Rent(chunkSize);
            long chunkCount = 0;
            long blobLength = 0;
            using SHA256 sha256 = SHA256.Create();

            try
            {
                // Read first chunk into buffer.
                int bytesRead = async ?
                    await content.ReadAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false) :
                    content.Read(buffer, 0, chunkSize);

                while (bytesRead > 0)
                {
                    var contentRange = GetContentRange(chunkCount * chunkSize, bytesRead);
                    location = uploadChunkResult?.Headers.Location ?? location;

                    // Incrementally compute hash for digest.
                    sha256.TransformBlock(buffer, 0, bytesRead, buffer, 0);

                    using (Stream chunk = new MemoryStream(buffer, 0, bytesRead))
                    {
                        uploadChunkResult = async ?
                            await _blobRestClient.UploadChunkAsync(location, chunk, contentRange, bytesRead.ToString(CultureInfo.InvariantCulture), cancellationToken).ConfigureAwait(false) :
                            _blobRestClient.UploadChunk(location, chunk, contentRange, bytesRead.ToString(CultureInfo.InvariantCulture), cancellationToken);
                    }

                    blobLength += bytesRead;
                    chunkCount++;

                    // Read next chunk into buffer
                    bytesRead = async ?
                        await content.ReadAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false) :
                        content.Read(buffer, 0, chunkSize);
                }

                // Complete hash computation.
                sha256.TransformFinalBlock(buffer, 0, 0);

                return new ChunkedUploadResult(BlobHelper.FormatDigest(sha256.Hash), uploadChunkResult.Headers.Location, blobLength);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// ACR has a non-standard use of the Content-Range header in the PATCH chunked
        /// upload request. This converts range to the format used by this API,
        /// <see href="https://docs.docker.com/registry/spec/api/#patch-blob-upload"/> for details.
        /// </summary>
        /// <param name="offset">The offset of the chunk in the blob stream.</param>
        /// <param name="length">The length of the chunk.</param>
        /// <returns>A string describing the chunk range in the non-standard Content-Range header format.</returns>
        private static string GetContentRange(long offset, long length)
        {
            var endRange = (offset + length - 1).ToString(CultureInfo.InvariantCulture);
            return FormattableString.Invariant($"{offset}-{endRange}");
        }

        private static long GetBlobSizeFromContentRange(string contentRange)
        {
            string size = contentRange.Split('/')[1];
            return long.Parse(size, CultureInfo.InvariantCulture);
        }

        // Some streams will throw if you try to access their length so we wrap
        // the check in a TryGet helper.
        private static bool TryGetLength(Stream content, out long length)
        {
            length = 0;
            try
            {
                if (content.CanSeek)
                {
                    length = content.Length;
                    return true;
                }
            }
            catch (NotSupportedException)
            {
            }
            return false;
        }

        /// <summary>
        /// Downloads a manifest.
        /// </summary>
        /// <param name="tagOrDigest">The tag or digest of the manifest to download.</param>
        /// <param name="mediaTypes">The set of media types to accept for the manifest being downloaded.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual Response<DownloadManifestResult> DownloadManifest(string tagOrDigest, IEnumerable<ManifestMediaType> mediaTypes, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));
            Argument.AssertNotNull(mediaTypes, nameof(mediaTypes));

            return DownloadManifest(tagOrDigest, string.Join(", ", mediaTypes), cancellationToken);
        }

        /// <summary>
        /// Downloads a manifest.
        /// </summary>
        /// <param name="tagOrDigest">The tag or digest of the manifest to download.</param>
        /// <param name="mediaType">The media type of the manifest to download.  If not specified, all media types will be requested.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual Response<DownloadManifestResult> DownloadManifest(string tagOrDigest, ManifestMediaType? mediaType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadManifest)}");
            scope.Start();
            try
            {
                string accept = GetAcceptHeader(mediaType);

                Response<ManifestWrapper> response = _restClient.GetManifest(_repositoryName, tagOrDigest, accept, cancellationToken);
                Response rawResponse = response.GetRawResponse();

                rawResponse.Headers.TryGetValue("Docker-Content-Digest", out string digest);
                rawResponse.Headers.TryGetValue("Content-Type", out string contentType);

                var contentDigest = BlobHelper.ComputeDigest(rawResponse.ContentStream);

                if (ReferenceIsDigest(tagOrDigest))
                {
                    BlobHelper.ValidateDigest(contentDigest, tagOrDigest, "The digest of the received manifest does not match the requested digest reference.");
                }
                else
                {
                    BlobHelper.ValidateDigest(contentDigest, digest);
                }

                return Response.FromValue(new DownloadManifestResult(digest, contentType, rawResponse.Content), rawResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Downloads a manifest.
        /// </summary>
        /// <param name="tagOrDigest">The tag or digest of the manifest to download.</param>
        /// <param name="mediaTypes">The set of media types to accept for the manifest being downloaded.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual async Task<Response<DownloadManifestResult>> DownloadManifestAsync(string tagOrDigest, IEnumerable<ManifestMediaType> mediaTypes, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));
            Argument.AssertNotNull(mediaTypes, nameof(mediaTypes));

            return await DownloadManifestAsync(tagOrDigest, string.Join(", ", mediaTypes), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Downloads a manifest.
        /// </summary>
        /// <param name="tagOrDigest">The tag or digest of the manifest to download.</param>
        /// <param name="mediaType">The media type of the manifest to download.  If not specified, all media types will be requested.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual async Task<Response<DownloadManifestResult>> DownloadManifestAsync(string tagOrDigest, ManifestMediaType? mediaType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tagOrDigest, nameof(tagOrDigest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadManifest)}");
            scope.Start();
            try
            {
                string accept = GetAcceptHeader(mediaType);

                Response<ManifestWrapper> response = await _restClient.GetManifestAsync(_repositoryName, tagOrDigest, accept, cancellationToken).ConfigureAwait(false);
                Response rawResponse = response.GetRawResponse();

                rawResponse.Headers.TryGetValue("Docker-Content-Digest", out var digest);
                rawResponse.Headers.TryGetValue("Content-Type", out string contentType);

                var contentDigest = BlobHelper.ComputeDigest(rawResponse.ContentStream);

                if (ReferenceIsDigest(tagOrDigest))
                {
                    BlobHelper.ValidateDigest(contentDigest, tagOrDigest, "The digest of the received manifest does not match the requested digest reference.");
                }
                else
                {
                    BlobHelper.ValidateDigest(contentDigest, digest);
                }

                return Response.FromValue(new DownloadManifestResult(digest, contentType, rawResponse.Content), rawResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static string GetAcceptHeader(ManifestMediaType? mediaType)
        {
            if (mediaType.HasValue)
            {
                return (string)mediaType.Value;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(ManifestMediaType.DockerManifest);
            sb.Append(", ");
            sb.Append(ManifestMediaType.DockerManifestList);
            sb.Append(", ");
            sb.Append(ManifestMediaType.DockerManifestV1);
            sb.Append(", ");
            sb.Append(ManifestMediaType.OciImageManifest);
            sb.Append(", ");
            sb.Append(ManifestMediaType.OciIndex);

            return sb.ToString();
        }

        private static bool ReferenceIsDigest(string reference)
        {
            return reference.StartsWith("sha256:", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Download a container registry blob.
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// To download a blob that does not fit in memory, consider using the <see cref="DownloadBlobTo(string, Stream, CancellationToken)"/> method instead.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<DownloadBlobResult> DownloadBlobContent(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobContent)}");
            scope.Start();
            try
            {
                return DownloadBlobContentInternalAsync(digest, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Download a container registry blob.
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// To download a blob that does not fit in memory, consider using the <see cref="DownloadBlobToAsync(string, Stream, CancellationToken)"/> method instead.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadBlobResult>> DownloadBlobContentAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobContent)}");
            scope.Start();
            try
            {
                return await DownloadBlobContentInternalAsync(digest, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<DownloadBlobResult>> DownloadBlobContentInternalAsync(string digest, bool async, CancellationToken cancellationToken)
        {
            ResponseWithHeaders<Stream, ContainerRegistryBlobGetBlobHeaders> blobResult = async ?
                await _blobRestClient.GetBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false) :
                _blobRestClient.GetBlob(_repositoryName, digest, cancellationToken);

            BinaryData data = async ?
                await BinaryData.FromStreamAsync(blobResult.Value, cancellationToken).ConfigureAwait(false) :
                BinaryData.FromStream(blobResult.Value);

            string contentDigest = BlobHelper.ComputeDigest(data);
            BlobHelper.ValidateDigest(contentDigest, digest);

            return Response.FromValue(new DownloadBlobResult(digest, data), blobResult.GetRawResponse());
        }

        /// <summary>
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<DownloadBlobStreamingResult> DownloadBlobStreaming(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobStreaming)}");
            scope.Start();
            try
            {
                return DownloadBlobStreamingInternalAsync(digest, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadBlobStreamingResult>> DownloadBlobStreamingAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobStreaming)}");
            scope.Start();
            try
            {
                return await DownloadBlobStreamingInternalAsync(digest, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<DownloadBlobStreamingResult>> DownloadBlobStreamingInternalAsync(string digest, bool async, CancellationToken cancellationToken)
        {
            ResponseWithHeaders<Stream, ContainerRegistryBlobGetBlobHeaders> blobResult = async ?
                await _blobRestClient.GetBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false) :
                _blobRestClient.GetBlob(_repositoryName, digest, cancellationToken);

            // Wrap the response Content in a RetriableStream so we
            // can return it before it's finished downloading, but still
            // allow retrying if it fails.
            Stream retriableStream = RetriableStream.Create(
                blobResult.Value,
                offset => _blobRestClient.GetChunk(_repositoryName, digest, new HttpRange(offset).ToString(), cancellationToken).Value,
                async offset => await _blobRestClient.GetChunkAsync(_repositoryName, digest, new HttpRange(offset).ToString(), cancellationToken).ConfigureAwait(false),
                _pipeline.ResponseClassifier,
                _maxRetries);

            ValidatingStream stream = new(retriableStream, (int)blobResult.Headers.ContentLength.Value, digest);

            return Response.FromValue(new DownloadBlobStreamingResult(digest, stream), blobResult.GetRawResponse());
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="path">A file path to write the downloaded content to.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual Response DownloadBlobTo(string digest, string path, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(path, nameof(path));

            return DownloadBlobTo(digest, path, new DownloadBlobToOptions(DefaultChunkSize), cancellationToken);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="path">A file path to write the downloaded content to.</param>
        /// <param name="options">Options to configure the operation behavior.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual Response DownloadBlobTo(string digest, string path, DownloadBlobToOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(path, nameof(path));
            Argument.AssertNotNull(options, nameof(options));

            using Stream destination = File.Create(path);
            return DownloadBlobTo(digest, destination, cancellationToken);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The response corresponding to the final GET blob chunk request.</returns>
        public virtual Response DownloadBlobTo(string digest, Stream destination, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));

            return DownloadBlobTo(digest, destination, new DownloadBlobToOptions(DefaultChunkSize), cancellationToken);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="options">Options to configure the operation behavior.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual Response DownloadBlobTo(string digest, Stream destination, DownloadBlobToOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobTo)}");
            scope.Start();
            try
            {
                return DownloadBlobToInternalAsync(digest, destination, options, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.  This approach will download the blob
        /// to the destination stream in sequential chunks of bytes.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="path">A file path to write the downloaded content to.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual async Task<Response> DownloadBlobToAsync(string digest, string path, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(path, nameof(path));

            return await DownloadBlobToAsync(digest, path, new DownloadBlobToOptions(DefaultChunkSize), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.  This approach will download the blob
        /// to the destination stream in sequential chunks of bytes.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="path">A file path to write the downloaded content to.</param>
        /// <param name="options">Options to configure the operation behavior.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual async Task<Response> DownloadBlobToAsync(string digest, string path, DownloadBlobToOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(path, nameof(path));
            Argument.AssertNotNull(options, nameof(options));

            using Stream destination = File.Create(path);
            return await DownloadBlobToAsync(digest, destination, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.  This approach will download the blob
        /// to the destination stream in sequential chunks of bytes.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual async Task<Response> DownloadBlobToAsync(string digest, Stream destination, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));

            return await DownloadBlobToAsync(digest, destination, new DownloadBlobToOptions(DefaultChunkSize), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.  This approach will download the blob
        /// to the destination stream in sequential chunks of bytes.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="options">Options to configure the operation behavior.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual async Task<Response> DownloadBlobToAsync(string digest, Stream destination, DownloadBlobToOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobTo)}");
            scope.Start();
            try
            {
                return await DownloadBlobToInternalAsync(digest, destination, options, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response> DownloadBlobToInternalAsync(string digest, Stream destination, DownloadBlobToOptions options, bool async, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(options.MaxChunkSize);
            long bytesDownloaded = 0;
            using SHA256 sha256 = SHA256.Create();
            long? blobSize = default;

            try
            {
                Response result = null;
                do
                {
                    int chunkSize = blobSize.HasValue ?
                        (int)Math.Min(blobSize.Value - bytesDownloaded, options.MaxChunkSize) :
                        options.MaxChunkSize;
                    HttpRange range = new HttpRange(bytesDownloaded, chunkSize);

                    var chunkResult = async ?
                        await _blobRestClient.GetChunkAsync(_repositoryName, digest, range.ToString(), cancellationToken).ConfigureAwait(false) :
                        _blobRestClient.GetChunk(_repositoryName, digest, range.ToString(), cancellationToken);

                    blobSize ??= GetBlobSizeFromContentRange(chunkResult.Headers.ContentRange);
                    chunkSize = (int)chunkResult.Headers.ContentLength.Value;

                    if (async)
                    {
                        await chunkResult.Value.ReadAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false);
                        sha256.TransformBlock(buffer, 0, chunkSize, buffer, 0);
                        await destination.WriteAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        chunkResult.Value.Read(buffer, 0, chunkSize);
                        sha256.TransformBlock(buffer, 0, chunkSize, buffer, 0);
                        destination.Write(buffer, 0, chunkSize);
                    }

                    bytesDownloaded += chunkSize;

                    result = chunkResult.GetRawResponse();
                }
                while (bytesDownloaded < blobSize.Value);

                // Complete hash computation.
                sha256.TransformFinalBlock(buffer, 0, 0);
                string computedDigest = BlobHelper.FormatDigest(sha256.Hash);
                BlobHelper.ValidateDigest(computedDigest, digest);

                if (async)
                {
                    await destination.FlushAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    destination.Flush();
                }

                // Return the last response received.
                return result;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        /// <summary>
        /// Delete a blob.
        /// </summary>
        /// <param name="digest">The digest of the blob to delete.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The response received from the delete operation.</returns>
        public virtual Response DeleteBlob(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<Stream, ContainerRegistryBlobDeleteBlobHeaders> blobResult = _blobRestClient.DeleteBlob(_repositoryName, digest, cancellationToken);
                return blobResult.GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a blob.
        /// </summary>
        /// <param name="digest">The digest of the blob to delete.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The response received from the delete operation.</returns>
        public virtual async Task<Response> DeleteBlobAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<Stream, ContainerRegistryBlobDeleteBlobHeaders> blobResult = await _blobRestClient.DeleteBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
                return blobResult.GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a manifest.  Doing so effectively deletes the artifact from the registry.
        /// </summary>
        /// <param name="digest">The digest of the manifest to delete.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The response received from the delete operation.</returns>
        public virtual Response DeleteManifest(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteManifest)}");
            scope.Start();
            try
            {
                return _restClient.DeleteManifest(_repositoryName, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a manifest.  Doing so effectively deletes the artifact from the registry.
        /// </summary>
        /// <param name="digest">The digest of the manifest to delete.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The response received from the delete operation.</returns>
        public virtual async Task<Response> DeleteManifestAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteManifest)}");
            scope.Start();
            try
            {
                return await _restClient.DeleteManifestAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

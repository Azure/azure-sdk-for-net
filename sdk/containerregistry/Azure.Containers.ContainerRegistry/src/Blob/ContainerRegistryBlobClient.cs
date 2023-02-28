// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary> The Azure Container Registry blob client, responsible for uploading and downloading
    /// blobs and manifests, the building blocks of artifacts. </summary>
    public class ContainerRegistryBlobClient
    {
        private const int DefaultChunkSize = 4 * 1024 * 1024; // 4MB
        private readonly int _maxChunkSize;

        private readonly Uri _endpoint;
        private readonly string _registryName;
        private readonly string _repositoryName;
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly IContainerRegistryAuthenticationClient _acrAuthClient;
        private readonly ContainerRegistryBlobRestClient _blobRestClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="repository">The name of the repository that logically groups the artifact parts.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="repository"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repository) :
            this(endpoint,  repository, new ContainerRegistryAnonymousAccessCredential(), new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts,
        /// using anonymous access to the registry.  Only operations that support anonymous access are enabled.  Other service
        /// methods will throw <see cref="RequestFailedException"/> if called from this client.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="repository">The name of the repository that logically groups the artifact parts.</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="repository"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repository, ContainerRegistryClientOptions options) :
            this(endpoint, repository, new ContainerRegistryAnonymousAccessCredential(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repository">The name of the repository that logically groups the artifact parts.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/>, <paramref name="credential"/>, or <paramref name="repository"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repository, TokenCredential credential) : this(endpoint, repository, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryBlobClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repository">The name of the repository that logically groups the artifact parts.</param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/>, <paramref name="credential"/>, or <paramref name="repository"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, string repository, TokenCredential credential, ContainerRegistryClientOptions options) : this(endpoint, credential, repository, null, options)
        {
        }

        internal ContainerRegistryBlobClient(
            Uri endpoint,
            TokenCredential credential,
            string repository,
            IContainerRegistryAuthenticationClient authenticationClient,
            ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(repository, nameof(repository));

            if (options.Audience == null)
            {
                throw new InvalidOperationException($"{nameof(ContainerRegistryClientOptions.Audience)} property must be set to initialize a {nameof(ContainerRegistryBlobClient)}.");
            }

            _endpoint = endpoint;
            _registryName = endpoint.Host.Split('.')[0];
            _repositoryName = repository;
            _maxChunkSize = options?.MaxChunkSize ?? DefaultChunkSize;
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = authenticationClient ?? new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            string defaultScope = options.Audience + "/.default";
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
        /// <returns></returns>
        public virtual Response<UploadManifestResult> UploadManifest(OciManifest manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
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
        /// <param name="manifestStream">The <see cref="Stream"/> manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<UploadManifestResult> UploadManifest(Stream manifestStream, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifestStream, nameof(manifestStream));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream stream = CopyStreamAsync(manifestStream, false).EnsureCompleted();
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
        /// <param name="manifest">The manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(OciManifest manifest, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
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
        /// <param name="manifestStream">The <see cref="Stream"/> manifest to upload.</param>
        /// <param name="tag">A optional tag to assign to the artifact this manifest represents.</param>
        /// <param name="mediaType">The media type of the manifest.  If not specified, this value will be set to
        /// a default value of "application/vnd.oci.image.manifest.v1+json".</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(Stream manifestStream, string tag = default, ManifestMediaType? mediaType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifestStream, nameof(manifestStream));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using MemoryStream stream = await CopyStreamAsync(manifestStream, true).ConfigureAwait(false);
                return await UploadManifestInternalAsync(stream, tag, mediaType, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<UploadManifestResult>> UploadManifestInternalAsync(MemoryStream stream, string tag, ManifestMediaType? mediaType, bool async, CancellationToken cancellationToken)
        {
            string contentDigest = BlobHelper.ComputeDigest(stream);
            string tagOrDigest = tag ?? contentDigest;
            string contentType = mediaType.HasValue ? mediaType.ToString() : ManifestMediaType.OciManifest.ToString();

            ResponseWithHeaders<ContainerRegistryCreateManifestHeaders> response = async ?
                await _restClient.CreateManifestAsync(_repositoryName, tagOrDigest, stream, contentType, cancellationToken).ConfigureAwait(false) :
                _restClient.CreateManifest(_repositoryName, tagOrDigest, stream, contentType, cancellationToken);

            ValidateDigest(contentDigest, response.Headers.DockerContentDigest);

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

        private static MemoryStream SerializeManifest(OciManifest manifest)
        {
            MemoryStream stream = new();
            Utf8JsonWriter jsonWriter = new(stream);
            ((IUtf8JsonSerializable)manifest).Write(jsonWriter);
            jsonWriter.Flush();

            stream.Position = 0;

            return stream;
        }

        private static OciManifest DeserializeManifest(Stream stream)
        {
            using var document = JsonDocument.Parse(stream);
            return OciManifest.DeserializeOciManifest(document.RootElement);
        }

        /// <summary>
        /// Upload an artifact blob.
        /// </summary>
        /// <param name="stream">The stream containing the blob data.</param>
        /// <param name="options">Options for the blob upload.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<UploadBlobResult> UploadBlob(Stream stream, UploadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult =
                    _blobRestClient.StartUpload(_repositoryName, cancellationToken);

                var result = UploadInChunksInternalAsync(startUploadResult.Headers.Location, stream, _maxChunkSize, async: false, cancellationToken: cancellationToken).EnsureCompleted();

                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult =
                    _blobRestClient.CompleteUpload(result.Digest, result.Location, null, cancellationToken);

                ValidateDigest(result.Digest, completeUploadResult.Headers.DockerContentDigest);

                return Response.FromValue(new UploadBlobResult(completeUploadResult.Headers.DockerContentDigest, result.Size), completeUploadResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upload an artifact blob.
        /// </summary>
        /// <param name="stream">The stream containing the blob data.</param>
        /// <param name="options">Options for the blob upload.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadBlobResult>> UploadBlobAsync(Stream stream, UploadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult =
                    await _blobRestClient.StartUploadAsync(_repositoryName, cancellationToken).ConfigureAwait(false);

                var result = await UploadInChunksInternalAsync(startUploadResult.Headers.Location, stream, _maxChunkSize, cancellationToken: cancellationToken).ConfigureAwait(false);

                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult =
                    await _blobRestClient.CompleteUploadAsync(result.Digest, result.Location, null, cancellationToken).ConfigureAwait(false);

                ValidateDigest(result.Digest, completeUploadResult.Headers.DockerContentDigest);

                return Response.FromValue(new UploadBlobResult(completeUploadResult.Headers.DockerContentDigest, result.Size), completeUploadResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<ChunkedUploadResult> UploadInChunksInternalAsync(string location, Stream stream, int chunkSize, bool async = true, CancellationToken cancellationToken = default)
        {
            ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> uploadChunkResult = null;

            // If the stream is seekable and smaller than the max chunk size, upload in a single chunk.
            if (TryGetLength(stream, out long length) && length < chunkSize)
            {
                // Create a copy so we don't dispose the caller's stream when sending.
                using MemoryStream chunk = async ?
                    await CopyStreamAsync(stream, true).ConfigureAwait(false) :
                    CopyStreamAsync(stream, false).EnsureCompleted();

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
                    await stream.ReadAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false) :
                    stream.Read(buffer, 0, chunkSize);

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
                        await stream.ReadAsync(buffer, 0, chunkSize, cancellationToken).ConfigureAwait(false) :
                        stream.Read(buffer, 0, chunkSize);
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
        /// Downloads the manifest for an OCI artifact.
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
                    ValidateDigest(contentDigest, tagOrDigest, "The digest of the received manifest does not match the requested digest reference.");
                }
                else
                {
                    ValidateDigest(contentDigest, digest);
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
        /// Downloads the manifest for an OCI artifact.
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
                    ValidateDigest(contentDigest, tagOrDigest, "The digest of the received manifest does not match the requested digest reference.");
                }
                else
                {
                    ValidateDigest(contentDigest, digest);
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
            sb.Append(ManifestMediaType.OciManifest);
            sb.Append(", ");
            sb.Append(ManifestMediaType.OciIndex);

            return sb.ToString();
        }

        private static bool ReferenceIsDigest(string reference)
        {
            return reference.StartsWith("sha256:", StringComparison.OrdinalIgnoreCase);
        }

        private static void ValidateDigest(string clientDigest, string serverDigest, string message = default)
        {
            message ??= "The server-computed digest does not match the client-computed digest.";

            if (!clientDigest.Equals(serverDigest, StringComparison.OrdinalIgnoreCase))
            {
                throw new RequestFailedException(message);
            }
        }

        /// <summary>
        /// Download an artifact blob.
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// To download a blob that does not fit in memory, please use the <see cref="DownloadBlobTo"/> method instead.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<DownloadBlobResult> DownloadBlob(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlob)}");
            scope.Start();
            try
            {
                return DownloadBlobInternalAsync(digest, false, cancellationToken).EnsureCompleted();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Download an artifact blob.
        /// This API is a prefered way to fetch blobs that can fit into memory.
        /// The content is provided as <see cref="BinaryData"/> that provides a lightweight abstraction for a payload of bytes.
        /// It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes.
        /// To download a blob that does not fit in memory, please use the <see cref="DownloadBlobToAsync"/> method instead.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadBlobResult>> DownloadBlobAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlob)}");
            scope.Start();
            try
            {
                return await DownloadBlobInternalAsync(digest, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response<DownloadBlobResult>> DownloadBlobInternalAsync(string digest, bool async, CancellationToken cancellationToken)
        {
            ResponseWithHeaders<Stream, ContainerRegistryBlobGetBlobHeaders> blobResult = async ?
                await _blobRestClient.GetBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false) :
                _blobRestClient.GetBlob(_repositoryName, digest, cancellationToken);

            var contentDigest = BlobHelper.ComputeDigest(blobResult.Value);
            ValidateDigest(contentDigest, digest);

            BinaryData data = async ?
                await BinaryData.FromStreamAsync(blobResult.Value, cancellationToken).ConfigureAwait(false) :
                BinaryData.FromStream(blobResult.Value);

            return Response.FromValue(new DownloadBlobResult(digest, data), blobResult.GetRawResponse());
        }

        /// <summary>
        /// Download a blob to a passed-in destination stream.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual Response DownloadBlobTo(string digest, Stream destination, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobTo)}");
            scope.Start();
            try
            {
                return DownloadBlobToInternalAsync(digest, destination, false, cancellationToken).EnsureCompleted();
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
        /// <param name="destination">Destination for the downloaded blob.</param>
        /// <param name="cancellationToken"> The cancellation token to use.</param>
        /// <returns>The raw response corresponding to the final GET blob chunk request.</returns>
        public virtual async Task<Response> DownloadBlobToAsync(string digest, Stream destination, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));
            Argument.AssertNotNull(destination, nameof(destination));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlobTo)}");
            scope.Start();
            try
            {
                return await DownloadBlobToInternalAsync(digest, destination, true, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response> DownloadBlobToInternalAsync(string digest, Stream destination, bool async, CancellationToken cancellationToken)
        {
            byte[] buffer = ArrayPool<byte>.Shared.Rent(_maxChunkSize);
            long bytesDownloaded = 0;
            using SHA256 sha256 = SHA256.Create();
            long? blobSize = default;

            try
            {
                Response result = null;
                do
                {
                    int chunkSize = blobSize.HasValue ?
                        (int)Math.Min(blobSize.Value - bytesDownloaded, _maxChunkSize) :
                        _maxChunkSize;
                    HttpRange range = new HttpRange(bytesDownloaded, chunkSize);

                    var chunkResult = async ?
                        await _blobRestClient.GetChunkAsync(_repositoryName, digest, range.ToString(), cancellationToken).ConfigureAwait(false) :
                        _blobRestClient.GetChunk(_repositoryName, digest, range.ToString(), cancellationToken);

                    blobSize ??= GetBlobSizeFromContentRange(chunkResult.Headers.ContentRange);
                    chunkSize = (int)chunkResult.Value.Length;

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
                var computedDigest = BlobHelper.FormatDigest(sha256.Hash);

                ValidateDigest(computedDigest, digest);

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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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

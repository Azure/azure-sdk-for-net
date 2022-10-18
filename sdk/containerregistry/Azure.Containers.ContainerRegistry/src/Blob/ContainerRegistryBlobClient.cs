// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary> The Azure Container Registry blob client, responsible for uploading and downloading
    /// blobs and manifests, the building blocks of artifacts. </summary>
    [CodeGenClient("ContainerRegistryBlobClient")]
    public partial class ContainerRegistryBlobClient
    {
        private readonly Uri _endpoint;
        private readonly string _registryName;
        private readonly string _repository;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics ClientDiagnostics;

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
            this(endpoint, new ContainerRegistryAnonymousAccessCredential(), repository, new ContainerRegistryClientOptions())
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
            this(endpoint, new ContainerRegistryAnonymousAccessCredential(), repository, options)
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
        public ContainerRegistryBlobClient(Uri endpoint, TokenCredential credential, string repository) : this(endpoint, credential, repository, new ContainerRegistryClientOptions())
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
        public ContainerRegistryBlobClient(Uri endpoint, TokenCredential credential, string repository, ContainerRegistryClientOptions options) : this(endpoint, credential, repository, null, options)
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
            _repository = repository;
            ClientDiagnostics = new ClientDiagnostics(options, true);

            string defaultScope = options.Audience + "/.default";
            var authClient = authenticationClient ?? new AuthenticationClient(endpoint, options);
            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, defaultScope, authClient));
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
        public virtual string RepositoryName => _repository;

        /// <summary>
        /// Uploads a manifest for an OCI Artifact.
        /// </summary>
        /// <param name="manifest">The manifest to upload.</param>
        /// <param name="options">Options for configuring the upload operation.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<UploadManifestResult> UploadManifest(OciManifest manifest, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            options ??= new UploadManifestOptions();

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                RequestContent content = manifest.ToRequestContent();
                using MemoryStream manifestStream = new MemoryStream();
                content.WriteTo(manifestStream, cancellationToken);
                string manifestDigest = OciBlobDescriptor.ComputeDigest(manifestStream);
                string tagOrDigest = options.Tag ?? manifestDigest;
                RequestContext context = FromCancellationToken(cancellationToken);

                Response response = CreateManifest(tagOrDigest, content, ManifestMediaType.OciManifest.ToString(), context);
                var responseDigest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!manifestDigest.Equals(responseDigest, StringComparison.Ordinal))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The digest in the response does not match the digest of the uploaded manifest."));
                }

                return Response.FromValue(new UploadManifestResult(responseDigest), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads a manifest for an OCI Artifact.
        /// </summary>
        /// <param name="manifestStream">The <see cref="Stream"/> manifest to upload.</param>
        /// <param name="options">Options for configuring the upload operation.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<UploadManifestResult> UploadManifest(Stream manifestStream, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifestStream, nameof(manifestStream));

            options ??= new UploadManifestOptions();

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using Stream stream = new MemoryStream();
                manifestStream.CopyTo(stream);
                manifestStream.Position = 0;
                stream.Position = 0;
                RequestContent content = RequestContent.Create(stream);
                RequestContext context = FromCancellationToken(cancellationToken);

                string tagOrDigest = options.Tag ?? OciBlobDescriptor.ComputeDigest(manifestStream);
                Response response = CreateManifest(tagOrDigest, content, ManifestMediaType.OciManifest.ToString(), context);
                var responseDigest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!ValidateDigest(manifestStream, responseDigest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The digest in the response does not match the digest of the uploaded manifest."));
                }

                return Response.FromValue(new UploadManifestResult(responseDigest), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upload a manifest for an OCI Artifact.
        /// </summary>
        /// <param name="manifest">The manifest to upload.</param>
        /// <param name="options">Options for configuring the upload operation.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(OciManifest manifest, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifest, nameof(manifest));

            options ??= new UploadManifestOptions();

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                RequestContent content = manifest.ToRequestContent();
                using MemoryStream manifestStream = new MemoryStream();
                content.WriteTo(manifestStream, cancellationToken);
                string manifestDigest = OciBlobDescriptor.ComputeDigest(manifestStream);
                string tagOrDigest = options.Tag ?? manifestDigest;
                RequestContext context = FromCancellationToken(cancellationToken);

                Response response = await CreateManifestAsync(tagOrDigest, content, ManifestMediaType.OciManifest.ToString(), context).ConfigureAwait(false);
                var responseDigest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!manifestDigest.Equals(responseDigest, StringComparison.Ordinal))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The digest in the response does not match the digest of the uploaded manifest."));
                }

                return Response.FromValue(new UploadManifestResult(responseDigest), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Uploads a manifest for an OCI artifact.
        /// </summary>
        /// <param name="manifestStream">The <see cref="Stream"/> manifest to upload.</param>
        /// <param name="options">Options for configuring the upload operation.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadManifestResult>> UploadManifestAsync(Stream manifestStream, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(manifestStream, nameof(manifestStream));

            options ??= new UploadManifestOptions();

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                using Stream stream = new MemoryStream();
                manifestStream.CopyTo(stream);
                manifestStream.Position = 0;
                stream.Position = 0;
                RequestContent content = RequestContent.Create(stream);
                RequestContext context = FromCancellationToken(cancellationToken);

                string tagOrDigest = options.Tag ?? OciBlobDescriptor.ComputeDigest(manifestStream);
                Response response = await CreateManifestAsync(tagOrDigest, content, ManifestMediaType.OciManifest.ToString(), context).ConfigureAwait(false);
                var responseDigest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!ValidateDigest(manifestStream, responseDigest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The digest in the response does not match the digest of the uploaded manifest."));
                }

                return Response.FromValue(new UploadManifestResult(responseDigest), response);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<UploadBlobResult> UploadBlob(Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                string blobDigest = OciBlobDescriptor.ComputeDigest(stream);
                RequestContext context = FromCancellationToken(cancellationToken);

                Response startUploadResponse = StartUpload(context);

                string startLocation = startUploadResponse.Headers.TryGetValue(ContainerRegistryHeaders.Location, out string value) ? value : null;
                RequestContent content = RequestContent.Create(stream);
                Response uploadChunkResponse = UploadChunk(startLocation, content, context);

                string uploadLocation = uploadChunkResponse.Headers.TryGetValue(ContainerRegistryHeaders.Location, out string location) ? location : null;
                Response completeUploadResponse = CompleteUpload(uploadLocation, blobDigest, null, context);
                string responseDigest = completeUploadResponse.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string digest) ? digest : null;

                return Response.FromValue(new UploadBlobResult(responseDigest), completeUploadResponse);
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<UploadBlobResult>> UploadBlobAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                string blobDigest = OciBlobDescriptor.ComputeDigest(stream);
                RequestContext context = FromCancellationToken(cancellationToken);

                Response startUploadResponse = await StartUploadAsync(context).ConfigureAwait(false);

                string startLocation = startUploadResponse.Headers.TryGetValue(ContainerRegistryHeaders.Location, out string value) ? value : null;
                RequestContent content = RequestContent.Create(stream);
                Response uploadChunkResponse = await UploadChunkAsync(startLocation, content, context).ConfigureAwait(false);

                string uploadLocation = uploadChunkResponse.Headers.TryGetValue(ContainerRegistryHeaders.Location, out string location) ? location : null;
                Response completeUploadResponse = await CompleteUploadAsync(uploadLocation, blobDigest, null, context).ConfigureAwait(false);
                string responseDigest = completeUploadResponse.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string digest) ? digest : null;

                return Response.FromValue(new UploadBlobResult(responseDigest), uploadChunkResponse);
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
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual Response<DownloadManifestResult> DownloadManifest(DownloadManifestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadManifest)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = GetManifest(options.Tag ?? options.Digest, ManifestMediaType.OciManifest.ToString(), context);

                var digest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!ValidateDigest(response.ContentStream, digest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The requested digest does not match the digest of the received manifest."));
                }

                using var document = JsonDocument.Parse(response.ContentStream);
                var manifest = OciManifest.DeserializeOciManifest(document.RootElement);

                response.ContentStream.Position = 0;

                return Response.FromValue(new DownloadManifestResult(digest, manifest, response.ContentStream), response);
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
        /// <param name="options">Options for the download operation.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The download manifest result.</returns>
        public virtual async Task<Response<DownloadManifestResult>> DownloadManifestAsync(DownloadManifestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadManifest)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetManifestAsync(options.Tag ?? options.Digest, ManifestMediaType.OciManifest.ToString(), context).ConfigureAwait(false);

                var digest = response.Headers.TryGetValue(ContainerRegistryHeaders.DockerContentDigest, out string value) ? value : null;

                if (!ValidateDigest(response.ContentStream, digest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The requested digest does not match the digest of the received manifest."));
                }

                using var document = JsonDocument.Parse(response.ContentStream);
                var manifest = OciManifest.DeserializeOciManifest(document.RootElement);

                response.ContentStream.Position = 0;

                return Response.FromValue(new DownloadManifestResult(digest, manifest, response.ContentStream), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static bool ValidateDigest(Stream content, string digest)
        {
            // Validate that the file content did not change in transmission from the registry.

            // TODO: The registry may use a different digest algorithm - we may need to handle that
            string contentDigest = OciBlobDescriptor.ComputeDigest(content);
            content.Position = 0;
            return digest.Equals(contentDigest, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Download a blob that is part of an artifact.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual Response<DownloadBlobResult> DownloadBlob(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlob)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = GetBlob(digest, context);

                if (!ValidateDigest(response.ContentStream, digest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The requested digest does not match the digest of the received manifest."));
                }

                return Response.FromValue(new DownloadBlobResult(digest, response.ContentStream), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Download a blob that is part of an artifact.
        /// </summary>
        /// <param name="digest">The digest of the blob to download.</param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadBlobResult>> DownloadBlobAsync(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlob)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                Response response = await GetBlobAsync(digest, context).ConfigureAwait(false);

                if (!ValidateDigest(response.ContentStream, digest))
                {
                    throw ClientDiagnostics.CreateRequestFailedException(response,
                        new ResponseError(null, "The requested digest does not match the digest of the received manifest."));
                }

                return Response.FromValue(new DownloadBlobResult(digest, response.ContentStream), response);
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
        public virtual Response DeleteBlob(string digest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(digest, nameof(digest));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteBlob)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return DeleteBlob(digest, context);
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

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteBlob)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return await DeleteBlobAsync(digest, context).ConfigureAwait(false);
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

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteManifest)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return DeleteManifest(digest, context);
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

            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DeleteManifest)}");
            scope.Start();
            try
            {
                RequestContext context = FromCancellationToken(cancellationToken);
                return await DeleteManifestAsync(digest, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static RequestContext DefaultRequestContext = new RequestContext();

        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken)
        {
            if (cancellationToken == CancellationToken.None)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}

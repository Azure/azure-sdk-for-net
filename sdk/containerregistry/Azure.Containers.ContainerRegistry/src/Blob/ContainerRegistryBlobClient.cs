// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class ContainerRegistryBlobClient
    {
        private readonly Uri _endpoint;
        private readonly string _registryName;
        private readonly string _repositoryName;
        private readonly HttpPipeline _pipeline;
        private readonly HttpPipeline _acrAuthPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ContainerRegistryRestClient _restClient;
        private readonly AuthenticationRestClient _acrAuthClient;
        private readonly ContainerRegistryBlobRestClient _blobRestClient;

        // TODO: Design choice about taking repository name in the constructor, vs. methods?

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/> for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repository"></param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, TokenCredential credential, string repository) : this(endpoint, credential, repository, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ContainerRegistryClient for managing container images and artifacts.
        /// </summary>
        /// <param name="endpoint">The URI endpoint of the container registry.  This is likely to be similar
        /// to "https://{registry-name}.azurecr.io".</param>
        /// <param name="credential">The API key credential used to authenticate requests
        /// against the container registry.  </param>
        /// <param name="repository"></param>
        /// <param name="options">Client configuration options for connecting to Azure Container Registry.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ContainerRegistryBlobClient(Uri endpoint, TokenCredential credential, string repository, ContainerRegistryClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _endpoint = endpoint;
            _registryName = endpoint.Host.Split('.')[0];
            _repositoryName = repository;
            _clientDiagnostics = new ClientDiagnostics(options);

            _acrAuthPipeline = HttpPipelineBuilder.Build(options);
            _acrAuthClient = new AuthenticationRestClient(_clientDiagnostics, _acrAuthPipeline, endpoint.AbsoluteUri);

            string defaultScope = options.Audience + "/.default";
            _pipeline = HttpPipelineBuilder.Build(options, new ContainerRegistryChallengeAuthenticationPolicy(credential, defaultScope, _acrAuthClient));
            _restClient = new ContainerRegistryRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
            _blobRestClient = new ContainerRegistryBlobRestClient(_clientDiagnostics, _pipeline, _endpoint.AbsoluteUri);
        }

        /// <summary> Initializes a new instance of RepositoryClient for mocking. </summary>
        protected ContainerRegistryBlobClient()
        {
        }

        #region File Upload/Download

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<UploadManifestResult> UploadManifest(Stream stream, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async virtual Task<Response<UploadManifestResult>> UploadManifestAsync(Stream stream, UploadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new UploadManifestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadManifest)}");
            scope.Start();
            try
            {
                string tagOrDigest = options.Tag ?? ContentDescriptor.ComputeDigest(stream);
                ResponseWithHeaders<object, ContainerRegistryCreateManifestHeaders> response = await _restClient.CreateManifestAsync(_repositoryName, tagOrDigest, stream, options.MediaType.ToString(), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new UploadManifestResult(response.Headers.DockerContentDigest), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<UploadBlobResult> UploadBlob(Stream stream, UploadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<UploadBlobResult>> UploadBlobAsync(Stream stream, UploadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new UploadBlobOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(UploadBlob)}");
            scope.Start();
            try
            {
                string digest = ContentDescriptor.ComputeDigest(stream);

                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> startUploadResult =
                    await _blobRestClient.StartUploadAsync(_repositoryName, cancellationToken).ConfigureAwait(false);

                ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> uploadChunkResult =
                    await _blobRestClient.UploadChunkAsync(startUploadResult.Headers.Location, stream, cancellationToken).ConfigureAwait(false);

                ResponseWithHeaders<ContainerRegistryBlobCompleteUploadHeaders> completeUploadResult =
                    await _blobRestClient.CompleteUploadAsync(digest, uploadChunkResult.Headers.Location, null, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(new UploadBlobResult(completeUploadResult.Headers.DockerContentDigest), completeUploadResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DownloadManifestResult> DownloadManifest(string digest, DownloadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadManifestResult>> DownloadManifestAsync(string digest, DownloadManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new DownloadManifestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadManifest)}");
            scope.Start();
            try
            {
                Response<ManifestWrapper> response = await _restClient.GetManifestAsync(_repositoryName, digest, options.MediaType.ToString(), cancellationToken).ConfigureAwait(false);
                Response rawResponse = response.GetRawResponse();
                ManifestMediaType mediaType = rawResponse.Headers.ContentType;

                if (!rawResponse.Headers.TryGetValue("Docker-Content-Digest", out string registryDigest))
                {
                    _clientDiagnostics.CreateRequestFailedException(rawResponse, "Response did not contain \"Docker-Content-Digest\" header.");
                }

                if (!ValidateDigest(rawResponse.ContentStream, registryDigest))
                {
                    _clientDiagnostics.CreateRequestFailedException(rawResponse, "The manifest's digest according to the registry does not match the locally computed digest value.");
                }

                return Response.FromValue(new DownloadManifestResult(registryDigest, mediaType, rawResponse.ContentStream, GetArtifactFiles(options.MediaType, response.Value)), rawResponse);
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
            string contentDigest = ContentDescriptor.ComputeDigest(content);
            content.Position = 0;
            return digest.Equals(contentDigest, StringComparison.OrdinalIgnoreCase);
        }

        private IReadOnlyList<ArtifactBlobProperties> GetArtifactFiles(ManifestMediaType mediaType, ManifestWrapper manifest)
        {
            List<ArtifactBlobProperties> artifactFiles = new List<ArtifactBlobProperties>();

            // TODO: Implement for each of the manifest schemas
            if (mediaType == ManifestMediaType.OciManifest)
            {
                // If has config, add config
                if (manifest.Config != null)
                {
                    artifactFiles.Add(new ArtifactBlobProperties(_repositoryName, manifest.Config.Digest, "config.json"));
                }

                // Add layers
                foreach (var layer in manifest.Layers)
                {
                    artifactFiles.Add(new ArtifactBlobProperties(_repositoryName, layer.Digest));
                }
            }

            return artifactFiles;
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DownloadBlobResult> DownloadBlob(string digest, DownloadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DownloadBlobResult>> DownloadBlobAsync(string digest, DownloadBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new DownloadBlobOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ContainerRegistryBlobClient)}.{nameof(DownloadBlob)}");
            scope.Start();
            try
            {
                ResponseWithHeaders<Stream, ContainerRegistryBlobGetBlobHeaders> blobResult = await _blobRestClient.GetBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);

                if (!ValidateDigest(blobResult.Value, blobResult.Headers.DockerContentDigest))
                {
                    _clientDiagnostics.CreateRequestFailedException(blobResult.GetRawResponse(), "The manifest's digest according to the registry does not match the locally computed digest value.");
                }

                return Response.FromValue(new DownloadBlobResult(digest, blobResult.Value), blobResult.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response DeleteBlob(string digest, DeleteBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteBlobAsync(string digest, DeleteBlobOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new DeleteBlobOptions();

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
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response DeleteManifest(string digest, DeleteManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> DeleteManifestAsync(string digest, DeleteManifestOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new DeleteManifestOptions();

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

        #endregion
    }
}

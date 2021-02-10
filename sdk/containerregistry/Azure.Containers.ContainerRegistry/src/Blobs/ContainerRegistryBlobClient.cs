// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry.Blobs
{
    /// <summary> The ContainerRegistryBlob service client. </summary>
    public partial class ContainerRegistryBlobClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        internal ContainerRegistryBlobRestClient RestClient { get; }

        // Name of the image (including the namespace).
        private string _repositoryName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName, TokenCredential credential) : this(endpoint, repositoryName, credential, new ContainerRegistryClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRegistryClient"/>.
        /// </summary>
        public ContainerRegistryBlobClient(Uri endpoint, string repositoryName, TokenCredential credential, ContainerRegistryClientOptions options)
        {
            _repositoryName = repositoryName;
        }

        /// <summary> Initializes a new instance of ContainerRegistryBlobClient for mocking. </summary>
        protected ContainerRegistryBlobClient()
        {
        }
        /// <summary> Initializes a new instance of ContainerRegistryBlobClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        internal ContainerRegistryBlobClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            RestClient = new ContainerRegistryBlobRestClient(clientDiagnostics, pipeline, url);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Retrieve the blob from the registry identified by digest. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> GetBlobAsync(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetBlob");
            scope.Start();
            try
            {
                return await RestClient.GetBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve the blob from the registry identified by digest. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> GetBlob(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetBlob");
            scope.Start();
            try
            {
                return RestClient.GetBlob(_repositoryName, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Same as GET, except only the headers are returned. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CheckBlobExistsAsync(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CheckBlobExists");
            scope.Start();
            try
            {
                return (await RestClient.CheckBlobExistsAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Same as GET, except only the headers are returned. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CheckBlobExists(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CheckBlobExists");
            scope.Start();
            try
            {
                return RestClient.CheckBlobExists(_repositoryName, digest, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes an already uploaded blob. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> DeleteBlobAsync(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.DeleteBlob");
            scope.Start();
            try
            {
                return await RestClient.DeleteBlobAsync(_repositoryName, digest, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Removes an already uploaded blob. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> DeleteBlob(string digest, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.DeleteBlob");
            scope.Start();
            try
            {
                return RestClient.DeleteBlob(_repositoryName, digest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Mount a blob identified by the `mount` parameter from another repository. </summary>
        /// <param name="from"> Name of the source repository. </param>
        /// <param name="mount"> Digest of blob to mount from the source repository. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> MountBlobAsync(string @from, string mount, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.MountBlob");
            scope.Start();
            try
            {
                return (await RestClient.MountBlobAsync(_repositoryName, @from, mount, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Mount a blob identified by the `mount` parameter from another repository. </summary>
        /// <param name="from"> Name of the source repository. </param>
        /// <param name="mount"> Digest of blob to mount from the source repository. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response MountBlob(string @from, string mount, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.MountBlob");
            scope.Start();
            try
            {
                return RestClient.MountBlob(_repositoryName, @from, mount, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve status of upload identified by uuid. The primary purpose of this endpoint is to resolve the current status of a resumable upload. </summary>
        /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetUploadStatusAsync(string location, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetUploadStatus");
            scope.Start();
            try
            {
                return (await RestClient.GetUploadStatusAsync(location, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve status of upload identified by uuid. The primary purpose of this endpoint is to resolve the current status of a resumable upload. </summary>
        /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetUploadStatus(string location, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetUploadStatus");
            scope.Start();
            try
            {
                return RestClient.GetUploadStatus(location, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        //// See sample UploadBlobInOneRequest_Monolithic
        // NOTE: Not in swagger.
        //public virtual Response Upload(string digest, Stream value, CancellationToken cancellationToken = default)
        //{
        //    using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.Upload");
        //    scope.Start();
        //    try
        //    {
        //        return RestClient.(uploadInfo.BlobLocation.ToString(), value, cancellationToken).GetRawResponse();
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        /// <summary> Upload a stream of data without completing the upload. </summary>
        /// <param name="value"> Raw data of blob. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobUploadDetails>> UploadChunkAsync(BlobUploadDetails uploadInfo, Stream value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.UploadChunk");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobUploadChunkHeaders> response = await RestClient.UploadChunkAsync(uploadInfo.BlobLocation.ToString(), value, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BlobUploadDetails(response.Headers.Location.ToString()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Upload a stream of data without completing the upload. </summary>
        /// <param name="value"> Raw data of blob. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UploadChunk(BlobUploadDetails uploadInfo, Stream value, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.UploadChunk");
            scope.Start();
            try
            {
                return RestClient.UploadChunk(uploadInfo.BlobLocation.ToString(), value, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Complete the upload, providing all the data in the body, if necessary. A request without a body will just complete the upload with previously uploaded content. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>        
        /// <param name="value"> Raw data of final blob. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CompleteUploadAsync(BlobUploadDetails uploadInfo, string digest, Stream value, CancellationToken cancellationToken = default)
        {
            // /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>

            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CompleteUpload");
            scope.Start();
            try
            {
                return (await RestClient.CompleteUploadAsync(digest, uploadInfo.BlobLocation.ToString(), value, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Complete the upload, providing all the data in the body, if necessary. A request without a body will just complete the upload with previously uploaded content. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="value"> Raw data of final blob. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CompleteUpload(BlobUploadDetails uploadInfo, string digest, Stream value, CancellationToken cancellationToken = default)
        {
            // /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>

            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CompleteUpload");
            scope.Start();
            try
            {
                // TODO: in this method call, we're validating that value is not null, but it is actually an optional 
                // parameter and should not be validated as null is a correct value.  How can we reflect this in the swagger?

                return RestClient.CompleteUpload(digest, uploadInfo.BlobLocation.ToString(), value, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Cancel outstanding upload processes, releasing associated resources. If this is not called, the unfinished uploads will eventually timeout. </summary>
        /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CancelUploadAsync(string location, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CancelUpload");
            scope.Start();
            try
            {
                return await RestClient.CancelUploadAsync(location, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Cancel outstanding upload processes, releasing associated resources. If this is not called, the unfinished uploads will eventually timeout. </summary>
        /// <param name="location"> Link acquired from upload start or previous chunk. Note, do not include initial / (must do substring(1) ). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CancelUpload(string location, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CancelUpload");
            scope.Start();
            try
            {
                return RestClient.CancelUpload(location, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: Naming here - usually Create takes an instance of the resource to create - we're asking the service to create 
        // one for us from scratch - like getting a ticket we'll use elsewhere.  Do we have a pattern for this elsewhere?
        /// <summary> Initiate a resumable blob upload with an empty request body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BlobUploadDetails>> InitiateResumableUploadAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.StartUpload");
            scope.Start();
            try
            {
                // Note: content length header has got to be 0 in order to start the upload
                // See: Initiate Resumable Blob Upload
                // in: https://docs.docker.com/registry/spec/api/#initiate-blob-upload
                // TODO: doesn't look like we're doing this - does the service support not setting the header if the body has no content?
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> response = await RestClient.StartUploadAsync(_repositoryName, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new BlobUploadDetails(response.Headers.Location), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Initiate a resumable blob upload with an empty request body. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BlobUploadDetails> InitiateResumableUpload(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.StartUpload");
            scope.Start();
            try
            {
                ResponseWithHeaders<ContainerRegistryBlobStartUploadHeaders> response = RestClient.StartUpload(_repositoryName, cancellationToken);
                return Response.FromValue(new BlobUploadDetails(response.Headers.Location), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve the blob from the registry identified by `digest`. This endpoint may also support RFC7233 compliant range requests. Support can be detected by issuing a HEAD request. If the header `Accept-Range: bytes` is returned, range requests can be used to fetch partial content. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="range"> Format : bytes=&lt;start&gt;-&lt;end&gt;,  HTTP Range header specifying blob chunk. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Stream>> GetChunkAsync(string digest, string range, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetChunk");
            scope.Start();
            try
            {
                return await RestClient.GetChunkAsync(_repositoryName, digest, range, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve the blob from the registry identified by `digest`. This endpoint may also support RFC7233 compliant range requests. Support can be detected by issuing a HEAD request. If the header `Accept-Range: bytes` is returned, range requests can be used to fetch partial content. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="range"> Format : bytes=&lt;start&gt;-&lt;end&gt;,  HTTP Range header specifying blob chunk. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Stream> GetChunk(string digest, string range, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.GetChunk");
            scope.Start();
            try
            {
                return RestClient.GetChunk(_repositoryName, digest, range, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Same as GET, except only the headers are returned. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="range"> Format : bytes=&lt;start&gt;-&lt;end&gt;,  HTTP Range header specifying blob chunk. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CheckChunkExistsAsync(string digest, string range, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CheckChunkExists");
            scope.Start();
            try
            {
                return (await RestClient.CheckChunkExistsAsync(_repositoryName, digest, range, cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Same as GET, except only the headers are returned. </summary>
        /// <param name="digest"> Digest of a BLOB. </param>
        /// <param name="range"> Format : bytes=&lt;start&gt;-&lt;end&gt;,  HTTP Range header specifying blob chunk. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CheckChunkExists(string digest, string range, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ContainerRegistryBlobClient.CheckChunkExists");
            scope.Start();
            try
            {
                return RestClient.CheckChunkExists(_repositoryName, digest, range, cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}

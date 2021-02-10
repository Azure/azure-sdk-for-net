// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Containers.ContainerRegistry;
using Azure.Containers.ContainerRegistry.Blobs;
using Azure.Containers.ContainerRegistry.Models;
using Azure.Identity;

namespace ContainerRegistrySamples
{
    public class Samples_ManageBlobs
    {
        public async Task UploadBlobInOneRequest_Monolithic()
        {
            // Monolithic upload
            ContainerRegistryClient registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            // TODO: is this the right model for Blob Client?  To have it in a separate namespace?
            ContainerRegistryBlobClient blobClient = registryClient.GetBlobClient("hello-world");


            //POST INITIATE BLOB UPLOAD
            // Initiate a resumable blob upload. If successful, an upload location will be provided to complete the upload.
            // Optionally, if the digest parameter is present, the request body will be used to **complete the upload in a single request**.
            // See: https://docs.docker.com/registry/spec/api/#initiate-blob-upload

            // TODO: Note this is not defined in the swagger, where the /v2/{name}/blobs/uploads/ takes a digest parameter.
            // TODO: We will need to add this to the swagger - the service supports it.
        }

        public async Task UploadBlob_ResumableUploadOnlyOneChunk()
        {
            // Track 1:
            //_logger.LogInformation($"Uploading Blob {reference} to {digest}");
            //var repository = reference.Repository;
            //var uploadInfo = await _runtimeClient.Blob.StartUploadAsync(repository);
            //var uploadedLayer = await _runtimeClient.Blob.UploadAsync(blobStream, uploadInfo.Location);
            //var uploadedLayerEnd = await _runtimeClient.Blob.EndUploadAsync(digest, uploadedLayer.Location);
            //return uploadedLayerEnd.DockerContentDigest == digest;

            ContainerRegistryClient registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            // TODO: is this the right model for Blob Client?  To have it in a separate namespace?
            ContainerRegistryBlobClient blobClient = registryClient.GetBlobClient("hello-world");

            // TODO: Will calling this "Start" name cause confusion with our LRO patterns?
            // TODO: Naming here - what about Create?  usually Create takes an instance of the resource to create - we're asking the service to create 
            // one for us from scratch - like getting a ticket we'll use elsewhere.  Do we have a pattern for this elsewhere?
            // Other ideas: CreateUploadTicket() - problem with this is we're creating this Ticket concept where there was none in the ACR or Docker lit before...
			// What about this:
            BlobUploadDetails uploadDetails = await blobClient.InitiateResumableUploadAsync();
            // TODO: "digest"
            // TODO: "stream"
            await blobClient.CompleteUploadAsync(uploadDetails, "digest", new MemoryStream());
        }

        public async Task UploadBlob_ResumableUploadInSeveralChunks()
        {
            ContainerRegistryClient registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            ContainerRegistryBlobClient blobClient = registryClient.GetBlobClient("hello-world");

            BlobUploadDetails uploadDetails = await blobClient.InitiateResumableUploadAsync();
            bool haveChunks = true;  // TODO: how do I know?  Who decides how to break things into chunks and why?
            while (haveChunks)
            {
                uploadDetails = await blobClient.UploadChunkAsync(uploadDetails, new MemoryStream());
            }

            // TODO: how to handle this multiplicity around sometimes you pass a blob here and sometimes you don't
            // and what should the return value be for each of these cases?  Do you need the location if you're done?
            // One idea: could we not use a default parameter and instead have overloads that returned two different things?
            // What would the different things be?
            // Do you need the progress 
            // TODO: What should we be doing with the returned digest?  Should we verify on behalf of the customer or no?

            //await blobClient.CompleteUpload(uploadInfo, "digest");

        }

        public async Task MountBlob()
        {

        }

        public async Task GetUploadStatus()
        {

        }

        public async Task CancelUpload()
        {

        }

        public async Task CheckBlobExists()
        {

        }

        public async Task CheckBlobChunkExists()
        {

        }

        public async Task DeleteBlob()
        {

        }

        public async Task DownloadBlob()
        {
            // Track 1:
            // return await _runtimeClient.Blob.GetAsync(repo, digest);
        }

        public async Task DownloadBlobInChunks()
        {

        }
    }
}

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
            // Is it worth supporting?
        }


        public async Task UploadBlob()
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

            BlobUploadInfo uploadInfo = await blobClient.StartUploadAsync();
            // TODO: "digest"
            // TODO: "stream"
            await blobClient.CompleteUploadAsync(uploadInfo, "digest", new MemoryStream());
        }

        public async Task UploadBlobInChunks()
        {
            ContainerRegistryClient registryClient = new ContainerRegistryClient(new Uri("myacr.azurecr.io"), new DefaultAzureCredential());

            ContainerRegistryBlobClient blobClient = registryClient.GetBlobClient("hello-world");

            BlobUploadInfo uploadInfo = await blobClient.StartUploadAsync();
            bool haveChunks = true;  // TODO: how do I know?  Who decides how to break things into chunks and why?
            while (haveChunks)
            {
                uploadInfo = await blobClient.UploadChunkAsync(uploadInfo, new MemoryStream());
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

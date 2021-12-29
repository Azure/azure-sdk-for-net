using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Tests;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public static class DirectoryClientBuilderExtensions
    {
        /// <summary>
        /// Creates a new <see cref="ClientBuilder{TServiceClient, TServiceClientOptions}"/>
        /// setup to generate <see cref="BlobServiceClient"/>s.
        /// </summary>
        /// <param name="tenants"><see cref="TenantConfigurationBuilder"/> powering this client builder.</param>
        /// <param name="serviceVersion">Service version for clients to target.</param>
        public static BlobsClientBuilder GetNewBlobsClientBuilder(TenantConfigurationBuilder tenants, BlobClientOptions.ServiceVersion serviceVersion)
            => new BlobsClientBuilder(
                ServiceEndpoint.Blob,
                tenants,
                (uri, clientOptions) => new BlobServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new BlobServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new BlobServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new BlobServiceClient(uri, azureSasCredential, clientOptions),
                () => new BlobClientOptions(serviceVersion));

        public static string GetNewBlobName(this BlobsClientBuilder clientBuilder)
            => $"test-blob-directory-{clientBuilder.Recording.Random.NewGuid()}";
    }
}

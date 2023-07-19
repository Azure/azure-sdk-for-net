// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// This tests various client ctors and hierarchy traversal.
    /// </summary>
    public class CreateClients : PerfTest<PerfOptions>
    {
        private const string AccountName = "foo";
        private const string ContainerName = "bar";
        private const string BlobName = "fizz";
        private static readonly Uri s_serviceUri = new Uri($"https://{AccountName}.blob.core.windows.net");
        private static readonly Uri s_containerUri = new Uri(s_serviceUri.ToString() + $"/{ContainerName}");
        private static readonly Uri s_blobUri = new Uri(s_containerUri.ToString() + $"/{BlobName}");
        private static readonly string s_connectionString = $"DefaultEndpointsProtocol=https;AccountName=foo;AccountKey={Convert.ToBase64String(Guid.NewGuid().ToByteArray())};EndpointSuffix=core.windows.net";
        private static readonly AzureSasCredential s_azureSasCredential = new AzureSasCredential("foo");
        private static readonly TokenCredential s_tokenCredential = new ClientSecretCredential("foo", "bar", "baz");
        private static readonly StorageSharedKeyCredential s_sharedKeyCredential = new StorageSharedKeyCredential("fizz", "buzz");

        public CreateClients(PerfOptions options) : base(options)
        {
        }

#pragma warning disable CA1806 // Do not ignore method results
        public override void Run(CancellationToken cancellationToken)
        {
            // BlobServiceClient ctors
            var blobServiceClient = new BlobServiceClient(s_connectionString);
            new BlobServiceClient(s_serviceUri);
            new BlobServiceClient(s_serviceUri, s_azureSasCredential);
            new BlobServiceClient(s_serviceUri, s_tokenCredential);
            new BlobServiceClient(s_serviceUri, s_sharedKeyCredential);

            // BlobContainerClient ctors
            var blobContainerClient = new BlobContainerClient(s_connectionString, ContainerName);
            new BlobContainerClient(s_containerUri);
            new BlobContainerClient(s_containerUri, s_azureSasCredential);
            new BlobContainerClient(s_containerUri, s_tokenCredential);
            new BlobContainerClient(s_containerUri, s_sharedKeyCredential);

            // BlobClient ctors
            var blobClient = new BlobClient(s_connectionString, ContainerName, BlobName);
            new BlobClient(s_blobUri);
            new BlobClient(s_blobUri, s_azureSasCredential);
            new BlobClient(s_blobUri, s_tokenCredential);
            new BlobClient(s_blobUri, s_sharedKeyCredential);

            // BlobBaseClient ctors
            new BlobBaseClient(s_connectionString, ContainerName, BlobName);
            new BlobBaseClient(s_blobUri);
            new BlobBaseClient(s_blobUri, s_azureSasCredential);
            new BlobBaseClient(s_blobUri, s_tokenCredential);
            new BlobBaseClient(s_blobUri, s_sharedKeyCredential);

            // AppendBlobClient ctors
            new AppendBlobClient(s_connectionString, ContainerName, BlobName);
            new AppendBlobClient(s_blobUri);
            new AppendBlobClient(s_blobUri, s_azureSasCredential);
            new AppendBlobClient(s_blobUri, s_tokenCredential);
            new AppendBlobClient(s_blobUri, s_sharedKeyCredential);

            // BlockBlobClient ctors
            new BlockBlobClient(s_connectionString, ContainerName, BlobName);
            new BlockBlobClient(s_blobUri);
            new BlockBlobClient(s_blobUri, s_azureSasCredential);
            new BlockBlobClient(s_blobUri, s_tokenCredential);
            new BlockBlobClient(s_blobUri, s_sharedKeyCredential);

            // PageBlobClient ctors
            new PageBlobClient(s_connectionString, ContainerName, BlobName);
            new PageBlobClient(s_blobUri);
            new PageBlobClient(s_blobUri, s_azureSasCredential);
            new PageBlobClient(s_blobUri, s_tokenCredential);
            new PageBlobClient(s_blobUri, s_sharedKeyCredential);

            // traverse hierarchy down
            blobServiceClient.GetBlobContainerClient(ContainerName);
            blobContainerClient.GetBlobClient(BlobName);
            blobContainerClient.GetBlobBaseClient(BlobName);
            blobContainerClient.GetBlockBlobClient(BlobName);
            blobContainerClient.GetPageBlobClient(BlobName);
            blobContainerClient.GetAppendBlobClient(BlobName);

            // traverse hierarchy up
            blobClient.GetParentBlobContainerClient();
            blobContainerClient.GetParentBlobServiceClient();
        }
#pragma warning restore CA1806 // Do not ignore method results

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            Run(cancellationToken);
            return Task.CompletedTask;
        }
    }
}

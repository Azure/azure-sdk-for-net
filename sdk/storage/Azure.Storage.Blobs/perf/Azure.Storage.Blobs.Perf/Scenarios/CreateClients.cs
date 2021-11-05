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
    public class CreateClients : BlobTest<SizeOptions>
    {
        private static readonly string s_connectionString = $"DefaultEndpointsProtocol=https;AccountName=foo;AccountKey={Convert.ToBase64String(Guid.NewGuid().ToByteArray())};EndpointSuffix=core.windows.net";
        private static readonly AzureSasCredential s_azureSasCredential = new AzureSasCredential("foo");
        private static readonly TokenCredential s_tokenCredential = new ClientSecretCredential("foo", "bar", "baz");

        public CreateClients(SizeOptions options) : base(options)
        {
        }

#pragma warning disable CA1806 // Do not ignore method results
        public override void Run(CancellationToken cancellationToken)
        {
            // traverse hierarchy down
            BlobServiceClient.GetBlobContainerClient(ContainerName);
            BlobContainerClient.GetBlobClient(BlobName);
            BlobContainerClient.GetBlobBaseClient(BlobName);
            BlobContainerClient.GetBlockBlobClient(BlobName);
            BlobContainerClient.GetPageBlobClient(BlobName);
            BlobContainerClient.GetAppendBlobClient(BlobName);

            // traverse hierarchy up
            BlobClient.GetParentBlobContainerClient();
            BlobContainerClient.GetParentBlobServiceClient();

            // BlobServiceClient ctors
            new BlobServiceClient(s_connectionString);
            new BlobServiceClient(BlobServiceClient.Uri);
            new BlobServiceClient(BlobServiceClient.Uri, s_azureSasCredential);
            new BlobServiceClient(BlobServiceClient.Uri, s_tokenCredential);
            new BlobServiceClient(BlobServiceClient.Uri, StorageSharedKeyCredential);

            // BlobContainerClient ctors
            new BlobContainerClient(s_connectionString, ContainerName);
            new BlobContainerClient(BlobContainerClient.Uri);
            new BlobContainerClient(BlobContainerClient.Uri, s_azureSasCredential);
            new BlobContainerClient(BlobContainerClient.Uri, s_tokenCredential);
            new BlobContainerClient(BlobContainerClient.Uri, StorageSharedKeyCredential);

            // BlobClient ctors
            new BlobClient(s_connectionString, ContainerName, BlobName);
            new BlobClient(BlobContainerClient.Uri);
            new BlobClient(BlobContainerClient.Uri, s_azureSasCredential);
            new BlobClient(BlobContainerClient.Uri, s_tokenCredential);
            new BlobClient(BlobContainerClient.Uri, StorageSharedKeyCredential);

            // BlobBaseClient ctors
            new BlobBaseClient(s_connectionString, ContainerName, BlobName);
            new BlobBaseClient(BlobContainerClient.Uri);
            new BlobBaseClient(BlobContainerClient.Uri, s_azureSasCredential);
            new BlobBaseClient(BlobContainerClient.Uri, s_tokenCredential);
            new BlobBaseClient(BlobContainerClient.Uri, StorageSharedKeyCredential);

            // AppendBlobClient ctors
            new AppendBlobClient(s_connectionString, ContainerName, BlobName);
            new AppendBlobClient(BlobContainerClient.Uri);
            new AppendBlobClient(BlobContainerClient.Uri, s_azureSasCredential);
            new AppendBlobClient(BlobContainerClient.Uri, s_tokenCredential);
            new AppendBlobClient(BlobContainerClient.Uri, StorageSharedKeyCredential);

            // BlockBlobClient ctors
            new BlockBlobClient(s_connectionString, ContainerName, BlobName);
            new BlockBlobClient(BlobContainerClient.Uri);
            new BlockBlobClient(BlobContainerClient.Uri, s_azureSasCredential);
            new BlockBlobClient(BlobContainerClient.Uri, s_tokenCredential);
            new BlockBlobClient(BlobContainerClient.Uri, StorageSharedKeyCredential);

            // PageBlobClient ctors
            new PageBlobClient(s_connectionString, ContainerName, BlobName);
            new PageBlobClient(BlobContainerClient.Uri);
            new PageBlobClient(BlobContainerClient.Uri, s_azureSasCredential);
            new PageBlobClient(BlobContainerClient.Uri, s_tokenCredential);
            new PageBlobClient(BlobContainerClient.Uri, StorageSharedKeyCredential);
        }
#pragma warning restore CA1806 // Do not ignore method results

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            Run(cancellationToken);
            return Task.CompletedTask;
        }
    }
}

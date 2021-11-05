// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Triggers
{
    internal class StringToCloudBlobConverter : IAsyncConverter<string, BlobBaseClient>
    {
        private readonly BlobServiceClient _client;

        public StringToCloudBlobConverter(BlobServiceClient client)
        {
            _client = client;
        }

        public async Task<BlobBaseClient> ConvertAsync(string input, CancellationToken cancellationToken)
        {
            BlobPath path = BlobPath.ParseAndValidate(input);
            var container = _client.GetBlobContainerClient(path.ContainerName);
            return (await container.GetBlobReferenceFromServerAsync(path.BlobName, cancellationToken).ConfigureAwait(false)).Client;
        }
    }
}

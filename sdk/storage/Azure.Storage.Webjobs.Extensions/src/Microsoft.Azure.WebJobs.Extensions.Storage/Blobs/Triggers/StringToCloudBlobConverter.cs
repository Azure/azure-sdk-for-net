// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Triggers
{
    internal class StringToCloudBlobConverter : IAsyncConverter<string, ICloudBlob>
    {
        private readonly CloudBlobClient _client;

        public StringToCloudBlobConverter(CloudBlobClient client)
        {
            _client = client;
        }

        public Task<ICloudBlob> ConvertAsync(string input, CancellationToken cancellationToken)
        {
            BlobPath path = BlobPath.ParseAndValidate(input);
            var container = _client.GetContainerReference(path.ContainerName);
            return container.GetBlobReferenceFromServerAsync(path.BlobName, cancellationToken);
        }
    }
}

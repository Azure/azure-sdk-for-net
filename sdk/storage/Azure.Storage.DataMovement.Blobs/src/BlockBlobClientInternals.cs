// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlockBlobClientInternals : BlockBlobClient
    {
        public static BlockBlobClient WithAdditionalPoliciesClient(
            BlockBlobClient client,
            params HttpPipelineSynchronousPolicy[] policies)
            => BlockBlobClient.WithAdditionalPolicies(client, policies);
    }
}

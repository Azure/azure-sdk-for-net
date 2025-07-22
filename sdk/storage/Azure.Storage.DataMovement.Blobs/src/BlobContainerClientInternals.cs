// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobContainerClientInternals : BlobContainerClient
    {
        public static BlobContainerClient WithAdditionalPoliciesClient(
            BlobContainerClient client,
            params HttpPipelinePolicy[] policies)
            => BlobContainerClient.WithAdditionalPolicies(client, policies);
    }
}

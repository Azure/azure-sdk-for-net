// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryClientInternals : ShareDirectoryClient
    {
        public static ShareDirectoryClient WithAdditionalPoliciesClient(
            ShareDirectoryClient client,
            params HttpPipelinePolicy[] policies)
            => ShareDirectoryClient.WithAdditionalPolicies(client, policies);
    }
}

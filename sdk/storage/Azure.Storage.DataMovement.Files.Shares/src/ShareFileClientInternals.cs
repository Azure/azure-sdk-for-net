// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileClientInternals : ShareFileClient
    {
        public static Task<HttpAuthorization> GetCopyAuthorizationTokenAsync(
            ShareFileClient client,
            CancellationToken cancellationToken)
            => ShareFileClient.GetCopyAuthorizationHeaderAsync(client, cancellationToken);

        public static ShareFileClient WithAdditionalPoliciesClient(
            ShareFileClient client,
            params HttpPipelinePolicy[] policies)
            => ShareFileClient.WithAdditionalPolicies(client, policies);
    }
}

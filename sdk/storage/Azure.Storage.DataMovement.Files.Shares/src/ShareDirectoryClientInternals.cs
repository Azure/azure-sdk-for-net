// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareDirectoryClientInternals : ShareDirectoryClient
    {
        public static ShareDirectoryClient WithAppendedUserAgentClient(
            ShareDirectoryClient client,
            string appendedUserAgent)
            => ShareDirectoryClient.WithAppendedUserAgent(client, appendedUserAgent);
    }
}

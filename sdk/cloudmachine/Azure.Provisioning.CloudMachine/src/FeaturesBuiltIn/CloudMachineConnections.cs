// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.CloudMachine.Core
{
    internal static class CloudMachineConnections
    {
        public static readonly string DefaultBlobContainerName = "default";

        public static ClientConnection CreateDefaultBlobContainerConnection(string cmId)
        {
            ClientConnection connection = new(
                $"Azure.Storage.Blobs.BlobContainerClient@{DefaultBlobContainerName}",
                $"https://{cmId}.blob.core.windows.net/{DefaultBlobContainerName}"
            );
            return connection;
        }
    }
}

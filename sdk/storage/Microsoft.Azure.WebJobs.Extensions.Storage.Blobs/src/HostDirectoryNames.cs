// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    // Names of directories used only by hosts (not directly part of the protocol with the dashboard, though other parts
    // may point to blobs stored here).
    internal static class HostDirectoryNames
    {
        public const string BlobReceipts = "blobreceipts";
    }
}

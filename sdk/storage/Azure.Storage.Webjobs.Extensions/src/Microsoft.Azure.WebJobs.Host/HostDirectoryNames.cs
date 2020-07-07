// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Microsoft.Azure.WebJobs.Host
{
    // Names of directories used only by hosts (not directly part of the protocol with the dashboard, though other parts
    // may point to blobs stored here).
    internal static class HostDirectoryNames
    {
        public const string BlobReceipts = "blobreceipts";

        public const string Heartbeats = "heartbeats";

        public const string Ids = "ids";

        public const string OutputLogs = "output-logs";

        public const string SingletonLocks = "locks";
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal sealed partial class PollLogsStrategy
    {
        private class Logger
        {
            // Keep these events in 300-399 range.

            private static readonly Action<ILogger<BlobListener>, string, string, int, Exception> _scanBlobLogs =
               LoggerMessage.Define<string, string, int>(LogLevel.Debug, new EventId(300, nameof(ScanBlobLogs)),
                   "Log scan for recent blob updates in container '{containerName}' with PollId '{pollId}' found {blobCount} blobs.");

            public static void ScanBlobLogs(ILogger<BlobListener> logger, string containerName, string pollId, int blobCount) =>
                _scanBlobLogs(logger, containerName, pollId, blobCount, null);
        }
    }
}

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

            private static readonly Action<ILogger<BlobListener>, string, Exception> _loggingNotEnabledOnTargetAccount =
               LoggerMessage.Define<string>(LogLevel.Warning, new EventId(400, nameof(LoggingNotEnabledOnTargetAccount)),
                   "Storage Analytics Logs are not enabled on the target blob storage account: '{targetAccountName}'. See aka.ms/AAywxhb");

            public static void ScanBlobLogs(ILogger<BlobListener> logger, string containerName, string pollId, int blobCount) =>
                _scanBlobLogs(logger, containerName, pollId, blobCount, null);

            public static void LoggingNotEnabledOnTargetAccount(ILogger<BlobListener> logger, string targetAccountName) =>
                _loggingNotEnabledOnTargetAccount(logger, targetAccountName, null);
        }
    }
}

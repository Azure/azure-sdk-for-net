// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal sealed partial class ScanBlobScanLogHybridPollingStrategy
    {
        private static class Logger
        {
            // Keep these events in 1-99 range.

            private static readonly Action<ILogger<BlobListener>, string, string, Exception> _initializedScanInfo =
               LoggerMessage.Define<string, string>(LogLevel.Debug, new EventId(1, nameof(InitializedScanInfo)),
                   "Initialized scan info for container '{containerName}'. Scan will start with blobs inserted or updated after '{latestScanInfo}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, int, long, bool, Exception> _pollBlobContainer =
                LoggerMessage.Define<string, string, string, int, long, bool>(LogLevel.Debug, new EventId(2, nameof(PollBlobContainer)),
                    "Poll for blobs newer than '{pollMinimumTime}' in container '{containerName}' with ClientRequestId '{clientRequestId}' found {blobCount} blobs in {pollLatency} ms. ContinuationToken: {hasContinuationToken}.");

            private static readonly Action<ILogger<BlobListener>, string, Exception> _containerDoesNotExist =
                LoggerMessage.Define<string>(LogLevel.Debug, new EventId(3, nameof(ContainerDoesNotExist)),
                    "Container '{containerName}' does not exist.");

            public static void InitializedScanInfo(ILogger<BlobListener> logger, string container, DateTime latestScanInfo) =>
                _initializedScanInfo(logger, container, latestScanInfo.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture), null);

            public static void PollBlobContainer(ILogger<BlobListener> logger, string container, DateTime latestScanInfo, string clientRequestId, int blobCount, long latencyInMilliseconds, bool hasContinuationToken) =>
                _pollBlobContainer(logger, latestScanInfo.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture), container, clientRequestId, blobCount, latencyInMilliseconds, hasContinuationToken, null);

            public static void ContainerDoesNotExist(ILogger<BlobListener> logger, string container) =>
                _containerDoesNotExist(logger, container, null);
        }
    }
}

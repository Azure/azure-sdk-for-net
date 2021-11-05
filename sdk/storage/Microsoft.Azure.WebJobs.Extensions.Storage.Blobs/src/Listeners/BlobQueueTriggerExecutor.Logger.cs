// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal partial class BlobQueueTriggerExecutor
    {
        private static class Logger
        {
            // Keep these events in 200-299 range.

            private static readonly Action<ILogger<BlobListener>, string, string, string, Exception> _functionNotFound =
              LoggerMessage.Define<string, string, string>(LogLevel.Debug, new EventId(200, nameof(FunctionNotFound)),
                  "Blob '{blobName}' will not be processed because function '{functionName}' cannot be found. Message Id: '{queueMessageId}'");

            private static readonly Action<ILogger<BlobListener>, string, string, Exception> _blobNotFound =
              LoggerMessage.Define<string, string>(LogLevel.Debug, new EventId(201, nameof(BlobNotFound)),
                  "Blob '{blobName}' will not be processed becuase the blob cannot be found. Message Id: '{queueMessageId}'");

            public static void FunctionNotFound(ILogger<BlobListener> logger, string blobName, string functionName, string queueMessageId) =>
                _functionNotFound(logger, blobName, functionName, queueMessageId, null);

            public static void BlobNotFound(ILogger<BlobListener> logger, string blobName, string queueMessageId) =>
               _blobNotFound(logger, blobName, queueMessageId, null);
        }
    }
}

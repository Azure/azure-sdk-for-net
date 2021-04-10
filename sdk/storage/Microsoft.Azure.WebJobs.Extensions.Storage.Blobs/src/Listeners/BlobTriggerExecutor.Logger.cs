// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal partial class BlobTriggerExecutor
    {
        private static class Logger
        {
            // Keep these events in 100-199 range.

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, BlobTriggerScanSource, Exception> _blobDoesNotMatchPattern =
               LoggerMessage.Define<string, string, string, string, BlobTriggerScanSource>(LogLevel.Debug, new EventId(100, nameof(BlobDoesNotMatchPattern)),
                   "Blob '{blobName}' will be skipped for function '{functionName}' because it does not match the pattern '{pattern}'. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, BlobTriggerScanSource, Exception> _blobHasNoETag =
                LoggerMessage.Define<string, string, string, BlobTriggerScanSource>(LogLevel.Debug, new EventId(101, nameof(BlobHasNoETag)),
                    "Blob '{blobName}' will be skipped for function '{functionName}' because its ETag cannot be found. The blob may have been deleted. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, BlobTriggerScanSource, Exception> _blobAlreadyProcessed =
                LoggerMessage.Define<string, string, string, string, BlobTriggerScanSource>(LogLevel.Debug, new EventId(102, nameof(BlobAlreadyProcessed)),
                    "Blob '{blobName}' will be skipped for function '{functionName}' because this blob with ETag '{eTag}' has already been processed. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, string, BlobTriggerScanSource, Exception> _blobMessageEnqueued =
                LoggerMessage.Define<string, string, string, string, string, BlobTriggerScanSource>(LogLevel.Debug, new EventId(103, nameof(BlobMessageEnqueued)),
                    "Blob '{blobName}' is ready for processing by function '{functionName}'. A message with id '{messageId}' has been added to queue '{queueName}'. This message will be dequeued and processed by the BlobTrigger. PollId: '{pollId}'. Source: '{triggerSource}'.");

            public static void BlobDoesNotMatchPattern(ILogger<BlobListener> logger, string functionName, string blobName, string pattern, string pollId, BlobTriggerScanSource triggerSource) =>
                _blobDoesNotMatchPattern(logger, blobName, functionName, pattern, pollId, triggerSource, null);

            public static void BlobHasNoETag(ILogger<BlobListener> logger, string functionName, string blobName, string pollId, BlobTriggerScanSource triggerSource) =>
                _blobHasNoETag(logger, blobName, functionName, pollId, triggerSource, null);

            public static void BlobAlreadyProcessed(ILogger<BlobListener> logger, string functionName, string blobName, string eTag, string pollId, BlobTriggerScanSource triggerSource) =>
                _blobAlreadyProcessed(logger, blobName, functionName, eTag, pollId, triggerSource, null);

            public static void BlobMessageEnqueued(ILogger<BlobListener> logger, string functionName, string blobName, string queueMessageId, string queueName, string pollId, BlobTriggerScanSource triggerSource) =>
                _blobMessageEnqueued(logger, blobName, functionName, queueMessageId, queueName, pollId, triggerSource, null);
        }
    }
}

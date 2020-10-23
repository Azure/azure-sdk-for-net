// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal partial class BlobTriggerExecutor
    {
        private static class Logger
        {
            // Keep these events in 100-199 range.

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, BlobTriggerSource, Exception> _blobDoesNotMatchPattern =
               LoggerMessage.Define<string, string, string, string, BlobTriggerSource>(LogLevel.Debug, new EventId(100, nameof(BlobDoesNotMatchPattern)),
                   "Blob '{blobName}' will be skipped for function '{functionName}' because it does not match the pattern '{pattern}'. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, BlobTriggerSource, Exception> _blobHasNoETag =
                LoggerMessage.Define<string, string, string, BlobTriggerSource>(LogLevel.Debug, new EventId(101, nameof(BlobHasNoETag)),
                    "Blob '{blobName}' will be skipped for function '{functionName}' because its ETag cannot be found. The blob may have been deleted. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, BlobTriggerSource, Exception> _blobAlreadyProcessed =
                LoggerMessage.Define<string, string, string, string, BlobTriggerSource>(LogLevel.Debug, new EventId(102, nameof(BlobAlreadyProcessed)),
                    "Blob '{blobName}' will be skipped for function '{functionName}' because this blob with ETag '{eTag}' has already been processed. PollId: '{pollId}'. Source: '{triggerSource}'.");

            private static readonly Action<ILogger<BlobListener>, string, string, string, string, string, BlobTriggerSource, Exception> _blobMessageEnqueued =
                LoggerMessage.Define<string, string, string, string, string, BlobTriggerSource>(LogLevel.Debug, new EventId(103, nameof(BlobMessageEnqueued)),
                    "Blob '{blobName}' is ready for processing by function '{functionName}'. A message with id '{messageId}' has been added to queue '{queueName}'. This message will be dequeued and processed by the BlobTrigger. PollId: '{pollId}'. Source: '{triggerSource}'.");

            public static void BlobDoesNotMatchPattern(ILogger<BlobListener> logger, string functionName, string blobName, string pattern, string pollId, BlobTriggerSource triggerSource) =>
                _blobDoesNotMatchPattern(logger, blobName, functionName, pattern, pollId, triggerSource, null);

            public static void BlobHasNoETag(ILogger<BlobListener> logger, string functionName, string blobName, string pollId, BlobTriggerSource triggerSource) =>
                _blobHasNoETag(logger, blobName, functionName, pollId, triggerSource, null);

            public static void BlobAlreadyProcessed(ILogger<BlobListener> logger, string functionName, string blobName, string eTag, string pollId, BlobTriggerSource triggerSource) =>
                _blobAlreadyProcessed(logger, blobName, functionName, eTag, pollId, triggerSource, null);

            public static void BlobMessageEnqueued(ILogger<BlobListener> logger, string functionName, string blobName, string queueMessageId, string queueName, string pollId, BlobTriggerSource triggerSource) =>
                _blobMessageEnqueued(logger, blobName, functionName, queueMessageId, queueName, pollId, triggerSource, null);
        }
    }
}

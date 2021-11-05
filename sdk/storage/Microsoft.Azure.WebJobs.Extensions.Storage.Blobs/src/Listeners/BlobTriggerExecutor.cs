// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal partial class BlobTriggerExecutor : ITriggerExecutor<BlobTriggerExecutorContext>
    {
        internal const string TriggerSourceKey = "MS_TriggerSource";
        internal const string TriggerClientRequestIdKey = "MS_ClientRequestId";

        private readonly string _hostId;
        private readonly FunctionDescriptor _functionDescriptor;
        private readonly IBlobPathSource _input;
        private readonly IBlobTriggerQueueWriter _queueWriter;
        private readonly IBlobReceiptManager _receiptManager;
        private readonly ILogger<BlobListener> _logger;

        public BlobTriggerExecutor(string hostId, FunctionDescriptor functionDescriptor, IBlobPathSource input,
            IBlobReceiptManager receiptManager, IBlobTriggerQueueWriter queueWriter, ILogger<BlobListener> logger)
        {
            _hostId = hostId;
            _functionDescriptor = functionDescriptor;
            _input = input;
            _queueWriter = queueWriter;
            _receiptManager = receiptManager;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<FunctionResult> ExecuteAsync(BlobTriggerExecutorContext context, CancellationToken cancellationToken)
        {
            BlobBaseClient value = context.Blob.BlobClient;
            BlobTriggerScanSource triggerSource = context.TriggerSource;
            string pollId = context.PollId;

            // Avoid unnecessary network calls for non-matches. First, check to see if the blob matches this trigger.
            IReadOnlyDictionary<string, object> bindingData = _input.CreateBindingData(value.ToBlobPath());

            if (bindingData == null)
            {
                string pattern = new BlobPath(_input.ContainerNamePattern, _input.BlobNamePattern).ToString();
                Logger.BlobDoesNotMatchPattern(_logger, _functionDescriptor.LogName, value.Name, pattern, pollId, triggerSource);

                // Blob is not a match for this trigger.
                return new FunctionResult(true);
            }

            // Next, check to see if the blob currently exists (and, if so, what the current ETag is).
            BlobProperties blobProperties = await value.FetchPropertiesOrNullIfNotExistAsync(cancellationToken).ConfigureAwait(false);
            string possibleETag = null;
            if (blobProperties != null)
            {
                possibleETag = blobProperties.ETag.ToString();
            }

            if (possibleETag == null)
            {
                Logger.BlobHasNoETag(_logger, _functionDescriptor.LogName, value.Name, pollId, triggerSource);

                // If the blob doesn't exist and have an ETag, don't trigger on it.
                return new FunctionResult(true);
            }

            var receiptBlob = _receiptManager.CreateReference(_hostId, _functionDescriptor.Id, value.BlobContainerName,
                value.Name, possibleETag);

            // Check for the completed receipt. If it's already there, noop.
            BlobReceipt unleasedReceipt = await _receiptManager.TryReadAsync(receiptBlob, cancellationToken).ConfigureAwait(false);

            if (unleasedReceipt != null && unleasedReceipt.IsCompleted)
            {
                Logger.BlobAlreadyProcessed(_logger, _functionDescriptor.LogName, value.Name, possibleETag, pollId, triggerSource);

                return new FunctionResult(true);
            }
            else if (unleasedReceipt == null)
            {
                // Try to create (if not exists) an incomplete receipt.
                if (!await _receiptManager.TryCreateAsync(receiptBlob, cancellationToken).ConfigureAwait(false))
                {
                    // Someone else just created the receipt; wait to try to trigger until later.
                    // Alternatively, we could just ignore the return result and see who wins the race to acquire the
                    // lease.
                    return new FunctionResult(false);
                }
            }

            string leaseId = await _receiptManager.TryAcquireLeaseAsync(receiptBlob, cancellationToken).ConfigureAwait(false);

            if (leaseId == null)
            {
                // If someone else owns the lease and just took over this receipt or deleted it;
                // wait to try to trigger until later.
                return new FunctionResult(false);
            }

            try
            {
                // Check again for the completed receipt. If it's already there, noop.
                BlobReceipt receipt = await _receiptManager.TryReadAsync(receiptBlob, cancellationToken).ConfigureAwait(false);
                Debug.Assert(receipt != null); // We have a (30 second) lease on the blob; it should never disappear on us.

                if (receipt.IsCompleted)
                {
                    Logger.BlobAlreadyProcessed(_logger, _functionDescriptor.LogName, value.Name, possibleETag, pollId, triggerSource);

                    await _receiptManager.ReleaseLeaseAsync(receiptBlob, leaseId, cancellationToken).ConfigureAwait(false);
                    return new FunctionResult(true);
                }

                // We've successfully acquired a lease to enqueue the message for this blob trigger. Enqueue the message,
                // complete the receipt and release the lease.

                // Enqueue a message: function ID + blob path + ETag
                BlobTriggerMessage message = new BlobTriggerMessage
                {
                    FunctionId = _functionDescriptor.Id,
                    BlobType = blobProperties.BlobType,
                    ContainerName = value.BlobContainerName,
                    BlobName = value.Name,
                    ETag = possibleETag
                };

                var (queueName, messageId) = await _queueWriter.EnqueueAsync(message, cancellationToken).ConfigureAwait(false);

                Logger.BlobMessageEnqueued(_logger, _functionDescriptor.LogName, value.Name, messageId, queueName, pollId, triggerSource);

                // Complete the receipt
                await _receiptManager.MarkCompletedAsync(receiptBlob, leaseId, cancellationToken).ConfigureAwait(false);

                return new FunctionResult(true);
            }
            finally
            {
                await _receiptManager.ReleaseLeaseAsync(receiptBlob, leaseId, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    internal partial class BlobQueueTriggerExecutor : ITriggerExecutor<CloudQueueMessage>
    {
        private const string BlobCreatedKey = "BlobCreated";
        private const string BlobLastModifiedKey = "BlobLastModified";

        private readonly IBlobCausalityReader _causalityReader;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;
        private readonly ConcurrentDictionary<string, BlobQueueRegistration> _registrations;
        private readonly ILogger<BlobListener> _logger;

        public BlobQueueTriggerExecutor(IBlobWrittenWatcher blobWrittenWatcher, ILogger<BlobListener> logger)
            : this(BlobCausalityReader.Instance, blobWrittenWatcher, logger)
        {
        }

        public BlobQueueTriggerExecutor(IBlobCausalityReader causalityReader, IBlobWrittenWatcher blobWrittenWatcher, ILogger<BlobListener> logger)
        {
            _causalityReader = causalityReader;
            _blobWrittenWatcher = blobWrittenWatcher;
            _registrations = new ConcurrentDictionary<string, BlobQueueRegistration>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool TryGetRegistration(string functionId, out BlobQueueRegistration registration)
        {
            return _registrations.TryGetValue(functionId, out registration);
        }

        public void Register(string functionId, BlobQueueRegistration registration)
        {
            _registrations.AddOrUpdate(functionId, registration, (i1, i2) => registration);
        }

        public async Task<FunctionResult> ExecuteAsync(CloudQueueMessage value, CancellationToken cancellationToken)
        {
            BlobTriggerMessage message = JsonConvert.DeserializeObject<BlobTriggerMessage>(value.AsString, JsonSerialization.Settings);

            if (message == null)
            {
                throw new InvalidOperationException("Invalid blob trigger message.");
            }

            string functionId = message.FunctionId;

            if (functionId == null)
            {
                throw new InvalidOperationException("Invalid function ID.");
            }

            // Ensure that the function ID is still valid. Otherwise, ignore this message.
            FunctionResult successResult = new FunctionResult(true);
            if (!_registrations.TryGetValue(functionId, out BlobQueueRegistration registration))
            {
                Logger.FunctionNotFound(_logger, message.BlobName, functionId, value.Id);
                return successResult;
            }

            var container = registration.BlobClient.GetContainerReference(message.ContainerName);
            string blobName = message.BlobName;

            ICloudBlob blob;

            try
            {
                blob = await container.GetBlobReferenceFromServerAsync(blobName);
            }
            catch (StorageException exception) when (exception.IsNotFound() || exception.IsOk())
            {
                // If the blob no longer exists, just ignore this message.
                Logger.BlobNotFound(_logger, blobName, value.Id);
                return successResult;
            }

            // Ensure the blob still exists with the same ETag.
            string possibleETag = blob.Properties.ETag; // set since we fetched from server

            // If the blob still exists but the ETag is different, delete the message but do a fast path notification.
            if (!string.Equals(message.ETag, possibleETag, StringComparison.Ordinal))
            {
                _blobWrittenWatcher.Notify(blob);
                return successResult;
            }

            // If the blob still exists and its ETag is still valid, execute.
            // Note: it's possible the blob could change/be deleted between now and when the function executes.
            Guid? parentId = await _causalityReader.GetWriterAsync(blob, cancellationToken);

            // Include the queue details here.
            IDictionary<string, string> details = QueueTriggerExecutor.PopulateTriggerDetails(value);

            if (blob?.Properties?.Created != null && blob.Properties.Created.HasValue)
            {
                details[BlobCreatedKey] = blob.Properties.Created.Value.ToString(Constants.DateTimeFormatString);
            }

            if (blob?.Properties?.LastModified != null && blob.Properties.LastModified.HasValue)
            {
                details[BlobLastModifiedKey] = blob.Properties.LastModified.Value.ToString(Constants.DateTimeFormatString);
            }

            TriggeredFunctionData input = new TriggeredFunctionData
            {
                ParentId = parentId,
                TriggerValue = blob,
                TriggerDetails = details
            };

            return await registration.Executor.TryExecuteAsync(input, cancellationToken);
        }
    }
}

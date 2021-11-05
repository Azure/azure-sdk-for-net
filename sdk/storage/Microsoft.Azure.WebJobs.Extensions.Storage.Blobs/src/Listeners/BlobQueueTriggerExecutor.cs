// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    internal partial class BlobQueueTriggerExecutor : ITriggerExecutor<QueueMessage>
    {
        private const string BlobCreatedKey = "BlobCreated";
        private const string BlobLastModifiedKey = "BlobLastModified";

        private readonly IBlobCausalityReader _causalityReader;
        private readonly IBlobWrittenWatcher _blobWrittenWatcher;
        private readonly ConcurrentDictionary<string, BlobQueueRegistration> _registrations;
        private readonly BlobTriggerSource _blobTriggerSource;
        private readonly ILogger<BlobListener> _logger;

        public BlobQueueTriggerExecutor(BlobTriggerSource blobTriggerSource, IBlobWrittenWatcher blobWrittenWatcher, ILogger<BlobListener> logger)
            : this(BlobCausalityReader.Instance, blobTriggerSource, blobWrittenWatcher, logger)
        {
        }

        public BlobQueueTriggerExecutor(IBlobCausalityReader causalityReader, BlobTriggerSource blobTriggerSource, IBlobWrittenWatcher blobWrittenWatcher, ILogger<BlobListener> logger)
        {
            _causalityReader = causalityReader;
            _blobTriggerSource = blobTriggerSource;
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

        public async Task<FunctionResult> ExecuteAsync(QueueMessage value, CancellationToken cancellationToken)
        {
            BlobTriggerMessage message = JsonConvert.DeserializeObject<BlobTriggerMessage>(value.Body.ToValidUTF8String(), JsonSerialization.Settings);

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
                Logger.FunctionNotFound(_logger, message.BlobName, functionId, value.MessageId);
                return successResult;
            }

            var container = registration.BlobServiceClient.GetBlobContainerClient(message.ContainerName);
            string blobName = message.BlobName;

            BlobBaseClient blob;
            BlobProperties blobProperties;

            try
            {
                (blob, blobProperties) = await container.GetBlobReferenceFromServerAsync(blobName, cancellationToken).ConfigureAwait(false);
            }
            catch (RequestFailedException exception) when (exception.IsNotFound() || exception.IsOk())
            {
                // If the blob no longer exists, just ignore this message.
                Logger.BlobNotFound(_logger, blobName, value.MessageId);
                return successResult;
            }

            // Ensure the blob still exists with the same ETag.
            string possibleETag = blobProperties.ETag.ToString();

            // If the blob still exists but the ETag is different, delete the message but do a fast path notification.
            if (_blobTriggerSource == BlobTriggerSource.LogsAndContainerScan && !string.Equals(message.ETag, possibleETag, StringComparison.Ordinal))
            {
                _blobWrittenWatcher.Notify(new Extensions.Storage.Blobs.BlobWithContainer<BlobBaseClient>(container, blob));
                return successResult;
            }

            // If the blob still exists and its ETag is still valid, execute.
            // Note: it's possible the blob could change/be deleted between now and when the function executes.
            Guid? parentId = await _causalityReader.GetWriterAsync(blob, cancellationToken).ConfigureAwait(false);

            // Include the queue details here.
            IDictionary<string, string> details = PopulateTriggerDetails(value);

            if (blobProperties.CreatedOn != null)
            {
                details[BlobCreatedKey] = blobProperties.CreatedOn.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture);
            }

            if (blobProperties.LastModified != null)
            {
                details[BlobLastModifiedKey] = blobProperties.LastModified.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture);
            }

            TriggeredFunctionData input = new TriggeredFunctionData
            {
                ParentId = parentId,
                TriggerValue = blob,
                TriggerDetails = details
            };

            return await registration.Executor.TryExecuteAsync(input, cancellationToken).ConfigureAwait(false);
        }

        // TODO (kasobol-msft) duplication with QueueTriggerExecutor.PopulateTriggerDetails.
        internal static Dictionary<string, string> PopulateTriggerDetails(QueueMessage value)
        {
            return new Dictionary<string, string>()
            {
                { "MessageId", value.MessageId },
                { nameof(QueueMessage.DequeueCount), value.DequeueCount.ToString(CultureInfo.InvariantCulture) },
                { nameof(QueueMessage.InsertedOn), value.InsertedOn?.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture) }
            };
        }
    }
}

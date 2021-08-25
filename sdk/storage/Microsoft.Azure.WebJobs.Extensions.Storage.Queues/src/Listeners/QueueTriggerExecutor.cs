// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners
{
    internal class QueueTriggerExecutor : ITriggerExecutor<QueueMessage>
    {
        private readonly ITriggeredFunctionExecutor _innerExecutor;
        private readonly QueueCausalityManager _queueCausalityManager;

        public QueueTriggerExecutor(ITriggeredFunctionExecutor innerExecutor, QueueCausalityManager queueCausalityManager)
        {
            _innerExecutor = innerExecutor;
            _queueCausalityManager = queueCausalityManager;
        }

        public async Task<FunctionResult> ExecuteAsync(QueueMessage value, CancellationToken cancellationToken)
        {
            Guid? parentId = _queueCausalityManager.GetOwner(value);
            TriggeredFunctionData input = new TriggeredFunctionData
            {
                ParentId = parentId,
                TriggerValue = value,
                TriggerDetails = PopulateTriggerDetails(value)
            };
            return await _innerExecutor.TryExecuteAsync(input, cancellationToken).ConfigureAwait(false);
        }

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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.Storage.Queue;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host.Queues.Listeners
{
    internal class QueueTriggerExecutor : ITriggerExecutor<CloudQueueMessage>
    {
        private readonly ITriggeredFunctionExecutor _innerExecutor;

        public QueueTriggerExecutor(ITriggeredFunctionExecutor innerExecutor)
        {
            _innerExecutor = innerExecutor;
        }

        public async Task<FunctionResult> ExecuteAsync(CloudQueueMessage value, CancellationToken cancellationToken)
        {
            Guid? parentId = QueueCausalityManager.GetOwner(value);
            TriggeredFunctionData input = new TriggeredFunctionData
            {
                ParentId = parentId,
                TriggerValue = value,
                TriggerDetails = PopulateTriggerDetails(value)
            };
            return await _innerExecutor.TryExecuteAsync(input, cancellationToken).ConfigureAwait(false);
        }

        internal static Dictionary<string, string> PopulateTriggerDetails(CloudQueueMessage value)
        {
            return new Dictionary<string, string>()
            {
                { "MessageId", value.Id },
                { nameof(CloudQueueMessage.DequeueCount), value.DequeueCount.ToString(CultureInfo.InvariantCulture) },
                { nameof(CloudQueueMessage.InsertionTime), value.InsertionTime?.ToString(Constants.DateTimeFormatString, CultureInfo.InvariantCulture) }
            };
        }
    }
}

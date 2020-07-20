// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.WebJobs.Host;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    internal static class CloudQueueMessageExtensions
    {
        private static PropertyHelper _idProp = PropertyHelper.GetProperties(typeof(CloudQueueMessage)).Single(p => p.Name == nameof(CloudQueueMessage.Id));
        private static PropertyHelper _popReceiptProp = PropertyHelper.GetProperties(typeof(CloudQueueMessage)).Single(p => p.Name == nameof(CloudQueueMessage.PopReceipt));

        /// <summary>
        /// Overwrites the message's Id and PopReceipt properties with the specified values, if different.
        /// </summary>
        public static void UpdateChangedProperties(this CloudQueueMessage message, string id, string popReceipt)
        {
            if (id != message.Id)
            {
                _idProp.SetValue(message, id);
            }

            if (popReceipt != message.PopReceipt)
            {
                _popReceiptProp.SetValue(message, popReceipt);
            }
        }
    }
}

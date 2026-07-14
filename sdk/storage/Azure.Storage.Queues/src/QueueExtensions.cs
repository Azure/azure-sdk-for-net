// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Queues.Models;
using Azure.Core;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Extension methods for parsing response headers.
    /// </summary>
    internal static partial class QueueExtensions
    {
        private const string ApproximateMessagesCountHeader = "x-ms-approximate-messages-count";
        private const string TimeNextVisibleHeader = "x-ms-time-next-visible";
        private const string PopReceiptHeader = "x-ms-popreceipt";
        private const string MetadataHeaderPrefix = "x-ms-meta-";

        /// <summary>
        /// Parses QueueProperties from a GetProperties response.
        /// </summary>
        internal static QueueProperties ToQueueProperties(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new QueueProperties
            {
                ApproximateMessagesCountLong = (response.Headers.TryGetValue(ApproximateMessagesCountHeader, out long? count) ? count : null).GetValueOrDefault(),
                Metadata = response.Headers.TryGetValue(MetadataHeaderPrefix, out IDictionary<string, string> metadata)
                    ? metadata
                    : null
            };
        }

        /// <summary>
        /// Parses UpdateReceipt from an UpdateMessage response.
        /// </summary>
        internal static UpdateReceipt ToUpdateReceipt(this Response response)
        {
            if (response == null)
            {
                return null;
            }

            return new UpdateReceipt
            {
                NextVisibleOn = (response.Headers.TryGetValue(TimeNextVisibleHeader, out DateTimeOffset? timeNextVisible) ? timeNextVisible : null).GetValueOrDefault(),
                PopReceipt = response.Headers.TryGetValue(PopReceiptHeader, out string popReceipt) ? popReceipt : null
            };
        }
    }
}

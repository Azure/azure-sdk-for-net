// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    internal static class StorageQueueMessageExtensions
    {
        public static string TryGetAsString(this CloudQueueMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            string value;

            try
            {
                value = message.AsString;
            }
            catch (Exception ex)
            {
                if (ex is DecoderFallbackException || ex is FormatException)
                {
                    value = null;
                }
                else
                {
                    throw;
                }
            }

            return value;
        }
    }
}

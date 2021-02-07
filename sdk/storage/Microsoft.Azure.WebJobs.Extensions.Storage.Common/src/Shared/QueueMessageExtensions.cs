// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common
{
    internal static class QueueMessageExtensions
    {
        public static string TryGetAsString(this QueueMessage message, ILogger logger)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            string value;

            try
            {
                value = message.Body.ToValidUTF8String();
            }
            catch (Exception ex)
            {
                if (ex is DecoderFallbackException || ex is FormatException)
                {
                    logger.LogWarning($"Queue message's body cannot be converted to string because it contains non-UTF8 bytes, message id={message.MessageId}");
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

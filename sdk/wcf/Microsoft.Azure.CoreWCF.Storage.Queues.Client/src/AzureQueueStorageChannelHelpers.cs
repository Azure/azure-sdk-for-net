// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.ServiceModel;

namespace Azure.Storage.WCF.Channels
{
    internal static class AzureQueueStorageChannelHelpers
    {
        /// <summary>
        /// The Channel layer normalizes exceptions thrown by the underlying networking implementations
        /// into subclasses of CommunicationException, so that Channels can be used polymorphically from
        /// an exception handling perspective.
        /// </summary>
        internal static CommunicationException ConvertTransferException(Exception e)
        {
            return new CommunicationException(
                string.Format(CultureInfo.CurrentCulture,
                "An error ({0}) occurred while transmitting message.", e.Message),
                e);
        }

        internal static void ThrowIfDisposedOrNotOpen(object state)
        {
            switch (state)
            {
                case CommunicationState.Created:
                case CommunicationState.Opening:
                case CommunicationState.Closing:
                case CommunicationState.Closed:
                case CommunicationState.Faulted:
                    throw new CommunicationException("ThrowIfDisposedOrNotOpen: Communicate object not in open state. Current state: " + state.ToString());
                default:
                    throw new CommunicationException("ThrowIfDisposedOrNotOpen: Unknown CommunicationObject.state");
                case CommunicationState.Opened:
                    break;
            }
        }

        internal static void ValidateTimeout(TimeSpan timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("timeout", timeout, "Timeout must be greater than or equal to TimeSpan.Zero. To disable timeout, specify TimeSpan.MaxValue.");
            }
        }

        internal static AzureQueueStorageMessageEncoding ConvertMessageEncoding(Azure.Storage.Queues.QueueMessageEncoding queueMessageEncoding)
        {
            switch (queueMessageEncoding)
            {
                case Azure.Storage.Queues.QueueMessageEncoding.None:
                    return AzureQueueStorageMessageEncoding.Text;
                case Azure.Storage.Queues.QueueMessageEncoding.Base64:
                    return AzureQueueStorageMessageEncoding.Binary;
                default:
                    return AzureQueueStorageMessageEncoding.Text;
            }
        }

        internal static void ValidateQueueNames(
            string queueNameConnectionString,
            string queueNameUri)
        {
            if (string.IsNullOrEmpty(queueNameConnectionString) && string.IsNullOrEmpty(queueNameUri))
            {
                throw new ArgumentException("Queue name could not be found.");
            }

            if (string.IsNullOrEmpty(queueNameConnectionString) || string.IsNullOrEmpty(queueNameUri))
            {
                return;
            }

            if (queueNameConnectionString != queueNameUri)
            {
                throw new ArgumentException("Queue Name passed in as queuename on connection string and End point Uri do not match.");
            }
        }

        internal static string ExtractQueueNameFromConnectionString(string connectionString)
        {
            string[] parts = connectionString.Split(';');

            foreach (string part in parts)
            {
                if (part.Trim().StartsWith("QueueEndpoint=", StringComparison.OrdinalIgnoreCase))
                {
                    // Split the part by '/' and take the 5th segment if present as the queue name.
                    string[] endpointParts = part.Split('/');
                    if (endpointParts.Length > 4)
                    {
                        return endpointParts[endpointParts.Length - 1];
                    }
                }
            }

            return null;
        }

        internal static string ExtractQueueNameFromUri(Uri endPointUri)
        {
            if (endPointUri == null || string.IsNullOrEmpty(endPointUri.AbsoluteUri))
            {
                throw new ArgumentException("The endPointUri is empty.");
            }

            string[] segments = endPointUri.AbsoluteUri.Split(new char[] { '/', '?' });

            if (segments.Length > 4)
            {
                return segments[4].TrimEnd('/');
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

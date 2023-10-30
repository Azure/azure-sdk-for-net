// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using CoreWCF;

namespace Azure.Storage.CoreWCF.Channels
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
                throw new ArgumentOutOfRangeException(nameof(timeout), timeout, "Timeout must be greater than or equal to TimeSpan.Zero. To disable timeout, specify TimeSpan.MaxValue.");
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

        internal static string ExtractAndValidateQueueName(
            Uri endpointUri,
            AzureQueueStorageTransportBindingElement azureQueueStorageTransportBindingElement)
        {
            string queueNameConnectionString = "";

            if (!string.IsNullOrEmpty(azureQueueStorageTransportBindingElement.ConnectionString))
            {
                queueNameConnectionString = ExtractQueueNameFromConnectionString(azureQueueStorageTransportBindingElement.ConnectionString);
            }

            string queueNameUri = ExtractQueueNameFromUri(endpointUri);

            ValidateQueueNames(queueNameConnectionString, queueNameUri);

            return queueNameConnectionString ?? queueNameUri;
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

        internal static Uri CreateEndpointUriForQueue(Uri baseAddress, string queueName)
        {
            string[] segments = baseAddress.AbsoluteUri.Split(new char[] { '/', '?' });

            if (segments.Length < 4)
            {
                throw new ArgumentException("EndPoint Uri is not in the correct format.");
            }

            segments[4] = queueName;
            return new Uri(string.Join("/", segments));
        }

        internal static Uri CreateEndpointUriFromConnectionString(string connectionString)
        {
            string[] segments = connectionString.Split(new char[] { ';' });

            foreach (string segment in segments)
            {
                if (segment.Contains("QueueEndpoint="))
                {
                    return new UriBuilder(segment.Replace("QueueEndpoint=", "")).Uri;
                }
            }
            return null;
        }
    }
}

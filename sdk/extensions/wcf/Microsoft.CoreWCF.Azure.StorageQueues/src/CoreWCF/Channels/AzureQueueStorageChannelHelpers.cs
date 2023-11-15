// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using CoreWCF;

namespace Microsoft.CoreWCF.Azure.StorageQueues
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
            string endpoint = ExtractEndpointFromConnectionString(connectionString);

            if (!string.IsNullOrEmpty(endpoint))
            {
                // Handle URL transformations if needed
                endpoint = TransformEndpointUrl(endpoint);
                return new Uri(endpoint);
            }

            return null;
        }

        internal static string GetEndpointStringFromConnectionString(string connectionString)
        {
            string endpoint = ExtractEndpointFromConnectionString(connectionString);
            return endpoint;
        }

        private static string ExtractEndpointFromConnectionString(string connectionString)
        {
            string[] segments = connectionString.Split(new char[] { ';' });

            foreach (string segment in segments)
            {
                var trimmedSegment = segment.Trim();
                if (trimmedSegment.StartsWith("QueueEndpoint="))
                {
                    return trimmedSegment.Replace("QueueEndpoint=", "");
                }
            }

            return null;
        }

        private static string TransformEndpointUrl(string endpoint)
        {
            // Apply URL transformations here if needed
            return endpoint.Replace("https", "net.aqs");
        }
    }
}

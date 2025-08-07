// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF;
using System;
using System.Globalization;

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
                SR.SendError, e.Message),
                e);
        }

        internal static Uri ExtractQueueUriFromConnectionString(string connectionString)
        {
            string[] parts = connectionString.Split(';');

            foreach (string part in parts)
            {
                var keyValue = part.Trim().Split('=');
                if (keyValue[0].Equals("QueueEndpoint", StringComparison.OrdinalIgnoreCase))
                {
                    if (Uri.TryCreate(keyValue[1], default, out Uri endpointUri))
                    {
                        return endpointUri;
                    }
                }
            }

            return null;
        }

        internal static void ExtractAccountAndQueueNameFromUri(Uri endpointUri, bool queueNameRequired, out string accountName, out string queueName)
        {
            if (endpointUri.HostNameType == UriHostNameType.Dns && !endpointUri.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                // Account name should be first component of hostname, eg
                // https://<storage account>.queue.core.windows.net/<queue>

                if (queueNameRequired)
                {
                    // If queue name required, then the uri should have 2 segments, "/" and the queue name
                    if (endpointUri.Segments.Length != 2)
                    {
                        throw new ArgumentException(string.Format(SR.AccountNameShouldBePartOfHostName, endpointUri));
                    }
                    queueName = endpointUri.Segments[1].TrimEnd('/');
                }
                else
                {
                    // If the queue name is not required, then there could be 2 or 1 segments. Any more than 2 means the account
                    // name was in the path
                    if (endpointUri.Segments.Length > 2)
                    {
                        throw new ArgumentException(string.Format(SR.AccountNameShouldBePartOfHostName, endpointUri));
                    }
                    if (endpointUri.Segments.Length == 2)
                    {
                        // Queue name is part of path, so extract it
                        queueName = endpointUri.Segments[1].TrimEnd('/');
                    }
                    else
                    {
                        // Queue name wasn't provided in url, and wasn't required
                        queueName = String.Empty;
                    }
                }

                accountName = endpointUri.Host.Split('.')[0];
            }
            else
            {
                // Hostname is not a Dns hostname or is localhost. Likely using Azure where the account name is
                // a path segment, eg
                // https://127.0.0.1/<storage account>/<queue>
                if (queueNameRequired)
                {
                    if (endpointUri.Segments.Length != 3)
                    {
                        throw new ArgumentException(string.Format(SR.AccountNameShouldBePartOfUriPath, endpointUri));
                    }
                    queueName = endpointUri.Segments[2].TrimEnd('/');
                }
                else
                {
                    // If the queue name is not required, then there could be 3 or 2 segments.
                    if (endpointUri.Segments.Length < 2)
                    {
                        throw new ArgumentException(string.Format(SR.AccountNameShouldBePartOfHostName, endpointUri));
                    }
                    if (endpointUri.Segments.Length == 3)
                    {
                        // Queue name is part of path, so extract it
                        queueName = endpointUri.Segments[2].TrimEnd('/');
                    }
                    else
                    {
                        // Queue name wasn't provided in url, and wasn't required
                        queueName = String.Empty;
                    }
                }

                accountName = endpointUri.Segments[1].TrimEnd('/');
            }
        }

        internal static string ReplaceQueueUriInConnectionString(string connectionString, Uri via)
        {
            if (!via.Scheme.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                var builder = new UriBuilder(via);
                var connectionStringUri = ExtractQueueUriFromConnectionString(connectionString);
                if (connectionStringUri != null)
                {
                    // If using an AQS emulator, might be using http. Pull the scheme from the connection string to account for that
                    builder.Scheme = connectionStringUri.Scheme;
                }
                else
                {
                    // In case the queue endpoint isn't in the connection string, just presume https. Only case this is wrong is when
                    // using http with AQS emulator not configured for HTTPS, in which case just add it to the connection string.
                    builder.Scheme = "https";
                }

                via = builder.Uri;
            }

            string[] parts = connectionString.Split(';');

            for (int i = 0; i < parts.Length; i++)
            {
                var keyValue = parts[i].Trim().Split('=');
                if (keyValue[0].Equals("QueueEndpoint", StringComparison.OrdinalIgnoreCase))
                {
                    parts[i] = $"QueueEndpoint={via.AbsoluteUri}";
                    break;
                }
            }

            return string.Join(";", parts);
        }
    }
}

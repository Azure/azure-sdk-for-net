// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.CoreWCF.Channels
{
    /// <summary>
    /// Class containing methods to convert Queue Name.
    /// </summary>
    public class AzureQueueStorageQueueNameConverter
    {
        /// <summary>
        /// Method to fetch Queue Endpoint Url
        /// </summary>
        public static string GetEndpointUrl(string accountName, string queueName)
        {
            return $"net.aqs://{accountName}.queue.core.windows.net/{queueName}";
        }

        /// <summary>
        /// Method to fetch Queue name from endpoint.
        /// </summary>
        public static string GetAzureQueueStorageQueueName(Uri endpoint)
        {
            string uriLocalPath = endpoint.LocalPath; //check if this should be absolute path
            int startIndex = uriLocalPath.LastIndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            int length = uriLocalPath.Length - startIndex - 1;
            string queueName = uriLocalPath.Substring(startIndex, length);
            return queueName;
        }
    }
}

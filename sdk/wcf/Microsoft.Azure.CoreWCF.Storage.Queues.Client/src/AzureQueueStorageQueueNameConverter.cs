// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Queues;

namespace Microsoft.ServiceModel.AQS
{
    internal class AzureQueueStorageQueueNameConverter
    {
        public static Uri ConvertToHttpEndpointUrl(Uri uri)
        {
            QueueUriBuilder builder = new QueueUriBuilder(uri);
            return new Uri("https://" + builder.AccountName.ToString() +"." + builder.Host.ToString() + "/" + builder.QueueName.ToString() + ":" + builder.Port.ToString());
        }

        public static Uri ConvertToNetEndpointUrl(Uri uri)
        {
            QueueUriBuilder builder = new QueueUriBuilder(uri);
            return new Uri("net.aqs://" + builder.AccountName.ToString() + "." + builder.QueueName.ToString() + "." + builder.Host.ToString() + ":" + builder.Port.ToString());
        }
    }
}

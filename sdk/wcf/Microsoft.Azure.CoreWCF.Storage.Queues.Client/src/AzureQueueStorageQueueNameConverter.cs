// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Storage.Queues;

namespace Azure.Storage.WCF.Channels
{
    internal class AzureQueueStorageQueueNameConverter
    {
        public static Uri ConvertToHttpEndpointUrl(Uri uri)
        {
            if (uri.HostNameType == UriHostNameType.IPv4 || uri.HostNameType == UriHostNameType.IPv6)
            {
                var ipaddress = IPAddress.Parse(uri.Host);
                if (IPAddress.IsLoopback(ipaddress))
                {
                    // this means that Azurite is being used for tests.
                    UriBuilder uriBuilder = new(uri)
                    {
                        Scheme = "https"
                    };
                    return uriBuilder.Uri;
                }
            }

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

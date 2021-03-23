// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace Azure.Core.Pipeline
{
    // This type manages changing HttpClient/HttpWebRequest defaults to more appropriate values
    // There are two limits we target:
    // - Per Server Connection Limit
    // - Keep Alive Connection Timeout
    // On .NET Core 2.1 & NET 5.0 the HttpClientTransport would default to using the SocketClientHandler
    //   we adjust both limits on the client handler
    // On .NET Standard & NET 4.6+ the HttpClientTransport would default to using the HttpClientHandler
    //   and there is no easy way to set Keep Alive Connection Timeout but it's mitigated by WebHttpRequestTransport
    //   being the default on NET 4.6.1
    // The default transport on NET 4.6.1 is WebHttpRequestTransport the default and we are updating both
    //  limits on the service point

    internal static class ServicePointHelpers
    {
        private const int RuntimeDefaultConnectionLimit = 2;
        private const int IncreasedConnectionLimit = 50;
        private const int IncreasedConnectionLeaseTimeout = 300 * 1000;

#if NETFRAMEWORK || NETSTANDARD
        private const int DefaultConnectionLeaseTimeout = Timeout.Infinite;

        public static void SetLimits(ServicePoint requestServicePoint)
        {
            // Only change when the default runtime limit is used
            if (requestServicePoint.ConnectionLimit == RuntimeDefaultConnectionLimit)
            {
                requestServicePoint.ConnectionLimit = IncreasedConnectionLimit;
            }

            if (requestServicePoint.ConnectionLeaseTimeout == DefaultConnectionLeaseTimeout)
            {
                requestServicePoint.ConnectionLeaseTimeout = IncreasedConnectionLeaseTimeout;
            }
        }

        public static void SetLimits(HttpClientHandler httpClientHandler)
        {
            // Only change when the default runtime limit is used
            if (httpClientHandler.MaxConnectionsPerServer == RuntimeDefaultConnectionLimit)
            {
                httpClientHandler.MaxConnectionsPerServer = IncreasedConnectionLimit;
            }
        }
#else // NETCOREAPP +
        private static TimeSpan DefaultConnectionLeaseTimeoutTimeSpan = Timeout.InfiniteTimeSpan;
        private static TimeSpan IncreasedConnectionLeaseTimeoutTimeSpan = TimeSpan.FromMilliseconds(IncreasedConnectionLeaseTimeout);

        public static void SetLimits(SocketsHttpHandler socketsHttpHandler)
        {
            if (socketsHttpHandler.MaxConnectionsPerServer == RuntimeDefaultConnectionLimit)
            {
                socketsHttpHandler.MaxConnectionsPerServer = IncreasedConnectionLimit;
            }
            if (socketsHttpHandler.PooledConnectionLifetime == DefaultConnectionLeaseTimeoutTimeSpan)
            {
                socketsHttpHandler.PooledConnectionLifetime = IncreasedConnectionLeaseTimeoutTimeSpan;
            }
        }
#endif
    }
}
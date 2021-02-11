// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;

namespace Azure.Core.Pipeline
{
    internal static class ServicePointHelpers
    {
        private const int RuntimeDefaultConnectionLimit = 2;
        private const int IncreasedConnectionLimit = 50;

        public static void SetLimits(ServicePoint requestServicePoint)
        {
            // Only change when the default runtime limit is used
            if (requestServicePoint.ConnectionLimit == RuntimeDefaultConnectionLimit)
            {
                requestServicePoint.ConnectionLimit = IncreasedConnectionLimit;
            }
        }

        public static void SetLimits(HttpClientHandler requestServicePoint)
        {
            // Only change when the default runtime limit is used
            if (requestServicePoint.MaxConnectionsPerServer == RuntimeDefaultConnectionLimit)
            {
                requestServicePoint.MaxConnectionsPerServer = IncreasedConnectionLimit;
            }
        }
    }
}
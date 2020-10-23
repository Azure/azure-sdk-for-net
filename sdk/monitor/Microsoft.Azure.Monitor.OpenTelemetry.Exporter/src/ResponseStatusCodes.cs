﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter
{
    internal class ResponseStatusCodes
    {
        public const int Success = 200;
        public const int PartialSuccess = 206;
        public const int RequestTimeout = 408;
        public const int ResponseCodeTooManyRequests = 429;
        public const int ResponseCodeTooManyRequestsAndRefreshCache = 439;
        public const int InternalServerError = 500;
        public const int BadGateway = 502;
        public const int ServiceUnavailable = 503;
        public const int GatewayTimeout = 504;
    }
}

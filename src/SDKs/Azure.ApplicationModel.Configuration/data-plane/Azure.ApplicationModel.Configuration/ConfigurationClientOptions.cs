// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure.ApplicationModel.Configuration
{
    public class ConfigurationClientOptions: HttpClientOptions
    {
        static readonly HttpPipelinePolicy s_defaultRetryPolicy = Base.Http.Pipeline.RetryPolicy.CreateFixed(3, TimeSpan.Zero,
            //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after
            500, // Internal Server Error
            503, // Service Unavailable
            504  // Gateway Timeout
        );

        public HttpPipelinePolicy RetryPolicy { get; set; }

        public ConfigurationClientOptions()
        {
            LoggingPolicy = Base.Http.Pipeline.LoggingPolicy.Shared;
            RetryPolicy = s_defaultRetryPolicy;
        }

        public HttpPipelinePolicy LoggingPolicy { get; set; }
    }
}
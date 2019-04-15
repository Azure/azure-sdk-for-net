// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.ApplicationModel.Configuration
{
    public class ConfigurationClientOptions: HttpClientOptions
    {
        public FixedRetryPolicy RetryPolicy { get; set; }

        public HttpPipelinePolicy LoggingPolicy { get; set; }

        public ConfigurationClientOptions()
        {
            LoggingPolicy = Core.Pipeline.Policies.LoggingPolicy.Shared;
            RetryPolicy = new FixedRetryPolicy()
            {
                Delay =  TimeSpan.Zero,
                RetriableCodes = new[]
                {
                    //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after
                    500, // Internal Server Error
                    503, // Service Unavailable
                    504  // Gateway Timeout
                },
                MaxRetries = 3
            };
        }

    }
}

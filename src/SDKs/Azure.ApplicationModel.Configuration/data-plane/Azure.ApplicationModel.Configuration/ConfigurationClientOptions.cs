// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Base.Pipeline;
using Azure.Base.Pipeline.Policies;

namespace Azure.ApplicationModel.Configuration
{
    public class ConfigurationClientOptions: HttpClientOptions
    {
        public ResponseClassifier ResponseClassifier { get; set; }

        public FixedRetryPolicy RetryPolicy { get; set; }

        public HttpPipelinePolicy LoggingPolicy { get; set; }

        public ConfigurationClientOptions()
        {
            ResponseClassifier = new DefaultResponseClassifier();
            LoggingPolicy = Base.Pipeline.Policies.LoggingPolicy.Shared;
            RetryPolicy = new FixedRetryPolicy()
            {
                Delay =  TimeSpan.Zero,
                MaxRetries = 3
            };
        }

    }
}

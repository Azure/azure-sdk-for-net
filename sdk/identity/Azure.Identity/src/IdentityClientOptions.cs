// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Identity
{    public class IdentityClientOptions : HttpClientOptions
    {
        private const string DefaultAuthorityHost = "https://login.microsoftonline.com/";
        private readonly static TimeSpan DefaultRefreshBuffer = TimeSpan.FromMinutes(2);

        public RetryPolicy RetryPolicy { get; set; }

        public HttpPipelinePolicy LoggingPolicy { get; set; }

        public string AuthorityHost { get; set; }

        public TimeSpan RefreshBuffer { get; set; }

        public IdentityClientOptions()
        {
            AuthorityHost = DefaultAuthorityHost;
            LoggingPolicy = Core.Pipeline.Policies.LoggingPolicy.Shared;
            RefreshBuffer = DefaultRefreshBuffer;
            RetryPolicy = new ExponentialRetryPolicy()
            {
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }
}

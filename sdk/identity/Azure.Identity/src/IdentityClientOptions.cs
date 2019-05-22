// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Identity
{
    public class IdentityClientOptions : HttpClientOptions
    {
        public static string BufferResponsePolicy { get; } = "BufferResponse";

        private readonly static Uri DefaultAuthorityHost = new Uri("https://login.microsoftonline.com/");
        private readonly static TimeSpan DefaultRefreshBuffer = TimeSpan.FromMinutes(2);

        public ExponentialRetryOptions Retry { get; } = new ExponentialRetryOptions()
        {
            Delay = TimeSpan.FromMilliseconds(800),
            MaxRetries = 3
        };

        public Uri AuthorityHost { get; set; }

        public TimeSpan RefreshBuffer { get; set; }

        public IdentityClientOptions()
        {
            AuthorityHost = DefaultAuthorityHost;
            RefreshBuffer = DefaultRefreshBuffer;
        }
    }
}

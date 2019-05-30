// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;

namespace Azure.Security.KeyVault.Keys
{
    public class KeyClientOptions : HttpClientOptions
    {
        public RetryPolicy RetryPolicy { get; set; }

        public KeyClientOptions()
        {
            RetryPolicy = new ExponentialRetryPolicy()
            {
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }
}

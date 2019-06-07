// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Security.KeyVault.Secrets
{
    public class SecretClientOptions : HttpClientOptions
    {
        public RetryPolicy RetryPolicy { get; set; }

        public SecretClientOptions()
        {
            RetryPolicy = new RetryPolicy()
            {
                Mode = RetryMode.Exponential,
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }
}

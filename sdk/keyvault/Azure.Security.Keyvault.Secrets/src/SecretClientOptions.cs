using System;
using System.Configuration;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Security.KeyVault.Secrets
{
    public class SecretClientOptions : HttpClientOptions
    {
        public ExponentialRetryOptions Retry { get; } = new ExponentialRetryOptions()
        {
            Delay = TimeSpan.FromMilliseconds(800),
            MaxRetries = 3
        };
    }
}

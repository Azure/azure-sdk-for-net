using System;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Security.KeyVault.Secrets
{
    public class SecretClientOptions : HttpClientOptions
    {
        public RetryPolicy RetryPolicy { get; set; }

        public HttpPipelinePolicy LoggingPolicy { get; set; }

        public SecretClientOptions()
        {
            LoggingPolicy = Core.Pipeline.Policies.LoggingPolicy.Shared;
            RetryPolicy = new ExponentialRetryPolicy()
            {
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }
}

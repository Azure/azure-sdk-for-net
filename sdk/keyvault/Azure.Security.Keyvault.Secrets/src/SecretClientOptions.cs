using System;
using System.Configuration;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.Security.KeyVault.Secrets
{
    public class SecretClientOptions : HttpClientOptions
    {
        public static string AuthenticationPolicy { get; } = "Authentication";

        public static string BufferResponsePolicy { get; } = "BufferResponse";

        public ExponentialRetryOptions Retry { get; } = new ExponentialRetryOptions()
        {
            Delay = TimeSpan.FromMilliseconds(800),
            MaxRetries = 3
        };
    }
}

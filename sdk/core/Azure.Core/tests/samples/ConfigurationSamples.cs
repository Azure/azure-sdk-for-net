// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class ConfigurationSamples
    {
        [Test]
        public void ConfigurationHelloWorld()
        {
            #region Snippet:ConfigurationHelloWorld

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxRetries = 10,
                    Mode = RetryMode.Fixed
                },
                Diagnostics =
                {
                    IsLoggingContentEnabled = true,
                    ApplicationId = "myApplicationId"
                }
            };

            SecretClient client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential(), options);
            #endregion
        }

        [Test]
        public void RetryOptions()
        {
            #region Snippet:RetryOptions

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay = TimeSpan.FromSeconds(2),
                    MaxRetries = 10,
                    Mode = RetryMode.Fixed
                }
            };

            #endregion
        }

        [Test]
        public void SettingHttpClient()
        {
            #region Snippet:SettingHttpClient

            using HttpClient client = new HttpClient();

            SecretClientOptions options = new SecretClientOptions
            {
                Transport = new HttpClientTransport(client)
            };

            #endregion
        }

        [Test]
        public void SetPollyRetryPolicy()
        {
            #region Snippet:SetPollyRetryPolicy
            SecretClientOptions options = new SecretClientOptions()
            {
                RetryPolicy = new PollyPolicy()
            };
            #endregion
        }

        [Test]
        public void SetGlobalTimeoutRetryPolicy()
        {
            #region Snippet:SetGlobalTimeoutRetryPolicy

            var delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromSeconds(2));
            SecretClientOptions options = new SecretClientOptions()
            {
                RetryPolicy = new GlobalTimeoutRetryPolicy(maxRetries: 4, delayStrategy: delay, timeout: TimeSpan.FromSeconds(30))
            };
            #endregion
        }

        [Test]
        public void CustomizedDelayStrategy()
        {
            #region Snippet:CustomizedDelay
            SecretClientOptions options = new SecretClientOptions()
            {
                RetryPolicy = new RetryPolicy(delayStrategy: new SequentialDelayStrategy())
            };
            #endregion
        }

        #region Snippet:SequentialDelayStrategy
        public class SequentialDelayStrategy : DelayStrategy
        {
            private static readonly TimeSpan[] PollingSequence = new TimeSpan[]
            {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(8),
                TimeSpan.FromSeconds(16),
                TimeSpan.FromSeconds(32)
            };
            private static readonly TimeSpan MaxDelay = PollingSequence[PollingSequence.Length - 1];

            protected override TimeSpan GetNextDelayCore(Response response, int retryNumber)
            {
                int index = retryNumber - 1;
                return index >= PollingSequence.Length ? MaxDelay : PollingSequence[index];
            }
        }
        #endregion
    }
}

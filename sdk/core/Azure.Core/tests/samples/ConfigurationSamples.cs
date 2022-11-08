// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
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
        public void HttpClientProxyConfiguration()
        {
            #region Snippet:HttpClientProxyConfiguration

            using HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(new Uri("http://example.com"))
            };

            SecretClientOptions options = new SecretClientOptions
            {
                Transport = new HttpClientTransport(handler)
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
            var retryOptions = new RetryOptions
            {
                Delay = TimeSpan.FromSeconds(2),
                MaxRetries = 10,
                Mode = RetryMode.Fixed
            };
            SecretClientOptions options = new SecretClientOptions()
            {
                RetryPolicy = new GlobalTimeoutRetryPolicy(retryOptions, timeout: TimeSpan.FromSeconds(30))
            };
            #endregion
        }
    }
}

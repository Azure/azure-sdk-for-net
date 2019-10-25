// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Core.Samples
{
    public class TransportSamples
    {
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

            using HttpClient client = new HttpClient(
                new HttpClientHandler()
                {
                    Proxy = new WebProxy(new Uri("http://example.com"))
                });

            SecretClientOptions options = new SecretClientOptions
            {
                Transport = new HttpClientTransport(client)
            };

            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class ClientOptionsTests
    {
#if NETCOREAPP
        [Test]
        public void DefaultTransportIsHttpClientTransport()
        {
            var options = new TestClientOptions();

            Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
        }
#else
        [Test]
        public void DefaultTransportIsHttpWebRequestTransport()
        {
            var options = new TestClientOptions();

            Assert.IsInstanceOf<HttpWebRequestTransport>(options.Transport);
        }

        [Test]
        public void DefaultTransportIsHttpClientTransportIfEnvVarSet()
        {
            string oldValue = Environment.GetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT");

            try
            {
                Environment.SetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT", "true");

                var options = new TestClientOptions();

                Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
            }
            finally
            {
                Environment.SetEnvironmentVariable("AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT", oldValue);
            }
        }

        [Test]
        public void DefaultTransportIsHttpClientTransportIfSwitchIsSet()
        {
            AppContext.TryGetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", out bool oldSwitch);

            try
            {
                AppContext.SetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", true);

                var options = new TestClientOptions();

                Assert.IsInstanceOf<HttpClientTransport>(options.Transport);
            }
            finally
            {
                AppContext.SetSwitch("Azure.Core.Pipeline.DisableHttpWebRequestTransport", oldSwitch);
            }
        }

#endif

        private class TestClientOptions : ClientOptions
        {
        }
    }
}
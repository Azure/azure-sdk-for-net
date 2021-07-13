// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class WebPubSubPolicyTests
    {
        [Test]
        public void ReverseProxyEndpointRedirection()
        {
            var mockResponse = new MockResponse(202);
            var transport = new MockTransport(mockResponse);

            var wpsEndpoint = "https://wps.contoso.com/";
            var apimEndpoint = "https://apim.contoso.com/";
            var credentail = new AzureKeyCredential("abcdabcdabcdabcdabcdabcdabcdabcd");

            var options = new WebPubSubServiceClientOptions();
            options.Transport = transport;
            options.ReverseProxyEndpoint = new Uri(apimEndpoint);

            var client = new WebPubSubServiceClient(new Uri(wpsEndpoint), "test_hub", credentail, options);

            var response = client.SendToAll("Hello World!");
            Assert.AreEqual(202, response.Status);

            var requestUri = transport.SingleRequest.Uri.ToUri();
            Assert.AreEqual(new Uri(apimEndpoint).Host, requestUri.Host);
        }
    }
}

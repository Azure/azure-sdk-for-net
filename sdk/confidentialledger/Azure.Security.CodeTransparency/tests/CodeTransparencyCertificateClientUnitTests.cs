// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyCertificateClientUnitTests: ClientTestBase
    {
        public CodeTransparencyCertificateClientUnitTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetServiceIdentityAsync_calls_api_once_and_uses_cache()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent("""
            {
                "ledgerTlsCertificate": ""
            }
            """);
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com",
                CacheTTLSeconds = 1
            };
            CodeTransparencyCertificateClient client = options.CreateCertificateClient();
            ServiceIdentityResult responseFirst = await client.GetServiceIdentityAsync("serviceName");
            ServiceIdentityResult responseSecond = await client.GetServiceIdentityAsync("serviceName");
            ServiceIdentityResult responseThird = await client.GetServiceIdentityAsync("serviceName");

            Assert.AreEqual(1, mockTransport.Requests.Count, "called only once");
            Assert.AreEqual("https://foo.bar.com/ledgerIdentity/serviceName", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(responseFirst.CreatedAt, responseSecond.CreatedAt);
            Assert.AreEqual(responseFirst.CreatedAt, responseThird.CreatedAt);
        }

        [Test]
        public async Task GetServiceIdentityAsync_response_converts_to_cert()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent("""
            {
                "ledgerTlsCertificate": "-----BEGIN CERTIFICATE-----\nMIIBvjCCAUSgAwIBAgIRALIcCHAQ8TpbFgvuNThTIFkwCgYIKoZIzj0EAwMwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjQwMTAzMDg1NDM2WhcNMjQwNDAyMDg1\nNDM1WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazB2MBAGByqGSM49AgEGBSuBBAAi\nA2IABFK177XlxO+GvJ91xjC98icJRKJbUIOSffHYEWAKojxvEa7EV1eVUINye0tU\nZJVVI5Nw2Y7Gbi7cm89Njnvz/uYUHBp/di3Rk+R4kupHEH6XErTMN93CAR4lIBOY\ndF7JpqNWMFQwEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU4px9yVX1Ru3W\nefhlw88K2zmyFQEwHwYDVR0jBBgwFoAU4px9yVX1Ru3Wefhlw88K2zmyFQEwCgYI\nKoZIzj0EAwMDaAAwZQIwG20Zjw5WPVoW6jsIchwSnfhniJNr0xF8hJJKUXIfyEDo\nnPewSdWnE4RubOm/ctMYAjEAlvwpdzSDFg57beLfq0bhaznxGOBpYQXl+q1uzm/S\nPup20CFNsp8G8m7w076DGJEA\n-----END CERTIFICATE-----\n",
                "ledgerId": "cts-canary"
            }
            """);
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport
            };
            CodeTransparencyCertificateClient client = options.CreateCertificateClient();
            ServiceIdentityResult responseFirst = await client.GetServiceIdentityAsync("serviceName");
            Assert.AreEqual("https://identity.confidential-ledger.core.azure.com/ledgerIdentity/serviceName", mockTransport.Requests[0].Uri.ToString());
            Assert.NotNull(responseFirst.GetCertificate(), "can parse the PEM cert");
        }
    }
}
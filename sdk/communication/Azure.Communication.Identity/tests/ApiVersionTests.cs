// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Identity.Tests
{
    public class ApiVersionTests
    {
        [TestCase(null, "2026-09-23")]
        [TestCase(CommunicationIdentityClientOptions.ServiceVersion.V2025_03_02_PREVIEW, "2025-03-02-preview")]
        [TestCase(CommunicationIdentityClientOptions.ServiceVersion.V2026_09_23, "2026-09-23")]
        public void ClientSendsExpectedApiVersion(
            CommunicationIdentityClientOptions.ServiceVersion? version,
            string expectedApiVersion)
        {
            var requests = new List<Request>();
            var response = new MockResponse(201);
            response.SetContent("{\"identity\":{\"id\":\"8:acs:test\"}}");
            var options = version.HasValue
                ? new CommunicationIdentityClientOptions(version.Value)
                : new CommunicationIdentityClientOptions();
            options.Transport = new MockTransport(request =>
            {
                requests.Add(request);
                return response;
            });

            var client = new CommunicationIdentityClient(
                new Uri("https://contoso.communication.azure.com"),
                new AzureKeyCredential(Convert.ToBase64String(Encoding.UTF8.GetBytes("test-key"))),
                options);

            client.CreateUser();

            Assert.That(requests, Has.Count.EqualTo(1));
            Assert.That(requests[0].Uri.Query, Does.Contain($"api-version={expectedApiVersion}"));
        }
    }
}

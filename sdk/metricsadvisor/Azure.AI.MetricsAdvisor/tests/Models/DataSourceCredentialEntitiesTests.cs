// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataSourceCredentialEntitiesTests : MockClientTestBase
    {
        private static object[] CredentialEntityTestCases =
        {
            new object[] { new ServicePrincipalCredentialEntity("mock", "mock", "secret", "mock"), "\"clientSecret\":\"secret\"" }
        };

        public DataSourceCredentialEntitiesTests(bool isAsync) : base(isAsync)
        {
        }

        private string CredentialEntityResponseContent => @"
        {
            ""dataSourceCredentialType"": ""ServicePrincipal"",
            ""parameters"": {
                ""clientId"": """",
                ""tenantId"": """"
            }
        }
        ";

        [Test]
        [TestCaseSource(nameof(CredentialEntityTestCases))]
        public async Task DataSourceCredentialEntitySendsSecretDuringCreation(DataSourceCredentialEntity credentialEntity, string expectedSubstring)
        {
            MockResponse createResponse = new MockResponse(201);
            createResponse.AddHeader(new HttpHeader("Location", $"https://fakeresource.cognitiveservices.azure.com/metricsadvisor/v1.0/credentials/{FakeGuid}"));

            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(CredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(createResponse, getResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            await adminClient.CreateCredentialEntityAsync(credentialEntity);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring(expectedSubstring));
        }

        private string ReadContent(Request request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private MetricsAdvisorAdministrationClient CreateInstrumentedAdministrationClient(MockTransport transport)
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");
            var options = new MetricsAdvisorClientsOptions() { Transport = transport };

            return InstrumentClient(new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential, options));
        }
    }
}

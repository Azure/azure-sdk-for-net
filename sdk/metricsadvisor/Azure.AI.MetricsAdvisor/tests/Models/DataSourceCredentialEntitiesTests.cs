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
        private static Uri FakeUri = new Uri("https://fakeuri.com");

        private static object[] DataSourceCredentialEntityTestCases =
        {
            new object[] { new DataSourceDataLakeGen2SharedKey("mock", "secret"), "\"accountKey\":\"secret\"" },
            new object[] { new DataSourceServicePrincipal("mock", "mock", "secret", "mock"), "\"clientSecret\":\"secret\"" },
            new object[] { new DataSourceServicePrincipalInKeyVault("mock", FakeUri, "mock", "secret", "mock", "mock", "mock"), "\"keyVaultClientSecret\":\"secret\"" },
            new object[] { new DataSourceSqlConnectionString("mock", "secret"), "\"connectionString\":\"secret\"" },
        };

        public DataSourceCredentialEntitiesTests(bool isAsync) : base(isAsync)
        {
        }

        private string DataSourceCredentialEntityResponseContent => @"
        {
            ""dataSourceCredentialType"": ""ServicePrincipal"",
            ""parameters"": {
                ""clientId"": """",
                ""tenantId"": """"
            }
        }
        ";

        [Test]
        [TestCaseSource(nameof(DataSourceCredentialEntityTestCases))]
        public async Task DataSourceCredentialEntitySendsSecretDuringCreation(DataSourceCredentialEntity credential, string expectedSubstring)
        {
            MockResponse createResponse = new MockResponse(201);
            createResponse.AddHeader(new HttpHeader("Location", $"https://fakeresource.cognitiveservices.azure.com/metricsadvisor/v1.0/credentials/{FakeGuid}"));

            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(createResponse, getResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            await adminClient.CreateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring(expectedSubstring));
        }

        [Test]
        public async Task DataLakeGen2SharedKeyDataSourceCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new DataSourceDataLakeGen2SharedKey(DataSourceCredentialType.DataLakeGen2SharedKey, FakeGuid,
                default, default, new DataLakeGen2SharedKeyParam());

            Assert.That(credential.AccountKey, Is.Null);

            credential.UpdateAccountKey("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring("\"accountKey\":\"secret\""));
        }

        [Test]
        public async Task ServicePrincipalDataSourceCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new DataSourceServicePrincipal(DataSourceCredentialType.ServicePrincipal, FakeGuid,
                default, default, new ServicePrincipalParam("mock", "mock"));

            Assert.That(credential.ClientSecret, Is.Null);

            credential.UpdateClientSecret("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring("\"clientSecret\":\"secret\""));
        }

        [Test]
        public async Task ServicePrincipalInKeyVaultDataSourceCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new DataSourceServicePrincipalInKeyVault(DataSourceCredentialType.ServicePrincipal, FakeGuid,
                default, default, new ServicePrincipalInKVParam(FakeUri.AbsoluteUri, "mock", "mock", "mock", "mock"));

            Assert.That(credential.KeyVaultClientSecret, Is.Null);

            credential.UpdateKeyVaultClientSecret("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring("\"keyVaultClientSecret\":\"secret\""));
        }

        [Test]
        public async Task SqlConnectionStringDataSourceCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new DataSourceSqlConnectionString(DataSourceCredentialType.AzureSQLConnectionString, FakeGuid,
                default, default, new AzureSQLConnectionStringParam());

            Assert.That(credential.ConnectionString, Is.Null);

            credential.UpdateConnectionString("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, Contains.Substring("\"connectionString\":\"secret\""));
        }

        private string ReadContent(Request request)
        {
            using MemoryStream stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

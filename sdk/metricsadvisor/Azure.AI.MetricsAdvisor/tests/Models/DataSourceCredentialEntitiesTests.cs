// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            new object[] { new DataLakeSharedKeyCredentialEntity("mock", "secret"), "\"accountKey\":\"secret\"" },
            new object[] { new ServicePrincipalCredentialEntity("mock", "mock", "secret", "mock"), "\"clientSecret\":\"secret\"" },
            new object[] { new ServicePrincipalInKeyVaultCredentialEntity("mock", FakeUri, "mock", "secret", "mock", "mock", "mock"), "\"keyVaultClientSecret\":\"secret\"" },
            new object[] { new SqlConnectionStringCredentialEntity("mock", "secret"), "\"connectionString\":\"secret\"" },
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
        public async Task DataLakeSharedKeyCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new DataLakeSharedKeyCredentialEntity(DataSourceCredentialType.DataLakeGen2SharedKey, FakeGuid,
                default, default, new DataLakeGen2SharedKeyParam());

            Assert.That(credential.AccountKey, Is.Null);

            credential.UpdateAccountKey("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, ContainsJsonString("accountKey", "secret"));
        }

        [Test]
        public async Task ServicePrincipalCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new ServicePrincipalCredentialEntity(DataSourceCredentialType.ServicePrincipal, FakeGuid,
                default, default, new ServicePrincipalParam("mock", "mock"));

            Assert.That(credential.ClientSecret, Is.Null);

            credential.UpdateClientSecret("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, ContainsJsonString("clientSecret", "secret"));
        }

        [Test]
        public async Task ServicePrincipalInKeyVaultCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new ServicePrincipalInKeyVaultCredentialEntity(DataSourceCredentialType.ServicePrincipal, FakeGuid,
                default, default, new ServicePrincipalInKVParam(FakeUri.AbsoluteUri, "mock", "mock", "mock", "mock"));

            Assert.That(credential.KeyVaultClientSecret, Is.Null);

            credential.UpdateKeyVaultClientSecret("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, ContainsJsonString("keyVaultClientSecret", "secret"));
        }

        [Test]
        public async Task SqlConnectionStringCredentialEntitySendsSecretDuringUpdate()
        {
            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(DataSourceCredentialEntityResponseContent);

            MockTransport mockTransport = new MockTransport(updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);

            var credential = new SqlConnectionStringCredentialEntity(DataSourceCredentialType.AzureSQLConnectionString, FakeGuid,
                default, default, new AzureSQLConnectionStringParam());

            Assert.That(credential.ConnectionString, Is.Null);

            credential.UpdateConnectionString("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, ContainsJsonString("connectionString", "secret"));
        }
    }
}

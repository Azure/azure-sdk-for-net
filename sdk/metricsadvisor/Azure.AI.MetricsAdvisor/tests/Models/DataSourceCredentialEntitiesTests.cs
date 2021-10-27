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

        private string UnknownCredentialContent => $@"
        {{
            ""dataSourceCredentialType"": ""unknownType"",
            ""dataSourceCredentialId"": ""{FakeGuid}"",
            ""dataSourceCredentialName"": ""unknownCredentialName"",
            ""dataSourceCredentialDescription"": ""unknown credential description""
        }}
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

            var credential = new DataLakeSharedKeyCredentialEntity(DataSourceCredentialKind.DataLakeSharedKey, FakeGuid,
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

            var credential = new ServicePrincipalCredentialEntity(DataSourceCredentialKind.ServicePrincipal, FakeGuid,
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

            var credential = new ServicePrincipalInKeyVaultCredentialEntity(DataSourceCredentialKind.ServicePrincipal, FakeGuid,
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

            var credential = new SqlConnectionStringCredentialEntity(DataSourceCredentialKind.SqlConnectionString, FakeGuid,
                default, default, new AzureSQLConnectionStringParam());

            Assert.That(credential.ConnectionString, Is.Null);

            credential.UpdateConnectionString("secret");

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.First();
            string content = ReadContent(request);

            Assert.That(content, ContainsJsonString("connectionString", "secret"));
        }

        [Test]
        public async Task DataSourceCredentialEntityGetsUnknownCredential()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownCredentialContent);

            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(getResponse);
            DataSourceCredentialEntity credential = await adminClient.GetDataSourceCredentialAsync(FakeGuid);

            Assert.That(credential.Id, Is.EqualTo(FakeGuid));
            Assert.That(credential.Name, Is.EqualTo("unknownCredentialName"));
            Assert.That(credential.Description, Is.EqualTo("unknown credential description"));
        }

        [Test]
        public async Task DataSourceCredentialEntityUpdatesUnknownCredential()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownCredentialContent);

            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(UnknownCredentialContent);

            MockTransport mockTransport = new MockTransport(getResponse, updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);
            DataSourceCredentialEntity credential = await adminClient.GetDataSourceCredentialAsync(FakeGuid);

            credential.Name = "newCredentialName";
            credential.Description = "new description";

            await adminClient.UpdateDataSourceCredentialAsync(credential);

            MockRequest request = mockTransport.Requests.Last();
            string content = ReadContent(request);

            Assert.That(request.Uri.Path, Contains.Substring(FakeGuid));
            Assert.That(content, ContainsJsonString("dataSourceCredentialName", "newCredentialName"));
            Assert.That(content, ContainsJsonString("dataSourceCredentialType", "unknownType"));
            Assert.That(content, ContainsJsonString("dataSourceCredentialDescription", "new description"));
        }
    }
}

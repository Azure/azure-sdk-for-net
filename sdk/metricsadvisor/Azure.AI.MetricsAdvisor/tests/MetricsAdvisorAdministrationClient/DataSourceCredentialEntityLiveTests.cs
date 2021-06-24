// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataSourceCredentialEntityLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string ClientId = "clientId";
        private const string TenantId = "tenantId";
        private const string Endpoint = "https://fakeuri.com/";
        private const string ClientIdSecretName = "clientIdSecretName";
        private const string ClientSecretSecretName = "clientSecretSecretName";

        public DataSourceCredentialEntityLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(nameof(DataSourceDataLakeGen2SharedKey))]
        [TestCase(nameof(DataSourceServicePrincipal))]
        [TestCase(nameof(DataSourceServicePrincipalInKeyVault))]
        [TestCase(nameof(DataSourceSqlConnectionString))]
        public async Task CreateAndGetDataSourceCredential(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            DataSourceCredentialEntity credentialToCreate = GetDataSourceCredentialEntityTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialToCreate);
            DataSourceCredentialEntity createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Id, Is.Not.Empty.And.Not.Null);
            Assert.That(createdCredential.Name, Is.EqualTo(credentialName));
            Assert.That(createdCredential.Description, Is.Empty);

            ValidateTestCaseDataSourceCredentialEntity(createdCredential);
        }

        [RecordedTest]
        [TestCase(nameof(DataSourceDataLakeGen2SharedKey))]
        [TestCase(nameof(DataSourceServicePrincipal))]
        [TestCase(nameof(DataSourceServicePrincipalInKeyVault))]
        [TestCase(nameof(DataSourceSqlConnectionString))]
        public async Task CreateAndGetDataSourceCredentialWithDescription(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This is a description";

            DataSourceCredentialEntity credentialToCreate = GetDataSourceCredentialEntityTestCase(credentialTypeName, credentialName);

            credentialToCreate.Description = expectedDescription;

            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialToCreate);
            DataSourceCredentialEntity createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        [TestCase(nameof(DataSourceDataLakeGen2SharedKey))]
        [TestCase(nameof(DataSourceServicePrincipal))]
        [TestCase(nameof(DataSourceServicePrincipalInKeyVault))]
        [TestCase(nameof(DataSourceSqlConnectionString))]
        public async Task UpdateDataSourceCredentialCommonProperties(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredentialEntity credentialToCreate = GetDataSourceCredentialEntityTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialToCreate);
            DataSourceCredentialEntity credentialToUpdate = disposableCredential.Credential;

            string expectedName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This description was created by a .NET test";

            credentialToUpdate.Name = expectedName;
            credentialToUpdate.Description = expectedDescription;

            DataSourceCredentialEntity updatedCredential = await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate);

            Assert.That(updatedCredential.Id, Is.EqualTo(credentialToUpdate.Id));
            Assert.That(updatedCredential.Name, Is.EqualTo(expectedName));
            Assert.That(updatedCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        public async Task UpdateServicePrincipalDataSourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredentialEntity credentialToCreate = new DataSourceServicePrincipal(credentialName, "mock", "mock", "mock");

            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialToCreate);
            var credentialToUpdate = disposableCredential.Credential as DataSourceServicePrincipal;

            credentialToUpdate.ClientId = ClientId;
            credentialToUpdate.TenantId = TenantId;

            var updatedCredential = (await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate)).Value as DataSourceServicePrincipal;

            Assert.That(updatedCredential.ClientId, Is.EqualTo(ClientId));
            Assert.That(updatedCredential.TenantId, Is.EqualTo(TenantId));
        }

        [RecordedTest]
        public async Task UpdateServicePrincipalInKeyVaultDataSourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredentialEntity credentialToCreate = new DataSourceServicePrincipalInKeyVault(credentialName, new Uri("https://mock.com/"), "mock", "mock", "mock", "mock", "mock");

            await using var disposableCredential = await DisposableDataSourceCredentialEntity.CreateDataSourceCredentialEntityAsync(adminClient, credentialToCreate);
            var credentialToUpdate = disposableCredential.Credential as DataSourceServicePrincipalInKeyVault;

            credentialToUpdate.Endpoint = new Uri(Endpoint);
            credentialToUpdate.KeyVaultClientId = ClientId;
            credentialToUpdate.TenantId = TenantId;
            credentialToUpdate.SecretNameForClientId = ClientIdSecretName;
            credentialToUpdate.SecretNameForClientSecret = ClientSecretSecretName;

            var updatedCredential = (await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate)).Value as DataSourceServicePrincipalInKeyVault;

            Assert.That(updatedCredential.Endpoint.AbsoluteUri, Is.EqualTo(Endpoint));
            Assert.That(updatedCredential.KeyVaultClientId, Is.EqualTo(ClientId));
            Assert.That(updatedCredential.TenantId, Is.EqualTo(TenantId));
            Assert.That(updatedCredential.SecretNameForClientId, Is.EqualTo(ClientIdSecretName));
            Assert.That(updatedCredential.SecretNameForClientSecret, Is.EqualTo(ClientSecretSecretName));
        }

        [RecordedTest]
        public async Task GetDataSourceCredentials()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialCount = 0;

            await foreach (DataSourceCredentialEntity credential in adminClient.GetDataSourceCredentialsAsync())
            {
                Assert.That(credential.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Description, Is.Not.Null);

                ValidateGenericDataSourceCredentialEntity(credential);

                if (++credentialCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(credentialCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task DeleteDataSourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            var credentialToCreate = new DataSourceServicePrincipal(credentialName, "clientId", "clientSecret", "tenantId");

            string credentialId = null;

            try
            {
                DataSourceCredentialEntity createdCredential = await adminClient.CreateDataSourceCredentialAsync(credentialToCreate);
                credentialId = createdCredential.Id;

                Assert.That(credentialId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (credentialId != null)
                {
                    await adminClient.DeleteDataSourceCredentialAsync(credentialId);

                    var errorCause = "credentialId is invalid";
                    Assert.That(async () => await adminClient.GetDataSourceCredentialAsync(credentialId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private void ValidateGenericDataSourceCredentialEntity(DataSourceCredentialEntity credential)
        {
            if (credential is DataSourceServicePrincipal spCredential)
            {
                Assert.That(spCredential.ClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(spCredential.TenantId, Is.Not.Null.And.Not.Empty);
            }
            else if (credential is DataSourceServicePrincipalInKeyVault kvCredential)
            {
                Assert.That(kvCredential.Endpoint.AbsoluteUri, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.KeyVaultClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.TenantId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.SecretNameForClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.SecretNameForClientSecret, Is.Not.Null.And.Not.Empty);
            }
            else if (credential is DataSourceDataLakeGen2SharedKey ||
                     credential is DataSourceSqlConnectionString)
            {
                // There's nothing to validate since these credential types do not have public properties.
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private void ValidateTestCaseDataSourceCredentialEntity(DataSourceCredentialEntity credential)
        {
            if (credential is DataSourceServicePrincipal spCredential)
            {
                Assert.That(spCredential.ClientId, Is.EqualTo(ClientId));
                Assert.That(spCredential.TenantId, Is.EqualTo(TenantId));
            }
            else if (credential is DataSourceServicePrincipalInKeyVault kvCredential)
            {
                Assert.That(kvCredential.Endpoint.AbsoluteUri, Is.EqualTo(Endpoint));
                Assert.That(kvCredential.KeyVaultClientId, Is.EqualTo(ClientId));
                Assert.That(kvCredential.TenantId, Is.EqualTo(TenantId));
                Assert.That(kvCredential.SecretNameForClientId, Is.EqualTo(ClientIdSecretName));
                Assert.That(kvCredential.SecretNameForClientSecret, Is.EqualTo(ClientSecretSecretName));
            }
            else if (credential is DataSourceDataLakeGen2SharedKey ||
                     credential is DataSourceSqlConnectionString)
            {
                // There's nothing to validate since these credential types do not have public properties.
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private static DataSourceCredentialEntity GetDataSourceCredentialEntityTestCase(string credentialTypeName, string credentialName) => credentialTypeName switch
        {
            nameof(DataSourceDataLakeGen2SharedKey) => new DataSourceDataLakeGen2SharedKey(credentialName, "accountKey"),
            nameof(DataSourceServicePrincipal) => new DataSourceServicePrincipal(credentialName, ClientId, "clientSecret", TenantId),
            nameof(DataSourceServicePrincipalInKeyVault) => new DataSourceServicePrincipalInKeyVault(credentialName, new Uri(Endpoint), ClientId, "clientSecret", TenantId, ClientIdSecretName, ClientSecretSecretName),
            nameof(DataSourceSqlConnectionString) => new DataSourceSqlConnectionString(credentialName, "connectionString"),
            _ => throw new ArgumentOutOfRangeException($"Unknown credential type: {credentialTypeName}")
        };
    }
}

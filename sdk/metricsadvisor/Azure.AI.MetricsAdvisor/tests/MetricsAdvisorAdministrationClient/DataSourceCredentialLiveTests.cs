// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataSourceCredentialLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string ClientId = "clientId";
        private const string TenantId = "tenantId";
        private const string Endpoint = "https://fakeuri.com/";
        private const string ClientIdSecretName = "clientIdSecretName";
        private const string ClientSecretSecretName = "clientSecretSecretName";

        public DataSourceCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeGen2SharedKeyDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalInKeyVaultDataSourceCredential))]
        [TestCase(nameof(SqlConnectionStringDataSourceCredential))]
        public async Task CreateAndGetDataSourceCredential(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            DataSourceCredential credentialToCreate = GetDataSourceCredentialTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDataSourceCredential.CreateDataSourceCredentialAsync(adminClient, credentialToCreate);
            DataSourceCredential createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Id, Is.Not.Empty.And.Not.Null);
            Assert.That(createdCredential.Name, Is.EqualTo(credentialName));
            Assert.That(createdCredential.Description, Is.Empty);

            ValidateTestCaseDataSourceCredential(createdCredential);
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeGen2SharedKeyDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalInKeyVaultDataSourceCredential))]
        [TestCase(nameof(SqlConnectionStringDataSourceCredential))]
        public async Task CreateAndGetDataSourceCredentialWithDescription(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This is a description";

            DataSourceCredential credentialToCreate = GetDataSourceCredentialTestCase(credentialTypeName, credentialName);

            credentialToCreate.Description = expectedDescription;

            await using var disposableCredential = await DisposableDataSourceCredential.CreateDataSourceCredentialAsync(adminClient, credentialToCreate);
            DataSourceCredential createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeGen2SharedKeyDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalDataSourceCredential))]
        [TestCase(nameof(ServicePrincipalInKeyVaultDataSourceCredential))]
        [TestCase(nameof(SqlConnectionStringDataSourceCredential))]
        public async Task UpdateDataSourceCredentialCommonProperties(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredential credentialToCreate = GetDataSourceCredentialTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDataSourceCredential.CreateDataSourceCredentialAsync(adminClient, credentialToCreate);
            DataSourceCredential credentialToUpdate = disposableCredential.Credential;

            string expectedName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This description was created by a .NET test";

            credentialToUpdate.Name = expectedName;
            credentialToUpdate.Description = expectedDescription;

            DataSourceCredential updatedCredential = await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate);

            Assert.That(updatedCredential.Id, Is.EqualTo(credentialToUpdate.Id));
            Assert.That(updatedCredential.Name, Is.EqualTo(expectedName));
            Assert.That(updatedCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        public async Task UpdateServicePrincipalDataSourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredential credentialToCreate = new ServicePrincipalDataSourceCredential(credentialName, "mock", "mock", "mock");

            await using var disposableCredential = await DisposableDataSourceCredential.CreateDataSourceCredentialAsync(adminClient, credentialToCreate);
            var credentialToUpdate = disposableCredential.Credential as ServicePrincipalDataSourceCredential;

            credentialToUpdate.ClientId = ClientId;
            credentialToUpdate.TenantId = TenantId;

            var updatedCredential = (await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate)).Value as ServicePrincipalDataSourceCredential;

            Assert.That(updatedCredential.ClientId, Is.EqualTo(ClientId));
            Assert.That(updatedCredential.TenantId, Is.EqualTo(TenantId));
        }

        [RecordedTest]
        public async Task UpdateServicePrincipalInKeyVaultDataSourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DataSourceCredential credentialToCreate = new ServicePrincipalInKeyVaultDataSourceCredential(credentialName, new Uri("https://mock.com/"), "mock", "mock", "mock", "mock", "mock");

            await using var disposableCredential = await DisposableDataSourceCredential.CreateDataSourceCredentialAsync(adminClient, credentialToCreate);
            var credentialToUpdate = disposableCredential.Credential as ServicePrincipalInKeyVaultDataSourceCredential;

            credentialToUpdate.Endpoint = new Uri(Endpoint);
            credentialToUpdate.KeyVaultClientId = ClientId;
            credentialToUpdate.TenantId = TenantId;
            credentialToUpdate.SecretNameForClientId = ClientIdSecretName;
            credentialToUpdate.SecretNameForClientSecret = ClientSecretSecretName;

            var updatedCredential = (await adminClient.UpdateDataSourceCredentialAsync(credentialToUpdate)).Value as ServicePrincipalInKeyVaultDataSourceCredential;

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

            await foreach (DataSourceCredential credential in adminClient.GetDataSourceCredentialsAsync())
            {
                Assert.That(credential.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Description, Is.Not.Null);

                ValidateGenericDataSourceCredential(credential);

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
            var credentialToCreate = new ServicePrincipalDataSourceCredential(credentialName, "clientId", "clientSecret", "tenantId");

            string credentialId = null;

            try
            {
                DataSourceCredential createdCredential = await adminClient.CreateDataSourceCredentialAsync(credentialToCreate);
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

        private void ValidateGenericDataSourceCredential(DataSourceCredential credential)
        {
            if (credential is ServicePrincipalDataSourceCredential spCredential)
            {
                Assert.That(spCredential.ClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(spCredential.TenantId, Is.Not.Null.And.Not.Empty);
            }
            else if (credential is ServicePrincipalInKeyVaultDataSourceCredential kvCredential)
            {
                Assert.That(kvCredential.Endpoint.AbsoluteUri, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.KeyVaultClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.TenantId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.SecretNameForClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(kvCredential.SecretNameForClientSecret, Is.Not.Null.And.Not.Empty);
            }
            else if (credential is DataLakeGen2SharedKeyDataSourceCredential ||
                     credential is SqlConnectionStringDataSourceCredential)
            {
                // There's nothing to validate since these credential types do not have public properties.
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private void ValidateTestCaseDataSourceCredential(DataSourceCredential credential)
        {
            if (credential is ServicePrincipalDataSourceCredential spCredential)
            {
                Assert.That(spCredential.ClientId, Is.EqualTo(ClientId));
                Assert.That(spCredential.TenantId, Is.EqualTo(TenantId));
            }
            else if (credential is ServicePrincipalInKeyVaultDataSourceCredential kvCredential)
            {
                Assert.That(kvCredential.Endpoint.AbsoluteUri, Is.EqualTo(Endpoint));
                Assert.That(kvCredential.KeyVaultClientId, Is.EqualTo(ClientId));
                Assert.That(kvCredential.TenantId, Is.EqualTo(TenantId));
                Assert.That(kvCredential.SecretNameForClientId, Is.EqualTo(ClientIdSecretName));
                Assert.That(kvCredential.SecretNameForClientSecret, Is.EqualTo(ClientSecretSecretName));
            }
            else if (credential is DataLakeGen2SharedKeyDataSourceCredential ||
                     credential is SqlConnectionStringDataSourceCredential)
            {
                // There's nothing to validate since these credential types do not have public properties.
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private static DataSourceCredential GetDataSourceCredentialTestCase(string credentialTypeName, string credentialName) => credentialTypeName switch
        {
            nameof(DataLakeGen2SharedKeyDataSourceCredential) => new DataLakeGen2SharedKeyDataSourceCredential(credentialName, "accountKey"),
            nameof(ServicePrincipalDataSourceCredential) => new ServicePrincipalDataSourceCredential(credentialName, ClientId, "clientSecret", TenantId),
            nameof(ServicePrincipalInKeyVaultDataSourceCredential) => new ServicePrincipalInKeyVaultDataSourceCredential(credentialName, new Uri(Endpoint), ClientId, "clientSecret", TenantId, ClientIdSecretName, ClientSecretSecretName),
            nameof(SqlConnectionStringDataSourceCredential) => new SqlConnectionStringDataSourceCredential(credentialName, "connectionString"),
            _ => throw new ArgumentOutOfRangeException($"Unknown credential type: {credentialTypeName}")
        };
    }
}

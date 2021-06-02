// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DatasourceCredentialLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string ClientId = "clientId";
        private const string ClientSecret = "clientSecret";
        private const string TenantId = "tenantId";

        public DatasourceCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetServicePrincipalDatasourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            var credentialToCreate = new ServicePrincipalDatasourceCredential(credentialName, ClientId, ClientSecret, TenantId);

            await using var disposableCredential = await DisposableCredentialEntity.CreateCredentialEntityAsync(adminClient, credentialToCreate);

            DatasourceCredential createdCredential = await adminClient.GetDatasourceCredentialAsync(disposableCredential.Id);

            Assert.That(createdCredential.Id, Is.EqualTo(disposableCredential.Id));
            Assert.That(createdCredential.Name, Is.EqualTo(credentialName));
            Assert.That(createdCredential.Description, Is.Empty);

            ValidateServicePrincipalDatasourceCredential(createdCredential);
        }

        [RecordedTest]
        public async Task CreateAndGetDatasourceCredentialWithDescription()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This is a description";

            var credentialToCreate = new ServicePrincipalDatasourceCredential(credentialName, ClientId, ClientSecret, TenantId)
            {
                Description = expectedDescription
            };

            await using var disposableCredential = await DisposableCredentialEntity.CreateCredentialEntityAsync(adminClient, credentialToCreate);

            DatasourceCredential createdCredential = await adminClient.GetDatasourceCredentialAsync(disposableCredential.Id);

            Assert.That(createdCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        public async Task GetDatasourceCredentials()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialCount = 0;

            await foreach (DatasourceCredential credential in adminClient.GetDatasourceCredentialsAsync())
            {
                Assert.That(credential.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(credential.Description, Is.Not.Null);

                ValidateGenericDatasourceCredential(credential);

                if (++credentialCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(credentialCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task DeleteDatasourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            var credentialToCreate = new ServicePrincipalDatasourceCredential(credentialName, "clientId", "clientSecret", "tenantId");

            string credentialId = null;

            try
            {
                DatasourceCredential createdCredential = await adminClient.CreateDatasourceCredentialAsync(credentialToCreate);
                credentialId = createdCredential.Id;

                Assert.That(credentialId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (credentialId != null)
                {
                    await adminClient.DeleteDatasourceCredentialAsync(credentialId);

                    var errorCause = "credentialId is invalid";
                    Assert.That(async () => await adminClient.GetDatasourceCredentialAsync(credentialId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private void ValidateServicePrincipalDatasourceCredential(DatasourceCredential credential)
        {
            var servicePrincipalCredential = credential as ServicePrincipalDatasourceCredential;

            Assert.That(servicePrincipalCredential, Is.Not.Null);
            Assert.That(servicePrincipalCredential.ClientId, Is.EqualTo(ClientId));
            Assert.That(servicePrincipalCredential.TenantId, Is.EqualTo(TenantId));
        }

        private void ValidateGenericDatasourceCredential(DatasourceCredential credential)
        {
            if (credential is ServicePrincipalDatasourceCredential spCredential)
            {
                Assert.That(spCredential.ClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(spCredential.TenantId, Is.Not.Null.And.Not.Empty);
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class CredentialEntityLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string ClientId = "clientId";
        private const string ClientSecret = "clientSecret";
        private const string TenantId = "tenantId";

        public CredentialEntityLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetServicePrincipalCredentialEntity()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            var credentialToCreate = new ServicePrincipalCredentialEntity(credentialName, ClientId, ClientSecret, TenantId);

            await using var disposableCredential = await DisposableCredentialEntity.CreateCredentialEntityAsync(adminClient, credentialToCreate);

            DataSourceCredentialEntity createdCredential = await adminClient.GetCredentialEntityAsync(disposableCredential.Id);

            Assert.That(createdCredential.Id, Is.EqualTo(disposableCredential.Id));
            Assert.That(createdCredential.Name, Is.EqualTo(credentialName));
            Assert.That(createdCredential.Description, Is.Empty);

            ValidateServicePrincipalCredentialEntity(createdCredential);
        }

        [RecordedTest]
        public async Task CreateAndGetCredentialEntityWithDescription()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This is a description";

            var credentialToCreate = new ServicePrincipalCredentialEntity(credentialName, ClientId, ClientSecret, TenantId)
            {
                Description = expectedDescription
            };

            await using var disposableCredential = await DisposableCredentialEntity.CreateCredentialEntityAsync(adminClient, credentialToCreate);

            DataSourceCredentialEntity createdCredential = await adminClient.GetCredentialEntityAsync(disposableCredential.Id);

            Assert.That(createdCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21466")]
        public async Task DeleteCredentialEntity()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credentialName = Recording.GenerateAlphaNumericId("credential");
            var credentialToCreate = new ServicePrincipalCredentialEntity(credentialName, "clientId", "clientSecret", "tenantId");

            string credentialId = null;

            try
            {
                DataSourceCredentialEntity createdCredential = await adminClient.CreateCredentialEntityAsync(credentialToCreate);
                credentialId = createdCredential.Id;

                Assert.That(credentialId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (credentialId != null)
                {
                    await adminClient.DeleteCredentialEntityAsync(credentialId);

                    var errorCause = "credentialUUID is invalid";
                    Assert.That(async () => await adminClient.GetCredentialEntityAsync(credentialId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private void ValidateServicePrincipalCredentialEntity(DataSourceCredentialEntity credentialEntity)
        {
            var servicePrincipalCredential = credentialEntity as ServicePrincipalCredentialEntity;

            Assert.That(servicePrincipalCredential, Is.Not.Null);
            Assert.That(servicePrincipalCredential.ClientId, Is.EqualTo(ClientId));
            Assert.That(servicePrincipalCredential.TenantId, Is.EqualTo(TenantId));
        }
    }
}

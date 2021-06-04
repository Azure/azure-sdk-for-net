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
    public class DatasourceCredentialLiveTests : MetricsAdvisorLiveTestBase
    {
        private const string ClientId = "clientId";
        private const string TenantId = "tenantId";

        public DatasourceCredentialLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(nameof(ServicePrincipalDatasourceCredential))]
        public async Task CreateAndGetDatasourceCredential(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            DatasourceCredential credentialToCreate = GetDatasourceCredentialTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDatasourceCredential.CreateDatasourceCredentialAsync(adminClient, credentialToCreate);
            DatasourceCredential createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Id, Is.Not.Empty.And.Not.Null);
            Assert.That(createdCredential.Name, Is.EqualTo(credentialName));
            Assert.That(createdCredential.Description, Is.Empty);

            ValidateTestCaseDatasourceCredential(createdCredential);
        }

        [RecordedTest]
        [TestCase(nameof(ServicePrincipalDatasourceCredential))]
        public async Task CreateAndGetDatasourceCredentialWithDescription(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This is a description";

            DatasourceCredential credentialToCreate = GetDatasourceCredentialTestCase(credentialTypeName, credentialName);

            credentialToCreate.Description = expectedDescription;

            await using var disposableCredential = await DisposableDatasourceCredential.CreateDatasourceCredentialAsync(adminClient, credentialToCreate);
            DatasourceCredential createdCredential = disposableCredential.Credential;

            Assert.That(createdCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        [TestCase(nameof(ServicePrincipalDatasourceCredential))]
        public async Task UpdateDatasourceCredentialCommonProperties(string credentialTypeName)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DatasourceCredential credentialToCreate = GetDatasourceCredentialTestCase(credentialTypeName, credentialName);

            await using var disposableCredential = await DisposableDatasourceCredential.CreateDatasourceCredentialAsync(adminClient, credentialToCreate);
            DatasourceCredential credentialToUpdate = disposableCredential.Credential;

            string expectedName = Recording.GenerateAlphaNumericId("credential");
            string expectedDescription = "This description was created by a .NET test";

            credentialToUpdate.Name = expectedName;
            credentialToUpdate.Description = expectedDescription;

            DatasourceCredential updatedCredential = await adminClient.UpdateDatasourceCredentialAsync(credentialToUpdate);

            Assert.That(updatedCredential.Name, Is.EqualTo(expectedName));
            Assert.That(updatedCredential.Description, Is.EqualTo(expectedDescription));
        }

        [RecordedTest]
        public async Task UpdateServicePrincipalDatasourceCredential()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string credentialName = Recording.GenerateAlphaNumericId("credential");

            DatasourceCredential credentialToCreate = new ServicePrincipalDatasourceCredential(credentialName, "mock", "mock", "mock");

            await using var disposableCredential = await DisposableDatasourceCredential.CreateDatasourceCredentialAsync(adminClient, credentialToCreate);
            var credentialToUpdate = disposableCredential.Credential as ServicePrincipalDatasourceCredential;

            credentialToUpdate.ClientId = ClientId;
            credentialToUpdate.TenantId = TenantId;

            var updatedCredential = (await adminClient.UpdateDatasourceCredentialAsync(credentialToUpdate)).Value as ServicePrincipalDatasourceCredential;

            Assert.That(updatedCredential.ClientId, Is.EqualTo(ClientId));
            Assert.That(updatedCredential.TenantId, Is.EqualTo(TenantId));
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

        private void ValidateGenericDatasourceCredential(DatasourceCredential credential)
        {
            if (credential is ServicePrincipalDatasourceCredential spCredential)
            {
                Assert.That(spCredential.ClientId, Is.Not.Null.And.Not.Empty);
                Assert.That(spCredential.TenantId, Is.Not.Null.And.Not.Empty);
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private void ValidateTestCaseDatasourceCredential(DatasourceCredential credential)
        {
            if (credential is ServicePrincipalDatasourceCredential spCredential)
            {
                Assert.That(spCredential.ClientId, Is.EqualTo(ClientId));
                Assert.That(spCredential.TenantId, Is.EqualTo(TenantId));
            }
            else
            {
                throw new Exception($"Unknown credential type: {credential.GetType()}");
            }
        }

        private static DatasourceCredential GetDatasourceCredentialTestCase(string credentialTypeName, string credentialName) => credentialTypeName switch
        {
            nameof(ServicePrincipalDatasourceCredential) => new ServicePrincipalDatasourceCredential(credentialName, ClientId, "clientSecret", TenantId),
            _ => throw new ArgumentOutOfRangeException($"Unknown credential type: {credentialTypeName}")
        };
    }
}

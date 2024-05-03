// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    public class DeploymentEnvironmentsClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private const string EnvName = "DevTestEnv";
        private const string EnvDefinitionName = "Sandbox";
        private const int EnvDefinitionCount = 8;
        private DeploymentEnvironmentsClient _environmentsClient;

        internal DeploymentEnvironmentsClient GetEnvironmentsClient() =>
            InstrumentClient(new DeploymentEnvironmentsClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        public DeploymentEnvironmentsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _environmentsClient = GetEnvironmentsClient();
        }

        [Test]
        public async Task GetCatalogsSucceeds()
        {
            List<DevCenterCatalog> catalogs = await _environmentsClient.GetCatalogsAsync(
                TestEnvironment.ProjectName).ToEnumerableAsync();

            Assert.AreEqual(1, catalogs.Count);

            string catalogName = catalogs[0].Name;
            if (string.IsNullOrWhiteSpace(catalogName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
        }

        [Test]
        public async Task GetCatalogSucceeds()
        {
            DevCenterCatalog catalog = await _environmentsClient.GetCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName);

            string catalogName = catalog.Name;
            if (string.IsNullOrWhiteSpace(catalogName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
        }

        [Test]
        public async Task GetEnvironmentTypesSucceeds()
        {
            List<DevCenterEnvironmentType> envTypes = await _environmentsClient.GetEnvironmentTypesAsync(
                TestEnvironment.ProjectName).ToEnumerableAsync();

            Assert.AreEqual(1, envTypes.Count);

            string envTypeName = envTypes[0].Name;
            if (string.IsNullOrWhiteSpace(envTypeName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(TestEnvironment.EnvironmentTypeName, envTypeName);
        }

        [Test]
        public async Task GetEnvironmentDefinitionSucceeds()
        {
            EnvironmentDefinition envDefinition = await _environmentsClient.GetEnvironmentDefinitionAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName,
                EnvDefinitionName);

            string envDefinitionName = envDefinition.Name;
            if (string.IsNullOrWhiteSpace(envDefinitionName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.AreEqual(EnvDefinitionName, envDefinitionName);
        }

        [Test]
        public async Task GetEnvironmentDefinitionsSucceeds()
        {
            List<EnvironmentDefinition> envDefinitions = await _environmentsClient.GetEnvironmentDefinitionsAsync(
                TestEnvironment.ProjectName).ToEnumerableAsync();

            Assert.AreEqual(EnvDefinitionCount, envDefinitions.Count);

            foreach (var envDefinition in envDefinitions)
            {
                string envDefinitionName = envDefinition.Name;
                if (string.IsNullOrWhiteSpace(envDefinitionName))
                {
                    FailDueToMissingProperty("name");
                }

                TestContext.WriteLine(envDefinitionName);
            }
        }

        [Test]
        public async Task GetEnvironmentDefinitionsByCatalogSucceeds()
        {
            List<EnvironmentDefinition> envDefinitions = await _environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName).ToEnumerableAsync();

            Assert.AreEqual(EnvDefinitionCount, envDefinitions.Count);

            foreach (var envDefinition in envDefinitions)
            {
                string envDefinitionsName = envDefinition.Name;
                if (string.IsNullOrWhiteSpace(envDefinitionsName))
                {
                    FailDueToMissingProperty("name");
                }

                TestContext.WriteLine(envDefinitionsName);
            }
        }

        [Test]
        public async Task CreateGetAndDeleteEnvironmentSucceeds()
        {
            await CreateEnvironmentAsync();
            await GetEnvironmentAsync();
            await GetEnvironmentsAsync();
            await GetAllEnvironmentsAsync();
            await DeleteEnvironmentAsync();
        }

        private async Task GetEnvironmentAsync()
        {
            DevCenterEnvironment environment = (await _environmentsClient.GetEnvironmentAsync(
                    TestEnvironment.ProjectName,
                    TestEnvironment.MeUserId,
                    EnvName)).Value;

            string envName = environment.Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task GetEnvironmentsAsync()
        {
            List<DevCenterEnvironment> environments = await _environmentsClient.GetEnvironmentsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId).ToEnumerableAsync();

            Assert.AreEqual(1, environments.Count);

            string envName = environments[0].Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task GetAllEnvironmentsAsync()
        {
            List<DevCenterEnvironment> environments = await _environmentsClient.GetAllEnvironmentsAsync(
                TestEnvironment.ProjectName).ToEnumerableAsync();

            Assert.AreEqual(1, environments.Count);

            string envName = environments[0].Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task CreateEnvironmentAsync()
        {
            var environment = new DevCenterEnvironment
            (
                EnvName,
                TestEnvironment.EnvironmentTypeName,
                TestEnvironment.CatalogName,
                EnvDefinitionName
            );

            Operation<DevCenterEnvironment> environmentCreateOperation = await _environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                environment);

            EnvironmentProvisioningState? provisioningState = environmentCreateOperation.Value.ProvisioningState;
            Assert.IsTrue(provisioningState.Equals(EnvironmentProvisioningState.Succeeded));
        }

        private async Task DeleteEnvironmentAsync()
        {
            Operation environmentDeleteOperation = await _environmentsClient.DeleteEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName);

            CheckLROSucceeded(environmentDeleteOperation);
        }

        private void CheckLROSucceeded(Operation finalOperationResponse)
        {
            var responseData = finalOperationResponse.GetRawResponse().Content;
            var response = JsonDocument.Parse(responseData).RootElement;

            if (!response.TryGetProperty("status", out var responseStatusJson))
            {
                FailDueToMissingProperty("status");
            }

            var status = responseStatusJson.ToString();
            Assert.True(status.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The JSON response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

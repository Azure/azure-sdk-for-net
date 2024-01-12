// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    [PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class EnvironmentsClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private const string EnvName = "DevTestEnv";
        private const string EnvDefinitionName = "Sandbox";
        private DeploymentEnvironmentsClient _environmentsClient;

        internal DeploymentEnvironmentsClient GetEnvironmentsClient() =>
            InstrumentClient(new DeploymentEnvironmentsClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DevCenterClientOptions())));

        public EnvironmentsClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _environmentsClient = GetEnvironmentsClient();
        }

        [RecordedTest]
        public async Task GetCatalogsSucceeds()
        {
            var numberOfReturnedCatalogs = 0;
            await foreach (DevCenterCatalog catalog in _environmentsClient.GetCatalogsAsync(
                TestEnvironment.ProjectName))
            {
                numberOfReturnedCatalogs++;

                string catalogName = catalog.Name;
                if (string.IsNullOrWhiteSpace(catalogName))
                {
                    FailDueToMissingProperty("name");
                }
                Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
            }

            Assert.AreEqual(1, numberOfReturnedCatalogs);
        }

        [RecordedTest]
        public async Task GetCatalogSucceeds()
        {
            Response<DevCenterCatalog> getCatalogResponse = await _environmentsClient.GetCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName);

            string catalogName = getCatalogResponse?.Value?.Name;
            if (string.IsNullOrWhiteSpace(catalogName))
            {
                FailDueToMissingProperty("name");
            }
            Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
        }

        [RecordedTest]
        public async Task GetEnvironmentTypesSucceeds()
        {
            var numberOfEnvTypes = 0;
            await foreach (DevCenterEnvironmentType envType in _environmentsClient.GetEnvironmentTypesAsync(TestEnvironment.ProjectName))
            {
                numberOfEnvTypes++;

                string envTypeName = envType.Name;
                if (string.IsNullOrWhiteSpace(envTypeName))
                {
                    FailDueToMissingProperty("name");
                }

                Assert.AreEqual(TestEnvironment.EnvironmentTypeName, envTypeName);
            }

            Assert.AreEqual(1, numberOfEnvTypes);
        }

        [RecordedTest]
        public async Task GetEnvironmentDefinitionsSucceeds()
        {
            var numberOfEnvDefinitions = 0;
            await foreach (EnvironmentDefinition envDefinition in _environmentsClient.GetEnvironmentDefinitionsAsync(TestEnvironment.ProjectName))
            {
                numberOfEnvDefinitions++;

                string envDefinitionsName = envDefinition.Name;
                if (string.IsNullOrWhiteSpace(envDefinitionsName))
                {
                    FailDueToMissingProperty("name");
                }

                TestContext.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }

        [RecordedTest]
        public async Task GetEnvironmentDefinitionsByCatalogSucceeds()
        {
            var numberOfEnvDefinitions = 0;
            await foreach (EnvironmentDefinition envDefinition in _environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName))
            {
                numberOfEnvDefinitions++;

                string envDefinitionsName = envDefinition.Name;
                if (string.IsNullOrWhiteSpace(envDefinitionsName))
                {
                    FailDueToMissingProperty("name");
                }

                TestContext.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }

        [RecordedTest]
        public async Task EnvironmentCreateAndDeleteSucceeds()
        {
            await SetUpEnvironmentAsync();
            await DeleteEnvironmentAsync();
        }

        [RecordedTest]
        public async Task GetEnvironmentSucceeds()
        {
            DevCenterEnvironment environment = await GetEnvironmentAsync();

            if (environment == default)
            {
                await SetUpEnvironmentAsync();
                environment = await GetEnvironmentAsync();
            }

            string envName = environment.Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        [RecordedTest]
        public async Task GetEnvironmentsSucceeds()
        {
            var environments = await GetEnvironmentsAsync();

            if (!environments.Any())
            {
                await SetUpEnvironmentAsync();
                environments = await GetEnvironmentsAsync();
            }

            Assert.AreEqual(1, environments.Count);

            string envName = environments[0].Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        [RecordedTest]
        public async Task GetAllEnvironmentsSucceeds()
        {
            var environments = await GetAllEnvironmentsAsync();

            if (!environments.Any())
            {
                await SetUpEnvironmentAsync();
                environments = await GetAllEnvironmentsAsync();
            }

            Assert.AreEqual(1, environments.Count);

            string envName = environments[0].Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));
        }

        private async Task<DevCenterEnvironment> GetEnvironmentAsync()
        {
            try
            {
                return (await _environmentsClient.GetEnvironmentAsync(
                    TestEnvironment.ProjectName,
                    TestEnvironment.MeUserId,
                    EnvName)).Value;
            }
            // if environment doesn't exist Get Environment will throw an error
            catch
            {
                return default;
            }
        }

        private async Task<List<DevCenterEnvironment>> GetEnvironmentsAsync()
        {
            return await _environmentsClient.GetEnvironmentsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId).ToEnumerableAsync();
        }

        private async Task<List<DevCenterEnvironment>> GetAllEnvironmentsAsync()
        {
            return await _environmentsClient.GetAllEnvironmentsAsync(
                TestEnvironment.ProjectName).ToEnumerableAsync();
        }

        private async Task SetUpEnvironmentAsync()
        {
            var environment = new DevCenterEnvironment
            (
                TestEnvironment.EnvironmentTypeName,
                TestEnvironment.CatalogName,
                EnvDefinitionName
            );

            Operation<DevCenterEnvironment> environmentCreateOperation = await _environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName,
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

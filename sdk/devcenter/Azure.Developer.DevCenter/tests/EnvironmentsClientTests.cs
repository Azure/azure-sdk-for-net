// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Developer.DevCenter.Models;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    //[PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class EnvironmentsClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private const string EnvName = "DevTestEnv";
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

                Console.WriteLine(envDefinitionsName);
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

                Console.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }

        [RecordedTest]
        public async Task GetEnvironmentSucceeds()
        {
            await SetUpEnvironmentAsync();

            Response<DevCenterEnvironment> getEnvResponse = await _environmentsClient.GetEnvironmentAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName);

            string envName = getEnvResponse?.Value?.Name;
            if (string.IsNullOrWhiteSpace(envName))
            {
                FailDueToMissingProperty("name");
            }

            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));

            await DeleteEnvironmentAsync();
        }

        [Test]
        public async Task GetEnvironmentsSucceeds()
        {
            var numberOfEnvironments = await GetEnvironmentsAsync();

            if (numberOfEnvironments == 0)
            {
                await SetUpEnvironmentAsync();
            }

            numberOfEnvironments = await GetEnvironmentsAsync();
            Assert.AreEqual(1, numberOfEnvironments);

            await DeleteEnvironmentAsync();
        }

        [RecordedTest]
        public async Task GetAllEnvironmentsSucceeds()
        {
            var numberOfEnvironments = await GetAllEnvironmentsAsync();

            if (numberOfEnvironments == 0)
            {
                await SetUpEnvironmentAsync();
            }

            numberOfEnvironments = await GetAllEnvironmentsAsync();
            Assert.AreEqual(1, numberOfEnvironments);

            await DeleteEnvironmentAsync();
        }

        private async Task<int> GetAllEnvironmentsAsync()
        {
            var numberOfEnvironments = 0;
            await foreach (DevCenterEnvironment environment in _environmentsClient.GetAllEnvironmentsAsync(
                TestEnvironment.ProjectName))
            {
                numberOfEnvironments++;

                string envName = environment.Name;
                if (string.IsNullOrWhiteSpace(envName))
                {
                    FailDueToMissingProperty("name");
                }
                Console.WriteLine(envName);
            }

            return numberOfEnvironments;
        }

        private async Task<int> GetEnvironmentsAsync()
        {
            var numberOfEnvironments = 0;
            await foreach (DevCenterEnvironment environment in _environmentsClient.GetEnvironmentsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId))
            {
                numberOfEnvironments++;

                string envName = environment.Name;
                if (string.IsNullOrWhiteSpace(envName))
                {
                    FailDueToMissingProperty("name");
                }
                Console.WriteLine(envName);
            }

            return numberOfEnvironments;
        }

        private async Task SetUpEnvironmentAsync()
        {
            string envDefinitionName = string.Empty;

            await foreach (EnvironmentDefinition envDefinition in _environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName))
            {
                envDefinitionName = envDefinition.Name;
                if (string.IsNullOrWhiteSpace(envDefinitionName))
                {
                    FailDueToMissingProperty("name");
                }

                if (envDefinitionName == "Sandbox") break;
            }

            var environment = new DevCenterEnvironment
            (
                TestEnvironment.EnvironmentTypeName,
                TestEnvironment.CatalogName,
                envDefinitionName
            );

            Operation<DevCenterEnvironment> environmentCreateOperation = await _environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName,
                environment);

            environment = await environmentCreateOperation.WaitForCompletionAsync();

            EnvironmentProvisioningState? provisioningState = environment.ProvisioningState;
            Assert.IsTrue(provisioningState.Equals(EnvironmentProvisioningState.Succeeded));
        }

        private async Task DeleteEnvironmentAsync()
        {
            Operation environmentDeleteOperation = await _environmentsClient.DeleteEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName);

            await environmentDeleteOperation.WaitForCompletionResponseAsync();
            Console.WriteLine($"Completed environment deletion.");
        }

        private void FailDueToMissingProperty(string propertyName)
        {
            Assert.Fail($"The JSON response received from the service does not include the necessary property: {propertyName}");
        }
    }
}

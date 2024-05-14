// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    [PlaybackOnly("As deploy/delete manipulations with real resources take time.")]
    public class EnvironmentsClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
        private const string EnvName = "DevTestEnv";
        private DeploymentEnvironmentsClient _environmentsClient;

        internal DeploymentEnvironmentsClient GetEnvironmentsClient() =>
            InstrumentClient(new DeploymentEnvironmentsClient(
                TestEnvironment.Endpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new AzureDeveloperDevCenterClientOptions())));

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
            await foreach (BinaryData catalogData in _environmentsClient.GetCatalogsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfReturnedCatalogs++;
                JsonElement catalogResponseData = JsonDocument.Parse(catalogData.ToStream()).RootElement;

                if (!catalogResponseData.TryGetProperty("name", out var catalogNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string catalogName = catalogNameJson.ToString();
                Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
            }

            Assert.AreEqual(1, numberOfReturnedCatalogs);
        }

        [RecordedTest]
        public async Task GetCatalogSucceeds()
        {
            Response getCatalogResponse = await _environmentsClient.GetCatalogAsync(TestEnvironment.ProjectName, TestEnvironment.CatalogName, TestEnvironment.context);
            JsonElement getCatalogData = JsonDocument.Parse(getCatalogResponse.ContentStream).RootElement;

            if (!getCatalogData.TryGetProperty("name", out var catalogNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string catalogName = catalogNameJson.ToString();
            Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
        }

        [RecordedTest]
        public async Task GetEnvironmentTypesSucceeds()
        {
            var numberOfEnvTypes = 0;
            await foreach (BinaryData envTypeData in _environmentsClient.GetEnvironmentTypesAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfEnvTypes++;
                JsonElement envTypeResponseData = JsonDocument.Parse(envTypeData.ToStream()).RootElement;

                if (!envTypeResponseData.TryGetProperty("name", out var envTypeNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string envTypeName = envTypeNameJson.ToString();
                Assert.AreEqual(TestEnvironment.EnvironmentTypeName, envTypeName);
            }

            Assert.AreEqual(1, numberOfEnvTypes);
        }

        [RecordedTest]
        public async Task GetEnvironmentDefinitionsSucceeds()
        {
            var numberOfEnvDefinitions = 0;
            await foreach (BinaryData envDefinitionsData in _environmentsClient.GetEnvironmentDefinitionsAsync(TestEnvironment.ProjectName, TestEnvironment.maxCount, TestEnvironment.context))
            {
                numberOfEnvDefinitions++;
                JsonElement envDefinitionsResponseData = JsonDocument.Parse(envDefinitionsData.ToStream()).RootElement;

                if (!envDefinitionsResponseData.TryGetProperty("name", out var envDefinitionsNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string envDefinitionsName = envDefinitionsNameJson.ToString();
                Console.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }

        [RecordedTest]
        public async Task GetEnvironmentDefinitionsByCatalogSucceeds()
        {
            var numberOfEnvDefinitions = 0;
            await foreach (BinaryData envDefinitionsData in _environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfEnvDefinitions++;
                JsonElement envDefinitionsResponseData = JsonDocument.Parse(envDefinitionsData.ToStream()).RootElement;

                if (!envDefinitionsResponseData.TryGetProperty("name", out var envDefinitionsNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string envDefinitionsName = envDefinitionsNameJson.ToString();
                Console.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }

        [RecordedTest]
        public async Task GetEnvironmentSucceeds()
        {
            await SetUpEnvironmentAsync();

            Response getEnvResponse = await _environmentsClient.GetEnvironmentAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName,
                TestEnvironment.context);
            JsonElement getEnvData = JsonDocument.Parse(getEnvResponse.ContentStream).RootElement;

            if (!getEnvData.TryGetProperty("name", out var envNameJson))
            {
                FailDueToMissingProperty("name");
            }

            string envName = envNameJson.ToString();
            Assert.IsTrue(EnvName.Equals(envName, StringComparison.OrdinalIgnoreCase));

            await DeleteEnvironmentAsync();
        }

        [RecordedTest]
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
            await foreach (BinaryData environmentsData in _environmentsClient.GetAllEnvironmentsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfEnvironments++;
                JsonElement environmentsResponseData = JsonDocument.Parse(environmentsData.ToStream()).RootElement;

                if (!environmentsResponseData.TryGetProperty("name", out var environmentNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string envName = environmentNameJson.ToString();
                Console.WriteLine(envName);
            }

            return numberOfEnvironments;
        }

        private async Task<int> GetEnvironmentsAsync()
        {
            var numberOfEnvironments = 0;
            await foreach (BinaryData environmentsData in _environmentsClient.GetEnvironmentsAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                numberOfEnvironments++;
                JsonElement environmentsResponseData = JsonDocument.Parse(environmentsData.ToStream()).RootElement;

                if (!environmentsResponseData.TryGetProperty("name", out var environmentNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                string envName = environmentNameJson.ToString();
                Console.WriteLine(envName);
            }

            return numberOfEnvironments;
        }

        private async Task SetUpEnvironmentAsync()
        {
            string envDefinitionsName = string.Empty;

            await foreach (BinaryData envDefinitionsData in _environmentsClient.GetEnvironmentDefinitionsByCatalogAsync(
                TestEnvironment.ProjectName,
                TestEnvironment.CatalogName,
                TestEnvironment.maxCount,
                TestEnvironment.context))
            {
                JsonElement envDefinitionsResponseData = JsonDocument.Parse(envDefinitionsData.ToStream()).RootElement;

                if (!envDefinitionsResponseData.TryGetProperty("name", out var envDefinitionsNameJson))
                {
                    FailDueToMissingProperty("name");
                }

                envDefinitionsName = envDefinitionsNameJson.ToString();
                if (envDefinitionsName == "Sandbox") break;
            }

            var content = new
            {
                environmentDefinitionName = envDefinitionsName,
                catalogName = TestEnvironment.CatalogName,
                environmentType = TestEnvironment.EnvironmentTypeName,
            };

            Operation<BinaryData> environmentCreateOperation = await _environmentsClient.CreateOrUpdateEnvironmentAsync(
                WaitUntil.Completed,
                TestEnvironment.ProjectName,
                TestEnvironment.MeUserId,
                EnvName,
                RequestContent.Create(content));

            BinaryData environmentData = await environmentCreateOperation.WaitForCompletionAsync();
            JsonElement environment = JsonDocument.Parse(environmentData.ToStream()).RootElement;

            var provisioningState = environment.GetProperty("provisioningState").ToString();
            Assert.IsTrue(provisioningState.Equals("Succeeded", StringComparison.OrdinalIgnoreCase));
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.DevCenter.Tests
{
    public class EnvironmentsClientTests : RecordedTestBase<DevCenterClientTestEnvironment>
    {
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
        public async Task SetUp()
        {
            Mode = RecordedTestMode.Record;
            await base.StartTestRecordingAsync();

            _environmentsClient = GetEnvironmentsClient();
        }

        [RecordedTest]
        public async Task GetCatalogsSucceeds()
        {
            var numberOfReturnedCatalogs = 0;
            await foreach (BinaryData catalogData in _environmentsClient.GetCatalogsAsync(TestEnvironment.ProjectName))
            {
                numberOfReturnedCatalogs++;
                JsonElement catalogResponseData = JsonDocument.Parse(catalogData.ToStream()).RootElement;

                if (!catalogResponseData.TryGetProperty("name", out var catalogNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string catalogName = catalogNameJson.ToString();
                Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
            }

            Assert.AreEqual(1, numberOfReturnedCatalogs);
        }

        [RecordedTest]
        public async Task GetCatalogSucceeds()
        {
            Response getCatalogResponse = await _environmentsClient.GetCatalogAsync(TestEnvironment.ProjectName, TestEnvironment.CatalogName);
            JsonElement getCatalogData = JsonDocument.Parse(getCatalogResponse.ContentStream).RootElement;

            if (!getCatalogData.TryGetProperty("name", out var catalogNameJson))
            {
                Assert.Fail("The JSON response received from the service does not include the necessary property.");
            }

            string catalogName = catalogNameJson.ToString();
            Assert.AreEqual(TestEnvironment.CatalogName, catalogName);
        }

        [RecordedTest]
        public async Task GetEnvironmentTypesSucceeds()
        {
            var numberOfEnvTypes = 0;
            await foreach (BinaryData envTypeData in _environmentsClient.GetEnvironmentTypesAsync(TestEnvironment.ProjectName))
            {
                numberOfEnvTypes++;
                JsonElement envTypeResponseData = JsonDocument.Parse(envTypeData.ToStream()).RootElement;

                if (!envTypeResponseData.TryGetProperty("name", out var envTypeNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string envTypeName = envTypeNameJson.ToString();
                Assert.AreEqual(TestEnvironment.EnvironmentTypeName, envTypeName);
            }

            Assert.AreEqual(1, numberOfEnvTypes);
        }

        [RecordedTest]
        public async Task GetEnvironmentDefinitionsAsyncSucceeds()
        {
            var numberOfEnvDefinitions = 0;
            await foreach (BinaryData envDefinitionsData in _environmentsClient.GetEnvironmentDefinitionsAsync(TestEnvironment.ProjectName))
            {
                numberOfEnvDefinitions++;
                JsonElement envDefinitionsResponseData = JsonDocument.Parse(envDefinitionsData.ToStream()).RootElement;

                if (!envDefinitionsResponseData.TryGetProperty("name", out var envDefinitionsNameJson))
                {
                    Assert.Fail("The JSON response received from the service does not include the necessary property.");
                }

                string envDefinitionsName = envDefinitionsNameJson.ToString();
                Console.WriteLine(envDefinitionsName);
            }

            Assert.AreEqual(3, numberOfEnvDefinitions);
        }
    }
}

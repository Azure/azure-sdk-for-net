// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin operations.
    /// </summary>
    public class ModelsTests : E2eTestBase
    {
        public ModelsTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task Models_Lifecycle()
        {
            DigitalTwinsClient client = GetClient();

            string buildingModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.BuildingModelId).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelId).ConfigureAwait(false);
            string hvacModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.HvacModelId).ConfigureAwait(false);
            string wardModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WardModelId).ConfigureAwait(false);

            try
            {
                string modelBuilding = TestAssetsHelper.GetBuildingModelPayload(buildingModelId, hvacModelId, floorModelId);
                string modelHvac = TestAssetsHelper.GetHvacModelPayload(hvacModelId, floorModelId);
                string modelWard = TestAssetsHelper.GetWardModelPayload(wardModelId);

                // CREATE models
                var modelsList = new List<string> { modelBuilding, modelHvac, modelWard };
                await client.CreateModelsAsync(modelsList).ConfigureAwait(false);

                // GET one created model
                Response<ModelData> buildingModel = await client.GetModelAsync(buildingModelId).ConfigureAwait(false);
                Console.WriteLine($"Got {buildingModelId} as {buildingModel.Value.Model}");

                // LIST all models
                AsyncPageable<ModelData> models = client.GetModelsAsync();
                await foreach (ModelData model in models)
                {
                    Console.WriteLine($"{model.Id}");
                }

                // DECOMMISSION a model
                await client.DecommissionModelAsync(buildingModelId).ConfigureAwait(false);
            }
            finally
            {
                // Test DELETE all models.
                try
                {
                    await client.DeleteModelAsync(buildingModelId).ConfigureAwait(false);
                    await client.DeleteModelAsync(hvacModelId).ConfigureAwait(false);
                    await client.DeleteModelAsync(wardModelId).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Swagger defines ModelData as an object, but expected to be "a language map that contains the localized" values.
        /// A model definition may specify a single string value, and the service will turn that into a dictionary.
        /// This test validates that potentially non-conforming data format (string) properly gets translated into a map
        /// on the service, and can be properly deserialized into a ModelData instance in the SDK.
        /// </summary>
        [Test]
        public async Task ModelData_DisplayNameAndDescription_Deserializes()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            string wardModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WardModelId).ConfigureAwait(false);

            // add a model with a single value for displayName and for description, neither of which were defined as a map
            string modelWard = TestAssetsHelper.GetWardModelPayload(wardModelId);

            await client.CreateModelsAsync(new[] { modelWard }).ConfigureAwait(false);

            // act
            // should not throw on deserialization
            Response<ModelData> wardModel = await client.GetModelAsync(wardModelId).ConfigureAwait(false);

            // assert

            wardModel.Value.DisplayName.Count.Should().Be(1, "Should have 1 entry for display name");
            wardModel.Value.DisplayName.Keys.First().Should().Be("en");
        }

        [Test]
        public void Models_ModelNotExists_ThrowsNotFoundException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            // act
            Func<Task> act = async () => await client.GetModelAsync("urn:doesnotexist:fakemodel:1000").ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public void Models_MalformedModelId_ThrowsBadRequestException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            // act
            Func<Task> act = async () => await client.GetModelAsync("thisIsNotAValidModelId").ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Models_ModelAlreadyExists_ThrowsConflictException()
        {
            // arrange

            DigitalTwinsClient client = GetClient();

            string wardModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.WardModelId).ConfigureAwait(false);

            string modelWard = TestAssetsHelper.GetWardModelPayload(wardModelId);

            var modelsList = new List<string> { modelWard };

            // Create model once
            await client.CreateModelsAsync(modelsList).ConfigureAwait(false);

            // act
            Func<Task> act = async () => await client.CreateModelsAsync(modelsList).ConfigureAwait(false);

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.Conflict);
        }
    }
}

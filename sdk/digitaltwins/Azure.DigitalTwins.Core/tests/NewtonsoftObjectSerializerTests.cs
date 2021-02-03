// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for custom ObjectSerializer.
    /// </summary>
    public class NewtonsoftObjectSerializerTests : E2eTestBase
    {
        public NewtonsoftObjectSerializerTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TestNewtonsoftObjectSerializerWithDigitalTwins()
        {
            DigitalTwinsClient defaultClient = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(defaultClient, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(defaultClient, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(defaultClient, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(defaultClient, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await defaultClient.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // Create a client with NewtonsoftJsonObjectSerializer configured as the serializer.
                DigitalTwinsClient testClient = GetClient(
                    new DigitalTwinsClientOptions
                    {
                        Serializer = new NewtonsoftJsonObjectSerializer()
                    });

                // Get digital twin using the simple DigitalTwin model annotated with Newtonsoft attributes
                SimpleNewtonsoftDtModel getResponse = await testClient.GetDigitalTwinAsync<SimpleNewtonsoftDtModel>(roomTwinId).ConfigureAwait(false);

                Assert.IsNotNull(getResponse.Id, "Digital twin Id should not be null or empty");

                // Query DigitalTwins using the simple DigitalTwin model annotated with Newtonsoft attributes
                AsyncPageable<SimpleNewtonsoftDtModel> queryResponse = testClient.QueryAsync<SimpleNewtonsoftDtModel>("SELECT * FROM DIGITALTWINS");

                await foreach (SimpleNewtonsoftDtModel twin in queryResponse)
                {
                    Assert.IsNotNull(twin.Id, "Digital twin Id should not be null or empty");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    // delete twin
                    if (!string.IsNullOrWhiteSpace(roomTwinId))
                    {
                        await defaultClient.DeleteDigitalTwinAsync(roomTwinId).ConfigureAwait(false);
                    }

                    // delete models
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await defaultClient.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}

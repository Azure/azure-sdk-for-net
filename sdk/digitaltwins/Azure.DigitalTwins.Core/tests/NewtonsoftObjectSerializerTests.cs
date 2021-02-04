// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for custom ObjectSerializer.
    /// Users can specify their own serializer/deserializer and not go with the default JsonObjectSerializer.
    /// SDK needs to make sure it can properly use different serializers and the behavior is seamless.
    /// Specifically, we have a work around in the query code which requires use of a System.Text.Json serializer because it works on a JsonElement.
    /// When the user initializes with a non-default serializer, we must not use that to do this work.
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

                getResponse.Id.Should().NotBeNullOrEmpty("Digital twin ID should not be null or empty");

                // Query DigitalTwins using the simple DigitalTwin model annotated with Newtonsoft attributes
                AsyncPageable<SimpleNewtonsoftDtModel> queryResponse = testClient.QueryAsync<SimpleNewtonsoftDtModel>("SELECT * FROM DIGITALTWINS");

                await foreach (SimpleNewtonsoftDtModel twin in queryResponse)
                {
                    twin.Id.Should().NotBeNullOrEmpty("Digital twin Id should not be null or empty");
                }
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

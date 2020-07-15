// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin operations.
    /// </summary>
    public class DigitalTwinTests : E2eTestBase
    {
        public DigitalTwinTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task DigitalTwins_Lifecycle()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await client.CreateModelsAsync(new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                string roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

                // get twin
                await client.GetDigitalTwinAsync(roomTwinId).ConfigureAwait(false);

                // update twin
                string updateTwin = TestAssetsHelper.GetRoomTwinUpdatePayload();

                var requestOptions = new RequestOptions
                {
                    IfMatch = "*"
                };

                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwin, requestOptions).ConfigureAwait(false);

                // delete a twin
                await client.DeleteDigitalTwinAsync(roomTwinId).ConfigureAwait(false);

                // assert
                Func<Task> act = async () =>
                {
                    await client.GetDigitalTwinAsync(roomTwinId).ConfigureAwait(false);
                };

                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public void DigitalTwins_IncorrectCredentials_ThrowsUnauthorizedException()
        {
            // arrange
            DigitalTwinsClient unauthorizedClient = GetFakeClient();

            // act
            Func<Task> act = async () =>
            {
                await unauthorizedClient.GetDigitalTwinAsync("someNonExistantTwin").ConfigureAwait(false);
            };

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.Unauthorized);
        }

        [Test]
        public void DigitalTwins_TwinNotExist_ThrowsNotFoundException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            // act
            Func<Task> act = async () =>
            {
                await client.GetDigitalTwinAsync("someNonExistantTwin").ConfigureAwait(false);
            };

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.NotFound);
        }
    }
}

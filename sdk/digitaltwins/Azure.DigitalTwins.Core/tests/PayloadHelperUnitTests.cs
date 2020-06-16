// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.DigitalTwins.Core.Serialization;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    [Category("Unit")]
    [Parallelizable(ParallelScope.All)]
    public class PayloadHelperUnitTests
    {
        [Test]
        public void PayloadHelper_BuildArrayPayload_ValidateArray()
        {
            // arrange
            string floorJson = TestAssetsHelper.GetFloorModelPayload(
                TestAssetDefaults.FloorModelId,
                TestAssetDefaults.RoomModelId,
                TestAssetDefaults.HvacModelId);
            string roomJson = TestAssetsHelper.GetRoomModelPayload(TestAssetDefaults.RoomModelId, TestAssetDefaults.FloorModelId);
            var models = new List<string> { floorJson, roomJson };

            // act
            string creationPayload = PayloadHelper.BuildArrayPayload(models);

            // assert
            creationPayload.Should().NotBeNullOrEmpty();
            JsonDocument parsedJson = JsonDocument.Parse(creationPayload);
            parsedJson.RootElement.ValueKind.Should().Be(JsonValueKind.Array);
            parsedJson.RootElement.GetArrayLength().Should().Be(models.Count);
            parsedJson.RootElement[0].ToString().Should().Be(floorJson);
            parsedJson.RootElement[1].ToString().Should().Be(roomJson);
        }

        [Test]
        public void PayloadHelper_BuildArrayPayload_NullParam()
        {
            Action act = () => PayloadHelper.BuildArrayPayload(null);

            act.Should().Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("entities");
        }
    }
}

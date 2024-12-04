// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.GeoJson;

namespace Azure.Maps.TimeZones.Tests
{
    public class MapsTimeZoneTests : TimeZoneClientLiveTestsBase
    {
        public MapsTimeZoneTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetTimezoneByIdTest()
        {
            var client = CreateClient();
            GetTimeZoneOptions options = new GetTimeZoneOptions()
            {
                AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
            };
            var response = await client.GetTimeZoneByIdAsync("Asia/Bahrain", options);
            Assert.AreEqual("Asia/Qatar", response.Value.TimeZones[0].Id);
        }

        [RecordedTest]
        public void InvalidGetTimezoneByIdTest()
        {
            var client = CreateClient();
            GetTimeZoneOptions options = new GetTimeZoneOptions();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimeZoneByIdAsync("", options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetTimezoneByCoordinatesTest()
        {
            var client = CreateClient();
            GetTimeZoneOptions options = new GetTimeZoneOptions()
            {
                AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
            };
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetTimeZoneByCoordinatesAsync(coordinates, options);
            Assert.AreEqual(1, response.Value.TimeZones.Count);
            Assert.AreEqual("Asia/Taipei", response.Value.TimeZones[0].Id);
        }

        [RecordedTest]
        public void InvalidGetTimezoneByCoordinatesTest()
        {
            // "The provided coordinates in query are invalid, out of range, or not in the expected format"
            var client = CreateClient();
            GetTimeZoneOptions options = new GetTimeZoneOptions()
            {
                AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
            };
            GeoPosition coordinates = new GeoPosition(121.0, -100.0);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimeZoneByCoordinatesAsync(coordinates, options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetWindowsTimezoneIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetWindowsTimeZoneIdsAsync();
            Assert.AreEqual(505, response.Value.WindowsTimeZones.Count);
        }

        [RecordedTest]
        public async Task GetTimeZoneIanaIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetTimeZoneIanaIdsAsync();
            Assert.AreEqual(596, response.Value.IanaIds.Count);
        }

        [RecordedTest]
        public async Task GetIanaVersionTest()
        {
            var client = CreateClient();
            var response = await client.GetIanaVersionAsync();
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task ConvertWindowsTimezoneToIanaTest()
        {
            var client = CreateClient();
            var response = await client.ConvertWindowsTimeZoneToIanaAsync("Dateline Standard Time");
            Assert.AreEqual(1, response.Value.IanaIds.Count);
            Assert.AreEqual("Etc/GMT+12", response.Value.IanaIds[0].Id);
        }

        [RecordedTest]
        public void InvalidConvertWindowsTimezoneToIanaTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.ConvertWindowsTimeZoneToIanaAsync(""));
            Assert.AreEqual(400, ex.Status);
        }
    }
}

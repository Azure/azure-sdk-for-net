// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Maps.TimeZone.Models.Options;
using Azure.Maps.TimeZone.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.TimeZone.Tests
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
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            options.Options = TimeZoneOptions.All;
            var response = await client.GetTimeZoneByIDAsync("Asia/Bahrain", options);
            Assert.AreEqual("Asia/Qatar", response.Value.TimeZones[0].Id);
        }

        [RecordedTest]
        public void InvalidGetTimezoneByIdTest()
        {
            var client = CreateClient();
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimeZoneByIDAsync("", options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetTimezoneByCoordinatesTest()
        {
            var client = CreateClient();
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            options.Options = TimeZoneOptions.All;
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
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            options.Options = TimeZoneOptions.All;
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
            Assert.AreEqual(505, response.Value.Count);
        }

        [RecordedTest]
        public async Task GetIanaTimezoneIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetIanaTimeZoneIdsAsync();
            Assert.AreEqual(596, response.Value.Count);
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
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("Etc/GMT+12", response.Value[0].Id);
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

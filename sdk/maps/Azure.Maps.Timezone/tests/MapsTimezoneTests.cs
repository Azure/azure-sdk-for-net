// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Maps.Timezone.Models.Options;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Timezone.Tests
{
    public class MapsTimezoneTests : TimezoneClientLiveTestsBase
    {
        public MapsTimezoneTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetTimezoneByIdTest()
        {
            var client = CreateClient();
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            options.Options = TimezoneOptions.All;
            var response = await client.GetTimezoneByIDAsync("Asia/Bahrain", options);
            Assert.AreEqual("Asia/Qatar", response.Value.TimeZones[0].Id);
        }

        [RecordedTest]
        public void InvalidGetTimezoneByIdTest()
        {
            var client = CreateClient();
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimezoneByIDAsync("", options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetTimezoneByCoordinatesTest()
        {
            var client = CreateClient();
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            options.Options = TimezoneOptions.All;
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetTimezoneByCoordinatesAsync(coordinates, options);
            Assert.AreEqual(1, response.Value.TimeZones.Count);
            Assert.AreEqual("Asia/Taipei", response.Value.TimeZones[0].Id);
        }

        [RecordedTest]
        public void InvalidGetTimezoneByCoordinatesTest()
        {
            // "The provided coordinates in query are invalid, out of range, or not in the expected format"
            var client = CreateClient();
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            options.Options = TimezoneOptions.All;
            GeoPosition coordinates = new GeoPosition(121.0, -100.0);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimezoneByCoordinatesAsync(coordinates, options));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetWindowsTimezoneIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetWindowsTimezoneIdsAsync();
            Assert.AreEqual(505, response.Value.Count);
        }

        [RecordedTest]
        public async Task GetIanaTimezoneIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetIanaTimezoneIdsAsync();
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
            var response = await client.ConvertWindowsTimezoneToIanaAsync("Dateline Standard Time");
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual("Etc/GMT+12", response.Value[0].Id);
        }

        [RecordedTest]
        public void InvalidConvertWindowsTimezoneToIanaTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.ConvertWindowsTimezoneToIanaAsync(""));
            Assert.AreEqual(400, ex.Status);
        }
    }
}

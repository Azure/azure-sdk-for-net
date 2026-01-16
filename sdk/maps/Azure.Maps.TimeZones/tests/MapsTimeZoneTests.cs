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
            Assert.That(response.Value.TimeZones[0].Id, Is.EqualTo("Asia/Qatar"));
        }

        [RecordedTest]
        public void InvalidGetTimezoneByIdTest()
        {
            var client = CreateClient();
            GetTimeZoneOptions options = new GetTimeZoneOptions();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetTimeZoneByIdAsync("", options));
            Assert.That(ex.Status, Is.EqualTo(400));
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
            Assert.That(response.Value.TimeZones.Count, Is.EqualTo(1));
            Assert.That(response.Value.TimeZones[0].Id, Is.EqualTo("Asia/Taipei"));
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
            Assert.That(ex.Status, Is.EqualTo(400));
        }

        [RecordedTest]
        public async Task GetWindowsTimezoneIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetWindowsTimeZoneIdsAsync();
            Assert.That(response.Value.WindowsTimeZones.Count, Is.EqualTo(505));
        }

        [RecordedTest]
        public async Task GetTimeZoneIanaIdsTest()
        {
            var client = CreateClient();
            var response = await client.GetTimeZoneIanaIdsAsync();
            Assert.That(response.Value.IanaIds.Count, Is.EqualTo(596));
        }

        [RecordedTest]
        public async Task GetIanaVersionTest()
        {
            var client = CreateClient();
            var response = await client.GetIanaVersionAsync();
            Assert.That(response, Is.Not.Null);
        }

        [RecordedTest]
        public async Task ConvertWindowsTimezoneToIanaTest()
        {
            var client = CreateClient();
            var response = await client.ConvertWindowsTimeZoneToIanaAsync("Dateline Standard Time");
            Assert.That(response.Value.IanaIds.Count, Is.EqualTo(1));
            Assert.That(response.Value.IanaIds[0].Id, Is.EqualTo("Etc/GMT+12"));
        }

        [RecordedTest]
        public void InvalidConvertWindowsTimezoneToIanaTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.ConvertWindowsTimeZoneToIanaAsync(""));
            Assert.That(ex.Status, Is.EqualTo(400));
        }
    }
}

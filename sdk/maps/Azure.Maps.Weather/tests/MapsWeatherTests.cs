// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using Azure.Maps.Weather.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.Weather.Tests
{
    public class MapsWeatherTests : WeatherClientLiveTestsBase
    {
        public MapsWeatherTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetHourlyForecastAsyncTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetHourlyForecastAsync("json", coordinates, "metric", 1, "en-US");
            Console.WriteLine(response);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetMinuteForecastTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetMinuteForecastAsync("json", coordinates, "metric", 1, "en-US");
            Console.WriteLine(response);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public void GetQuarterDayForecastTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetMinuteForecastAsync("json", coordinates, "metric", 1, "en-US");
            Console.WriteLine(response);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetCurrentConditionsTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetMinuteForecastAsync("json", coordinates, "metric", "true", 1, "en-US");
            Console.WriteLine(response);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyForecastTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            var response = await client.GetMinuteForecastAsync("json", coordinates, "metric", 1, "en-US");
            Console.WriteLine(response);
            Assert.NotNull(response);
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

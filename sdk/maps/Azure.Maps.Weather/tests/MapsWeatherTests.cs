// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core.GeoJson;
using Azure.Maps.Weather.Models;
using Azure.Maps.Weather.Models.Options;

namespace Azure.Maps.Weather.Tests
{
    public class MapsWeatherTests : WeatherClientLiveTestsBase
    {
        public MapsWeatherTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetAirQualityDailyForecastsTest()
        {
            var client = CreateClient();
            var options = new GetAirQualityDailyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetAirQualityDailyForecastsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetAirQualityHourlyForecastsTest()
        {
            var client = CreateClient();
            var options = new GetAirQualityHourlyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetAirQualityHourlyForecastsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetCurrentAirQualityTest()
        {
            var client = CreateClient();
            var options = new GetCurrentAirQualityOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetCurrentAirQualityAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetCurrentConditionsTest()
        {
            var client = CreateClient();
            var options = new GetCurrentConditionsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetCurrentConditionsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyForecastTest()
        {
            var client = CreateClient();
            var options = new GetDailyForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetDailyForecastAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalActualsTest()
        {
            var client = CreateClient();
            var options = new GetDailyHistoricalActualsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = await client.GetDailyHistoricalActualsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalNormalsTest()
        {
            var client = CreateClient();
            var options = new GetDailyHistoricalNormalsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = await client.GetDailyHistoricalNormalsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalRecordsTest()
        {
            var client = CreateClient();
            var options = new GetDailyHistoricalRecordsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = await client.GetDailyHistoricalRecordsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyIndicesTest()
        {
            var client = CreateClient();
            var options = new GetDailyIndicesOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetDailyIndicesAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetHourlyForecastTest()
        {
            var client = CreateClient();
            var options = new GetHourlyForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetHourlyForecastAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetMinuteForecastTest()
        {
            var client = CreateClient();
            var options = new GetMinuteForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetMinuteForecastAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetQuarterDayForecastTest()
        {
            var client = CreateClient();
            var options = new GetQuarterDayForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetQuarterDayForecastAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetSevereWeatherAlertsTest()
        {
            var client = CreateClient();
            var options = new GetSevereWeatherAlertsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = await client.GetSevereWeatherAlertsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormActiveTest()
        {
            var client = CreateClient();
            var response = await client.GetTropicalStormActiveAsync();
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormForecastTest()
        {
            var client = CreateClient();
            var options = new GetTropicalStormForecastOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = await client.GetTropicalStormForecastAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormLocationsTest()
        {
            var client = CreateClient();
            var options = new GetTropicalStormLocationsOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = await client.GetTropicalStormLocationsAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormSearchTest()
        {
            var client = CreateClient();
            var options = new GetTropicalStormSearchOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = await client.GetTropicalStormSearchAsync(options);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetWeatherAlongRouteTest()
        {
            var client = CreateClient();
            var response = await client.GetWeatherAlongRouteAsync(
                "25.033075,121.525694,0:25.0338053,121.5640089,2",
                WeatherLanguage.EnglishUsa
            );
            response.ToString();
            Assert.NotNull(response);
        }
    }
}

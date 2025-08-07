// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Core.TestFramework;
using Azure.Core.GeoJson;
using Azure.Maps.Weather.Models;
using Azure.Maps.Weather.Models.Options;
using NUnit.Framework;

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
            MapsWeatherClient client = CreateClient();
            GetAirQualityDailyForecastsOptions options = new GetAirQualityDailyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyAirQualityForecastResult> response = await client.GetAirQualityDailyForecastsAsync(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetAirQualityHourlyForecastsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetAirQualityHourlyForecastsOptions options = new GetAirQualityHourlyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<AirQualityResult> response = await client.GetAirQualityHourlyForecastsAsync(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetCurrentAirQualityTest()
        {
            MapsWeatherClient client = CreateClient();
            GetCurrentAirQualityOptions options = new GetCurrentAirQualityOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<AirQualityResult> response = await client.GetCurrentAirQualityAsync(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetCurrentWeatherConditionsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetCurrentWeatherConditionsOptions options = new GetCurrentWeatherConditionsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<CurrentConditionsResult> response = await client.GetCurrentWeatherConditionsAsync(options);
            Console.WriteLine("Temperature: " + response.Value.Results[0].Temperature.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyWeatherForecastTest()
        {
            MapsWeatherClient client = CreateClient();
            GetDailyWeatherForecastOptions options = new GetDailyWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyForecastResult> response = await client.GetDailyWeatherForecastAsync(options);
            Console.WriteLine("Minimum temperatrue: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperatrue: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalActualsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetDailyHistoricalActualsOptions options = new GetDailyHistoricalActualsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalActualsResult> response = await client.GetDailyHistoricalActualsAsync(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalActuals[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalActuals[0].Temperature.Maximum.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalNormalsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetDailyHistoricalNormalsOptions options = new GetDailyHistoricalNormalsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalNormalsResult> response = await client.GetDailyHistoricalNormalsAsync(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalNormals[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalNormals[0].Temperature.Maximum.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyHistoricalRecordsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetDailyHistoricalRecordsOptions options = new GetDailyHistoricalRecordsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalRecordsResult> response = await client.GetDailyHistoricalRecordsAsync(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalRecords[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalRecords[0].Temperature.Maximum.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetDailyIndicesTest()
        {
            MapsWeatherClient client = CreateClient();
            GetDailyIndicesOptions options = new GetDailyIndicesOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyIndicesResult> response = await client.GetDailyIndicesAsync(options);
            Console.WriteLine("Description: " + response.Value.Results[0].Description);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetHourlyWeatherForecastTest()
        {
            MapsWeatherClient client = CreateClient();
            GetHourlyWeatherForecastOptions options = new GetHourlyWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<HourlyForecastResult> response = await client.GetHourlyWeatherForecastAsync(options);
            Console.WriteLine("Temperature: " + response.Value.Forecasts[0].Temperature.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetMinuteWeatherForecastTest()
        {
            MapsWeatherClient client = CreateClient();
            GetMinuteWeatherForecastOptions options = new GetMinuteWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<MinuteForecastResult> response = await client.GetMinuteWeatherForecastAsync(options);
            Console.WriteLine("Summary: " + response.Value.Summary.LongPhrase);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetQuarterDayWeatherForecastTest()
        {
            MapsWeatherClient client = CreateClient();
            GetQuarterDayWeatherForecastOptions options = new GetQuarterDayWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<QuarterDayForecastResult> response = await client.GetQuarterDayWeatherForecastAsync(options);
            Console.WriteLine("Minimum temperature: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetSevereWeatherAlertsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetSevereWeatherAlertsOptions options = new GetSevereWeatherAlertsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<SevereWeatherAlertsResult> response = await client.GetSevereWeatherAlertsAsync(options);
            if (response.Value.Results.Count > 0) {
                Console.WriteLine("Description: " + response.Value.Results[0].Description);
            }
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormActiveTest()
        {
            MapsWeatherClient client = CreateClient();
            Response<ActiveStormResult> response = await client.GetTropicalStormActiveAsync();
            Console.WriteLine("Name: " + response.Value.ActiveStorms[0].Name);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormForecastTest()
        {
            MapsWeatherClient client = CreateClient();
            GetTropicalStormForecastOptions options = new GetTropicalStormForecastOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2,
                IncludeDetails = true,
                IncludeGeometricDetails = true
            };
            Response<StormForecastResult> response = await client.GetTropicalStormForecastAsync(options);
            if (response.Value.StormForecasts[0].WindRadiiSummary[0].RadiiGeometry is GeoPolygon geoPolygon) {
                Console.WriteLine("Geometry type: Polygon");
                for (int i = 0; i < geoPolygon.Coordinates[0].Count; ++i) {
                    Console.WriteLine("Point {0}: {1}", i, geoPolygon.Coordinates[0][i]);
                }
            }
            Console.WriteLine(
                "Wind speed: {0}{1}",
                response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.Value,
                response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.UnitLabel
            );
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormLocationsTest()
        {
            MapsWeatherClient client = CreateClient();
            GetTropicalStormLocationsOptions options = new GetTropicalStormLocationsOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2
            };
            Response<StormLocationsResult> response = await client.GetTropicalStormLocationsAsync(options);
            Console.WriteLine(
                "Coordinates(longitude, latitude): ({0}, {1})",
                response.Value.StormLocations[0].Coordinates.Longitude,
                response.Value.StormLocations[0].Coordinates.Latitude
            );
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetTropicalStormSearchTest()
        {
            MapsWeatherClient client = CreateClient();
            GetTropicalStormSearchOptions options = new GetTropicalStormSearchOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2
            };
            Response<StormSearchResult> response = await client.GetTropicalStormSearchAsync(options);
            Console.WriteLine("Name: " + response.Value.Storms[0].Name);
            Assert.NotNull(response);
        }

        [RecordedTest]
        public async Task GetWeatherAlongRouteTest()
        {
            MapsWeatherClient client = CreateClient();
            WeatherAlongRouteQuery query = new WeatherAlongRouteQuery()
            {
                Waypoints = new List<WeatherAlongRouteWaypoint> {
                    new WeatherAlongRouteWaypoint()
                    {
                        Coordinates = new GeoPosition(121.525694, 25.033075),
                        EtaInMinutes = 0,
                        Heading = 0
                    },
                    new WeatherAlongRouteWaypoint()
                    {
                        Coordinates = new GeoPosition(121.5640089, 25.0338053),
                        EtaInMinutes = 2,
                        Heading = 0
                    }
                }
            };
            Response<WeatherAlongRouteResult> response = await client.GetWeatherAlongRouteAsync(
                query,
                WeatherLanguage.EnglishUsa
            );
            Console.WriteLine("Temperature: " + response.Value.Waypoints[0].Temperature.Value);
            Assert.NotNull(response);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.GeoJson;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
using Azure.Maps.Weather.Models;
using Azure.Maps.Weather.Models.Options;
using NUnit.Framework;

namespace Azure.Maps.Weather.Tests.Samples
{
    public class WeatherClientSamples : SamplesBase<WeatherClientTestEnvironment>
    {
        public void WeatherClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateWeatherClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsWeatherClient client = new MapsWeatherClient(credential);
            #endregion
        }

        public void WeatherClientViaMicrosoftEntra()
        {
            #region Snippet:InstantiateWeatherClientViaMicrosoftEntra
            // Create a MapsWeatherClient that will authenticate through MicrosoftEntra
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string clientId = "<My Map Account Client Id>";
            MapsWeatherClient client = new MapsWeatherClient(credential, clientId);
            #endregion
        }

        public void WeatherClientViaSas()
        {
            #region Snippet:InstantiateWeatherClientViaSas
            // Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // Authenticate your client
            ArmClient armClient = new ArmClient(cred);

            string subscriptionId = "MyMapsSubscriptionId";
            string resourceGroupName = "MyMapsResourceGroupName";
            string accountName = "MyMapsAccountName";

            // Get maps account resource
            ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

            // Assign SAS token information
            // Every time you want to SAS token, update the principal ID, max rate, start and expiry time
            string principalId = "MyManagedIdentityObjectId";
            int maxRatePerSecond = 500;

            // Set start and expiry time for the SAS token in round-trip date/time format
            DateTime now = DateTime.Now;
            string start = now.ToString("O");
            string expiry = now.AddDays(1).ToString("O");

            MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
            Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

            // Create a WeatherClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsWeatherClient client = new MapsWeatherClient(sasCredential);
            #endregion
        }
        [Test]
        public void GetAirQualityDailyForecasts()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetAirQualityDailyForecasts
            GetAirQualityDailyForecastsOptions options = new GetAirQualityDailyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyAirQualityForecastResult> response = client.GetAirQualityDailyForecasts(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            #endregion
        }

        [Test]
        public void GetAirQualityHourlyForecasts()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetAirQualityHourlyForecasts
            GetAirQualityHourlyForecastsOptions options = new GetAirQualityHourlyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<AirQualityResult> response = client.GetAirQualityHourlyForecasts(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            #endregion
        }

        [Test]
        public void GetCurrentAirQuality()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetCurrentAirQuality
            GetCurrentAirQualityOptions options = new GetCurrentAirQualityOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<AirQualityResult> response = client.GetCurrentAirQuality(options);
            Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
            #endregion
        }

        [Test]
        public void GetCurrentWeatherConditions()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetCurrentWeatherConditions
            GetCurrentWeatherConditionsOptions options = new GetCurrentWeatherConditionsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<CurrentConditionsResult> response = client.GetCurrentWeatherConditions(options);
            Console.WriteLine("Temperature: " + response.Value.Results[0].Temperature.Value);
            #endregion
        }

        [Test]
        public void GetDailyWeatherForecast()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyWeatherForecast
            GetDailyWeatherForecastOptions options = new GetDailyWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyForecastResult> response = client.GetDailyWeatherForecast(options);
            Console.WriteLine("Minimum temperatrue: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperatrue: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
            #endregion
        }

        [Test]
        public void GetDailyHistoricalActuals()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalActuals
            GetDailyHistoricalActualsOptions options = new GetDailyHistoricalActualsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalActualsResult> response = client.GetDailyHistoricalActuals(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalActuals[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalActuals[0].Temperature.Maximum.Value);
            #endregion
        }

        [Test]
        public void GetDailyHistoricalNormals()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalNormals
            GetDailyHistoricalNormalsOptions options = new GetDailyHistoricalNormalsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalNormalsResult> response = client.GetDailyHistoricalNormals(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalNormals[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalNormals[0].Temperature.Maximum.Value);
            #endregion
        }

        [Test]
        public void GetDailyHistoricalRecords()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalRecords
            GetDailyHistoricalRecordsOptions options = new GetDailyHistoricalRecordsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            Response<DailyHistoricalRecordsResult> response = client.GetDailyHistoricalRecords(options);
            Console.WriteLine("Minimum temperature: " + response.Value.HistoricalRecords[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.HistoricalRecords[0].Temperature.Maximum.Value);
            #endregion
        }

        [Test]
        public void GetDailyIndices()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyIndices
            GetDailyIndicesOptions options = new GetDailyIndicesOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<DailyIndicesResult> response = client.GetDailyIndices(options);
            Console.WriteLine("Description: " + response.Value.Results[0].Description);
            #endregion
        }

        [Test]
        public void GetHourlyWeatherForecast()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetHourlyWeatherForecast
            GetHourlyWeatherForecastOptions options = new GetHourlyWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<HourlyForecastResult> response = client.GetHourlyWeatherForecast(options);
            Console.WriteLine("Temperature: " + response.Value.Forecasts[0].Temperature.Value);
            #endregion
        }

        [Test]
        public void GetMinuteWeatherForecast()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetMinuteWeatherForecast
            GetMinuteWeatherForecastOptions options = new GetMinuteWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<MinuteForecastResult> response = client.GetMinuteWeatherForecast(options);
            Console.WriteLine("Summary: " + response.Value.Summary.LongPhrase);
            #endregion
        }

        [Test]
        public void GetQuarterDayWeatherForecast()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetQuarterDayWeatherForecast
            GetQuarterDayWeatherForecastOptions options = new GetQuarterDayWeatherForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<QuarterDayForecastResult> response = client.GetQuarterDayWeatherForecast(options);
            Console.WriteLine("Minimum temperature: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
            Console.WriteLine("Maximum temperature: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
            #endregion
        }

        [Test]
        public void GetSevereWeatherAlerts()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetSevereWeatherAlerts
            GetSevereWeatherAlertsOptions options = new GetSevereWeatherAlertsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            Response<SevereWeatherAlertsResult> response = client.GetSevereWeatherAlerts(options);
            if (response.Value.Results.Count > 0)
            {
                Console.WriteLine("Description: " + response.Value.Results[0].Description);
            }
            #endregion
        }

        [Test]
        public void GetTropicalStormActive()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormActive
            Response<ActiveStormResult> response = client.GetTropicalStormActive();
            if (response.Value.ActiveStorms.Count > 0)
            {
                Console.WriteLine("Name: " + response.Value.ActiveStorms[0].Name);
            }
            else
            {
                Console.WriteLine("No active storm");
            }
            #endregion
        }

        [Test]
        public void GetTropicalStormForecast()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormForecast
            GetTropicalStormForecastOptions options = new GetTropicalStormForecastOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2,
                IncludeDetails = true,
                IncludeGeometricDetails = true
            };
            Response<StormForecastResult> response = client.GetTropicalStormForecast(options);

            if (response.Value.StormForecasts.Count == 0)
            {
                Console.WriteLine("No storm forecast found.");
                return;
            }

            if (response.Value.StormForecasts[0].WindRadiiSummary[0].RadiiGeometry is GeoPolygon geoPolygon)
            {
                Console.WriteLine("Geometry type: Polygon");
                for (int i = 0; i < geoPolygon.Coordinates[0].Count; ++i)
                {
                    Console.WriteLine("Point {0}: {1}", i, geoPolygon.Coordinates[0][i]);
                }
            }

            Console.WriteLine(
                "Windspeed: {0}{1}",
                response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.Value,
                response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.UnitLabel
            );
            #endregion
        }

        [Test]
        public void GetTropicalStormLocations()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormLocations
            GetTropicalStormLocationsOptions options = new GetTropicalStormLocationsOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2
            };
            Response<StormLocationsResult> response = client.GetTropicalStormLocations(options);
            if (response.Value.StormLocations.Count > 0)
            {
                Console.WriteLine(
                    "Coordinates(longitude, latitude): ({0}, {1})",
                    response.Value.StormLocations[0].Coordinates.Longitude,
                    response.Value.StormLocations[0].Coordinates.Latitude
                );
            }
            else
            {
                Console.WriteLine("No storm location found.");
            }
            #endregion
        }

        [Test]
        public void GetTropicalStormSearch()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormSearch
            GetTropicalStormSearchOptions options = new GetTropicalStormSearchOptions()
            {
                Year = 2021,
                BasinId = BasinId.NP,
                GovernmentStormId = 2
            };
            Response<StormSearchResult> response = client.GetTropicalStormSearch(options);
            if (response.Value.Storms.Count > 0)
            {
                Console.WriteLine("Name: " + response.Value.Storms[0].Name);
            }
            else
            {
                Console.WriteLine("No storm found.");
            }
            #endregion
        }

        [Test]
        public void GetWeatherAlongRoute()
        {
            MapsWeatherClientOptions clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            string clientId = TestEnvironment.MapAccountClientId;
            MapsWeatherClient client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetWeatherAlongRoute
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
            Response<WeatherAlongRouteResult> response = client.GetWeatherAlongRoute(
                query,
                WeatherLanguage.EnglishUsa
            );
            if (response.Value.Waypoints.Count > 0)
            {
                Console.WriteLine("Temperature of waypoints 0: " + response.Value.Waypoints[0].Temperature.Value);
            }
            else
            {
                Console.WriteLine("No weather information found.");
            }
            #endregion
        }
    }
}

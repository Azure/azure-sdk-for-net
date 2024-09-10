// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maps.Models;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager;
using NUnit.Framework;
using Azure.Maps.Weather.Models.Options;
using Azure.Maps.Weather.Models;
using Azure.Maps.Weather;
using System.Collections.Generic;
using Azure.Core.GeoJson;

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

        public void GetAirQualityDailyForecasts()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetAirQualityDailyForecasts
            var options = new GetAirQualityDailyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetAirQualityDailyForecasts(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetAirQualityHourlyForecasts()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetAirQualityHourlyForecasts
            var options = new GetAirQualityHourlyForecastsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetAirQualityHourlyForecasts(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetCurrentAirQuality()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetCurrentAirQuality
            var options = new GetCurrentAirQualityOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetCurrentAirQuality(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetCurrentConditions()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetCurrentConditions
            var options = new GetCurrentConditionsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetCurrentConditions(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetDailyForecast()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyForecast
            var options = new GetDailyForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetDailyForecast(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetDailyHistoricalActuals()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalActuals
            var options = new GetDailyHistoricalActualsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = client.GetDailyHistoricalActuals(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetDailyHistoricalNormals()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalNormals
            var options = new GetDailyHistoricalNormalsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = client.GetDailyHistoricalNormals(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetDailyHistoricalRecords()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyHistoricalRecords
            var options = new GetDailyHistoricalRecordsOptions()
            {
                Coordinates = new GeoPosition(-73.961968, 40.760139),
                StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
                EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
            };
            var response = client.GetDailyHistoricalRecords(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetDailyIndices()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetDailyIndices
            var options = new GetDailyIndicesOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetDailyIndices(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetHourlyForecast()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetHourlyForecast
            var options = new GetHourlyForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetHourlyForecast(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetMinuteForecast()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetMinuteForecast
            var options = new GetMinuteForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetMinuteForecast(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetQuarterDayForecast()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetQuarterDayForecast
            var options = new GetQuarterDayForecastOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetQuarterDayForecast(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetSevereWeatherAlerts()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetSevereWeatherAlerts
            var options = new GetSevereWeatherAlertsOptions()
            {
                Coordinates = new GeoPosition(121.5640089, 25.0338053),
                Language = WeatherLanguage.EnglishUsa
            };
            var response = client.GetSevereWeatherAlerts(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetTropicalStormActive()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormActive
            var response = client.GetTropicalStormActive();
            #endregion
        }

        public void GetTropicalStormForecast()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormForecast
            var options = new GetTropicalStormForecastOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = client.GetTropicalStormForecast(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetTropicalStormLocations()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormLocations
            var options = new GetTropicalStormLocationsOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = client.GetTropicalStormLocations(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetTropicalStormSearch()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTropicalStormSearch
            var options = new GetTropicalStormSearchOptions()
            {
                Year = 2021,
                BasinId = "NP",
                GovernmentStormId = 2
            };
            var response = client.GetTropicalStormSearch(options);
            Console.WriteLine(response);
            #endregion
        }

        public void GetWeatherAlongRoute()
        {
            var clientOptions = new MapsWeatherClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsWeatherClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetWeatherAlongRoute
            var response = client.GetWeatherAlongRoute(
                "25.033075,121.525694,0:25.0338053,121.5640089,2",
                WeatherLanguage.EnglishUsa
            );
            response.ToString();
            #endregion
        }
    }
}

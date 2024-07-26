// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maps.Models;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager;
using NUnit.Framework;
using Azure.Maps.TimeZone.Models.Options;
using Azure.Maps.TimeZone.Models;
using Azure.Maps.TimeZone;
using System.Collections.Generic;
using Azure.Core.GeoJson;

namespace Azure.Maps.TimeZone.Tests.Samples
{
    public class TimeZoneClientSamples : SamplesBase<TimeZoneClientTestEnvironment>
    {
        public void TimeZoneClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateTimeZoneClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsTimeZoneClient client = new MapsTimeZoneClient(credential);
            #endregion
        }

        public void TimeZoneClientViaMicrosoftEntra()
        {
            #region Snippet:InstantiateTimeZoneClientViaMicrosoftEntra
            // Create a MapsTimeZoneClient that will authenticate through MicrosoftEntra
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string clientId = "<My Map Account Client Id>";
            MapsTimeZoneClient client = new MapsTimeZoneClient(credential, clientId);
            #endregion
        }

        public void TimeZoneClientViaSas()
        {
            #region Snippet:InstantiateTimeZoneClientViaSas
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

            // Create a TimeZoneClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsTimeZoneClient client = new MapsTimeZoneClient(sasCredential);
            #endregion
        }

        [Test]
        public void GetTimeZoneById()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTimeZoneById
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            options.Options = TimeZoneOptions.All;
            Response<TimeZoneInformation> response = client.GetTimeZoneByID("Asia/Bahrain", options);
            Console.WriteLine("Version: " + response.Value.Version);
            Console.WriteLine("Countires: " + response.Value.TimeZones[0].Countries);
            #endregion
        }

        [Test]
        public void GetTimeZoneByCoordinates()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTimeZoneByCoordinates
            TimeZoneBaseOptions options = new TimeZoneBaseOptions();
            options.Options = TimeZoneOptions.All;
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            Response<TimeZoneInformation> response =  client.GetTimeZoneByCoordinates(coordinates, options);
            Console.WriteLine("Names: " + response.Value.TimeZones[0].Names);
            #endregion
        }

        [Test]
        public void GetWindowsTimeZoneIds()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetWindowsTimeZoneIds
            Response<IReadOnlyList<TimeZoneWindows>> response = client.GetWindowsTimeZoneIds();
            Console.WriteLine("Count: " + response.Value.Count);
            Console.WriteLine("WindowsId: " + response.Value[0].WindowsId);
            Console.WriteLine("Territory: " + response.Value[0].Territory);
            #endregion
        }

        [Test]
        public void GetIanaTimeZoneIds()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetIanaTimeZoneIds
            Response<IReadOnlyList<IanaId>> response = client.GetIanaTimeZoneIds();
            Console.WriteLine("IsAlias: " + response.Value[0].IsAlias);
            Console.WriteLine("Id: " + response.Value[0].Id);
            #endregion
        }

        [Test]
        public void GetIanaVersion()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetIanaVersion
            Response<TimeZoneIanaVersionResult> response = client.GetIanaVersion();
            Console.WriteLine("Version: " + response.Value.Version);
            #endregion
        }

        [Test]
        public void ConvertWindowsTimeZoneToIana()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:ConvertWindowsTimeZoneToIana
            Response<IReadOnlyList<IanaId>> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
            Console.WriteLine("Id: " + response.Value[0].Id);
            #endregion
        }
    }
}

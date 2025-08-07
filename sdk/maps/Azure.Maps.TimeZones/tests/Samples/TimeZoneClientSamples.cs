// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
#region Snippet:TimeZoneImportNamespaces
using Azure.Maps.TimeZones;
#endregion
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
using NUnit.Framework;

namespace Azure.Maps.TimeZones.Tests.Samples
{
    public class TimeZoneClientSamples : SamplesBase<TimeZoneClientTestEnvironment>
    {
        public void TimeZoneClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateTimeZoneClientViaSubscriptionKey
            // Create a MapsTimeZoneClient that will authenticate through Subscription Key (Shared key)
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

            // Create a MapsTimeZoneClient that will authenticate via SAS token
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
            GetTimeZoneOptions options = new GetTimeZoneOptions()
            {
                AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
            };
            Response<TimeZoneResult> response = client.GetTimeZoneById("Asia/Bahrain", options);
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
            GetTimeZoneOptions options = new GetTimeZoneOptions()
            {
                AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
            };
            GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
            Response<TimeZoneResult> response = client.GetTimeZoneByCoordinates(coordinates, options);

            Console.WriteLine("Time zone for (latitude, longitude) = ({0}, {1}) is {2}: ",
                coordinates.Latitude, coordinates.Longitude,
                response.Value.TimeZones[0].Name.Generic);
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
            Response<WindowsTimeZoneData> response = client.GetWindowsTimeZoneIds();
            Console.WriteLine("Total time zones: " + response.Value.WindowsTimeZones.Count);
            foreach (WindowsTimeZone timeZone in response.Value.WindowsTimeZones)
            {
                Console.WriteLine("IANA Id: " + timeZone.IanaIds);
                Console.WriteLine("Windows ID: " + timeZone.WindowsId);
                Console.WriteLine("Territory: " + timeZone.Territory);
            }
            #endregion
        }

        [Test]
        public void GetTimeZoneIanaIds()
        {
            var clientOptions = new MapsTimeZoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimeZoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTimeZoneIanaIds
            Response<IanaIdData> response = client.GetTimeZoneIanaIds();
            if (response.Value.IanaIds[0].AliasOf != null)
            {
                Console.WriteLine("It is an alias: " + response.Value.IanaIds[0].AliasOf);
            }
            else
            {
                Console.WriteLine("It is not an alias");
            }
            Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
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
            Console.WriteLine("IANA Version: " + response.Value.Version);
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
            Response<IanaIdData> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
            Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
            #endregion
        }
    }
}

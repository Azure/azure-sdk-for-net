// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Maps.Models;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager;
using NUnit.Framework;
using Azure.Maps.Timezone.Models.Options;
using System.Collections.Generic;

namespace Azure.Maps.Timezone.Tests.Samples
{
    public class TimezoneClientSamples : SamplesBase<TimezoneClientTestEnvironment>
    {
        public void TimezoneClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateTimezoneClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsTimezoneClient client = new MapsTimezoneClient(credential);
            #endregion
        }

        public void TimezoneClientViaMicrosoftEntra()
        {
            #region Snippet:InstantiateTimezoneClientViaMicrosoftEntra
            // Create a MapsTimezoneClient that will authenticate through MicrosoftEntra
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string clientId = "<My Map Account Client Id>";
            MapsTimezoneClient client = new MapsTimezoneClient(credential, clientId);
            #endregion
        }

        public void TimezoneClientViaSas()
        {
            #region Snippet:InstantiateTimezoneClientViaSas
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

            // Create a TimezoneClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsTimezoneClient client = new MapsTimezoneClient(sasCredential);
            #endregion
        }

        [Test]
        public void GetTimezoneById()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTimezoneById
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            options.Options = TimezoneOptions.All;
            var response = client.GetTimezoneByID("Asia/Bahrain", options);
            Console.WriteLine(response);
            #endregion
        }

        [Test]
        public void GetTimezoneByCoordinates()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetTimezoneByCoordinates
            TimezoneBaseOptions options = new TimezoneBaseOptions();
            options.Options = TimezoneOptions.All;
            IList<double> coordinates = new[] { 25.0338053, 121.5640089 };
            var response =  client.GetTimezoneByCoordinates(coordinates, options);
            Console.WriteLine(response);
            #endregion
        }

        [Test]
        public void GetWindowsTimezoneIds()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetWindowsTimezoneIds
            var response = client.GetWindowsTimezoneIds();
            Console.WriteLine(response);
            #endregion
        }

        [Test]
        public void GetIanaTimezoneIds()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetIanaTimezoneIds
            var response = client.GetIanaTimezoneIds();
            Console.WriteLine(response);
            #endregion
        }

        [Test]
        public void GetIanaVersion()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetIanaVersion
            var response = client.GetIanaVersion();
            Console.WriteLine(response);
            #endregion
        }

        [Test]
        public void ConvertWindowsTimezoneToIana()
        {
            var clientOptions = new MapsTimezoneClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsTimezoneClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:ConvertWindowsTimezoneToIana
            var response = client.ConvertWindowsTimezoneToIana("Dateline Standard Time");
            Console.WriteLine(response);
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:GeolocationSasAuthImportNamespaces
using Azure.Maps.Geolocation;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
#endregion

namespace Azure.Maps.Geolocation.Tests
{
    public class GeolocationClientSamples : SamplesBase<GeolocationClientTestEnvironment>
    {
        public void GeolocationClientViaAAD()
        {
            #region Snippet:InstantiateGeolocationClientViaAAD
            // Create a MapsGeolocationClient that will authenticate through Active Directory
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);
            #endregion
        }

        public void GeolocationClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateGeolocationClientViaSubscriptionKey
            // Create a MapsGeolocationClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsGeolocationClient client = new MapsGeolocationClient(credential);
            #endregion
        }

        public void GeolocationClientViaSas()
        {
            #region Snippet:InstantiateGeolocationClientViaSas
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

            // Create a SearchClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsGeolocationClient client = new MapsGeolocationClient(sasCredential);
            #endregion
        }

        [Test]
        public void GetCountryCodeTest()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:GetCountryCode
            //Get location by given IP address
            IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
            Response<CountryRegionResult> result = client.GetCountryCode(ipAddress);

            //Get location result country code
            Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
            #endregion

            Assert.IsTrue(result.Value.IsoCode == "US");
        }

        [Test]
        public void GetCountryCodeError()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:CatchGeolocationException
            try
            {
                // An invalid IP address
                IPAddress inValidIpAddress = IPAddress.Parse("2001:4898:80e8:b:123123213123");

                Response<CountryRegionResult> result = client.GetCountryCode(inValidIpAddress);
                // Do something with result ...
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}

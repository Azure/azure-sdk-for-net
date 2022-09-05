// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
#region Snippet:GeolocationImportNamespace
using Azure.Maps.Geolocation;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;

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
            TokenCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsGeolocationClient client = new MapsGeolocationClient(credential);
            #endregion
        }

        [Test]
        public void GetLocationTest()
        {
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:GetLocation
            //Get location by given IP address
            string ipAddress = "2001:4898:80e8:b::189";
            string result = client.GetLocation(ipAddress);

            //Get location result country code
            Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
            #endregion

            Assert.IsTrue(result.Value.IsoCode == "US");
        }

        [Test]
        public void GetGeolocationDirectionsError()
        {
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:CatchGeolocationException
            try
            {
                // An invalid IP address
                string inValidIpAddress = "xxx";

                string result = client.GetLocation(inValidIpAddress);
                // Do something with result ...
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }
    }
}

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
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);
            #endregion
        }

        public void GeolocationClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateGeolocationClientViaSubscriptionKey
            // Create a MapsGeolocationClient that will authenticate through Subscription Key (Shared key)
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsGeolocationClient client = new MapsGeolocationClient(credential);
            #endregion
        }

        [Test]
        public void GetLocationTest()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:GetLocation
            //Get location by given IP address
            var ipAddress = "2001:4898:80e8:b::189";
            var result = client.GetLocation(ipAddress);

            //Get location result country code
            Console.WriteLine($"Country code results by given IP Address: {0}", result.Value.IsoCode);
            #endregion

            Assert.IsTrue(result.Value.IsoCode == "US");
        }

        [Test]
        public void GetGeolocationDirectionsError()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsGeolocationClient(credential, clientId);

            #region Snippet:CatchGeolocationException
            try
            {
                // An invalid IP address
                var inValidIpAddress = "xxx";

                var result = client.GetLocation(inValidIpAddress);
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

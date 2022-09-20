// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core;
using Azure.Maps.GeoLocation;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.GeoLocation.Tests
{
    public class GeoLocationClientSamples : SamplesBase<GeoLocationClientTestEnvironment>
    {
        public void GeoLocationClientViaAAD()
        {
            #region Snippet:InstantiateGeoLocationClientViaAAD
            // Create a MapsGeoLocationClient that will authenticate through Active Directory
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsGeoLocationClient client = new MapsGeoLocationClient(credential, clientId);
            #endregion
        }

        public void GeoLocationClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateGeoLocationClientViaSubscriptionKey
            // Create a MapsGeoLocationClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsGeoLocationClient client = new MapsGeoLocationClient(credential);
            #endregion
        }

        [Test]
        public void GetLocationTest()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeoLocationClient client = new MapsGeoLocationClient(credential, clientId);

            #region Snippet:GetLocation
            //Get location by given IP address
            string ipAddress = "2001:4898:80e8:b::189";
            Response<IpAddressToLocationResult> result = client.GetLocation(ipAddress);

            //Get location result country code
            Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
            #endregion

            Assert.IsTrue(result.Value.IsoCode == "US");
        }

        [Test]
        public void GetGeoLocationDirectionsError()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsGeoLocationClient client = new MapsGeoLocationClient(credential, clientId);

            #region Snippet:CatchGeoLocationException
            try
            {
                // An invalid IP address
                string inValidIpAddress = "xxx";

                Response<IpAddressToLocationResult> result = client.GetLocation(inValidIpAddress);
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

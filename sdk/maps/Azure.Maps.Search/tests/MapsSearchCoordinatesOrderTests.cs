// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    /// <summary>
    /// Offline tests verifying that the <c>coordinates</c> query parameter is sent as
    /// <c>lon,lat</c>, as required by the Azure Maps Search service.
    /// </summary>
    public class MapsSearchCoordinatesOrderTests
    {
        // Longitude and latitude are intentionally different so a swap is detectable.
        private const double Longitude = -122.13;
        private const double Latitude = 47.64;
        private const string ExpectedCoordinates = "coordinates=-122.13,47.64";

        private static MapsSearchClient CreateClient(MockTransport transport)
        {
            var options = new MapsSearchClientOptions { Transport = transport };
            return new MapsSearchClient(new AzureKeyCredential("fake-key"), options);
        }

        private static MockTransport CreateTransport() =>
            new MockTransport(new MockResponse(200).SetContent("{\"type\":\"FeatureCollection\",\"features\":[]}"));

        private static string GetRequestQuery(MockTransport transport)
        {
            Assert.AreEqual(1, transport.Requests.Count);
            return Uri.UnescapeDataString(transport.Requests[0].Uri.Query);
        }

        [Test]
        public async Task GetGeocodingAsyncSendsCoordinatesAsLongitudeLatitude()
        {
            var transport = CreateTransport();
            var client = CreateClient(transport);

            await client.GetGeocodingAsync("Redmond", new GeocodingQuery { Coordinates = new GeoPosition(Longitude, Latitude) });

            StringAssert.Contains(ExpectedCoordinates, GetRequestQuery(transport));
        }

        [Test]
        public void GetGeocodingSendsCoordinatesAsLongitudeLatitude()
        {
            var transport = CreateTransport();
            var client = CreateClient(transport);

            client.GetGeocoding("Redmond", new GeocodingQuery { Coordinates = new GeoPosition(Longitude, Latitude) });

            StringAssert.Contains(ExpectedCoordinates, GetRequestQuery(transport));
        }

        [Test]
        public async Task GetPolygonAsyncSendsCoordinatesAsLongitudeLatitude()
        {
            var transport = CreateTransport();
            var client = CreateClient(transport);

            try
            {
                await client.GetPolygonAsync(new GetPolygonOptions { Coordinates = new GeoPosition(Longitude, Latitude) });
            }
            catch (Exception)
            {
                // The canned response is not a valid boundary; only the outgoing request is under test.
            }

            StringAssert.Contains(ExpectedCoordinates, GetRequestQuery(transport));
        }
    }
}

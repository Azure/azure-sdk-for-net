using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.Management;
using Microsoft.AzureStack.Management.Models;
using Xunit;

namespace AzureStackAdmin.Tests
{
    public class LocationTests
    {
        public AzureStackClient GetAzureStackAdminClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new AzureStackClient(new Uri("https://armuri"), token, "2015-11-01").WithHandler(handler);
        }

        [Fact]
        public void GetLocation()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7b9e2b97-c218-4577-9582-6f390d5cd2e7/providers/Microsoft.Subscriptions.Admin/locations/chicago',
                    'name': 'chicago',
                    'displayName': 'chicago',
                    'latitude': '80.5',
                    'longitude': '-45.5'
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedLocations.Get("chicago");
            
            // Validate Headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("chicago", result.Location.Name);
            Assert.Equal("-45.5", result.Location.Longitude);
            Assert.Equal("80.5", result.Location.Latitude);
            Assert.Equal("chicago", result.Location.DisplayName);
        }

        [Fact]
        public void CreateOrUpdateLocation()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7b9e2b97-c218-4577-9582-6f390d5cd2e7/providers/Microsoft.Subscriptions.Admin/locations/chicago',
                    'name': 'chicago',
                    'displayName': 'chicago',
                    'latitude': '80.5',
                    'longitude': '-45.5'
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedLocations.CreateOrUpdate(
                        new ManagedLocationCreateOrUpdateParameters()
                        {
                            Location = new Location()
                                       {
                                           Name = "chicago",
                                           DisplayName = "chicago",
                                           Latitude = "80.5",
                                           Longitude = "-45.5"
                                       }
                        }                
            );

            // Validate Headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("chicago", result.Location.Name);
            Assert.Equal("-45.5", result.Location.Longitude);
            Assert.Equal("80.5", result.Location.Latitude);
            Assert.Equal("chicago", result.Location.DisplayName);
        }

        [Fact]
        public void DeleteLocation()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedLocations.Delete("chicago");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}

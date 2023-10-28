using System.Net;
using Azure;
using Azure.Maps.Geolocation;
using NUnit.Framework;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string key = Environment.GetEnvironmentVariable("AZURE_MAPS_API_KEY");
AzureKeyCredential credential = new AzureKeyCredential(key);
MapsGeolocationClient client = new MapsGeolocationClient(credential);
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
CountryRegionResult result = client.GetCountryCode(ipAddress);


Assert.AreEqual("US", result.IsoCode);

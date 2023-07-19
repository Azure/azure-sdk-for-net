# Get Location Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation#getting-started) for details.

## Get Location with IP Address

The sample below returns the for the provided IP address:

```C# Snippet:GetCountryCode
//Get location by given IP address
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
Response<CountryRegionResult> result = client.GetCountryCode(ipAddress);

//Get location result country code
Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
```

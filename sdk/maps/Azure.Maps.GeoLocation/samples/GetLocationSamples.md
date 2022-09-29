# Get Location Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.GeoLocation#getting-started) for details.

## Get Location with IP Address

The sample below returns the for the provided IP address:

```C# Snippet:GetLocation
//Get location by given IP address
string ipAddress = "2001:4898:80e8:b::189";
Response<IpAddressToLocationResult> result = client.GetLocation(ipAddress);

//Get location result country code
Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
```

## Examples

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Timezone/samples). 

### Get Timezone By ID

```C# Snippet:GetTimezoneById
TimezoneBaseOptions options = new TimezoneBaseOptions();
options.Options = TimezoneOptions.All;
var response = client.GetTimezoneByID("Asia/Bahrain", options);
Console.WriteLine(response);
```

### Get Timezone By Coordinates

```C# Snippet:GetTimezoneByCoordinates
TimezoneBaseOptions options = new TimezoneBaseOptions();
options.Options = TimezoneOptions.All;
GeoPosition coordinates = new GeoPosition(25.0338053, 121.5640089);
var response =  client.GetTimezoneByCoordinates(coordinates, options);
Console.WriteLine(response);
```

### Get Windows Timezone Ids

```C# Snippet:GetWindowsTimezoneIds
var response = client.GetWindowsTimezoneIds();
Console.WriteLine(response);
```

### Get Iana Timezone Ids

```C# Snippet:GetIanaTimezoneIds
var response = client.GetIanaTimezoneIds();
Console.WriteLine(response);
```

### Get Iana Version

```C# Snippet:GetIanaVersion
var response = client.GetIanaVersion();
Console.WriteLine(response);
```

### Convert Windows Timezone To Iana

```C# Snippet:ConvertWindowsTimezoneToIana
var response = client.ConvertWindowsTimezoneToIana("Dateline Standard Time");
Console.WriteLine(response);
```

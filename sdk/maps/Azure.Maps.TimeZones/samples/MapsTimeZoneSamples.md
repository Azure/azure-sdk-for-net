using Azure.Maps.TimeZones;


## Examples


### Get TimeZone By ID

```C# Snippet:GetTimeZoneById
GetTimeZoneOptions options = new GetTimeZoneOptions()
{
    AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
};
Response<TimeZoneResult> response = client.GetTimeZoneById("Asia/Bahrain", options);
Console.WriteLine("Version: " + response.Value.Version);
Console.WriteLine("Countires: " + response.Value.TimeZones[0].Countries);
```

### Get TimeZone By Coordinates

```C# Snippet:GetTimeZoneByCoordinates
GetTimeZoneOptions options = new GetTimeZoneOptions()
{
    AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
};
GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
Response<TimeZoneResult> response =  client.GetTimeZoneByCoordinates(coordinates, options);

Console.WriteLine("Time zone for (latitude, longitude) = ({0}, {1}) is {2}: ",
    coordinates.Latitude, coordinates.Longitude,
    response.Value.TimeZones[0].Name.Generic);
```

### Get Windows TimeZone Ids

```C# Snippet:GetWindowsTimeZoneIds
Response<WindowsTimeZoneData> response = client.GetWindowsTimeZoneIds();
Console.WriteLine("Total time zones: " + response.Value.WindowsTimeZones.Count);
foreach (WindowsTimeZone timeZone in response.Value.WindowsTimeZones)
{
    Console.WriteLine("IANA Id: " + timeZone.IanaIds);
    Console.WriteLine("Windows ID: " + timeZone.WindowsId);
    Console.WriteLine("Territory: " + timeZone.Territory);
}
```

### Get Iana TimeZone Ids

```C# Snippet:GetTimeZoneIanaIds
Response<IReadOnlyList<IanaId>> response = client.GetTimeZoneIanaIds();
if (response.Value[0].Alias != null)
{
    Console.WriteLine("It is an alias: " + response.Value[0].Alias);
}
else
{
    Console.WriteLine("It is not an alias");
}
Console.WriteLine("IANA Id: " + response.Value[0].Id);
```

### Get Iana Version

```C# Snippet:GetIanaVersion
Response<TimeZoneIanaVersionResult> response = client.GetIanaVersion();
Console.WriteLine("IANA Version: " + response.Value.Version);
```

### Convert Windows TimeZone To Iana

```C# Snippet:ConvertWindowsTimeZoneToIana
Response<IReadOnlyList<IanaId>> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
Console.WriteLine("IANA Id: " + response.Value[0].Id);
```

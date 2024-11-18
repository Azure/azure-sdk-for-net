using Azure.Maps.TimeZone;


## Examples


### Get TimeZone By ID

```C# Snippet:GetTimeZoneById
TimeZoneBaseOptions options = new TimeZoneBaseOptions();
options.Options = TimeZoneOptions.All;
Response<TimeZoneInformation> response = client.GetTimeZoneByID("Asia/Bahrain", options);
Console.WriteLine("Version: " + response.Value.Version);
Console.WriteLine("Countires: " + response.Value.TimeZones[0].Countries);
```

### Get TimeZone By Coordinates

```C# Snippet:GetTimeZoneByCoordinates
TimeZoneBaseOptions options = new TimeZoneBaseOptions();
options.Options = TimeZoneOptions.All;
GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
Response<TimeZoneInformation> response =  client.GetTimeZoneByCoordinates(coordinates, options);
Console.WriteLine("Names: " + response.Value.TimeZones[0].Names);
```

### Get Windows TimeZone Ids

```C# Snippet:GetWindowsTimeZoneIds
Response<IReadOnlyList<TimeZoneWindows>> response = client.GetWindowsTimeZoneIds();
Console.WriteLine("Count: " + response.Value.Count);
Console.WriteLine("WindowsId: " + response.Value[0].WindowsId);
Console.WriteLine("Territory: " + response.Value[0].Territory);
```

### Get Iana TimeZone Ids

```C# Snippet:GetIanaTimeZoneIds
Response<IReadOnlyList<IanaId>> response = client.GetIanaTimeZoneIds();
Console.WriteLine("IsAlias: " + response.Value[0].IsAlias);
Console.WriteLine("Id: " + response.Value[0].Id);
```

### Get Iana Version

```C# Snippet:GetIanaVersion
Response<TimeZoneIanaVersionResult> response = client.GetIanaVersion();
Console.WriteLine("Version: " + response.Value.Version);
```

### Convert Windows TimeZone To Iana

```C# Snippet:ConvertWindowsTimeZoneToIana
Response<IReadOnlyList<IanaId>> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
Console.WriteLine("Id: " + response.Value[0].Id);
```

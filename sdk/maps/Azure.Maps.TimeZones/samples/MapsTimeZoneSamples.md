# TimeZone Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.TimeZones#getting-started) for details.

## Import the namespaces

```C# Snippet:TimeZoneImportNamespaces
using Azure.Maps.TimeZones;
```

## Create TimeZone Client

Before searching addresses, create a `MapsTimeZoneClient` first. Either use subscription key, Microsoft Entra or SAS token for authentication.

Instantiate time zone client with subscription key:

```C# Snippet:InstantiateTimeZoneClientViaSubscriptionKey
// Create a MapsTimeZoneClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsTimeZoneClient client = new MapsTimeZoneClient(credential);
```

Instantiate route client via Microsoft Entra authentication:

```C# Snippet:InstantiateTimeZoneClientViaMicrosoftEntra
// Create a MapsTimeZoneClient that will authenticate through MicrosoftEntra
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsTimeZoneClient client = new MapsTimeZoneClient(credential, clientId);
```

Instantiate time zone client with SAS token:

```C# Snippet:InstantiateTimeZoneClientViaSas
// Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
TokenCredential cred = new DefaultAzureCredential();
// Authenticate your client
ArmClient armClient = new ArmClient(cred);

string subscriptionId = "MyMapsSubscriptionId";
string resourceGroupName = "MyMapsResourceGroupName";
string accountName = "MyMapsAccountName";

// Get maps account resource
ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

// Assign SAS token information
// Every time you want to SAS token, update the principal ID, max rate, start and expiry time
string principalId = "MyManagedIdentityObjectId";
int maxRatePerSecond = 500;

// Set start and expiry time for the SAS token in round-trip date/time format
DateTime now = DateTime.Now;
string start = now.ToString("O");
string expiry = now.AddDays(1).ToString("O");

MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

// Create a MapsTimeZoneClient that will authenticate via SAS token
AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
MapsTimeZoneClient client = new MapsTimeZoneClient(sasCredential);
```

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
Response<TimeZoneResult> response = client.GetTimeZoneByCoordinates(coordinates, options);

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
Response<IanaIdData> response = client.GetTimeZoneIanaIds();
if (response.Value.IanaIds[0].AliasOf != null)
{
    Console.WriteLine("It is an alias: " + response.Value.IanaIds[0].AliasOf);
}
else
{
    Console.WriteLine("It is not an alias");
}
Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
```

### Get Iana Version

```C# Snippet:GetIanaVersion
Response<TimeZoneIanaVersionResult> response = client.GetIanaVersion();
Console.WriteLine("IANA Version: " + response.Value.Version);
```

### Convert Windows TimeZone To Iana

```C# Snippet:ConvertWindowsTimeZoneToIana
Response<IanaIdData> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
```

# Azure Maps Weather client library for .NET

Azure Maps Weather is a library which contains Azure Maps Weather APIs.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://learn.microsoft.com/rest/api/maps/weather) | [Product documentation](https://learn.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Weather --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 3  ways to authenticate the client: Shared key authentication, Microsoft Entra and Shared Access Signature (SAS) Authentication.

#### Shared Key authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key authentication** section

```C# Snippet:InstantiateWeatherClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsWeatherClient client = new MapsWeatherClient(credential);
```

#### Microsoft Entra authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsWeatherClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Microsoft Entra support for authenticating Azure SDK clients with their corresponding Azure services.

To use Microsoft Entra authentication, the environment variables as described in the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and create a `DefaultAzureCredential` instance to use with the `MapsWeatherClient`.

We also need an **Azure Maps Client ID** which can be found on the Azure Maps page > Authentication tab > "Client ID" in Microsoft Entra Authentication section.

```C# Snippet:InstantiateWeatherClientViaMicrosoftEntra
// Create a MapsWeatherClient that will authenticate through MicrosoftEntra
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsWeatherClient client = new MapsWeatherClient(credential, clientId);
```

#### Shared Access Signature (SAS) Authentication

Shared access signature (SAS) tokens are authentication tokens created using the JSON Web token (JWT) format and are cryptographically signed to prove authentication for an application to the Azure Maps REST API.

Before integrating SAS token authentication, we need to install `Azure.ResourceManager` and `Azure.ResourceManager.Maps` (version `1.1.0-beta.2` or higher):

```powershell
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Maps --prerelease
```


And then we can get SAS token via [List Sas](https://learn.microsoft.com/rest/api/maps-management/accounts/list-sas?tabs=HTTP) API and assign it to `MapsWeatherClient`. In the follow code sample, we fetch a specific maps account resource, and create a SAS token for 1 day expiry time when the code is executed.

```C# Snippet:InstantiateWeatherClientViaSas
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

// Create a WeatherClient that will authenticate via SAS token
AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
MapsWeatherClient client = new MapsWeatherClient(sasCredential);
```

## Key concepts

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather/samples).

### Get Air Quality Daily Forecasts

```C# Snippet:GetAirQualityDailyForecasts
GetAirQualityDailyForecastsOptions options = new GetAirQualityDailyForecastsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<DailyAirQualityForecastResult> response = client.GetAirQualityDailyForecasts(options);
Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
```
### Get Air Quality Hourly Forecasts

```C# Snippet:GetAirQualityHourlyForecasts
GetAirQualityHourlyForecastsOptions options = new GetAirQualityHourlyForecastsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<AirQualityResult> response = client.GetAirQualityHourlyForecasts(options);
Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
```
### Get Current Air Quality

```C# Snippet:GetCurrentAirQuality
GetCurrentAirQualityOptions options = new GetCurrentAirQualityOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<AirQualityResult> response = client.GetCurrentAirQuality(options);
Console.WriteLine("Description: " + response.Value.AirQualityResults[0].Description);
```
### Get Current Conditions

```C# Snippet:GetCurrentWeatherConditions
GetCurrentWeatherConditionsOptions options = new GetCurrentWeatherConditionsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<CurrentConditionsResult> response = client.GetCurrentWeatherConditions(options);
Console.WriteLine("Temperature: " + response.Value.Results[0].Temperature.Value);
```
### Get Daily Forecast

```C# Snippet:GetDailyWeatherForecast
GetDailyWeatherForecastOptions options = new GetDailyWeatherForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<DailyForecastResult> response = client.GetDailyWeatherForecast(options);
Console.WriteLine("Minimum temperatrue: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
Console.WriteLine("Maximum temperatrue: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
```
### Get Daily Historical Actuals

```C# Snippet:GetDailyHistoricalActuals
GetDailyHistoricalActualsOptions options = new GetDailyHistoricalActualsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
Response<DailyHistoricalActualsResult> response = client.GetDailyHistoricalActuals(options);
Console.WriteLine("Minimum temperature: " + response.Value.HistoricalActuals[0].Temperature.Minimum.Value);
Console.WriteLine("Maximum temperature: " + response.Value.HistoricalActuals[0].Temperature.Maximum.Value);
```
### Get Daily Historical Normals

```C# Snippet:GetDailyHistoricalNormals
GetDailyHistoricalNormalsOptions options = new GetDailyHistoricalNormalsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
Response<DailyHistoricalNormalsResult> response = client.GetDailyHistoricalNormals(options);
Console.WriteLine("Minimum temperature: " + response.Value.HistoricalNormals[0].Temperature.Minimum.Value);
Console.WriteLine("Maximum temperature: " + response.Value.HistoricalNormals[0].Temperature.Maximum.Value);
```
### Get Daily Historical Records

```C# Snippet:GetDailyHistoricalRecords
GetDailyHistoricalRecordsOptions options = new GetDailyHistoricalRecordsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
Response<DailyHistoricalRecordsResult> response = client.GetDailyHistoricalRecords(options);
Console.WriteLine("Minimum temperature: " + response.Value.HistoricalRecords[0].Temperature.Minimum.Value);
Console.WriteLine("Maximum temperature: " + response.Value.HistoricalRecords[0].Temperature.Maximum.Value);
```
### Get Daily Indices

```C# Snippet:GetDailyIndices
GetDailyIndicesOptions options = new GetDailyIndicesOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<DailyIndicesResult> response = client.GetDailyIndices(options);
Console.WriteLine("Description: " + response.Value.Results[0].Description);
```
### Get Hourly Forecast

```C# Snippet:GetHourlyWeatherForecast
GetHourlyWeatherForecastOptions options = new GetHourlyWeatherForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<HourlyForecastResult> response = client.GetHourlyWeatherForecast(options);
Console.WriteLine("Temperature: " + response.Value.Forecasts[0].Temperature.Value);
```
### Get Minute Forecast

```C# Snippet:GetMinuteWeatherForecast
GetMinuteWeatherForecastOptions options = new GetMinuteWeatherForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<MinuteForecastResult> response = client.GetMinuteWeatherForecast(options);
Console.WriteLine("Summary: " + response.Value.Summary.LongPhrase);
```
### Get Quarter Day Forecast

```C# Snippet:GetQuarterDayWeatherForecast
GetQuarterDayWeatherForecastOptions options = new GetQuarterDayWeatherForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<QuarterDayForecastResult> response = client.GetQuarterDayWeatherForecast(options);
Console.WriteLine("Minimum temperature: " + response.Value.Forecasts[0].Temperature.Minimum.Value);
Console.WriteLine("Maximum temperature: " + response.Value.Forecasts[0].Temperature.Maximum.Value);
```
### Get Severe Weather Alerts

```C# Snippet:GetSevereWeatherAlerts
GetSevereWeatherAlertsOptions options = new GetSevereWeatherAlertsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
Response<SevereWeatherAlertsResult> response = client.GetSevereWeatherAlerts(options);
if (response.Value.Results.Count > 0)
{
    Console.WriteLine("Description: " + response.Value.Results[0].Description);
}
```
### Get Tropical Storm Active

```C# Snippet:GetTropicalStormActive
Response<ActiveStormResult> response = client.GetTropicalStormActive();
if (response.Value.ActiveStorms.Count > 0)
{
    Console.WriteLine("Name: " + response.Value.ActiveStorms[0].Name);
}
else
{
    Console.WriteLine("No active storm");
}
```
### Get Tropical Storm Forecast

```C# Snippet:GetTropicalStormForecast
GetTropicalStormForecastOptions options = new GetTropicalStormForecastOptions()
{
    Year = 2021,
    BasinId = BasinId.NP,
    GovernmentStormId = 2,
    IncludeDetails = true,
    IncludeGeometricDetails = true
};
Response<StormForecastResult> response = client.GetTropicalStormForecast(options);

if (response.Value.StormForecasts.Count == 0)
{
    Console.WriteLine("No storm forecast found.");
    return;
}

if (response.Value.StormForecasts[0].WindRadiiSummary[0].RadiiGeometry is GeoPolygon geoPolygon)
{
    Console.WriteLine("Geometry type: Polygon");
    for (int i = 0; i < geoPolygon.Coordinates[0].Count; ++i)
    {
        Console.WriteLine("Point {0}: {1}", i, geoPolygon.Coordinates[0][i]);
    }
}

Console.WriteLine(
    "Windspeed: {0}{1}",
    response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.Value,
    response.Value.StormForecasts[0].WindRadiiSummary[0].WindSpeed.UnitLabel
);
```
### Get Tropical Storm Locations

```C# Snippet:GetTropicalStormLocations
GetTropicalStormLocationsOptions options = new GetTropicalStormLocationsOptions()
{
    Year = 2021,
    BasinId = BasinId.NP,
    GovernmentStormId = 2
};
Response<StormLocationsResult> response = client.GetTropicalStormLocations(options);
if (response.Value.StormLocations.Count > 0)
{
    Console.WriteLine(
        "Coordinates(longitude, latitude): ({0}, {1})",
        response.Value.StormLocations[0].Coordinates.Longitude,
        response.Value.StormLocations[0].Coordinates.Latitude
    );
}
else
{
    Console.WriteLine("No storm location found.");
}
```
### Get Tropical Storm Search

```C# Snippet:GetTropicalStormSearch
GetTropicalStormSearchOptions options = new GetTropicalStormSearchOptions()
{
    Year = 2021,
    BasinId = BasinId.NP,
    GovernmentStormId = 2
};
Response<StormSearchResult> response = client.GetTropicalStormSearch(options);
if (response.Value.Storms.Count > 0)
{
    Console.WriteLine("Name: " + response.Value.Storms[0].Name);
}
else
{
    Console.WriteLine("No storm found.");
}
```
### Get Weather Along Route

```C# Snippet:GetWeatherAlongRoute
WeatherAlongRouteQuery query = new WeatherAlongRouteQuery()
{
    Waypoints = new List<WeatherAlongRouteWaypoint> {
        new WeatherAlongRouteWaypoint()
        {
            Coordinates = new GeoPosition(121.525694, 25.033075),
            EtaInMinutes = 0,
            Heading = 0
        },
        new WeatherAlongRouteWaypoint()
        {
            Coordinates = new GeoPosition(121.5640089, 25.0338053),
            EtaInMinutes = 2,
            Heading = 0
        }
    }
};
Response<WeatherAlongRouteResult> response = client.GetWeatherAlongRoute(
    query,
    WeatherLanguage.EnglishUsa
);
if (response.Value.Waypoints.Count > 0)
{
    Console.WriteLine("Temperature of waypoints 0: " + response.Value.Waypoints[0].Temperature.Value);
}
else
{
    Console.WriteLine("No weather information found.");
}
```



## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the service correspond to the same HTTP status codes returned for [REST API requests](https://learn.microsoft.com/rest/api/maps/weather).

For example, if you search with an invalid coordinate, an error is returned, indicating "Bad Request".400


## Next steps

* For more context and additional scenarios, please see: [detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

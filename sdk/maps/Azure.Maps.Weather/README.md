# Azure Maps Weather client library for .NET

Azure Maps Weather is a library which contains Azure Maps Weather APIs.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/weather) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Weather --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://docs.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

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
var options = new GetAirQualityDailyForecastsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetAirQualityDailyForecasts(options);
Console.WriteLine(response);
```
### Get Air Quality Hourly Forecasts

```C# Snippet:GetAirQualityHourlyForecasts
var options = new GetAirQualityHourlyForecastsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetAirQualityHourlyForecasts(options);
Console.WriteLine(response);
```
### Get Current Air Quality

```C# Snippet:GetCurrentAirQuality
var options = new GetCurrentAirQualityOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetCurrentAirQuality(options);
Console.WriteLine(response);
```
### Get Current Conditions

```C# Snippet:GetCurrentConditions
var options = new GetCurrentConditionsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetCurrentConditions(options);
Console.WriteLine(response);
```
### Get Daily Forecast

```C# Snippet:GetDailyForecast
var options = new GetDailyForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetDailyForecast(options);
Console.WriteLine(response);
```
### Get Daily Historical Actuals

```C# Snippet:GetDailyHistoricalActuals
var options = new GetDailyHistoricalActualsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
var response = client.GetDailyHistoricalActuals(options);
Console.WriteLine(response);
```
### Get Daily Historical Normals

```C# Snippet:GetDailyHistoricalNormals
var options = new GetDailyHistoricalNormalsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
var response = client.GetDailyHistoricalNormals(options);
Console.WriteLine(response);
```
### Get Daily Historical Records

```C# Snippet:GetDailyHistoricalRecords
var options = new GetDailyHistoricalRecordsOptions()
{
    Coordinates = new GeoPosition(-73.961968, 40.760139),
    StartDate = new DateTimeOffset(new DateTime(2024, 1, 1)),
    EndDate = new DateTimeOffset(new DateTime(2024, 1, 31))
};
var response = client.GetDailyHistoricalRecords(options);
Console.WriteLine(response);
```
### Get Daily Indices

```C# Snippet:GetDailyIndices
var options = new GetDailyIndicesOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetDailyIndices(options);
Console.WriteLine(response);
```
### Get Hourly Forecast

```C# Snippet:GetHourlyForecast
var options = new GetHourlyForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetHourlyForecast(options);
Console.WriteLine(response);
```
### Get Minute Forecast

```C# Snippet:GetMinuteForecast
var options = new GetMinuteForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetMinuteForecast(options);
Console.WriteLine(response);
```
### Get Quarter Day Forecast

```C# Snippet:GetQuarterDayForecast
var options = new GetQuarterDayForecastOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetQuarterDayForecast(options);
Console.WriteLine(response);
```
### Get Severe Weather Alerts

```C# Snippet:GetSevereWeatherAlerts
var options = new GetSevereWeatherAlertsOptions()
{
    Coordinates = new GeoPosition(121.5640089, 25.0338053),
    Language = WeatherLanguage.EnglishUsa
};
var response = client.GetSevereWeatherAlerts(options);
Console.WriteLine(response);
```
### Get Tropical Storm Active

```C# Snippet:GetTropicalStormActive
var response = client.GetTropicalStormActive();
Console.WriteLine(response);
```
### Get Tropical Storm Forecast

```C# Snippet:GetTropicalStormForecast
var options = new GetTropicalStormForecastOptions()
{
    Year = 2021,
    BasinId = "NP",
    GovernmentStormId = 2
};
var response = client.GetTropicalStormForecast(options);
Console.WriteLine(response);
```
### Get Tropical Storm Locations

```C# Snippet:GetTropicalStormLocations
var options = new GetTropicalStormLocationsOptions()
{
    Year = 2021,
    BasinId = "NP",
    GovernmentStormId = 2
};
var response = client.GetTropicalStormLocations(options);
Console.WriteLine(response);
```
### Get Tropical Storm Search

```C# Snippet:GetTropicalStormSearch
var options = new GetTropicalStormSearchOptions()
{
    Year = 2021,
    BasinId = "NP",
    GovernmentStormId = 2
};
var response = client.GetTropicalStormSearch(options);
Console.WriteLine(response);
```
### Get Weather Along Route

```C# Snippet:GetWeatherAlongRoute
var response = client.GetWeatherAlongRoute(
    "25.033075,121.525694,0:25.0338053,121.5640089,2",
    WeatherLanguage.EnglishUsa
);
Console.WriteLine(response);
```


## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the service correspond to the same HTTP status codes returned for [REST API requests](https://docs.microsoft.com/rest/api/maps/weather).

For example, if you search with an invalid coordinate, an error is returned, indicating "Bad Request".400


## Next steps

* For more context and additional scenarios, please see: [detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/maps/Azure.Maps.Weather/README.png)

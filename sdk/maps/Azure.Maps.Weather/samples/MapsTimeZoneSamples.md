using Azure.Maps.TimeZone;


## Examples


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

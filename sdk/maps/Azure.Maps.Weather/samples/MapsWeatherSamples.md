## Examples


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

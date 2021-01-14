# Time Series Insights

## Model Settings

The main motivation for Time Series Model is to simplify finding and analyzing IoT or Time Series data. It achieves this objective by enabling the curation, maintenance, and enrichment of time series data to help prepare consumer-ready datasets for analytics.

Time Series Model settings can be managed through the Model Settings API which includes model display name, Time Series ID properties and default type ID. Every Gen2 environment has a model that is automatically created.

### GET /timeseries/modelSettings

Returns the model settings which includes model display name, Time Series ID properties and default type ID. Every Gen2 environment has a model that is automatically created.

```javascript
{
  "parameters": {
    "api-version": "2020-07-31",
    "environmentFqdn": "10000000-0000-0000-0000-100000000109.env.timeseries.azure.com"
  },
  "responses": {
    "200": {
      "body": {
        "modelSettings": {
          "name": "DefaultModel",
          "timeSeriesIdProperties": [
            {
              "name": "DeviceId",
              "type": "String"
            }
          ],
          "defaultTypeId": "5AB70D71-A8CD-410E-B70D-6F04AB9C132C"
        }
      }
    }
  }
}
```

```csharp
public virtual async Task<Response<ModelSettingsResponse>> GetAsync(string clientSessionId = null, CancellationToken cancellationToken = default)
```

### POST /timeseries/modelSettings

Updates time series model settings - either the model name or default type ID.

```javascript
{
  "parameters": {
    "api-version": "2020-07-31",
    "environmentFqdn": "10000000-0000-0000-0000-100000000109.env.timeseries.azure.com",
    "parameters": {
      "name": "Thermostats"
    }
  },
  "responses": {
    "200": {
      "body": {
        "modelSettings": {
          "name": "Thermostats",
          "timeSeriesIdProperties": [
            {
              "name": "DeviceId",
              "type": "String"
            }
          ],
          "defaultTypeId": "5AB70D71-A8CD-410E-B70D-6F04AB9C132C"
        }
      }
    }
  }
}
```
```csharp
public virtual async Task<Response<ModelSettingsResponse>> UpdateAsync(UpdateModelSettingsRequest parameters, string clientSessionId = null, CancellationToken cancellationToken = default)
```
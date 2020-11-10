# Azure.Iot.TimeSeriesInsights

## Azure Time Series Insights swagger

## Official swagger document

The official swagger specification for Azure Time Series Insights can be found [here](https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9a6510d0597a55d39ab1edcf22abab4631cbc0d3/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/timeseriesinsights.json).

## Code generation

Run `generate.ps1` in this directory to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
# when generating from official source - The raw link must have a commit hash for C# generator
#input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9a6510d0597a55d39ab1edcf22abab4631cbc0d3/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/timeseriesinsights.json

# It is highly recommended that you generate the REST layer from the official source. However, in this case we are using a local file because there are a couple of minor issues fixed in the local swagger. These fixes should be made on the official source.
input-file: $(this-folder)/swagger/timeseriesinsights.json
```

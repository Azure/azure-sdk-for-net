# Azure.IoT.TimeSeriesInsights

## Azure Time Series Insights swagger

## Official swagger document

The official swagger specification for Azure Time Series Insights can be found [here](https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9a6510d0597a55d39ab1edcf22abab4631cbc0d3/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/timeseriesinsights.json).

## Code generation

Run `generate.ps1` in this directory to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

# Change accessibility
``` yaml

model-namespace: false

directive:
  from: timeseriesinsights.json
  where: $.definitions
  transform: >
    for (var path in $)
    {
      if (path.includes("UpdateModelSettingsRequest") ||
          path.includes("AvailabilityResponse") ||
          path.includes("Availability") ||
          path.includes("EventSchema") ||
          path.includes("InstanceHit") ||
          path.includes("InstancesSearchStringSuggestion") ||
          path.includes("InstancesSortParameter") ||
          path.includes("InstancesSuggestResponse") ||
          path.includes("InstancesSuggestRequest") ||
          path.includes("InstancesSortBy") ||
          path.includes("HierarchyHit") ||
          path.includes("SearchHierarchyNodesResponse") ||
          path.includes("SearchInstancesHierarchiesParameters") ||
          path.includes("SearchInstancesParameters") ||
          path.includes("SearchInstancesRequest") ||
          path.includes("SearchInstancesResponse") ||
          path.includes("SearchInstancesResponsePage") ||
          path.includes("HierarchiesSortBy") ||
          path.includes("HierarchiesSortParameter") ||
          path.includes("HierarchiesExpandParameter") ||
          path.includes("HierarchiesSortParameter") ||
          path.includes("QueryRequest") ||
          path.includes("InstancesBatchRequest") ||
          path.includes("GetHierarchiesPage") ||
          path.includes("GetInstancesPage") ||
          path.includes("GetTypesPage") ||
          path.includes("HierarchiesBatchRequest") ||
          path.includes("HierarchiesRequestBatchGetDelete") ||
          path.includes("ModelSettingsResponse") ||
          path.includes("TypesBatchRequest") ||
          path.includes("TypesRequestBatchGetOrDelete") ||
          path.includes("DateTimeRange") ||
          path.includes("PagedResponse") ||
          path.includes("QueryResultPage"))
      {
        $[path]["x-accessibility"] = "internal"
      }
    }
```

``` yaml
# when generating from official source - The raw link must have a commit hash for C# generator
#input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9a6510d0597a55d39ab1edcf22abab4631cbc0d3/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/timeseriesinsights.json

# It is highly recommended that you generate the REST layer from the official source. However, in this case we are using a local file because there are a couple of minor issues fixed in the local swagger. These fixes should be made on the official source.
input-file: $(this-folder)/swagger/timeseriesinsights.json
generation1-convenience-client: true
```

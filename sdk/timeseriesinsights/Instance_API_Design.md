# Time Series Insights

## Instances
Time Series Model instances are virtual representations of the time series themselves. Instances have descriptive information associated with them called instance properties, such as a time series ID, type, name, description, hierarchies, and instance fields. At a minimum, instance properties include hierarchy information.

### GET /timeseries/instances

```javascript
/timeseries/instances:
    get:
      tags:
        - TimeSeriesInstances
      operationId: TimeSeriesInstances_List
      description: Gets time series instances in pages.
      x-ms-examples:
        InstancesListPage1:
          $ref: ./examples/InstancesListPage1.json
        InstancesListPage2:
          $ref: ./examples/InstancesListPage2.json
        InstancesListPage3:
          $ref: ./examples/InstancesListPage3.json
      parameters:
        - $ref: '#/parameters/ApiVersion'
        - $ref: '#/parameters/ContinuationToken'
        - $ref: '#/parameters/ClientRequestId'
        - $ref: '#/parameters/ClientSessionId'
      responses:
        '200':
          description: Successful operation.
          schema:
            $ref: '#/definitions/GetInstancesPage'
          headers:
            x-ms-request-id:
              x-ms-client-name: serverRequestId
              type: string
              description: Server-generated request ID. Can be used to contact support to investigate a request.
        default:
          description: Unexpected error.
          schema:
            $ref: '#/definitions/TsiError'
          headers:
            x-ms-request-id:
              x-ms-client-name: serverRequestId
              type: string
              description: Server-generated request ID. Can be used to contact support to investigate a request.
```

```csharp
public virtual AsyncPageable<TimeSeriesInstance> GetInstances(string clientSessionId = null, CancellationToken cancellationToken = default);
```
<br>
<br>

### POST /timeseries/instances/suggest
Example: https://github.com/Azure/azure-rest-api-specs/blob/master/specification/timeseriesinsights/data-plane/Microsoft.TimeSeriesInsights/stable/2020-07-31/examples/InstancesSuggest.json
```javascript
  /timeseries/instances/suggest:
    post:
      tags:
        - TimeSeriesInstances
      operationId: TimeSeriesInstances_Suggest
      description: Suggests keywords based on time series instance attributes to be later used in Search Instances.
      x-ms-examples:
        InstancesSuggest:
          $ref: ./examples/InstancesSuggest.json
      parameters:
        - $ref: '#/parameters/ApiVersion'
        - name: parameters
          in: body
          required: true
          schema:
            $ref: '#/definitions/InstancesSuggestRequest'
          description: Time series instances suggest request body.
        - $ref: '#/parameters/ClientRequestId'
        - $ref: '#/parameters/ClientSessionId'
      responses:
        '200':
          description: Successful operation.
          schema:
            $ref: '#/definitions/InstancesSuggestResponse'
          headers:
            x-ms-request-id:
              x-ms-client-name: serverRequestId
              type: string
              description: Server-generated request ID. Can be used to contact support to investigate a request.
        default:
          description: Unexpected error.
          schema:
            $ref: '#/definitions/TsiError'
          headers:
            x-ms-request-id:
              x-ms-client-name: serverRequestId
              type: string
              description: Server-generated request ID. Can be used to contact support to investigate a request.
```

```csharp
public virtual Response<InstancesSearchStringSuggestion[]> GetSearchSuggestions(string searchString, int take = null, string clientSessionId = null, CancellationToken cancellationToken = default);
```

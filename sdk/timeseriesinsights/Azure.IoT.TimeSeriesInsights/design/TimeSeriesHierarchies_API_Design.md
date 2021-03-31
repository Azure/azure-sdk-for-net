# Time Series Insights

## Hierarchies

Time Series Model hierarchies organize instances by specifying property names and their relationships.
Hierarchies are represented in JSON as:

```json
{
  "hierarchies": [
    {
      "id": "6e292e54-9a26-4be1-9034-607d71492707",
      "name": "Location",
      "source": {
        "instanceFieldNames": [
          "state",
          "city"
        ]
      }
    },
    {
      "id": "a28fd14c-6b98-4ab5-9301-3840f142d30e",
      "name": "ManufactureDate",
      "source": {
        "instanceFieldNames": [
          "year",
          "month"
        ]
      }
    }
  ]
}
```

## GET /timeseries/hierarchies

Returns time series hierarchies definitions in pages.

```csharp
/// <summary>
/// Gets time series insight hierarchies in pages asynchronously.
/// </summary>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns> The pageable list <see cref="AsyncPageable{TimeSeriesHierarchy}"/> of Time Series instances hierarchies with the http response.</returns>
public virtual AsyncPageable<TimeSeriesHierarchy> GetTimeSeriesHierarchiesAsync(
    CancellationToken cancellationToken = default)
```

## POST /timeseries/hierarchies/$batch

Executes a batch get, create, update, delete operation on multiple time series hierarchies.

### Get Time Series Insights Hierarchies

```csharp
/// <summary>
/// Gets time series insight hierarchies by Time Series hierarchy Ids asynchronously.
/// </summary>
/// <param name="timeSeriesHierarchyIds">List of Ids of the Time Series hierarchies to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>List of hierarchy or error objects corresponding by position to the array in the request. Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> GetTimeSeriesHierarchiesByIdAsync(
    IEnumerable<string> timeSeriesHierarchyIds, 
    CancellationToken cancellationToken = default)
```

```csharp
/// <summary>
/// Gets time series insight hierarchies by Time Series hierarchy Names asynchronously.
/// </summary>
/// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>List of hierarchy or error objects corresponding by position to the array in the request. Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> GetTimeSeriesHierarchiesByNameAsync(
    IEnumerable<string> timeSeriesHierarchyNames, 
    CancellationToken cancellationToken = default)
```

### Create OR Replace Time Series Insights Hierarchies

```csharp
/// <summary>
/// Creates or Updates Time Series insight hierarchies asynchronously.
/// </summary>
/// <param name="timeSeriesHierarchies">The Time Series insight hierarchies to be created or replaced.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of hierarchy or error objects corresponding by position to the array in the request. Hierarchy object is set when operation is successful and error object is set when operation is unsuccessful.
/// </returns>
public virtual async Task<Response<TimeSeriesHierarchyOperationResult[]>> CreateOrReplaceTimeSeriesHierarchiesAsync(
    IEnumerable<TimeSeriesHierarchy> timeSeriesHierarchies,
    CancellationToken cancellationToken = default)
```

### Delete Time Series Insights Hierarchies

```csharp
/// <summary>
/// Deletes Time Series insight hierarchies by Time Series hierarchy Ids asynchronously.
/// </summary>
/// <param name="timeSeriesHierarchyIds">List of names of the Time Series hierarchies to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of error objects corresponding by position to the "delete" array in the request - null when the operation is successful.
/// </returns>
public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteTimeSeriesHierarchiesByIdAsync(
    IEnumerable<string> timeSeriesHierarchyIds,
    CancellationToken cancellationToken = default)
```

```csharp
/// <summary>
/// Deletes time series insight hierarchies by Time Series hierarchy Names asynchronously.
/// </summary>
/// <param name="timeSeriesHierarchyNames">List of names of the Time Series hierarchies to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of error objects corresponding by position to the "delete" array in the request - null when the operation is successful.
/// </returns>
public virtual async Task<Response<TimeSeriesOperationError[]>> DeleteTimeSeriesHierarchiesByNameAsync(
    IEnumerable<string> timeSeriesHierarchyNames,
    CancellationToken cancellationToken = default)
```

## Definitions

### TimeSeriesHierarchyOperationResult:

```json
  TimeSeriesHierarchyOperationResult:
    description: Result of a batch operation on a particular time series hierarchy. Hierarchy is set when operation is successful and error object is set when operation is unsuccessful.
    type: object
    properties:
      hierarchy:
        description: Time series hierarchy object - set when the operation is successful.
        readOnly: true
        $ref: '#/definitions/TimeSeriesHierarchy'
      error:
        description: Error object - set when the operation is unsuccessful.
        readOnly: true
        $ref: '#/definitions/TsiErrorBody'
```

### TimeSeriesOperationError:

```json
TsiErrorBody:
    description: A particular API error with an error code and a message.
    type: object
    properties:
      code:
        description: 'Language-independent, human-readable string that defines a service-specific error code. This code serves as a more specific indicator for the HTTP error code specified in the response. Can be used to programmatically handle specific error cases.'
        readOnly: true
        type: string
      message:
        description: 'Human-readable, language-independent representation of the error. It is intended as an aid to developers and is not suitable for exposure to end users.'
        readOnly: true
        type: string
      target:
        description: 'Target of the particular error (for example, the name of the property in error). May be null.'
        readOnly: true
        type: string
      innerError:
        description: Contains more specific error that narrows down the cause. May be null.
        readOnly: true
        $ref: '#/definitions/TsiErrorBody'
      details:
        description: Contains additional error information. May be null.
        readOnly: true
        type: array
        items:
          $ref: '#/definitions/TsiErrorDetails'
    additionalProperties: true
    x-ms-external: false
```
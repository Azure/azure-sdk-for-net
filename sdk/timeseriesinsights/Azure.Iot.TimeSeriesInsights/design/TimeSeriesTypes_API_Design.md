# Time Series Insights

## Types

Time Series Model types help you define variables or formulas for doing computations. Types are associated with a specific instance.

A type can have one or more variables. For example, a Time Series Model instance might be of type Temperature Sensor, which consists of the variables avg temperature, min temperature, and max temperature.

### GET /timeseries/types

Returns time series types in pages.

```csharp
/// <summary>
/// Gets time series insight types in pages asynchronously.
/// </summary>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The pageable list <see cref="AsyncPageable{TimeSeriesType}"/> of Time Series instances types with the http response.</returns>
public virtual AsyncPageable<TimeSeriesType> GetTimeSeriesTypesAsync(
    CancellationToken cancellationToken = default)
```

### POST /timeseries/types

Executes a batch get, create, update, delete operation on multiple time series types.

#### Get Time Series Insights Types

```csharp
/// <summary>
/// Gets time series insight types by Time Series Type Ids asynchronously.
/// </summary>
/// <param name="timeSeriesTypeIds">List of Time Series Type Ids of the Time Series Types to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>List of types or error objects corresponding by position to the array in the request. Type object is set when operation is successful and error object is set when operation is unsuccessful.
public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesbyIdAsync(
    IEnumerable<string> timeSeriesTypeIds, 
    CancellationToken cancellationToken = default)
```

```csharp
/// <summary>
/// Gets time series insight types by Time Series Types Names asynchronously.
/// </summary>
/// <param name="timeSeriesTypeNames">List of names of the Time Series Types to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>List of types or error objects corresponding by position to the array in the request. Type object is set when operation is successful and error object is set when operation is unsuccessful.
public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> GetTimeSeriesTypesbyNamesAsync(
    IEnumerable<string> timeSeriesTypeNames, 
    CancellationToken cancellationToken = default)
```

#### Create OR Replace Time Series Insights Types

```csharp
/// <summary>
/// Creates Time Series instances types asynchronously. If a provided instance type is already in use, then this will attempt to replace the existing instance type with the provided Time Series Instance.
/// </summary>
/// <param name="timeSeriesTypes">The Time Series instances types to be created or replaced.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of error objects corresponding by position to the <paramref name="timeSeriesTypes"/> array in the request.
/// An error object will be set when operation is unsuccessful.
/// </returns>
public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> CreateOrReplaceTimeSeriesTypesAsync(
    IEnumerable<TimeSeriesType> timeSeriesTypes,
    CancellationToken cancellationToken = default)
```

#### Delete Time Series Insights Types

```csharp
/// <summary>
/// Deletes Time Series instances types by Time Series Type Ids asynchronously.
/// </summary>
/// <param name="timeSeriesTypeIds">List of Time Series Type Ids of the Time Series Types to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of error objects corresponding by position to the <paramref name="timeSeriesIds"/> array in the request.
/// An error object will be set when operation is unsuccessful.
/// null will be set when the operation is successful.
/// </returns>
public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> DeleteTimeSeriesTypesbyIdAsync(
    IEnumerable<string> timeSeriesTypeIds,
    CancellationToken cancellationToken = default)
```

```csharp
/// <summary>
/// Deletes Time Series instances types by Time Series Types Names asynchronously.
/// </summary>
/// <param name="timeSeriesTypeNames">List of names of the Time Series Types to return.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>
/// List of error objects corresponding by position to the <paramref name="timeSeriesNames"/> array in the request.
/// An error object will be set when operation is unsuccessful.
/// null will be set when the operation is successful.
/// </returns>
public virtual async Task<Response<TimeSeriesTypeOperationResult[]>> DeleteTimeSeriesTypesbyNamesAsync(
    IEnumerable<string> timeSeriesTypeNames,
    CancellationToken cancellationToken = default)
```

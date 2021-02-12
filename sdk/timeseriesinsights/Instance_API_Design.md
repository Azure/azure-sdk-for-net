# Time Series Insights

## Instances
Time Series Model instances are virtual representations of the time series themselves. Instances have descriptive information associated with them called instance properties, such as a time series ID, type, name, description, hierarchies, and instance fields. At a minimum, instance properties include hierarchy information.

### GET /timeseries/instances

```csharp
public virtual Pageable<TimeSeriesInstance> GetTimeSeriesInstances(CancellationToken cancellationToken = default);
```

### POST /timeseries/instances/suggest

```csharp
public virtual Response<SearchSuggestion[]> GetSearchSuggestions(string searchString, int? maxNumberOfSuggestions, CancellationToken cancellationToken = default);
```

### POST /timeseries/instances/$batch

```csharp
~~public virtual Response<InstanceOrError[]> GetInstances(IEnumerable<TimeSeriesId> timeSeriesIds, CancellationToken cancellationToken = default);~~
public virtual Response<InstanceOrError[]> GetInstances(IEnumerable<IList<object>> timeSeriesIds, CancellationToken cancellationToken = default);

// Thoughts on renaming InstanceOrError to GetInstancesOperationResult or GetInstancesResult
```

```csharp
public virtual Response<InstanceOrError[]> GetInstances(IEnumerable<string> timeSeriesNames, CancellationToken cancellationToken = default);

// Thoughts on naming the APIs GetInstancesByIds and GetInstancesByNames
```

```csharp
public virtual Response<InstanceOrError[]> CreateOrReplaceTimeSeriesInstances(IEnumerable<TimeSeriesInstance> timeSeriesInstances, CancellationToken cancellationToken = default);
```

```csharp
public virtual Response<InstanceOrError[]> ReplaceTimeSeriesInstances(IEnumerable<TimeSeriesInstance> timeSeriesInstances, CancellationToken cancellationToken = default);

// thoughts on only having CreateOrReplaceInstances? It's safer to have both. 
```

```csharp
public virtual Response<TsiErrorBody[]> DeleteTimeSeriesInstances(IEnumerable<TimeSeriesId> timeSeriesIds, CancellationToken cancellationToken = default);

// Thoughts on renaming TsiErrorBody to DeleteInstanceOperationResponse
```

```csharp
public virtual Response<TsiErrorBody[]> DeleteTimeSeriesInstances(IEnumerable<string> timeSeriesNames, CancellationToken cancellationToken = default);

// Thoughts on naming the APIs DeleteInstancesByIds and DeleteInstancesByNames
```

### POST /timeseries/instances/search

```csharp
public virtual Response<SearchInstancesResponsePage> Search(string searchString, IEnumerable<string> hierarchyPath, SearchInstancesParameters instancesParameters, SearchInstancesHierarchiesParameters hierarchiesParameters, string continuationToken = null, CancellationToken cancellationToken = default)

// Thoughts on renaming SearchInstancesParameters to SearchInstancesOptions
// Thoughts on renaming SearchInstancesHierarchiesParameters to SearchHierarchiesOptions
// Thoughts on renaming SearchInstancesResponsePage to SearchInstancesPage
```

# Time Series Insights

## Instances
Time Series Model instances are virtual representations of the time series themselves. Instances have descriptive information associated with them called instance properties, such as a time series ID, type, name, description, hierarchies, and instance fields. At a minimum, instance properties include hierarchy information.

### GET /timeseries/instances

```csharp
public virtual Pageable<TimeSeriesInstance> GetInstances(CancellationToken cancellationToken = default);
```

### POST /timeseries/instances/suggest

```csharp
public virtual Response<InstancesSearchStringSuggestion[]> GetSearchSuggestions(InstancesSuggestRequest instancesSuggestRequest, CancellationToken cancellationToken = default);

// Thoughts on renaming InstancesSuggestRequest to GetSearchSuggestionsOptions
// Thoughts on renaming InstancesSearchStringSuggestion to InstanceSuggestion
```

### POST /timeseries/instances/$batch

```csharp
public virtual Response<InstanceOrError[]> GetInstances(TimeSeriesId[] timeSeriesIds, CancellationToken cancellationToken = default);

// Thoughts on renaming InstanceOrError to GetInstanceOperationResult
```

```csharp
public virtual Response<InstanceOrError[]> GetInstances(string[] timeSeriesNames, CancellationToken cancellationToken = default);

// Thoughts on naming the APIs GetInstancesByIds and GetInstancesByNames
```

```csharp

public virtual Response<InstanceOrError[]> CreateOrReplaceInstances(TimeSeriesInstance[] timeSeriesInstances, CancellationToken cancellationToken = default);
```

```csharp
public virtual Response<InstanceOrError[]> ReplaceInstances(TimeSeriesInstance[] timeSeriesInstances, CancellationToken cancellationToken = default);

// thoughts on only having CreateOrReplaceInstances? It's safer to have both. 
```

```csharp
public virtual Response<TsiErrorBody[]> DeleteInstances(TimeSeriesId[] timeSeriesIds, CancellationToken cancellationToken = default);

// Thoughts on renaming TsiErrorBody to DeleteInstanceOperationResponse
```

```csharp
public virtual Response<TsiErrorBody[]> DeleteInstances(string[] timeSeriesNames, CancellationToken cancellationToken = default);

// Thoughts on naming the APIs DeleteInstancesByIds and DeleteInstancesByNames
```

### POST /timeseries/instances/search

```csharp
public virtual Response<SearchInstancesResponsePage> Search(SearchInstancesRequest searchInstancesRequest, string continuationToken = null, CancellationToken cancellationToken = default)

// Thoughts on renaming SearchInstancesRequest to SearchInstancesOptions
// Thoughts on renaming SearchInstancesResponsePage to SearchInstancesResponse
```
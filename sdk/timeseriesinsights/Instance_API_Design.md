# Time Series Insights

## Instances
Time Series Model instances are virtual representations of the time series themselves. Instances have descriptive information associated with them called instance properties, such as a time series ID, type, name, description, hierarchies, and instance fields. At a minimum, instance properties include hierarchy information.

### GET /timeseries/instances

```csharp
public virtual Pageable<TimeSeriesInstance> GetInstances(string clientSessionId = null, CancellationToken cancellationToken = default);
```

### POST /timeseries/instances/suggest

```csharp
public virtual Response<InstancesSearchStringSuggestion[]> GetSearchSuggestions(string searchString, int take = null, string clientSessionId = null, CancellationToken cancellationToken = default);

// Thoughts on renaming IstancesSearchStringSuggestion to InstanceSuggestion
```

### POST /timeseries/instances/$batch

```csharp
public virtual Response<InstanceOrError[]> GetInstancesByTimeSeriesIds(TimeSeriesId[] timeSeriesIds, clientSessionId = null, CancellationToken cancellationToken = default);

public virtual Response<InstanceOrError[]> GetInstancesByNames(string[] timeSeriesNames, clientSessionId = null, CancellationToken cancellationToken = default);

// Thoughts on renaming InstanceOrError to GetInstanceOperationResponse

public virtual Response<InstanceOrError[]> CreateOrReplaceTimeSeriesInstances(TimeSeriesInstance[] timeSeriesInstances, clientSessionId = null, CancellationToken cancellationToken = default);

public virtual Response<InstanceOrError[]> UpdateTimeSeriesInstances(TimeSeriesInstance[] timeSeriesInstances, clientSessionId = null, CancellationToken cancellationToken = default);

public virtual Response<> DeleteInstancesByTimeSeriesId(TimeSeriesId[] timeSeriesIds, clientSessionId = null, CancellationToken cancellationToken = default);

public virtual Response<> DeleteInstancesByNames(string[] timeSeriesNames, clientSessionId = null, CancellationToken cancellationToken = default);

// Thoughts on the above operations but for single instance

```

### POST /timeseries/instances/search

```csharp
public virtual Pageable<TimeSeriesInstance> Search(SearchInstancesRequest parameters, string continuationToken = null, string clientSessionId = null, CancellationToken cancellationToken = default)
```
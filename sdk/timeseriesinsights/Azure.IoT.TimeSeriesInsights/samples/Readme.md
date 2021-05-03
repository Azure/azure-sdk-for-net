# Introduction

Azure Time Series Insights provides data exploration and telemetry tools to help you improve operational analysis. It's a fully managed analytics, storage, and visualization service where you can explore and analyze billions of Internet of Things (IoT) events simultaneously.

Azure Time Series Insights gives you a global view of your data, so you can quickly validate your IoT solution and avoid costly downtime to mission-critical devices. It can help you discover hidden trends, spot anomalies, and conduct root-cause analysis in near real time.

If you are new to Azure Time Series Insights and would like to learn more about the platform, please make sure you check out the Azure Time Series Insights official documentation page.

# Time Series Insights Samples

You can explore the time series insights APIs (using the client library) using the samples project.

The samples project demonstrates the following:

- Instantiate the client
- Demonstrate how to use Model APIs
    - Create, get, replace, and delete instances
    - Create, get, replace, and delete types
    - Create, get, replace, and delete hierarchies
    - Get and update model configuration settings
- Demonstrate how to query raw events, series, and aggregates.

## Creating the time series insights client

To create a new time series insights client, you need the endpoint to an Azure Time Series Insights instance and supply credentials.
In the sample below, you can set `TsiEndpoint`, `TenantId`, `ClientId`, and `ClientSecret` as command-line arguments.
The client requires an instance of [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In this samples, we illustrate how to use one derived class: ClientSecretCredential.

```C# Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret
// DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
// It attempts to use multiple credential types in an order until it finds a working credential.
var tokenCredential = new DefaultAzureCredential();

var client = new TimeSeriesInsightsClient(
    tsiEndpoint,
    tokenCredential);
```

## Create, get, replace, and delete instances

### Create instances
You can use the following snippet to create instance Id using `TimeSeriesId`.

```csharp
you can use the Model Settings client to learn more about what the Time Series Id is composed of in the environment.
TimeSeriesId instanceId = modelSettings.TimeSeriesIdProperties.Count switch
{
    1 => new TimeSeriesId("key1"),
    2 => new TimeSeriesId("key1", "key2"),
    3 => new TimeSeriesId("key1", "key2", "key3"),
    _ => throw new Exception($"Invalid number of Time Series Insights Id properties."),
};
```

Let's create instances using the code below. 
```C# Snippet:TimeSeriesInsightsSampleCreateInstance
// Create a Time Series Instance object with the default Time Series Insights type Id.
// The default type Id can be obtained programmatically by using the ModelSettings client.
var instance = new TimeSeriesInstance(instanceId, defaultTypeId)
{
    Name = "instance1",
};

var tsiInstancesToCreate = new List<TimeSeriesInstance>
{
    instance,
};

Response<TimeSeriesOperationError[]> createInstanceErrors = await client
    .Instances
    .CreateOrReplaceAsync(tsiInstancesToCreate)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter
// array in the request. If the error object is set to null, this means the operation was a success.
for (int i = 0; i < createInstanceErrors.Value.Length; i++)
{
    TimeSeriesId tsiId = tsiInstancesToCreate[i].TimeSeriesId;

    if (createInstanceErrors.Value[i] == null)
    {
        Console.WriteLine($"Created Time Series Insights instance with Id '{tsiId}'.");
    }
    else
    {
        Console.WriteLine($"Failed to create a Time Series Insights instance with Id '{tsiId}'.");
    }
}
```

### Get instances

Use `Instances.GetAsync` to get all created instances as `AsyncPageable<TimeSeriesInstance>`.
```C# Snippet:TimeSeriesInsightsGetAllInstances
// Get all instances for the Time Series Insigths environment
AsyncPageable<TimeSeriesInstance> tsiInstances = client.Instances.GetAsync();
await foreach (TimeSeriesInstance tsiInstance in tsiInstances)
{
    Console.WriteLine($"Retrieved Time Series Insights instance with Id '{tsiInstance.TimeSeriesId}' and name '{tsiInstance.Name}'.");
}
```

Use `Instances.GetAsync` with list of instance's unique identifiers or names to get a list of specific instances.
```C# Snippet:TimeSeriesInsightsGetnstancesById
// Get Time Series Insights instances by Id
var timeSeriesIds = new List<TimeSeriesId>
{
    instanceId,
};

Response<InstancesOperationResult[]> getByIdsResult = await client.Instances.GetAsync(timeSeriesIds).ConfigureAwait(false);

/// The response of calling the API contains a list of instance or error objects corresponding by position to the array in the request.
/// Instance object is set when operation is successful and error object is set when operation is unsuccessful.
for (int i = 0; i < getByIdsResult.Value.Length; i++)
{
    InstancesOperationResult currentOperationResult = getByIdsResult.Value[i];

    if (currentOperationResult.Instance != null)
    {
        Console.WriteLine($"Retrieved Time Series Insights instance with Id '{currentOperationResult.Instance.TimeSeriesId}' and name '{currentOperationResult.Instance.Name}'.");
    }
    else if (currentOperationResult.Error != null)
    {
        Console.WriteLine($"Failed to retrieve a Time Series Insights instance with Id '{timeSeriesIds[i]}'. Error message: '{currentOperationResult.Error.Message}'.");
    }
}
```

### Replace instances

To replace instances, pass in a list of `TimeSeriesInstance`.
```C# Snippet:TimeSeriesInsightsReplaceInstance
// Get Time Series Insights instances by Id
var instanceIdsToGet = new List<TimeSeriesId>
{
    instanceId,
};

Response<InstancesOperationResult[]> getInstancesByIdResult = await client.Instances.GetAsync(instanceIdsToGet).ConfigureAwait(false);

TimeSeriesInstance instanceResult = getInstancesByIdResult.Value[0].Instance;
Console.WriteLine($"Retrieved Time Series Insights instance with Id '{instanceResult.TimeSeriesId}' and name '{instanceResult.Name}'.");

// Now let's replace the instance with an updated name
instanceResult.Name = "newInstanceName";

var instancesToReplace = new List<TimeSeriesInstance>
{
    instanceResult,
};

Response<InstancesOperationResult[]> replaceInstancesResult = await client.Instances.ReplaceAsync(instancesToReplace).ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter
// array in the request. If the error object is set to null, this means the operation was a success.
for (int i = 0; i < replaceInstancesResult.Value.Length; i++)
{
    TimeSeriesId tsiId = instancesToReplace[i].TimeSeriesId;

    TimeSeriesOperationError currentError = replaceInstancesResult.Value[i].Error;

    if (currentError != null)
    {
        Console.WriteLine($"Failed to replace Time Series Insights instance with Id '{tsiId}'. Error Message: '{currentError.Message}'.");
    }
    else
    {
        Console.WriteLine($"Replaced Time Series Insights instance with Id '{tsiId}'.");
    }
}
```

### Delete instances

To delete instances, pass in a list of time series Ids or names for the instances you want to delete.
```C# Snippet:TimeSeriesInsightsSampleDeleteInstanceById
var instancesToDelete = new List<TimeSeriesId>
{
    instanceId,
};

Response<TimeSeriesOperationError[]> deleteInstanceErrors = await client
    .Instances
    .DeleteAsync(instancesToDelete)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter
// array in the request. If the error object is set to null, this means the operation was a success.
for (int i = 0; i < deleteInstanceErrors.Value.Length; i++)
{
    TimeSeriesId tsiId = instancesToDelete[i];

    if (deleteInstanceErrors.Value[i] == null)
    {
        Console.WriteLine($"Deleted Time Series Insights instance with Id '{tsiId}'.");
    }
    else
    {
        Console.WriteLine($"Failed to delete a Time Series Insights instance with Id '{tsiId}'. Error Message: '{deleteInstanceErrors.Value[i].Message}'");
    }
}
```

## Create, get, replace, and delete types

### Create types
You can use the following snippet to create types.

```C# Snippet:TimeSeriesInsightsSampleCreateType
// Create an aggregate type
var timeSeriesTypes = new List<TimeSeriesType>();

var countExpression = new TimeSeriesExpression("count()");
var aggregateVariable = new AggregateVariable(countExpression);
var variables = new Dictionary<string, TimeSeriesVariable>();
var variableName = "aggregateVariable";
variables.Add(variableName, aggregateVariable);

var timeSeriesTypesProperties = new Dictionary<string, string>
{
    { "Type1", "Type1Id"},
    { "Type2", "Type2Id"}
};

foreach (KeyValuePair<string, string> property in timeSeriesTypesProperties)
{
    var type = new TimeSeriesType(property.Key, variables)
    {
        Id = property.Value
    };
    timeSeriesTypes.Add(type);
}

Response<TimeSeriesTypeOperationResult[]> createTypesResult = await client
    .Types
    .CreateOrReplaceAsync(timeSeriesTypes)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < createTypesResult.Value.Length; i++)
{
    if (createTypesResult.Value[i].Error == null)
    {
        Console.WriteLine($"Created Time Series type successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to create a Time Series Insights type: {createTypesResult.Value[i].Error.Message}.");
    }
}
```

### Get types

Using `Types.GetTypesAsync`, all created types are returned as `AsyncPageable<TimeSeriesType>`.
```C# Snippet:TimeSeriesInsightsSampleGetAllTypes
// Get all Time Series types in the environment
AsyncPageable<TimeSeriesType> getAllTypesResponse = client.Types.GetTypesAsync();

await foreach (TimeSeriesType tsiType in getAllTypesResponse)
{
    Console.WriteLine($"Retrieved Time Series Insights type with Id: '{tsiType?.Id}' and Name: '{tsiType?.Name}'");
}
```

Use `Types.GetByIdAsync` with list of types' unique identifiers or names to get a list of specific types.
```C# Snippet:TimeSeriesInsightsSampleGetTypeById
// Code snippet below shows getting a default Type using Id
// The default type Id can be obtained programmatically by using the ModelSettings client.

TimeSeriesModelSettings modelSettings = await client.ModelSettings.GetAsync().ConfigureAwait(false);
Response<TimeSeriesTypeOperationResult[]> getTypeByIdResults = await client
    .Types
    .GetByIdAsync(new string[] { modelSettings.DefaultTypeId })
    .ConfigureAwait(false);

// The response of calling the API contains a list of type or error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < getTypeByIdResults.Value.Length; i++)
{
    if (getTypeByIdResults.Value[i].Error == null)
    {
        Console.WriteLine($"Retrieved Time Series type with Id: '{getTypeByIdResults.Value[i].TimeSeriesType.Id}'.");
    }
    else
    {
        Console.WriteLine($"Failed to retrieve a Time Series type due to '{getTypeByIdResults.Value[i].Error.Message}'.");
    }
}
```

### Replace types

To replace types, use `Types.CreateOrReplaceAsync` with a list of `TimeSeriesType`.
```C# Snippet:TimeSeriesInsightsSampleReplaceType
// Update variables with adding a new variable
foreach (TimeSeriesType type in timeSeriesTypes)
{
    type.Description = "Description";
}

Response<TimeSeriesTypeOperationResult[]> updateTypesResult = await client
    .Types
    .CreateOrReplaceAsync(timeSeriesTypes)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < updateTypesResult.Value.Length; i++)
{
    if (updateTypesResult.Value[i].Error == null)
    {
        Console.WriteLine($"Updated Time Series type successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to update a Time Series Insights type due to: {updateTypesResult.Value[i].Error.Message}.");
    }
}
```

### Delete types

To delete types, use `Types.DeleteByIdAsync` and pass in a list of type Ids or names for the types you want to delete.
```C# Snippet:TimeSeriesInsightsSampleDeleteTypeById
// Delete Time Series types with Ids

var typesIdsToDelete = new List<string> { "Type1Id", " Type2Id" };
Response<TimeSeriesOperationError[]> deleteTypesResponse = await client
    .Types
    .DeleteByIdAsync(typesIdsToDelete)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter
// array in the request. If the error object is set to null, this means the operation was a success.
foreach (var result in deleteTypesResponse.Value)
{
    if (result != null)
    {
        Console.WriteLine($"Failed to delete a Time Series Insights type: {result.Message}.");
    }
    else
    {
        Console.WriteLine($"Deleted a Time Series Insights type successfully.");
    }
}
```

## Create, get, replace, and delete hierarchies

### Create hierarchies
You can use the following snippet to create hierarchies.

```C# Snippet:TimeSeriesInsightsSampleCreateHierarchies
var tsiHierarchyName = "sampleHierarchy";
var tsiInstanceField1 = "hierarchyLevel1";
var hierarchySource = new TimeSeriesHierarchySource();
hierarchySource.InstanceFieldNames.Add(tsiInstanceField1);

var tsiHierarchy = new TimeSeriesHierarchy(tsiHierarchyName, hierarchySource);
tsiHierarchy.Id = "sampleHierarchyId";

var timeSeriesHierarchies = new List<TimeSeriesHierarchy>
{
    tsiHierarchy
};

// Create Time Series hierarchies
Response<TimeSeriesHierarchyOperationResult[]> createHierarchiesResult = await client
    .Hierarchies
    .CreateOrReplaceAsync(timeSeriesHierarchies)
    .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < createHierarchiesResult.Value.Length; i++)
{
    if (createHierarchiesResult.Value[i].Error == null)
    {
        Console.WriteLine($"Created Time Series hierarchy successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to create a Time Series hierarchy: {createHierarchiesResult.Value[i].Error.Message}.");
    }
}
```

### Get hierarchies

Using `Hierarchies.GetAsync`, all created hierarchies are returned as `AsyncPageable<TimeSeriesHierarchy>`.
```C# Snippet:TimeSeriesInsightsSampleGetAllHierarchies
// Get all Time Series hierarchies in the environment
AsyncPageable<TimeSeriesHierarchy> getAllHierarchies = client.Hierarchies.GetAsync();
await foreach (TimeSeriesHierarchy hierarchy in getAllHierarchies)
{
    Console.WriteLine($"Retrieved Time Series Insights hierarchy with Id: '{hierarchy.Id}' and Name: '{hierarchy.Name}'.");
}
```

Use `Hierarchies.GetByIdAsync` with list of hierarchies unique identifiers or names to get a list of specific hierarchies.
```C# Snippet:TimeSeriesInsightsSampleGetHierarchiesById
var tsiHierarchyIds = new List<string>
{
    "sampleHierarchyId"
};

Response<TimeSeriesHierarchyOperationResult[]> getHierarchiesByIdsResult = await client
            .Hierarchies
            .GetByIdAsync(tsiHierarchyIds)
            .ConfigureAwait(false);

// The response of calling the API contains a list of hieararchy or error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < getHierarchiesByIdsResult.Value.Length; i++)
{
    if (getHierarchiesByIdsResult.Value[i].Error == null)
    {
        Console.WriteLine($"Retrieved Time Series hieararchy with Id: '{getHierarchiesByIdsResult.Value[i].Hierarchy.Id}'.");
    }
    else
    {
        Console.WriteLine($"Failed to retrieve a Time Series hieararchy due to '{getHierarchiesByIdsResult.Value[i].Error.Message}'.");
    }
}
```

### Replace hierarchies

To replace hierarchies, pass in a list of `TimeSeriesHierarchy`.
```C# Snippet:TimeSeriesInsightsSampleReplaceHierarchies
// Update hierarchies with adding a new instance field
var tsiInstanceField2 = "hierarchyLevel2";
foreach (TimeSeriesHierarchy hierarchy in timeSeriesHierarchies)
{
    hierarchy.Source.InstanceFieldNames.Add(tsiInstanceField2);
}

Response<TimeSeriesHierarchyOperationResult[]> updateHierarchiesResult = await client
        .Hierarchies
        .CreateOrReplaceAsync(timeSeriesHierarchies)
        .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter array in the request.
// If the error object is set to null, this means the operation was a success.
for (int i = 0; i < updateHierarchiesResult.Value.Length; i++)
{
    if (updateHierarchiesResult.Value[i].Error == null)
    {
        Console.WriteLine($"Updated Time Series hierarchy successfully.");
    }
    else
    {
        Console.WriteLine($"Failed to update a Time Series Insights hierarchy due to: {updateHierarchiesResult.Value[i].Error.Message}.");
    }
}
```

### Delete hierarchies

To delete hierarchies, pass in a list of hierarchies Ids or names for the hierarchies you want to delete.
```C# Snippet:TimeSeriesInsightsSampleDeleteHierarchiesById
// Delete Time Series hierarchies with Ids
var tsiHierarchyIdsToDelete = new List<string>
{
    "sampleHiearchyId"
};

Response<TimeSeriesOperationError[]> deleteHierarchiesResponse = await client
        .Hierarchies
        .DeleteByIdAsync(tsiHierarchyIdsToDelete)
        .ConfigureAwait(false);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter
// array in the request. If the error object is set to null, this means the operation was a success.
foreach (TimeSeriesOperationError result in deleteHierarchiesResponse.Value)
{
    if (result != null)
    {
        Console.WriteLine($"Failed to delete a Time Series Insights hierarchy: {result.Message}.");
    }
    else
    {
        Console.WriteLine($"Deleted a Time Series Insights hierarchy successfully.");
    }
}
```

## Get and delete model settings

### Get model settings

Using `ModelSettings.GetAsync`, model display name, Time Series Id properties and default type ID are returned with the  `Response<TimeSeriesModelSettings>`.
```C# Snippet:TimeSeriesInsightsSampleGetModelSettings
Response<TimeSeriesModelSettings> getModelSettingsResponse = await client.ModelSettings.GetAsync();
Console.WriteLine($"Retrieved Time Series Insights model settings:\n{JsonSerializer.Serialize(getModelSettingsResponse.Value)}");
```

### Update model settings

Here's how to update model display name or default type Id.
```C# Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName
Response<TimeSeriesModelSettings> updateModelSettingsNameResponse = await client.ModelSettings.UpdateNameAsync("NewModelSettingsName");
Console.WriteLine($"Updated Time Series Insights model settings name:\n" +
    $"{JsonSerializer.Serialize(updateModelSettingsNameResponse.Value)}");
```

```C# Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
Response<TimeSeriesModelSettings> updateDefaultTypeIdResponse = await client.ModelSettings.UpdateDefaultTypeIdAsync(tsiTypeId);
Console.WriteLine($"Updated Time Series Insights model settings default type Id:\n" +
    $"{JsonSerializer.Serialize(updateDefaultTypeIdResponse.Value)}");
```

## Query raw events, series, and aggregates

TBD
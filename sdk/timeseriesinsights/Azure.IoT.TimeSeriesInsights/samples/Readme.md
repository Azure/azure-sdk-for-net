# Introduction

A `TimeSeriesInsightsClient` is the primary interface for developers using the Time Series Insights client library. It provides both synchronous and asynchronous operations to perform operations on a Time Series Insights environment. The `TimeSeriesInsightsClient` exposes several properties that a developer will use to perform specific operations on a Time Series Insights environment. For example, `ModelSettings` is the property that a developer can use to perform operations on the model settings of the TSI environment. `Instances` can be used to perform operations on TSI instances. Other properties include `Types`, `Hierarchies` and `Query`.

## Creating TimeSeriesInsightsClient

To create a new Time Series Insights client, you need the endpoint to an Azure Time Series Insights environment and supply credentials.
To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the [Azure.Identity][AzureIdentity].

```C# Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret
// DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based on the environment it is executing in.
// It attempts to use multiple credential types in an order until it finds a working credential.
var tokenCredential = new DefaultAzureCredential();

var client = new TimeSeriesInsightsClient(
    tsiEndpoint,
    tokenCredential);
```

## Time Series Insights Samples

The following section provides several code snippets using the `client` created above, and covers the main functions of Time Series Insights. You can explore and learn more about the Time Series Insights client library APIs through using the samples project.

- [Time Series Insights ID](#time-series-insights-id)
- [Time Series Insights Model Settings](#time-series-insights-model-settings)
- [Time Series Insights Instances](#time-series-insights-instances)
- [Time Series Insights Types](#time-series-insights-types)
- [Time Series Insights Hierarchies](#time-series-insights-hierarchies)
- [Time Series Insights Query](#time-series-insights-query)

## Time Series Insights ID
A single Time Series ID value is composed of up to 3 string values that uniquely identify a Time Series instance. The keys that make up the Time Series ID are chosen when creating a Time Series Insights Gen2 environment through the Azure portal. The position of values must match Time Series ID properties specified on the environment and returned by Get Model Setting API.  For example, if your Time Series Insights environment is setup with ID properties `Building`, `Floor` and `Room`, then this code snippet illustrates creating a Time Series instance ID using `TimeSeriesId` class for `Building` : 'Millennium', `Floor` : 'Floor2' and `Room` : '2A01'. Visit [this page][tsi_id_learn_more] to check out the best practices for choosing a Time Series ID.

```csharp
var instanceId =  new TimeSeriesId("Millennium", "Floor2", "2A01");
```

> **Please note that this sample is set up to work best when the Time Series Insights ID key that is configured with your environment is not one of the default telemetry system properties, such as iothub-connection-device-id. The reason being is that this sample will generate random unique strings for each TSI ID key that you have set up for your TSI environment, and use these randomly generated strings when sending telemetry to IoT Hub. But since the iothub-connection-device-id is already a random identifier for a device, setting up your TSI environment with ID key as iothub-connection-device-id will not make the sample run as expected since TSI will create an instance per device. For this sample to mimic a more realistic TSI environment, use Building, Floor and Room as properties for your Time Series Insights IDs.**

## Time Series Insights Model Settings

Use `ModelSettings` in [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs) to learn more about the environment model settings, such as name, default type ID, and the properties that define the Time Series ID during environment creation.

```C# Snippet:TimeSeriesInsightsSampleGetModelSettings
TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
TimeSeriesInsightsTypes typesClient = client.GetTypesClient();
Response<TimeSeriesModelSettings> getModelSettingsResponse = await modelSettingsClient.GetAsync();
Console.WriteLine($"Retrieved Time Series Insights model settings \nname : '{getModelSettingsResponse.Value.Name}', " +
    $"default type Id: {getModelSettingsResponse.Value.DefaultTypeId}'");
IReadOnlyList<TimeSeriesIdProperty> timeSeriesIdProperties = getModelSettingsResponse.Value.TimeSeriesIdProperties;
foreach (TimeSeriesIdProperty property in timeSeriesIdProperties)
{
    Console.WriteLine($"Time Series Id property name : '{property.Name}', type : '{property.PropertyType}'.");
}
```

Here's what a retrieved model settings object looks like.
```json
{
  "Name": "sampleModel",
  "TimeSeriesIdProperties": [
    {
      "Name": "Building",
      "Type": {
        "HasValue": true,
        "Value": {

        }
      }
    },
    {
      "Name": "Floor",
      "Type": {
        "HasValue": true,
        "Value": {

        }
      }
    },
    {
      "Name": "Room",
      "Type": {
        "HasValue": true,
        "Value": {

        }
      }
    }
  ],
  "DefaultTypeId": "86fc3da5-a7cb-443a-b7c3-00a7d9ebb72d"
}
```

You can also use `ModelSettings` object to make changes to the model settings name and/or default type ID.

```C# Snippet:TimeSeriesInsightsSampleUpdateModelSettingsName
Response<TimeSeriesModelSettings> updateModelSettingsNameResponse = await modelSettingsClient.UpdateNameAsync("NewModelSettingsName");
Console.WriteLine($"Updated Time Series Insights model settings name: " +
    $"{updateModelSettingsNameResponse.Value.Name}");
```

```C# Snippet:TimeSeriesInsightsSampleUpdateModelSettingsDefaultType
Response<TimeSeriesModelSettings> updateDefaultTypeIdResponse = await modelSettingsClient
    .UpdateDefaultTypeIdAsync(tsiTypeId);
Console.WriteLine($"Updated Time Series Insights model settings default type Id: " +
    $"{updateDefaultTypeIdResponse.Value.Name}");
```

## Time Series Insights Instances

Time Series Model instances are virtual representations of the time series themselves. To learn more about Time Series Model instances, make sure you visit [this page][tsi_instances_learn_more].

Use `Instances` in [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs) to perform a variety of operations on the environment's instances.

This code snippet demonstrates retrieving all created instances in your TSI environment.
```C# Snippet:TimeSeriesInsightsGetAllInstances
// Get all instances for the Time Series Insights environment
AsyncPageable<TimeSeriesInstance> tsiInstances = instancesClient.GetAsync();
await foreach (TimeSeriesInstance tsiInstance in tsiInstances)
{
    Console.WriteLine($"Retrieved Time Series Insights instance with Id '{tsiInstance.TimeSeriesId}' and name '{tsiInstance.Name}'.");
}
```

This code snippet demonstrates creating a list of Time Series instances in your environment.
```C# Snippet:TimeSeriesInsightsSampleCreateInstance
// Create a Time Series Instance object with the default Time Series Insights type Id.
// The default type Id can be obtained programmatically by using the ModelSettings client.
// tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
var instance = new TimeSeriesInstance(tsId, defaultTypeId)
{
    Name = "instance1",
};

var tsiInstancesToCreate = new List<TimeSeriesInstance>
{
    instance,
};

Response<TimeSeriesOperationError[]> createInstanceErrors = await instancesClient
    .CreateOrReplaceAsync(tsiInstancesToCreate);

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
        Console.WriteLine($"Failed to create a Time Series Insights instance with Id '{tsiId}', " +
            $"Error Message: '{createInstanceErrors.Value[i].Message}, " +
            $"Error code: '{createInstanceErrors.Value[i].Code}'.");
    }
}
```

You can also retrieve specific instances by their unique identifier, or by the Time Series instance names.

```C# Snippet:TimeSeriesInsightsGetnstancesById
// Get Time Series Insights instances by Id
// tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
var timeSeriesIds = new List<TimeSeriesId>
{
    tsId,
};

Response<InstancesOperationResult[]> getByIdsResult = await instancesClient.GetByIdAsync(timeSeriesIds);

// The response of calling the API contains a list of instance or error objects corresponding by position to the array in the request.
// Instance object is set when operation is successful and error object is set when operation is unsuccessful.
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

Similarly, you can delete specific instances by their unique identifier, or by the Time Series instances names.

```C# Snippet:TimeSeriesInsightsSampleDeleteInstanceById
// tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
var instancesToDelete = new List<TimeSeriesId>
{
    tsId,
};

Response<TimeSeriesOperationError[]> deleteInstanceErrors = await instancesClient
    .DeleteByIdAsync(instancesToDelete);

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

This code snippet demonstrates replacing an existing Time Series instance.
```C# Snippet:TimeSeriesInsightsReplaceInstance
// Get Time Series Insights instances by Id
// tsId is created above using `TimeSeriesIdHelper.CreateTimeSeriesId`.
var instanceIdsToGet = new List<TimeSeriesId>
{
    tsId,
};

Response<InstancesOperationResult[]> getInstancesByIdResult = await instancesClient.GetByIdAsync(instanceIdsToGet);

TimeSeriesInstance instanceResult = getInstancesByIdResult.Value[0].Instance;
Console.WriteLine($"Retrieved Time Series Insights instance with Id '{instanceResult.TimeSeriesId}' and name '{instanceResult.Name}'.");

// Now let's replace the instance with an updated name
instanceResult.Name = "newInstanceName";

var instancesToReplace = new List<TimeSeriesInstance>
{
    instanceResult,
};

Response<InstancesOperationResult[]> replaceInstancesResult = await instancesClient.ReplaceAsync(instancesToReplace);

// The response of calling the API contains a list of error objects corresponding by position to the input parameter.
// array in the request. If the error object is set to null, this means the operation was a success.
for (int i = 0; i < replaceInstancesResult.Value.Length; i++)
{
    TimeSeriesId tsiId = instancesToReplace[i].TimeSeriesId;

    TimeSeriesOperationError currentError = replaceInstancesResult.Value[i].Error;

    if (currentError != null)
    {
        Console.WriteLine($"Failed to replace Time Series Insights instance with Id '{tsiId}'," +
            $" Error Message: '{currentError.Message}', Error code: '{currentError.Code}'.");
    }
    else
    {
        Console.WriteLine($"Replaced Time Series Insights instance with Id '{tsiId}'.");
    }
}
```

## Time Series Insights Types
Use `Types` in [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs) to create, retrieve, replace and delete Time Series types in your environment.

This snippet demonstrates creating a Time Series type in your environment.

```C# Snippet:TimeSeriesInsightsSampleCreateType
TimeSeriesInsightsTypes typesClient = client.GetTypesClient();

// Create a type with an aggregate variable
var timeSeriesTypes = new List<TimeSeriesType>();

var countExpression = new TimeSeriesExpression("count()");
var aggregateVariable = new AggregateVariable(countExpression);
var variables = new Dictionary<string, TimeSeriesVariable>();
variables.Add("aggregateVariable", aggregateVariable);

timeSeriesTypes.Add(new TimeSeriesType("Type1", variables) { Id = "Type1Id" });
timeSeriesTypes.Add(new TimeSeriesType("Type2", variables) { Id = "Type2Id" });

Response<TimeSeriesTypeOperationResult[]> createTypesResult = await typesClient
    .CreateOrReplaceAsync(timeSeriesTypes);

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

This snippet demonstrates retrieving all created types in your environment in pages. You can enumerate an AsyncPageable object using the `async foreach` loop.

```C# Snippet:TimeSeriesInsightsSampleGetAllTypes
// Get all Time Series types in the environment
AsyncPageable<TimeSeriesType> getAllTypesResponse = typesClient.GetTypesAsync();

await foreach (TimeSeriesType tsiType in getAllTypesResponse)
{
    Console.WriteLine($"Retrieved Time Series Insights type with Id: '{tsiType?.Id}' and Name: '{tsiType?.Name}'");
}
```

This snippet highlights how you can retrieve a list of specific Time Series types by their unique identifiers or names.

```C# Snippet:TimeSeriesInsightsSampleGetTypeById
// Code snippet below shows getting a default Type using Id
// The default type Id can be obtained programmatically by using the ModelSettings client.

TimeSeriesInsightsModelSettings modelSettingsClient = client.GetModelSettingsClient();
TimeSeriesModelSettings modelSettings = await modelSettingsClient.GetAsync();
Response<TimeSeriesTypeOperationResult[]> getTypeByIdResults = await typesClient
    .GetByIdAsync(new string[] { modelSettings.DefaultTypeId });

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

Similarly, you can delete Time Series types by providing a list of Time Series type Ids or names.

```C# Snippet:TimeSeriesInsightsSampleDeleteTypeById
// Delete Time Series types with Ids

var typesIdsToDelete = new List<string> { "Type1Id", " Type2Id" };
Response<TimeSeriesOperationError[]> deleteTypesResponse = await typesClient
    .DeleteByIdAsync(typesIdsToDelete);

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

This code snippet demonstrates replacing an existing Time Series type.

```C# Snippet:TimeSeriesInsightsSampleReplaceType
// Update variables with adding a new variable
foreach (TimeSeriesType type in timeSeriesTypes)
{
    type.Description = "Description";
}

Response<TimeSeriesTypeOperationResult[]> updateTypesResult = await typesClient
    .CreateOrReplaceAsync(timeSeriesTypes);

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

## Time Series Insights Hierarchies

Time Series Model hierarchies organize instances by specifying property names and their relationships. You can configure multiple hierarchies in a given Azure Time Series Insights Gen2 environment. A Time Series Model instance can map to a single hierarchy or multiple hierarchies (many-to-many relationship). To learn more about Time Series Model hierarchies, make sure you visit [this page][tsi_hierarchies_learn_more].

Use `Hierarchies` in [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs) to perform a variety of operations on the environment's hierarchies.

This code snippet demonstrates creating hierarchies in your Time Series Insights environment.

```C# Snippet:TimeSeriesInsightsSampleCreateHierarchies
TimeSeriesInsightsHierarchies hierarchiesClient = client.GetHierarchiesClient();

var hierarchySource = new TimeSeriesHierarchySource();
hierarchySource.InstanceFieldNames.Add("hierarchyLevel1");

var tsiHierarchy = new TimeSeriesHierarchy("sampleHierarchy", hierarchySource)
{
    Id = "sampleHierarchyId"
};

var timeSeriesHierarchies = new List<TimeSeriesHierarchy>
{
    tsiHierarchy
};

// Create Time Series hierarchies
Response<TimeSeriesHierarchyOperationResult[]> createHierarchiesResult = await hierarchiesClient
    .CreateOrReplaceAsync(timeSeriesHierarchies);

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

This code snippet demonstrates retrieving all hierarchies in your environment in pages. You can enumerate an AsyncPageable object using the `async foreach` loop.

```C# Snippet:TimeSeriesInsightsSampleGetAllHierarchies
// Get all Time Series hierarchies in the environment
AsyncPageable<TimeSeriesHierarchy> getAllHierarchies = hierarchiesClient.GetAsync();
await foreach (TimeSeriesHierarchy hierarchy in getAllHierarchies)
{
    Console.WriteLine($"Retrieved Time Series Insights hierarchy with Id: '{hierarchy.Id}' and Name: '{hierarchy.Name}'.");
}
```

You can use a list of hierarchy IDs or names to get specific hierarchies, as demonstrated in this code snippet.

```C# Snippet:TimeSeriesInsightsSampleGetHierarchiesById
var tsiHierarchyIds = new List<string>
{
    "sampleHierarchyId"
};

Response<TimeSeriesHierarchyOperationResult[]> getHierarchiesByIdsResult = await hierarchiesClient
            .GetByIdAsync(tsiHierarchyIds);

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

Similarly, you can use a list of hierarchies Ids or names to be able to delete hierarchies, as demonstrated in this code snippet.
```C# Snippet:TimeSeriesInsightsSampleDeleteHierarchiesById
// Delete Time Series hierarchies with Ids
var tsiHierarchyIdsToDelete = new List<string>
{
    "sampleHiearchyId"
};

Response<TimeSeriesOperationError[]> deleteHierarchiesResponse = await hierarchiesClient
        .DeleteByIdAsync(tsiHierarchyIdsToDelete);

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

This code snippet demonstrates replacing a Time Series hierarchy.

```C# Snippet:TimeSeriesInsightsSampleReplaceHierarchies
// Update hierarchies with adding a new instance field
foreach (TimeSeriesHierarchy hierarchy in timeSeriesHierarchies)
{
    hierarchy.Source.InstanceFieldNames.Add("hierarchyLevel2");
}

Response<TimeSeriesHierarchyOperationResult[]> updateHierarchiesResult = await hierarchiesClient
        .CreateOrReplaceAsync(timeSeriesHierarchies);

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

## Time Series Insights Query

Use `Queries` in [TimeSeriesInsightsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/src/TimeSeriesInsightsClient.cs) to query for:
- Raw events for a given Time Series ID and search span.
- Computed values and the associated event timestamps by applying calculations defined by variables on raw events. These variables can be defined in either the Time Series Model or provided inline in the query.
- Aggregated values and the associated interval timestamps by applying calculations defined by variables on raw events. These variables can be defined in either the Time Series Model or provided inline in the query.

Response for the `Query` APIs are of type `QueryAnalyzer`. The QueryAnalyzer allows a developer to query for pages of results, while being able to perform operations on the result set as a whole. For example, to get a list of `TimeSeriesPoint` in pages, call the `GetResultsAsync` method on the `TimeSeriesQuery` object. You can enumerate an AsyncPageable object using the `async foreach` loop.

This code snippet demonstrates querying for raw events with using a time span interval.

```C# Snippet:TimeSeriesInsightsSampleQueryEventsUsingTimeSpan
Console.WriteLine("\n\nQuery for raw humidity events over the past 30 seconds.\n");

TimeSeriesQueryAnalyzer humidityEventsQuery = queriesClient.CreateEventsQuery(tsId, TimeSpan.FromSeconds(30));
await foreach (TimeSeriesPoint point in humidityEventsQuery.GetResultsAsync())
{
    TimeSeriesValue humidityValue = point.GetValue("Humidity");

    // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
    // environment best, you probably do not need this logic and you can skip to directly casting to the proper
    // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
    // too familiar with the property type.
    if (humidityValue.Type == typeof(double?))
    {
        Console.WriteLine($"{point.Timestamp} - Humidity: {point.GetNullableDouble("Humidity")}");
    }
    else if (humidityValue.Type == typeof(int?))
    {
        Console.WriteLine($"{point.Timestamp} - Humidity: {point.GetNullableInt("Humidity")}");
    }
    else
    {
        Console.WriteLine("The type of the Time Series value for Humidity is not numeric.");
    }
}
```

The client library also provides a way to query for raw events using using a start and end time, as demonstrated in this code snippet.

```C# Snippet:TimeSeriesInsightsSampleQueryEvents
Console.WriteLine("\n\nQuery for raw temperature events over the past 10 minutes.\n");

// Get events from last 10 minute
DateTimeOffset endTime = DateTime.UtcNow;
DateTimeOffset startTime = endTime.AddMinutes(-10);

TimeSeriesQueryAnalyzer temperatureEventsQuery = queriesClient.CreateEventsQuery(tsId, startTime, endTime);
await foreach (TimeSeriesPoint point in temperatureEventsQuery.GetResultsAsync())
{
    TimeSeriesValue temperatureValue = point.GetValue("Temperature");

    // Figure out what is the underlying type for the time series value. Since you know your Time Series Insights
    // environment best, you probably do not need this logic and you can skip to directly casting to the proper
    // type. This logic demonstrates how you can figure out what type to cast to in the case where you are not
    // too familiar with the property type.
    if (temperatureValue.Type == typeof(double?))
    {
        Console.WriteLine($"{point.Timestamp} - Temperature: {point.GetNullableDouble("Temperature")}");
    }
    else if (temperatureValue.Type == typeof(int?))
    {
        Console.WriteLine($"{point.Timestamp} - Temperature: {point.GetNullableInt("Temperature")}");
    }
    else
    {
        Console.WriteLine("The type of the Time Series value for Temperature is not numeric.");
    }
}
```

This code snippet demonstrates querying for series events. In this snippet, we query for the temperature both in Celsius and fahrenheit. The Time Series instance that we query from has predefined numeric variables, one for the Celsius and the other for Fahrenheit.

```C# Snippet:TimeSeriesInsightsSampleQuerySeries
Console.WriteLine($"\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes. " +
    $"The Time Series instance belongs to a type that has predefined numeric variable that represents the temperature " +
    $"in Celsuis, and a predefined numeric variable that represents the temperature in Fahrenheit.\n");

DateTimeOffset endTime = DateTime.UtcNow;
DateTimeOffset startTime = endTime.AddMinutes(-10);
TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
    tsId,
    startTime,
    endTime);

await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
{
    double? tempInCelsius = point.GetNullableDouble(celsiusVariableName);
    double? tempInFahrenheit = point.GetNullableDouble(fahrenheitVariableName);

    Console.WriteLine($"{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. " +
        $"Average temperature in Fahrenheit: {tempInFahrenheit}.");
}
```

You can also query for series events with variables defined in the request options. In this snippet, we create two [numeric variables][tsi_numeric_variables], one for the Celsius and the other for Fahrenheit. These variables are then added as inline variables to the request options.

```C# Snippet:TimeSeriesInsightsSampleQuerySeriesWithInlineVariables
Console.WriteLine("\n\nQuery for temperature series in Celsius and Fahrenheit over the past 10 minutes.\n");

var celsiusVariable = new NumericVariable(
    new TimeSeriesExpression("$event.Temperature"),
    new TimeSeriesExpression("avg($value)"));
var fahrenheitVariable = new NumericVariable(
    new TimeSeriesExpression("$event.Temperature * 1.8 + 32"),
    new TimeSeriesExpression("avg($value)"));

var querySeriesRequestOptions = new QuerySeriesRequestOptions();
querySeriesRequestOptions.InlineVariables["TemperatureInCelsius"] = celsiusVariable;
querySeriesRequestOptions.InlineVariables["TemperatureInFahrenheit"] = fahrenheitVariable;

TimeSeriesQueryAnalyzer seriesQuery = queriesClient.CreateSeriesQuery(
    tsId,
    TimeSpan.FromMinutes(10),
    null,
    querySeriesRequestOptions);

await foreach (TimeSeriesPoint point in seriesQuery.GetResultsAsync())
{
    double? tempInCelsius = (double?)point.GetValue("TemperatureInCelsius");
    double? tempInFahrenheit = (double?)point.GetValue("TemperatureInFahrenheit");

    Console.WriteLine($"{point.Timestamp} - Average temperature in Celsius: {tempInCelsius}. Average temperature in Fahrenheit: {tempInFahrenheit}.");
}
```

This code snippet demonstrates querying for aggregated values. More specifically, the number of temperature events that the TSI environment has ingested over the past 3 minutes, in 1-minute time slots. In order to achieve this, a `count` [AggregateVariable][tsi_aggregate_variables] is added as an inline variable to the request options.

```C# Snippet:TimeSeriesInsightsSampleQueryAggregateSeriesWithAggregateVariable
Console.WriteLine("\n\nCount the number of temperature events over the past 3 minutes, in 1-minute time slots.\n");

// Get the count of events in 60-second time slots over the past 3 minutes
DateTimeOffset endTime = DateTime.UtcNow;
DateTimeOffset startTime = endTime.AddMinutes(-3);

var aggregateVariable = new AggregateVariable(
    new TimeSeriesExpression("count()"));

var countVariableName = "Count";

var aggregateSeriesRequestOptions = new QueryAggregateSeriesRequestOptions();
aggregateSeriesRequestOptions.InlineVariables[countVariableName] = aggregateVariable;
aggregateSeriesRequestOptions.ProjectedVariableNames.Add(countVariableName);

TimeSeriesQueryAnalyzer query = queriesClient.CreateAggregateSeriesQuery(
    tsId,
    startTime,
    endTime,
    TimeSpan.FromSeconds(60),
    aggregateSeriesRequestOptions);

await foreach (TimeSeriesPoint point in query.GetResultsAsync())
{
    long? temperatureCount = (long?)point.GetValue(countVariableName);
    Console.WriteLine($"{point.Timestamp} - Temperature count: {temperatureCount}");
}
```

<!-- LINKS -->
[AzureIdentity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[DefaultAzureCredential]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[tsi_instances_learn_more]: https://learn.microsoft.com/azure/time-series-insights/concepts-model-overview#time-series-model-instances
[tsi_id_learn_more]: https://learn.microsoft.com/azure/time-series-insights/how-to-select-tsid
[tsi_hierarchies_learn_more]: https://learn.microsoft.com/azure/time-series-insights/concepts-model-overview#time-series-model-hierarchies
[tsi_numeric_variables]: https://learn.microsoft.com/azure/time-series-insights/concepts-variables#numeric-variables
[tsi_aggregate_variables]: https://learn.microsoft.com/azure/time-series-insights/concepts-variables#aggregate-variables

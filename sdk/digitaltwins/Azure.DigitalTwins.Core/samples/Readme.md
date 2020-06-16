# Introduction

Azure Digital Twins is a developer platform for next-generation IoT solutions that lets you create, run, and manage digital representations of your business environment, securely and efficiently in the cloud. With Azure Digital Twins, creating live operational state representations is quick and cost-effective, and digital representations stay current with real-time data from IoT and other data sources. If you are new to Azure Digital Twins and would like to learn more about the platform, please make sure you check out the Azure Digital Twins [official documentation page](https://docs.microsoft.com/azure/digital-twins/overview). 

For an introduction on how to program against the Azure Digital Twins service, visit the [coding tutorial page](https://docs.microsoft.com/en-us/azure/digital-twins/tutorial-code) for an easy step-by-step guide. Visit [this tutorial](https://docs.microsoft.com/azure/digital-twins/tutorial-command-line-app) to learn how to interact with an Azure Digital Twin instance using a command-line client application. Finally, for a quick guide on how to build an end-to-end Azure Digital Twins solution that is driven by live data from your environment, make sure you check out [this helpful guide](https://docs.microsoft.com/azure/digital-twins/tutorial-end-to-end).

The guides mentioned above can help you get started with key elements of Azure Digital Twins, such as creating Azure Digital Twins instances, models, twin graphs, etc. Use this samples guide below to familiarize yourself with the various APIs that help you program against Azure Digital Twins.

# Digital Twins Samples

You can explore the digital twins APIs (using the client library) using the samples project.

The samples project demonstrates the following:

- Instantiate the client
- Create, get, and decommission models
- Create, query, and delete a digital twin
- Get and update components for a digital twin
- Create, get, and delete relationships between digital twins
- Create, get, and delete event routes for digital twin
- Publish telemetry messages to a digital twin and digital twin component

## Creating the digital twins client

To create a new digital twins client, you need the endpoint to an Azure Digital Twin instance and credentials.
In the sample below, you can set `AdtEndpoint`, `TenantId`, `ClientId`, and `ClientSecret` as command-line arguments.
The client requires an instance of [TokenCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In this samples, we illustrate how to use one derived class: ClientSecretCredential.

> Note: In order to access the data plane for the Digital Twins service, the entity must be given permissions.
> To do this, use the Azure CLI command: `az dt rbac assign-role --assignee '<user-email | application-id>' --role owner -n '<your-digital-twins-instance>'`

```C# Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret
// DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
// It attempts to use multiple credential types in an order until it finds a working credential.
var tokenCredential = new DefaultAzureCredential();

var client = new DigitalTwinsClient(
    new Uri(adtEndpoint),
    tokenCredential);
```

Also, if you need to override pipeline behavior, such as provide your own HttpClient instance, you can do that via the other constructor that takes a client options.
It provides an opportunity to override default behavior including:

- Specifying API version
- Overriding [transport](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Pipeline.md)
- Enabling [diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md)
- Controlling [retry strategy](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Configuration.md)

## Create, list, decommission, and delete models

### Create models

Let's create models using the code below. You need to pass in `List<string>` containing list of json models.
Check out sample models [here](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/DTDL/Models).

```C# Snippet:DigitalTwinsSampleCreateModels
Response<IReadOnlyList<ModelData>> response = await client.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload });
Console.WriteLine($"Created models with Ids {componentModelId} and {sampleModelId}. Response status: {response.GetRawResponse().Status}");
```

### List models

Using `GetModelsAsync`, all created models are returned as `AsyncPageable<ModelData>`.

```C# Snippet:DigitalTwinsSampleGetModels
AsyncPageable<ModelData> allModels = client.GetModelsAsync();
await foreach (ModelData model in allModels)
{
    Console.WriteLine($"Retrieved model with Id {model.Id}, display name {model.DisplayName["en"]}, upload time {model.UploadTime}, and decommissioned: {model.Decommissioned}");
}
```

Use `GetModelAsync` with model's unique identifier to get a specific model.

```C# Snippet:DigitalTwinsSampleGetModel
Response<ModelData> sampleModel = await client.GetModelAsync(sampleModelId);
Console.WriteLine($"Retrieved model with Id {sampleModelId}. Response status: {sampleModel.GetRawResponse().Status}");
```

### Decommission models

To decommision a model, pass in a model Id for the model you want to decommision.

```C# Snippet:DigitalTwinsSampleDecommisionModel
try
{
    Response decommissionModelResponse = await client.DecommissionModelAsync(sampleModelId);
    Console.WriteLine($"Decommissioned model with Id {sampleModelId}. Response status: {decommissionModelResponse.Status}");
}
catch (RequestFailedException ex)
{
    FatalError($"Failed to decommision model with Id {sampleModelId} due to:\n{ex}");
}
```

### Delete models

To delete a model, pass in a model Id for the model you want to delete.

```C# Snippet:DigitalTwinsSampleDeleteModel
try
{
    Response deleteModelResponse = await client.DeleteModelAsync(sampleModelId);
    Console.WriteLine($"Deleted model with Id {sampleModelId}. Response status: {deleteModelResponse.Status}");
}
catch (Exception ex)
{
    FatalError($"Failed to delete model with Id {sampleModelId} due to:\n{ex}");
}
```

## Create and delete digital twins

### Create digital twins

For Creating Twin you will need to provide Id of a digital Twin such as `myTwin` and the application/json digital twin based on the model created earlier. You can look at sample application/json [here](https://github.com/Azure/azure-sdk-for-net-pr/tree/feature/IoT-ADT/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/DTDL/DigitalTwins "DigitalTwin").

One option is to use the provided class BasicDigitalTwin for serialization and deserialization.
It uses functionality from the `System.Text.Json` library to maintain any unmapped json properties to a dictionary.

```C# Snippet:DigitalTwinsSampleCreateBasicTwin
// Create digital twin with component payload using the BasicDigitalTwin serialization helper

var basicTwin = new BasicDigitalTwin
{
    Id = basicDtId,
    // model Id of digital twin
    Metadata = { ModelId = modelId },
    CustomProperties =
    {
        // digital twin properties
        { "Prop1", "Value1" },
        { "Prop2", 987 },
        // component
        {
            "Component1",
            new ModelProperties
            {
                // component properties
                CustomProperties =
                {
                    { "ComponentProp1", "Component value 1" },
                    { "ComponentProp2", 123 },
                },
            }
        },
    },
};

string basicDtPayload = JsonSerializer.Serialize(basicTwin);

Response<string> createBasicDtResponse = await client.CreateDigitalTwinAsync(basicDtId, basicDtPayload);
Console.WriteLine($"Created digital twin with Id {basicDtId}. Response status: {createBasicDtResponse.GetRawResponse().Status}.");
```

Alternatively, you can create your own custom data types to serialize and deserialize your digital twins.
By specifying your properties and types directly, it requires less code or knowledge of the type for interaction.
You can review the [CustomDigitalTwin definition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/CustomDigitalTwin.cs).

```C# Snippet:DigitalTwinsSampleCreateCustomTwin
var customTwin = new CustomDigitalTwin
{
    Id = customDtId,
    Metadata = { ModelId = modelId },
    Prop1 = "Prop1 val",
    Prop2 = 987,
    Component1 = new Component1
    {
        ComponentProp1 = "Component prop1 val",
        ComponentProp2 = 123,
    }
};
string dt2Payload = JsonSerializer.Serialize(customTwin);

Response<string> createCustomDtResponse = await client.CreateDigitalTwinAsync(customDtId, dt2Payload);
Console.WriteLine($"Created digital twin with Id {customDtId}. Response status: {createCustomDtResponse.GetRawResponse().Status}.");
```

### Get and deserialize a digital twin


You can get a digital twin and deserialize it into a BasicDigitalTwin.
It works well for basic stuff, but as you can see it gets more difficult when delving into more complex properties, like components.

```C# Snippet:DigitalTwinsSampleGetBasicDigitalTwin
Response<string> getBasicDtResponse = await client.GetDigitalTwinAsync(basicDtId);
if (getBasicDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
{
    BasicDigitalTwin basicDt = JsonSerializer.Deserialize<BasicDigitalTwin>(getBasicDtResponse.Value);

    // Must cast Component1 as a JsonElement and get its raw text in order to deserialize it as a dictionary
    string component1RawText = ((JsonElement)basicDt.CustomProperties["Component1"]).GetRawText();
    IDictionary<string, object> component1 = JsonSerializer.Deserialize<IDictionary<string, object>>(component1RawText);

    Console.WriteLine($"Retrieved and deserialized digital twin {basicDt.Id}:\n\t" +
        $"ETag: {basicDt.ETag}\n\t" +
        $"Prop1: {basicDt.CustomProperties["Prop1"]}\n\t" +
        $"Prop2: {basicDt.CustomProperties["Prop2"]}\n\t" +
        $"ComponentProp1: {component1["ComponentProp1"]}\n\t" +
        $"ComponentProp2: {component1["ComponentProp2"]}");
}
```

Getting and deserializing a digital twin into a custom data type is extremely easy.
Custom types provide the best possible experience.

```C# Snippet:DigitalTwinsSampleGetCustomDigitalTwin
Response<string> getCustomDtResponse = await client.GetDigitalTwinAsync(customDtId);
if (getCustomDtResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
{
    CustomDigitalTwin customDt = JsonSerializer.Deserialize<CustomDigitalTwin>(getCustomDtResponse.Value);
    Console.WriteLine($"Retrieved and deserialized digital twin {customDt.Id}:\n\t" +
        $"ETag: {customDt.ETag}\n\t" +
        $"Prop1: {customDt.Prop1}\n\t" +
        $"Prop2: {customDt.Prop2}\n\t" +
        $"ComponentProp1: {customDt.Component1.ComponentProp1}\n\t" +
        $"ComponentProp2: {customDt.Component1.ComponentProp2}");
}
```

### Query digital twins

Query the Azure Digital Twins instance for digital twins using the [Azure Digital Twins Query Store lanaguage](https://review.docs.microsoft.com/en-us/azure/digital-twins-v2/concepts-query-language?branch=pr-en-us-114648). Query calls support paging. Here's an example of how to query for digital twins and how to iterate over the results.

```C# Snippet:DigitalTwinsSampleQueryTwins
// This code snippet demonstrates the simplest way to iterate over the digital twin results, where paging
// happens under the covers.
AsyncPageable<string> asyncPageableResponse = client.QueryAsync("SELECT * FROM digitaltwins");

// Iterate over the twin instances in the pageable response.
// The "await" keyword here is required because new pages will be fetched when necessary,
// which involves a request to the service.
await foreach (string response in asyncPageableResponse)
{
    BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
    Console.WriteLine($"Found digital twin: {twin.Id}");
}
```

The SDK also allows you to extract the `query-charge` header from the pageable response. Here's an example of how to query for digital twins and how to iterate over the pageable response to extract the `query-charge` header.

```C# Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge
// This code snippet demonstrates how you could extract the query charges incurred when calling
// the query API. It iterates over the response pages first to access to the query-charge header,
// and then the digital twin results within each page.

AsyncPageable<string> asyncPageableResponseWithCharge = client.QueryAsync("SELECT * FROM digitaltwins");
int pageNum = 0;

// The "await" keyword here is required as a call is made when fetching a new page.
await foreach (Page<string> page in asyncPageableResponseWithCharge.AsPages())
{
    Console.WriteLine($"Page {++pageNum} results:");

    // Extract the query-charge header from the page
    if (QueryChargeHelper.TryGetQueryCharge(page, out float queryCharge))
    {
        Console.WriteLine($"Query charge was: {queryCharge}");
    }

    // Iterate over the twin instances.
    // The "await" keyword is not required here as the paged response is local.
    foreach (string response in page.Values)
    {
        BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
        Console.WriteLine($"Found digital twin: {twin.Id}");
    }
}
```

### Delete digital twins

Delete a digital twin simply by providing Id of a digital twin as below.

```C# Snippet:DigitalTwinsSampleDeleteTwin
Response deleteDigitalTwinResponse = await client.DeleteDigitalTwinAsync(digitalTwinId);
Console.WriteLine($"Deleted digital twin with Id {digitalTwinId}. Response Status: {deleteDigitalTwinResponse.Status}");
```

## Get and update digital twin components

### Update digital twin components

To update a component or in other words to replace, remove and/or add a component property or subproperty within Digital Twin, you would need Id of a digital twin, component name and application/json-patch+json operations to be performed on the specified digital twin's component. Here is the sample code on how to do it.

```C# Snippet:DigitalTwinsSampleUpdateComponent
// Update Component1 by replacing the property ComponentProp1 value
var componentUpdateUtility = new UpdateOperationsUtility();
componentUpdateUtility.AppendReplaceOp("/ComponentProp1", "Some new value");
string updatePayload = componentUpdateUtility.Serialize();

Response<string> response = await client.UpdateComponentAsync(basicDtId, "Component1", updatePayload);

Console.WriteLine($"Updated component for digital twin with Id {basicDtId}. Response status: {response.GetRawResponse().Status}");
```

### Get digital twin components

Get a component by providing name of a component and Id of digital twin to which it belongs.

```C# Snippet:DigitalTwinsSampleGetComponent
response = await client.GetComponentAsync(basicDtId, SamplesConstants.ComponentPath);

Console.WriteLine($"Retrieved component for digital twin with Id {basicDtId}. Response status: {response.GetRawResponse().Status}");
```

## Create, get,  list and delete digital twin relationships

### Create digital twin relationships

`CreateRelationshipAsync` creates a relationship on a digital twin provided with Id of a digital twin, name of relationship such as "contains", Id of an relationship such as "FloorContainsRoom" and an application/json relationship to be created. Must contain property with key "$targetId" to specify the target of the relationship. Sample payloads for relationships can be found [here](https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/IoT-ADT/sdk/iot/Azure.Iot.DigitalTwins/samples/DigitalTwinServiceClientSample/DTDL/Relationships/HospitalRelationships.json "RelationshipExamples").

One option is to use the provided class BasicRelationship for serialization and deserialization. 
It uses functionality from the `System.Text.Json` library to maintain any unmapped json properties to a dictionary.

```C# Snippet:DigitalTwinsSampleCreateBasicRelationship
var buildingFloorRelationshipPayload = new BasicRelationship
{
    Id = "buildingFloorRelationshipId",
    SourceId = "buildingTwinId",
    TargetId = "floorTwinId",
    Name = "contains",
    CustomProperties =
    {
        { "Prop1", "Prop1 value" },
        { "Prop2", 6 }
    }
};

string serializedRelationship = JsonSerializer.Serialize(buildingFloorRelationshipPayload);
Response<string> createRelationshipResponse = await client.CreateRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId", serializedRelationship);
Console.WriteLine($"Created a digital twin relationship with Id buildingFloorRelationshipId from digital twin with Id buildingTwinId to digital twin with Id floorTwinId. " +
    $"Response status: {createRelationshipResponse.GetRawResponse().Status}.");
```

Alternatively, you can create your own custom data types to serialize and deserialize your relationships.
By specifying your properties and types directly, it requires less code or knowledge of the type for interaction.
You can review the [CustomRelationship definition](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/CustomRelationship.cs).

```C# Snippet:DigitalTwinsSampleCreateCustomRelationship
var floorBuildingRelationshipPayload = new CustomRelationship
{
    Id = "floorBuildingRelationshipId",
    SourceId = "floorTwinId",
    TargetId = "buildingTwinId",
    Name = "containedIn",
    Prop1 = "Prop1 val",
    Prop2 = 4
};
string serializedCustomRelationship = JsonSerializer.Serialize(floorBuildingRelationshipPayload);

Response<string> createCustomRelationshipResponse = await client.CreateRelationshipAsync("floorTwinId", "floorBuildingRelationshipId", serializedCustomRelationship);
Console.WriteLine($"Created a digital twin relationship with Id floorBuildingRelationshipId from digital twin with Id floorTwinId to digital twin with Id buildingTwinId. " +
    $"Response status: {createCustomRelationshipResponse.GetRawResponse().Status}.");
```

### Get and deserialize a digital twin relationship
You can get a digital twin relationship and deserialize it into a BasicRelationship.

```C# Snippet:DigitalTwinsSampleGetBasicRelationship
Response<string> getBasicRelationshipResponse = await client.GetRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId");
if (getBasicRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
{
    BasicRelationship basicRelationship = JsonSerializer.Deserialize<BasicRelationship>(getBasicRelationshipResponse.Value);
    Console.WriteLine($"Retrieved relationship with Id {basicRelationship.Id} from digital twin with Id {basicRelationship.SourceId}. " +
        $"Response status: {getBasicRelationshipResponse.GetRawResponse().Status}.\n\t" +
        $"Prop1: {basicRelationship.CustomProperties["Prop1"]}\n\t" +
        $"Prop2: {basicRelationship.CustomProperties["Prop2"]}");
}
```

Getting and deserializing a digital twin relationship into a custom data type is as easy.
```C# Snippet:DigitalTwinsSampleGetCustomRelationship
Response<string> getCustomRelationshipResponse = await client.GetRelationshipAsync("floorTwinId", "floorBuildingRelationshipId");
if (getCustomRelationshipResponse.GetRawResponse().Status == (int)HttpStatusCode.OK)
{
    CustomRelationship getCustomRelationship = JsonSerializer.Deserialize<CustomRelationship>(getCustomRelationshipResponse.Value);
    Console.WriteLine($"Retrieved and deserialized relationship with Id {getCustomRelationship.Id} from digital twin with Id {getCustomRelationship.SourceId}. " +
        $"Response status: {getCustomRelationshipResponse.GetRawResponse().Status}.\n\t" +
        $"Prop1: {getCustomRelationship.Prop1}\n\t" +
        $"Prop2: {getCustomRelationship.Prop2}");
}
```

### List digital twin relationships

`GetRelationshipsAsync` lists all the relationships of a digital twin. You can get digital twin relationships and deserialize them into `BasicRelationship`.

```C# Snippet:DigitalTwinsSampleGetAllRelationships
AsyncPageable<string> relationships = client.GetRelationshipsAsync("buildingTwinId");

await foreach (var relationshipJson in relationships)
{
    BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
    Console.WriteLine($"Found relationship with Id {relationship.Id} with a digital twin source Id {relationship.SourceId} and " +
        $"a digital twin target Id {relationship.TargetId}. \n\t " +
        $"Prop1: {relationship.CustomProperties["Prop1"]}\n\t" +
        $"Prop2: {relationship.CustomProperties["Prop2"]}");
}
```

`GetIncomingRelationshipsAsync` lists all incoming relationships of digital twin.

```C# Snippet:DigitalTwinsSampleGetIncomingRelationships
AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync("buildingTwinId");

await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
{
    Console.WriteLine($"Found an incoming relationship with Id {incomingRelationship.RelationshipId} coming from a digital twin with Id {incomingRelationship.SourceId}.");
}
```

### Delete a digital twin relationship

To delete all outgoing relationships for a digital twin, simply iterate over the relationships and delete them iteratively.

```C# Snippet:DigitalTwinsSampleDeleteRelationship
Response deleteBuildingRelationshipResponse = await client.DeleteRelationshipAsync("buildingTwinId", "buildingFloorRelationshipId");
Console.WriteLine($"Deleted relationship with Id buildingFloorRelationshipId. Status response: {deleteBuildingRelationshipResponse.Status}.");
```

## Create, list, and delete event routes of digital twins

### Create event routes

To create an event route, provide an Id of an event route such as "sampleEventRoute" and event route data containing the endpoint and optional filter like the example shown below.

```C# Snippet:DigitalTwinsSampleCreateEventRoute
string eventFilter = "$eventType = 'DigitalTwinTelemetryMessages' or $eventType = 'DigitalTwinLifecycleNotification'";
var eventRoute = new EventRoute(eventhubEndpointName)
{
    Filter = eventFilter
};

Response createEventRouteResponse = await client.CreateEventRouteAsync(_eventRouteId, eventRoute);
Console.WriteLine($"Created event route with Id {_eventRouteId}. Response status: {createEventRouteResponse.Status}");
```

For more information on the event route filter language, see the "how to manage routes" [filter events documentation](https://github.com/Azure/azure-digital-twins/blob/private-preview/Documentation/how-to-manage-routes.md#filter-events).

### List event routes

List a specific event route given event route Id or all event routes setting options with `GetEventRouteAsync` and `GetEventRoutesAsync`.

```C# Snippet:DigitalTwinsSampleGetEventRoutes
AsyncPageable<EventRoute> response = client.GetEventRoutesAsync();
await foreach (EventRoute er in response)
{
    Console.WriteLine($"Event route: {er.Id}, endpoint name: {er.EndpointName}");
}
```

### Delete event routes

Delete an event route given event route Id.

```C# Snippet:DigitalTwinsSampleDeleteEventRoute
Response response = await client.DeleteEventRouteAsync(_eventRouteId);
Console.WriteLine($"Deleted event route with Id {_eventRouteId}. Response status: {response.Status}");
```

### Publish telemetry messages for a digital twin

To publish a telemetry message for a digital twin, you need to provide the digital twin Id, along with the payload on which telemetry that needs the update.

```C# Snippet:DigitalTwinsSamplePublishTelemetry
// construct your json telemetry payload by hand.
Response publishTelemetryResponse = await client.PublishTelemetryAsync(twinId, "{\"Telemetry1\": 5}");
Console.WriteLine($"Published telemetry message to twin with Id {twinId}. Response status: {publishTelemetryResponse.Status}");
```

You can also publish a telemetry message for a specific component in a digital twin. In addition to the digital twin Id and payload, you need to specify the target component Id.

```C# Snippet:DigitalTwinsSamplePublishComponentTelemetry
// construct your json telemetry payload by serializing a dictionary.
var telemetryPayload = new Dictionary<string, int>
{
    { "ComponentTelemetry1", 9}
};
Response publishTelemetryToComponentResponse = await client.PublishComponentTelemetryAsync(
    twinId,
    "Component1",
    JsonSerializer.Serialize(telemetryPayload));
Console.WriteLine($"Published component telemetry message to twin with Id {twinId}. Response status: {publishTelemetryToComponentResponse.Status}");
```

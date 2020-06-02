# Digital Twin Samples
You can explore azure digital twin APIs (using the SDK) using the samples project. 
Sample project demonstrates the following:
* Create, get and decommision models
* Create, query and delete a Digital Twin
* Get and update components for a Digital Twin
* Create, get and delete relationships between Digital Twins
* Create, get and delete event routes for Digital Twin
* Publish telemetry messages to a Digital Twin and Digital Twin component

## Creating Digital Twin Client

To create a new Digital Twin Client, you need the endpoint to an Azure Digital Twin and credentials.
In the sample below, you can set `AdtEndpoint`, `TenantId`, `ClientId`, and `ClientSecret` as command-line arguments.
The client requires an instance of [TokenCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet).
In these samples, we illustrate how to use two derived classes: ClientSecretCredential, InteractiveLogin.

```C# Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret
// By using the ClientSecretCredential, a specified application Id can login using a
// client secret.
var tokenCredential = new ClientSecretCredential(
    tenantId,
    clientId,
    clientSecret,
    new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

var dtClient = new DigitalTwinsClient(
    new Uri(adtEndpoint),
    tokenCredential);
```

Also, if you need to override pipeline behavior, such as provide your own HttpClient instance, you can do that via client options. This parameter is optional.

```C# Snippet:DigitalTwinsSampleCreateServiceClientInteractiveLogin
// This illustrates how to specify client options, in this case, by providing an
// instance of HttpClient for the digital twins client to use.
var clientOptions = new DigitalTwinsClientOptions
{
    Transport = new HttpClientTransport(httpClient),
};

// By using the InteractiveBrowserCredential, the current user can login using a web browser
// interactively with the AAD
var tokenCredential = new InteractiveBrowserCredential(
    tenantId,
    clientId,
    new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

var dtClient = new DigitalTwinsClient(
    new Uri(adtEndpoint),
    tokenCredential,
    clientOptions);
```

## Create, List, Decommision and Delete Models

### Create Models

Let's create models using the code below. You need to pass in List<string> containing list of json models. Check out sample models [here](https://github.com/Azure/azure-sdk-for-net-pr/tree/feature/IoT-ADT/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/DTDL/Models "Models")

```C# Snippet:DigitalTwinsSampleCreateModels
Response<IReadOnlyList<ModelData>> response = await DigitalTwinsClient.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload }).ConfigureAwait(false);
Console.WriteLine($"Successfully created a model with Id: {newComponentModelId}, {sampleModelId}, status: {response.GetRawResponse().Status}");
```

### List Models

Using `GetModelsAsync`, all created models are listed as AsyncPageable<ModelData>

```C# Snippet:DigitalTwinsSampleGetModels
AsyncPageable<ModelData> allModels = DigitalTwinsClient.GetModelsAsync();
await foreach (ModelData model in allModels)
{
    Console.WriteLine($"Model Id: {model.Id}, display name: {model.DisplayName["en"]}, upload time: {model.UploadTime}, is decommissioned: {model.Decommissioned}");
}
```

Use `GetModelAsync` with model's unique identifier to get a specific model

```C# Snippet:DigitalTwinsSampleGetModel
Response<ModelData> sampleModel = await DigitalTwinsClient.GetModelAsync(sampleModelId).ConfigureAwait(false);
```

### Decommission Models

To decommision a model, pass in a model id for the model you want to decommision

```C# Snippet:DigitalTwinsSampleDecommisionModel
try
{
    await DigitalTwinsClient.DecommissionModelAsync(sampleModelId).ConfigureAwait(false);

    Console.WriteLine($"Successfully decommissioned model {sampleModelId}");
}
catch (Exception ex)
{
    FatalError($"Failed to decommision model {sampleModelId} due to:\n{ex}");
}
```

### Delete Models

To delete a model, pass in a model id for the model you want to delete

```C# Snippet:DigitalTwinsSampleDeleteModel
try
{
    await DigitalTwinsClient.DeleteModelAsync(sampleModelId).ConfigureAwait(false);

    Console.WriteLine($"Deleted model {sampleModelId}");
}
catch (Exception ex)
{
    FatalError($"Failed to delete model {sampleModelId} due to:\n{ex}");
}
```

## Create and delete Digital Twin

### Create Digital Twin

For Creating Twin you will need to provide Id of a digital Twin such as `myTwin` and the application/json digital twin based on the model created earlier. You can look at sample application/json [here](https://github.com/Azure/azure-sdk-for-net-pr/tree/feature/IoT-ADT/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/DTDL/DigitalTwins "DigitalTwin").

```C# Snippet:DigitalTwinsSampleCreateBasicTwin
// Create digital twin with Component payload using the BasicDigitalTwin serialization helper

var basicDigitalTwin = new BasicDigitalTwin();
basicDigitalTwin.Metadata.ModelId = modelId;
basicDigitalTwin.CustomProperties.Add("Prop1", "Value1");
basicDigitalTwin.CustomProperties.Add("Prop2", "Value2");

var componentMetadata = new ModelProperties();
componentMetadata.Metadata.ModelId = componentModelId;
componentMetadata.CustomProperties.Add("ComponentProp1", "ComponentValue1");
componentMetadata.CustomProperties.Add("ComponentProp2", "ComponentValue2");

basicDigitalTwin.CustomProperties.Add("Component1", componentMetadata);

string dtPayload = JsonSerializer.Serialize(basicDigitalTwin, new JsonSerializerOptions { IgnoreNullValues = true });

Response<string> createDtResponse = await DigitalTwinsClient.CreateDigitalTwinAsync(dtId, dtPayload).ConfigureAwait(false);
Console.WriteLine($"Created digital twin {dtId} with response {createDtResponse.GetRawResponse().Status}.");
```

### Query Digital Twin

Query the Azure Digital Twins instance for digital twins using the [Azure Digital Twins Query Store lanaguage](https://review.docs.microsoft.com/en-us/azure/digital-twins-v2/concepts-query-language?branch=pr-en-us-114648). Query calls support paging. Here's an example of how to query for digital twins and how to iterate over the results.

```C# Snippet:DigitalTwinsSampleQueryTwins
// This code snippet demonstrates the simplest way to iterate over the digital twin results, where paging
// happens under the covers.
AsyncPageable<string> asyncPageableResponse = DigitalTwinsClient.QueryAsync("SELECT * FROM digitaltwins");

// Iterate over the twin instances in the pageable response.
// The "await" keyword here is required because new pages will be fetched when necessary,
// which involves a request to the service.
await foreach (string response in asyncPageableResponse)
{
    BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
    Console.WriteLine($"Found digital twin: {twin.Id}");
}
```

The SDK also allows you to extract the `query-charge` header from the pagebale response. Here's an example of how to query for digital twins and how to iterate over the pageable response to extract the `query-charge` header.

```C# Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge
// This code snippet demonstrates how you could extract the query charges incurred when calling
// the query API. It iterates over the response pages first to access to the query-charge header,
// and then the digital twin results within each page.

AsyncPageable<string> asyncPageableResponseWithCharge = DigitalTwinsClient.QueryAsync("SELECT * FROM digitaltwins");
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

### Delete Digital Twin

Delete a digital twin simply by providing id of a digital twin as below.

```C# Snippet:DigitalTwinsSampleDeleteTwin
await DigitalTwinsClient.DeleteDigitalTwinAsync(twin.Key).ConfigureAwait(false);
```

## Get and update Digital Twin Component

### Update Digital Twin Component

To update a component or in other words to replace, remove and/or add a component property or subproperty within Digital Twin, you would need id of a digital twin, component name and application/json-patch+json operations to be performed on the specified digital twin's component. Here is the sample code on how to do it.  

```C# Snippet:DigitalTwinsSampleUpdateComponent
// Update Component1 by replacing the property ComponentProp1 value
var componentUpdateUtility = new UpdateOperationsUtility();
componentUpdateUtility.AppendReplaceOp("/ComponentProp1", "Some new value");
string updatePayload = componentUpdateUtility.Serialize();

Response<string> response = await DigitalTwinsClient.UpdateComponentAsync(dtId, "Component1", updatePayload);

Console.WriteLine($"Updated component for digital twin {dtId}. Update response status: {response.GetRawResponse().Status}");
```

### Get Digital Twin Component

Get a component by providing name of a component and id of digital twin it belongs to.

```C# Snippet:DigitalTwinsSampleGetComponent
response = await DigitalTwinsClient.GetComponentAsync(dtId, SamplesConstants.ComponentPath).ConfigureAwait(false);

Console.WriteLine($"Get component for digital twin: \n{response.Value}. Get response status: {response.GetRawResponse().Status}");
```

## Create and list Digital Twin edges

### Create Digital Twin Edge

`CreateEdgeAsync` creates a relationship edge on a digital twin provided with id of a digital twin, name of relationship such as "contains", id of an edge such as "FloorContainsRoom" and an application/json edge to be created. Must contain property with key "$targetId" to specify the target of the edge. Sample payloads for relationships can be found [here](https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/IoT-ADT/sdk/iot/Azure.Iot.DigitalTwins/samples/DigitalTwinServiceClientSample/DTDL/Relationships/HospitalEdges.json "RelationshipExamples").

```C# Snippet:DigitalTwinsSampleCreateRelationship
string serializedRelationship = JsonSerializer.Serialize(relationship);

await DigitalTwinsClient
    .CreateRelationshipAsync(
        relationship.SourceId,
        relationship.Id,
        serializedRelationship)
    .ConfigureAwait(false);
```
### List Digital Twin Edges

`GetEdgesAsync` and `GetIncomingEdgesAsync` lists all the edges and all incoming edges respectively of a digital twin

```C# Snippet:DigitalTwinsSampleGetRelationships
AsyncPageable<string> relationships = DigitalTwinsClient.GetRelationshipsAsync(twin.Key);
```

```C# Snippet:DigitalTwinsSampleGetIncomingRelationships
AsyncPageable<IncomingRelationship> incomingRelationships = DigitalTwinsClient.GetIncomingRelationshipsAsync(twin.Key);
```

## Create, list and delete event routes of Digital Twin

### Create Event Route

To create Event route, one needs to provide id of an event route such as "sampleEventRoute" and event route data containing the endpoint and optional filter like the example shown below

```C# Snippet:DigitalTwinsSampleCreateEventRoute
string eventFilter = "$eventType = 'DigitalTwinTelemetryMessages' or $eventType = 'DigitalTwinLifecycleNotification'";
var eventRoute = new EventRoute(_eventhubEndpointName)
{
    Filter = eventFilter
};

Response createEventRouteResponse = await DigitalTwinsClient.CreateEventRouteAsync(_eventRouteId, eventRoute).ConfigureAwait(false);
```

### List Event Routes

List a specific event route given event route id or all event routes setting options with `GetEventRouteAsync` and `GetEventRoutesAsync`.

```C# Snippet:DigitalTwinsSampleGetEventRoutes
AsyncPageable<EventRoute> response = DigitalTwinsClient.GetEventRoutesAsync();
await foreach (EventRoute er in response)
{
    Console.WriteLine($"Event route: {er.Id}, endpoint name: {er.EndpointName}");
}
```

### Delete Event Route

Delete an event route given event route id

```C# Snippet:DigitalTwinsSampleDeleteEventRoute
Response response = await DigitalTwinsClient.DeleteEventRouteAsync(_eventRouteId).ConfigureAwait(false);
```

### Publish telemetry messages to a Digital Twin

To publish a telemetry message to a digital twin, you need to provide the digital twin id, along with the payload on which telemetry that needs the update.

```C# Snippet:DigitalTwinsSamplePublishTelemetry
// construct your json telemetry payload by hand.
Response publishTelemetryResponse = await DigitalTwinsClient.PublishTelemetryAsync(twinId, "{\"Telemetry1\": 5}");
Console.WriteLine($"Successfully published telemetry message, status: {publishTelemetryResponse.Status}");
```

You can also publish a telemetry message to a specific component in a digital twin. In addition to the digital twin id and payload, you need to specify the target component id.

```C# Snippet:DigitalTwinsSamplePublishComponentTelemetry
// construct your json telemetry payload by serializing a dictionary.
var telemetryPayload = new Dictionary<string, int>
{
    { "ComponentTelemetry1", 9}
};
Response publishTelemetryToComponentResponse = await DigitalTwinsClient.PublishComponentTelemetryAsync(twinId, "Component1", JsonSerializer.Serialize(telemetryPayload));
Console.WriteLine($"Successfully published component telemetry message, status: {publishTelemetryToComponentResponse.Status}");
```

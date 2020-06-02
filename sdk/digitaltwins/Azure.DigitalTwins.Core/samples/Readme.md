# Digital Twin Samples
You can explore azure digital twin APIs (using the SDK) using the samples project. 
Sample project demonstrates the following:
* Create, get and decommision models
* Create, query and delete a Digital Twin
* Get and update components for a Digital Twin
* Create, get and delete relationships between Digital Twins
* Create, get and delete eventroutes for Digital Twin

## Creating Digital Twin Client

To create a new Digital Twin Client, you need the endpoint to an Azure Digital Twin and credentials. In the sample below, you can set `AdtEndpoint`, `TenantId`, `ClientId` and, `ClientSecret` as command line arguments.

```C# Snippet:DigitalTwinSampleCreateServiceClient
var clientSecretCredential = new ClientSecretCredential(
    tenantId,
    clientId,
    clientSecret,
    new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

var dtClient = new DigitalTwinsClient(
    new Uri(adtEndpoint),
    clientSecretCredential);
```

If you need to override pipeline behavior, such as provide your own HttpClient instance, you can do that via client options.

```C# Snippet:DigitalTwinSampleCreateServiceClientWithHttpClient
// This illustrates how to specify client options, in this case, by providing an
// instance of HttpClient for the digital twins client to use

var clientOptions = new DigitalTwinsClientOptions
{
    Transport = new HttpClientTransport(httpClient),
};

var clientSecretCredential = new ClientSecretCredential(
    tenantId,
    clientId,
    clientSecret,
    new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

var dtClient = new DigitalTwinsClient(
    new Uri(adtEndpoint),
    clientSecretCredential,
    clientOptions);
```

## Create, List, Decommision and Delete Models

### Create Models

Let's create models using the code below. You need to pass in List<string> containing list of json models. Check out sample models [here](https://github.com/Azure/azure-sdk-for-net-pr/tree/feature/IoT-ADT/sdk/digitaltwins/Azure.DigitalTwins.Core/samples/DigitalTwinsClientSample/DTDL/Models "Models")

```C# Snippet:DigitalTwinSampleCreateModels
Response<IReadOnlyList<ModelData>> response = await DigitalTwinsClient.CreateModelsAsync(new[] { newComponentModelPayload, newModelPayload }).ConfigureAwait(false);
Console.WriteLine($"Successfully created a model with Id: {newComponentModelId}, {sampleModelId}, status: {response.GetRawResponse().Status}");
```

### List Models

Using `GetModelsAsync`, all created models are listed as AsyncPageable<ModelData>

```C# Snippet:DigitalTwinSampleGetModels
AsyncPageable<ModelData> allModels = DigitalTwinsClient.GetModelsAsync();
await foreach (ModelData model in allModels)
{
    Console.WriteLine($"Model Id: {model.Id}, display name: {model.DisplayName["en"]}, upload time: {model.UploadTime}, is decommissioned: {model.Decommissioned}");
}
```

Use `GetModelAsync` with model's unique identifier to get a specific model

```C# Snippet:DigitalTwinSampleGetModel
Response<ModelData> sampleModel = await DigitalTwinsClient.GetModelAsync(sampleModelId).ConfigureAwait(false);
```

### Decommission Models

To decommision a model, pass in a model id for the model you want to decommision

```C# Snippet:DigitalTwinSampleDecommisionModel
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

```C# Snippet:DigitalTwinSampleDeleteModel
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

```C# Snippet:DigitalTwinSampleCreateTwin
Response<string> response = await DigitalTwinsClient.CreateDigitalTwinAsync(twin.Key, twin.Value).ConfigureAwait(false);
```

### Query Digital Twin

Query the Azure Digital Twins instance for digital twins using the [Azure Digital Twins Query Store lanaguage](https://review.docs.microsoft.com/en-us/azure/digital-twins-v2/concepts-query-language?branch=pr-en-us-114648). Query calls support paging. Here's an example of how to query for digital twins and how to iterate over the results.

```C# Snippet:DigitalTwinSampleQueryTwins
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

```C# Snippet:DigitalTwinSampleQueryTwinsWithQueryCharge
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

```C# Snippet:DigitalTwinSampleDeleteTwin
await DigitalTwinsClient.DeleteDigitalTwinAsync(twin.Key).ConfigureAwait(false);
```

## Get and update Digital Twin Component

### Update Digital Twin Component

To update a component or in other words to replace, remove and/or add a component property or subproperty within Digital Twin, you would need id of a digital twin, component name and application/json-patch+json operations to be performed on the specified digital twin's component. Here is the sample code on how to do it.  

```C# Snippet:DigitalTwinSampleUpdateComponent
// Update Component with replacing property value
string propertyPath = "/ComponentProp1";
string propValue = "New Value";

var componentUpdateUtility = new UpdateOperationsUtility();
componentUpdateUtility.AppendReplaceOp(propertyPath, propValue);

Response<string> response = await DigitalTwinsClient.UpdateComponentAsync(twinId, SamplesConstants.ComponentPath, componentUpdateUtility.Serialize());
```

### Get Digital Twin Component

Get a component by providing name of a component and id of digital twin it belongs to.

```C# Snippet:DigitalTwinSampleGetComponent
response = await DigitalTwinsClient.GetComponentAsync(twinId, SamplesConstants.ComponentPath).ConfigureAwait(false);
```

## Create and list Digital Twin edges

### Create Digital Twin Edge

`CreateEdgeAsync` creates a relationship edge on a digital twin provided with id of a digital twin, name of relationship such as "contains", id of an edge such as "FloorContainsRoom" and an application/json edge to be created. Must contain property with key "$targetId" to specify the target of the edge. Sample payloads for relationships can be found [here](https://github.com/Azure/azure-sdk-for-net-pr/blob/feature/IoT-ADT/sdk/iot/Azure.Iot.DigitalTwins/samples/DigitalTwinServiceClientSample/DTDL/Relationships/HospitalEdges.json "RelationshipExamples").

```C# Snippet:DigitalTwinSampleCreateRelationship
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

```C# Snippet:DigitalTwinSampleGetRelationships
AsyncPageable<string> relationships = DigitalTwinsClient.GetRelationshipsAsync(twin.Key);
```

```C# Snippet:DigitalTwinSampleGetIncomingRelationships
AsyncPageable<IncomingRelationship> incomingRelationships = DigitalTwinsClient.GetIncomingRelationshipsAsync(twin.Key);
```

## Create, list and delete event routes of Digital Twin

### Create Event Route

To create Event route, one needs to provide id of an event route such as "sampleEventRoute" and event route data containing the endpoint and optional filter like the example shown below

```C# Snippet:DigitalTwinSampleCreateEventRoute
string eventFilter = "$eventType = 'DigitalTwinTelemetryMessages' or $eventType = 'DigitalTwinLifecycleNotification'";
var eventRoute = new EventRoute(_eventhubEndpointName)
{
    Filter = eventFilter
};

Response createEventRouteResponse = await DigitalTwinsClient.CreateEventRouteAsync(_eventRouteId, eventRoute).ConfigureAwait(false);
```

### List Event Routes

List a specific event route given event route id or all event routes setting options with `GetEventRouteAsync` and `GetEventRoutesAsync`.

```C# Snippet:DigitalTwinSampleGetEventRoutes
AsyncPageable<EventRoute> response = DigitalTwinsClient.GetEventRoutesAsync();
await foreach (EventRoute er in response)
{
    Console.WriteLine($"Event route: {er.Id}, endpoint name: {er.EndpointName}");
}
```

### Delete Event Route

Delete an event route given event route id

```C# Snippet:DigitalTwinSampleDeleteEventRoute
Response response = await DigitalTwinsClient.DeleteEventRouteAsync(_eventRouteId).ConfigureAwait(false);
```

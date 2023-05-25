# Azure Schema Registry JSON Schema client library for .NET

Azure Schema Registry is a schema repository service hosted by Azure Event Hubs, providing schema storage, versioning, and management. This package provides a JSON Schema serializer capable of serializing and deserializing payloads containing Schema Registry schema identifiers and JSON-serialized data.

## Getting started

### Install the package

Install the Azure Schema Registry JSON Schema library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.Data.SchemaRegistry.JsonSchema
```

### Prerequisites

* An [Azure subscription][azure_sub]
* An [Event Hubs namespace][event_hubs_namespace]

If you need to [create an Event Hubs namespace][create_event_hubs_namespace], you can use the Azure Portal or [Azure PowerShell][azure_powershell].

You can use Azure PowerShell to create the Event Hubs namespace with the following command:

```PowerShell
New-AzEventHubNamespace -ResourceGroupName myResourceGroup -NamespaceName namespace_name -Location eastus
```

### Authenticate the client

In order to interact with the Azure Schema Registry service, you'll need to create an instance of the [Schema Registry Client][schema_registry_client] class. To create this client, you'll need Azure resource credentials and the Event Hubs namespace hostname.

#### Get credentials

To acquire authenticated credentials and start interacting with Azure resources, please see the [quickstart guide here][quickstart_guide].

#### Get Event Hubs namespace hostname

The simplest way is to use the [Azure portal][azure_portal] and navigate to your Event Hubs namespace. From the Overview tab, you'll see `Host name`. Copy the value from this field.

#### Create SchemaRegistryClient

Once you have the Azure resource credentials and the Event Hubs namespace hostname, you can create the [SchemaRegistryClient][schema_registry_client]. You'll also need the [Azure.Identity][azure_identity] package to create the credential.

```C# Snippet:SchemaRegistryJsonCreateSchemaRegistryClient
// Create a new SchemaRegistry client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
// For more information on Azure.Identity usage, see: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
var schemaRegistryClient = new SchemaRegistryClient(fullyQualifiedNamespace: fullyQualifiedNamespace, credential: new DefaultAzureCredential());
```
## Key concepts

### JSON Schema generator

The `SchemaRegistryJsonSchemaGenerator` is an abstract class that must be implemented and passed into the `SchemaRegistryJsonSerializer` constructor. This allows you to choose the third-party JSON Schema package you would like to use for generating schemas from types. You can optionally provide an implementation for JSON Schema validation. The default evaluates all schemas as valid.

### Serializer

This library provides a serializer, `SchemaRegistryJsonSerializer` that interacts with `EventData` events. The `SchemaRegistryJsonSerializer` utilizes a `SchemaRegistryClient` to enrich the `EventData` events with the schema ID for the schema used to serialize the data.

## Examples

## Implementation of `SchemaRegistryJsonSchemaGenerator` using `Newtonsoft.Json.Schema`

```C# Snippet:SampleSchemaRegistryJsonSchemaGeneratorImplementation
internal class SampleJsonGenerator : SchemaRegistryJsonSchemaGenerator
{
    public override bool ValidateAgainstSchema(Object data, Type dataType, string schemaDefinition)
    {
        // Your implementation using the third-party library of your choice goes here.
        // This method is optional. If it is not overridden, the default always returns true.

        return true;
    }
    public override string GenerateSchemaFromObject(Type dataType)
    {
        // Your implementation using the third-party library of your choice goes here.

        return "<< SCHEMA GENERATED FROM DATATYPE PARAMETER >>";
    }
}
```

### Serialize and deserialize data using the Event Hub EventData model

In order to serialize an `EventData` instance with JSON information, you can do the following:

```C# Snippet:SchemaRegistryJsonSerializeEventData
var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());

var employee = new Employee { Age = 42, Name = "Caketown" };
EventData eventData = (EventData)await serializer.SerializeAsync(employee, messageType: typeof(EventData));

// the schema Id will be included as a parameter of the content type
Console.WriteLine(eventData.ContentType);

// the serialized JSON data will be stored in the EventBody
Console.WriteLine(eventData.EventBody);

// construct a publisher and publish the events to our event hub
var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();
await using var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
await producer.SendAsync(new EventData[] { eventData });
```

To deserialize an `EventData` event that you are consuming:

```C# Snippet:SchemaRegistryJsonDeserializeEventData
// construct a consumer and consume the event from our event hub
await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential);
await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync())
{
    Employee deserialized = (Employee)await serializer.DeserializeAsync(eventData, typeof(Employee));
    Console.WriteLine(deserialized.Age);
    Console.WriteLine(deserialized.Name);
    break;
}
```

You can also use generic methods to serialize and deserialize the data. This may be more convenient if you are not building a library on top of the Json Schema serializer. Using it with your own library may introduce complexities.

```C# Snippet:SchemaRegistryJsonSerializeEventDataGenerics
var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());

var employee = new Employee { Age = 42, Name = "Caketown" };
EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

// the schema Id will be included as a parameter of the content type
Console.WriteLine(eventData.ContentType);

// the serialized Avro data will be stored in the EventBody
Console.WriteLine(eventData.EventBody);
```

Similarly, to deserialize:

```C# Snippet:SchemaRegistryJsonDeserializeEventDataGenerics
Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);
Console.WriteLine(deserialized.Age);
Console.WriteLine(deserialized.Name);
```

### Serialize and deserialize data using `MessageContent` directly

It is also possible to serialize and deserialize using `MessageContent`. Use this option if you are integrating with a library that uses `MessageContent` directly.

```C# Snippet:SchemaRegistryJsonSerializeDeserializeMessageContent
var serializer = new SchemaRegistryJsonSerializer(client, groupName, new SampleJsonGenerator());
MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
```

## Troubleshooting

If you encounter errors when communicating with the Schema Registry service, these errors will be thrown as a [RequestFailedException][request_failed_exception]. The serializer will only communicate with the service the first time it encounters a schema (when serializing) or a schema ID (when deserializing). Any errors related to invalid Content-Types will be thrown as a `FormatException`. 

Errors related to invalid schemas will be thrown as an `Exception`, and the `InnerException` property will contain the underlying exception that was thrown from your implemented methods in the `SchemaRegistryJsonSchemaGenerator`. This type of error would typically be caught during testing and should not be handled in code.

## Next steps

See [Azure Schema Registry][azure_schema_registry] for additional information.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-about
[azure_powershell]: https://docs.microsoft.com/powershell/azure/
[create_event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-quickstart-powershell#create-an-event-hubs-namespace
[quickstart_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md
[schema_registry_client]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/schemaregistry/Azure.Data.SchemaRegistry/src/SchemaRegistryClient.cs
[azure_portal]: https://ms.portal.azure.com/
[azure_identity]: https://www.nuget.org/packages/Azure.Identity
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_schema_registry]: https://aka.ms/schemaregistry
[request_failed_exception]: https://docs.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet

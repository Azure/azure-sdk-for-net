# Using the `SchemaRegistrySerializer`

The following shows how to use the `SchemaRegistrySerializer` to serialize and deserialize JSON payloads containing Schema Registry schema identifiers and serialized data. The default serialization is JSON, but the serializer is customizable to any type of serialization.

## Table of contents
- [Implementing `SchemaValidator`](#implementing-schemavalidator)
- [Serialize and deserialize JSON data using the Event Hubs `EventData` type](#serialize-and-deserialize-json-data-using-the-event-hubs-eventdata-type)
- [Serialize and deserialize JSON data using `MessageContent` directly](#serialize-and-deserialize-json-data-using-messagecontent-directly)
- [Pluggable object serialization](#pluggable-object-serialization)
- [Troubleshooting](#troubleshooting)
- [Next steps](#next-steps)
- [Contributing](#contributing)

## Implementing `SchemaValidator`

The `SchemaValidator` is an abstract class that must be implemented and passed into the `SchemaRegistryJsonSerializer` constructor. This allows you to choose the third-party JSON Schema package you would like to use to generate schemas from .NET types and validate .NET objects against JSON schemas.

Implementing both `SchemaValidator.TryValidate` and `SchemaValidator.GenerateSchema` is required. Validation may be useful for your application since JSON deserialization is flexible. Deserializing on its own will not verify that a type matches a given schema, so implementing the validation method will be a much more reliable way to enforce schema adherance.

The following is an outline of how an implemented `SchemaValidator` may look:
```C# Snippet:SampleSchemaRegistryJsonSchemaGeneratorImplementation
internal class SampleJsonValidator : SchemaValidator
{
    public override string GenerateSchema(Type dataType)
    {
        // Your implementation using the third-party library of your choice goes here.
        return "<< SCHEMA GENERATED FROM DATATYPE PARAMETER >>";
    }

    public override bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors)
    {
        // Your implementation using the third-party library of your choice goes here.
        bool isValid = SampleValidationClass.SampleIsValidMethod(schemaDefinition, data, dataType, out validationErrors);
        return isValid;
    }
}
```

## Serialize and deserialize JSON data using the Event Hubs `EventData` model

In order to serialize an `EventData` instance with JSON information, you can do the following:

```C# Snippet:SchemaRegistryJsonSerializeEventData
// The serializer serializes into JSON by default
var serializer = new SchemaRegistrySerializer(client, groupName, new SampleJsonValidator());

var employee = new Employee { Age = 42, Name = "Caketown" };
EventData eventData = (EventData)await serializer.SerializeAsync(employee, messageType: typeof(EventData));

// The schema Id will be included as a parameter of the content type
Console.WriteLine(eventData.ContentType);

// The serialized JSON data will be stored in the EventBody
Console.WriteLine(eventData.EventBody);

// Construct a publisher and publish the events to our event hub
var fullyQualifiedNamespace = "<< FULLY-QUALIFIED EVENT HUBS NAMESPACE (like something.servicebus.windows.net) >>";
var eventHubName = "<< NAME OF THE EVENT HUB >>";
var credential = new DefaultAzureCredential();

// It is recommended that you cache the Event Hubs clients for the lifetime of your
// application, closing or disposing when application ends.  This example disposes
// after the immediate scope for simplicity.
await using var producer = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential);
await producer.SendAsync(new EventData[] { eventData });
```

To deserialize an `EventData` event that you are consuming:

```C# Snippet:SchemaRegistryJsonDeserializeEventData
// Construct a consumer and consume the event from our event hub

// It is recommended that you cache the Event Hubs clients for the lifetime of your
// application, closing or disposing when application ends.  This example disposes
// after the immediate scope for simplicity.
await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential);
await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync())
{
    Employee deserialized = (Employee)await serializer.DeserializeAsync(eventData, typeof(Employee));
    Console.WriteLine(deserialized.Age);
    Console.WriteLine(deserialized.Name);
    break;
}
```

You can also use generic methods to serialize and deserialize the data. This may be more convenient if you are not building a library on top of the serializer. Using it with your own library may introduce complexities.

```C# Snippet:SchemaRegistryJsonSerializeEventDataGenerics
// The serializer serializes into JSON by default
var serializer = new SchemaRegistrySerializer(client, groupName, new SampleJsonValidator());

var employee = new Employee { Age = 42, Name = "Caketown" };
EventData eventData = await serializer.SerializeAsync<EventData, Employee>(employee);

// The schema Id will be included as a parameter of the content type
Console.WriteLine(eventData.ContentType);

// The serialized JSON data will be stored in the EventBody
Console.WriteLine(eventData.EventBody);
```

Similarly, to deserialize:

```C# Snippet:SchemaRegistryJsonDeserializeEventDataGenerics
Employee deserialized = await serializer.DeserializeAsync<Employee>(eventData);
Console.WriteLine(deserialized.Age);
Console.WriteLine(deserialized.Name);
```

## Serialize and deserialize JSON data using `MessageContent` directly

It is also possible to serialize and deserialize using `MessageContent`. Use this option if you are integrating with a library that uses `MessageContent` directly.

```C# Snippet:SchemaRegistryJsonSerializeDeserializeMessageContent
// The serializer serializes into JSON by default
var serializer = new SchemaRegistrySerializer(client, groupName, new SampleJsonValidator());
MessageContent content = await serializer.SerializeAsync<MessageContent, Employee>(employee);

Employee deserializedEmployee = await serializer.DeserializeAsync<Employee>(content);
```

## Pluggable object serialization

By default, the `SchemaRegistrySerializer` serializes and deserializes using the [`JsonObjectSerializer`][json_serializer] with its built-in options. However, the `SchemaRegistrySerializerOptions` allows you to configure this by specifying an [`ObjectSerializer`][object_serializer] to use for serialization.

For example, to serialize and deserialize with a [`NewtonsoftJsonObjectSerializer`][newtonsoft_serializer]:
```C# Snippet:SchemaRegistryJsonSerializeDeserializeWithOptionsNewtonsoft
var newtonsoftSerializerOptions = new SchemaRegistrySerializerOptions
{
    Serializer = new NewtonsoftJsonObjectSerializer()
};
var newtonsoftSerializer = new SchemaRegistrySerializer(client, groupName, new SampleJsonValidator(), newtonsoftSerializerOptions);
```

If you'd like to configure the `JsonObjectSerializer`, you can pass `JsonSerializerOptions` into the 'JsonObjectSerializer`'s constructor:
```C# Snippet:SchemaRegistryJsonSerializeDeserializeWithOptions
var jsonSerializerOptions = new JsonSerializerOptions
{
    AllowTrailingCommas = true
};

var serializerOptions = new SchemaRegistrySerializerOptions
{
    Serializer = new JsonObjectSerializer(jsonSerializerOptions)
};
var serializer = new SchemaRegistrySerializer(client, groupName, new SampleJsonValidator(), serializerOptions);
```

## Troubleshooting

If you encounter errors when communicating with the Schema Registry service, these errors will be thrown as a [RequestFailedException][request_failed_exception]. The serializer will only communicate with the service the first time it encounters a schema (when serializing) or a schema Id (when deserializing). Any errors related to invalid Content-Types will be thrown as a `FormatException`. 

Errors related to invalid schemas will be thrown as an `Exception`, and the `InnerException` property will contain the underlying exception that was thrown from your implemented methods in the `SchemaRegistryJsonSchemaGenerator`. This type of error would typically be caught during testing and should not be handled in code.

## Next steps

See [Azure Schema Registry][azure_schema_registry] for additional information.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fschemaregistry%2FMicrosoft.Azure.Data.SchemaRegistry.JsonSchema%2FREADME.png)

<!-- LINKS -->
[nuget]: https://www.nuget.org/
[event_hubs_namespace]: https://docs.microsoft.com/azure/event-hubs/event-hubs-about
[object_serializer]: https://docs.microsoft.com/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet
[json_serializer]: https://docs.microsoft.com/dotnet/api/azure.core.serialization.jsonobjectserializer?view=azure-dotnet
[newtonsoft_serializer]: https://docs.microsoft.com/dotnet/api/azure.core.serialization.newtonsoftjsonobjectserializer?view=azure-dotnet
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[azure_schema_registry]: https://aka.ms/schemaregistry
[request_failed_exception]: https://docs.microsoft.com/dotnet/api/azure.requestfailedexception?view=azure-dotnet

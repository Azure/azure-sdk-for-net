# Azure.Core public serialization

The .NET Azure SDK libraries support serialization and deserialization of most client library model types using the static `ModelSerializer` class. 

## Key Concepts

- [Using the ModelSerializer](#using-the-modelserializer)
- [Using models with protocol methods](#using-models-with-protocol-methods)
- [Using JsonSerializer](#using-jsonserializer)
- [Generic Models](#generic-models)

## Using the ModelSerializer
The `ModelSerializer` class enables users to serialize and deserialize any Azure models that implement the `IModelSerializable<T>` interface. The following example shows a Dog model being serialized and deserialized.

```C# Snippet:BaseModelSerializer
Dog doggo = new Dog
{
    Name = "Doggo",
    Age = 7
};

BinaryData data = ModelSerializer.Serialize(doggo);

Dog dog = ModelSerializer.Deserialize<Dog>(data);
```

By default, the ModelSerializer gives you the JSON representation of the model. Some services accept XML so if you want to send the serialized data to an Azure service that accepts XML, you can use the `ModelSerializerFormat` enum to specify the format. By using the `Wire` format, the serializer automatically picks what the service would use.

```C# Snippet:ModelSerializerWithFormat
Dog doggo = new Dog
{
    Name = "Doggo",
    Age = 7
};

ModelSerializerOptions options = new ModelSerializerOptions(format: ModelSerializerFormat.Wire);

BinaryData data = ModelSerializer.Serialize(doggo, options);

Dog dog = ModelSerializer.Deserialize<Dog>(data, options);
```

## Using models with protocol methods

If you would like to use the additional control that [protocol methods][protocol_method] give you but still have the convenience of strongly typed models, you can use the built-in cast operators.

```C# Snippet:CastOperations
DefaultAzureCredential credential = new DefaultAzureCredential();
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), credential);
Dog dog = new Dog
{
    Name = "Doggo",
    Age = 7
};

// Our models contain an implicit cast to RequestContent so you can pass them directly to protocol methods.
Response response = client.CreatePet("myPet", dog);

// Our models also contain an explicit cast to the response type so you can deserialize them easily.
dog = (Dog)response;
```

## Using JsonSerializer

If you would like to use the `JsonSerializer`, you can add the `ModelJSONConverter` to your options, which allow `JsonSerializer` to serialize and deserialize any model that implements `IModelJSONSerializable<T>`. The following example shows a Dog model being serialized and deserialized using the ModelJSONConverter.

```C# Snippet:BaseModelConverter
Dog dog = new Dog
{
    Name = "Doggo",
    Age = 7
};

JsonSerializerOptions options = new JsonSerializerOptions();
// The ModelJSONConverter is able to serialize and deserialize any model that implements IModelJSONSerializable<T>.
options.Converters.Add(new ModelJSONConverter());

string json = JsonSerializer.Serialize(dog, options);

dog = JsonSerializer.Deserialize<Dog>(json, options);
```

## Generic Models

The following examples show a use case where a user brings a model unknown to the Serializer. The serialization used for each model can also be set in the `ModelSerializableOptions` options property `GenericTypeSerializerCreator`. 

Model Being Used by User
```C# Snippet:Example_Model
private class SearchResult
{
    public string X { get; set; }
    public int Y { get; set; }
}
```

```C# Snippet:BYOMWithNewtonsoft
Envelope<SearchResult> envelope = new Envelope<SearchResult>();
envelope.ModelA = new Cat();
envelope.ModelT = new SearchResult { X = "Square", Y = 10 };

ModelSerializerOptions options = new ModelSerializerOptions();
options.GenericTypeSerializerCreator = type => type.Equals(typeof(SearchResult)) ? new NewtonsoftJSONObjectSerializer() : null;

BinaryData data = ModelSerializer.Serialize(envelope, options);

Envelope<SearchResult> model = ModelSerializer.Deserialize<Envelope<SearchResult>>(data, options: options);
```

## Next steps

To learn more about serialization with `Azure.Core`, see the [Azure.Core.Serialization namespace](https://learn.microsoft.com/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. For example, labels and comments. Follow the instructions provided by the bot. You only need to sign the CLA once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

<!-- LINKS -->
[protocol_method]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md

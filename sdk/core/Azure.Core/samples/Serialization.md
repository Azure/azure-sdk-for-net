# Azure.Core public serialization

The .NET Azure SDK libraries support serialization and deserialization of most client library model types using the static `ModelSerializer` class. 

## Key Concepts

- [Using the ModelSerializer](#using-the-modelserializer)
- [Using models with protocol methods](#using-models-with-protocol-methods)
- [Using JsonSerializer](#using-jsonserializer)
- [Envelope bring your own model case](#envelope-bring-your-own-model-case)

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

By default, the ModelSerializer will give you the Json representation of the model. Some services accept XML so if you want to send the serialized data to an Azure service that accepts XML, you can use the `ModelSerializerFormat` enum to specify the format. By using the `Wire` format, the serializer automatically picks what the service would use.

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

If you would like to use the `JsonSerializer`, you can add the `ModelJsonConverter` to your options which will allow `JsonSerializer` to serialize and deserialize any model that implements `IModelJsonSerializable<T>`. The following example shows a Dog model being serialized and deserialized using the ModelJsonConverter.

```C# Snippet:BaseModelConverter
Dog dog = new Dog
{
    Name = "Doggo",
    Age = 7
};

JsonSerializerOptions options = new JsonSerializerOptions();
// The ModelJsonConverter is able to serialize and deserialize any model that implements IModelJsonSerializable<T>.
options.Converters.Add(new ModelJsonConverter());

string json = System.Text.Json.JsonSerializer.Serialize(dog, options);

dog = System.Text.Json.JsonSerializer.Deserialize<Dog>(json, options);
```

## Envelope bring your own model case

The following examples show a use case where a user brings a model unknown to the Serializer. The serialization used for each model can also be set in the `ModelSerializableOptions` options property `GenericTypeSerializerCreator`. 

Model Being Used by User
```C# Snippet:Example_Model
private class ModelT
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### Serialization

```C# Snippet:BYOMWithNewtonsoftSerialize
Envelope<ModelT> envelope = new Envelope<ModelT>();
envelope.ModelA = new CatReadOnlyProperty();
envelope.ModelT = new ModelT { Name = "Fluffy", Age = 10 };

ModelSerializerOptions options = new ModelSerializerOptions();
options.GenericTypeSerializerCreator = type => type.Equals(typeof(ModelT)) ? new NewtonsoftJsonObjectSerializer() : null;

BinaryData data = ModelSerializer.Serialize(envelope, options);
```

### Deserialization

```C# Snippet:BYOMWithNewtonsoftDeserialize
string serviceResponse =
    "{\"readOnlyProperty\":\"read\"," +
    "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
    "\"modelT\":{\"Name\":\"hello\",\"Age\":1}" +
    "}";

ModelSerializerOptions options = new ModelSerializerOptions();
options.GenericTypeSerializerCreator = type => type.Equals(typeof(ModelT)) ? new NewtonsoftJsonObjectSerializer() : null;

Envelope<ModelT> model = ModelSerializer.Deserialize<Envelope<ModelT>>(new BinaryData(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
```

## Next steps

To learn more about serialization with Azure Core, see the [Azure.Core.Serialization class](https://learn.microsoft.com/en-us/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. For example, labels and comments. Follow the instructions provided by the bot. You only need to sign the CLA once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

<!-- LINKS -->
[protocol_method]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md

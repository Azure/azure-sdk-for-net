# Azure.Core public serialization

The `Azure.Core` library supports serialization and deserialization of most client library model types using the static `ModelSerializer` class. The `ModelSerializer` class offers users additional control over serialization through the `ModelSerializerOptions`. These options allow users to specify the desired `ModelSerializerFormat` type, either `Json` or `Wire`, and provide custom Serializer types for individual models.

## Key Concepts

- [Using the ModelSerializer](#using-the-modelserializer)
- [Using models with protocol methods](#using-models-with-protocol-methods)
- [Using JsonSerializer](#using-jsonserializer)
- [Envelope bring your own model case](#envelope-bring-your-own-model-case)
- [ModelSerializerFormat description]("modelserializerformat-description")

## Using the ModelSerializer
The ModelSerializer class enables users to serialize and deserialize any Azure models that implement the IModelSerializable interface with ease. 

```C# Snippet:BaseModelSerializer
Dog doggo = new Dog
{
    Name = "Doggo",
    Age = 7
};

//Serializer
BinaryData data = ModelSerializer.Serialize(doggo);

//Deserializer
Dog dog = ModelSerializer.Deserialize<Dog>(data);
```

## Using models with protocol methods

If you would like to convert the [protocol method][protocol_method] to the strongly typed model, you can use the explicit cast operator. This will allow you to use the strongly typed model for serialization and deserialization. There is also an implicit cast operator that can be used to convert the strongly typed model to `RequestContent`.

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

If you have Json that needs to be converted into a specific object type, consider using the `ModelJsonConverter class`. This class can handle the deserialization of a model to a specific type and include additional metadata. 

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

## ModelSerializerFormat description
This section further describes the `ModelSerializerFormat` enum and the differences between the `Json` and `Wire` formats. The default format is `Json`. To get the default type the Azure service returns - like XML, use the `Wire` format.

## Next steps

To learn more about serialization with Azure Core, see the [Azure.Core.Serialization class](https://learn.microsoft.com/en-us/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. For example, labels and comments. Follow the instructions provided by the bot. You only need to sign the CLA once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

<!-- LINKS -->
[protocol_method]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md

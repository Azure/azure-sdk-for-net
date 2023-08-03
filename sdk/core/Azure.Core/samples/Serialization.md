# Azure.Core Public Serialization Guide

The latest updates to the `Azure.Core` library have simplified serializing and deserializing of all public Azure models. With the addiion of the `ModelSerializer` class, we provide a public interface that exposes the previously internal serialization code so customers can access it without needing to use reflection or write their own translation. The recommended serialization approach is to use the static `ModelSerializer` class. The `ModelSerializer` class also has `ModelSerializerOptions` which allows the user to set the serialization `ModelSerializerFormat` type (`Json` or `Wire`) and provide custom Serializer types for specific models.

## Key Concepts

- [ModelSerializerFormat description]("modelserializerformat-description")
- [Using the ModelSerializer](#using-the-modelserializer)
- [Interfacing with protocol methods](#interfacing-with-protocol-methods)
- [Using JsonSerializer](#using-jsonserializer)
- [Envelope bring your own model case](#envelope-bring-your-own-model-case)
- [Interfacing with the low level interfaces](#interfacing-with-the-low-level-interfaces)

## Using the ModelSerializer

The default serialization options can be overridden by passing in a `ModelSerializerOptions` object to the Serialize and Deserialize methods. Developers can set the format options to specify the serialization format such as XML or JSON. Default `ModelSerializationOptions` use the `Json` format and the `System.Text.Json` serializer. The following samples demonstrate how to use `ModelSerializer` class for `System.Text.Json` and `Newtonsoft.Json` serialization.

### Using ModelSerializer for System.Text.Json
In the following sample, we are using the default `ModelSerializerOptions`. This will allow the `ModelSerializer` to use the `System.Text.Json` serializer for all models. In the Deserialization sample, we are setting the `ModelSerializerFormat` in the Options to `Json`. This will serialize all properties including read-only and additional properties.

### Serialization

```C# Snippet:SystemTextJson_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};
BinaryData data = ModelSerializer.Serialize(dog);
```

### Deserialization

```C# Snippet:SystemTextJson_Deserialize
ModelSerializerOptions options = new ModelSerializerOptions(ModelSerializerFormat.Json);
string json = @"[{""Name"":""Doggo"",""IsHungry"":true,""Weight"":1.1,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(BinaryData.FromString(json), options);
```

### Using ModelSerializer for NewtonSoftJson

In the following sample, we are adding the `DogListProperty` with the `NewtonsoftJsonObjectSerializer` to the `GenericTypeSerializerCreator`. This will allow the `ModelSerializer` to use the `NewtonsoftJsonObjectSerializer` for the DogListProperty model. 

### Serialization

```C# Snippet:NewtonSoft_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};
ModelSerializerOptions options = new ModelSerializerOptions();
options.GenericTypeSerializerCreator = type => type.Equals(typeof(DogListProperty)) ? new NewtonsoftJsonObjectSerializer() : null;

BinaryData data = ModelSerializer.Serialize(dog, options);
```

### Deserialization

```C# Snippet:NewtonSoft_Deserialize
ModelSerializerOptions options = new ModelSerializerOptions();
options.GenericTypeSerializerCreator = type => type.Equals(typeof(DogListProperty)) ? new NewtonsoftJsonObjectSerializer() : null;
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(BinaryData.FromString(json), options);
```

## Interfacing with protocol methods

If you would like to convert the protocol model to the strongly typed model, you can use the explicit cast operator. This will allow you to use the strongly typed model for serialization and deserialization. There is also an explicit cast operator that can be used to convert the strongly typed model to the protocol RequestContent.

### Serialization

```C# Snippet:ExplicitCast_Serialize
DefaultAzureCredential credential = new DefaultAzureCredential();
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), credential);
DogListProperty dog = new DogListProperty("myPet");
Response response = client.CreatePet("myPet", (RequestContent)dog);
Response response2 = client.CreatePet("myPet", RequestContent.Create(dog));
```

### Deserialization

```C# Snippet:ExplicitCast_Deserialize
DefaultAzureCredential credential = new DefaultAzureCredential();
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), credential);
Response response = client.GetPet("myPet");
DogListProperty dog = (DogListProperty)response;
Console.WriteLine(dog.IsHungry);
```

## Using JsonSerializer

If you have Json that needs to be converted into a specific object type, consider using the `ModelJsonConverter class`. This class can handle the deserialization of a model to a specific type and include additional metadata. 

### Serialization

```C# Snippet:ModelConverter_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};

JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ModelJsonConverter());

string json = System.Text.Json.JsonSerializer.Serialize(dog, options);
```

### Deserialization

```C# Snippet:ModelConverter_Deserialize
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ModelJsonConverter());

DogListProperty dog = System.Text.Json.JsonSerializer.Deserialize<DogListProperty>(json, options);
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

## Interfacing with the low level interfaces

In this example we demonstrate how we could use the exact same method / interface to serialize either Json or Xml.
Above we demonstrate using `SerializeJson` and `SerializeXml` methods but this requires the user to know which serializer to use.

### Serialization

```C# Snippet:ModelSerializer_IModelSerializable_Serialize
XmlModelForCombinedInterface xmlModel = new XmlModelForCombinedInterface("Color", "Red", "ReadOnly");
var data = ModelSerializer.Serialize(xmlModel);
string xmlString = data.ToString();

JsonModelForCombinedInterface jsonModel = new JsonModelForCombinedInterface("Color", "Red", "ReadOnly");
data = ModelSerializer.Serialize(jsonModel);
string jsonString = data.ToString();
```

### Deserialization

```C# Snippet:ModelSerializer_IModelSerializable_Deserialize
string xmlResponse = "<Tag><Key>Color</Key><Value>Red</Value></Tag>";
XmlModelForCombinedInterface xmlModel = ModelSerializer.Deserialize<XmlModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(xmlResponse)));

string jsonResponse = "{\"key\":\"Color\",\"value\":\"Red\",\"readOnlyProperty\":\"ReadOnly\",\"x\":\"extra\"}";
JsonModelForCombinedInterface jsonModel = ModelSerializer.Deserialize<JsonModelForCombinedInterface>(new BinaryData(Encoding.UTF8.GetBytes(jsonResponse)));
```

## Next steps

To learn more about serialization with Azure Core, see the [Azure.Core.Serialization class](https://learn.microsoft.com/en-us/dotnet/api/azure.core.serialization.objectserializer?view=azure-dotnet).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [https://cla.microsoft.com](https://cla.microsoft.com).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. For example, labels and comments. Follow the instructions provided by the bot. You only need to sign the CLA once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any questions or comments.

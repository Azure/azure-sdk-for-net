# Azure.Core public serialization samples

## Using explicit cast

When using protocol methods for advanced handling of RequestContext it is still possible to use the strongly typed models.
There is an explicit cast operator that can be used to convert the protocol Response to the strongly typed model.
There is also an explicit cast operator that can be used to convert the strongly typed model to the protocol RequestContent.

### Serialization

```C# Snippet:ExplicitCast_Serialize
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
DogListProperty dog = new DogListProperty("myPet");
Response response = client.CreatePet("myPet", (RequestContent)dog);
var response2 = client.CreatePet("myPet", RequestContent.Create(dog));
```

### Deserialization

```C# Snippet:ExplicitCast_Deserialize
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
Response response = client.GetPet("myPet");
DogListProperty dog = (DogListProperty)response;
Console.WriteLine(dog.IsHungry);
```

Given that explicit cast does not allow for serialization options we might also consider a static `FromResponse` and instance `ToRequestContent` methods.

## Using ModelSerializer for NewtonSoftJson

By using the ModelSerializer class, a new instance of Dog does not need to be created before calling Deserialize. Also added ObjectSerializer to Options class so different kinds of Serializers can be used.

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

## Using ModelJsonConverter for JsonSerializer

In order to better integrate with the rest of the .NET ecosystem, Azure.Core supports System.Text.Json serialization. The following example demonstrates using System.Text.Json for serialization and deserialization
If we go this route the IJsonSerializable interface will only be needed for compile time constraints and can most likely be methodless and renamed to IRehydratable.

One limitation if we go this route is there isn't a clear place to pass in a flag to include additional properties during serialization and deserialization.

By using the ModelJsonConverter class we can have a place to add additional properties to the JsonSerializerOptions.
This will allow us to add things like `IgnoreAdditionalProperties` and `Version` to the options without needing to have our own ModelSerializer.
The `SerializableOptions` would become internal and we would have a converter to convert from `JsonSerializerOptions` + `ModelJsonConverter` to `SerializableOptions`.

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

## Envelope BYOM Case

The following examples show a use case where a User brings a model unknown to the Serializer. The serialization used for each model can also be set in the SerializableOptions options property Serializers. 

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

## Using ModelSerializer with generic IModelSerializable

In this example we demonstrate how we could use the exact same method / interface to serialize either json or xml.
Above we demonstrate using `SerializeJson` and `SerializeXml` methods but this requires the user to know which serializer to use.
We could delegate needing to know this to each model itself since they for sure need to know how to serialize themselves.  It does
introduce a question around what happens if a model could be serialized as both json and xml.

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

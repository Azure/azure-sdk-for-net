# Azure.Core public serialization samples

## Using explicit cast

When using protocol methods for advanced handling of RequestContext it is still possible to use the strongly typed models.
There is an explicit cast operator that can be used to convert the protocol Response to the strongly typed model.
There is also an explicit cast operator that can be used to convert the strongly typed model to the protocol RequestContent.

Serialization

```C# Snippet:ExplicitCast_Serialize
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
DogListProperty dog = new DogListProperty("myPet");
Response response = client.CreatePet("myPet", (RequestContent)dog);
var response2 = client.CreatePet("myPet", RequestContent.Create(dog));
```

Deserialization

```C# Snippet:ExplicitCast_Deserialize
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
Response response = client.GetPet("myPet");
DogListProperty dog = (DogListProperty)response;
Console.WriteLine(dog.IsHungry);
```

Given that explicit cast does not allow for serialization options we might also consider a static `FromResponse` and instance `ToRequestContent` methods.

## Using System.Text.Json

In order to better integrate with the rest of the .NET ecosystem, Azure.Core supports System.Text.Json serialization. The following example demonstrates using System.Text.Json for serialization and deserialization
If we go this route the IJsonSerializable interface will only be needed for compile time constraints and can most likely be methodless and renamed to IRehydratable.

One limitation if we go this route is there isn't a clear place to pass in a flag to include additional properties during serialization and deserialization.
One solution here is to always have this on by default for public usage and internally turn it off for communication with Azure services.

Serialization

```C# Snippet:Stj_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = false,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};

//STJ example
string json = System.Text.Json.JsonSerializer.Serialize(dog);
```

Deserialization

```C# Snippet:Stj_Deserialize
string json = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

//stj example
DogListProperty dog = System.Text.Json.JsonSerializer.Deserialize<DogListProperty>(json);
```

## Using ModelSerializer

Serialize would use the Try/Do examples from above. We would use Interface form the Serializable but potentially have static method for Deserialize. 
When using Static Deserialize, an empty Model does not have to be created first as we can deserialize directly into a new instance.

Serialization
```C# Snippet:ModelSerializer_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};

Stream stream = ModelSerializer.SerializeJson(dog);
```

Deserialization
```C# Snippet:ModelSerializer_Deserialize
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.DeserializeJson<DogListProperty>(json);
```

## Using ModelSerializer for NewtonSoftJson
By using the ModelSerializer class, a new instance of Dog does not need to be created before calling Deserialize. Also added ObjectSerializer to Options class so different kinds of Serializers can be used.

Serialization
```C# Snippet:NewtonSoft_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};
ModelSerializerOptions options = new ModelSerializerOptions();
options.Serializers.Add(typeof(DogListProperty), new NewtonsoftJsonObjectSerializer());

Stream stream = ModelSerializer.SerializeJson(dog, options);
```

Deserialization

```C# Snippet:NewtonSoft_Deserialize
ModelSerializerOptions options = new ModelSerializerOptions();
options.Serializers.Add(typeof(DogListProperty), new NewtonsoftJsonObjectSerializer());
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.DeserializeJson<DogListProperty>(json, options);
```

## Using ModelJsonConverter for JsonSerializer
By using the ModelJsonConverter class we can have a place to add additional properties to the JsonSerializerOptions.
This will allow us to add things like `IgnoreAdditionalProperties` and `Version` to the options without needing to have our own ModelSerializer.
The `SerializableOptions` would become internal and we would have a converter to convert from `JsonSerializerOptions` + `ModelJsonConverter` to `SerializableOptions`.

Serialization
```C# Snippet:ModelConverter_Serialize
DogListProperty dog = new DogListProperty
{
    Name = "Doggo",
    IsHungry = true,
    Weight = 1.1,
    FoodConsumed = { "kibble", "egg", "peanut butter" },
};

JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ModelJsonConverter(false));

string json = System.Text.Json.JsonSerializer.Serialize(dog, options);
```

Deserialization

```C# Snippet:ModelConverter_Deserialize
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ModelJsonConverter(false));

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

Serialization
```C# Snippet:BYOMWithNewtonsoftSerialize
Envelope<ModelT> envelope = new Envelope<ModelT>();
envelope.ModelA = new CatReadOnlyProperty();
envelope.ModelT = new ModelT { Name = "Fluffy", Age = 10 };
ModelSerializerOptions options = new ModelSerializerOptions();
options.Serializers.Add(typeof(ModelT), new NewtonsoftJsonObjectSerializer());
Stream stream = ModelSerializer.SerializeJson(envelope, options);
```

Deserialization
```C# Snippet:BYOMWithNewtonsoftDeserialize
string serviceResponse =
    "{\"readOnlyProperty\":\"read\"," +
    "\"modelA\":{\"name\":\"Cat\",\"isHungry\":false,\"weight\":2.5}," +
    "\"modelT\":{\"Name\":\"hello\",\"Age\":1}" +
    "}";

ModelSerializerOptions options = new ModelSerializerOptions();
options.Serializers.Add(typeof(ModelT), new NewtonsoftJsonObjectSerializer());

Envelope<ModelT> model = ModelSerializer.DeserializeJson<Envelope<ModelT>>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
```

## XmlModel Example
By using the SerializeXml and DeserializeXml methods we can serialize and deserialize Xml Models using the XmlSerializer. Next steps include combining ModelSerializer Serialize/Deserialize methods with XmlSerializer models to have a single method for both Json and Xml.

Serialization
```C# Snippet:XmlModelSerialize
ModelXml modelXml = new ModelXml("Color", "Red", "ReadOnly");
var stream = ModelSerializer.SerializeXml(modelXml);
stream.Position = 0;
string roundTrip = new StreamReader(stream).ReadToEnd();
```

Deserialization
```C# Snippet:XmlModelDeserialize
string serviceResponse =
    "<Tag>" +
    "<Key>Color</Key>" +
    "<Value>Red</Value>" +
    "</Tag>";

ModelXml model = ModelSerializer.DeserializeXml<ModelXml>(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)));
```

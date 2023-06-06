# Azure.Core public serialization samples

## Using IJsonSerialization Try methods

The following example demonstrates using two Try methods for serialization and deserialization in an Interface called IJsonSerializable. When serializing, the stream position has to be set to 0 to return the json. When deserializing, an empty Model must first be constructed and then deserialized into that instance.

Serialization

```C# Snippet:Try_Serialize
SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
using Stream stream = new MemoryStream();
Animal model = new Animal();
model.TrySerialize(stream, out long bytesWritten, options: options);
stream.Position = 0;
string json = new StreamReader(stream).ReadToEnd();
```

Deserialization

```C# Snippet:Try_Deserialize
using Stream stream = new MemoryStream();
bool ignoreReadOnly = false;
bool ignoreUnknown = false;
string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";
SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

Animal model = new Animal();
model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);
```

## Using IJsonSerialization Non-Try methods
The following example demonstrates the NonTry methods for serialization and deserialization. If serialization or deserialization fails, an Exception is bubbled up. When serializing, the stream position has to be set to 0 to return the json. When deserializing, an empty Model must first be constructed and then deserialized into that instance.

Serialization

```C# Snippet:NonTry_Serialize
SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
using Stream stream = new MemoryStream();
Animal model = new Animal();
model.Serialize(stream, options: options);
stream.Position = 0;
string roundTrip = new StreamReader(stream).ReadToEnd();
```

Deserialization

```C# Snippet:NonTry_Deserialize
using Stream stream = new MemoryStream();
bool ignoreReadOnly = false;
bool ignoreUnknown = false;
string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";
SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

Animal model = new Animal();
model.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
```

## Using explicit cast

When using protocol methods for advanced handling of RequestContext it is still possible to use the strongly typed models.
There is an explicit cast operator that can be used to convert the protocol Response to the strongly typed model.
There is also an explicit cast operator that can be used to convert the strongly typed model to the protocol RequestContent.

Serialization

```C# Snippet:ExplicitCast_Serialize
PetStoreClient client = new PetStoreClient(new Uri("http://somewhere.com"), new MockCredential());
DogListProperty dog = new DogListProperty("myPet");
Response response = client.CreatePet("myPet", (RequestContent)dog);
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
string json = JsonSerializer.Serialize(dog);
```

Deserialization

```C# Snippet:Stj_Deserialize
string json = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

//stj example
DogListProperty dog = JsonSerializer.Deserialize<DogListProperty>(json);
```

## Using static deserializer
Serialize would use the Try/Do examples from above. We would use Interface form the Serializable but potentially have static method for Deserialize. 
When using Static Deserialize, an empty Model does not have to be created first as we can deserialize directly into a new instance.

```C# Snippet:Static_Deserialize
SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = false, IgnoreAdditionalProperties = false };
string serviceResponse =
    "{\"latinName\":\"Animalia\",\"weight\":2.3,\"name\":\"Rabbit\",\"isHungry\":false,\"numberOfLegs\":4}";

Animal model = Animal.StaticDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), options: options);
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

Stream stream = ModelSerializer.Serialize(dog);
```

Deserialization
```C# Snippet:ModelSerializer_Deserialize
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(json);
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
SerializableOptions options = new SerializableOptions();
options.Serializer = new NewtonsoftJsonObjectSerializer();

Stream stream = ModelSerializer.Serialize(dog, options);
```

Deserialization

```C# Snippet:NewtonSoft_Deserialize
SerializableOptions options = new SerializableOptions();
options.Serializer = new NewtonsoftJsonObjectSerializer();
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

DogListProperty dog = ModelSerializer.Deserialize<DogListProperty>(json, options);
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

string json = JsonSerializer.Serialize(dog, options);
```

Deserialization

```C# Snippet:ModelConverter_Deserialize
string json = @"[{""LatinName"":""Animalia"",""Weight"":1.1,""Name"":""Doggo"",""IsHungry"":false,""FoodConsumed"":[""kibble"",""egg"",""peanut butter""],""NumberOfLegs"":4}]";

JsonSerializerOptions options = new JsonSerializerOptions();
options.Converters.Add(new ModelJsonConverter(false));

DogListProperty dog = JsonSerializer.Deserialize<DogListProperty>(json, options);
```

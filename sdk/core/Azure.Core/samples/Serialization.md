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

//stj example
string json = JsonSerializer.Serialize(dog);

//modelSerializer example
Stream stream = ModelSerializer.Serialize(dog);
```

Deserialization

```C# Snippet:Stj_Deserialize
string json = "{\"latinName\":\"Animalia\",\"weight\":1.1,\"name\":\"Doggo\",\"isHungry\":false,\"foodConsumed\":[\"kibble\",\"egg\",\"peanut butter\"],\"numberOfLegs\":4}";

//stj example
DogListProperty dog = JsonSerializer.Deserialize<DogListProperty>(json);

//modelSerializer example
DogListProperty dog2 = ModelSerializer.Deserialize<DogListProperty>(json);
```

## Using static deserializer

Serialization

```C# Snippet:Static_Serialize
//TODO
```

Deserialization

```C# Snippet:Static_Deserialize
//TODO
```



# Azure.Core public serialization samples

## Using IJsonSerialization Try methods

Serialization

```C# Snippet:Try_Serialize
//TODO
```

Deserialization

```C# Snippet:Try_Deserialize
//TODO
```

## Using IJsonSerialization Non-Try methods

Serialization

```C# Snippet:NonTry_Serialize
//TODO
```

Deserialization

```C# Snippet:NonTry_Deserialize
//TODO
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

Serialization

```C# Snippet:Stj_Serialize
//TODO
```

Deserialization

```C# Snippet:Stj_Deserialize
//TODO
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

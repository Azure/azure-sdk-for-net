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

Serialization

```C# Snippet:ExplicitCast_Serialize
//TODO
```

Deserialization

```C# Snippet:ExplicitCast_Deserialize
//TODO
```

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



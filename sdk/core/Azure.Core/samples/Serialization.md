# Azure.Core public serialization samples

## Using IJsonSerialization Try methods

Serialization

```C# Snippet:Try_Serialize
    SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
    Stream stream = new MemoryStream();
    var model = new Animal();
    model.TrySerialize(stream, out var bytesWritten, options: options);
    stream.Position = 0;
    string roundTrip = new StreamReader(stream).ReadToEnd();
```

Deserialization

```C# Snippet:Try_Deserialize
    Stream stream = new MemoryStream();
    bool ignoreReadOnly = false;
    bool ignoreUnknown = false;
    string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";

    StringBuilder expectedSerialized = new StringBuilder("{");
    if (!ignoreReadOnly)
    {
    expectedSerialized.Append("\"latinName\":\"Canis lupus familiaris\",");
    }
    expectedSerialized.Append("\"name\":\"Doggo\",");
    expectedSerialized.Append("\"isHungry\":false,");
    expectedSerialized.Append("\"weight\":5.5");
    if (!ignoreUnknown)
    {
    expectedSerialized.Append(",\"numberOfLegs\":4");
    }
    expectedSerialized.Append("}");
    var expectedSerializedString = expectedSerialized.ToString();

    SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

    var model = new Animal();
    model.TryDeserialize(new MemoryStream(Encoding.UTF8.GetBytes(serviceResponse)), out long bytesConsumed, options: options);
```

## Using IJsonSerialization Non-Try methods

Serialization

```C# Snippet:NonTry_Serialize
    SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = true, IgnoreAdditionalProperties = true };
    Stream stream = new MemoryStream();
    var model = new Animal();
    model.Serialize(stream, options: options);
    stream.Position = 0;
    string roundTrip = new StreamReader(stream).ReadToEnd();
```

Deserialization

```C# Snippet:NonTry_Deserialize
    Stream stream = new MemoryStream();
    bool ignoreReadOnly = false;
    bool ignoreUnknown = false;
    string serviceResponse = "{\"latinName\":\"Canis lupus familiaris\",\"weight\":5.5,\"name\":\"Doggo\",\"numberOfLegs\":4}";

    StringBuilder expectedSerialized = new StringBuilder("{");
    if (!ignoreReadOnly)
    {
    expectedSerialized.Append("\"latinName\":\"Canis lupus familiaris\",");
    }
    expectedSerialized.Append("\"name\":\"Doggo\",");
    expectedSerialized.Append("\"isHungry\":false,");
    expectedSerialized.Append("\"weight\":5.5");
    if (!ignoreUnknown)
    {
    expectedSerialized.Append(",\"numberOfLegs\":4");
    }
    expectedSerialized.Append("}");
    var expectedSerializedString = expectedSerialized.ToString();

    SerializableOptions options = new SerializableOptions() { IgnoreReadOnlyProperties = ignoreReadOnly, IgnoreAdditionalProperties = ignoreUnknown };

    var model = new Animal();
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



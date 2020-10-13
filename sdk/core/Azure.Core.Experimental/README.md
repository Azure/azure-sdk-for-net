# Azure Core Experimental shared client library for .NET

Azure.Core.Experimental contains types that are being evaluated and might eventually become part of Azure.Core, this library would always stay in a preview version and might allow breaking changes.

## Binary Data
### Overview
 The `BinaryData` type provides a lightweight abstraction for a payload of bytes. This type integrates with [ObjectSerializer](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/Serialization/ObjectSerializer.cs) to allow for serializing and deserializing payloads. It provides convenient helper methods to get out commonly used primitives, such as streams, strings, or bytes. The assumption when converting to and from string is that the encoding is UTF-8.
 
 ### Data ownership
 The ownership model of the underlying bytes varies depending on how the instance is constructed:
 If created using the static factory method, `FromMemory(ReadOnlyMemory<byte>)`, the passed in bytes will be wrapped, rather than copied. This is useful in scenarios where performance is critical and/or ownership of the bytes is controlled completely by the consumer, thereby allowing the enforcement of whatever ownership model is needed.
 
 If created using the `BinaryData(ReadOnlySpan<byte>)` constructor, `BinaryData` will maintain its own copy of the underlying bytes. This usage is geared more towards scenarios where the ownership of the bytes might be ambiguous to users of the consuming code. By making a copy of the bytes, the payload is guaranteed to be immutable. For all other constructors and static factory methods, BinaryData will assume ownership of the underlying bytes.

 ### Usage
 The main value of this type is its ability to easily convert from string to bytes to stream. This can greatly simplify API surface areas by exposing this type as opposed to numerous overloads or properties.
 
To/From string:
```C# Snippet:BinaryDataToFromString
var data = new BinaryData("some data");

// ToString will decode the bytes using UTF-8
Console.WriteLine(data.ToString()); // prints "some data"
```
 
 To/From bytes:
```C# Snippet:BinaryDataToFromBytes
var bytes = Encoding.UTF8.GetBytes("some data");

// when using the ReadOnlySpan constructor the underlying data is copied.
var data = new BinaryData(new ReadOnlySpan<byte>(bytes));

// when using the FromMemory method, the data is wrapped
data = BinaryData.FromMemory(bytes);

// there is an implicit cast defined for ReadOnlyMemory<byte>
ReadOnlyMemory<byte> rom = data;

// there is also a Bytes property that holds the data
rom = data.Bytes;
```
To/From stream:
```C# Snippet:BinaryDataToFromStream
var bytes = Encoding.UTF8.GetBytes("some data");
Stream stream = new MemoryStream(bytes);
var data = BinaryData.FromStream(stream);

// Calling ToStream will give back a stream that is backed by ReadOnlyMemory, so it is not writable.
stream = data.ToStream();
Console.WriteLine(stream.CanWrite); // prints false
```

 `BinaryData` also can be used to integrate with `ObjectSerializer`. By default, the `JsonObjectSerializer` will be used, but any serializer deriving from `ObjectSerializer` can be used.
```C# Snippet:BinaryDataToFromCustomModel
var model = new CustomModel
{
    A = "some text",
    B = 5,
    C = true
};

var data = BinaryData.Serialize(model);
model = data.Deserialize<CustomModel>();
```



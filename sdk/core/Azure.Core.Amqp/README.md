# Azure Core AMQP shared client library for .NET

Azure.Core.Amqp contains AMQP primitives. 

`AmqpUtf8String.FromBytes` creates a validated descriptor for existing UTF-8
bytes without creating an intermediate managed string.

```C# Snippet:AmqpUtf8StringDescriptor
ReadOnlyMemory<byte> utf8Bytes = Encoding.UTF8.GetBytes("order-created");
AmqpUtf8String value = AmqpUtf8String.FromBytes(utf8Bytes);
```

The descriptor borrows the bytes. Keep them valid and unchanged until the
operation using the value completes, or until its message batch is disposed.
Malformed UTF-8 is rejected.

Service Bus application-property support follows in the
[dependent change](https://github.com/Azure/azure-sdk-for-net/pull/64454).

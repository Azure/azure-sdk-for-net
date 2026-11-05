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

### Application properties

Use `AmqpUtf8String` for an AMQP string-valued application property when your
input is already UTF-8. Existing byte arrays and array segments continue to
represent AMQP binary values.

```C# Snippet:AmqpUtf8ApplicationProperty
var message = new AmqpAnnotatedMessage(
    AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
ReadOnlyMemory<byte> utf8Bytes = Encoding.UTF8.GetBytes("order-created");
message.ApplicationProperties["eventType"] = AmqpUtf8String.FromBytes(utf8Bytes);
```

For sends, completion includes retries. Received values are ordinary managed
strings.

If you already have a managed string, add that string directly instead of
encoding it first.

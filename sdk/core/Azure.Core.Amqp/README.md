# Azure Core AMQP shared client library for .NET

Azure.Core.Amqp contains AMQP primitives. 

`AmqpUtf8String.FromBytes` represents UTF-8 bytes as an AMQP string-valued
application property without creating an intermediate managed string. Existing
byte arrays and array segments continue to represent AMQP binary values.

```C# Snippet:AmqpUtf8ApplicationProperty
var message = new AmqpAnnotatedMessage(
    AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
ReadOnlyMemory<byte> utf8Bytes = Encoding.UTF8.GetBytes("order-created");
message.ApplicationProperties["eventType"] = AmqpUtf8String.FromBytes(utf8Bytes);
```

The value borrows the bytes. Keep them valid and unchanged until the send
operation completes, including retries, or until the message batch is disposed.
Received values are ordinary managed strings. Malformed UTF-8 is rejected.

Use this value when your input is already UTF-8. If you already have a managed
string, add that string directly instead of encoding it first.

# Interact with the AMQP message

This sample demonstrates how to interact with the underlying AMQP message used by the `ServiceBusMessage` and `ServiceBusReceivedMessage` types.

## Message body

The most common scenario where you may need to inspect the underlying AMQP message is in interop scenarios where you are receiving a message that has a non-standard body. The [AMQP specification](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format) allows three types of message body: a series of data sections, a value section, or a series of sequence sections. When using the `ServiceBusMessage.Body` property, you are implicitly using a single `data` section as the message body. If you are consuming from a queue or subscription in which the producer is sending messages with a non-standard body, you would need to do the following:

```C# Snippet:ServiceBusInspectMessageBody
ServiceBusReceiver receiver = client.CreateReceiver(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

AmqpAnnotatedMessage amqpMessage = receivedMessage.GetRawAmqpMessage();
if (amqpMessage.Body.TryGetValue(out object value))
{
    // handle the value body
}
else if (amqpMessage.Body.TryGetSequence(out IEnumerable<IList<object>> sequence))
{
    // handle the sequence body
}
else if (amqpMessage.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> data))
{
    // handle the data body - note that unlike when accessing the Body property of the received message,
    // we actually get back a list of byte arrays, not a single byte array. If you were to access the Body property,
    // the data would be flattened into a single byte array.
}
```

If you needed to send a value body, you could do the following:

```C# Snippet:ServiceBusSendValueBody
var client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

var message = new ServiceBusMessage();
message.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue(42);
await sender.SendMessageAsync(message);
```

## Setting miscellaneous properties

You can also set various properties on the AMQP message that are not exposed on the `ServiceBusMessage` type. These values are not granted special meaning by the Service Bus broker and therefore do not impact the Service Bus service behavior. However, since these are standard AMQP properties, they could impact the behavior of other message brokers that may receive these messages.

```C# Snippet:ServiceBusSetMiscellaneousProperties
var client = new ServiceBusClient(connectionString);
ServiceBusSender sender = client.CreateSender(queueName);

var message = new ServiceBusMessage("message with AMQP properties set");
AmqpAnnotatedMessage amqpMessage = message.GetRawAmqpMessage();

// set some properties of the AMQP header
amqpMessage.Header.Durable = true;
amqpMessage.Header.Priority = 1;

// set some custom properties in the footer
amqpMessage.Footer["custom-footer-property"] = "custom-footer-value";

// set some custom properties in the message annotations
amqpMessage.MessageAnnotations["custom-message-annotation"] = "custom-message-annotation-value";

// set some custom properties in the delivery annotations
amqpMessage.DeliveryAnnotations["custom-delivery-annotation"] = "custom-delivery-annotation-value";
await sender.SendMessageAsync(message);
```

You can also retrieve these properties when receiving a message:

```C# Snippet:ServiceBusGetMiscellaneousProperties
ServiceBusReceiver receiver = client.CreateReceiver(queueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

AmqpAnnotatedMessage receivedAmqpMessage = receivedMessage.GetRawAmqpMessage();
AmqpMessageHeader header = receivedAmqpMessage.Header;

bool? durable = header.Durable;
byte? priority = header.Priority;
string customFooterValue = (string)receivedAmqpMessage.Footer["custom-footer-property"];
string customMessageAnnotation = (string)receivedAmqpMessage.MessageAnnotations["custom-message-annotation"];
string customDeliveryAnnotation = (string)receivedAmqpMessage.DeliveryAnnotations["custom-delivery-annotation"];
```

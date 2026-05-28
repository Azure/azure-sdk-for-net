# Interop with `WindowsAzure.ServiceBus`

This sample demonstrates how to interoperate with messages that are sent or received using the `WindowsAzure.ServiceBus` library. The `WindowsAzure.ServiceBus` library uses the `DataContractSerializer` to serialize the `BrokeredMessage` body. Because of this, when attempting to interoperate with this library, there a few additional steps that are needed.

## Sending a message using `Azure.Messaging.ServiceBus` that will be received with `WindowsAzure.ServiceBus`

```C# Snippet:ServiceBusInteropSend
ServiceBusSender sender = client.CreateSender(queueName);
// When constructing the `DataContractSerializer`, We pass in the type for the model, which can be a strongly typed model or some pre-serialized data.
// If you use a strongly typed model here, the model properties will be serialized into XML. Since JSON is more commonly used, we will use it in our example, and
// and specify the type as string, since we will provide a JSON string.
var serializer = new DataContractSerializer(typeof(string));
using var stream = new MemoryStream();
XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream);

// serialize an instance of our type into a JSON string
string json = JsonSerializer.Serialize(new TestModel {A = "Hello world", B = 5, C = true});

// serialize our JSON string into the XML envelope using the DataContractSerializer
serializer.WriteObject(writer, json);
writer.Flush();

// construct the ServiceBusMessage using the DataContract serialized JSON
var message = new ServiceBusMessage(stream.ToArray());

await sender.SendMessageAsync(message);
```

## Receiving a message using `Azure.Messaging.Service` that was sent with `WindowsAzure.ServiceBus`

```C# Snippet:ServiceBusInteropReceive
ServiceBusReceiver receiver = client.CreateReceiver(queueName);
ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();

// Similar to the send scenario, we still rely on the DataContractSerializer and we use string as our type because we are expecting a JSON
// message body.
var deserializer = new DataContractSerializer(typeof(string));
XmlDictionaryReader reader =
    XmlDictionaryReader.CreateBinaryReader(received.Body.ToStream(), XmlDictionaryReaderQuotas.Max);

// deserialize the XML envelope into a string
string receivedJson = (string) deserializer.ReadObject(reader);

// deserialize the JSON string into TestModel
TestModel output = JsonSerializer.Deserialize<TestModel>(receivedJson);
```

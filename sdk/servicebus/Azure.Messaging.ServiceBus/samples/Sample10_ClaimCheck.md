# Claim check pattern

This sample demonstrates the use of the [claim check pattern](https://learn.microsoft.com/azure/architecture/patterns/claim-check) which enables you to work with arbitrarily large message bodies. For standard namespaces, a message can be at most 256 KB. For Premium namespaces, the limit is 100 MB. If these limits don't work for your application you can leverage Azure Storage Blobs to implement this pattern.

## Sending the message

In our example, we will assume that the message body can fit in memory. This allows us to use the Storage Blob methods that let you work with `BinaryData`. If your message body cannot fit in memory, you can use the [stream-based](https://learn.microsoft.com/dotnet/api/azure.storage.blobs.blobcontainerclient.uploadblobasync?view=azure-dotnet#Azure_Storage_Blobs_BlobContainerClient_UploadBlobAsync_System_String_System_IO_Stream_System_Threading_CancellationToken_) Upload/Download methods instead.

First, we will create a `BlobContainerClient` and use the container name "claim-checks". We will be storing our message bodies in blobs within this container.
```C# Snippet:CreateBlobContainer
DefaultAzureCredential credential = new();
var containerClient = new BlobContainerClient(accountUri, credential);
await containerClient.CreateIfNotExistsAsync();
```

Next, we will upload our large message body to a blob, and then assign the blob name to an application property in our `ServiceBusMessage`. In this example, we use a helper method that generates a random byte array of the specified size. For the blob name, we generate a GUID.

```C# Snippet:UploadMessage
byte[] body = ServiceBusTestUtilities.GetRandomBuffer(1000000);
string blobName = Guid.NewGuid().ToString();
await containerClient.UploadBlobAsync(blobName, new BinaryData(body));
var message = new ServiceBusMessage
{
    ApplicationProperties =
    {
        ["blob-name"] = blobName
    }
};
```

Finally, we send our message to our Service Bus queue.
```C# Snippet:ClaimCheckSendMessage
ServiceBusClient client = new("<service bus fully qualified namespace>", credential);
ServiceBusSender sender = client.CreateSender(scope.QueueName);
await sender.SendMessageAsync(message);
```

## Receiving the message

On the receiving side, we essentially perform the reverse of the operations that we did on the send side. We first receive our message and check for our application property key. After we find the key, we can download the corresponding blob.

```C# Snippet:ReceiveClaimCheck
ServiceBusReceiver receiver = client.CreateReceiver(scope.QueueName);
ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
if (receivedMessage.ApplicationProperties.TryGetValue("blob-name", out object blobNameReceived))
{
    Uri blobUri = new($"https://<storage account name>.blob.core.windows.net/claim-checks/{(string)blobNameReceived}");
    var blobClient = new BlobClient(blobUri, credential);

    BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();
    BinaryData messageBody = downloadResult.Content;

    // Once we determine that we are done with the message, we complete it and delete the corresponding blob.
    await receiver.CompleteMessageAsync(receivedMessage);
    await blobClient.DeleteAsync();
}
```

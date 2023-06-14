# Azure purview share client samples - Delete received share

## Import the namespaces

This sample demonstrates how to delete a received share by providing the received share id.

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Delete received share

```C# Snippet:ReceivedSharesClientSample_DeleteReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "receivedShareId");
```

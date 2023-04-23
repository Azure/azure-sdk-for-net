# Azure purview share client samples - List attached received shares

## Import the namespaces

This sample demonstrates how to get all attached received shares. The response will contain all active received shares given your reference name.
 
```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## List attached received shares

```C# Snippet:ReceivedSharesClientSample_ListAttachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("referenceName").ToEnumerableAsync();
```

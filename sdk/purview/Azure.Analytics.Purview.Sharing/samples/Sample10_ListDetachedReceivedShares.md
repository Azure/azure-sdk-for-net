# Azure purview share client samples - List detached received shares

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## List detached received shares

```C# Snippet:ReceivedSharesClientSample_ListDetachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllDetachedReceivedSharesAsync().ToEnumerableAsync();
```

# Azure Share Client Samples - List Detached Received Shares

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## List Detached Received Shares

```C# Snippet:ReceivedSharesClientSample_ListDetachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllDetachedReceivedSharesAsync().ToEnumerableAsync();
```

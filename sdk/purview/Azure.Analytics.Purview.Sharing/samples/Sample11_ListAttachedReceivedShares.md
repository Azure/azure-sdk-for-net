# Azure Share Client Samples - List Attached Received Shares

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## List Attached Received Shares

```C# Snippet:ReceivedSharesClientSample_ListAttachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("referenceName").ToEnumerableAsync();
```

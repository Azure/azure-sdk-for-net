# Azure purview share client samples - Get received share

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Get received share

```C# Snippet:ReceivedSharesClientSample_GetReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Response operation = await receivedSharesClient.GetReceivedShareAsync("receivedShareId");
```

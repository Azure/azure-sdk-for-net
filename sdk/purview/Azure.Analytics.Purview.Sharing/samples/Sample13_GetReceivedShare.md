# Azure Share Client Samples - Get Received Share

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## Get Received Share

```C# Snippet:ReceivedSharesClientSample_GetReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Response operation = await receivedSharesClient.GetReceivedShareAsync(<receivedShareId>);
```

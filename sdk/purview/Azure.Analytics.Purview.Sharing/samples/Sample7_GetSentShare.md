# Azure Share Client Samples - Get Sent Share

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Get Sent Share

```C# Snippet:SentSharesClientSample_GetSentShare
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

Response response = await sentShareClient.GetSentShareAsync("entShareId");
```

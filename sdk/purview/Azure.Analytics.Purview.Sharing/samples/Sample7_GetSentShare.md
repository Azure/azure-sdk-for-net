# Azure purview share client samples - Get sent share

## Import the namespaces

This sample demonstrates how to get the details of a sent share given it's id.

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Get sent share

```C# Snippet:SentSharesClientSample_GetSentShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Response response = await sentShareClient.GetSentShareAsync("sentShareId", new());
```

# Azure purview share client samples - List sent shares

## Import the namespaces

This sample demonstrates how to list all your sent shares. The reference name will be your storage account resource id.

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## List sent shares

```C# Snippet:SentSharesClientSample_ListSentShares
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync("referenceName").ToEnumerableAsync();
```

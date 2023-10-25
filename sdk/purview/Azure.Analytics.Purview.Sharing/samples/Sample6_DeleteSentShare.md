# Azure share client samples - Delete sent share

## Import the namespaces

This sample demonstrates how to delete a sent share given its id.

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Delete sent share

```C# Snippet:SentSharesClientSample_DeleteSentShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "sentShareId", new());
```

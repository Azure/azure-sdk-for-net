# Azure purview share client samples - Create sent share

This sample demonstrates how to create a sent share. Once a sent share is created, you will typically want to send an invitation to a list of recipients.

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Create a sent share

```C# Snippet:SentSharesClientSample_CreateSentSharesClient
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);
```

# Azure Share Client Samples - Create Sent Share

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## Create a Sent Share

```C# Snippet:SentSharesClientSample_CreateSentSharesClient
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);
```

# Azure Share Client Samples - Delete Sent Share

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Delete Sent Share

```C# Snippet:SentSharesClientSample_DeleteSentShare
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "sentShareId");
```

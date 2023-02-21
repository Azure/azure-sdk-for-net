# Azure Share Client Samples - Delete Received Share

## Import the namespaces

```C# Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## Delete Received Share

```C# Snippet:ReceivedSharesClientSample_DeleteReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "<receivedShareId>");
```

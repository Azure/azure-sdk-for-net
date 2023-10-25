# Azure purview share client samples - Delete sent share invitation

## Import the namespaces

This sample demonstrates how to delete a sent share invitation. It is an action provided to the sender's side of sharing.

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Delete sent share invitation

```C# Snippet:SentSharesClientSample_DeleteSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareInvitationAsync(WaitUntil.Completed, "sentShareId", "sentShareInvitationId", new());
```

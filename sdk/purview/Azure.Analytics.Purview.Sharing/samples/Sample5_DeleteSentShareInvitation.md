# Azure Share Client Samples - Delete Sent Share Invitation

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Delete Sent Share Invitation

```C# Snippet:SentSharesClientSample_DeleteSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareInvitationAsync(WaitUntil.Completed, "sentShareId", "sentShareInvitationId");
```

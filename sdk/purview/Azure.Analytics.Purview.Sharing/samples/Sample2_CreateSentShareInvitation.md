# Azure Share Client Samples - Create Sent Share Invitation

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Create Sent Share Invitation

```C# Snippet:SentSharesClientSample_CreateSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

var data = new
{
    invitationKind = "Service",
    properties = new
    {
        TargetActiveDirectoryId = "targetActiveDirectoryId",
        TargetObjectId = "targetObjectId",
    }
};

Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
```

# Azure purview share client samples - Create sent share invitation

This sample demonstrates how to send an invitation for a given sent share. The invitation can be sent to a service principal or an azure active directory user.
 
## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Create sent share invitation

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

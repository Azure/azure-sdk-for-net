# Azure purview share client samples - Get sent share invitation

This sample demonstrates how to get the details of a specific sent share invitation. You can see whether the invitation was sent to a user or a service principal, the expiration date can be viewed as well if applicable. 

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## Get sent share invitation

```C# Snippet:SentSharesClientSample_GetSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = "https://my-account-name.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

Response response = await sentShareClient.GetSentShareInvitationAsync("sentShareId", "sentShareInvitationId");
```


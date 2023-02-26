# Azure purview share client samples - Get sent share invitation

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


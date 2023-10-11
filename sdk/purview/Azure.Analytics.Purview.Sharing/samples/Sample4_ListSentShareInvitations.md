# Azure purview share client samples - List sent share invitations

This sample demonstrates how to list all sent share invitations for a given sent share.

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
```

## List sent share invitations

```C# Snippet:SentSharesClientSample_ListSentShareInvitations
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync("sentShareId", null, null, new()).ToEnumerableAsync();
```

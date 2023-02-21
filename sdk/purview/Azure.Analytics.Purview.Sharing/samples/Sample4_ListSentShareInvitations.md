# Azure Share Client Samples - List Sent Share Invitation

## Import the namespaces

```C# Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
```

## List Sent Share Invitation

```C# Snippet:SentSharesClientSample_ListSentShareInvitations
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync(<sentShareId>).ToEnumerableAsync();
```

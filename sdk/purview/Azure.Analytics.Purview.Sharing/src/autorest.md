# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file: 
- https://github.com/Azure/azure-rest-api-specs/blob/12cbd66750c4dfe302e9eca42b1fc727f8c02700/specification/purview/data-plane/Azure.Analytics.Purview.Share/preview/2023-02-15-preview/share.json
namespace: Azure.Analytics.Purview.Sharing
```

### Modify operation names
``` yaml
directive:
- rename-operation:
    from: SentShares_Get
    to: SentShares_GetSentShare
- rename-operation:
    from: SentShares_CreateOrReplace
    to: SentShares_CreateOrReplaceSentShare
- rename-operation:
    from: SentShares_Delete
    to: SentShares_DeleteSentShare
- rename-operation:
    from: SentShares_List
    to: SentShares_GetAllSentShares
- rename-operation:
    from: SentShares_GetInvitation
    to: SentShares_GetSentShareInvitation
- rename-operation:
    from: SentShares_CreateInvitation
    to: SentShares_CreateSentShareInvitation
- rename-operation:
    from: SentShares_DeleteInvitation
    to: SentShares_DeleteSentShareInvitation
- rename-operation:
    from: SentShares_ListInvitations
    to: SentShares_GetAllSentShareInvitations
- rename-operation:
    from: SentShares_NotifyUserInvitation
    to: SentShares_NotifyUserSentShareInvitation
- rename-operation:
    from: ReceivedShares_Get
    to: ReceivedShares_GetReceivedShare
- rename-operation:
    from: ReceivedShares_CreateOrReplace
    to: ReceivedShares_CreateOrReplaceReceivedShare
- rename-operation:
    from: ReceivedShares_Delete
    to: ReceivedShares_DeleteReceivedShare
- rename-operation:
    from: ReceivedShares_ListAttached
    to: ReceivedShares_GetAllAttachedReceivedShares
- rename-operation:
    from: ReceivedShares_ListDetached
    to: ReceivedShares_GetAllDetachedReceivedShares
```

# Azure Share Client Samples - Send invitation

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_03_Namespaces
using Azure.Core;
using Azure.Identity;
```

## Send invitation

```C# Snippet:Azure_Analytics_Purview_Share_Samples_SendInvitation
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";

// Send invitation
var sentShareName = "sample-Share";
var invitationName = "invitation-to-fabrikam";

var invitationData = new
{
    invitationKind = "User",
    properties = new
    {
        targetEmail = "user@domain.com"
    }
};

// Instead of sending invitation to Azure login email of the user, you can send invitation to object ID of a service principal and tenant ID.
// Tenant ID is optional. To use this method, comment out the previous declaration, and uncomment the next one.
//var invitationData = new
//{
//    invitationKind = "Application",
//    properties = new
//    {
//        targetActiveDirectoryId = "<targetActieDirectoryId>",
//        targetObjectId = "<targetObjectId>"
//    }
//};

var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);
await sentShareInvitationsClient.CreateOrUpdateAsync(sentShareName, invitationName, RequestContent.Create(invitationData));
```

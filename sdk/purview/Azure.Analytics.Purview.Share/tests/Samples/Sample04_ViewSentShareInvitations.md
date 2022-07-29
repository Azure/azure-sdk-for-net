# Azure Share Client Samples - View sent share invitations

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
```

## View sent share invitations

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com";
var sentShareName = "sample-Share";

// View sent share invitations. (Pending/Rejected)
var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);
var sentShareInvitations = sentShareInvitationsClient.GetSentShareInvitations(sentShareName);
var responseInvitation = sentShareInvitations.FirstOrDefault();

if (responseInvitation == null)
{
    //No invitations
    return;
}

var responseInvitationDocument = JsonDocument.Parse(responseInvitation);
var targetEmail = responseInvitationDocument.RootElement.GetProperty("name");
```

# Azure Share Client Samples - View sent share invitations

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
using System.Threading.Tasks;
```

## View sent share invitations

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
var sentShareName = "sample-Share";
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);

// View sent share invitations. (Pending/Rejected)
var sentShareInvitations = await sentShareInvitationsClient.GetSentShareInvitationsAsync(sentShareName).ToEnumerableAsync();
var responseInvitation = sentShareInvitations.FirstOrDefault();

if (responseInvitation == null)
{
    //No invitations
    return;
}

using var responseInvitationDocument = JsonDocument.Parse(responseInvitation);
var targetEmail = responseInvitationDocument.RootElement.GetProperty("name");
```

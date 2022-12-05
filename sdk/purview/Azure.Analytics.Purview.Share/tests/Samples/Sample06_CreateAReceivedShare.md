# Azure Share Client Samples - Create a received share
## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_06_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
```

## Create a received share

```C# Snippet:Azure_Analytics_Purview_Share_Samples_CreateAReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);

// Create received share
var receivedInvitations = await receivedInvitationsClient.GetReceivedInvitationsAsync().ToEnumerableAsync();
var receivedShareName = "fabrikam-received-share";
var receivedInvitation = receivedInvitations.LastOrDefault();

if (receivedInvitation == null)
{
    //No received invitations
    return;
}

using var jsonDocument = JsonDocument.Parse(receivedInvitation);
var receivedInvitationDocument = jsonDocument.RootElement;
var receivedInvitationId = receivedInvitationDocument.GetProperty("name");

var receivedShareData = new
{
    shareKind = "InPlace",
    properties = new
    {
        invitationId = receivedInvitationId,
        sentShareLocation = "eastus",
        collection = new
        {
            // for root collection else name of any accessible child collection in the Purview account.
            referenceName = "<purivewAccountName>",
            type = "CollectionReference"
        }
    }
};

var receivedShareClient = new ReceivedSharesClient(endPoint, credential);
var receivedShare = await receivedShareClient.CreateAsync(receivedShareName, RequestContent.Create(receivedShareData));
```

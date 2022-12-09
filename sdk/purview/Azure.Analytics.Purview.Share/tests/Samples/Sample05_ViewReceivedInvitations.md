# Azure Share Client Samples - View received invitations

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces
using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;
```

## View received invitations

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);

// View received invitations
var receivedInvitations = await receivedInvitationsClient.GetReceivedInvitationsAsync().ToEnumerableAsync();
```

# Azure Share Client Samples - View received invitations

## Import the namespaces

```C# Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces
using Azure.Identity;
```

## View received invitations

```C# Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com";

// View received invitations
var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);
var receivedInvitations = receivedInvitationsClient.GetReceivedInvitations();
```

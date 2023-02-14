# Azure Share client library for .NET

Microsoft Purview Share is a fully managed cloud service.

**Please rely heavily on the [service's documentation][share_product_documentation] and our [protocol client docs][protocol_client_quickstart] to use this library**

[Source code][source_code] | [Package (NuGet)][client_nuget_package] | [Product documentation][share_product_documentation]

## Getting started

### Install the package

Install the Microsoft Purview Share client library for .NET with [NuGet][client_nuget_package]:

```dotnetcli
dotnet add package Azure.Analytics.Purview.Share --prerelease
```

### Prerequisites

- You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

#### Using Azure Active Directory

This document demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted.  See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

Once you have chosen and configured your credential, you can create instances of the `SentSharesClient`.

```C# Snippet:SentSharesClientSample_CreateSentSharesClient
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);
```

## Key concepts

### Protocol Methods

Operations exposed by the Purview Share SDK for .NET use *protocol methods* to expose the underlying REST operations. You can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section shows you how to initialize and authenticate your client and share data.

### Create sent share

```C# Snippet:SentSharesClientSample_CreateSentShare
var credential = new DefaultAzureCredential();
var endPoint = "https://<my-account-name>.purview.azure.com/share";
var sentShareClient = new SentSharesClient(endPoint, credential);

// Create sent share
var sentShareName = "sample-Share";

var inPlaceSentShareDto = new
{
    shareKind = "InPlace",
    properties = new
    {
        description = "demo share",
        collection = new
        {
            // for root collection else name of any accessible child collection in the Purview account.
            referenceName = "<purivewAccountName>",
            type = "CollectionReference"
        }
    }
};

var sentShare = await sentShareClient.CreateOrUpdateAsync(sentShareName, RequestContent.Create(inPlaceSentShareDto));
```

### Create a sent share invitation

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

### View sent share invitations

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

### Create a received share

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

## Troubleshooting

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][azure_core_diagnostics].

## Next steps

This client SDK exposes operations using *protocol methods*, you can learn more about how to use SDK Clients which use protocol methods in our [documentation][protocol_client_quickstart].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://azure.microsoft.com/services/purview/
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Analytics.Purview.Share
[share_product_documentation]: https://docs.microsoft.com/azure/purview/concept-data-share
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[default_cred_ref]: https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://docs.microsoft.com/azure/purview
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fpurview%2FAzure.Analytics.Purview.Share%2FREADME.png)

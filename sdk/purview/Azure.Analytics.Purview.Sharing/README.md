# Azure Purview Share client library for .NET

Microsoft Purview Data Sharing allows data to be shared in-place from Azure Data Lake Storage Gen2 and Azure Storage accounts, both within and across organizations.

Data providers may use Microsoft Purview Data Sharing to share their data directly with other users and partners (known as data consumers) without data duplication, while centrally managing their sharing activities from within Microsoft Purview.

For data consumers, Microsoft Purview Data Sharing provides near real-time access to data shared with them by a provider.

Key capabilities delivered by Microsoft Purview Data Sharing include:
- Share data within the organization or with partners and customers outside of the organization (within the same Azure tenant or across different Azure tenants).
- Share data from ADLS Gen2 or Blob storage in-place without data duplication.
- Share data with multiple recipients.
- Access shared data in near real time.
- Manage sharing relationships and keep track of who the data is shared with/from, for each ADLSGen2 or Blob Storage account.
- Terminate share access at any time.
- Flexible experience through Microsoft Purview governance portal or via REST APIs.

**Please visit the following resources to learn more about this product.**

[Source code][source_code] | [Package (NuGet)][client_nuget_package] | [Product documentation][share_product_documentation]

## Getting started

### Install the package

Install the Microsoft Purview Share client library for .NET with [NuGet][client_nuget_package]:

```dotnetcli
dotnet add package Azure.Analytics.Purview.Sharing --prerelease
```

### Prerequisites

- You must have an [Azure subscription][azure_subscription] and a [Purview resource][purview_resource] to use this package.

### Authenticate the client

#### Using Azure Active Directory

This example demonstrates using [DefaultAzureCredential][default_cred_ref] to authenticate via Azure Active Directory. However, any of the credentials offered by the [Azure.Identity][azure_identity] will be accepted.  See the [Azure.Identity][azure_identity] documentation for more information about other credentials.

Once you have chosen and configured your credential, you can create instances of the `SentSharesClient`.

## Key concepts

__Data Provider:__ A data provider is the individual who creates a share by selecting a data source, choosing which files and folders to share, and who to share them with. Microsoft Purview then sends an invitation to each data consumer.

__Data Consumer:__ A data consumer is the individual who accepts the invitation by specifying a target storage account in their own Azure subscription that they'll use to access the shared data.

### Protocol Methods

Operations exposed by the Purview Share client library for .NET use *protocol methods* to expose the underlying REST operations. You can learn more about how to use Azure SDK clients which use protocol methods in our [documentation][protocol_client_quickstart].

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

##Examples

### Data Provider Examples

The following code examples demonstrate how data providers can use the Microsoft Azure Java SDK for Purview Sharing to manage their sharing activity.

#### Create a Sent Share Client
```C# Snippet:SentSharesClientSample_CreateSentSharesClient
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);
```

#### Create a Sent Share

```C# Snippet:SentSharesClientSample_CreateSentShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

var data = new
{
    shareKind = "InPlace",
    properties = new
    {
        artifact = new
        {
            storeKind = "AdlsGen2Account",
            storeReference = new
            {
                referenceName = "/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/sharerStorageAccount",
                type = "ArmResourceReference"
            },
            properties = new
            {
                paths = new[]
               {
                    new
                    {
                        containerName = "containerName",
                        senderPath = "senderPath",
                        receiverPath = "receiverPath"
                    }
                }
            }
        },
        displayName = "displayName",
        description = "description",
    }
};

Operation<BinaryData> createResponse = await sentShareClient.CreateOrReplaceSentShareAsync(WaitUntil.Completed, "sentShareId", RequestContent.Create(data));
```

#### Get a Sent Share

After creating a sent share, data providers can retrieve it.

```C# Snippet:SentSharesClientSample_GetSentShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Response response = await sentShareClient.GetSentShareAsync("sentShareId", new());
```

#### List Sent Shares

Data providers can also retrieve a list of the sent shares they have created.

```C# Snippet:SentSharesClientSample_ListSentShares
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync("referenceName", null, null, new()).ToEnumerableAsync();
```

#### Create a Share Invitation to a User

After creating a sent share, the data provider can extend invitations to consumers who may then view the shared data. In this example, an invitation is extended to an individual by specifying their email address.

```C# Snippet:SentSharesClientSample_CreateSentShareUserInvitation
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

var data = new
{
    invitationKind = "User",
    properties = new
    {
        TargetEmail = "receiver@microsoft.com",
        Notify = true,
    }
};

Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
```

#### Create a Share Invitation to a Service

Data providers can also extend invitations to services or applications by specifying the tenant id and object id of the service. *The object id used for sending an invitation to a service must be the object id associated with the Enterprise Application (not the application registration)*.

```C# Snippet:SentSharesClientSample_CreateSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

var data = new
{
    invitationKind = "Service",
    properties = new
    {
        TargetActiveDirectoryId = "targetActiveDirectoryId",
        TargetObjectId = "targetObjectId",
    }
};

Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
```

#### Get a sent share invitation

After creating a sent share invitation, data providers can retrieve it.

```C# Snippet:SentSharesClientSample_GetSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Response response = await sentShareClient.GetSentShareInvitationAsync("sentShareId", "sentShareInvitationId", new());
```

#### List sent share invitations

Data providers can also retrieve a list of the sent share invitations they have created.

```C# Snippet:SentSharesClientSample_ListSentShareInvitations
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync("sentShareId", null, null, new()).ToEnumerableAsync();
```

#### Delete a sent share invitation

Data providers can also retrieve a list of the sent share invitations they have created.

```C# Snippet:SentSharesClientSample_DeleteSentShareInvitation
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareInvitationAsync(WaitUntil.Completed, "sentShareId", "sentShareInvitationId", new());
```

#### Delete a sent share

A sent share can be deleted by the data provider to stop sharing their data with all data consumers.

```C# Snippet:SentSharesClientSample_DeleteSentShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var sentShareClient = new SentSharesClient(endPoint, credential);

Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "sentShareId", new());
```

### Data Consumer Examples

The following code examples demonstrate how data consumers can use the Microsoft Azure Java SDK for Purview Sharing to manage their sharing activity.

#### Create a Receive Share Client
```C# Snippet:ReceivedSharesClientSample_CreateReceivedSharesClient
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
```

#### List detached received shares

To begin viewing data shared with them, a data consumer must first retrieve a list of detached received shares. Within this list, they can identify a detached received share to attach.

```C# Snippet:ReceivedSharesClientSample_ListDetachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllDetachedReceivedSharesAsync(null, null, new()).ToEnumerableAsync();
```

#### Attach a received share

Once the data consumer has identified a received share, they can attach the received share to a location where they can access the shared data. If the received share is already attached, the shared data will be made accessible at the new location specified.

```C# Snippet:ReceivedSharesClientSample_CreateReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

var data = new
{
    shareKind = "InPlace",
    properties = new
    {
        sink = new
        {
            storeKind = "AdlsGen2Account",
            storeReference = new
            {
                referenceName = "/subscriptions/suscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/receiverStorageAccount",

                type = "ArmResourceReference"
            },
            properties = new
            {
                containerName = "containerName",
                folder = "folder",
                mountPath = "mountPath",
            }
        },
        displayName = "displayName",
    }
};

Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "receivedShareId", RequestContent.Create(data));
```

#### Get a received share

A data consumer can retrieve an individual received share.

```C# Snippet:ReceivedSharesClientSample_GetReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Response operation = await receivedSharesClient.GetReceivedShareAsync("receivedShareId", new());
```

#### List attached received shares

Data consumers can also retrieve a list of their attached received shares.

```C# Snippet:ReceivedSharesClientSample_ListAttachedReceivedShares
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("referenceName", null, null, new()).ToEnumerableAsync();
```

#### Delete a received share

Data consumers can also retrieve a list of their attached received shares.

```C# Snippet:ReceivedSharesClientSample_DeleteReceivedShare
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "receivedShareId", new());
```

### Share Resouce Examples

The following code examples demonstrate how to use the Microsoft Azure Java SDK for Purview Sharing to view share resources. A share resource is the underlying resource from which a provider shares data or the destination where a consumer attaches data shared with them.

#### List share resources

A list of share resources can be retrieved to view all resources within an account where sharing activities have taken place.

```C# Snippet:ShareResourcesClientExample_ListShareResources
var credential = new DefaultAzureCredential();
var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
var shareResourcesClient = new ShareResourcesClient(endPoint, credential);

List<BinaryData> createResponse = await shareResourcesClient.GetAllShareResourcesAsync(null, null, null).ToEnumerableAsync();
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
[client_nuget_package]: https://www.nuget.org/packages?q=Azure.Analytics.Purview.Sharing
[share_product_documentation]: https://learn.microsoft.com/azure/purview/concept-data-share
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[protocol_client_quickstart]: https://aka.ms/azsdk/net/protocol/quickstart
[default_cred_ref]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[purview_resource]: https://learn.microsoft.com/azure/purview
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

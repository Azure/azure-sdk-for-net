# Release History

## 1.0.0-preview.1

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)

### Migration from Previous Version of Azure Management SDK

#### Package Name
The package name has been changed from `Microsoft.Azure.Management.EventHub` to `Azure.ResourceManager.EventHubs`

#### Management Client Changes

Example: Create an Event Hub:

Before upgrade:
```csharp
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.EventHub.Models;

var tokenCredentials = new TokenCredentials("YOUR ACCESS TOKEN");
var eventHubManagementClient = new EventHubManagementClient(tokenCredentials);
eventHubManagementClient.SubscriptionId = subscriptionId;

var createNamespaceResponse = eventHubManagementClient.Namespaces.CreateOrUpdate(
    resourceGroup,
    namespaceName,
    new EHNamespace()
    {
        Location = "westus",
        Sku = new Sku
        {
            Name = SkuName.Standard,
            Tier = SkuTier.Standard
        },
        Tags = new Dictionary<string, string>()
        {
            {"tag1", "value1"},
            {"tag2", "value2"}
        }
    });

var createEventHubResponse = this.EventHubManagementClient.EventHubs.CreateOrUpdate(
    resourceGroup,
    namespaceName,
    eventhubName,
    new Eventhub()
    {
        MessageRetentionInDays = 4,
        PartitionCount = 4,
        Status = EntityStatus.Active,
        CaptureDescription = new CaptureDescription()
        {
            Enabled = true,
            Encoding = EncodingCaptureDescription.Avro,
            IntervalInSeconds = 120,
            SizeLimitInBytes = 10485763,
            Destination = new Destination()
            {
                Name = "EventHubArchive.AzureBlockBlob",
                BlobContainer = "container",
                ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
                StorageAccountResourceId = "/subscriptions/" + ResourceManagementClient.SubscriptionId.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew"
            },
            SkipEmptyArchives = true
        }
    });
```

After upgrade:
```csharp
using Azure.Identity;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;

 var eventHubsManagementClient = new EventHubsManagementClient(subscriptionId, new DefaultAzureCredential());
 var namespacesOperations = eventHubsManagementClient.Namespaces;
 var eventHubsOperations = eventHubsManagementClient.EventHubs;

 var createNamespaceResponse = await namespacesOperations.StartCreateOrUpdateAsync(
     resourceGroup,
     namespaceName,
     new EHNamespace()
     {
         Location = "westus",
         Sku = new Sku(SkuName.Standard)
         {
             Tier = SkuTier.Standard,
         },
         Tags = new Dictionary<string, string>()
         {
             {"tag1", "value1"},
             {"tag2", "value2"}
         }
     });
 await createNamespaceResponse.WaitForCompletionAsync();

 // Create Eventhub
 Eventhub eventHub = await eventHubsOperations.CreateOrUpdateAsync(
     resourceGroup,
     namespaceName,
     venthubName,
     new Eventhub() { MessageRetentionInDays = 5 });
```

#### Object Model Changes

Example: Create an AuthorizationRule Model

Before upgrade:
```csharp
var createAutorizationRuleParameter = new AuthorizationRule()
    {
        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
    };
```

After upgrade:
```csharp
var createAutorizationRuleParameter = new AuthorizationRule()
    {
        Rights = new List<AccessRights>() { AccessRights.Listen,AccessRights.Send}
    };
```

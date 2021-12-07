# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2021-12-01)

This package follows the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html) which provide a number of core capabilities that are shared amongst all Azure SDKs, including the intuitive Azure Identity library, an HTTP Pipeline with custom policies, error-handling, distributed tracing, and much more.

This is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

### General New Features

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing
    - HTTP pipeline with custom policies
    - Better error-handling
    - Support uniform telemetry across all languages

> NOTE: For more information about unified authentication, please refer to [Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet)


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
```C# Snippet:ChangeLog_Sample
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.EventHubs.Models;

string namespaceName = "myNamespace";
string eventhubName = "myEventhub";
string resourceGroupName = "myResourceGroup";
ArmClient client = new ArmClient(new DefaultAzureCredential());
Subscription subscription = await client.GetDefaultSubscriptionAsync();
ResourceGroup resourceGroup = subscription.GetResourceGroups().Get(resourceGroupName);
//create namespace
EventHubNamespaceData parameters = new EventHubNamespaceData(Location.WestUS)
{
    Sku = new Sku(SkuName.Standard)
    {
        Tier = SkuTier.Standard,
    }
};
parameters.Tags.Add("tag1", "value1");
parameters.Tags.Add("tag2", "value2");
EventHubNamespaceCollection eHNamespaceCollection = resourceGroup.GetEventHubNamespaces();
EventHubNamespace eventHubNamespace = eHNamespaceCollection.CreateOrUpdate(namespaceName, parameters).Value;

//create eventhub
EventHubCollection eventHubCollection = eventHubNamespace.GetEventHubs();
EventHubData eventHubData = new EventHubData()
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
        Destination = new EventHubDestination()
        {
            Name = "EventHubArchive.AzureBlockBlob",
            BlobContainer = "Container",
            ArchiveNameFormat = "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}",
            StorageAccountResourceId = subscription.Id.ToString() + "/resourcegroups/v-ajnavtest/providers/Microsoft.Storage/storageAccounts/testingsdkeventhubnew"
        },
        SkipEmptyArchives = true
    }
};
EventHub eventHub = eventHubCollection.CreateOrUpdate(eventhubName, eventHubData).Value;
```

#### Object Model Changes

Example: Create an AuthorizationRule Model

Before upgrade:
```csharp
var createAuthorizationRuleParameter = new AuthorizationRule()
    {
        Rights = new List<string>() { AccessRights.Listen, AccessRights.Send }
    };
```

After upgrade:
```csharp
var createAuthorizationRuleParameter = new AuthorizationRuleData();
createAuthorizationRuleParameter.Rights.Add(AccessRights.Listen);
createAuthorizationRuleParameter.Rights.Add(AccessRights.Send);
```

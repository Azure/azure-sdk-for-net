# Microsoft Azure Load Testing management client library for .NET

Microsoft Azure Load Testing is a fully managed load-testing service that enables you to generate high-scale load. The service simulates traffic for your applications, regardless of where they're hosted. Developers, testers, and quality assurance (QA) engineers can use it to optimize application performance, scalability, or capacity.

This library supports managing Microsoft Azure Load Testing resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Load Testing management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.LoadTesting
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)..

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Create a new Azure Load Testing resource

Before creating an Azure Load Testing resource, we need to have a resource group.

```C#
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
// With the collection, we can create a new resource group with an specific name
string rgName = "sample-rg";
AzureLocation location = AzureLocation.WestUS2;
ArmOperation<ResourceGroupResource> resourceGroupLro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
ResourceGroupResource resourceGroup = lro.Value;
```

Create an Azure Load Testing resource.

```C# Snippet:LoadTesting_CreateLoadTestResource_Basic
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
string loadTestResourceName = "sample-loadtest";
LoadTestingResourceData inputPayload = new LoadTestingResourceData(AzureLocation.WestUS2);
ArmOperation<LoadTestingResource> loadTestingLro = await loadTestingCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, inputPayload);

LoadTestingResource resource = loadTestingLro.Value;
```

Create an Azure Load Testing resource configured with CMK encryption.

```C# Snippet:LoadTesting_CreateLoadTestResource_WithEncryption
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
string loadTestResourceName = "sample-loadtest";
LoadTestingResourceData inputPayload = new LoadTestingResourceData(AzureLocation.WestUS2);

// Managed identity properties
ResourceIdentifier identityId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
inputPayload.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
inputPayload.Identity.UserAssignedIdentities.Add(identityId, new UserAssignedIdentity());

// CMK encryption properties
inputPayload.Encryption = new LoadTestingCmkEncryptionProperties();
inputPayload.Encryption.KeyUri = new Uri("https://sample-kv.vault.azure.net/keys/cmkkey/2d1ccd5c50234ea2a0858fe148b69cde");
inputPayload.Encryption.Identity = new LoadTestingCmkIdentity();
inputPayload.Encryption.Identity.IdentityType = LoadTestingCmkIdentityType.UserAssigned;
inputPayload.Encryption.Identity.ResourceId = identityId;

ArmOperation<LoadTestingResource> loadTestingLro = await loadTestingCollection.CreateOrUpdateAsync(WaitUntil.Completed, loadTestResourceName, inputPayload);

LoadTestingResource resource = loadTestingLro.Value;
```

### Get details of an Azure Load Testing resource

```C# Snippet:LoadTesting_GetLoadTestResource
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();

string loadTestResourceName = "sample-loadtest";
Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);

LoadTestingResource resource = loadTestingResponse.Value;
```

### Update an Azure Load Testing resource

Update an Azure Load Testing resource to configure CMK encryption using system-assigned managed identity.
```C# Snippet:LoadTesting_UpdateLoadTestResource_WithEncryption
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
string loadTestResourceName = "sample-loadtest";
Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
LoadTestingResource resource = loadTestingResponse.Value;

ResourceIdentifier identityId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch {
    Encryption = new LoadTestingCmkEncryptionProperties
    {
        Identity = new LoadTestingCmkIdentity
        {
            // make sure that system-assigned managed identity is enabled on this resource and the identity has been granted required permissions to access the key.
            IdentityType = LoadTestingCmkIdentityType.SystemAssigned,
            ResourceId = null
        },
        KeyUri = new Uri("https://sample-kv.vault.azure.net/keys/cmkkey/2d1ccd5c50234ea2a0858fe148b69cde")
    }
};

ArmOperation<LoadTestingResource> loadTestingLro = await resource.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);

LoadTestingResource updatedResource = loadTestingLro.Value;
```

Update an Azure Load Testing resource to update user-assigned managed identities.
```C# Snippet:LoadTesting_UpdateLoadTestResource_WithManagedIdentity
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
string loadTestResourceName = "sample-loadtest";
Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
LoadTestingResource resource = loadTestingResponse.Value;

ResourceIdentifier identityId1 = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity1");
ResourceIdentifier identityId2 = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/sample-rg/providers/microsoft.managedidentity/userassignedidentities/identity2");

LoadTestingResourcePatch resourcePatchPayload = new LoadTestingResourcePatch();
resourcePatchPayload.Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
// removes user-assigned identity with resourceId <identityId1> (if already assigned to the load testing resource)
resourcePatchPayload.Identity.UserAssignedIdentities.Add(identityId1, null);
resourcePatchPayload.Identity.UserAssignedIdentities.Add(identityId2, new UserAssignedIdentity());

ArmOperation<LoadTestingResource> loadTestingLro = await resource.UpdateAsync(WaitUntil.Completed, resourcePatchPayload);
LoadTestingResource updatedResource = loadTestingLro.Value;
```

### Delete an Azure Load Testing resource

```C# Snippet:LoadTesting_DeleteLoadTestResource
LoadTestingResourceCollection loadTestingCollection = _resourceGroup.GetLoadTestingResources();
string loadTestResourceName = "sample-loadtest";
Response<LoadTestingResource> loadTestingResponse = await loadTestingCollection.GetAsync(loadTestResourceName);
LoadTestingResource resource = loadTestingResponse.Value;

ArmOperation loadTestDeleteResponse = await resource.DeleteAsync(WaitUntil.Completed);
```

### Quota Operations

Get Load Testing quota collection.

```C# Snippet:LoadTesting_GetQuotaCollection
LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);
// Use the quotaCollection for all the quota operations.
```

Get quota values for a particular quota bucket.

```C# Snippet:LoadTesting_GetQuotaBucket
LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

// Get the quota values for a particular quota bucket
Response<LoadTestingQuotaResource> quotaResponse = await QuotaCollection.GetAsync("maxConcurrentTestRuns");
LoadTestingQuotaResource quotaBucket = quotaResponse.Value;
```

Get quota values for all quota buckets.

```C# Snippet:LoadTesting_GetAllQuotaBuckets
LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

// Get the quota values for a all quota buckets
List<LoadTestingQuotaResource> quotaBuckets = await QuotaCollection.GetAllAsync().ToEnumerableAsync();
```

Check quota availability.

```C# Snippet:LoadTesting_CheckQuotaAvailability
LoadTestingQuotaCollection QuotaCollection = _subscription.GetAllLoadTestingQuota(AzureLocation.WestUS2);

Response<LoadTestingQuotaResource> quotaResponse = await QuotaCollection.GetAsync("maxConcurrentTestRuns");
LoadTestingQuotaResource quotaResource = quotaResponse.Value;

LoadTestingQuotaBucketDimensions dimensions = new LoadTestingQuotaBucketDimensions("<subscription-id>", AzureLocation.WestUS2, null);
LoadTestingQuotaBucketContent quotaAvailabilityPayload = new LoadTestingQuotaBucketContent(
    quotaResponse.Value.Data.Id,
    quotaResource.Data.Name,
    quotaResource.Data.ResourceType,
    null,
    quotaResource.Data.Usage,
    quotaResource.Data.Limit,
    50, // new quota value
    dimensions, null);

Response<LoadTestingQuotaAvailabilityResult> checkAvailabilityResult = await quotaResponse.Value.CheckLoadTestingQuotaAvailabilityAsync(quotaAvailabilityPayload);
// IsAvailable property indicates whether the requested quota is available.
Console.WriteLine(checkAvailabilityResult.Value.IsAvailable);
```

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing
guide][cg].

This project welcomes contributions and suggestions. Most contributions
require you to agree to a Contributor License Agreement (CLA) declaring
that you have the right to, and actually do, grant us the rights to use
your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine
whether you need to provide a CLA and decorate the PR appropriately
(for example, label, comment). Follow the instructions provided by the
bot. You'll only need to do this action once across all repositories
using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For
more information, see the [Code of Conduct FAQ][coc_faq] or contact
<opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

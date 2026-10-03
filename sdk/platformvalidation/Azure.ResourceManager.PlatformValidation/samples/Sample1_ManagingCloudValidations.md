# Managing cloud validations

This sample creates a cloud validation, retrieves it, lists cloud validations in a resource group, and deletes the sample resource. A cloud validation groups validation execution plans; creating it does not execute validation tests.

## Prerequisites

- An Azure subscription with access to the Platform Validation public preview and the `Microsoft.PlatformValidation` resource provider registered.
- An existing resource group and permission to create, read, and delete cloud validations in it.
- A region supported by the service.
- A .NET console application with the `Azure.ResourceManager.PlatformValidation` preview package and `Azure.Identity` installed:

```dotnetcli
dotnet add package Azure.ResourceManager.PlatformValidation --prerelease
dotnet add package Azure.Identity
```

Authenticate with a credential supported by `DefaultAzureCredential`, for example by signing in with `az login` for local development. Set `AZURE_SUBSCRIPTION_ID`, `AZURE_RESOURCE_GROUP`, and `AZURE_LOCATION` to your subscription, existing resource group, and supported region.

The snippets below can be combined in order in the console application's `Program.cs`. They make real Azure requests and create a resource. The final cleanup snippet deletes only the cloud validation created by this sample, not the resource group.

## Authenticate and get the collection

```C# Snippet:PlatformValidation_CloudValidations_Usings
using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.PlatformValidation;
using Azure.ResourceManager.PlatformValidation.Models;
using Azure.ResourceManager.Resources;
```

```C# Snippet:PlatformValidation_CloudValidations_Authenticate
string subscriptionId = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTION_ID")
    ?? throw new InvalidOperationException("Set AZURE_SUBSCRIPTION_ID.");
string resourceGroupName = Environment.GetEnvironmentVariable("AZURE_RESOURCE_GROUP")
    ?? throw new InvalidOperationException("Set AZURE_RESOURCE_GROUP to an existing resource group.");
string location = Environment.GetEnvironmentVariable("AZURE_LOCATION")
    ?? throw new InvalidOperationException("Set AZURE_LOCATION to a region supported by Platform Validation.");

ArmClient client = new ArmClient(new DefaultAzureCredential());
ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
ResourceGroupResource resourceGroup = client.GetResourceGroupResource(resourceGroupId);
CloudValidationCollection cloudValidations = resourceGroup.GetCloudValidations();
```

## Create a cloud validation

Use a unique name to avoid updating an existing cloud validation. `WaitUntil.Completed` waits for the long-running ARM operation to finish.

```C# Snippet:PlatformValidation_CloudValidations_Create
string cloudValidationName = $"sample-{Guid.NewGuid():N}";
CloudValidationData data = new CloudValidationData(new AzureLocation(location))
{
    Properties = new CloudValidationProperties
    {
        Description = "Cloud validation for grouping validation execution plans."
    }
};

ArmOperation<CloudValidationResource> operation = await cloudValidations.CreateOrUpdateAsync(
    WaitUntil.Completed, cloudValidationName, data);
CloudValidationResource cloudValidation = operation.Value;
Console.WriteLine($"Created cloud validation: {cloudValidation.Id}");
```

## Retrieve and list cloud validations

```C# Snippet:PlatformValidation_CloudValidations_GetAndList
Response<CloudValidationResource> response = await cloudValidations.GetAsync(cloudValidationName);
Console.WriteLine($"Description: {response.Value.Data.Properties.Description}");

await foreach (CloudValidationResource item in cloudValidations.GetAllAsync())
{
    Console.WriteLine(item.Id);
}
```

## Clean up

When you are finished, delete the sample cloud validation. If an earlier request fails after creating it, use the resource ID printed by the sample to find and clean up that resource.

```C# Snippet:PlatformValidation_CloudValidations_Delete
await cloudValidation.DeleteAsync(WaitUntil.Completed);
```

For the compile-checked source, see [Sample1_ManagingCloudValidations.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/platformvalidation/Azure.ResourceManager.PlatformValidation/tests/Samples/Sample1_ManagingCloudValidations.cs). The sample is not executed by automated tests because it requires service access and creates and deletes live resources.

# Azure Resource Management Batch Client for .NET

The Azure Resource Management Batch Client library provides Azure Resource Manager (ARM) batch operation capabilities, allowing you to execute multiple ARM requests in a single batch operation.

## Features

- **Batch Operations**: Execute multiple ARM requests at once with proper dependency management
- **Subscription Scope**: Perform batch operations at the subscription level
- **Resource Group Scope**: Perform batch operations at the resource group level  
- **Long Running Operations**: Full LRO support with async/await patterns
- **Error Handling**: Comprehensive error handling and status tracking
- **Cancellation Support**: Proper cancellation token support

## Getting Started

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/)
- The [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

### Install the package

Install the Azure Resource Management Batch Client library for .NET with [NuGet](https://www.nuget.org/):

```bash
dotnet add package Azure.ResourceManager.Batch --prerelease
```

### Authenticate the client

To interact with the Azure Resource Manager Batch service, you'll need to create an instance of the `BatchClient` class. You'll need a **subscription ID**, **credential**, and **endpoint** to instantiate a client object.

```csharp
using Azure.Identity;
using ResourceManagementClient;

string subscriptionId = "your-subscription-id";
var credential = new DefaultAzureCredential();
var client = new BatchClient(subscriptionId, credential);
```

## Key Concepts

### Batch Requests

A batch request consists of multiple individual ARM requests that can be executed together:

```csharp
var batchRequests = new BatchRequests
{
    Requests = new List<BatchRequest>
    {
        new BatchRequest
        {
            Name = "create-vm",
            HttpMethod = "PUT", 
            Uri = "/subscriptions/{subscriptionId}/resourceGroups/my-rg/providers/Microsoft.Compute/virtualMachines/my-vm",
            Content = vmDefinition
        },
        new BatchRequest
        {
            Name = "create-disk",
            HttpMethod = "PUT",
            Uri = "/subscriptions/{subscriptionId}/resourceGroups/my-rg/providers/Microsoft.Compute/disks/my-disk", 
            Content = diskDefinition,
            DependentOn = new[] { "create-vm" }
        }
    }
};
```

### Long Running Operations

Batch operations return a Long Running Operation (LRO) that can be polled for completion:

```csharp 
var operation = await client.InvokeAtSubscriptionScopeAsync(
    WaitUntil.Completed,
    RequestContent.Create(batchRequests));

await foreach (BinaryData response in operation.Value)
{
    // Process individual responses
    Console.WriteLine(response.ToString());
}
```

## Examples

### Execute batch at subscription scope

```csharp
using Azure.Identity;
using ResourceManagementClient;

string subscriptionId = "your-subscription-id";
var credential = new DefaultAzureCredential();
var client = new BatchClient(subscriptionId, credential);

var batchRequests = new BatchRequests
{
    Requests = new List<BatchRequest>
    {
        new BatchRequest
        {
            Name = "list-resource-groups",
            HttpMethod = "GET",
            Uri = $"/subscriptions/{subscriptionId}/resourceGroups"
        }
    }
};

var operation = await client.InvokeAtSubscriptionScopeAsync(
    WaitUntil.Completed,
    RequestContent.Create(batchRequests));

await foreach (BinaryData response in operation.Value)
{
    Console.WriteLine($"Response: {response}");
}
```

### Execute batch at resource group scope

```csharp
string resourceGroupName = "my-resource-group";

var operation = await client.InvokeAtResourceGroupScopeAsync(
    subscriptionId,
    resourceGroupName,
    WaitUntil.Completed,
    RequestContent.Create(batchRequests));

await foreach (BinaryData response in operation.Value)
{
    Console.WriteLine($"Response: {response}");
}
```

## API Reference

For detailed information about the available methods and their parameters, see the [API reference documentation](https://docs.microsoft.com/dotnet/api/azure.resourcemanager.batch).

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
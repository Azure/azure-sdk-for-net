# Microsoft Azure Workloads SapVirtualInstance management client library for .NET

Azure Workloads SAP Virtual Instance (ACSS) is a service that simplifies the deployment, registration, and management of SAP workloads on Azure. It provides end-to-end lifecycle management for SAP systems—including SAP Virtual Instances, Central Server Instances, Application Server Instances, and Database Instances—allowing you to deploy, start, stop, and monitor your SAP landscape from a single control plane.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Workloads SapVirtualInstance management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.WorkloadsSapVirtualInstance --prerelease
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
* You must have an existing Azure resource group to deploy the SAP Virtual Instance into.

### Authenticate the client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

```dotnetcli
dotnet add package Azure.Identity
```

```csharp
ArmClient client = new ArmClient(new DefaultAzureCredential());
```

## Key concepts

**SAP Virtual Instance (SVI)** — The top-level resource representing a complete SAP system registered with Azure Center for SAP Solutions (ACSS). It acts as a logical container that groups all components of an SAP deployment.

**SAP Central Server Instance** — Manages the ABAP message server and enqueue server within an SAP landscape.

**SAP Application Server Instance** — Represents individual SAP application servers (dialog instances) that handle user workloads.

**SAP Database Instance** — Represents the database tier (for example, SAP HANA) backing the SAP system.

For broader Azure SDK concepts, see [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Create a SAP Virtual Instance

```C# Snippet:WorkloadsSapVirtualInstance_CreateSapVirtualInstance
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

string sapVirtualInstanceName = "X00";
SapVirtualInstanceData data = new SapVirtualInstanceData(new AzureLocation("eastus2"))
{
    Tags = { ["environment"] = "production" },
};
ArmOperation<SapVirtualInstanceResource> lro = await collection.CreateOrUpdateAsync(
    WaitUntil.Completed, sapVirtualInstanceName, data);

SapVirtualInstanceResource sapVirtualInstance = lro.Value;
Console.WriteLine($"Created SAP Virtual Instance: {sapVirtualInstance.Data.Id}");
```

### Get a SAP Virtual Instance

```C# Snippet:WorkloadsSapVirtualInstance_GetSapVirtualInstance
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

string sapVirtualInstanceName = "X00";
SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

Console.WriteLine($"SAP Virtual Instance name: {sapVirtualInstance.Data.Name}");
Console.WriteLine($"SAP Virtual Instance status: {sapVirtualInstance.Data.Status}");
```

### List SAP Virtual Instances

```C# Snippet:WorkloadsSapVirtualInstance_ListSapVirtualInstances
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

await foreach (SapVirtualInstanceResource item in collection.GetAllAsync())
{
    Console.WriteLine($"SAP Virtual Instance: {item.Data.Name} - Status: {item.Data.Status}");
}
```

### Start a SAP Virtual Instance

```C# Snippet:WorkloadsSapVirtualInstance_StartSapVirtualInstance
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

string sapVirtualInstanceName = "X00";
SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

ArmOperation<OperationStatusResult> lro = await sapVirtualInstance.StartAsync(WaitUntil.Completed);
Console.WriteLine($"SAP Virtual Instance started. Status: {lro.Value.Status}");
```

### Stop a SAP Virtual Instance

```C# Snippet:WorkloadsSapVirtualInstance_StopSapVirtualInstance
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

string sapVirtualInstanceName = "X00";
SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

ArmOperation<OperationStatusResult> lro = await sapVirtualInstance.StopAsync(WaitUntil.Completed);
Console.WriteLine($"SAP Virtual Instance stopped. Status: {lro.Value.Status}");
```

### Delete a SAP Virtual Instance

```C# Snippet:WorkloadsSapVirtualInstance_DeleteSapVirtualInstance
SapVirtualInstanceCollection collection = _resourceGroup.GetSapVirtualInstances();

string sapVirtualInstanceName = "X00";
SapVirtualInstanceResource sapVirtualInstance = await collection.GetAsync(sapVirtualInstanceName);

await sapVirtualInstance.DeleteAsync(WaitUntil.Completed);
Console.WriteLine("SAP Virtual Instance deleted successfully.");
```

For additional code samples, see:
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
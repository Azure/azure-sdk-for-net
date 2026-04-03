# Microsoft Azure DevTest Labs management client library for .NET

Microsoft Azure DevTest Labs is a service for easily creating, using, and managing infrastructure-as-a-service (IaaS) virtual machines (VMs) and platform-as-a-service (PaaS) environments in labs.

This library supports managing Microsoft Azure DevTest Labs resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started

### Install the package

Install the Microsoft Azure DevTest Labs management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.DevTestLabs
```

### Prerequisites

* You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
* An existing Azure resource group where you want to create and manage DevTest Labs.

### Authenticate the client

To authenticate to Azure and create an `ArmClient`, install the [Azure.Identity][azure_identity_nuget] package:

```dotnetcli
dotnet add package Azure.Identity
```

Then use `DefaultAzureCredential`, which is appropriate for most scenarios including local development and production environments:

```C# Snippet:DevTestLabs_AuthClient_Namespaces
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DevTestLabs;
using Azure.ResourceManager.Resources;
```
```C# Snippet:DevTestLabs_AuthClient
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
```

More details about authentication can be found in the [Azure Identity documentation][azure_identity_readme] and the [management SDK quickstart guide][mgmt_quickstart].

## Key concepts

Key concepts of the Azure .NET SDK can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/README.md#key-concepts).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart][mgmt_quickstart]
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication][azure_identity_readme]

## Examples

### Create a lab

```C# Snippet:DevTestLabs_CreateALab
DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();
string labName = "myLab";
DevTestLabData labData = new DevTestLabData(location);
ArmOperation<DevTestLabResource> lro = await labCollection.CreateOrUpdateAsync(WaitUntil.Completed, labName, labData);
DevTestLabResource lab = lro.Value;
Console.WriteLine($"Created lab: {lab.Data.Name}");
```

### Get a lab

```C# Snippet:DevTestLabs_GetALab
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myResourceGroup";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();

string labName = "myLab";
DevTestLabResource lab = await labCollection.GetAsync(labName);
Console.WriteLine($"Retrieved lab: {lab.Data.Name}, location: {lab.Data.Location}");
```

### List all labs in a resource group

```C# Snippet:DevTestLabs_ListAllLabs
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myResourceGroup";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);
DevTestLabCollection labCollection = resourceGroup.GetDevTestLabs();

await foreach (DevTestLabResource lab in labCollection.GetAllAsync())
{
    Console.WriteLine($"Lab: {lab.Data.Name}");
}
```

### Check if a lab exists

```C# Snippet:DevTestLabs_CheckIfLabExists
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
string rgName = "myResourceGroup";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);

string labName = "myLab";
bool exists = await resourceGroup.GetDevTestLabs().ExistsAsync(labName);

if (exists)
{
    Console.WriteLine($"Lab '{labName}' exists.");
}
else
{
    Console.WriteLine($"Lab '{labName}' does not exist.");
}
```

### Delete a lab

```C# Snippet:DevTestLabs_DeleteALab
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
ResourceGroupCollection rgCollection = subscription.GetResourceGroups();

string rgName = "myResourceGroup";
ResourceGroupResource resourceGroup = await rgCollection.GetAsync(rgName);

string labName = "myLab";
DevTestLabResource lab = await resourceGroup.GetDevTestLabs().GetAsync(labName);
await lab.DeleteAsync(WaitUntil.Completed);
Console.WriteLine($"Deleted lab: {labName}");
```

For additional samples, see the [tests/Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/tests/Samples) folder and the [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples).

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
[azure_identity_nuget]: https://www.nuget.org/packages/Azure.Identity
[azure_identity_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[mgmt_quickstart]: https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md
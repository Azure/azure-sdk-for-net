# Azure Resource Manager Kubernetes Configuration Extensions client library for .NET

The Azure Kubernetes Configuration Extensions management library allows you to manage [Kubernetes Cluster Extensions](https://learn.microsoft.com/azure/azure-arc/kubernetes/conceptual-extensions) on AKS (Azure Kubernetes Service) and Arc-enabled Kubernetes clusters. Extensions allow you to install and manage lifecycle of cluster-level services such as monitoring, Azure Policy, Flux (GitOps), and more.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

- Support MSAL.NET; Azure.Identity is provided out of the box.
- Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
- HTTP pipeline with custom policies.
- Better error-handling.
- Uniform telemetry across all languages.

## Getting started

### Install the package

Install the Azure Resource Manager Kubernetes Configuration Extensions library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.KubernetesConfiguration.Extensions --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/).
- An existing AKS cluster or Arc-enabled Kubernetes cluster in Azure.

### Authenticate the client

To create an authenticated client and start interacting with Azure resources, see the [quickstart guide](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

### KubernetesClusterExtensionResource

A `KubernetesClusterExtensionResource` represents a Kubernetes cluster extension. Extensions are add-ons that can be installed on AKS or Arc-enabled Kubernetes clusters to provide additional capabilities. Common extension types include:

- `microsoft.flux` — GitOps continuous deployment using Flux.
- `microsoft.azuremonitor.containers` — Container insights and monitoring.
- `microsoft.policinsights.containerinsights` — Azure Policy for Kubernetes.

### Extension parameters

Many methods require three parameters to identify which cluster the extension belongs to:

| Parameter | Description | Examples |
|---|---|---|
| `clusterRp` | The resource provider owning the cluster | `Microsoft.ContainerService`, `Microsoft.Kubernetes` |
| `clusterResourceName` | The cluster resource type | `managedClusters` (AKS), `connectedClusters` (Arc) |
| `clusterName` | The name of the cluster | `my-aks-cluster` |

## Examples

### Create a cluster extension

```C# Snippet:CreateKubernetesClusterExtension
ArmClient client = new ArmClient(new DefaultAzureCredential());

string subscriptionId = "<subscription-id>";
string resourceGroupName = "<resource-group-name>";
string clusterRp = "Microsoft.ContainerService";
string clusterResourceName = "managedClusters";
string clusterName = "<cluster-name>";
string extensionName = "flux";

ResourceGroupResource resourceGroup = client.GetResourceGroupResource(
    ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName));

KubernetesClusterExtensionCollection extensions = resourceGroup.GetKubernetesClusterExtensions(
    clusterRp, clusterResourceName, clusterName);

KubernetesClusterExtensionData data = new KubernetesClusterExtensionData
{
    ExtensionType = "microsoft.flux",
    IsAutoUpgradeMinorVersionEnabled = true,
    ReleaseTrain = "Stable"
};

ArmOperation<KubernetesClusterExtensionResource> operation = await extensions.CreateOrUpdateAsync(
    WaitUntil.Completed, extensionName, data);
KubernetesClusterExtensionResource extension = operation.Value;

Console.WriteLine($"Created extension: {extension.Data.Name} (type: {extension.Data.ExtensionType})");
```

### Get a cluster extension

```C# Snippet:GetKubernetesClusterExtension
ArmClient client = new ArmClient(new DefaultAzureCredential());

string subscriptionId = "<subscription-id>";
string resourceGroupName = "<resource-group-name>";
string clusterRp = "Microsoft.ContainerService";
string clusterResourceName = "managedClusters";
string clusterName = "<cluster-name>";
string extensionName = "flux";

ResourceGroupResource resourceGroup = client.GetResourceGroupResource(
    ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName));

KubernetesClusterExtensionCollection extensions = resourceGroup.GetKubernetesClusterExtensions(
    clusterRp, clusterResourceName, clusterName);

KubernetesClusterExtensionResource extension = await extensions.GetAsync(extensionName);

Console.WriteLine($"Extension: {extension.Data.Name}");
Console.WriteLine($"  Type:              {extension.Data.ExtensionType}");
Console.WriteLine($"  Provisioning:      {extension.Data.ProvisioningState}");
Console.WriteLine($"  Current version:   {extension.Data.CurrentVersion}");
Console.WriteLine($"  Auto-upgrade:      {extension.Data.IsAutoUpgradeMinorVersionEnabled}");
```

### List all extensions on a cluster

```C# Snippet:ListKubernetesClusterExtensions
ArmClient client = new ArmClient(new DefaultAzureCredential());

string subscriptionId = "<subscription-id>";
string resourceGroupName = "<resource-group-name>";
string clusterRp = "Microsoft.ContainerService";
string clusterResourceName = "managedClusters";
string clusterName = "<cluster-name>";

ResourceGroupResource resourceGroup = client.GetResourceGroupResource(
    ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName));

KubernetesClusterExtensionCollection extensions = resourceGroup.GetKubernetesClusterExtensions(
    clusterRp, clusterResourceName, clusterName);

await foreach (KubernetesClusterExtensionResource extension in extensions.GetAllAsync())
{
    Console.WriteLine($"  {extension.Data.Name} ({extension.Data.ExtensionType}) - {extension.Data.ProvisioningState}");
}
```

### Update (patch) a cluster extension

```C# Snippet:UpdateKubernetesClusterExtension
ArmClient client = new ArmClient(new DefaultAzureCredential());

ResourceIdentifier extensionId = KubernetesClusterExtensionResource.CreateResourceIdentifier(
    subscriptionId: "<subscription-id>",
    resourceGroupName: "<resource-group-name>",
    clusterRp: "Microsoft.ContainerService",
    clusterResourceName: "managedClusters",
    clusterName: "<cluster-name>",
    extensionName: "flux");

KubernetesClusterExtensionResource extension = client.GetKubernetesClusterExtensionResource(extensionId);

KubernetesClusterExtensionPatch patch = new KubernetesClusterExtensionPatch
{
    ReleaseTrain = "Preview",
    IsAutoUpgradeMinorVersionEnabled = true
};

ArmOperation<KubernetesClusterExtensionResource> operation = await extension.UpdateAsync(
    WaitUntil.Completed, patch);
KubernetesClusterExtensionResource updated = operation.Value;

Console.WriteLine($"Updated extension release train to: {updated.Data.ReleaseTrain}");
```

### Delete a cluster extension

```C# Snippet:DeleteKubernetesClusterExtension
ArmClient client = new ArmClient(new DefaultAzureCredential());

ResourceIdentifier extensionId = KubernetesClusterExtensionResource.CreateResourceIdentifier(
    subscriptionId: "<subscription-id>",
    resourceGroupName: "<resource-group-name>",
    clusterRp: "Microsoft.ContainerService",
    clusterResourceName: "managedClusters",
    clusterName: "<cluster-name>",
    extensionName: "flux");

KubernetesClusterExtensionResource extension = client.GetKubernetesClusterExtensionResource(extensionId);

await extension.DeleteAsync(WaitUntil.Completed);

Console.WriteLine("Extension deleted.");
```

## Documentation

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md)
- [API Reference](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet)
- [Authentication with Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md)
- [Azure Arc Kubernetes Extensions overview](https://learn.microsoft.com/azure/azure-arc/kubernetes/conceptual-extensions)

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using the `azure` and `.net` tags.

## Next steps

For more information about the Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

For details on contributing to this repository, see the [contributing guide][cg].

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact <opencode@microsoft.com> with any other questions or comments.

<!-- LINKS -->
[cg]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/resourcemanager/Azure.ResourceManager/docs/CONTRIBUTING.md
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

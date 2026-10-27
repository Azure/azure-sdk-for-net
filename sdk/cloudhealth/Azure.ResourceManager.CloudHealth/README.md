# Microsoft Azure Cloud Health management client library for .NET

Azure Monitor health models enable customers to monitor the health of their applications with ease and confidence. These models use the Azure-wide workload concept of Service Groups to infer the scope of workloads and provide out-of-the-box health criteria based on platform metrics for Azure resources. 

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Cloud Health management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.CloudHealth
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
* The samples require an existing resource group, the `Microsoft.CloudHealth` resource provider registered at subscription scope, and a region where the service is available.
* Creating health models, entities, relationships, and submitting health reports requires write/action permissions, such as Contributor on the resource group. Reading health requires read access, such as Reader on the entity or a containing scope. Resource provider registration requires separate subscription-scoped permissions. See the [sample prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#prerequisites).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Documentation

Documentation is available to help you learn how to use this package:


- [API References](https://learn.microsoft.com/rest/api/health-models/operation-groups?view=rest-health-models-2026-11-01).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Create a health model

Create a health model in an existing resource group. Follow the [sample setup instructions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#getting-started) to install Azure Identity and authenticate, then replace the placeholders below with your resource details.

```csharp
using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.CloudHealth;
using Azure.ResourceManager.Resources;

var client = new ArmClient(new DefaultAzureCredential());
var resourceGroup = client.GetResourceGroupResource(
    ResourceGroupResource.CreateResourceIdentifier("<subscription-id>", "<resource-group>"));

var model = (await resourceGroup.GetHealthModels().CreateOrUpdateAsync(
    WaitUntil.Completed,
    "<health-model-name>",
    new HealthModelData(new AzureLocation("<enabled-region>")))).Value;

Console.WriteLine($"Health model ID: {model.Id}");
```

`WaitUntil.Completed` waits for resource provisioning, not health evaluation. `Unknown` or unavailable health must not be treated as `Healthy`.

### Full scenario

Continue with the [full health models walkthrough](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md) for setup and all four scenarios:

- [Create a health model](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#create-a-health-model).
- [Create an entity in a health model and connect it to the root entity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#create-an-entity-in-a-health-model).
- [Push health status to an entity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#push-health-status-to-an-entity).
- [Get an entity's health](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cloudhealth/Azure.ResourceManager.CloudHealth/samples/Sample1_HealthModels.md#get-an-entitys-health).

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
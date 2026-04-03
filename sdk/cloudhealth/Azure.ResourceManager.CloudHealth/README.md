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
dotnet add package Azure.ResourceManager.CloudHealth --prerelease
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Azure Monitor Cloud Health lets you build *health models* — directed graphs where **entities** (Azure resources) are connected by **relationships** (parent–child edges). The library exposes the following top-level resource types:

| Resource type | ARM type | Description |
|---|---|---|
| `HealthModelResource` | `Microsoft.CloudHealth/healthmodels` | A health model scoped to a resource group. |
| `HealthModelEntityResource` | `Microsoft.CloudHealth/healthmodels/entities` | A monitored Azure resource (node) inside a health model. |
| `HealthModelRelationshipResource` | `Microsoft.CloudHealth/healthmodels/relationships` | A directed edge between two entities (parent → child). |
| `HealthModelDiscoveryRuleResource` | `Microsoft.CloudHealth/healthmodels/discoveryrules` | A rule that automatically discovers entities and relationships. |
| `HealthModelAuthenticationSettingResource` | `Microsoft.CloudHealth/healthmodels/authenticationsettings` | Authentication settings used by the health model. |
| `HealthModelSignalDefinitionResource` | `Microsoft.CloudHealth/healthmodels/signaldefinitions` | A signal definition that determines health criteria for entities. |

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

### Manage relationships between health model entities

A **relationship** is a directed edge between two entities (identified by their resource names inside the health model). The following examples demonstrate the most common operations.

#### Create or update a relationship

```C#
TokenCredential cred = new DefaultAzureCredential();
ArmClient client = new ArmClient(cred);

string subscriptionId = "<subscription-id>";
string resourceGroupName = "<resource-group>";
string healthModelName = "<health-model-name>";

ResourceIdentifier healthModelId = HealthModelResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, healthModelName);
HealthModelResource healthModel = client.GetHealthModelResource(healthModelId);

HealthModelRelationshipCollection relationships = healthModel.GetHealthModelRelationships();

string relationshipName = "rel-parent-child";
HealthModelRelationshipData data = new HealthModelRelationshipData
{
    Properties = new HealthModelRelationshipProperties("ParentEntity", "ChildEntity")
    {
        DisplayName = "Parent to Child",
        Labels = { ["environment"] = "production" },
    },
};

ArmOperation<HealthModelRelationshipResource> lro = await relationships.CreateOrUpdateAsync(WaitUntil.Completed, relationshipName, data);
HealthModelRelationshipResource relationship = lro.Value;
Console.WriteLine($"Created relationship: {relationship.Data.Id}");
```

#### Get an existing relationship

```C#
TokenCredential cred = new DefaultAzureCredential();
ArmClient client = new ArmClient(cred);

ResourceIdentifier relationshipId = HealthModelRelationshipResource.CreateResourceIdentifier(
    subscriptionId: "<subscription-id>",
    resourceGroupName: "<resource-group>",
    healthModelName: "<health-model-name>",
    relationshipName: "<relationship-name>");

HealthModelRelationshipResource relationship = client.GetHealthModelRelationshipResource(relationshipId);
HealthModelRelationshipResource result = await relationship.GetAsync();
Console.WriteLine($"Parent: {result.Data.Properties.ParentEntityName}, Child: {result.Data.Properties.ChildEntityName}");
```

#### List all relationships in a health model

```C#
TokenCredential cred = new DefaultAzureCredential();
ArmClient client = new ArmClient(cred);

ResourceIdentifier healthModelId = HealthModelResource.CreateResourceIdentifier("<subscription-id>", "<resource-group>", "<health-model-name>");
HealthModelResource healthModel = client.GetHealthModelResource(healthModelId);

await foreach (HealthModelRelationshipResource item in healthModel.GetHealthModelRelationships())
{
    Console.WriteLine($"{item.Data.Properties.ParentEntityName} -> {item.Data.Properties.ChildEntityName}");
}
```

#### Delete a relationship

```C#
TokenCredential cred = new DefaultAzureCredential();
ArmClient client = new ArmClient(cred);

ResourceIdentifier relationshipId = HealthModelRelationshipResource.CreateResourceIdentifier(
    "<subscription-id>", "<resource-group>", "<health-model-name>", "<relationship-name>");

HealthModelRelationshipResource relationship = client.GetHealthModelRelationshipResource(relationshipId);
await relationship.DeleteAsync(WaitUntil.Completed);
Console.WriteLine("Relationship deleted.");
```

Additional code samples for using the management library can be found in the following locations:
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
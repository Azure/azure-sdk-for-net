# Microsoft Azure Batch management client library for .NET

Use Microsoft Azure Batch to run large-scale parallel and high-performance computing (HPC) batch jobs efficiently in Azure. Azure Batch creates and manages a pool of compute nodes (virtual machines), installs the applications you want to run, and schedules jobs to run on the nodes. 

This library supports managing Microsoft Azure Batch resources.

This library follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

## Getting started 

### Install the package

Install the Microsoft Azure Batch management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.Batch
```

### Prerequisites

* You must have an [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

Code samples for using the management library for .NET can be found in the following locations
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

## Migrating from version 1.x to 2.0

Version 2.0 uses service API version `2026-10-01` by default and includes the breaking changes listed in the [changelog](CHANGELOG.md).

### Updating pools

`BatchAccountPoolResource.Update` and `UpdateAsync` now accept `BatchAccountPoolPatch` instead of `BatchAccountPoolData`. Construct the update settings inside `PoolPatchProperties`:

```C# Snippet:Azure_ResourceManager_Batch_CreatePoolPatch
var patch = new BatchAccountPoolPatch
{
    Properties = new PoolPatchProperties
    {
        ScaleSettings = new BatchAccountPoolScaleSettings
        {
            AutoScale = new BatchAccountAutoScaleSettings("$TargetDedicatedNodes=34")
        }
    }
};
```

Pass this patch to `Update` or `UpdateAsync`. Pool reads and update responses still return `BatchAccountPoolData`; do not pass that response data directly to the update methods.

### Authentication modes

`BatchAuthenticationMode.TaskAuthenticationToken` was removed. Remove references to this enum value and use an authentication mode supported by the service.

Account responses from older API versions, including older test recordings, that contain `TaskAuthenticationToken` cannot be deserialized by version 2.0. Applications that explicitly select an older API version should account for this incompatibility before upgrading.

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about Microsoft Azure SDK, see [this website](https://azure.github.io/azure-sdk/).

## Contributing

### Recording management tests

Provision the resources in [the Batch test-resource template](../test-resources.json) before recording tests. The template accepts `batchAccounts_poolallocation_location` and `batchAccounts_usersubscription_location` overrides so the two setup accounts can use separate regional quotas. Both default to the deployment's `location`; the user-subscription account's Key Vault and disk encryption set use its selected region.

The generated test environment's `LOCATION` selects the region for additional test accounts and their storage. Allow at least three free Batch account slots in that region for the account-collection test.

For non-interactive developer recording, set `BATCH_USE_CLI_AUTH=true` to use Azure CLI authentication in the tenant from the test environment. Without this flag, the existing developer credential behavior is unchanged.

Set the optional MSBuild property `BatchTestTargetFramework` to a single target, such as `net10.0`, when recording with limited quota. Leave it unset for normal validation across all required frameworks. Use serial NUnit run settings and wait for resource cleanup between fixtures before starting another recording run.

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
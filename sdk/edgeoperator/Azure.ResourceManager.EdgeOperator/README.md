# Azure Resource Manager EdgeOperator client library for .NET

This package provides management operations for `Microsoft.EdgeOperator`
resources.

In `1.0.0-beta.1`, the preview surface is focused on Billing Configurations for
Azure Local Disconnected Operations (ALDO), including the active singleton
billing configuration and its immutable snapshots.

## Getting started

### Install the package

Install the Azure.ResourceManager.EdgeOperator management library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.ResourceManager.EdgeOperator --prerelease
```

### Prerequisites

* You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

To create an authenticated client, see the [management quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

## Key concepts

Key concepts of the Microsoft Azure SDK for .NET can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html).

This package currently targets `Microsoft.EdgeOperator` API version
`2026-06-01-preview` and includes:

- `BillingConfigurationResource` as a singleton subscription resource named
    `default`.
- `CreateOrUpdate` (HTTP PUT) for create-or-replace of the active billing
    configuration.
- `Get` for the active billing configuration.
- `BillingConfigurationSnapshotResource` and
    `BillingConfigurationSnapshotCollection` for read-only historical snapshots.

The billing configuration resource intentionally does not expose PATCH or DELETE.

## Documentation

Documentation is available to help you learn how to use this package:

- [Quickstart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).
- [API References](https://learn.microsoft.com/dotnet/api/?view=azure-dotnet).
- [Authentication](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md).

## Examples

Code samples for management libraries are available at:
- [.NET Management Library Code Samples](https://aka.ms/azuresdk-net-mgmt-samples)

Typical workflow:

1. Create an `ArmClient`.
2. Resolve a `SubscriptionResource`.
3. Retrieve the singleton billing configuration resource using
    `GetBillingConfiguration()`.
4. Call `CreateOrUpdate` to replace the active billing manifest.
5. Use `GetBillingConfigurationSnapshots().GetAllAsync()` to enumerate immutable
    historical snapshots.

## Troubleshooting

- File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
- Check [existing questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

For more information about the Azure SDK, see [azure.github.io/azure-sdk](https://azure.github.io/azure-sdk/).

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

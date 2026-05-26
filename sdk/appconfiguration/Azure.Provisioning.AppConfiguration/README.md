# Azure Provisioning AppConfiguration client library for .NET

Azure.Provisioning.AppConfiguration simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.AppConfiguration
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Basic AppConfiguration Resource

This example demonstrates how to create an App Configuration store with a feature flag, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.appconfiguration/app-configuration-store-ff/main.bicep).

```C# Snippet:AppConfigurationStoreFF
Infrastructure infra = new();

ProvisioningParameter featureFlagKey =
    new(nameof(featureFlagKey), typeof(string))
    {
        Value = "FeatureFlagSample",
        Description = "Specifies the key of the feature flag."
    };
infra.Add(featureFlagKey);

AppConfigurationStore configStore =
    new(nameof(configStore), AppConfigurationStore.ResourceVersions.V2022_05_01)
    {
        SkuName = "Standard",
    };
infra.Add(configStore);

ProvisioningVariable flag =
    new(nameof(flag), typeof(object))
    {
        Value =
            new BicepDictionary<object>
            {
                { "id", featureFlagKey },
                { "description", "A simple feature flag." },
                { "enabled", true }
            }
    };
infra.Add(flag);

AppConfigurationKeyValue featureFlag =
    new(nameof(featureFlag), AppConfigurationKeyValue.ResourceVersions.V2022_05_01)
    {
        Parent = configStore,
        Name = BicepFunction.Interpolate($".appconfig.featureflag~2F{featureFlagKey}"),
        ContentType = "application/vnd.microsoft.appconfig.ff+json;charset=utf-8",
        Value = BicepFunction.AsString(flag)
    };
infra.Add(featureFlag);
```

## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

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

# Azure Provisioning AppService client library for .NET

Azure.Provisioning.AppService simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.AppService
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a Basic Function App

This example demonstrates how to create a Function App with required dependencies including storage account and application insights, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.web/function-app-create-dynamic/main.bicep).

```C# Snippet:AppServiceBasic
Infrastructure infra = new();

StorageAccount storage =
    new(nameof(storage))
    {
        Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
        Kind = StorageKind.Storage,
        EnableHttpsTrafficOnly = true,
        IsDefaultToOAuthAuthentication = true
    };
infra.Add(storage);

AppServicePlan hostingPlan =
    new(nameof(hostingPlan), "2021-03-01")
    {
        Sku =
            new AppServiceSkuDescription
            {
                Tier = "Dynamic",
                Name = "Y1"
            }
    };
infra.Add(hostingPlan);

ApplicationInsightsComponent appInsights =
    new(nameof(appInsights))
    {
        Kind = "web",
        ApplicationType = ApplicationInsightsApplicationType.Web,
        RequestSource = ComponentRequestSource.Rest
    };
infra.Add(appInsights);

ProvisioningVariable funcAppName =
    new(nameof(funcAppName), typeof(string))
    {
        Value = BicepFunction.Concat("functionApp-", BicepFunction.GetUniqueString(BicepFunction.GetResourceGroup().Id))
    };
infra.Add(funcAppName);

WebSite functionApp =
    new(nameof(functionApp), WebSite.ResourceVersions.V2023_12_01)
    {
        Name = funcAppName,
        Kind = "functionapp",
        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
        AppServicePlanId = hostingPlan.Id,
        IsHttpsOnly = true,
        SiteConfig =
            new SiteConfigProperties
            {
                FtpsState = AppServiceFtpsState.FtpsOnly,
                MinTlsVersion = AppServiceSupportedTlsVersion.Tls1_2,
                AppSettings =
                {
                    new AppServiceNameValuePair
                    {
                        Name = "AzureWebJobsStorage",
                        Value = BicepFunction.Interpolate($"DefaultEndpointsProtocol=https;AccountName={storage.Name};EndpointSuffix=core.windows.net;AccountKey={storage.GetKeys()[0].Unwrap().Value}")
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "WEBSITE_CONTENTAZUREFILECONNECTIONSTRING",
                        Value = BicepFunction.Interpolate($"DefaultEndpointsProtocol=https;AccountName={storage.Name};EndpointSuffix=core.windows.net;AccountKey={storage.GetKeys()[0].Unwrap().Value}")
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "WEBSITE_CONTENTSHARE",
                        Value = BicepFunction.ToLower(funcAppName)
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "FUNCTIONS_EXTENSION_VERSION",
                        Value = "~4"
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "WEBSITE_NODE_DEFAULT_VERSION",
                        Value = "~14"
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "FUNCTIONS_WORKER_RUNTIME",
                        Value = "dotnet"
                    },
                    new AppServiceNameValuePair
                    {
                        Name = "APPINSIGHTS_INSTRUMENTATIONKEY",
                        Value = appInsights.InstrumentationKey
                    }
                }
            }
    };
infra.Add(functionApp);
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

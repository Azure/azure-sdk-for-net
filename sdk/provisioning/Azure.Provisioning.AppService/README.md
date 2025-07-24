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

### Create a Function App with storage and hosting plan

```csharp
using Azure.Provisioning;
using Azure.Provisioning.AppService;
using Azure.Provisioning.ApplicationInsights;
using Azure.Provisioning.Storage;

Infrastructure infrastructure = new Infrastructure();

// Create storage account for the function app
StorageAccount storage = new StorageAccount("storage")
{
    Sku = new StorageSku { Name = StorageSkuName.StandardLrs },
    Kind = StorageKind.Storage,
    EnableHttpsTrafficOnly = true,
    IsDefaultToOAuthAuthentication = true
};
infrastructure.Add(storage);

// Create an App Service plan (consumption plan for functions)
AppServicePlan hostingPlan = new AppServicePlan("hostingPlan", "2021-03-01")
{
    Sku = new AppServiceSkuDescription
    {
        Tier = "Dynamic",
        Name = "Y1"
    }
};
infrastructure.Add(hostingPlan);

// Create Application Insights for monitoring
ApplicationInsightsComponent appInsights = new ApplicationInsightsComponent("appInsights")
{
    Kind = "web",
    ApplicationType = ApplicationInsightsApplicationType.Web,
    RequestSource = ComponentRequestSource.Rest
};
infrastructure.Add(appInsights);

// Create the Function App
WebSite functionApp = new WebSite("functionApp")
{
    Kind = "functionapp",
    Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
    AppServicePlanId = hostingPlan.Id,
    IsHttpsOnly = true,
    SiteConfig = new SiteConfigProperties
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
                Name = "FUNCTIONS_EXTENSION_VERSION",
                Value = "~4"
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
infrastructure.Add(functionApp);

// Generate the Bicep template
string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
```

### Create a basic web app

```csharp
using Azure.Provisioning;
using Azure.Provisioning.AppService;

Infrastructure infrastructure = new Infrastructure();

// Create an App Service plan
AppServicePlan appServicePlan = new AppServicePlan("plan")
{
    Sku = new AppServiceSkuDescription
    {
        Name = "F1",  // Free tier
        Tier = "Free"
    }
};
infrastructure.Add(appServicePlan);

// Create a web app
WebSite webApp = new WebSite("webapp")
{
    AppServicePlanId = appServicePlan.Id,
    IsHttpsOnly = true,
    SiteConfig = new SiteConfigProperties
    {
        MinTlsVersion = AppServiceSupportedTlsVersion.Tls1_2,
        AppSettings =
        {
            new AppServiceNameValuePair
            {
                Name = "ASPNETCORE_ENVIRONMENT",
                Value = "Production"
            }
        }
    }
};
infrastructure.Add(webApp);

string bicep = infrastructure.Compile();
Console.WriteLine(bicep);
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

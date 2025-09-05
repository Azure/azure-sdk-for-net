# Azure Provisioning AppContainers client library for .NET

Azure.Provisioning.AppContainers simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.AppContainers
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create A Container App

This example demonstrates how to create a Container App with log analytics workspace and managed environment, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.app/container-app-create/main.bicep).

```C# Snippet:AppContainerBasic
Infrastructure infra = new();

ProvisioningParameter containerImage =
    new(nameof(containerImage), typeof(string))
    {
        Value = "mcr.microsoft.com/azuredocs/containerapps-helloworld:latest",
        Description = "Specifies the docker container image to deploy."
    };
infra.Add(containerImage);

OperationalInsightsWorkspace logAnalytics =
    new(nameof(logAnalytics), OperationalInsightsWorkspace.ResourceVersions.V2023_09_01)
    {
        Sku = new OperationalInsightsWorkspaceSku { Name = OperationalInsightsWorkspaceSkuName.PerGB2018 }
    };
infra.Add(logAnalytics);

ContainerAppManagedEnvironment env =
    new(nameof(env), ContainerAppManagedEnvironment.ResourceVersions.V2024_03_01)
    {
        AppLogsConfiguration =
            new ContainerAppLogsConfiguration
            {
                Destination = "log-analytics",
                LogAnalyticsConfiguration = new ContainerAppLogAnalyticsConfiguration
                {
                    CustomerId = logAnalytics.CustomerId,
                    SharedKey = logAnalytics.GetKeys().PrimarySharedKey,
                }
            },
    };
infra.Add(env);

ContainerApp app =
    new(nameof(app), ContainerApp.ResourceVersions.V2024_03_01)
    {
        ManagedEnvironmentId = env.Id,
        Configuration =
            new ContainerAppConfiguration
            {
                Ingress =
                    new ContainerAppIngressConfiguration
                    {
                        External = true,
                        TargetPort = 80,
                        AllowInsecure = false,
                        Traffic =
                        {
                            new ContainerAppRevisionTrafficWeight
                            {
                                IsLatestRevision = true,
                                Weight = 100
                            }
                        }
                    },
            },
        Template =
            new ContainerAppTemplate
            {
                RevisionSuffix = "firstrevision",
                Scale = new ContainerAppScale { MinReplicas = 1, MaxReplicas = 3 },
                Containers =
                {
                    new ContainerAppContainer
                    {
                        Name = "test",
                        Image = containerImage,
                        Resources =
                            new AppContainerResources
                            {
                                Cpu = (BicepExpression?)BicepFunction.ParseJson("0.5"),
                                Memory = "1Gi"
                            }
                    }
                }
            }
    };
infra.Add(app);
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

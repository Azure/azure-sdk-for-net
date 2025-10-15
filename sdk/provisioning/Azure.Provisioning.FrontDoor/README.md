# Azure Provisioning FrontDoor client library for .NET

Azure.Provisioning.FrontDoor simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.FrontDoor
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a basic Front Door

This template creates a basic Front Door configuration with a single backend, single default path match /* and no custom domain.

```C# Snippet:FrontDoorBasic
Infrastructure infra = new();

ProvisioningParameter frontDoorName =
    new(nameof(frontDoorName), typeof(string))
    {
        Description = "The name of the frontdoor resource."
    };
infra.Add(frontDoorName);

ProvisioningParameter backendAddress =
    new(nameof(backendAddress), typeof(string))
    {
        Description = "The hostname of the backend. Must be an IP address or FQDN."
    };
infra.Add(backendAddress);

ProvisioningVariable frontEndEndpointName =
    new(nameof(frontEndEndpointName), typeof(string))
    {
        Value = "frontEndEndpoint"
    };
infra.Add(frontEndEndpointName);

ProvisioningVariable loadBalancingSettingsName =
    new(nameof(loadBalancingSettingsName), typeof(string))
    {
        Value = "loadBalancingSettings"
    };
infra.Add(loadBalancingSettingsName);

ProvisioningVariable healthProbeSettingsName =
    new(nameof(healthProbeSettingsName), typeof(string))
    {
        Value = "healthProbeSettings"
    };
infra.Add(healthProbeSettingsName);

ProvisioningVariable routingRuleName =
    new(nameof(routingRuleName), typeof(string))
    {
        Value = "routingRule"
    };
infra.Add(routingRuleName);

ProvisioningVariable backendPoolName =
    new(nameof(backendPoolName), typeof(string))
    {
        Value = "backendPool"
    };
infra.Add(backendPoolName);

FrontDoorResource frontDoor =
    new(nameof(frontDoor), FrontDoorResource.ResourceVersions.V2021_06_01)
    {
        Name = frontDoorName,
        Location = new AzureLocation("global"),
        EnabledState = FrontDoorEnabledState.Enabled,
        FrontendEndpoints =
        {
            new FrontendEndpointData
            {
                Name = frontEndEndpointName,
                HostName = BicepFunction.Interpolate($"{frontDoorName}.azurefd.net"),
                SessionAffinityEnabledState = SessionAffinityEnabledState.Disabled
            }
        },
        LoadBalancingSettings =
        {
            new FrontDoorLoadBalancingSettingsData
            {
                Name = loadBalancingSettingsName,
                SampleSize = 4,
                SuccessfulSamplesRequired = 2
            }
        },
        HealthProbeSettings =
        {
            new FrontDoorHealthProbeSettingsData
            {
                Name = healthProbeSettingsName,
                Path = "/",
                Protocol = FrontDoorProtocol.Http,
                IntervalInSeconds = 120
            }
        },
        BackendPools =
        {
            new FrontDoorBackendPool
            {
                Name = backendPoolName,
                Backends =
                {
                    new FrontDoorBackend
                    {
                        Address = backendAddress,
                        BackendHostHeader = backendAddress,
                        HttpPort = 80,
                        HttpsPort = 443,
                        Weight = 50,
                        Priority = 1,
                        EnabledState = BackendEnabledState.Enabled
                    }
                },
                LoadBalancingSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/loadBalancingSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(loadBalancingSettingsName.BicepIdentifier)),
                HealthProbeSettingsId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/healthProbeSettings"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(healthProbeSettingsName.BicepIdentifier))
            }
        },
        RoutingRules =
        {
            new RoutingRuleData
            {
                Name = routingRuleName,
                FrontendEndpoints =
                {
                    new WritableSubResource
                    {
                        Id = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/frontEndEndpoints"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(frontEndEndpointName.BicepIdentifier))
                    }
                },
                AcceptedProtocols = { FrontDoorProtocol.Http, FrontDoorProtocol.Https },
                PatternsToMatch = { "/*" },
                RouteConfiguration = new ForwardingConfiguration
                {
                    ForwardingProtocol = FrontDoorForwardingProtocol.MatchRequest,
                    BackendPoolId = new FunctionCallExpression(new IdentifierExpression("resourceId"), new StringLiteralExpression("Microsoft.Network/frontDoors/backEndPools"), new IdentifierExpression(frontDoorName.BicepIdentifier), new IdentifierExpression(backendPoolName.BicepIdentifier))
                },
                EnabledState = RoutingRuleEnabledState.Enabled
            }
        }
    };
infra.Add(frontDoor);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = new MemberExpression(new IdentifierExpression( frontDoor.BicepIdentifier), "name") }); // TODO -- update this to use the expression conversion
infra.Add(new ProvisioningOutput("resourceGroupName", typeof(string)) { Value = BicepFunction.GetResourceGroup().Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = frontDoor.Id });
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

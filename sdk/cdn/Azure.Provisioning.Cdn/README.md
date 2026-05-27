# Azure Provisioning Cdn client library for .NET

Azure.Provisioning.Cdn simplifies declarative resource provisioning for Azure CDN in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Provisioning.Cdn --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use `azd` to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create a CDN Profile and Endpoint with Custom Origin

This example demonstrates how to create a CDN profile and endpoint with a custom origin, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/cdn-with-custom-origin/main.bicep).

```C# Snippet:CdnWithCustomOrigin
Infrastructure infra = new();

ProvisioningParameter profileName = new(nameof(profileName), typeof(string))
{
    Description = "Name of the CDN Profile."
};
infra.Add(profileName);

ProvisioningParameter endpointName = new(nameof(endpointName), typeof(string))
{
    Description = "Name of the CDN Endpoint, must be unique."
};
infra.Add(endpointName);

ProvisioningParameter originUrl = new(nameof(originUrl), typeof(string))
{
    Description = "Url of the origin."
};
infra.Add(originUrl);

CdnProfile profile = new(nameof(profile), CdnProfile.ResourceVersions.V2025_06_01)
{
    Name = profileName,
    Location = new AzureLocation("global"),
    SkuName = CdnSkuName.StandardMicrosoft
};
infra.Add(profile);

CdnEndpoint endpoint = new(nameof(endpoint), CdnEndpoint.ResourceVersions.V2025_06_01)
{
    Parent = profile,
    Name = endpointName,
    Location = new AzureLocation("global"),
    OriginHostHeader = originUrl,
    IsHttpAllowed = true,
    IsHttpsAllowed = true,
    QueryStringCachingBehavior = QueryStringCachingBehavior.IgnoreQueryString,
    IsCompressionEnabled = true,
    ContentTypesToCompress =
    {
        "application/javascript",
        "application/json",
        "application/xml",
        "text/css",
        "text/html",
        "text/plain"
    },
    Origins =
    {
        new DeepCreatedOrigin
        {
            Name = "origin1",
            HostName = originUrl
        }
    }
};
infra.Add(endpoint);

infra.Add(new ProvisioningOutput("endpointHostName", typeof(string)) { Value = endpoint.HostName });
```

### Create a Front Door Standard/Premium Profile

This example demonstrates how to create a Front Door Standard/Premium profile with an endpoint, origin group, origin, and route, based on the [Azure quickstart template](https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cdn/front-door-standard-premium/main.bicep).

```C# Snippet:FrontDoorStandardPremium
Infrastructure infra = new();

ProvisioningParameter originHostName = new(nameof(originHostName), typeof(string))
{
    Description = "The host name that should be used when connecting from Front Door to the origin."
};
infra.Add(originHostName);

CdnProfile profile = new(nameof(profile), CdnProfile.ResourceVersions.V2025_06_01)
{
    Name = "MyFrontDoor",
    Location = new AzureLocation("global"),
    SkuName = CdnSkuName.StandardAzureFrontDoor
};
infra.Add(profile);

FrontDoorEndpoint endpoint = new(nameof(endpoint), FrontDoorEndpoint.ResourceVersions.V2025_06_01)
{
    Parent = profile,
    Name = "MyEndpoint",
    Location = new AzureLocation("global"),
    EnabledState = EnabledState.Enabled
};
infra.Add(endpoint);

FrontDoorOriginGroup originGroup = new(nameof(originGroup), FrontDoorOriginGroup.ResourceVersions.V2025_06_01)
{
    Parent = profile,
    Name = "MyOriginGroup",
    LoadBalancingSettings = new LoadBalancingSettings
    {
        SampleSize = 4,
        SuccessfulSamplesRequired = 3
    },
    HealthProbeSettings = new HealthProbeSettings
    {
        ProbePath = "/",
        ProbeRequestType = HealthProbeRequestType.Head,
        ProbeProtocol = HealthProbeProtocol.Http,
        ProbeIntervalInSeconds = 100
    }
};
infra.Add(originGroup);

FrontDoorOrigin origin = new(nameof(origin), FrontDoorOrigin.ResourceVersions.V2025_06_01)
{
    Parent = originGroup,
    Name = "MyOrigin",
    HostName = originHostName,
    HttpPort = 80,
    HttpsPort = 443,
    OriginHostHeader = originHostName,
    Priority = 1,
    Weight = 1000
};
infra.Add(origin);

FrontDoorRoute route = new(nameof(route), FrontDoorRoute.ResourceVersions.V2025_06_01)
{
    Parent = endpoint,
    Name = "MyRoute",
    OriginGroupId = originGroup.Id,
    SupportedProtocols =
    {
        FrontDoorEndpointProtocol.Http,
        FrontDoorEndpointProtocol.Https
    },
    PatternsToMatch =
    {
        "/*"
    },
    ForwardingProtocol = ForwardingProtocol.HttpsOnly,
    LinkToDefaultDomain = LinkToDefaultDomain.Enabled,
    HttpsRedirect = HttpsRedirect.Enabled
};
infra.Add(route);

infra.Add(new ProvisioningOutput("frontDoorEndpointHostName", typeof(string)) { Value = endpoint.HostName });
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

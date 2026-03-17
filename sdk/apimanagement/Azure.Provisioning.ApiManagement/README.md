# Azure Provisioning ApiManagement client library for .NET

Azure.Provisioning.ApiManagement simplifies declarative resource provisioning in .NET.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Provisioning.ApiManagement --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/).

### Authenticate the Client

## Key concepts

This library allows you to specify your infrastructure in a declarative style using dotnet.  You can then use azd to deploy your infrastructure to Azure directly without needing to write or maintain bicep or arm templates.

## Examples

### Create an API Management Service with Managed Identity

This example demonstrates how to create an Azure API Management service with system-assigned managed identity.

```C# Snippet:ApiManagementBasic
Infrastructure infra = new();

ProvisioningParameter publisherEmail =
    new(nameof(publisherEmail), typeof(string))
    {
        Description = "The email address of the owner of the service."
    };
infra.Add(publisherEmail);

ProvisioningParameter publisherName =
    new(nameof(publisherName), typeof(string))
    {
        Description = "The name of the owner of the service."
    };
infra.Add(publisherName);

ApiManagementService apiService =
    new(nameof(apiService), ApiManagementService.ResourceVersions.V2024_05_01)
    {
        Sku = new ApiManagementServiceSkuProperties
        {
            Name = ApiManagementServiceSkuType.Developer,
            Capacity = 1
        },
        PublisherEmail = publisherEmail,
        PublisherName = publisherName,
        Identity = new ManagedServiceIdentity
        {
            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
        }
    };
infra.Add(apiService);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = apiService.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = apiService.Id });
```

### Create an API Management Service with API and Product

This example demonstrates a more advanced setup with an API and a product.

```C# Snippet:ApiManagementWithApi
Infrastructure infra = new();

ProvisioningParameter publisherEmail =
    new(nameof(publisherEmail), typeof(string))
    {
        Description = "The email address of the owner of the service."
    };
infra.Add(publisherEmail);

ProvisioningParameter publisherName =
    new(nameof(publisherName), typeof(string))
    {
        Description = "The name of the owner of the service."
    };
infra.Add(publisherName);

ApiManagementService apiService =
    new(nameof(apiService), ApiManagementService.ResourceVersions.V2024_05_01)
    {
        Sku = new ApiManagementServiceSkuProperties
        {
            Name = ApiManagementServiceSkuType.Developer,
            Capacity = 1
        },
        PublisherEmail = publisherEmail,
        PublisherName = publisherName
    };
infra.Add(apiService);

ApiManagementApi exampleApi =
    new("exampleApi", ApiManagementApi.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "Example API Name",
        Description = "Description for example API",
        Path = "exampleapipath",
        Protocols = { ApiOperationInvokableProtocol.Https }
    };
infra.Add(exampleApi);

ApiManagementProduct exampleProduct =
    new("exampleProduct", ApiManagementProduct.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "Example Product Name",
        Description = "Description for example product",
        IsSubscriptionRequired = true,
        IsApprovalRequired = false,
        SubscriptionsLimit = 1,
        State = ApiManagementProductState.Published
    };
infra.Add(exampleProduct);

infra.Add(new ProvisioningOutput("name", typeof(string)) { Value = apiService.Name });
infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = apiService.Id });
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
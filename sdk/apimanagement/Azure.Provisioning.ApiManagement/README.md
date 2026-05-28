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

ProvisioningParameter tenantPolicy =
    new(nameof(tenantPolicy), typeof(string)) { Description = "Tenant policy XML." };
infra.Add(tenantPolicy);

ProvisioningParameter apiPolicy =
    new(nameof(apiPolicy), typeof(string)) { Description = "API policy XML." };
infra.Add(apiPolicy);

ProvisioningParameter operationPolicy =
    new(nameof(operationPolicy), typeof(string)) { Description = "Operation policy XML." };
infra.Add(operationPolicy);

ProvisioningParameter productPolicy =
    new(nameof(productPolicy), typeof(string)) { Description = "Product policy XML." };
infra.Add(productPolicy);

// Service
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

// Tenant policy
ApiManagementPolicy tenantPolicyResource =
    new("tenantPolicyResource", ApiManagementPolicy.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        Value = tenantPolicy
    };
infra.Add(tenantPolicyResource);

// API
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

// Operations
ApiOperation exampleOperationDelete =
    new("exampleOperationDelete", ApiOperation.ResourceVersions.V2024_05_01)
    {
        Parent = exampleApi,
        DisplayName = "DELETE resource",
        Method = "DELETE",
        UriTemplate = "/resource",
        Description = "A demonstration of a DELETE call"
    };
infra.Add(exampleOperationDelete);

ApiOperation exampleOperationGet =
    new("exampleOperationGet", ApiOperation.ResourceVersions.V2024_05_01)
    {
        Parent = exampleApi,
        DisplayName = "GET resource",
        Method = "GET",
        UriTemplate = "/resource",
        Description = "A demonstration of a GET call"
    };
infra.Add(exampleOperationGet);

// Operation policy
ApiOperationPolicy exampleOperationGetPolicy =
    new("exampleOperationGetPolicy", ApiOperationPolicy.ResourceVersions.V2024_05_01)
    {
        Parent = exampleOperationGet,
        Value = operationPolicy
    };
infra.Add(exampleOperationGetPolicy);

// API with policy
ApiManagementApi exampleApiWithPolicy =
    new("exampleApiWithPolicy", ApiManagementApi.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "Example API Name with Policy",
        Description = "Description for example API with policy",
        Path = "exampleapiwithpolicypath",
        Protocols = { ApiOperationInvokableProtocol.Https }
    };
infra.Add(exampleApiWithPolicy);

ApiPolicy exampleApiWithPolicyPolicy =
    new("exampleApiWithPolicyPolicy", ApiPolicy.ResourceVersions.V2024_05_01)
    {
        Parent = exampleApiWithPolicy,
        Value = apiPolicy
    };
infra.Add(exampleApiWithPolicyPolicy);

// Product with policy
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

ApiManagementProductPolicy exampleProductPolicy =
    new("exampleProductPolicy", ApiManagementProductPolicy.ResourceVersions.V2024_05_01)
    {
        Parent = exampleProduct,
        Value = productPolicy
    };
infra.Add(exampleProductPolicy);

// Users
ApiManagementUser exampleUser1 =
    new("exampleUser1", ApiManagementUser.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        FirstName = "ExampleFirstName1",
        LastName = "ExampleLastName1",
        Email = "examplefirst1@example.com",
        State = ApiManagementUserState.Active,
        Note = "note for example user 1"
    };
infra.Add(exampleUser1);

ApiManagementUser exampleUser2 =
    new("exampleUser2", ApiManagementUser.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        FirstName = "ExampleFirstName2",
        LastName = "ExampleLastName2",
        Email = "examplefirst2@example.com",
        State = ApiManagementUserState.Active,
        Note = "note for example user 2"
    };
infra.Add(exampleUser2);

// Named value
ApiManagementNamedValue exampleNamedValue =
    new("exampleNamedValue", ApiManagementNamedValue.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "propertyExampleName",
        Value = "propertyExampleValue",
        Tags = { "exampleTag" }
    };
infra.Add(exampleNamedValue);

// Group
ApiManagementGroup exampleGroup =
    new("exampleGroup", ApiManagementGroup.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "Example Group Name",
        Description = "Example group description"
    };
infra.Add(exampleGroup);

// OpenId Connect provider
ApiManagementOpenIdConnectProvider exampleOpenIdConnectProvider =
    new("exampleOpenIdConnectProvider", ApiManagementOpenIdConnectProvider.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        DisplayName = "exampleOpenIdConnectProviderName",
        Description = "Description for example OpenId Connect provider",
        MetadataEndpoint = "https://example-openIdConnect-url.net",
        ClientId = "exampleClientId"
    };
infra.Add(exampleOpenIdConnectProvider);

// Logger
ApiManagementLogger exampleLogger =
    new("exampleLogger", ApiManagementLogger.ResourceVersions.V2024_05_01)
    {
        Parent = apiService,
        LoggerType = LoggerType.AzureEventHub,
        Description = "Description for example logger"
    };
infra.Add(exampleLogger);

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
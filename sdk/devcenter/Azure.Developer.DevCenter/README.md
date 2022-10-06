# Azure DevCenter client library for .NET

The DevCenter client library provides access to manage resources for Microsoft Dev Box and Azure Deployment Environments. This SDK enables managing developer machines and environments in Azure.

Use the client library for [Azure DevCenter] to:
> Create, access, manage, and delete Dev Box resources
> Create, deploy, manage, and delete Environment resources

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/devcenter/Azure.Developer.DevCenter/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Developer.DevCenter) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://docs.microsoft.com/azure)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.DevCenter --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.

> You must have [configured](https://learn.microsoft.com/azure/dev-box/quickstart-configure-dev-box-service) a DevCenter, Project, Network Connection, Dev Box Definition, and Pool before you can create Dev Boxes 

> You must have configured a DevCenter, Project, Catalog, and Environment Type before you can create Environments

### Authenticate the client

You can use standard Azure Active Directory [Token Credential authentication](https://learn.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet) to access the client. The identity interacting with all resources must have a minimum of Read access on the Project resources it is interacting with. The identity managing Dev Boxes must have the [DevCenter Project Admin](https://learn.microsoft.com/azure/dev-box/how-to-project-admin) or [DevCenter Dev Box User](https://learn.microsoft.com/azure/dev-box/how-to-dev-box-user) roles for Dev Box scenarios. These roles can be assigned directly to the project, or inherited from a broader scope (such as the resource group or subscription).

## Key concepts

The library uses three main clients. The `DevCenterClient` provides access to common APIs for interacting with projects and listing resources across projects.
The `DevBoxesClient` is scoped to a single project, and provides access to Dev Box resources such as Pools and Dev Boxes.
The `EnvironmentsClient` is scoped to a single project, and provides access to Environments resources such as Catalog Items, Environment Types, and Environments.

Use these clients to interact with DevCenter resources based on your scenario.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/devcenter/Azure.Developer.DevCenter/samples).

### Dev Box Usage

```C# Snippet:Azure_DevCenter_DevBox_Scenario
```

### Environment Usage

```C# Snippet:Azure_DevCenter_Environment_Scenario
```

## Troubleshooting

Errors may occur during Dev Box provisioning due to problems with other resources or your Azure configuration. You can view the operation error or the `errorDetails` property on the Dev Box if provisioning fails, which will show more information about the problem and how to resolve it.
Ensure that your Pool, Network Connection, and Dev Box Definition resources are all in a healthy state before attempting to create a Dev Box. Problems with their configurations will prevent successful creation of your Dev Box.

Errors may occur during Environment deployment due to problems with your template, parameters, or the configuration of other resources. You can view the operation error, which will provide more information about the problem and how to resolve it.
Ensure that your Project Environment Type's identity has the correct permissions to the target subscription, that you are passing all parameters which are required by the template, and that all parameters are valid.

## Contributing

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/devcenter/Azure.Developer.DevCenter/README.png)

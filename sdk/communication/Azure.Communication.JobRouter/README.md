# Azure Communication JobRouter client library for .NET

This package contains a C# SDK for Azure Communication Services for JobRouter.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]


## Getting started

### Install the package
Install the Azure Communication JobRouter client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Chat 
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Authenticate the client

### Using statements
```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements

```

### Create a JobRouter Client

This will allow you to interact with the JobRouter Service
```C#
var routerClient new RouterClient("<Communication Service Connection String>");
```


## Key concepts


### Distribution Policy

```c# Snippet:Azure_Communication_JobRouter_Tests_Samples_DistributionPolicy
```

### Queue

```c# Snippet:Azure_Communication_JobRouter_Tests_Samples_Queue
```

### Job

```c# Snippet:Azure_Communication_JobRouter_Tests_Samples_Job
```

### Worker

```c# Snippet:Azure_Communication_JobRouter_Tests_Samples_Worker
```

### Offer

```c# Snippet:Azure_Communication_JobRouter_Tests_Samples_QueryWorker
```

## Next steps
[Read more about Chat in Azure Communication Services][nextsteps]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[nuget]: https://www.nuget.org/
[netstandars2mappings]:https://github.com/dotnet/standard/blob/master/docs/versions.md
[useraccesstokens]:https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[nextsteps]:https://docs.microsoft.com/en-us/azure/communication-services/concepts/router/concepts
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.JobRouter/src
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[package]: https://www.nuget.org/packages/Azure.Communication.JobRouter

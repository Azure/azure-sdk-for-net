# Azure Load Testing client library for .NET

Azure Load Testing provides client library in .NET to the user by which they can interact natively with Azure Load Testing service. Azure Load Testing is a fully managed load-testing service that enables you to generate high-scale load. The service simulates traffic for your applications, regardless of where they're hosted. Developers, testers, and quality assurance (QA) engineers can use it to optimize application performance, scalability, or capacity.

[Source code][source_code] | [Package (NuGet)][nuget_package] | [API reference documentation][sdk_api_reference] | [Product documentation](https://learn.microsoft.com/azure/load-testing/)


## Documentation

Various documentation is available to help you get started

- [Source code][source_code]
- [REST API reference documentation](https://learn.microsoft.com/rest/api/loadtesting/)
- [Product Documentation](https://azure.microsoft.com/services/load-testing/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Developer.LoadTesting
```

### Prerequisites

You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Load Test Service Resource](https://learn.microsoft.com/azure/load-testing/) to use this package. You can create the resource via the [Azure Portal](https://portal.azure.com), or the [Azure CLI](https://learn.microsoft.com/cli/azure).


### Authenticate the client

To use an [Azure Active Directory (AAD) token credential](https://learn.microsoft.com/aspnet/core/security/authentication/identity),
provide an instance of the desired credential type obtained from the
[azure-identity][azure_identity_credentials] library.

To authenticate with AAD, you must first use [nuget][nuget] install [`azure-identity`][azure_identity_nuget]

After setup, you can choose which type of [credential][azure_identity_credentials] from Azure.Identity to use.

As an example, sign in via the Azure CLI `az login` command and [DefaultAzureCredential](https://learn.microsoft.com/python/api/azure-identity/azure.identity.defaultazurecredential?view=azure-python) will authenticate as that user.

Use the returned token credential to authenticate the client.

## Key concepts

The following components make up the Azure Load Testing service. The Azure Load Test client library for C# allows you to interact with each of these components through the use of clients. There are two clients:

- `LoadTestAdministrationClient`

- `LoadTestRunClient`

These clients are used for managing and using different components of the service. For each method in both of these sub-clients there is a corresponding Async method in the same class, with the same implementation however enabling async functionalities. For example, if there is a method, `CreateOrUpdateTest` as a part of `LoadTestAdministrationClient` then there always exists one more method `CreateOrUpdateTestAsync` in the same client class.

### Load Test Administration Client

The `LoadTestAdministrationClient` client is used to administer and configure the load tests, app components and metrics.

#### Test

A test specifies the test script, and configuration settings for running a load test. You can create one or more tests in an Azure Load Testing resource.

#### App Component

When you run a load test for an Azure-hosted application, you can monitor resource metrics for the different Azure application components (server-side metrics). While the load test runs, and after completion of the test, you can monitor and analyze the resource metrics in the Azure Load Testing dashboard.

#### Metrics

During a load test, Azure Load Testing collects metrics about the test execution. There are two types of metrics:

1. Client-side metrics give you details reported by the test engine. These metrics include the number of virtual users, the request response time, the number of failed requests, or the number of requests per second.

2. Server-side metrics are available for Azure-hosted applications and provide information about your Azure application components. Metrics can be for the number of database reads, the type of HTTP responses, or container resource consumption.

### Test Run Client

The `LoadTestRunClient` client is used to start and stop test runs corresponding to a load test. A test run represents one execution of a load test. It collects the logs associated with running the test script, the load test configuration, the list of app components to monitor, and the results of the test.

### Data-Plane Endpoint

Data-plane of Azure Load Testing resources is addressable using the following URL format:

`00000000-0000-0000-0000-000000000000.aaa.cnt-prod.loadtesting.azure.com`

The first GUID `00000000-0000-0000-0000-000000000000` is the unique identifier used for accessing the Azure Load Testing resource. This is followed by  `aaa` which is the Azure region of the resource.

The data-plane endpoint is obtained from Control Plane APIs. To obtain the data-plane endpoint for your resource, follow [this documentation][obtaining_data_plane_uri].

**Example:** `1234abcd-12ab-12ab-12ab-123456abcdef.eastus.cnt-prod.loadtesting.azure.com`

In the above example, `eastus` represents the Azure region `East US`.

### Thread Safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->


## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting/samples).

## Troubleshooting

### Setting up console logging

The simplest way to see the logs is to enable the console logging. To create an Azure SDK log listener that outputs messages to the console, use `AzureEventSourceListener.CreateConsoleLogger` method.

```cs
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][azure_core_diagnostics].

## Next steps

For more extensive documentation on Azure Load Testing, see the [Azure Load Testing documentation][product_documentation].

Get started with our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting/samples) that cover common scenarios.

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) file for information about how to onboard and contribute to the overall Azure SDK ecosystem.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.


<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/src
[nuget_package]: https://www.nuget.org/packages/Azure.Developer.LoadTesting
[sdk_api_reference]: https://azure.github.io/azure-sdk-for-net/loadtesting.html
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cla]: https://cla.microsoft.com
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
[authenticate_with_token]: https://learn.microsoft.com/aspnet/core/security/authentication/identity
[azure_identity_credentials]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials
[azure_identity_nuget]: https://www.nuget.org/packages/Azure.Identity/1.7.0
[client_secret_credential]: https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
[nuget]: https://www.nuget.org/
[azure_sub]: https://azure.microsoft.com/free/
[api_reference_doc]: https://learn.microsoft.com/rest/api/loadtesting/
[product_documentation]: https://azure.microsoft.com/services/load-testing/
[obtaining_data_plane_uri]: https://learn.microsoft.com/rest/api/loadtesting/data-plane-uri
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md

# Azure Load Testing client library for .NET
Azure Load Testing provides client library in .NET to the user by which they can interact natively with Azure Load Testing service. Azure Load Testing is a fully managed load-testing service that enables you to generate high-scale load. The service simulates traffic for your applications, regardless of where they're hosted. Developers, testers, and quality assurance (QA) engineers can use it to optimize application performance, scalability, or capacity.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/src) | [Package (NuGet)](https://www.nuget.org/packages?q=Azure.Developer.Loadtesting) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/azure/load-testing/)


## Documentation

Various documentation is available to help you get started

<!-- - [Source code][source_code] -->
- [API reference documentation](https://docs.microsoft.com/rest/api/loadtesting/)
- [Product Documentation](https://azure.microsoft.com/services/load-testing/)

## Getting started


### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.LoadTesting
```

### Prerequisites
You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Load Test Service Resource](https://learn.microsoft.com/azure/load-testing/). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.


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

These clients are used for managing and using different components of the service. For each method in both of these sub-clients there is a corresponding Async method in the same class, with the same implementation however enabling async functionalities. For example, if there is a method, `CreateOrUpdateTest` as a part of `LoadTestAdministrationClient` then there always exists one more function `CreateOrUpdateTestAsync` in the same client class.

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

The `LoadTestRunClient` client is used to start and stop test runs corresponding to a load test. A test run represents one execution of a load test. It collects the logs associated with running the Apache JMeter script, the load test YAML configuration, the list of app components to monitor, and the results of the test.

### Data-Plane Endpoint

Data-plane of Azure Load Testing resources is addressable using the following URL format:

`00000000-0000-0000-0000-000000000000.aaa.cnt-prod.loadtesting.azure.com`

The first GUID `00000000-0000-0000-0000-000000000000` is the unique identifier used for accessing the Azure Load Testing resource. This is followed by  `aaa` which is the Azure region of the resource.

The data-plane endpoint is obtained from Control Plane APIs.

**Example:** `1234abcd-12ab-12ab-12ab-123456abcdef.eus.cnt-prod.loadtesting.azure.com`

In the above example, `eus` represents the Azure region `East US`.
## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting/samples).


## Troubleshooting
More about it is coming soon...


### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

## Next steps

Get started with our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting/samples).

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

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

<!-- LINKS -->
<!-- LINKS -->
<!-- [source_code]: https://github.com/Azure/azure-sdk-for-java/blob/main/sdk/loadtesting/azure-developer-loadtesting/src -->
<!-- [sample_code]: https://github.com/Azure/azure-sdk-for-java/blob/main/sdk/loadtesting/azure-developer-loadtesting/src/samples -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[authenticate_with_token]: https://learn.microsoft.com/aspnet/core/security/authentication/identity
[azure_identity_credentials]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials
[azure_identity_nuget]: https://www.nuget.org/packages/Azure.Identity/1.7.0
[client_secret_credential]: https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
[nuget]: https://www.nuget.org/
[azure_sub]: https://azure.microsoft.com/free/
[api_reference_doc]: https://docs.microsoft.com/rest/api/loadtesting/
[product_documentation]: https://azure.microsoft.com/services/load-testing/

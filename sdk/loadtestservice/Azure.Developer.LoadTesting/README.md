# Azure Load Testing client library for .NET
Azure Load Testing provides client library in .NET to the user by which they can interact natively with Azure Load Testing service. Azure Load Testing is a fully managed load-testing service that enables you to generate high-scale load. The service simulates traffic for your applications, regardless of where they're hosted. Developers, testers, and quality assurance (QA) engineers can use it to optimize application performance, scalability, or capacity.

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/loadtestservice/Azure.Developer.LoadTesting/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.Developer.LoadTesting) | [API reference documentation](https://azure.github.io/azure-sdk-for-net) | [Product documentation](https://learn.microsoft.com/en-in/azure/load-testing/)

## Getting started


### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Developer.LoadTesting --prerelease
```

### Prerequisites
You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Load Test Service Resource](https://learn.microsoft.com/en-in/azure/load-testing/). In order to take advantage of the C# 8.0 syntax, it is recommended that you compile using the [.NET Core SDK](https://dotnet.microsoft.com/download) 3.0 or higher with a [language version](https://docs.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `latest`.  It is also possible to compile with the .NET Core SDK 2.1.x using a language version of `preview`.


### Authenticate the client

To use an [Azure Active Directory (AAD) token credential][authenticate_with_token],
provide an instance of the desired credential type obtained from the
[azure-identity][azure_identity_credentials] library.

To authenticate with AAD, you must first use [nuget][nuget] install [`azure-identity`][azure_identity_nuget]

After setup, you can choose which type of [credential][azure_identity_credentials] from Azure.Identity to use.

As an example, sign in via the Azure CLI `az login` command and [DefaultAzureCredential](https://learn.microsoft.com/python/api/azure-identity/azure.identity.defaultazurecredential?view=azure-python) will authenticate as that user.

Use the returned token credential to authenticate the client.

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting/samples).


## Key concepts

The following components make up the Azure Load Testing Service. The Azure Load Test client library for Python allows you to interact with each of these components through the use of a dedicated client object.

### Load testing resource
The Load testing resource is the top-level resource for your load-testing activities. This resource provides a centralized place to view and manage load tests, test results, and related artifacts. A load testing resource contains zero or more load tests.

### Test
A test specifies the test script, and configuration settings for running a load test. You can create one or more tests in an Azure Load Testing resource.

### Test Engine
A test engine is computing infrastructure that runs the Apache JMeter test script. You can scale out your load test by configuring the number of test engines. The test script runs in parallel across the specified number of test engines.

### Test Run
A test run represents one execution of a load test. It collects the logs associated with running the Apache JMeter script, the load test YAML configuration, the list of app components to monitor, and the results of the test.

### App Component
When you run a load test for an Azure-hosted application, you can monitor resource metrics for the different Azure application components (server-side metrics). While the load test runs, and after completion of the test, you can monitor and analyze the resource metrics in the Azure Load Testing dashboard.

### Metrics
During a load test, Azure Load Testing collects metrics about the test execution. There are two types of metrics:

1. Client-side metrics give you details reported by the test engine. These metrics include the number of virtual users, the request response time, the number of failed requests, or the number of requests per second. 

2. Server-side metrics are available for Azure-hosted applications and provide information about your Azure application components. Metrics can be for the number of database reads, the type of HTTP responses, or container resource consumption.

## Troubleshooting
More about it is coming soon...


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


## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/loadtestservice/Azure.Developer.LoadTesting/README.png)
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[authenticate_with_token]: https://learn.microsoft.com/en-us/azure/developer/java/sdk/identity-user-auth
[azure_identity_credentials]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials
[azure_identity_nuget]: https://www.nuget.org/packages/Azure.Identity/1.7.0
[client_secret_credential]: https://learn.microsoft.com/en-us/dotnet/api/azure.identity.clientsecretcredential?view=azure-dotnet-preview
[nuget]: https://www.nuget.org/
[azure_sub]: https://azure.microsoft.com/free/
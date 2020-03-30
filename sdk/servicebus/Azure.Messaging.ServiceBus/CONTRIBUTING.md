# Contributing

Thank you for your interest in contributing to the Service Bus client library.  As an open source effort, we're excited to welcome feedback and contributions from the community.  A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aopen+is%3Aissue+label%3AClient+label%3A%22Service+Bus%22).

Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use any contribution that you make. For details, visit https://cla.microsoft.com.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Getting started

Before working on a contribution, it would be beneficial to familiarize yourself with the process and guidelines used for the Azure SDKs so that your submission is consistent with the project standards and is ready to be accepted with fewer changes requested.  In particular, it is recommended to review:

  - [Azure SDK README](https://github.com/Azure/azure-sdk), to learn more about the overall project and processes used.
  - [Azure SDK Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md), for information about how to onboard and contribute to the overall Azure SDK ecosystem.
  - [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/general_introduction.html), to understand the general guidelines for the Azure SDK across all languages and platforms.
  - [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html), to understand the guidelines specific to the Azure SDK for .NET.

## Development environment setup

### Running tests

The Service Bus client library tests may be executed using the `dotnet` CLI, or the test runner of your choice - such as Visual Studio or Visual Studio Code.  For those developers using Visual Studio, it is safe to use the Live Unit Testing feature, as any tests with external dependencies have been marked to be excluded.

Tests in the Service Bus client library are split into two categories:

- **Unit tests** have no special considerations; these are self-contained and execute locally without any reliance on external resources.  Unit tests are considered the default test type in the Service Bus client library and, thus, have no explicit category trait attached to them.

- **Integration tests** have dependencies on live Azure resources and require setting up your development environment prior to running.  Known in the Azure SDK project commonly as "Live" tests, these tests are decorated with a category trait of "Live".  To run them, an Azure resource group and Azure Service Principal with "contributor" rights to that resource group are required.  For each test run, the Live tests will use the service principal to dynamically create a Service Bus namespace within the resource group and remove it once the test run is complete.

The Live tests read information from the following environment variables:

`SERVICE_BUS_RESOURCEGROUP`  
 The name of the Azure resource group that contains the Service Bus namespace

`SERVICE_BUS_SUBSCRIPTION`  
 The identifier (GUID) of the Azure subscription to which the service principal belongs

`SERVICE_BUS_TENANT`  
 The identifier (GUID) of the Azure Active Directory tenant that contains the service principal

`SERVICE_BUS_CLIENT`  
 The identifier (GUID) of the Azure Active Directory application that is associated with the service principal

`SERVICE_BUS_SECRET`  
 The client secret (password) of the Azure Active Directory application that is associated with the service principal

### Samples

In order to run the samples, you'll need a Service Bus namespace and a queue. For the session samples, you will need a session-enabled queue.

## Development history

For additional insight and context, the development, release, and issue history for the Azure Service Bus client library is available in read-only form, in its previous location, the [Azure Service Bus .NET repository](https://github.com/Azure/azure-service-bus-dotnet).

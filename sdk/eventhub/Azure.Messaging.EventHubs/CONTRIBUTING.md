# Contributing

Thank you for your interest in contributing to the Event Hubs client library.  As an open source effort, we're excited to welcome feedback and contributions from the community.  A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aopen+is%3Aissue+label%3AClient+label%3A%22Event+Hubs%22).

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

The Event Hubs client library tests may be executed using the `dotnet` CLI, or the test runner of your choice - such as Visual Studio or Visual Studio Code.  For those developers using Visual Studio, it is safe to use the Live Unit Testing feature, as any tests with external dependencies have been marked to be excluded.

Tests in the Event Hubs client library are split into two categories:

- **Unit tests** have no special considerations; these are self-contained and execute locally without any reliance on external resources.  Unit tests are considered the default test type in the Event Hubs client library and, thus, have no explicit category trait attached to them.

- **Integration tests** have dependencies on live Azure resources and require setting up your development environment prior to running.  Known in the Azure SDK project commonly as "Live" tests, these tests are decorated with a category trait of "Live".  To run them, an Azure resource group and Azure Service Principal with "contributor" rights to that resource group are required.  For each test run, the Live tests will use the service principal to dynamically create an Event Hubs namespace within the resource group and remove it once the test run is complete.

The Live tests read information from the following environment variables:

`EVENT_HUBS_RESOURCEGROUP`  
 The name of the Azure resource group that contains the Event Hubs namespace

`EVENT_HUBS_SUBSCRIPTION`  
 The identifier (GUID) of the Azure subscription to which the service principal belongs

`EVENT_HUBS_TENANT`  
 The identifier (GUID) of the Azure Active Directory tenant that contains the service principal

`EVENT_HUBS_CLIENT`  
 The identifier (GUID) of the Azure Active Directory application that is associated with the service principal

`EVENT_HUBS_SECRET`  
 The client secret (password) of the Azure Active Directory application that is associated with the service principal

To make setting up your environment easier, a [PowerShell script](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/live-tests-azure-setup.ps1) is included in the repository and will create and/or configure the needed Azure resources.  To use this script, open a PowerShell instance and login to your Azure account using `Login-AzAccount`, then execute the script.  You will need to provide some information, after which the script will configure the Azure resources and then output the set of environment variables with the correct values for running tests.

The simplest way to get started is to execute the script with your subscription name and then follow the prompts:

```powershell
./live-tests-azure-setup -SubscriptionName "<< YOUR SUBSCRIPTION NAME >>"
```

Help for the full set of parameters and additional information is available by specifying the `-Help` flag.

```powershell
./live-tests-azure-setup -Help
```

### Samples

In order to run the samples interactively, you'll need an Event Hubs namespace and an Event Hub with at least one partition.  Each sample will take a connection string and Event Hub name as parameters when executing, which can either be supplied directly as part of development or can be specified to the console application host in the `Samples` project, either using command line arguments or entered in response to prompts.

## Development history

For additional insight and context, the development, release, and issue history for the Azure Event Hubs client library is available in read-only form, in its previous location, the [Azure Event Hubs .NET repository](https://github.com/Azure/azure-event-hubs-dotnet).
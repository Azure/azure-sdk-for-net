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

- `EVENTHUB_RESOURCE_GROUP`  
 The name of the Azure resource group that contains the Event Hubs namespace

- `EVENTHUB_SUBSCRIPTION_ID`  
 The identifier (GUID) of the Azure subscription to which the service principal belongs

- `EVENTHUB_TENANT_ID`  
 The identifier (GUID) of the Azure Active Directory tenant that contains the service principal

- `EVENTHUB_CLIENT_ID`  
 The identifier (GUID) of the Azure Active Directory application that is associated with the service principal

- `EVENTHUB_CLIENT_SECRET`  
 The client secret (password) of the Azure Active Directory application that is associated with the service principal
 
- `EVENTHUB_PER_TEST_LIMIT_MINUTES`
The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk for being hung.  If not provided, a default suitable for most local development environment runs is assumed.

- `EVENTHUB_NAMESPACE_CONNECTION_STRING` _**(optional)**_  
  The connection string to an existing Event Hubs namespace to use for testing.  If specified, this namespace will be used as the basis for the test run, with Event Hub instances dynamically managed by the tests.  When the run is complete, the namespace will be left in the state that it was in before the test run took place.  If not specified, a new namespace will be dynamically created for the test run and removed at the end of the run.
  
- `EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING` _**(optional)**_  
  The connection string to an existing Blob Storage account to use for `EventProcessorClient` testing.  If specified, this account will be used as the basis for the test run, with container instances dynamically managed by the tests.  When the run is complete, the account will be left in the state that it was in before the test run took place.  If not specified, a new storage account will be dynamically created for the test run and removed at the end of the run.
  
- `AZURE_AUTHORITY_HOST` _**(optional)**_  
  The name of the Azure Authority to use for authenticating resource management operations.  The default for this is appropriate for use with the Azure public cloud; when testing in other cloud instances, this may be needed.
  
- `SERVICE_MANAGEMENT_URL` _**(optional)**_  
  The URL of the endpoint responsible for service management operations in Azure.  The default for this is appropriate for use with the Azure public cloud; when testing in other cloud instances, this may be needed.
  
- `RESOURCE_MANAGER_URL` _**(optional)**_  
  The URL of the endpoint responsible for resource management operations in Azure.  The default for this is appropriate for use with the Azure public cloud; when testing in other cloud instances, this may be needed.

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

### Azure Identity Samples

In order to run [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity) samples interactively, you'll also need to have a service principal set up on the Azure Active Directory mapped to your subscription. The service principal will need to have the role `Azure Event Hubs Data Owner` associated with your Event Hubs namespace. 

A [PowerShell script](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/eventhub/Azure.Messaging.EventHubs/assets/identity-samples-azure-setup.ps1) can be used to create the service principal.

To run the script:

```powershell
./identity-tests-azure-setup -SubscriptionName "<< YOUR SUBSCRIPTION NAME >>"
```

Help for the full set of parameters and additional information is available by specifying the `-Help` flag.

```powershell
./identity-tests-azure-setup -Help
```

## Development history

For additional insight and context, the development, release, and issue history for the Azure Event Hubs client library is available in read-only form, in its previous location, the [Azure Event Hubs .NET repository](https://github.com/Azure/azure-event-hubs-dotnet).
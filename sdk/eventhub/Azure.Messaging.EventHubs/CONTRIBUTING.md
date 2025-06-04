# Contributing

Thank you for your interest in contributing to the Event Hubs client library.  As an open source effort, we're excited to welcome feedback and contributions from the community.  A great first step in sharing your thoughts and understanding where help is needed would be to take a look at the [open issues](https://github.com/Azure/azure-sdk-for-net/issues?q=is%3Aopen+is%3Aissue+label%3AClient+label%3A%22Event+Hubs%22).

Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use any contribution that you make. For details, visit https://cla.microsoft.com.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Getting started

Before working on a contribution, it would be beneficial to familiarize yourself with the process and guidelines used for the Azure SDKs so that your submission is consistent with the project standards and is ready to be accepted with fewer changes requested.  In particular, it is recommended to review:

  - [Azure SDK README](https://github.com/Azure/azure-sdk), to learn more about the overall project and processes used.
  - [Azure SDK Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md), for information about how to onboard and contribute to the overall Azure SDK ecosystem.
  - [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/general_introduction.html), to understand the general guidelines for the Azure SDK across all languages and platforms.
  - [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html), to understand the guidelines specific to the Azure SDK for .NET.

## Running tests

The Event Hubs client library tests may be executed using the `dotnet` CLI, or the test runner of your choice - such as Visual Studio or Visual Studio Code.  For those developers using Visual Studio, it is safe to use the Live Unit Testing feature, as any tests with external dependencies have been marked to be excluded.

Tests in the Event Hubs client library are split into two categories:

- **Unit tests** have no special considerations; these are self-contained and execute locally without any reliance on external resources.  Unit tests are considered the default test type in the Event Hubs client library and, thus, have no explicit category trait attached to them.

- **Integration tests** have dependencies on live Azure resources and require setting up your development environment prior to running.  Known in the Azure SDK project commonly as "Live" tests, these tests are decorated with a category trait of "Live".  

## Development environment setup

### Prerequisites

- **Azure Subscription:**  To use Azure services, including Azure Event Hubs, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).

- **.NET SDK:** The Azure Event Hubs requires the [.NET SDK](https://dotnet.microsoft.com/download/dotnet/7.0) 7.0.100. (or a higher version in the 7.0.x band) with a [language version](https://learn.microsoft.com/dotnet/csharp/language-reference/configure-language-version#override-a-default) of `11.0`.  Visual Studio users will need to use Visual Studio 2022 or later.  Visual Studio 2022, including the free Community edition, can be downloaded [here](https://visualstudio.microsoft.com). 

- **PowerShell:** To use the Azure SDK automation for development tools and setting up your testing environment, PowerShell Core version 7.0 or greater is needed.  This version is available cross-platform and can be installed from the [PowerShell Core repository](https://github.com/PowerShell/PowerShell/blob/master/README.md).

- **Azure PowerShell Module:** For PowerShell to interact with Azure, the [Azure Az module](https://learn.microsoft.com/powershell/azure/install-az-ps) is needed.  

### Creating Azure resources for tests

The required Azure resources for testing the Event Hubs client library are defined in the [test resources ARM template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/test-resources.json).  In addition to these resources, a Azure Active Directory service principal is needed.

The recommended approach is to use the Azure SDK [Test Resources](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/README.md) tooling as described in the next section.  For those would prefer not to automate resource creation, the steps needed for [manual creation](#manually-creating-resources) are outlined later in this guide.

#### Automating creation with `New-TestResources.ps1`

`New-TestResources.ps1` is a PowerShell script dedicated to creating the Azure resources needed for testing the Azure SDK in a uniform and consistent way; this approach will for Event Hubs and can also be used with any of the client libraries in this repository.

The following PowerShell commands will make use of `New-TestResources.ps1` to create the Event Hubs test resources, including the Azure Active Directory service principal.  The script uses the `BaseName` as a prefix when naming the service principal and other resources.  The principal created will be granted the "Owner" role for the new resource group but will have no access to other resources in the subscription. 

```powershell
Connect-AzAccount -Subscription '<< AZURE SUBSCRIPTION ID >>'

<repository-root>/eng/common/TestResources/New-TestResources.ps1 `
    -BaseName '<< MEMORABLE VALUE (example: azsdk) >>' `
    -ServiceDirectory 'eventhub' `
    -SubscriptionId '<< AZURE SUBSCRIPTION ID >>' `
    -ResourceGroupName '<< NAME FOR RESOURCE GROUP >>' `
    -Location '<< AZURE REGION CODE (example: eastus) >>' `
    -ArmTemplateParameters @{ perTestExecutionLimitMinutes = '5' }
```

The `ResourceGroupName` and `Location` parameters are optional; if not provided, the `BaseName` will be used to generate the name of the resource group and will be located in `westus2`.  For a list of the Azure locations valid for Event Hubs, the following command can be used:

```powershell
Get-AzLocation `
    | Where { $_.Providers.Contains("Microsoft.EventHub") } `
    | Select DisplayName, Location `
    | Format-Table
```

If you prefer to use an existing service principal with the Live tests, the following set of parameters will instruct the script to create a new resource group for the tests and assign the "Owner" role for the resource group to the specified `TestAppliaticationId`.

```powershell
Connect-AzAccount -Subscription '<< AZURE SUBSCRIPTION ID >>'

<repository-root>/eng/common/TestResources/New-TestResources.ps1 `
    -BaseName '<< MEMORABLE VALUE (example: azsdk) >>' `
    -ServiceDirectory 'eventhub' `
    -SubscriptionId '<< AZURE SUBSCRIPTION ID >>' `
    -ResourceGroupName '<< NAME FOR RESOURCE GROUP >>' `
    -Location '<< AZURE REGION CODE (example: eastus) >>' `
    -TestApplicationId '<< APPLICATION ID OF THE AAD APPLICATION >>' `
    -TestApplicationSecret '<< APPLICATION SECRET OF THE AAD APPLICATION >>' `
    -ArmTemplateParameters @{ perTestExecutionLimitMinutes = '5' }`
```

The full set of options for `New-TestResources.ps1` can be found in the [New-TestResources.ps1 documentation](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/New-TestResources.ps1.md).

#### Configuring the environment

When the `New-TestResources.ps1` script completes, it will output a set of environment variables needed by the tests when executing.  On the Windows platform, the script will also emit an environment file read by the tests so that environment variables do not need to be explicitly set.  The environment file is encrypted using the .NET [Data Protection API (DAPI)](https://learn.microsoft.com/dotnet/standard/security/how-to-use-data-protection) and can be read only by the user account that executed the script.

For non-Windows platforms, these environment variables will need to be available prior to running the tests.  For more information on setting environment variables, please see [Azure SDK Live Test Resource Management](https://github.com/Azure/azure-sdk-tools/blob/main/eng/common/TestResources/README.md#on-the-desktop).

The Event Hubs Live tests read information from the following environment variables:

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
  The maximum duration, in minutes, that a single test is permitted to run before it is considered at-risk of not responding.  If not provided, a default suitable for most local development environment runs is assumed.

- `EVENTHUB_NAMESPACE_CONNECTION_STRING`  
  The connection string to an Event Hubs namespace to use for testing.  Tests will each create an ephemeral Event Hub instance in this namespace when executing, in order to ensure isolation.  When the run is complete, the namespace will be left in the state that it was in before the test run took place.
  
- `EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING`  
  The connection string to a Blob Storage account to use for `EventProcessorClient` testing.  Tests will each create an ephemeral container in this account when executing, in order to ensure isolation.  When the run is complete, the account will be left in the state that it was in before the test run took place.
 
 - `AZURE_AUTHORITY_HOST`  
  The URL of the Azure Authority to use for authenticating resource management operations.  For the Azure public cloud, this should be: https://login.microsoftonline.com/.  
  
    When testing in other cloud instances, the appropriate host will be needed.  See [National Clouds](https://learn.microsoft.com/azure/active-directory/develop/authentication-national-cloud) for more information.
 
- `SERVICE_MANAGEMENT_URL` _**(optional)**_  
  The URL of the endpoint responsible for service management operations in Azure.  The default for this is appropriate for use with the Azure public cloud; when testing in other cloud instances, specifying this value may be needed.
  
- `RESOURCE_MANAGER_URL` _**(optional)**_  
  The URL of the endpoint responsible for resource management operations in Azure.  The default for this is appropriate for use with the Azure public cloud; when testing in other cloud instances, specifying this value may be needed.
  
#### Manually creating resources

It is also possible to manually generate the test resources.  To do so:

1) Create a new resource group
1) Create a service principal or select an existing service principal to use with the tests
1) Ensure that your service principal is granted "Owner" or "Contributor" on the resource group
1) Deploy the [Event Hubs test resources ARM template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/eventhub/test-resources.json) to the resource group
1) Capture the output from the ARM template deployment and [configure the environment](#configuring-the-environment).

If you're using  Windows and would like to manually generate the environment file to avoid creating environment variables, you can do so by using DAPI to encrypt the ARM template output, writing it to `<repository-root>/sdk/eventhub/test-resources.json.env`, as demonstrated in the following snippet:

```csharp
using System.IO;
using System.Security.Cryptography;
using System.Text;

// NOTE: 
//    The Azure Public cloud is assumed; the URLs for the Authority Host, 
//    Resource Manager, and Service Management may need to be adjusted if 
//    testing in another cloud.

private string envVars = @"{
  ""EVENTHUB_RESOURCE_GROUP"":""<< RESOURCE GROUP NAME >>"",
  ""EVENTHUB_LOCATION"": ""<< AZURE REGION CODE (example: eastus) >>"",
  ""EVENTHUB_SUBSCRIPTION_ID"":""<< AZURE SUBSCRIPTION ID >>"",
  ""EVENTHUB_TENANT_ID"":""<< AZURE ACTIVE DIRECTORY TENANT ID >>"",
  ""EVENTHUB_CLIENT_ID"":""<< APPLICATION ID OF THE AAD APPLICATION >>"",
  ""EVENTHUB_CLIENT_SECRET"":""<< APPLICATION SECRET OF THE AAD APPLICATION >>"",
  ""EVENTHUB_NAMESPACE_CONNECTION_STRING"":""<< EVENT HUBS NAMESPACE CONNECTION STRING >>"",
  ""EVENTHUB_PROCESSOR_STORAGE_CONNECTION_STRING"":""<< BLOB STORAGE CONNECTION STRING >>"",
  ""AZURE_AUTHORITY_HOST"": ""https://login.microsoftonline.com/"",
  ""RESOURCE_MANAGER_URL"": ""https://management.azure.com/"",  
  ""SERVICE_MANAGEMENT_URL"": ""https://management.core.windows.net/""
}";

var bytes = Encoding.UTF8.GetBytes(envVars);
var protectedBytes = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);

using var stream = File.OpenWrite(@"<repository-root>/sdk/eventhub/test-resources.json.env");
using var writer = new BinaryWriter(stream);

writer.Write(protectedBytes);
writer.Flush();
```

## Development history

For additional insight and context, the development, release, and issue history for the Azure Event Hubs client library is available in read-only form, in its previous location, the [Azure Event Hubs .NET repository](https://github.com/Azure/azure-event-hubs-dotnet).
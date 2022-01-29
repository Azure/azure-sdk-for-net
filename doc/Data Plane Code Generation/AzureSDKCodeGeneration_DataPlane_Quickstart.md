# Azure SDK Code Geneneration Quickstart Tutorial (Data Plane)

The purpose of the Azure SDK is to provide a unified developer experience across Azure services. In this tutorial, we will walk through creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have a standardized API based on the  [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).

We will use the swagger file which contains a REST API definition based on [Azure REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md). We will use the swagger to generate SDK using [autorest.csharp](https://github.com/Azure/autorest.csharp).

**Learn more**: to understand more about Azure SDK Code Geneneration, see the [Azure SDK Code Geneneration docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

This tutorial has following sections:

- [Azure SDK Code Geneneration Quickstart Tutorial (Data Plane)](#azure-sdk-code-geneneration-quickstart-tutorial-data-plane)
  - [Prerequisites](#prerequisites)
  - [Setup your repo](#setup-your-repo)
  - [Create starter package](#create-starter-package)
  - [Add package ship requirements](#add-package-ship-requirements)
    - [Tests](#tests)
    - [Samples](#samples)
    - [Snippets](#snippets)
    - [README](#readme)
    - [Changelog](#changelog)
    - [Customize](#customize)

<!-- /TOC -->

## Prerequisites

- Install VS 2020 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
  - Install the **.NET Core cross-platform development** workloads in VisualStudio
- Install **.NET 6.0 SDK** for your specific platform. (or a higher version)
- Install **.NET core 3.1** for your specific platform.
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher.
- Install [NodeJS](https://nodejs.org/) (14.x.x).

## Setup your repo

- Fork and clone an [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repo. Follow the instructions in the [.NET CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/issues/12903) to fork and clone the `azure-sdk-for-net` repo.
- Create a branch to work in.

## Create starter package  

For this guide, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. The started project will be under `sdk\<servie name>\<package name>` directory of `azure-sdk-for-net` repo. The package will contain several folders and files (see following). Please refer to [sdk-directory-layout](https://github.com/Azure/azure-sdk/blob/main/docs/policies/repostructure.md#sdk-directory-layout) for detail information.

```text
sdk\<service name>\<package name>\README.md
sdk\<service name>\<package name>\api
sdk\<service name>\<package name>\src
sdk\<service name>\<package name>\tests
sdk\<service name>\<package name>\samples
sdk\<service name>\<package name>\CHANGELOG.md
```

- `<service name>` - Should be the short name for the azure service. e.g. deviceupdate
- `<package name>` -  Should be the name of the shipping package, or an abbreviation that distinguishes the given shipping artifact for the given service. It will be `Azure.<group>.<service>`, e.g. Azure.IoT.DeviceUpdate
  
We will use dotnet project template [Azure.ServiceTemplate.Template](https://github.com/Azure/azure-sdk-for-net/blob/3ac301ac6435c818ad7a9946ab1c4023cee236ff/eng/templates) to automatically create the project.

You can run `eng\scripts\automation\Invoke-DataPlaneGenerateSDKPackage.ps1` to generate the starting SDK client library package directly as following:

```powershell
eng/scripts/automation/Invoke-DataPlaneGenerateSDKPackage.ps1 -service <servicename> -namespace Azure.<group>.<service> -sdkPath <sdkrepoRootPath> -inputfiles <inputfilelink> [-securityScope <securityScope>] [-securityHeaderName <securityHeaderName>]
```

e.g.

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-DataPlaneGenerateSDKPackage.ps1 -service sample -namespace Azure.Template.Sample -sdkPath /home/azure-sdk-for-net -inputfiles https://github.com/Azure/azure-rest-api-specs/blob/73a0fa453a93bdbe8885f87b9e4e9fef4f0452d0/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json -securityScope https://sample/.default
```

**Note**:

- Use one of the following pre-approved namespace groups (<https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespaces-approved-list>): Azure.AI, Azure.Analytics, Azure.Communication, Azure.Data, Azure.DigitalTwins, Azure.IoT, Azure.Learn, Azure.Media, Azure.Management, Azure.Messaging, Azure.ResourceManager, Azure.Search, Azure.Security, Azure.Storage, Azure.Template, Azure.Identity, Microsoft.Extensions.Azure
- namespace is the shipped package name, it should be `Azure.<group>.<service>`
- inputfiles is the api definition files, separated by semicolon if more than one. The api definition file can be local file e.g. ./swagger/compute.json or premlink which contains commit id in it, e.g. <https://github.com/Azure/azure-rest-api-specs/blob/73a0fa453a93bdbe8885f87b9e4e9fef4f0452d0/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json>.

- Both AADToken and AzureKey authentication are supported. **AzureKey authentication** is specific to each service, but generally it is documented by that service. e.g [AzureKey authentication of Azure Storage](https://docs.microsoft.com/azure/storage/blobs/authorize-data-operations-portal#use-the-account-access-key). **AADToken** is for any service that supports [TokenCredential authentication](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet). If your service supports AADToken, just set the parameter **securityScope**(the security scope), and if your service supports AzureKey authentication, set parameter **securityHeaderName**( the security header name). You also can provide both if your service supports two authentications.

The script `eng\scripts\automation\Invoke-DataPlaneGenerateSDKPackage.ps1` will do **step-by-step** as following:

1. Create the project folder

Create a SDK library project, configuration file, or solution based on the specified template.

- install dotnet template
  
Navigate to the sdk repo root directory, and run the following commands:

```cmd
dotnet new --install eng/templates/Azure.ServiceTemplate.Template
```

- dotnet new project
  
Create project folder `Azure.<group>.<service>`. e.g. Azure.IoT.DeviceUpdate under `sdk/<service>` folder, navigate to the project folder, and run 'dotnet new' as following:
  
```cmd
sdk\<your-service-name>\Azure.<group>.<service>> dotnet new dataplane --libraryName [Client-Library-Title] --groupName [namespace-group-name] --swagger [input-swagger-file-path] --securityScopes [security-scopes] --force
```

e.g.

```cmd
dotnet new dataplane --libraryName DeviceUpdate --groupName IoT --swagger https://github.com/Azure/azure-rest-api-specs/blob/23dc68e5b20a0e49dd3443a4ab177d9f2fcc4c2b/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2021-06-01-preview/deviceupdate.json --securityScopes https://api.adu.microsoft.com/.default --force
```

- update the solution file if needed

Run 'dotnet sln' as following to update the projects in the solution file:

```cmd
dotnet sln remove src\Azure.<group>.<service>.csproj
dotnet sln add src\Azure.<group>.<service>.csproj
dotnet sln remove tests\Azure.<group>.<service>.Tests.csproj
dotnet sln add tests\Azure.<group>.<service>.Tests.csproj
```

**Learn more:** to understand more about the Azure SDK repo structure, see [Repo Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md) in the `azure-sdk` repo.

2. Generate client library

In this section, we'll create a generated API layer built on Azure Core.

From a PowerShell command prompt, navigate to the directory holding `Azure.<group>.<service>.csproj`. Run the following commands:

```cmd
sdk\<your-service-name>\Azure.<group>.<service>\src> dotnet build /t:GenerateCode
```

After you run the GenerateCode command, you should find a **Generated** folder in your project. Inside the Generated folder you'll find the ServiceClient and ServiceClientOptions which you can use to interact with the service.

3. Export public API

If you make public API changes or additions, the `eng\scripts\Export-API.ps1` script has to be run to update public API listings. This generates a file in the library's directory similar to the example found in [eng\templates\Azure.ServiceTemplate.Template\api\Azure.ServiceTemplate.Template.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/bb0fbccfc33dd27d1ec6f0870022824d47181e61/sdk/template-dpg/Azure.ServiceTemplate.Template/api/Azure.ServiceTemplate.Template.netstandard2.0.cs).

e.g. Running the script for a project in `sdk\deviceupdate` would look like this:

```powershell
eng\scripts\Export-API.ps1 deviceupdate
```

## Add package ship requirements

Before the library package can be released, you will need to add several requirements manually, including tests, samples, README, and CHANGELOG.
You can refer to following guideline to add those requirements:

- Tests: <https://azure.github.io/azure-sdk/general_implementation.html#testing>
- README/Samples: <https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-repository>
- Changelog: <https://azure.github.io/azure-sdk/policies_releases.html#change-logs>
- Other release concerns: <https://azure.github.io/azure-sdk/policies_releases.html>

### Tests

In this section, we will talk about adding unit tests and live tests and how to run them. You will notice that there is a test project under `Azure.<group>.<service>\tests`.

Here is the step by step process to add tests:requirements

- Add other client parameters in `<client-name>ClientTestEnvironment.cs`
- Update `<client-name>ClientTest.cs`.
  - Comment-out the 'CreateClient' method, and update the new <service>Client statement.
  - remove all the template project tests, and write the tests according to the commented Test method template. Please refer to [Using the TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md) to add tests.

**Note**:

- Before running live tests you will need to create live test resources, please refer to [Live Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manage resources and update test environment.
- `Azure.<group>.<service>` is the Azure SDK package name and `<client-name>` is a client name, C# generator will generate a client which you can find in `Azure.<group>.<service>/Generated` directory.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

### Samples

In this section, we will talk about how to add samples. As you can see, we already have a `Samples` folder under `Azure.<group>.<service>/tests` directory. We run the samples as a part of tests. First, enter `Sample<number>_<scenario>.cs` and remove the existing commented sample tests. You will add the basic sample tests for your SDK in this file. Create more test files and add tests as per your scenarios.

**Learn more:** For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

You will update all the `Sample<sample_number>_<scenario>.md` and README.md files under `Azure.<group>.<service>\samples` directory to the your service according to the examples in those files. Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/samples/) is an example.

### Snippets

Snippets are the great way to reuse the sample code. Snippets allow us to verify that the code in our samples and READMEs is always up to date, and passes unit tests. We have added the snippet [here](https://github.com/Azure/azure-sdk-for-net/blob/3ac301ac6435c818ad7a9946ab1c4023cee236ff/eng/templates/Azure.ServiceTemplate.Template/tests/Samples/Sample1_CreateResource.cs#L32) in a sample and used it in the [README](https://github.com/Azure/azure-sdk-for-net/blob/3ac301ac6435c818ad7a9946ab1c4023cee236ff/eng/templates/Azure.ServiceTemplate.Template/README.md#create-resource). Please refer to [Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

### README

README.md file instructions are listed in `Azure.<group>.<service>/README.md` file. Please add/update the README.md file as per your library.

**Learn more:** to understand more about README, see the [README.md](https://github.com/Azure/azure-sdk-for-net/blob/3ac301ac6435c818ad7a9946ab1c4023cee236ff/eng/templates/Azure.ServiceTemplate.Template/README.md). Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) is an example.

### Changelog

Update the CHANGELOG.md file which exists in `Azure.<group>.<service>/CHANGELOG.md`. For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).

### Customize

You may need to customize the client library a little bit to provide customers better experience when they use the library. 

There are two customization approaches:

- C# customization: Add convenience APIs.

**Learn more**: The [autorest.csharp README](https://github.com/Azure/autorest.csharp#setup) has great samples showing how to add convenience APIs in the generated code. Explore this further as you design APIs for your own service.

- Customizations can be done as a transform in `autorest.md`.
In `Azure.<group>.<service>` project, we have autorest.md file which is use to add configuration to generate code based on your swagger. [AnomalyDetector autorest.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/src/autorest.md) is an example.

```yaml
directive:
  - from: swagger-document
    where: $.parameters.endpoint
    transform: >
      if ($.format === undefined) {
        $.format = "url";
      }
  - from: swagger-document
    where: $.parameters.Endpoint
    transform: >
      if ($.format === undefined) {
        $.format = "url";
      }
```

**Note**: When to customize the client library, we prefer to using C# customization because it is easier to write, far easier to read, and much better documented than autorest.md REAMDE transforms. If c# customization does not work, you can write an autorest.md README transform.

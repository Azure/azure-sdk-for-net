# Azure SDK Code Geneneration Quickstart Tutorial (Data Plane)
The purpose of the Azure SDK is to provide a unified developer experience across Azure services. In this tutorial, we will walk through creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have a standardized API based on the  [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).

We will use the swagger file which contains a REST API definition based on [Azure REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md). We will use the swagger to generate SDK using [autorest.csharp](https://github.com/Azure/autorest.csharp).

**Learn more**: to understand more about Azure SDK Code Geneneration, see the [Azure SDK Code Geneneration docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

This tutorial has following sections:

- [Azure SDK Code Geneneration Quickstart Tutorial (Data Plane)](#azure-sdk-code-geneneration-quickstart-tutorial-data-plane)
  - [Prerequisites](#prerequisites)
  - [Setup your repo](#setup-your-repo)
  - [Getting started - shippable package](#getting-started---shippable-package)
    - [Create the project](#create-the-project)
      - [1. install dotnet tempate](#1-install-dotnet-tempate)
      - [2. dotnet new project](#2-dotnet-new-project)
      - [3. update the solution file if needed](#3-update-the-solution-file-if-needed)
    - [Create the generated client](#create-the-generated-client)
    - [Export Public API](#export-public-api)
  - [Refine the SDK library package](#refine-the-sdk-library-package)
    - [Tests](#tests)
    - [Samples](#samples)
    - [Snippets](#snippets)
    - [README](#readme)
  - [Changelog](#changelog)

<!-- /TOC -->

## Prerequisites

- Install VS 2020 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
- Install the **.NET Core cross-platform development** workloads in VisualStudio
- Install **.NET Core 5.0.301 SDK** for your specific platform. (or a higher version within the 5.0.*** band)  (https://dotnet.microsoft.com/download/dotnet-core/5.0)
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher.
- Install [NodeJS](https://nodejs.org/) (14.x.x).

## Setup your repo

- Fork and clone an [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repo. Follow the instructions in the [.NET Contributing.md](https://github.com/Azure/azure-sdk-for-net/issues/12903) to fork and clone the `azure-sdk-for-net` repo.
- Create a branch to work in. 

## Getting started - shippable package

For this tutorial, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. We will use dotnet project tempalte [Azure.ServiceTemplate.Template](https://github.com/Azure/azure-sdk-for-net/) to automatically create the project.

You can run `eng\Invoke-DataPlaneGenerateShippablePackage.ps1` to generate the first-version of SDK client library package, or you can do step-by-step as following.

### Create the project

#### 1. install dotnet tempate
navigate to the sdk repo root director, and run the following commands:

```
dotnet new -i eng/templates/Azure.ServiceTemplate.Template
```

#### 2. dotnet new project
- create project folder 'Azure.<group>.<service>'. e.g. Azure.IoT.DeviceUpdate under sdk/<resourceProvider> folder
- new project: navigate to the project folder, and run 'dotnet new' as following:
  
```
sdk\<your-service-name>\Azure.<group>.<service>> dotnet new dataplane --libraryName [Client-Library-Title] --swagger [input-swagger-file-path] --securityScopes [security-scopes] --force
```
e.g.
dotnet new dataplane --libraryName DeviceUpdate --swagger https://github.com/dpokluda/azure-rest-api-specs/blob/be397aa65510bd4e8f87da539af2b0025f6f44ca/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2020-09-01/deviceupdate.json --securityScopes https://api.adu.microsoft.com/.default --force

#### 3. update the solution file if needed
Run 'dotnet sln' as following to update the projects in the solution file:
dotnet sln remove src\Azure.<grouop>.<service>.csproj
dotnet sln add src\Azure.<grouop>.<service>.csproj
dotnet sln remove tests\Azure.<grouop>.<service>.Tests.csproj
dotnet sln add tests\Azure.<grouop>.<service>.Tests.csproj

**Learn more:** to understand more about the Azure SDK repo structure, see [Repo Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md) in the `azure-sdk` repo.

### Create the generated client

From a PowerShell command prompt, navigate to the directory holding `Azure.<group>.<service>.csproj`. Run the following commands:
```
sdk\<your-service-name>\Azure.<group>.<service>\src> dotnet build /t:GenerateCode
```

### Export Public API

If you make public API changes or additions, the `eng\scripts\Export-API.ps1` script has to be run to update public API listings. This generates a file in the library's directory similar to the example found in [sdk\template-dpg\Azure.Template.Generated\api\Azure.Template.Generated.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/api/Azure.Template.Generated.netstandard2.0.cs).

Running the script for a project in `sdk\deviceupdate` would look like this: 
```
eng\scripts\Export-API.ps1 deviceupdate
```

## Refine the SDK library package
You can continuously work on the first-version shippable package created above to refine, such as add Tests, Samples and refine the Readme.md and Changlog.
### Tests

In this section, we will talk about adding unit tests and live tests and how to run them. You will notice that there is an test project under Azure.<group>.<service>\tests.

Here is the step by step process to add tests:
- Add other client parameters in `<client-name>ClientTestEnvironment.cs`
- Update `<client-name>ClientTest.cs`. 
  - Comment-out the 'CreateClient' method, and update the new <service>Client statement.
  - remove all the template project tests, and write the tests according to the commented Test method template. Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing) to add live tests.
**Note**: Before running live tests you will need to create live test resources, please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manager resources and update test environment.

**Note**: `Azure.<group>.<service>` is the Azure SDK package name and `<client-name>` is a client name, C# generator will generate a client which you can find in `Azure.<group>.<service>/Generated` directory.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

### Samples

In this section, we will talk about how to add samples. As you can see, we already have a `Samples` folder under `Azure.<group>.<service>/tests` directory. We run the samples as a part of tests. First, enter `<client-name>ClientSamples.cs` and remove the existing commented sample tests. You will add the basic sample tests for your SDK in this file. Create more test files and add tests as per your scenarios.

**Learn more:** For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

### Snippets

Snippets are the great way to reuse the sample code. Snippets allow us to verify that the code in our samples and READMEs is always up to date, and passes unit tests. We have added the snippet [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/tests/Samples/TemplateServiceSamples.HelloWorld.cs#L30) in a sample and used it in the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md#create-resource). Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

### README

README.md file instructions are listed in `Azure.<group>.<service>/README.md` file. Please add/update the README.md file as per your library.

**Learn more:** to understand more about README, see the [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md). Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) is an example.

## Changelog

Update the CHANGELOG.md file which exists in `Azure.<group>.<service>/CHANGELOG.md`. For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).
# Azure SDK Code Geneneration Quickstart Tutorial (Data Plane)
The purpose of the Azure SDK is to provide a unified developer experience across Azure services. In this tutorial, we will walk through creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have a standardized API based on the  [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html).

We will use the [Azure SDK Generated Client template](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg) project as a reference. We have a template [swagger file](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg/Azure.Template.Generated/src/swagger) containing a REST API definition based on [Azure REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md). We will use the swagger to generate SDK using [autorest.csharp](https://github.com/Azure/autorest.csharp).

**Learn more**: to understand more about Azure SDK Code Geneneration, see the [Azure SDK Code Geneneration docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

This tutorial has following sections:

- [Prerequisites](#prerequisites)
- [Setup your repo](#setup-your-repo)
- [Getting started](#getting-started)
  - [Create the project](#create-the-project)
  - [Create the generated layer](#create-the-generated-layer)
- [Tests](#tests)
- [Samples](#samples)
- [Snippets](#snippets)
- [Export Public API](#export-public-api)
- [README](#readme)
- [Changelog](#changelog)

<!-- /TOC -->

## Prerequisites

- Install VS 2019 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
- Install the **.NET Core cross-platform development** workloads in VisualStudio
- Install **.NET Core 5.0.301 SDK** for your specific platform. (or a higher version within the 5.0.*** band)  (https://dotnet.microsoft.com/download/dotnet-core/5.0)
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 6 or higher.
- Install [NodeJS](https://nodejs.org/) (14.x.x).

## Setup your repo

- Fork and clone an [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repo. Follow the instructions in the [.NET Contributing.md](https://github.com/Azure/azure-sdk-for-net/issues/12903) to fork and clone the `azure-sdk-for-net` repo.
- Create a branch to work in. 

## Getting started

For this tutorial, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. To create the project, we'll copy the [Azure.Template.Generated](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg) project for .NET.

The `Azure.Template.Generated` project is a great place to get started with Azure SDK .NET library development in general, as it contains a number of common patterns we use for tests, samples, documentation, generating API listings. It also has generated code demonstrating an example Data Plane Generated Client.

**Learn more**: see other features listed in the [Azure.Template.Generated README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md).

### Create the project

#### 1. Copy the Azure.Template.Generated directory

Copy the `sdk\template-dpg` directory to an `sdk\<your-service-name>` directory at the same level. For example, from the root of your cloned repo:

```
% mkdir sdk\<your-service-name>
% xcopy sdk\template-dpg sdk\<your-service-name> /E
```

**Learn more:** to understand more about the Azure SDK repo structure, see [Repo Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md) in the `azure-sdk` repo.

#### 2. Remove existing generated code

Open the `Azure.Template.Generated.sln` file from the `sdk\<your-service-name>\Azure.Template.Generated` directory.

You'll notice that the `Azure.Template.Generated` project already has generated code in it!  You're welcome to explore what's there -- it's been generated from the swagger file in the `sdk/template-dpg/Azure.Template.Generated/src/swagger` folder. For this tutorial, however, we'll delete these generated files so we can start clean.

- Delete the Generated folder in the `Azure.Template.Generated` project.
- Delete the `swagger` folder in the `Azure.Template.Generated` project.

#### 3. Rename the solution and projects

In `Azure.Template.Generated` solution, you will notice that it contains `Azure.Template.Generated.csproj` and `Azure.Template.Generated.Tests.csproj`. You will need to rename the project and solution based on your `Azure.<group>.<service>` library. For now, you can remove the `Azure.Template.Generated.Tests` test project reference from the solution and add back when the generated code is ready.

In Visual Studio:

- Rename the `Azure.Template.Generated` project to `Azure.<group>.<service>`.
- Rename the `Azure.Template.Generated` solution to `Azure.<group>.<service>`.
- Remove the `Azure.Template.Generated.Tests` project from the solution.

**Note**: `Azure.<group>.<service>` is the Azure SDK package name. The package name/namespace will be something the architects will help standardize according to the guidelines.

**Learn more:** see the [.NET Guidelines on Namespace Naming](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespace-naming) for more information on naming Azure SDK packages. This name diverges from approved Azure SDK namespaces, since it is intended to be used just for this tutorial.

#### 4. Update the Assembly Info

You'll notice that the `Azure.<group>.<service>` project has `properties/AssemblyInfo.cs` file in it. Replace `Microsoft.Test` namespace with the correct resource provider namepace for your service.

**Learn more:** see the [Azure Services Resource Providers](https://docs.microsoft.com/azure/azure-resource-manager/management/azure-services-resource-providers) for the list of possible namespaces.

#### 5. Save and commit your changes to your branch

This will make it easier to see the changes you make when you generate code in the clean solution.

```
% git add -A
% git commit -m "initial commit for <service-name>"
```

### Create the generated client

In this section, we'll create a generated API layer built on Azure Core. We'll use a small swagger file containing a REST API definition for Azure Messaging WebPubSub.

In [Azure.Template.Generated](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg/Azure.Template.Generated/src) project, we have [autorest.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/src/autorest.md) file which is use to add configuration to generate code based on your swagger. After you run the `GenerateCode` command, you should find a [Generated](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg/Azure.Template.Generated/src/Generated) folder in your project. Inside the Generated folder you'll find the [ServiceClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/src/Generated/TemplateServiceClient.cs) and [ServiceClientOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/src/Generated/TemplateServiceClientOptions.cs) which you can use to interact with the service.

**Learn more:** the [autorest.csharp README](https://github.com/Azure/autorest.csharp#setup) has great samples showing how to add convenience APIs in the generated code. Explore this further as you design APIs for your own service.

Here is the step by step process to generate code:

#### 1. Set the Swagger File

Open autorest.md in your `Azure.<group>.<service>` project. In the input-file definition, replace the file path with your swagger link, for example: [WebPubSub swagger link](https://github.com/Azure/azure-rest-api-specs/blob/39c7d63c21b9a29efe3907d9b949d1c77b021907/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json). Update a namespace definition to set the namespace C# generator will use when creating your types. Update the AAD token credential(for AAD token, refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/src/autorest.md#autorest-configuration) example) or Azure key credential (for Azure Key credential, refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/src/autorest.md#swagger-sources) example). Save your changes.

Your `autorest.md` file should now look like:

````md
# `Azure.<group>.<service>` Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- <swagger-file-link>
namespace: <namespace>
public-clients: true
data-plane: true
security: AADToken
security-scopes: <AAD-token-scope>
```
````

**Learn more:** see the [README.md](https://github.com/Azure/autorest.csharp/blob/feature/v3/readme.md) to learn more about Azure SDK Code Geneneration.

#### 2. Run the Generate Command

From a PowerShell command prompt, navigate to the directory holding `Azure.<group>.<service>.sln`. Run the following commands:

```
sdk\<your-service-name>\Azure.<group>.<service>\src> dotnet msbuild /t:GenerateCode
```

#### 3. Explore the Generated Code

After you've run the `GenerateCode` command above, you should find a `Generated` folder in your `Azure.<group>.<service>` project.

If you're interested, you can look through the swagger file to see how the autorest.csharp extension translated the REST API definition into C# code. This could help you later if you decide to make adjustments to your API design in the swagger file directly, so they can be used for all Tier 1 languages.

**Learn more**: see the [OpenAPI Swagger Documentation](https://swagger.io/docs/) to learn more about swagger file formats.

#### 4. Save and commit your changes to your branch

This will make it easier to see the changes you make when you re-generate the code later.

Congratulations, you've generated your first Azure SDK library! Next, we'll discuss how we can add tests, samples and documents.

## Tests

In this section, we will talk about adding unit tests and live tests and how to run them. You will notice that [Azure.Template.Generated.Test](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-dpg/Azure.Template.Generated/tests) project contains [TemplateServiceTestEnvironment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/tests/TemplateServiceTestEnvironment.cs) file where we added live test environment to run live tests. We added live tests in [TemplateServiceLiveTests.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/tests/TemplateServiceLiveTests.cs) file and unit tests in [TemplateServiceTests.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/tests/TemplateServiceTests.cs) file.

Here is the step by step process to add tests:

- Add back `Azure.Template.Generated.Tests` csproj in your `Azure.<group>.<service>.sln`.
- Rename the `Azure.Template.Generated.Tests` project to `Azure.<group>.<service>.Tests`.
- Rename the `TemplateServiceTestEnvironment.cs` file to `<client-name>TestEnvironment.cs` and update the test environment. Before running live tests you will need to create live test resources, please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manager resources and update test environment.
- Rename the `TemplateServiceLiveTests.cs` file to `<client-name>LiveTests.cs` and remove all the template project tests. Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing) to add live tests.
- Rename the `TemplateServiceTests.cs` file to `<client-name>Tests.cs` and remove all the template project tests and add all the unit tests in this file.
- Remove the `SerializationHelpers.cs` file.

**Note**: `Azure.<group>.<service>` is the Azure SDK package name and `<client-name>` is a client name, C# generator will generate a client which you can find in `Azure.<group>.<service>/Generated` directory.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

## Samples

In this section, we will talk about how to add samples. As you can see, we already have a `Samples` folder under `Azure.<group>.<service>/tests` directory. We run the samples as a part of tests. First, rename the `TemplateServiceSamples.HelloWorld.cs` file to `<client-name>Samples.HelloWorld.cs` and remove the existing sample tests. You will add the basic sample tests for your SDK in this file. Create more test files and add tests as per your scenarios.

**Learn more:** For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

## Snippets

Snippets are the great way to reuse the sample code. Snippets allow us to verify that the code in our samples and READMEs is always up to date, and passes unit tests. We have added the snippet [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/tests/Samples/TemplateServiceSamples.HelloWorld.cs#L30) in a sample and used it in the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md#create-resource). Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

## Export Public API

If you make public API changes or additions, the `eng\scripts\Export-API.ps1` script has to be run to update public API listings. This generates a file in the library's directory similar to the example found in [sdk\template-dpg\Azure.Template.Generated\api\Azure.Template.Generated.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/api/Azure.Template.Generated.netstandard2.0.cs).

Running the script for a project in `sdk\webpubsub` would look like this: 
```
eng\scripts\Export-API.ps1 webpubsub
```

## README

README.md file instructions are listed in `Azure.<group>.<service>/README.md` file. Please add/update the README.md file as per your library.

**Learn more:** to understand more about README, see the [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-dpg/Azure.Template.Generated/README.md). Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) is an example.

## Changelog

Update the CHANGELOG.md file which exists in `Azure.<group>.<service>/CHANGELOG.md`. For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).
# LLC Quickstart Tutorial

- [Prerequisites](#prerequisites)
- [Setup your repo](#setup-your-repo)
- [Getting started](#getting-started)
  - [Create the project](#create-the-project)
  - [Create the generated layer](#create-the-generated-layer)
- [Tests](#tests)
- [Samples](#samples)
- [Snippets](#snippets)
- [Export Public API](#export-public-api)
- [Readme](#readme)
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

For this tutorial, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. To create the project, we'll copy the [Azure.Template.LLC](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template-LLC) project for .NET.

The `Azure.Template.LLC` project is a great place to get started with Azure SDK .NET library development in general, as it shows a number of common patterns we use for tests, samples, documentation, generating API listings, and an example of a generated library already in place.

**Learn more**: see other patterns `Azure.Template.LLC` illustrates in the [Azure.Template.LLC README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-LLC/Azure.Template.LLC/README.md).

### Create the project

#### 1. Copy the Azure.Template.LLC directory

Copy the `sdk\template-LLC` directory to an `sdk\<your-service-name>` directory at the same level. For example, from the root of your cloned repo:

```
% mkdir sdk\<your-service-name>
% xcopy sdk\template-LLC sdk\<your-service-name> /E
```

**Learn more:** to understand more about the Azure SDK repo structure, see [Repo Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md) in the `azure-sdk` repo.

#### 2. Remove existing generated code

Open the `Azure.Template.LLC.sln` file from the `sdk\<your-service-name>\Azure.Template.LLC` directory.

You'll notice that the `Azure.Template.LLC` project already has generated code in it!  You're welcome to explore what's there -- it's been generated from the swagger file in the `swagger` folder. For this tutorial, however, we'll delete these generated files so we can start clean.

- Delete the Generated folder in the `Azure.Template.LLC` project.
- Delete the `swagger` folder in the `Azure.Template.LLC` project.

#### 3. Rename the solution and projects

In Visual Studio:

- Rename the `Azure.Template.LLC` project `Azure.<your-sdk-name>`.
- Rename the `Azure.Template.LLC` solution `Azure.<your-sdk-name>`.
- Remove the `Azure.Template.LLC.Tests` project from the solution.

**Learn more:** see the [.NET Guidelines on Namespace Naming](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespace-naming) for more information on naming Azure SDK packages. This name diverges from approved Azure SDK namespaces, since it is intended to be used just for this tutorial.

#### 4. Save and commit your changes to your tutorial branch

This will make it easier to see the changes you make when you generate code in the clean solution.

```
% git add -A
% git commit -m "initial commit"
```

### Create the generated layer

In this section, we'll create a generated API layer built on Azure Core. We'll use a small swagger file containing a REST API definition for Azure Messaging WebPubSub.

**Learn more:** the [autorest.csharp README](https://github.com/Azure/autorest.csharp#setup) has great samples showing how to customize the API in the generated code. Explore this further as you design APIs for your own service.

#### 1. Set the Swagger File

Open autorest.md in your `Azure.<your-sdk-name>` project. In the input-file definition, replace the file path with your swagger link, for example: [WebPubSub swagger link](https://github.com/Azure/azure-rest-api-specs/blob/39c7d63c21b9a29efe3907d9b949d1c77b021907/specification/webpubsub/data-plane/WebPubSub/stable/2021-10-01/webpubsub.json). Update a namespace definition to set the namespace the generator will use when creating your types. Update the AAD token credential(For AAD token refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-LLC/Azure.Template.LLC/src/autorest.md#autorest-configuration) example) or Azure key credential(For Azure Key credential refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub/src/autorest.md#swagger-sources) example). Save your changes.

Your `autorest.md` file should now look like:

````md
# `Azure.<your-sdk-name>` Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
- <swagger-file-link>
namespace: <namespace>
public-clients: true
low-level-client: true
security: AADToken
security-scopes: <AAD-token-scope>
```
````

**Note:** see the [.NET Guidelines for Namespaces](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespace-naming) learn more about namespaces in the Azure SDK.

#### 2. Run the Generate Command

From a PowerShell command prompt, navigate to the directory holding `Azure.<your-sdk-name>.sln`.Run the following commands:

```
sdk\<your-service-name>\Azure.<your-sdk-name>\src> dotnet msbuild /t:GenerateCode
```

#### 3. Explore the Generated Code

After you've run the `GenerateCode` command above, you should find a `Generated` folder in your `Azure.<your-sdk-name>` project.

If you're interested, you can look through the swagger file to see how the autorest.csharp extension translated the REST API definition into C# code. This could help you later if you decide to make adjustments to your API design in the swagger file directly, so they can be used for all Tier 1 languages.

**Learn more**: see the [OpenAPI Swagger Documentation](https://swagger.io/docs/) to learn more about swagger file formats.

#### 4. Save and commit your changes to your tutorial branch

This will make it easier to see the changes you make when you re-generate the code later.

Congratulations, you've generated your first Azure SDK library! Next, we'll discuss how we can Add tests, samples and documents.

## Tests

In this section, we will talk about adding unit tests and live tests and how to run them.

- Add back `Azure.Template.LLC.Tests` in your `Azure.<your-sdk-name>.sln`.
- Rename the `Azure.Template.LLC.Tests` project `Azure.<your-sdk-name>.Tests`.
- Rename the `TemplateServiceTestEnvironment.cs` file `<client-name>TestEnvironment.cs` and update the test environment. Before running live tests you need to create live test resources, please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manager resources. 
- Rename the `TemplateServiceLiveTests.cs` file `<client-name>LiveTests.cs` and remove all the template project tests. Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing) to add live tests.
- Rename the `TemplateServiceTests.cs` file `<client-name>Tests.cs` and remove all the template project tests and add all the unit tests in this file.
- Remove the `SerializationHelpers.cs` file.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

## Samples

In this section, we will talk about how to add samples. As you can see we already have samples folder under `Azure.<your-sdk-name>/tests` directory. We run the samples as a part of tests. First, rename the `TemplateServiceSamples.HelloWorld.cs` file `<client-name>Samples.HelloWorld.cs` and remove the existing sample tests. You will add the basic sample tests for your SDK in this file. Create more test files and add tests as per your scenarios.

**Learn more:** For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

## Snippets

Snippets are the great way to reuse the sample code. Please refer [this](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

## Export Public API

If you make public API changes or additions, the `eng\scripts\Export-API.ps1` script has to be run to update public API listings. This generates a file in the library's directory similar to the example found in [sdk\template-LLC\Azure.Template.LLC\api\Azure.Template.LLC.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template-LLC/Azure.Template.LLC/api/Azure.Template.LLC.netstandard2.0.cs).

Running the script for a project in `sdk\webpubsub` would look like this: 
```
eng\scripts\Export-API.ps1 webpubsub
```

## Readme

README.md file instrauctions are listed in `Azure.<your-sdk-name>/README.md` file. Please Add/update the README.md file as per your library.

## Changelog

Update the CHANGELOG.md file which exists in `Azure.<your-sdk-name>/CHANGELOG.md`. For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).
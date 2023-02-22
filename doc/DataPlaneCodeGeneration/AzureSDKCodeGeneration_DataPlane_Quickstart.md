# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes an Open API spec or [Cadl](https://microsoft.github.io/cadl/) as input, and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input API spec should follow the [Azure REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md) and Cadl files should comply with cadl lint rules, to enable the output library to be consistent with the Azure SDK Guidelines.

**Learn more**: You can learn more about Azure SDK Data Plane Code Generation in the [Azure SDK Code Generation docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

This tutorial has following sections:

- [Azure SDK Code Generation Quickstart Tutorial (Data Plane)](#azure-sdk-code-generation-quickstart-tutorial-data-plane)
  - [Prerequisites](#prerequisites)
  - [Setup your repository](#setup-your-repository)
  - [Create SDK Package](#create-sdk-package)
    - [Use Cadl as Input API spec](#use-cadl-as-input-api-spec)
      - [Create Cadl project](#create-cadl-project)
      - [Create SDK project directory](#create-sdk-project-directory)
      - [Generate SDK](#generate-sdk)
    - [Use swagger as Input API spec](#use-swagger-as-input-api-spec)
  - [Add package ship requirements](#add-package-ship-requirements)
    - [Tests](#tests)
    - [Samples](#samples)
    - [Snippets](#snippets)
    - [README](#readme)
    - [Changelog](#changelog)
    - [Add Convenience APIs](#add-convenience-apis)
    - [APIView](#apiview)

<!-- /TOC -->

## Prerequisites

- Install Visual Studio 2022 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
  - Install the **.NET Core cross-platform development** workloads in Visual Studio
- Install **.NET 6.0 SDK** for your specific platform. (or a higher version)
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher.
- Install [NodeJS](https://nodejs.org/) (16.x.x or above).

## Setup your repository

- Fork and clone the [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repository. Instructions for doing so can be found in the [.NET CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md).
- Create a branch to work in.

## Create SDK Package

For this guide, we'll create a sdk project in a branch of your fork of `azure-sdk-for-net` repo. The project will be under `sdk\<servie name>\<package name>` directory of `azure-sdk-for-net` repo. The package will contain several folders and files (see following). Please refer to [sdk-directory-layout](https://github.com/Azure/azure-sdk/blob/main/docs/policies/repostructure.md#sdk-directory-layout) for detail information.

```text
sdk\<service name>\<package name>\README.md
sdk\<service name>\<package name>\api
sdk\<service name>\<package name>\perf
sdk\<service name>\<package name>\samples
sdk\<service name>\<package name>\src
sdk\<service name>\<package name>\stress
sdk\<service name>\<package name>\tests
sdk\<service name>\<package name>\CHANGELOG.md
sdk\<service name>\<package name>\<package name>.sln
```

- `<service name>` - Should be the short name for the azure service. e.g. deviceupdate. It is usually your service name in REST API specifications. For instance, if the API spec is under `specification/storage`, the service would normally be `storage`.
- `<package name>` -  Should be the name of the shipping package, or an abbreviation that distinguishes the given shipping artifact for the given service. It will be `Azure.<group>.<service>`, e.g. Azure.IoT.DeviceUpdate

### Use Cadl as Input API spec

#### Create Cadl project
  
  You can download existing cadl project from [azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) repo or you can follow following steps to create a new cadl project.

  ***Initialize Cadl Project***

  Follow [Cadl Getting Start](https://github.com/microsoft/cadl/#using-node--npm) to initialize your Cadl project.

  Make sure `npx cadl compile .` runs correctly.

  **Note**: It is recommended to configure Cadl Specs on [REST API specifications](https://github.com/Azure/azure-rest-api-specs). Please refer to the [Guidelines](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/cadl-structure-guidelines.md).

  ***Configuration***

  One can further configure the SDK generated, using the emitter options on @azure-tools/cadl-csharp.

  Modify (or create) cadl-project.yaml, add emitter options under options/@azure-tools/cadl-csharp. Option `namespace` and `emitter-output-dir` are required.

```diff
parameters:
  "python-sdk-folder":
    default: "{cwd}/azure-sdk-for-python/"
  "java-sdk-folder":
    default: "{cwd}/azure-sdk-for-java/"
  "js-sdk-folder":
    default: "{cwd}/azure-sdk-for-js/"
  "csharp-sdk-folder":
    default: "{cwd}/azure-sdk-for-csharp/"
  "openapi-folder":
    default: "{project-root}/../dataplane/"
  "service-directory-name":
    default: mycadlproject
emit:
  - "@azure-tools/cadl-autorest"
options:
  "@azure-tools/cadl-csharp":
+    namespace: Azure.Template.MyCadlProject
+    "emitter-output-dir": "{csharp-sdk-folder}/sdk/{service-directory-name}/{namespace}/src"
```

  **Notes**:
  
  @azure-tools/cadl-csharp emitter options:  

- `namespace` define the client library namespace. e.g. Azure.IoT.DeviceUpdate.
- `emitter-output-dir` define the output dire path which will store the generated code.
- `generate-protocol-methods` indicate if you want to generate **protocol method** for each operation. It is a boolean flag to shift the entire generation for the process (`true` by default)
- `generate-convenience-methods` indicate if you want to generate **convenience method** for each operation. It is a boolean flag to shift the entire generation for the process (`true` by default)
- `unreferenced-types-handling` define the strategy how to handle the unreferenced types. It can be `removeOrInternalize`, `internalize` or `keepAll`
- `model-namespace` indicate if we want to put the models in their own namespace which is a sub namespace of the client library namespace plus ".Models". if it is set `false`, the models will be put in the same namespace of the client. The default value is `true`.
- `clear-output-folder` indicate if you want to clear up the output folder.
- `package-name` define the package folder name which will be used as service directory name under `sdk/` in azure-sdk-for-net repo.
- `save-inputs` indicate if you want to keep the intermediate files for debug purpose, e.g. the model json file (cadl.json) parsed from cadl file.

#### Create SDK project directory

We will generate SDK library under `sdk\<servie name>\<package name>` directory of `azure-sdk-for-net` repo. e.g. /home/azure-sdk-for-net/sdk/anomalydetector/Azure.AI.AnomalyDetector).

If the sdk project directory does not exist, you can refer to [SDK project directory Set up](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKPackage_Setup.md) to create one.

#### Generate SDK

We will generate SDK under the SDK project directory.

***configuration***

You can update `cadl-location.yaml` under sdk project directory to set the cadl project.

You can refer to the [cadl-location.yaml](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/Cadl-Project-Scripts.md#cadl-locationyaml) which describes the supported properties in the file.

Example:

```yml
directory: specification/cognitiveservices/OpenAI.Inference
additionalDirectories:
  - specification/cognitiveservices/OpenAI.Authoring
commit: 14f11cab735354c3e253045f7fbd2f1b9f90f7ca
repo: Azure/azure-rest-api-specs
cleanup: false
```

**Note**: If you want to use a local specs repo that is already present, you can specify `spec-root-dir` to provide the path of the root directory of the specs repo, e.g. /home/azure-rest-api-specs, and don't provide the `commit` and `repo`.

***Generate Code***

Enter `src` folder, e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector/src
Run `dotnet build /t:GenerateCode` to generate the code.

### Use swagger as Input API spec

See QuickStart with [Autorest DataPlan QuickStart](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Autorest_DataPlane_Quickstart.md)

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
  - Please refer to [Using the TestFramework](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md) to add tests.

**Note**:

- Before running live tests you will need to create live test resources, please refer to [Live Test Resource Management](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/common/TestResources/README.md) to learn more about how to manage resources and update test environment.
- `Azure.<group>.<service>` is the Azure SDK package name and `<client-name>` is a client name, C# generator will generate a client which you can find in `Azure.<group>.<service>/Generated` directory.

**Learn more:** see the [docs](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#to-test-1) to learn more about tests.

### Samples

In this section, we will talk about how to add samples. As you can see, we already have a `Samples` folder under `Azure.<group>.<service>/tests` directory. We run the samples as a part of tests. First, enter `Sample<number>_<scenario>.cs` and remove the existing commented sample tests. You will add the basic sample tests for your SDK in this file. Create more test files and add tests as per your scenarios.

**Learn more:** For general information about samples, see the [Samples Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-samples).

You will update all the `Sample<sample_number>_<scenario>.md` and README.md files under `Azure.<group>.<service>\samples` directory to the your service according to the examples in those files. Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/anomalydetector/Azure.AI.AnomalyDetector/samples/) is an example.

### Snippets

Snippets are the great way to reuse the sample code. Snippets allow us to verify that the code in our samples and READMEs is always up to date, and passes unit tests. We have added the snippet [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1_HelloWorld.cs#L21) in a sample and used it in the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md#get-secret). Please refer to [Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) to add snippets in your samples.

### README

README.md file instructions are listed in `Azure.<group>.<service>/README.md` file. Please add/update the README.md file as per your library.

**Learn more:** to understand more about README, see the [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md). Based on that [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) is an example.

### Changelog

Update the CHANGELOG.md file which exists in `Azure.<group>.<service>/CHANGELOG.md`. For general information about the changelog, see the [Changelog Guidelines](https://azure.github.io/azure-sdk/policies_releases.html#change-logs).

### Add Convenience APIs

Adding convenience APIs is not required for Azure SDK data plane generated libraries, but doing so can provide customers with a better experience when they develop code using your library.  You should consider adding convenience APIs to the generated client to make it easier to use for the most common customer scenarios, or based on customer feedback.  Any convenience APIs you add should be approved with the Azure SDK architecture board.

You can add convienice APIs by adding a customization layer on top of the generated code.  Please see the [autorest.csharp README](https://github.com/Azure/autorest.csharp#setup) for the details of adding the customization layer.  This is the preferred method for adding convenience APIs to your generated client.


If other modifications are needed to the generated API, you can consider making them directly to the Open API specification, which will have the benefit of making the changes to the library in all languages you generate the library in.  As a last resort, you can add modifications with swagger transforms in the `autorest.md` file.  Details for various transforms can be found in [Customizing the generated code](https://github.com/Azure/autorest.csharp#customizing-the-generated-code).

Once you've made changes to the public API, you will need to run the `eng\scripts\Export-API.ps1` script to update the public API listing. This will generate a file in the library's directory similar to the example found in [sdk\template\Azure.Template\api\Azure.Template.netstandard2.0.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/api/Azure.Template.netstandard2.0.cs).

e.g. Running the script for a project in `sdk\deviceupdate` would look like this:

```powershell
eng\scripts\Export-API.ps1 deviceupdate
```

### APIView

Once you've done all above requirements, you will need to upload public API to [APIView Website](https://apiview.dev/) for review.

Here are the steps:

- Create the artifact: Run `dotnet pack` under `sdk\<service>\Azure.<group>.<service>` directory. The artifact will be generated to the directory `artifacts\packages\Debug\Azure.<group>.<service>`
- Upload the artifact to [APIView Website](https://apiview.dev/) to create APIView of the service.
# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes an Open API spec or [Cadl](https://microsoft.github.io/cadl/) as input, and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input API spec should follow the [Azure REST API Guidelines](https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md) and Cadl files should comply with cadl lint rules, to enable the output library to be consistent with the Azure SDK Guidelines.

**Learn more**: You can learn more about Azure SDK Data Plane Code Generation in the [Azure SDK Code Generation docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

This tutorial has following sections:

- [Azure SDK Code Generation Quickstart Tutorial (Data Plane)](#azure-sdk-code-generation-quickstart-tutorial-data-plane)
  - [Prerequisites](#prerequisites)
  - [Setup your repository](#setup-your-repository)
  - [Create starter package](#create-starter-package)
    - [Use Cadl as Input](#use-cadl-as-input)
      - [Create Cadl project](#create-cadl-project)
      - [Create sdk starter package](#create-sdk-starter-package)
    - [Use swagger as Input](#use-swagger-as-input)
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

## Create starter package  

For this guide, we'll create a getting started project in a branch of your fork of `azure-sdk-for-net` repo. The started project will be under `sdk\<servie name>\<package name>` directory of `azure-sdk-for-net` repo. The package will contain several folders and files (see following). Please refer to [sdk-directory-layout](https://github.com/Azure/azure-sdk/blob/main/docs/policies/repostructure.md#sdk-directory-layout) for detail information.

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

- `<service name>` - Should be the short name for the azure service. e.g. deviceupdate
- `<package name>` -  Should be the name of the shipping package, or an abbreviation that distinguishes the given shipping artifact for the given service. It will be `Azure.<group>.<service>`, e.g. Azure.IoT.DeviceUpdate

### Use Cadl as Input

#### Create Cadl project
  
  You can download existing cadl project from [azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) repo or you can follow following steps to create a new cadl project.

  ***Initialize Cadl Project***

  Follow [Cadl Getting Start](https://github.com/microsoft/cadl/#using-node--npm) to initialize your Cadl project.

  Make sure `npx cadl compile .` runs correctly.

  ***Add cadl-csharp emitter***

  Modify package.json, add one line under dependencies:

```diff
        "dependencies": {
          "@cadl-lang/compiler": "^0.37.0",
          "@cadl-lang/rest": "^0.19.0",
          "@azure-tools/cadl-azure-core": "^0.9.0",
+         "@azure-tools/cadl-csharp": "0.1.8"
        },
```

        Run `npm install` again to install @azure-tools/cadl-csharp.

  **Notes**: @azure-tools/cadl-csharp: "0.1.8" only works with @cadl-lang/compiler: "0.37.0" and @cadl-lang/rest: "0.19.0"
  

  ***Modify (or create) cadl-project.yaml, add one line under emitters:***

  ```diff
  emitters:
+  "@azure-tools/cadl-csharp": true
  ```

  ***Configuration (optional)***

  One can further configure the SDK generated, using the emitter options on @azure-tools/cadl-csharp.

```
emitters:
  "@azure-tools/cadl-csharp":
    namespace: "Azure.IoT.DeviceUpdate"
    clear-output-folder: true
```

  **Notes**:
  
  @azure-tools/cadl-csharp emitter options:  

- `namespace` define the client library namespace. e.g. Azure.IoT.DeviceUpdate.
- `new-project` indicate if it is a new sdk project and need to generate a project file (.csproj).
- `model-namespace` Indicate if we want to put the models in their own namespace which is a sub namespace of the client library namespace plus ".Models". if it is set `false`, the models will be put in the same namespace of the client. The default value is `true`.
- `clear-output-folder` indicate if you want to clear up the output folder.


#### Create sdk starter package
  
We will use the Azure SDK template [Azure.Template](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template) to create the initial project skeleton.

You can run `eng\scripts\automation\Invoke-CadlDataPlaneGenerateSDKPackage.ps1` to generate the starting SDK client library package directly as following:

```powershell
eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service <servicename> -namespace Azure.<group>.<service> -sdkPath <sdkrepoRootPath> -cadlRelativeFolder <relativeCadlProjectFolderPath> [-commit <commitId>] [-repo <specRepo>] [-specRoot <specRepoRootPath>] [-additionalSubDirectories <relativeFolders>]
```

e.g. 
Use git url

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service anomalydetector -namespace Azure.AI.AnomalyDetector -sdkPath /home/azure-sdk-for-net -cadlRelativeFolder specification/cognitiveservices/AnomalyDetector -commit ac8e06a2ed0fc1c54663c98f12c8a073f8026b90 -repo Azure/azure-rest-api-specs
```
or 
Use local Cadl project

```powershell
pwsh /home/azure-sdk-for-net/eng/scripts/automation/Invoke-CadlDataPlaneGenerateSDKPackage.ps1 -service anomalydetector -namespace Azure.AI.AnomalyDetector -sdkPath /home/azure-sdk-for-net -cadlRelativeFolder specification/cognitiveservices/AnomalyDetector -specRoot /home/azure-rest-api-specs
```
**Note**:

- `-service` takes Azure client service directory name. ie. purview. It equals to the name of the directory in the specification folder of the azure-rest-api-specs repo that contains the REST API definition file.
- For `- namespace`, please use one of the pre-approved namespace groups on the [.NET Azure SDK Guidelines Approved Namespaces list](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-namespaces-approved-list). This value will also provide the name for the shipped package, and should be of the form `Azure.<group>.<service>`.
- `-sdkPath` takes the address of the root directory of sdk repo. e.g. /home/azure-sdk-for-net
- `cadlRelativeFolder` takes the relative path of the cadl project folder in spec repo. e.g. specification/cognitiveservices/AnomalyDetector
- `-additionalSubDirectories` takes the relative paths of the additional directories needed by the cadl project, such as share library folder, separated by semicolon if there is more than one folder.
- `-commit` takes the git commit hash  (e.g. ac8e06a2ed0fc1c54663c98f12c8a073f8026b90)
- `-repo` takes the `<owner>/<repo>` of the REST API specification repository. (e.g. Azure/azure-rest-api-specs)
- `-specRoot` takes the file system path of the spec repo. e.g. /home/azure-rest-api-specs
- You need to provide one of (`-commit`, `-repo`) pair to refer to an URL path of the cadl project and `-specRoot` parameters. If you provide both, `-specRoot` will be ignored.

When you run `eng\scripts\automation\Invoke-CadlDataPlaneGenerateSDKPackage.ps1`, it will:

- Create a project folder, install template files from `sdk/template/Azure.Template`, and create `.csproj` and `.sln` files for your new library.

    These files are created following the guidance for the [Azure SDK Repository Structure](https://github.com/Azure/azure-sdk/blob/master/docs/policies/repostructure.md).

- Generate the library source code files to the directory `<sdkPath>/sdk/<service>/<namespace>/src/Generated`
- Build the library project to create the starter package binary.
- Export the library's public API to the directory `<sdkPath>/sdk/<service>/<namespace>/api`


### Use swagger as Input

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
# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes an [typespec](https://microsoft.github.io/typespec/) as input, and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input typespec files (*.tsp) should comply with typespec lint rules, to enable the output library to be consistent with the Azure SDK Guidelines.

**Learn more**: You can learn more about Azure SDK Data Plane Code Generation in the [Azure SDK Code Generation docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

## Prerequisites

For first time to setup of a new sdk package, please verify you have met the prerequisites. You can refer to [SDK Generation Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKGeneration_Prerequistites.md) to setup.

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


### Before you Start
  
  Make sure you have typespec project in [azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) repo or you can follow [Typespec Getting Start](https://github.com/microsoft/typespec/#using-node--npm) to initialize your typespec project, and refer to [Typespec Structure Guidelines](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/cadl-structure-guidelines.md) to configure your typespec project.

  We will generate SDK library under SDK project folder `sdk\<servie name>\<package name>` of `azure-sdk-for-net` repo. e.g. /home/azure-sdk-for-net/sdk/anomalydetector/Azure.AI.AnomalyDetector).

  Make sure that the SDK project folder exists in [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repo. If the SDK project folder does not exist, you can refer to [SDK project directory Set up](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKPackage_Setup.md) to create one.

### Generate SDK

We will generate SDK under the SDK project directory.

***configuration (optional)***

You can update `cadl-location.yaml` under sdk project directory to set the cadl project.

You can refer to the [cadl-location.yaml](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/Cadl-Project-Scripts.md#cadl-locationyaml) which describes the supported properties in the file.

***Generate Code***

Enter `src` sub-directory of sdk project folder, e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector/src
Run `dotnet build /t:GenerateCode`, and the code will be generated under `sdk\<servie name>\<package name>\src\Generated`

```dotnetcli
dotnet build /t:GenerateCode
```


## Add package ship requirements

Before the library package can be released, you will need to add several requirements manually, including tests, samples, README, and CHANGELOG. Please refer to [Azure SDK Package Ship Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Azure_SDK_Package_Ship_Requirements.md) to add those requirements.

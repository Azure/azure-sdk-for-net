# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes an [typespec](https://microsoft.github.io/typespec/) as input, and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input typespec files (*.tsp) should comply with typespec lint rules, to enable the output library to be consistent with the Azure SDK Guidelines.

**Learn more**: You can learn more about Azure SDK Data Plane Code Generation in the [Azure SDK Code Generation docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

## Prerequisites

For first time to setup of a new sdk package, please verify you have met the prerequisites, including runtime environment, typespec project, sdk project folder. You can refer to [SDK Generation Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKGeneration_Prerequistites.md) to setup.

## Generate SDK

We will generate an SDK under the SDK project folder of `azure-sdk-for-net`.

### Configuration (optional)

You can update `tsp-location.yaml` under sdk project folder to set the typespec project.

You can refer to the [tsp-location.yaml](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/Typespec-Project-Scripts.md#tsp-locationyaml) which describes the supported properties in the file.

### Generate Code

Enter `src` sub-directory of sdk project folder, e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector/src
Run `dotnet build /t:GenerateCode`, and the code will be generated under `sdk\<servie name>\<package name>\src\Generated`

```dotnetcli
dotnet build /t:GenerateCode
```

## Add package ship requirements

Before library package can be released, you will need to add tests and samples. You will also need to update the changelogs and README's as necessary. Please refer to [Azure SDK Package Ship Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Azure_SDK_Package_Ship_Requirements.md) to add those requirements.

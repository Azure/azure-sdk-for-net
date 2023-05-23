# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes a [TypeSpec](https://microsoft.github.io/typespec/) as input and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input TypeSpec files (*.tsp) should comply with TypeSpec lint rules so the output library is consistent with the Azure SDK Guidelines.

**Learn more**: You can learn more about Azure SDK Data Plane Code Generation in the [Azure SDK Code Generation docs](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md).

## Prerequisites

For first time to set up of a new SDK package, please verify you have met the prerequisites, including runtime environment, TypeSpec project, and SDK project folder. You can refer to [SDK Generation Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKGeneration_Prerequistites.md) to set up.

## Generate SDK

We will generate an SDK under the SDK project folder of `azure-sdk-for-net`.

### Configuration (optional)

You can update `tsp-location.yaml` under sdk project folder to set the typespec project.

You can refer to the [tsp-location.yaml](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md#tsp-locationyaml) which describes the supported properties in the file.

### Generate Code

Enter `src` sub-directory of sdk project folder, e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector/src
Run `dotnet build /t:GenerateCode`, and the code will be generated under `sdk\<servie name>\<package name>\src\Generated`

```dotnetcli
dotnet build /t:GenerateCode
```

## Add package ship requirements

Before a library package can be released, you will need to add tests and samples. You will also need to update the CHANGELOG.md and README.md as necessary. Please refer to [Azure SDK Package Ship Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Azure_SDK_Package_Ship_Requirements.md) for those requirements.

## Code Review

Code review happens on 2 places.

One is the usual GitHub pull request, for developers.

Another is the [apiview](https://apiview.dev/), for architects. GitHub pull request (PR) should automatically trigger the apiview. If this does not happen, please help to file an issue in [azure-sdk-tools](https://github.com/azure/azure-sdk-tools) to report the failure.
And you can upload one manually:

 - Build the SDK, Run `dotnet pack` to create SDK package.
 - Login apiview with GitHub account.
 - Click "Create + review" at bottom-right corner.
 - "Browse" and upload .nupkg (e.g. /home/azure-sdk-for-net/artifacts/package/Debug/Azure.AI.AnomalyDetector/Azure.AI.AnomalyDetector.3.0.0-alpha.20230331.1.nupkg), and comment the result apiview link in the PR.

**Comment @Azure/dpg-devs for awareness in PR to loop in SDK developers for review.**

## Package Release

See [Release Checklist](https://dev.azure.com/azure-sdk/internal/_wiki/wikis/internal.wiki/8/Release-Checklist?anchor=prepare-release-script).
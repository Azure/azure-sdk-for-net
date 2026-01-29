# Azure SDK Code Generation Quickstart Tutorial (Data Plane)

We build Azure SDK libraries to give developers a consistent, unified experience working with Azure services, in the language ecosystem where they're most comfortable.  Azure SDK Code Generation allows you to quickly and easily create a client library so customers can work with your service as part of the SDK.  In this tutorial, we will step through the process of creating a new Azure SDK Generated Client library for a data plane Azure service.  The output library will have an API that follows [.NET Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), which will give it the same look and feel of other .NET libraries in the Azure SDK.

Azure SDK Code Generation takes a [TypeSpec](https://microsoft.github.io/typespec/) as input and uses the [autorest.csharp](https://github.com/Azure/autorest.csharp) generator to output a generated library.  It is important that the input TypeSpec files (*.tsp) should comply with TypeSpec lint rules so the output library is consistent with the Azure SDK Guidelines.

## Prerequisites

The initial library generation should happen as part of the `azure-rest-api-specs` repo PR. Details about this process can be found [here](https://eng.ms/docs/products/azure-developer-experience/develop/sdk-generation-pipelines). To proceed with manual generation, follow the rest of the steps in this doc.

For first time to set up of a new SDK package, please verify you have met the prerequisites, including runtime environment, TypeSpec project, and SDK project folder. You can refer to [SDK Generation Prerequisites](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKGeneration_Prerequistites.md) to set up.

## Generate SDK

We will generate an SDK under the SDK project folder of `azure-sdk-for-net`.

### Configuration

You can update `tsp-location.yaml` under sdk project folder to set the typespec project.

You can refer to the [tsp-location.yaml](https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/TypeSpec-Project-Scripts.md#tsp-locationyaml) which describes the supported properties in the file. For new data plane services, you must set the `emitterPackageJsonPath` property in tsp-location.yaml to `eng/azure-typespec-http-client-csharp-emitter-package.json`. An example can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/tsp-location.yaml#L4).

### Generate Code

Enter `src` sub-directory of sdk project folder, e.g. /home/azure-sdk-for-net/sdk/anomalyDetector/Azure.AI.AnomalyDetector/src
Run `dotnet build /t:GenerateCode`, and the code will be generated under `sdk\<servie name>\<package name>\src\Generated`

```dotnetcli
dotnet build /t:GenerateCode
```

#### Run with tracing enabled
```dotnetcli
dotnet build /t:GenerateCode /p:Trace=true -v d
```

#### Run with additional emitter options
Any of the [emitter options](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp/README.md#emitter-options) can be passed through to the build target
as shown below:
```dotnetcli
dotnet build /t:GenerateCode /p:TypespecAdditionalOptions="debug=true;new-project=true"
```

Now that you have generated your SDK, you can release it by following the following steps:

1. Create a [release plan](https://aka.ms/azsdkdocs/release-plans). It will provide you with a workflow of tasks that you
will need to accomplish to release an SDK. For example, all the neccessary approvals, guidance on testing, release pipeline, and more.
2. [Enhance the SDK](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/Azure_SDK_Package_Ship_Requirements.md).

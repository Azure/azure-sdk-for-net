# Prerequisites

## Runtime Environment

- Install Visual Studio 2022 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
  - Install the **.NET Core cross-platform development** workloads in Visual Studio
- Install **.NET 6.0 SDK** for your specific platform. (or a higher version)
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher.
- Install [NodeJS](https://nodejs.org/) (16.x.x or above).

## Setup Typespec project

Make sure you have typespec project in [azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs) repo or you can follow [Typespec Getting Started](https://github.com/microsoft/typespec/#using-node--npm) to initialize your typespec project, and refer to [Typespec Structure Guidelines](https://github.com/Azure/azure-rest-api-specs/blob/main/documentation/cadl-structure-guidelines.md) to configure your typespec project.

## Setup SDK Project Folder

We will generate SDK library under SDK project folder `sdk\<servie name>\<package name>` of `azure-sdk-for-net` repo. e.g. /home/azure-sdk-for-net/sdk/anomalydetector/Azure.AI.AnomalyDetector).

Make sure that the SDK project folder exists in [azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net) repo. If the SDK project folder does not exist, you can refer to [SDK project directory Set up](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/DataPlaneCodeGeneration/AzureSDKPackage_Setup.md) to create one.

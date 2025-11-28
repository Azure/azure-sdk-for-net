# Prerequisites

## Runtime Environment

- Install Visual Studio 2022 (Community or higher) and make sure you have the [latest updates](https://www.visualstudio.com/).
  - Need at least .NET Framework 4.6.1 and 4.7 development tools
  - Install the **.NET Core cross-platform development** workloads in Visual Studio
- Install **.NET 8.0 SDK** for your specific platform. (or a higher version)
- Install the latest version of [git](https://git-scm.com/downloads)
- Install [PowerShell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell), version 7 or higher.
- Install [NodeJS](https://nodejs.org/) (18.x.x or above).

## Set up TypeSpec project

Make sure you have a TypeSpec project in the `main` branch of the public API specification repository [azure-rest-api-specs](https://github.com/Azure/azure-rest-api-specs). You can find more information about creating an API spec on TypeSpec [here](https://aka.ms/azsdk/typespec).

## Set up SDK Project Folder

You will need to generate the SDK library under an SDK project folder following the repository guidelines. You can use the [Azure.Template](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/template/Azure.Template) as an example.
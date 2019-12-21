# Azure SDK for .NET

[![Packages](https://img.shields.io/badge/packages-latest-blue.svg)](https://azure.github.io/azure-sdk/releases/latest/dotnet.html) [![Dependencies](https://img.shields.io/badge/dependencies-analyzed-blue.svg)](https://azuresdkartifacts.blob.core.windows.net/azure-sdk-for-net/dependencies/dependencies.html)

This repository is intended for active development of the Azure SDK for .NET. For consumers of the SDK we recommend visiting our [public developer docs](https://docs.microsoft.com/en-us/dotnet/azure/) or our versioned [developer docs](https://azure.github.io/azure-sdk-for-net).

## Getting started

To get started with a library, see the README.md file located in the library's project folder. You can find these library folders grouped by service in the /sdk directory.

For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).

## Azure SDK Standard

Historically, the Azure SDK has been just a collection of independent packages. In recent months, we embarked on an effort to transition the SDK from a collection of packages to a well-rounded, consistent, and dependable product. You can read about this effort in a blog post [Previewing Azure SDKs following new Azure SDK API Standards](https://azure.microsoft.com/en-in/blog/previewing-azure-sdks-following-new-azure-sdk-api-standards/). 

This repo contains all Azure SDK libraries for .NET. Some of these libraries have been transitioned to the Azure SDK Standard, i.e. they follow the [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html), and some are awaiting be to transitioned. We will refer to the already transitioned packages as _Azure SDK Standard Libraries_, or _Azure Standard Libraries_, for short. You can see a list of such libraries in the [packages guide](https://github.com/Azure/azure-sdk-for-net/blob/master/PACKAGES.md).   

Azure Standard Libraries offer many qualities described in detail in [Using Azure Standard Libraries](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/AzureStandardLibraries.md). To ensure that Azure Standard Libraries adhere to the design guidelines and maintain their qualities over time, we follow a methodical design and development process described in the [contributing guide](CONTRIBUTING.md).

## Need help?

* For reference documentation visit the [Azure SDK for .NET API Reference](http://aka.ms/net-docs).
* For tutorials, samples, quick starts, and other documentation, go to [Azure for .NET Developers](https://docs.microsoft.com/en-us/dotnet/azure/).
* File an issue via [Github Issues](https://github.com/Azure/azure-sdk-for-net/issues/new/choose).
* Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on StackOverflow using `azure` and `.net` tags.

### Reporting security issues and security bugs

Security issues and bugs should be reported privately, via email, to the Microsoft Security Response Center (MSRC) <secure@microsoft.com>. You should receive a response within 24 hours. If for some reason you do not, please follow up via email to ensure we received your original message. Further information, including the MSRC PGP key, can be found in the [Security TechCenter](https://www.microsoft.com/msrc/faqs-report-an-issue).

## Contributing
For details on contributing to this repository, see the [contributing guide](CONTRIBUTING.md).

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit
https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2FREADME.png)

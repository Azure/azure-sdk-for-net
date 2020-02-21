# Microsoft Azure Keyvault SDK for .NET

The Microsoft Azure Key Vault SDK for .NET allows you to build secure Azure applications that can access secrets, keys, and certificates that a encrypted at rest with hardware security modules.

This directory contains the open source subset of the .NET SDK. For documentation of the 
complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

## Features

- Secrets
    - Create, Read, Update, Delete, and Recover Secrets
    - Backup and Restore Secrets
- Keys
    - Create, Read, Update, Delete, and Recover Keys
    - Import, Backup and Restore Keys
    - Encrypt, Decrypt, Wrap, Unwrap, Sign and Verify cryptographic Key operations 
- Certificates
    - Create, Read, Update, Delete, and Recover Certificates
    - Create, Read, Update, and Delete certificate renewal properties
    - Create, Read, Update, and Delete certificate issuers
- Storage Accounts
    - Add, Read, Update, and Remove Storage Accounts managed by the Key Vault
    - Create, Read, Update, and Delete SAS definitions

## Getting Started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

Please review [Get started with Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-get-started) if you are not familiar with Azure Key Vault.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes. 

## Requirements

- Microsoft Azure Subscription: To call Microsoft Azure services, you need to first [create an account](https://account.windowsazure.com/Home/Index). Sign up for a free trial or use your MSDN subscriber benefits.
- Hosting: To host your .NET code in Microsoft Azure, you additionally need to download the full Microsoft Azure SDK for .NET - which includes packaging,
    emulation, and deployment tools, or use Microsoft Azure Web Sites to deploy ASP.NET web applications.

## Download Packages

- [Microsoft.Azure.KeyVault](https://www.nuget.org/packages/Microsoft.Azure.KeyVault)
- [Microsoft.Azure.KeyVault.Core](https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Core)
- [Microsoft.Azure.KeyVault.WebKey](https://www.nuget.org/packages/Microsoft.Azure.KeyVault.WebKey)
- [Microsoft.Azure.KeyVault.Cryptography](https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Cryptography)
- [Microsoft.Azure.KeyVault.Extensions](https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Extensions)

## Versioning Information

- The Key Vault SDK uses [the semantic versioning scheme.](http://semver.org/)

## Target Frameworks

For information about the target frameworks of the Key Vault SDK, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.

## Prerequisites

The Key Vault Client Library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

## To Build

For information on building the Azure Key Vault SDK, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build).

## Running Tests

Tests for the Azure Key Vault SDK are run in the same manner as the rest of the tests for the Azure SDK for .NET.  For information please see how to [run tests](https://github.com/azure/azure-sdk-for-net#to-run-the-tests).

## Samples

Code samples for the Azure Key Vault SDK are available on [Azure Code Samples](https://azure.microsoft.com/en-us/resources/samples/?sort=0&service=key-vault&platform=dotnet).

## Additional Documentation

* [Azure Key Vault General Documentation](https://docs.microsoft.com/en-us/azure/key-vault/)
* [Azure Key Vault REST API Reference](https://docs.microsoft.com/en-us/rest/api/keyvault/)
* [Azure Key Vault SDK for .NET Documentation](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/key-vault?view=azure-dotnet)
  
## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information 
see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) 
with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fkeyvault%2FMicrosoft.Azure.KeyVault%2FREADME.png)

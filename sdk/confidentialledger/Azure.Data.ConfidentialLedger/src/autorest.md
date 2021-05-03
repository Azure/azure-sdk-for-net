# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.ConfidentialLedger
credential-types: TokenCredential
credential-scopes: "https://confidential-ledger.azure.com/.default"
low-level-client: true
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/f26f6b7fa8a774c505b138d34b861b3d9bd7d07c/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/common.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/f26f6b7fa8a774c505b138d34b861b3d9bd7d07c/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/confidentialledger.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/f26f6b7fa8a774c505b138d34b861b3d9bd7d07c/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/identityservice.json
namespace: Azure.Data.ConfidentialLedger 
include-csproj: disable
```
require: https://github.com/Azure/azure-rest-api-specs/blob/f26f6b7fa8a774c505b138d34b861b3d9bd7d07c/specification/confidentialledger/data-plane/readme.md
tag: package-0.1-preview-ledger
tag: package-0.1-preview-identity

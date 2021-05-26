# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: ConfidentialLedger
namespace: Azure.Storage.ConfidentialLedger 
security: AADToken
security-scopes: "https://confidential-ledger.azure.com/.default"
low-level-client: true
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/e34c5f11d61ca17fdc9fd0f70446dd54b94d67f1/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/common.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/e34c5f11d61ca17fdc9fd0f70446dd54b94d67f1/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/confidentialledger.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/e34c5f11d61ca17fdc9fd0f70446dd54b94d67f1/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/0.1-preview/identityservice.json
```

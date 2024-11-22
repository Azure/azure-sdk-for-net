# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: ConfidentialLedger
operationgroup: confidential-ledger
namespace: Azure.Security.ConfidentialLedger 
security: AADToken
security-scopes: "https://confidential-ledger.azure.com/.default"
keep-non-overloadable-protocol-signature: true
generate-sample-project: false
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/987a8f38ab2a8359d085e149be042267a9ecc66f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/common.json
- https://github.com/Azure/azure-rest-api-specs/blob/987a8f38ab2a8359d085e149be042267a9ecc66f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/confidentialledger.json
- https://github.com/Azure/azure-rest-api-specs/blob/987a8f38ab2a8359d085e149be042267a9ecc66f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/987a8f38ab2a8359d085e149be042267a9ecc66f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/987a8f38ab2a8359d085e149be042267a9ecc66f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerCertificate_"+$.operationId'
```






















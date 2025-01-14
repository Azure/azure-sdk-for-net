# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: ConfidentialLedger
operationgroup: confidential-ledger
namespace: Azure.Security.ConfidentialLedger 
security: AADToken
security-scopes: "https://confidential-ledger.azure.com/.default"
keep-non-overloadable-protocol-signature: true
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/adb20036091c8d853084e62f89e1aecb866254d2/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-01-26-preview/common.json
- https://github.com/Azure/azure-rest-api-specs/blob/adb20036091c8d853084e62f89e1aecb866254d2/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-01-26-preview/confidentialledger.json
- https://github.com/Azure/azure-rest-api-specs/blob/adb20036091c8d853084e62f89e1aecb866254d2/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-01-26-preview/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/adb20036091c8d853084e62f89e1aecb866254d2/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-01-26-preview/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/adb20036091c8d853084e62f89e1aecb866254d2/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-01-26-preview/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerCertificate_"+$.operationId'
```




















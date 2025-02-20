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
- https://github.com/Azure/azure-rest-api-specs/blob/4ae5cdc221660762336d5a899495b2b4941ea486/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/common.json
- https://github.com/Azure/azure-rest-api-specs/blob/4ae5cdc221660762336d5a899495b2b4941ea486/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/confidentialledger.json
- https://github.com/Azure/azure-rest-api-specs/blob/4ae5cdc221660762336d5a899495b2b4941ea486/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/4ae5cdc221660762336d5a899495b2b4941ea486/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/4ae5cdc221660762336d5a899495b2b4941ea486/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-08-22-preview/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerCertificate_"+$.operationId'
```

























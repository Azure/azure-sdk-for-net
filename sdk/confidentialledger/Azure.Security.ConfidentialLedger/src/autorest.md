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
- https://github.com/Azure/azure-rest-api-specs/blob/763a27e7970d84740beef0bb6756375f77670c3a/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/common.json
- https://github.com/Azure/azure-rest-api-specs/blob/763a27e7970d84740beef0bb6756375f77670c3a/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/confidentialledger.json
- https://github.com/Azure/azure-rest-api-specs/blob/763a27e7970d84740beef0bb6756375f77670c3a/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/763a27e7970d84740beef0bb6756375f77670c3a/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/763a27e7970d84740beef0bb6756375f77670c3a/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerCertificate_"+$.operationId'
```
























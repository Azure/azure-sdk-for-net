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
- https://github.com/Azure/azure-rest-api-specs/blob/fd6d7550dbc964fb2238de5e41de48c860fa66f5/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/common.json
- https://github.com/Azure/azure-rest-api-specs/blob/fd6d7550dbc964fb2238de5e41de48c860fa66f5/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/confidentialledger.json
- https://github.com/Azure/azure-rest-api-specs/blob/fd6d7550dbc964fb2238de5e41de48c860fa66f5/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/fd6d7550dbc964fb2238de5e41de48c860fa66f5/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/fd6d7550dbc964fb2238de5e41de48c860fa66f5/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2024-12-09-preview/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerCertificate_"+$.operationId'
```
























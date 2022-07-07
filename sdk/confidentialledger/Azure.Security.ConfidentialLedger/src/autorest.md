# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: ConfidentialLedger
operationgroup: confidential-ledger
namespace: Azure.Security.ConfidentialLedger 
security: AADToken
security-scopes: "https://confidential-ledger.azure.com/.default"
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/37cd8dfac3c570a24bb645b31c012d12efb760df/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/stable/2022-05-13/common.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/37cd8dfac3c570a24bb645b31c012d12efb760df/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/stable/2022-05-13/confidentialledger.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/37cd8dfac3c570a24bb645b31c012d12efb760df/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/stable/2022-05-13/identityservice.json
```

``` yaml
directive:
  - from: https://github.com/Azure/azure-rest-api-specs/blob/37cd8dfac3c570a24bb645b31c012d12efb760df/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/stable/2022-05-13/confidentialledger.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedger_"+$.operationId'
  - from: https://github.com/Azure/azure-rest-api-specs/blob/37cd8dfac3c570a24bb645b31c012d12efb760df/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/stable/2022-05-13/identityservice.json
    where: '$..paths.*.*'
    transform: '$.operationId = "ConfidentialLedgerIdentityService_"+$.operationId'
```

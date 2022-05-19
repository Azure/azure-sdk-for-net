# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: ConfidentialLedger
namespace: Azure.Security.ConfidentialLedger 
security: AADToken
security-scopes: "https://confidential-ledger.azure.com/.default"
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/c24e31390f7bde23664f43190d9184f5fbbbd24f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2022-20-04-preview/common.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/c24e31390f7bde23664f43190d9184f5fbbbd24f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2022-20-04-preview/confidentialledger.json
    -  https://github.com/Azure/azure-rest-api-specs/blob/c24e31390f7bde23664f43190d9184f5fbbbd24f/specification/confidentialledger/data-plane/Microsoft.ConfidentialLedger/preview/2022-20-04-preview/identityservice.json
directive:
# only for simplify apiview for arch board review
  - from: confidentialledger.json
    where: $.parameters.CollectionIdParameter
    transform: >
      $["x-ms-client-name"] = "subLedgerId";
```

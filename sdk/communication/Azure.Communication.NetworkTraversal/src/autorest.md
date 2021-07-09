# Azure.Communication.NetworkTraversal

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Network traversal
tag: package-2021-02-22-preview1
model-namespace: false
require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/60be518b4fa1a9fb011a0cb69ae7ca3e1cee06b1/specification/communication/data-plane/Microsoft.CommunicationServicesTurn/readme.md
payload-flattening-threshold: 3
```

### Rename OperationId to for RestClient rename

```yaml
directive:
  from: swagger-document
  where: '$.paths["/turn/{id}/:issueCredentials"].post'
  transform: >
    $["operationId"] = "CommunicationNetworkTraversal_IssueTurnCredentials";
```

### Directive renaming "CommunicationTurnCredentialsResponse" model to "CommunicationRelayConfiguration"

```yaml
directive:
  from: swagger-document
  where: $.definitions.CommunicationTurnCredentialsResponse
  transform: >
    $["x-ms-client-name"] = "CommunicationRelayConfiguration";
```

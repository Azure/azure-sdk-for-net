# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
openapi-type: data-plane
tag: package-heavy-metal-demo
model-namespace: false

require:
     - https://github.com/williamzhao87/azure-rest-api-specs/blob/366f31cb260cb6c0ef4c8964440e9fee25bdf39f/specification/communication/data-plane/CallAutomation/readme.md
input-file:
    - ./swagger.json
title: Azure Communication Services

generation1-convenience-client: true

csharp:
  azure-arm: true
  license-header: MICROSOFT_MIT_NO_VERSION
  payload-flattening-threshold: 1
  clear-output-folder: true
  client-side-validation: false
  namespace: Azure.Communication.CallAutomation
  output-folder: $(csharp-sdks-folder)/communication/Azure.Communication.CallAutomation/src/Generated
```

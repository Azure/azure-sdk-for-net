# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
openapi-type: data-plane
tag: package-heavy-metal-demo
model-namespace: false

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

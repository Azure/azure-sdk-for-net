# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-01-15-preview

require:
     - https://github.com/williamzhao87/azure-rest-api-specs/blob/6dc8fd8d9756d21e747bdecf2df436c8100b14ca/specification/communication/data-plane/CallAutomation/readme.md
title: Azure Communication Services

generation1-convenience-client: true
```

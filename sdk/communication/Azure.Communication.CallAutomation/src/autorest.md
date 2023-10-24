# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-01-15-preview

require:
    - https://github.com/calvinkwtang/azure-rest-api-specs/blob/84649fd68a42f96f388ee2687bcce193db30173c/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

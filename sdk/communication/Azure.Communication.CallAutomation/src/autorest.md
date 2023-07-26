# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-01-15-preview

require:
    - https://github.com/williamzhao87/azure-rest-api-specs/blob/0a316f5346cf6dc37200403d6b20e2400157721c/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

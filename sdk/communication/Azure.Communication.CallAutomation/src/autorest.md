# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-01-15-preview

require:
    - https://github.com/juntuchen-msft/azure-rest-api-specs/blob/b864baedacd9c5dd6ecbe4ce3b8bf9cf817a4c8d/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

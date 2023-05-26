# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-03-06
model-namespace: false
tag: package-2023-01-15-preview

require:
     - https://github.com/Azure/azure-rest-api-specs/blob/7f115517cc6d5c57ee8a89b9ba4187f937bfe6dc/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

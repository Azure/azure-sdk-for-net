# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-06-15-preview
model-namespace: false
tag: package-2023-01-15-preview

require:
     - https://github.com/Azure/azure-rest-api-specs/blob/7e1589a49816226d7798922757bff4357286219d/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

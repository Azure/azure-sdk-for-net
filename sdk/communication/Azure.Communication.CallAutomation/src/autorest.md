# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-10-03-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/96a893225c84abe380a059b5e9bf54b0273d770e/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-10-03-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/a724210a4ebd3df91c49f00e6662c70b4a5cac21/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

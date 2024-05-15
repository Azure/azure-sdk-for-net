# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-06-15-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/2c0eb12fe6bbd0f30424c1e32427f2f8c3c3d14e/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2025-08-15-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/f443aa6185a8b5dd55d35f7d8ba7398cd926b934/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

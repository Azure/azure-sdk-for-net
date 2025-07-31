# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2025-08-15-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/3d5a5cdd98abce7301224dc6a3c2ff6303f9ef0f/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

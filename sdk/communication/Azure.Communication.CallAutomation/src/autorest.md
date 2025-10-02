# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-09-01-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/97209ee6c07fbb540b4afdfed2e1ebb2fa384169/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-01-22-preview

require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/011c16df70c3ed345bf7649c2019119cb1bfd802/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

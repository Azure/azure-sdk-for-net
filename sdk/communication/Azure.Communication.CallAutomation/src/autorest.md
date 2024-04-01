# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-10-03-preview

require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/main/specification/communication/data-plane/Chat/preview/2024-03-15-preview/communicationserviceschat.json


title: Azure Communication Services

generation1-convenience-client: true
```

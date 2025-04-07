# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2025-03-30-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/57c4594b63c2db1c687bec16bafff3b6c1389a46/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

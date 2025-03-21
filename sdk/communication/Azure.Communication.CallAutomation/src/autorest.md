# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2024-11-15-preview

require:
    - https://github.com/Azure/azure-rest-api-specs/blob/8fb53913852ecf612c803f4dbe07b4f9f65bea88/specification/communication/data-plane/CallAutomation/readme.md


title: Azure Communication Services

generation1-convenience-client: true
```

# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-01-15-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/williamzhao87/azure-rest-api-specs/dev-communication-CallAutomation-v4-2023-01-15/specification/communication/data-plane/CallAutomation/readme.md

generation1-convenience-client: true
```

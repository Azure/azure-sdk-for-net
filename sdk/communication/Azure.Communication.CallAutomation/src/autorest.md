# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2022-04-07-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/ac4677cd31042657c21bf40e0506c7c2752bbe70/specification/communication/data-plane/CallAutomation/readme.md

generation1-convenience-client: true
```

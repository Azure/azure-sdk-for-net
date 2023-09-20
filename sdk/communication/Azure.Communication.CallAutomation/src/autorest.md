# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
tag: package-2023-01-15-preview

require:
    - https://github.com/cochi2/azure-rest-api-specs/blob/165e9bcec8bcd7d2085df5fa0cd6a7e8f587caa1/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-10-15
model-namespace: false

require:
     - https://github.com/Azure/azure-rest-api-specs/blob/f97b5a33604873c440f582bb2b35a1b6849e034c/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true
```

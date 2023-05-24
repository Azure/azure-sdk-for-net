# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-03-06
model-namespace: false

require:
     - https://github.com/Azure/azure-rest-api-specs/blob/e669e3594775698f825dad6e0a47972adc0cbf70/specification/communication/data-plane/CallAutomation/readme.md

title: Azure Communication Services

generation1-convenience-client: true

```

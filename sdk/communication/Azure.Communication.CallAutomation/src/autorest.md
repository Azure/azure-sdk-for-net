# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-01-15-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/williamzhao87/azure-rest-api-specs/306db405794c1e9edc3609f2d0656a675f165eb9/specification/communication/data-plane/CallAutomation/preview/2023-01-15-preview/communicationservicescallautomation.json

generation1-convenience-client: true
modelerfour:
  lenient-model-deduplication: true

```

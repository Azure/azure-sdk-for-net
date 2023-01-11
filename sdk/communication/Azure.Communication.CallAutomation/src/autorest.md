# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-01-15-preview
model-namespace: false

require:
    - https://raw.githubusercontent.com/cochi2/azure-rest-api-specs/2be402f0f7bc8194a4522253d4d35d44f3c2e725/specification/communication/data-plane/CallAutomation/readme.md
title: Azure Communication Services

generation1-convenience-client: true

```

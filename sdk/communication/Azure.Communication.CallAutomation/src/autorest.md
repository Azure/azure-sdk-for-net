# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-01-15-preview
model-namespace: false

require:
    - https://raw.githubusercontent.com/williamzhao87/azure-rest-api-specs/28020b4e9a0479f5dff0026abad47bd01a74d7f9/specification/communication/data-plane/CallAutomation/readme.md
title: Azure Communication Services

generation1-convenience-client: true

```

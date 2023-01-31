# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
tag: package-2023-01-15-preview
model-namespace: false

require:
    - https://raw.githubusercontent.com/williamzhao87/azure-rest-api-specs/1fcceb1785e063e75b88436d18b56a04c04dc58d/specification/communication/data-plane/CallAutomation/readme.md
title: Azure Communication Services

generation1-convenience-client: true

```

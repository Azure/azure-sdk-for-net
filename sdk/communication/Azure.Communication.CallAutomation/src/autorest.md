# Azure.Communication.CallAutomation

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
openapi-type: data-plane
tag: package-2023-01-15-preview

input-file:
    -  $(this-folder)/Swagger/swagger.yaml

clear-output-folder: true
title: Azure Communication Services
model-namespace: false


generation1-convenience-client: true
```

# Azure.Communication.ServerCalling

From Folder that contains autorest.md, Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

```yaml
model-namespace: false
openapi-type: data-plane
title:
  Server Calling
input-file:
    -  $(this-folder)/Swagger/2022-04-07.json
payload-flattening-threshold: 10
generation1-convenience-client: true
```

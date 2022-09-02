# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
title: DeviceUpdate

input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d7c9be23749467be1aea18f02ba2f4948a39db6a/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/stable/2022-10-01/deviceupdate.json

namespace: Azure.IoT.DeviceUpdate
security: AADToken
security-scopes:  https://api.adu.microsoft.com/.default
```

### Fix 304s
``` yaml
directive:
- from: swagger-document
  where: $["paths"]["/deviceUpdate/{instanceId}/updates/providers/{provider}/names/{name}/versions/{version}"]
  transform: >
    $.get.responses["304"] = {
      "description": "The condition specified using HTTP conditional header(s) is not met."
    };
- from: swagger-document
  where: $["paths"]["/deviceUpdate/{instanceId}/updates/providers/{provider}/names/{name}/versions/{version}/files/{fileId}"]
  transform: >
    $.get.responses["304"] = {
      "description": "The condition specified using HTTP conditional header(s) is not met."
    };
- from: swagger-document
  where: $["paths"]["/deviceUpdate/{instanceId}/updates/operations/{operationId}"]
  transform: >
    $.get.responses["304"] = {
      "description": "The condition specified using HTTP conditional header(s) is not met."
    };
- from: swagger-document
  where: $["paths"]["/deviceUpdate/{instanceId}/management/operations/{operationId}"]
  transform: >
    $.get.responses["304"] = {
      "description": "The condition specified using HTTP conditional header(s) is not met."
    };
```

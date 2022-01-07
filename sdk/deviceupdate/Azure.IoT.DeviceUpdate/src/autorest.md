# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
title: DeviceUpdate
input-file: https://github.com/Azure/azure-rest-api-specs/blob/23dc68e5b20a0e49dd3443a4ab177d9f2fcc4c2b/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2021-06-01-preview/deviceupdate.json
namespace: Azure.IoT.DeviceUpdate
low-level-client: true
security: AADToken
security-scopes:  https://api.adu.microsoft.com/.default
```

# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
title: DeviceUpdate

input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5ee062ac3cc2df298ff47bdfc7792d257fd85bb8/specification/deviceupdate/data-plane/Microsoft.DeviceUpdate/preview/2022-07-01-preview/deviceupdate.json

namespace: Azure.IoT.DeviceUpdate
security: AADToken
security-scopes:  https://api.adu.microsoft.com/.default
```

# Azure.IoT.DeviceUpdate

Run `generate.ps1` or `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
title: DeviceUpdate

input-file: E:\Sdk\azure-rest-api-specs\specification\deviceupdate\data-plane\Microsoft.DeviceUpdate\stable\2022-10-01\deviceupdate.json

namespace: Azure.IoT.DeviceUpdate
security: AADToken
security-scopes:  https://api.adu.microsoft.com/.default
```

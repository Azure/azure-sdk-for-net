# Azure.Communication.SipRouting
Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/01563419f540c27a96abae75f9feaa3e5e9a1f13/specification/communication/data-plane/SipRouting/readme.md
tag: package-sip-2021-05-01
output-folder: ./Generated
namespace: Azure.Communication.SipRouting
no-namespace-folders: true
license-header: MICROSOFT_MIT_NO_VERSION
enable-xml: true
clear-output-folder: true
csharp: true
v3: true
no-async: false
add-credential: false
title: Azure Communication SIP Routing Service
disable-async-iterators: true
```

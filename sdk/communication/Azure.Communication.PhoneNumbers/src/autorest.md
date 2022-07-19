# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-11-30
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/86e3685f599833ce0a187294cb07d0c2b8a8d001/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

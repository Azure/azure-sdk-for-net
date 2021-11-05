# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2021-03-07
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/896d05e37dbb00712726620b8d679cc3c3be09fb/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
```
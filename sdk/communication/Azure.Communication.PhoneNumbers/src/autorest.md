# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-01-11-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/lucasrsant/azure-rest-api-specs/2bf34da7c005f8ea28d531a30bea2017e617bbcc/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
```
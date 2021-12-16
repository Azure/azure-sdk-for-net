# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-01-11-preview2
model-namespace: false
require:
    -  https://raw.githubusercontent.com/lucasrsant/azure-rest-api-specs/9b0f1d9a7c30833afc1a3302b5a3eaba194d96e4/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
```
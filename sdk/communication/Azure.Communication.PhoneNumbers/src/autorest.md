# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-07-31-preview3
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/3d2c1f210ad1a7fe50cdc561e81b8c88bf7f0648/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

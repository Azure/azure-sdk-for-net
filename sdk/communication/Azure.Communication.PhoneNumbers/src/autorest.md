# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-11-30
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c24836060a7ac3aa6e6d4eb64d4c69ef801bb9cb/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

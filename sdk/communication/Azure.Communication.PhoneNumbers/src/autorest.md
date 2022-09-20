# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-01-11-preview2
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/02fce64677f78021ba70d69bb8bd0d916d653927/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2022-07-31-preview3
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/04dea11dca267e61723e7085d89c776371dfcb2e/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

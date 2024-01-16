# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-preview-2024-01
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a443d2d3c562d91419d11bed6326b5907d38848c/specification/communication/data-plane/PhoneNumbers/readme.md
title: Phone numbers
payload-flattening-threshold: 3
generation1-convenience-client: true
```

### Change naming of countryCode to twoLetterIsoCountryName
``` yaml
directive:
  from: swagger-document
  where: $.paths.*.get.parameters[?(@.name == "countryCode")]
  transform: >
    $["x-ms-client-name"] = "twoLetterIsoCountryName";
```

``` yaml
directive:
  from: swagger-document
  where: $.paths.*.post.parameters[?(@.name == "countryCode")]
  transform: >
    $["x-ms-client-name"] = "twoLetterIsoCountryName";
```

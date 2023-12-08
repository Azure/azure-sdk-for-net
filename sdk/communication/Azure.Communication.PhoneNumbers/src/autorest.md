# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2023-10-01-preview
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5e9b69aec73f012cd7a9ebfe2c2ff7a65aa4c189/specification/communication/data-plane/PhoneNumbers/readme.md
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

### Removed Property error from PhoneNumberSearchResult
``` yaml
directive:
  where-model: PhoneNumberSearchResult
  remove-property: error
```

### Removed Property errorCode from PhoneNumberSearchResult
``` yaml
directive:
  where-model: PhoneNumberSearchResult
  remove-property: errorCode
```
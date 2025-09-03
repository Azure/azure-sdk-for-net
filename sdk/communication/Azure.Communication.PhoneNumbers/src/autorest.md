# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2025-06-01
model-namespace: false
require:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/14800a01400c295af0bfa5886e5f4042e4f6c62e/specification/communication/data-plane/PhoneNumbers/readme.md
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

``` yaml
directive:
  from: swagger-document
  where: $.definitions.PhoneNumberSearchResult.properties.error.x-ms-enum
  transform: >
    $["name"] = "PhoneNumberSearchResultError";
```

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: >
    $["format"] = "";
```

### Set remove-empty-child-schemas
```yaml
modelerfour:
    remove-empty-child-schemas: true
```

### Rename AvailablePhoneNumberStatus to PhoneNumberAvailabilityStatus
```yaml
directive:
  from: swagger-document
  where: $.definitions.AvailablePhoneNumber.properties.status.x-ms-enum
  transform: >
    $["name"] = "PhoneNumberAvailabilityStatus";
```

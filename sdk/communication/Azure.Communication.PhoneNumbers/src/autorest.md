# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-preview-2024-01
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/9cdbbefb7f5c024d0c54977669018ec310100ffa/specification/communication/data-plane/PhoneNumbers/readme.md
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
### Change naming of Error to ErrorMessage
``` yaml
directive:
  from: swagger-document
  where: "$.definitions.PhoneNumberSearchResult.properties.error"
  transform: >
    $["x-ms-enum"].name = "ErrorMessage";
```

### Change naming of PhoneNumberBrowseCapabilitiesRequest to PhoneNumberBrowseCapabilitiesContent
``` yaml
directive:
  from: swagger-document
  where: "$.definitions.PhoneNumberBrowseCapabilitiesRequest"
  transform: >
    $["x-ms-client-name"] = "PhoneNumberBrowseCapabilitiesContent";
```


### Change naming of PhoneNumbersBrowseRequest to PhoneNumbersBrowseContent
``` yaml
directive:
  from: swagger-document
  where: "$.definitions.PhoneNumbersBrowseRequest"
  transform: >
    $["x-ms-client-name"] = "PhoneNumbersBrowseContent";
```

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: >
    $["format"] = "";
```

# Removed Models
``` yaml
directive:
  from: swagger-document
  where: $.definitions.PhoneNumberSearchResult.properties.error.x-ms-enum
  transform: >
    $["x-ms-enum"].name = "ErrorMessage";
```

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: >
    $["format"] = "";
```

# Removed Models
``` yaml
directive:
  - remove-operation-match: /.*Reservation.*/i
  - remove-operation: PhoneNumbers_BrowseAvailableNumbers
  - remove-model: PhoneNumbersReservation
  - remove-model: PhoneNumbersReservations
  - remove-model: PhoneNumbersBrowseRequest
  - remove-model: PhoneNumbersBrowseResult
  - remove-model: PhoneNumberBrowseCapabilitiesRequest
  - remove-model: PhoneNumbersReservationPurchaseRequest
  - remove-model: Error
  - remove-model: AvailablePhoneNumber
  - remove-model: AvailablePhoneNumberCost

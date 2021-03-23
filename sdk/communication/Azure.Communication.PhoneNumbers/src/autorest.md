# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/1ef769ae890b5f5a952f9ba6e46e0ef6d38241da/specification/communication/data-plane/Microsoft.CommunicationServicesPhoneNumbers/stable/2021-03-07/phonenumbers.json
title: Phone numbers
payload-flattening-threshold: 3
```

### Move all the models to the main namespace
```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.PhoneNumbers"
```

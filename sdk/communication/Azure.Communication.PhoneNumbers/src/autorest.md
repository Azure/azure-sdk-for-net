# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
tag: package-phonenumber-2021-03-07
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/bf081421869ccd31d9fd87084b07a1e246aee310/specification/communication/data-plane/Microsoft.CommunicationServicesPhoneNumbers/readme.md
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

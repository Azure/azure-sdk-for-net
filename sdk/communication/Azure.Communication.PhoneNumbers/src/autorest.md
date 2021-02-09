# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8d209ae9b7bd6248b31e0cf0b1a8474a0c6d6297/specification/communication/data-plane/Microsoft.CommunicationServicesPhoneNumbers/stable/2021-03-07/phonenumbers.json
title: Phone number administration
payload-flattening-threshold: 3
```

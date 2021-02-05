# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b61f429d7eb88579c8e37ee8025687571280f235/specification/communication/data-plane/Microsoft.CommunicationServicesAdministration/stable/2021-03-07/phonenumbers.json
title: Phone number administration
payload-flattening-threshold: 3
```

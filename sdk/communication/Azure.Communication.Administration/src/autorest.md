# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/257f060be8b60d8468584682aa2d71b1faa5f82c/specification/communication/data-plane/Microsoft.CommunicationServicesAdministration/preview/2020-07-20-preview1/communicationservicesadministration.json
title: Phone number administration
payload-flattening-threshold: 3
```
``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/084de2711f77d12d644c7628b61cdd7634341ee8/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/stable/2021-03-07/CommunicationIdentity.json
title: Communication identity
payload-flattening-threshold: 3
```

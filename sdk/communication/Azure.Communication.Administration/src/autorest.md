# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  ./swagger/phonenumbers.json
title: Phone number administration
payload-flattening-threshold: 3
```
``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/084de2711f77d12d644c7628b61cdd7634341ee8/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/stable/2021-03-07/CommunicationIdentity.json
title: Communication identity
payload-flattening-threshold: 3
```

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
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/838c5092f11e8ca26e262b1f1099d5c5cdfedc3f/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/preview/2020-07-20-preview2/CommunicationIdentity.json
title: Communication identity
payload-flattening-threshold: 3
```

# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/257f060be8b60d8468584682aa2d71b1faa5f82c/specification/communication/data-plane/Microsoft.CommunicationServicesAdministration/preview/2020-07-20-preview1/communicationservicesadministration.json
payload-flattening-threshold: 3
```
``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/838c5092f11e8ca26e262b1f1099d5c5cdfedc3f/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/preview/2020-07-20-preview2/CommunicationIdentity.json
payload-flattening-threshold: 3
```

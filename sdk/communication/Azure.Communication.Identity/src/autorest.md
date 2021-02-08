# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
#    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5b19c6e69cd2bb9dbe4e5c1237b2c5a175d90ca5/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/stable/2021-03-07/CommunicationIdentity.json
    - https://github.com/apattath/azure-rest-api-specs/blob/fd8b27c1124b5f371966045c25a4402fb7b558cd/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/preview/2021-02-22-preview1/CommunicationIdentity.json
    - https://github.com/apattath/azure-rest-api-specs/blob/fd8b27c1124b5f371966045c25a4402fb7b558cd/specification/communication/data-plane/Microsoft.CommunicationServicesTurn/preview/2021-02-22-preview1/CommunicationTurn.json
payload-flattening-threshold: 3
```

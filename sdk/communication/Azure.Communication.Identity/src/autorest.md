# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
#    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5b19c6e69cd2bb9dbe4e5c1237b2c5a175d90ca5/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/stable/2021-03-07/CommunicationIdentity.json
#    -  https://github.com/apattath/azure-rest-api-specs/blob/08ac674efacce0ae35371f8b1d8c45b5a1420503/specification/communication/data-plane/Microsoft.CommunicationServicesTurn/preview/2021-02-22-preview1/CommunicationTurn.json
#    - https://github.com/apattath/azure-rest-api-specs/blob/9edffc88b87fdc90a4d339a0b49487d611304c6f/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/stable/2021-03-07/CommunicationIdentity.json
#    - https://github.com/apattath/azure-rest-api-specs/blob/9edffc88b87fdc90a4d339a0b49487d611304c6f/specification/communication/data-plane/Microsoft.CommunicationServicesTurn/preview/2021-02-22-preview1/CommunicationTurn.json
    -  ./swaggers/CommunicationIdentity.json
    -  ./swaggers/CommunicationTurn.json
payload-flattening-threshold: 3
```

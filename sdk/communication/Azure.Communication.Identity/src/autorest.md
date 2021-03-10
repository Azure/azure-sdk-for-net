# Azure.Communication.Identity

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/66f033f54d45a3409e0f6493a5396be8480c2449/specification/communication/data-plane/Microsoft.CommunicationServicesIdentity/preview/2021-02-22-preview1/CommunicationIdentity.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/66f033f54d45a3409e0f6493a5396be8480c2449/specification/communication/data-plane/Microsoft.CommunicationServicesTurn/preview/2021-02-22-preview1/CommunicationTurn.json
payload-flattening-threshold: 3
```

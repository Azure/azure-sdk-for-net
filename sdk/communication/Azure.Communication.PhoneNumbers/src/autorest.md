# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e23190a5bc64cd8526d08b6c2c1d616939bc88b3/specification/communication/data-plane/Microsoft.CommunicationServicesPhoneNumbers/stable/2021-03-07/phonenumbers.json
title: Phone number administration
payload-flattening-threshold: 3
```

# Azure.Communication.Administration

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
public-clients: true
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/6213acd678806cf094061e1caf9b4ecff065642b/specification/communication/data-plane/Microsoft.CommunicationServicesPhoneNumbers/stable/2021-03-07/phonenumbers.json
title: Phone number administration
payload-flattening-threshold: 3
```

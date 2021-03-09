# Azure.Communication.PhoneNumbers

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration

> see https://aka.ms/autorest

```yaml
public-clients: true
tag: package-phonenumber-2021-03-07
require:
    - https://github.com/JoshuaLai/azure-rest-api-specs/blob/85f3acf2ca9c8dd0da721e98c7e1b9fd2a447155/specification/communication/data-plane/readme.md
title: Phone numbers
payload-flattening-threshold: 3
```

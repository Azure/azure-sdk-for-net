# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/e01d8afe9be7633ed36db014af16d47fec01f737/specification/appconfiguration/data-plane/Microsoft.AppConfiguration/stable/1.0/appconfiguration.json
namespace: Azure.Data.AppConfiguration
title: ConfigurationClient
public-clients: true
```

### Change Endpoint type to Uri
``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
  ```

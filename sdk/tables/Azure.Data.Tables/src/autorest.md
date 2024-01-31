# Azure.Data.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.Tables
tag: package-2019-02
azure-validator: false
require:
    - https://github.com/Azure/azure-rest-api-specs/blob/2df8b07bf9af7c96066ca4dda21b79297307d108/specification/cosmos-db/data-plane/readme.md
namespace: Azure.Data.Tables
generation1-convenience-client: true
include-csproj: disable
modelerfour:
  seal-single-value-enum-by-default: true
protocol-method-list:
  - Table_Delete
  - Table_QueryEntityWithPartitionAndRowKey
  - Table_Create
```

### Add nullable annotations

``` yaml
directive:
  from: swagger-document
  where: $.definitions.SignedIdentifier
  transform: >
    $.properties.AccessPolicy["x-nullable"] = true;
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AccessPolicy
  transform: >
    $.properties.Start["x-nullable"] = true;
    $.properties.Expiry["x-nullable"] = true;
    $.properties.Permission["x-nullable"] = true;
```

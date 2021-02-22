# Azure.Data.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.Tables
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/2df8b07bf9af7c96066ca4dda21b79297307d108/specification/cosmos-db/data-plane/readme.md
namespace: Azure.Data.Tables
include-csproj: disable
```

### Fix Response type for QueryEntitiesWithPartitionAndRowKey

``` yaml
directive:
  from: swagger-document
  where: $.paths["/{table}(PartitionKey='{partitionKey}',RowKey='{rowKey}')"].get.responses
  transform: >
    $["200"].schema.$ref = "#/definitions/TableEntityProperties"
```
a

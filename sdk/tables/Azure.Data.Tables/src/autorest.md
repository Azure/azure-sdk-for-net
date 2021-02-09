# Azure.Data.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.Tables
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/bda39d9be69b9e838eb41e5b71964a567a627cbc/specification/cosmos-db/data-plane/Microsoft.Tables/preview/2019-02-02/table.json
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

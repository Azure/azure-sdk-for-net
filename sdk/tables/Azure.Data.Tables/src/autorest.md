# Azure.Data.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.Tables
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/33c52e4f87f3ae21611d45f34db65f9ccc510ea6/specification/cosmos-db/data-plane/Microsoft.Tables/preview/2019-02-02/table.json
namespace: Azure.Data.Tables
include-csproj: disable
```

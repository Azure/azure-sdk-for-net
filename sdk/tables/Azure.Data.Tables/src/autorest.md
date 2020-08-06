# Azure.Data.Tables

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` to generate code.

``` yaml
title: Azure.Data.Tables
input-file:
    - $(this-folder)/swagger/table.json
namespace: Azure.Data.Tables
include-csproj: disable
```

The direct swagger file reference is temporary until the following issue is addressed https://github.com/Azure/azure-sdk-for-net/issues/13559

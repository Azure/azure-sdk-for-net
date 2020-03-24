# Azure.Search Code Generation

Run ` dotnet msbuild /t:GenerateCode` to generate code.

## AutoRest Configuration
> see https://aka.ms/autorest

```yaml
title: Azure.Management.Storage
require: $(this-folder)/../../readme.md
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/blob.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/file.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/storage/resource-manager/Microsoft.Storage/stable/2019-06-01/storage.json
namespace: Azure.Management.Storage
payload-flattening-threshold: 2
```

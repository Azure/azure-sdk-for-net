# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - $(this-folder)/swagger/rbac.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```

Note the input file should be restored to 
the below path pending a service fix.
https://raw.githubusercontent.com/Azure/azure-rest-api-specs/001730d4c5b19d69b1edf43894a1e931f9591e58/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2/rbac.json

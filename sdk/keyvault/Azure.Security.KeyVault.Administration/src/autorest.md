# Azure.Security.KeyVault.Administration

## AutoRest Configuration

> See https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b7d6b00a7f388f048772ea249114a63773312538/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.3-preview/rbac.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b7d6b00a7f388f048772ea249114a63773312538/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.3-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```

## Swagger customization

These changes should eventually be included in the swagger or at least centralized in Azure/azure-rest-api-specs.

### Ignore 404s for DELETE operations

Treat HTTP 404 responses for DELETE operations for RBAC as non-errors.

``` yaml
directive:
- where-operation: RoleAssignments_Delete
  transform: >
    $.responses["404"] = {
        "description": "The resource to delete does not exist.",
        "x-ms-error-response": false
    };

- where-operation: RoleDefinitions_Delete
  transform: >
    $.responses["404"] = {
        "description": "The resource to delete does not exist.",
        "x-ms-error-response": false
    };
```

### Return void for DELETE operations

Do not parse response bodies unnecessarily.

``` yaml
directive:
- where-operation: RoleAssignments_Delete
  transform: >
    delete $.responses["200"].schema;

- where-operation: RoleDefinitions_Delete
  transform: >
    delete $.responses["200"].schema;
```

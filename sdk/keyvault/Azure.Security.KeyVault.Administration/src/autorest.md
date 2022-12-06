# Azure.Security.KeyVault.Administration

## AutoRest Configuration

> See https://aka.ms/autorest

Run `dotnet build /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d78681a9d322bbd8d33ecaad7e6aaa2d513513b4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.4-preview.1/rbac.json
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d78681a9d322bbd8d33ecaad7e6aaa2d513513b4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.4-preview.1/backuprestore.json
- https://raw.githubusercontent.com/Azure/azure-rest-api-specs/d78681a9d322bbd8d33ecaad7e6aaa2d513513b4/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.4-preview.1/settings.json
namespace: Azure.Security.KeyVault.Administration
generation1-convenience-client: true
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

#### Specify client name for settings operations

``` yaml
directive:
- rename-operation:
    from: UpdateSetting
    to: Settings_UpdateSetting
- rename-operation:
    from: GetSetting
    to: Settings_GetSetting
- rename-operation:
    from: GetSettings
    to: Settings_GetSettings
```

#### Fix GetSettings response based actual response

See https://github.com/Azure/azure-rest-api-specs/issues/21334

``` yaml
directive:
- where-model: SettingsListResult
  rename-property:
    from: value
    to: settings
```

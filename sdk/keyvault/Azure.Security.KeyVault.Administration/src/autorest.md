# Azure.Security.KeyVault.Administration

### AutoRest Configuration
> see https://aka.ms/autorest

Run `dotnet msbuild /t:GenerateCode` in src directory to re-generate.

``` yaml
title: Azure.Security.KeyVault.Administration
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0902e37d8806dc8f5d7866a9960581e366f5f5b3/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/rbac.json
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/0902e37d8806dc8f5d7866a9960581e366f5f5b3/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/backuprestore.json
namespace: Azure.Security.KeyVault.Administration
include-csproj: disable
```

## Swagger hacks
These should eventually be fixed in the swagger files. See Azure/azure-rest-api-specs#10262

### Add "x-nullable": true to FullBackupOperation.endTime
``` yaml
directive:
- from: backuprestore.json
  where: $.definitions["FullBackupOperation"]["properties"].endTime
  transform: >
    return {
        "type": "integer",
        "format": "unixtime",
        "description": "The end time of the backup operation in UTC",
        "x-nullable": true
    };
```

### Add "x-nullable": true to RestoreOperation.endTime
``` yaml
directive:
- from: backuprestore.json
  where: $.definitions["RestoreOperation"]["properties"].endTime
  transform: >
    return {
        "type": "integer",
        "format": "unixtime",
        "description": "The end time of the restore operation in UTC",
        "x-nullable": true
    };
```

### Add "x-nullable": true to SelectiveKeyRestoreOperation.endTime
``` yaml
directive:
- from: backuprestore.json
  where: $.definitions["SelectiveKeyRestoreOperation"]["properties"].endTime
  transform: >
    return {
        "type": "integer",
        "format": "unixtime",
        "description": "The end time of the restore operation in UTC",
        "x-nullable": true
    };
```

### Add "x-nullable": true to the Error property
``` yaml
directive:
- from: common.json
  where: $.definitions["Error"]
  transform: >
    return {
        "properties": {
        "code": {
          "type": "string",
          "readOnly": true,
          "description": "The error code."
        },
        "message": {
          "type": "string",
          "readOnly": true,
          "description": "The error message."
        },
        "innererror": {
          "x-ms-client-name": "innerError",
          "readOnly": true,
          "$ref": "#/definitions/Error"
        }
      },
      "description": "The key vault server error.",
      "x-nullable": true
    };
```

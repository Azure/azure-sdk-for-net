# Azure SDK Code Generation for Data Plane

Run `dotnet build /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/1e7b408f3323e7f5424745718fe62c7a043a2337/specification/appconfiguration/data-plane/Microsoft.AppConfiguration/preview/2022-11-01-preview/appconfiguration.json
namespace: Azure.Data.AppConfiguration
title: ConfigurationClient
```

### Change Endpoint type to Uri
``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
  ```

  ### Modify operation names
``` yaml
directive:
- rename-operation:
    from: PutKeyValue
    to: SetConfigurationSetting
- rename-operation:
    from: DeleteKeyValue
    to: DeleteConfigurationSetting
- rename-operation:
    from: GetKeyValue
    to: GetConfigurationSetting
- rename-operation:
    from: GetKeyValues
    to: GetConfigurationSettings
- rename-operation:
    from: PutLock
    to: CreateReadOnlyLock
- rename-operation:
    from: DeleteLock
    to: DeleteReadOnlyLock
- rename-operation:
    from: UpdateSnapshot
    to: UpdateSnapshotStatus
```

## Internalize operations
``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='CreateSnapshot')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetSnapshot')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetSnapshots')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='UpdateSnapshot')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckSnapshots')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckSnapshot')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckKeyValues')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckKeyValue')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckKeys')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckLabels')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CheckRevisions')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='CreateReadOnlyLock')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='DeleteReadOnlyLock')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='SetConfigurationSetting')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetConfigurationSettings')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='DeleteConfigurationSetting')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetKeyValue')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetKeyValues')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetKeys')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetLabels')]
  transform: >
    $["x-accessibility"] = "internal";
- from: swagger-document
  where: $..[?(@.operationId=='GetRevisions')]
  transform: >
    $["x-accessibility"] = "internal";
```

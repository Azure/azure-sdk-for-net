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
  from: swagger-document
  where: $.paths.*.*
  transform: >
    $["x-accessibility"] = "internal"
```

# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup CrossRegionRestore APIs.

## Run Generation
In this directory, run the following AutoRest commands to generate the code.
```
autorest --reset
autorest --use:@microsoft.azure/autorest.csharp@2.3.90
autorest.cmd README.md --version=v2
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
csharp: true
clear-output-folder: true
reflect-api-versions: true
openapi-type: arm
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
payload-flattening-threshold: 2
```

###
``` yaml
commit: 34782dd76c3f9990354009645caa3833744918f0
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2023-01-15/bms.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore
```
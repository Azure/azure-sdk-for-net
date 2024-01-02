# Overall
This directory contains management plane service clients of Az.RecoveryServices Backup APIs.

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
commit: 85917df97ae700d18aab11a39b070a6e34919f89
input-file:
  - https://github.com/vktibrewal/azure-rest-api-specs-workloadtest/blob/$(commit)/specification/recoveryservicesbackup/resource-manager/Microsoft.RecoveryServices/stable/2023-06-01/bms.json

output-folder: Generated

namespace: Microsoft.Azure.Management.RecoveryServices.Backup
```
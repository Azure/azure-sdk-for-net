# Azure.Communication.SipRouting
Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/01563419f540c27a96abae75f9feaa3e5e9a1f13/specification/communication/data-plane/SipRouting/readme.md
tag: package-2021-05-01-preview
output-folder: C:\Users\jiriburant\Git\azure-sdk-for-net\sdk\communication\Azure.Communication.PhoneNumbers\src\SipRouting\Generated
namespace: Azure.Communication.PhoneNumbers.SipRouting
enable-xml: true
clear-output-folder: true
csharp: true
v3: true
title: SIP Routing Service
model-namespace: false
```

# The types with Patch suffix, used in API are not used for SDK, to keep the things simple. Therefore, they are removed from autorest.
### Change SipConfigurationPatch to SipConfiguration
``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "PatchSipConfiguration")].parameters..[?(@.description == "Configuration patch.")]
  transform: >
    $.schema = {"$ref": "#/definitions/SipConfiguration"}
```

### Remove TrunkPatch type
``` yaml
directive:
  from: swagger-document
  where: $.definitions
  transform: >
    delete $.TrunkPatch
```

### Remove SipConfigurationPatch type
``` yaml
directive:
  from: swagger-document
  where: $.definitions
  transform: >
    delete $.SipConfigurationPatch
```

### Relax constraints on SipTrunk object to use it instead of TrunkPatch
``` yaml
directive:
  from: swagger-document
  where: $.definitions.SipTrunk
  transform: >
    delete $.required;
```

### Move all the models to the main namespace
```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.PhoneNumbers.SipRouting"
```

# Azure.Communication.PhoneNumbers.SipRouting

Run `ddotnet msbuild /t:GenerateCode /p:AutoRestInput=.\SipRouting\autorest_siprouting.md /p:UseDefaultNamespaceAndOutputFolder=false /p:AutoRestAdditionalParameters="--project-folder={PATH_TO_SDK_DIRECTORY}\sdk\communication\Azure.Communication.PhoneNumbers\src"` from the project root folder to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2022-09-01-preview
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/01563419f540c27a96abae75f9feaa3e5e9a1f13/specification/communication/data-plane/SipRouting/readme.md
output-folder: $(project-folder)\SipRouting\Generated
namespace: Azure.Communication.PhoneNumbers.SipRouting
enable-xml: true
clear-output-folder: true
csharp: true
v3: true
title: SIP Routing Service
model-namespace: false
generation1-convenience-client: true
```

# The types with Patch suffix, used in API are not used for SDK, to keep the things simple. Therefore, they are removed from autorest.
### Change SipConfigurationPatch to SipConfiguration
``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "SipRouting_Patch")].parameters..[?(@.description == "Configuration patch.")]
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

### Move all the models to the main namespace
```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.PhoneNumbers.SipRouting"
```

### Remove DomainPatch type
``` yaml
directive:
  from: swagger-document
  where: $.definitions
  transform: >
    delete $.DomainPatch
```

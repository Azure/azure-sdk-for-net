# Azure.Communication.PhoneNumbers.SipRouting
Run following command from the project root folder to generate code (note: AutoRest needs full path in the "project-folder" parameter to function properly):
`dotnet msbuild /t:GenerateCode /p:AutoRestInput=.\SipRouting\autorest_siprouting.md /p:UseDefaultNamespaceAndOutputFolder=false /p:AutoRestAdditionalParameters="--project-folder=<PATH_TO_SDK_DIRECTORY>\sdk\communication\Azure.Communication.PhoneNumbers\src"`

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2023-03
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/66174681c09b101de03fd35399080cfbccc93e8f/specification/communication/data-plane/SipRouting/readme.md
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

# The types with Update suffix, used in API are not used for SDK, to keep the things simple. Therefore, they are removed from autorest.
### Change SipConfigurationUpdate to SipConfiguration
``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "SipRouting_Update")].parameters..[?(@.description == "Sip configuration update object.")]
  transform: >
    $.schema = {"$ref": "#/definitions/SipConfiguration"}
```

### Remove TrunkUpdate type
``` yaml
directive:
  from: swagger-document
  where: $.definitions
  transform: >
    delete $.TrunkUpdate
```

### Remove SipConfigurationUpdate type
``` yaml
directive:
  from: swagger-document
  where: $.definitions
  transform: >
    delete $.SipConfigurationUpdate
```

### Move all the models to the main namespace
```yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.PhoneNumbers.SipRouting"
```

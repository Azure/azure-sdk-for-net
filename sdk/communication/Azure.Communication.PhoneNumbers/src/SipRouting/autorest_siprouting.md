# Azure.Communication.PhoneNumbers.SipRouting
Run following command from the project root folder to generate code (note: AutoRest needs full path in the "project-folder" parameter to function properly):
`dotnet msbuild /t:GenerateCode /p:AutoRestInput=.\SipRouting\autorest_siprouting.md /p:UseDefaultNamespaceAndOutputFolder=false /p:AutoRestAdditionalParameters="--project-folder=<PATH_TO_SDK_DIRECTORY>\sdk\communication\Azure.Communication.PhoneNumbers\src"`

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
tag: package-2024-11-15-preview
require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/8a218b1c6203d1ea118c3e0bcb4ae95bd44e1014/specification/communication/data-plane/SipRouting/readme.md
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

### Directive renaming "inactiveStatusReason" enum to "healthStatusReason"

```yaml
directive:
  from: swagger-document
  where: "$.definitions.OverallHealth"
  transform: >
    $.properties.reason["x-ms-enum"].name = "healthStatusReason";
```

### Directive deleting "CommunicationErrorResponse"

```yaml
directive:
  from: swagger-document
  where: "$.definitions"
  transform: >
    delete $.CommunicationErrorResponse
```

### Directives deleting default response

``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "SipRouting_Get")].responses
  transform: >
    delete $.default
```

``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "SipRouting_Update")].responses
  transform: >
    delete $.default
```

``` yaml
directive:
  from: swagger-document
  where: $.paths.*[?(@.operationId == "SipRouting_TestRoutesWithNumber")].responses
  transform: >
    delete $.default
```

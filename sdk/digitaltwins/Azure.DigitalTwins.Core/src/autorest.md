# Azure.DigitalTwins.Core

## Azure DigitalTwins swagger

## Local copy of the swagger document

A local copy of the official swagger documents are stored in this directory for convenience and testing purposes. Please make sure that you do not use these swagger documents for official code generation purposes.

## Official swagger document

The official swagger specification for Azure DigitalTwins can be found [here](https://raw.githubusercontent.com/Azure/azure-rest-api-specs/97db8d1015c2780c2704fe0f55537ff1f4740140/specification/digitaltwins/data-plane/Microsoft.DigitalTwins/preview/2020-05-31-preview/digitaltwins.json).

## Code generation

Run `generate.ps1` in this directory to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
#when generating from official source - The raw link must have a commit hash for C# generator
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/14fb40342c19f8b483e132038f8424ee62b745d9/specification/digitaltwins/data-plane/Microsoft.DigitalTwins/stable/2020-10-31/digitaltwins.json

directive:
- from: swagger-document
  where: $..[?(@.operationId=='DigitalTwins_GetComponent' || @.operationId=='DigitalTwins_GetRelationshipById' || @.operationId=='DigitalTwins_Add' || @.operationId=='DigitalTwins_GetById' || @.operationId=='DigitalTwins_AddRelationship')].responses.200.schema
  transform: $.format = "binary";


#if you want to generate using local swagger copy:
#input-file: $(this-folder)/swagger/2020-`0-31/digitaltwins.json

#azure-arm: true
#license-header: MICROSOFT_MIT_NO_VERSION
#payload-flattening-threshold: 1
#namespace: Azure.DigitalTwins.Core
```

## This directive removes the specified enum values from the swagger so the code generator will expose IfNonMatch header as an option instead of always attaching it to requests with its only default value.

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.name=='If-None-Match')]
  transform: delete $.enum;
```

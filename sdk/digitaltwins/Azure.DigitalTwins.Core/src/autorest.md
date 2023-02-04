# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory or run `dotnet build /t:GenerateCode` to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
tag: package-2022-05-31
require:
  - https://github.com/Azure/azure-rest-api-specs/blob/9135e2063fba5479098437a9261e1f2b281fb624/specification/digitaltwins/data-plane/readme.md
generation1-convenience-client: true
```

### Directives

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='DigitalTwins_GetComponent' || @.operationId=='DigitalTwins_GetRelationshipById' || @.operationId=='DigitalTwins_Add' || @.operationId=='DigitalTwins_GetById' || @.operationId=='DigitalTwins_AddRelationship')]
  transform:
    $["x-csharp-buffer-response"] = true;
    $.responses["200"].schema.format = "binary";
```

The following directive removes the specified enum values from the swagger so the code generator will expose IfNonMatch header as an option instead of always attaching it to requests with its only default value.

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.name=='If-None-Match')]
  transform: delete $.enum;
```

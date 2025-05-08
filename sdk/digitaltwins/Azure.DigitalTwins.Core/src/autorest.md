# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory or run `dotnet build /t:GenerateCode` to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
tag: package-2023-10-31
require:
  - https://github.com/Azure/azure-rest-api-specs/blob/b770b86265d5dc3a26b16c5d30a736e6bbba04de/specification/digitaltwins/data-plane/readme.md
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

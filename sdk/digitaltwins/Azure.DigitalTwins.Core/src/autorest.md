# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory or run `dotnet build /t:GenerateCode` to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
tag: package-preview-2023-02-27
require:
  - https://github.com/Azure/azure-rest-api-specs/blob/48c0c2036efcf0ccae7c0592a597699aac75ec4d/specification/digitaltwins/data-plane/readme.md
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

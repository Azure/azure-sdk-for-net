# Azure.DigitalTwins.Core

Run `generate.ps1` in this directory or run `dotnet build /t:GenerateCode` to generate the code.

## AutoRest Configuration

> see <https://aka.ms/autorest>

``` yaml
tag: package-2020-10-31
require: 
  - https://github.com/Azure/azure-rest-api-specs/blob/988d42ee7d8ca3243df17bfbc134e0c1f21b481e/specification/digitaltwins/data-plane/readme.md
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

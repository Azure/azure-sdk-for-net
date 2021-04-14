# Azure.AI.QuestionAnswering

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest configuration

We refer directly to the OpenAPI document to avoid batch processing of multiple tags (commented lines not working).

See <https://aka.ms/autorest> for more information.

``` yaml
# require:
# - https://github.com/Azure/azure-rest-api-specs/blob/0b9087be79feaca4504b1ecb277875bc6be56617/specification/cognitiveservices/data-plane/QnAMaker/readme.md
# batch: false
# tag: release_5_0_preview.2

input-file:
- https://github.com/Azure/azure-rest-api-specs/blob/0b9087be79feaca4504b1ecb277875bc6be56617/specification/cognitiveservices/data-plane/QnAMaker/preview/v5.0-preview.2/QnAMaker.json
```

## General customizations

These are transforms that should be in the swagger, or at least declared as transforms in the service [readme.md](https://github.com/Azure/azure-rest-api-specs/blob/0b9087be79feaca4504b1ecb277875bc6be56617/specification/cognitiveservices/data-plane/QnAMaker/readme.md).

### Name StringIndexType parameter enum

The `StringIndexType` parameter declares an enum but the AutoRest.CSharp add-in, at least, uses the ordinal to call it simply `Enum4`, which could change if enums are added later.

``` yaml
directive:
  from: swagger-document
  where: $.parameters.StringIndexType
  transform: |
    $["x-ms-enum"] = {
      name: "StringIndexType",
      modelAsString: false
    }
```

## C# customizations

These are transforms specific to the Azure QnA Maker client libraries for .NET

### Internal models

Make model types internal by default. This should be removed later and partial classes declared to only hide some models, like `QueryDTO`.

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: $["x-accessibility"] = "internal"
```

### Endpoint URI

Make the endpoint URLs a `System.Uri` parameter type.

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```

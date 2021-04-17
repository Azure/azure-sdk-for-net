# Azure.AI.QuestionAnswering

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest configuration

See <https://aka.ms/autorest> for more information.

``` yaml
require:
- https://github.com/Azure/azure-rest-api-specs/blob/f80541db7532f4e71e6f64c1bb1bde86b8620c67/specification/cognitiveservices/data-plane/QnAMaker/readme.md
tag: release_5_0_preview.2
```

## General customizations

These are transforms that should be in the swagger, or at least declared as transforms in the service [readme.md](https://github.com/Azure/azure-rest-api-specs/blob/f80541db7532f4e71e6f64c1bb1bde86b8620c67/specification/cognitiveservices/data-plane/QnAMaker/readme.md).

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

### Use datetime format for Operation

The two timestamps in Operation should use the `datetime` format.

``` yaml
directive:
  from: swagger-document
  where: $.definitions.Operation
  transform: |
    $.properties.createdTimestamp["format"] = "datetime";
    $.properties.lastActionTimestamp["format"] = "datetime";
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

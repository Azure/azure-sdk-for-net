# Azure.AI.QnaMaker

Run `dotnet build /t:GenerateCode` to generate code.

## AutoRest Configuration

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

## C# Customizations

These are transforms specific to the Azure QnA Maker client libraries for .NET

### Internal Models

Make model types internal by default. This should be removed later and partial classes declared to only hide some models, like `QueryDTO`.

``` yaml
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-accessibility"] = "internal"
```

### Endpoint URI

Make the endpoint URLs a `System.Uri` parameter type.

``` yaml
directive:
  from: swagger-document
  where: $.parameters.Endpoint
  transform: $.format = "url"
```

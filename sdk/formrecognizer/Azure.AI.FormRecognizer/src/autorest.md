# Azure.AI.FormRecognizer

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/de43e7fba7da1d2f2212c971d01f790a7afb1ba5/specification/cognitiveservices/data-plane/FormRecognizer/preview/v2.0/FormRecognizer.json
```




### Make AnalyzeResult.readResult optional
This is a temporary work-around
``` yaml
directive:
- from: swagger-document
  where: $.definitions.AnalyzeResult
  transform: $.required = ["version"];
```

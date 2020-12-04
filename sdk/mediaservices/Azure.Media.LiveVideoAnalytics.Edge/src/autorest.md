# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://github.com/Azure/azure-rest-api-specs-pr/blob/92ea1fa6945fa4aa0f1867d3a23c58577cf31fd9/specification/mediaservices/data-plane/LiveVideoAnalytics.Edge/preview/2.0.0/LiveVideoAnalytics.json

```

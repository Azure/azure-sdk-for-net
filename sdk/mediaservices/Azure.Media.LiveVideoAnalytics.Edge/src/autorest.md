# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://raw.githubusercontent.com/Azure/azure-rest-api-specs-pr/LVA-Release-do-not-delete/specification/mediaservices/data-plane/LiveVideoAnalytics.Edge/preview/2.0.0/LiveVideoAnalytics.json?token=AOYF5XTHV46STMV6NJEDH2C72PJ2Q

```

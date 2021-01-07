# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://github.com/Azure/azure-rest-api-specs/blob/297b7526f051e08f3a430b50daadd356ba74c6e2/specification/mediaservices/data-plane/readme.md

```


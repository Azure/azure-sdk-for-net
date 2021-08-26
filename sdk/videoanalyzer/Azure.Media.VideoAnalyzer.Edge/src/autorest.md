# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://github.com/Azure/azure-rest-api-specs/blob/cde7f150e8d3bf3af2418cc347cae0fb2baed6a7/specification/videoanalyzer/data-plane/readme.md
azure-arm: false
payload-flattening-threshold: 2
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
use-internal-constructors: true
use-datetimeoffset: true
```


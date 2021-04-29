# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://github.com/Azure/azure-rest-api-specs/blob/55b3e2d075398ec62f9322829494ff6a4323e299/specification/videoanalyzer/data-plane/readme.md
azure-arm: false
payload-flattening-threshold: 2
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Microsoft.Azure.Media.VideoAnalyzer.Edge
output-folder: $(csharp-sdks-folder)/videoanalyzer/Microsoft.Azure.Media.VideoAnalyzer.Edge/src/Generated
clear-output-folder: true
use-internal-constructors: true
override-client-name: LiveVideoAnalyticsEdgeClient
use-datetimeoffset: true
```


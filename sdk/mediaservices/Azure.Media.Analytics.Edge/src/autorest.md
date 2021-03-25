# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

input-file: 
- C:\Azure-Media-LiveVideoAnalytics\src\Edge\Client\AzureVideoAnalyzer.Edge\preview\1.0\AzureVideoAnalyzer.json
- C:\Azure-Media-LiveVideoAnalytics\src\Edge\Client\AzureVideoAnalyzer.Edge\preview\1.0\AzureVideoAnalyzerSdkDefinitions.json
azure-arm: false
payload-flattening-threshold: 2
license-header: MICROSOFT_MIT_NO_VERSION
namespace: Microsoft.Azure.Media.LiveVideoAnalytics.Edge
output-folder: $(csharp-sdks-folder)/mediaservices/Microsoft.Azure.Media.LiveVideoAnalytics.Edge/src/Generated
clear-output-folder: true
use-internal-constructors: true
override-client-name: LiveVideoAnalyticsEdgeClient
use-datetimeoffset: true
```


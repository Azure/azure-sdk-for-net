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
    - D:\azure-rest-api-specs\specification\videoanalyzer\data-plane\VideoAnalyzer.Edge\preview\1.1.0\AzureVideoAnalyzerSdkDefinitions.json
    - D:\azure-rest-api-specs\specification\videoanalyzer\data-plane\VideoAnalyzer.Edge\preview\1.1.0\AzureVideoAnalyzer.json
azure-arm: false
payload-flattening-threshold: 2
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
use-internal-constructors: true
use-datetimeoffset: true
```


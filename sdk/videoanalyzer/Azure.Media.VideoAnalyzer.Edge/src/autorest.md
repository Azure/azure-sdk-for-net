# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";

require: https://github.com/Azure/azure-rest-api-specs/blob/988d42ee7d8ca3243df17bfbc134e0c1f21b481e/specification/videoanalyzer/data-plane/readme.md
generation1-convenience-client: true
payload-flattening-threshold: 2
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
use-internal-constructors: true
use-datetimeoffset: true
```


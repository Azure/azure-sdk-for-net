# Azure.AI.FormRecognizer

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  https://github.com/Azure/azure-rest-api-specs/blob/master/specification/cognitiveservices/data-plane/FormRecognizer/preview/v2.0/FormRecognizer.json
```



### Hide LROs
``` yaml
directive:
- from: swagger-document
  where: $["paths"]
  transform: >
    for (var path in $) {
        for (var op of Object.values($[path])) {
            if (op["x-ms-long-running-operation"]) {
                delete op["x-ms-long-running-operation"];
            }
        }
    }
```

# Azure.Communication.MediaComposition

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Media Composition
tag: package-2022-07-16-preview
model-namespace: false
generation1-convenience-client: true
payload-flattening-threshold: 10
require: #Need to update the readme.md URL for an updated API specification
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/3443dabd3b2b6213b3984ac01ac3064e3d2f1e94/specification/communication/data-plane/MediaComposition/readme.md
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";
```

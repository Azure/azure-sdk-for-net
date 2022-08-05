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
input-file:
    - mediaComposition.json
```

``` yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";
```

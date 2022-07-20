# Azure.Communication.MediaComposition

Run `dotnet msbuild /t:GenerateCode` to generate code.

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Media Composition
tag: package-2022-07-16-preview1
generation1-convenience-client: true
model-namespace: false
payload-flattening-threshold: 10
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/c8d6546a49d0b58413c8dc06dc6c2a0912e4ad5a/specification/communication/data-plane/MediaComposition/preview/2022-07-16-preview/mediacomposition.json
```

```yaml
directive:
- from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-csharp-usage"] = "model,input,output";
    $["x-csharp-formats"] = "json";
```

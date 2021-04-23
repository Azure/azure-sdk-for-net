# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://github.com/jeremymeng/azure-rest-api-specs/blob/5cdb3c1b1fea7a84f3409e7820b7ad945e4098ac/specification/containerregistry/data-plane/Azure.ContainerRegistry/preview/2019-08-15-preview/containerregistry.json
model-namespace: false
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributes_manifest_references
  transform: >
    $["x-accessibility"] = "internal"
```

# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - $(this-folder)/swagger/containerregistry.json
#    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/5cdb3c1b1fea7a84f3409e7820b7ad945e4098ac/specification/containerregistry/data-plane/Azure.ContainerRegistry/preview/2019-08-15/containerregistry.json
model-namespace: false
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributes_manifest_references
  transform: >
    $["x-accessibility"] = "internal"
```

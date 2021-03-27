# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
#    -  https://github.com/Azure/azure-sdk-for-js/blob/53da30b0fc693faa6d2a80f92033370194caa784/sdk/containerregistry/container-registry/swagger/containerregistry.json
  - $(this-folder)/swagger/containerregistry.json
model-namespace: false
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.DeletedRepository
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributes_manifest_references
  transform: >
    $["x-accessibility"] = "internal"
```

# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-sdk-for-js/blob/16dd0bdd8cb94df32bba7c1a1299b33627990889/sdk/containerregistry/container-registry/swagger/containerregistry.json

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

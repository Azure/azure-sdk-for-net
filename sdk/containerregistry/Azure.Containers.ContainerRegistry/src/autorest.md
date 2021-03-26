# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-sdk-for-js/blob/b622e9dfff44fde2fa62c694c86f1d4532ece367/sdk/containerregistry/container-registry/swagger/containerregistry.json
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
  where: $.definitions.ManifestAttributes
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

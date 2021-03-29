# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://github.com/Azure/azure-sdk-for-js/blob/72c5d9ea15c374ff40bc6bc5420f36e5b68d4203/sdk/containerregistry/container-registry/swagger/containerregistry.json
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

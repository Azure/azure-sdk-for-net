# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/4af460b1ba17b339869775ca9fb1df3ebfe7c15a/specification/containerregistry/data-plane/Azure.ContainerRegistry/preview/2019-08-15-preview/containerregistry.json
 
model-namespace: false
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributes_manifest_references
  transform: >
    $["x-accessibility"] = "internal"
```

# Protocol namespace generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/dbd1dccfe2802010a0abc76e250ccbd55f4f2837/specification/containerregistry/data-plane/Azure.ContainerRegistry/preview/2019-08-15/containerregistry.json
namespace: Azure.Containers.ContainerRegistry.Protocol
library-name: Foo
low-level-client: true
credential-types: TokenCredential
credential-scopes: https://management.core.windows.net/.default
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributes_manifest_references
  transform: >
    $["x-accessibility"] = "internal"
```

# Protocol namespace generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  $(this-folder)/swagger/containerregistry.json
namespace: Azure.Containers.ContainerRegistry
library-name: ContainerRegistry
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

# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    -  $(this-folder)/swagger/containerregistry.json
public-clients: false

```

### Make generated models internal by default

#``` yaml
#directive:
#  from: swagger-document
#  where: $.definitions.*
#  transform: >
#    $["x-accessibility"] = "internal"
#```

### Make select generated models internal

``` yaml
directive:
  from: swagger-document
  where: $.definitions.Repositories
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.AcrManifests
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestAttributesBase
  transform: >
    $["x-accessibility"] = "internal"
```

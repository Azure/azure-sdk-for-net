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
  where: $.definitions.V1Manifest
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.V2Manifest
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.OCIIndex
  transform: >
    $["x-accessibility"] = "internal"
```

``` yaml
directive:
  from: swagger-document
  where: $.definitions.OCIManifest
  transform: >
    $["x-accessibility"] = "internal"
```

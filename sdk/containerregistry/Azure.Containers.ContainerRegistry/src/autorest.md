# Azure.Containers.ContainerRegistry Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Container Registry
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/c8d9a26a2857828e095903efa72512cf3a76c15d/specification/containerregistry/data-plane/Azure.ContainerRegistry/stable/2021-07-01/containerregistry.json
 
model-namespace: false
modelerfour:
    seal-single-value-enum-by-default: true
```

## Customizations for Code Generator

### Remove response for "ContainerRegistry_DeleteRepository" operation so that the generate code doesn't return a response for the delete repository operation.
```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/acr/v1/{name}"]
    transform: >
      delete $.delete["responses"]["202"].schema
```

### Remove "Authentication_GetAcrAccessTokenFromLogin" operation as the service team discourage using username/password to authenticate.
```yaml
directive:
  - from: swagger-document
    where: $["paths"]["/oauth2/token"]
    transform: >
      delete $.get
```

### Remove "definitions.TagAttributesBase.properties.signed" as we don't have a SDK client customer scenario using it.
```yaml
directive:
  - from: swagger-document
    where: $.definitions.TagAttributesBase
    transform: >
      delete $.properties.signed
```

### Remove "definitions.ManifestAttributesBase.properties.configMediaType" as we don't have a SDK client customer scenario using it.
```yaml
directive:
  - from: swagger-document
    where: $.definitions.ManifestAttributesBase
    transform: >
      delete $.properties.configMediaType
```

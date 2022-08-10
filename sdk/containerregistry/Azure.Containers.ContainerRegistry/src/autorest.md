# Azure.Containers.ContainerRegistry Code Generation

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Container Registry
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/c8d9a26a2857828e095903efa72512cf3a76c15d/specification/containerregistry/data-plane/Azure.ContainerRegistry/stable/2021-07-01/containerregistry.json
 
model-namespace: false
generation1-convenience-client: true
```

## Customizations for Code Generator

### Rename the enum TagOrderBy->ArtifactTagOrder
``` yaml
directive:
  from: swagger-document
  where: $.definitions.TagOrderBy
  transform: >
    $['x-ms-enum']["name"] = "ArtifactTagOrder"
```

### Rename the enum ManifestOrderBy->ArtifactManifestOrder
``` yaml
directive:
  from: swagger-document
  where: $.definitions.ManifestOrderBy
  transform: >
    $['x-ms-enum']["name"] = "ArtifactManifestOrder"
```

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

# Add content-type parameter
``` yaml
directive:
    from: swagger-document
    where: $.paths["/v2/{name}/manifests/{reference}"].put
    transform: >
        $.parameters.push({
            "name": "Content-Type",
            "in": "header",
            "type": "string",
            "description": "The manifest's Content-Type."
        });
        delete $.responses["201"].schema;
```

# Change NextLink client name to nextLink
``` yaml
directive:
  from: swagger-document
  where: $.parameters.NextLink
  transform: >
    $["x-ms-client-name"] = "nextLink"
```

# Updates to OciManifest
``` yaml
directive:
  from: swagger-document
  where: $.definitions.OCIManifest
  transform: >
    $["x-csharp-usage"] = "model,input,output,converter";
    $["x-csharp-formats"] = "json";
    delete $["x-accessibility"];
    delete $["allOf"];
    $.properties["schemaVersion"] = {
          "type": "integer",
          "description": "Schema version"
        };
```

# Take stream as manifest body
``` yaml
directive:
  from: swagger-document
  where: $.parameters.ManifestBody
  transform: >
    $.schema = {
        "type": "string",
        "format": "binary"
      }
```

# Make ArtifactBlobDescriptor a public type
``` yaml
directive:
  from: swagger-document
  where: $.definitions.Descriptor
  transform: >
    delete $["x-accessibility"]
```

# Make OciAnnotations a public type
``` yaml
directive:
  from: swagger-document
  where: $.definitions.Annotations
  transform: >
    delete $["x-accessibility"]
```

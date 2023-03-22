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

# Add content-type parameter to upload manifest
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

# Add content-range and content-length parameters to upload chunk
``` yaml
directive:
    from: swagger-document
    where: $.paths["/{nextBlobUuidLink}"].patch
    transform: >
        $.parameters.push({
            "name": "Content-Range",
            "in": "header",
            "type": "string",
            "description": "Range of bytes identifying the desired block of content represented by the body. Start must the end offset retrieved via status check plus one. Note that this is a non-standard use of the Content-Range header."
        });
        $.parameters.push({
            "name": "Content-Length",
            "in": "header",
            "type": "string",
            "description": "Length of the chunk being uploaded, corresponding the length of the request body."
        });
```

# Change NextLink client name to nextLink
``` yaml
directive:
  from: swagger-document
  where: $.parameters.NextLink
  transform: >
    $["x-ms-client-name"] = "nextLink"
```

# Updates to OciImageManifest
``` yaml
directive:
  from: swagger-document
  where: $.definitions.OCIManifest
  transform: >
    $["x-csharp-usage"] = "model,input,output,converter";
    $["x-csharp-formats"] = "json";
    $["x-ms-client-name"] = "OciImageManifest";
    $["required"] = ["schemaVersion"];
    delete $["x-accessibility"];
    delete $["allOf"];
    $.properties["schemaVersion"] = {
          "type": "integer",
          "description": "Schema version",
          "x-ms-client-default": 2
        };
    $.properties.config["x-ms-client-name"] = "configuration";
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

# Descriptor Updates
``` yaml
directive:
  from: swagger-document
  where: $.definitions.Descriptor
  transform: >
    $["x-ms-client-name"] = "OciDescriptor";
    $.properties.size["x-ms-client-name"] = "sizeInBytes";
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

# Don't buffer downloads
``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='ContainerRegistryBlob_GetBlob' || @.operationId=='ContainerRegistryBlob_GetChunk')]
  transform: $["x-csharp-buffer-response"] = false;
```

# Remove security definitions
``` yaml
directive:
- from: swagger-document
  where: $.
  transform: >
    delete $["securityDefinitions"];
    delete $["security"];
```

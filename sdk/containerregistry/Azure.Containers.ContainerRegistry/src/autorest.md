# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Container Registry
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/2c33d5572dab4c6f52faf31004f0561205737107/specification/containerregistry/data-plane/Azure.ContainerRegistry/stable/2021-07-01/containerregistry.json
 
model-namespace: false
modelerfour:
    seal-single-value-enum-by-default: true
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

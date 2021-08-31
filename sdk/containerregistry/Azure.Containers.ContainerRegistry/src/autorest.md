# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
title: Container Registry
input-file:
 - https://github.com/Azure/azure-rest-api-specs/blob/2c33d5572dab4c6f52faf31004f0561205737107/specification/containerregistry/data-plane/Azure.ContainerRegistry/stable/2021-07-01/containerregistry.json
 
model-namespace: false
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
```

# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f8c3f91da6a9ed64b687711af64e8d70cb500e1d/specification/storage/data-plane/Microsoft.BlobStorage/preview/2020-06-12/blob.json
```

### Delete all operations except SubmitBatch and operations
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    return {
        "/?comp=batch": $["/?comp=batch"],
        "/{containerName}?restype=container&comp=batch": $["/{containerName}?restype=container&comp=batch"],
        "/{containerName}/{blob}?comp=tier": {
            "put": {
                ...$["/{containerName}/{blob}?comp=tier"].put,
                operationId: "Blob_SetAccessTier"
            },
            "parameters": $["/{containerName}/{blob}?comp=tier"].parameters
        },
        "/{containerName}/{blob}": { "delete": $["/{containerName}/{blob}"].delete }
    };
```

### Add containerName as a parameter
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{containerName}'))
        {
            if (!$[property].parameters)
            {
                $[property].parameters = [];
            }
            $[property].parameters.push({
                "$ref": "#/parameters/ContainerName"
            });
        };
        if (property.includes('{blob}'))
        {
            if (!$[property].parameters)
            {
                $[property].parameters = [];
            }
            $[property].parameters.push({
                "$ref": "#/parameters/Blob"
            });
        };
    }
```
# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f8c3f91da6a9ed64b687711af64e8d70cb500e1d/specification/storage/data-plane/Microsoft.BlobStorage/preview/2020-06-12/blob.json
generation1-convenience-client: true
modelerfour:
    seal-single-value-enum-by-default: true
protocol-method-list:
  - Service_SubmitBatch
  - Container_SubmitBatch
```

### Batch returns a 202
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/?comp=batch"].post.responses
  transform: >
    const response = $["200"];
    if (response) {
        delete $["200"];
        $["202"] = response;
        $["202"]["x-az-public"] = false;
        $["202"]["x-az-response-name"] = "BlobBatchResult";
        $["202"]["x-az-response-schema-name"] = "Content";
    }
```

### Batch returns a 202
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{containerName}?restype=container&comp=batch"].post.responses
  transform: >
    const response = $["202"];
    if (response) {
        delete $["202"];
        $["202"] = response;
        $["202"]["x-az-public"] = false;
        $["202"]["x-az-response-name"] = "BlobBatchResult";
        $["202"]["x-az-response-schema-name"] = "Content";
    }
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

### Delete all definitions except those for SubmitBatch and operations
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    return {
        "StorageError": {
            ...$.StorageError,
            "x-az-public": false,
            properties: {
                ...$.StorageError.properties,
                Code: { "type": "string" }
            }
        }
    };
```

### Make move parameters to constructors.
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.Snapshot["x-ms-parameter-location"];
```

### Make Blob a constructor parameter
``` yaml
directive:
- from: swagger-documents
  where: $.parameters
  transform: >
    $.Blob["x-ms-skip-url-encoding"] = true;
```

### Remove conditions parameter groupings
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.IfMatch["x-ms-parameter-grouping"];
    delete $.IfModifiedSince["x-ms-parameter-grouping"];
    delete $.IfNoneMatch["x-ms-parameter-grouping"];
    delete $.IfUnmodifiedSince["x-ms-parameter-grouping"];
    delete $.LeaseIdOptional["x-ms-parameter-grouping"];
    delete $.IfTags["x-ms-parameter-grouping"];
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

### Delete all parameters except those for SubmitBatch and operations
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $ = {
        "Body": $.Body,
        "ContentLength": $.ContentLength,
        "MultipartContentType": $.MultipartContentType,
        "Timeout": $.Timeout,
        "ApiVersionParameter": $.ApiVersionParameter,
        "ClientRequestId": $.ClientRequestId,
        "Url": $.Url,
        "AccessTierRequired": $.AccessTierRequired,
        "RehydratePriority": $.RehydratePriority,
        "LeaseIdOptional": $.LeaseIdOptional,
        "Snapshot": $.Snapshot,
        "DeleteSnapshots": $.DeleteSnapshots,
        "IfModifiedSince": $.IfModifiedSince,
        "IfUnmodifiedSince": $.IfUnmodifiedSince,
        "IfMatch": $.IfMatch,
        "IfNoneMatch": $.IfNoneMatch,
        "VersionId": $.VersionId,
        "IfTags": $.IfTags,
        "BlobDeleteType": $.BlobDeleteType,
        "ContainerName": $.ContainerName,
        "Blob": $.Blob
    };

    return $;
```

### Rename AccessTierRequired and RehydratePriority
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.AccessTierRequired["x-ms-enum"].name = "BatchAccessTier";
    $.RehydratePriority["x-ms-enum"].name = "BatchRehydratePriority";
```

### Fix BlobDeleteType
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.BlobDeleteType.enum;
    $.BlobDeleteType.enum = [
        "None",
        "Permanent"
    ];
```

### Don't encode BlobName or Container Name
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.Blob["x-ms-skip-url-encoding"] = true;
    $.ContainerName["x-ms-skip-url-encoding"] = true;
```

### Buffer batch responses

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='Service_SubmitBatch' || @.operationId=='Container_SubmitBatch')]
  transform: $["x-csharp-buffer-response"] = true;
```
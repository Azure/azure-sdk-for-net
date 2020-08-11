# Blob Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate blob storage
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/storage-dataplane-preview/specification/storage/data-plane/Microsoft.BlobStorage/preview/2019-02-02/blob.json
output-folder: ../src/Generated
clear-output-folder: false

# Use the Azure C# Track 2 generator
# use: C:\src\Storage\Swagger\Generator
# We can't use relative paths here, so use a relative path in generate.ps1
azure-track2-csharp: true
```

## Customizations for Track 2 Generator
See the [AutoRest samples](https://github.com/Azure/autorest/tree/master/Samples/3b-custom-transformations)
for more about how we're customizing things.

### x-ms-code-generation-settings
``` yaml
directive:
- from: swagger-document
  where: $.info["x-ms-code-generation-settings"]
  transform: >
    $.namespace = "Azure.Storage.Blobs";
    $["client-name"] = "BatchRestClient";
    $["client-extensions-name"] = "BlobsExtensions";
    $["client-model-factory-name"] = "BlobsModelFactory";
    $["x-az-skip-path-components"] = true;
    $["x-az-include-sync-methods"] = true;
    $["x-az-public"] = false;
```

### Remove extra consumes/produces values
To avoid an arbitrary limitation in our generator
``` yaml
directive:
- from: swagger-document
  where: $.consumes
  transform: >
    return ["application/xml"];
- from: swagger-document
  where: $.produces
  transform: >
    return ["application/xml"];
```

### Url
``` yaml
directive:
- from: swagger-document
  where: $.parameters.Url
  transform: >
    $["x-ms-client-name"] = "resourceUri";
    $.format = "url";
    $["x-az-trace"] = true;
```

### Ignore common headers
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["x-ms-request-id"]
  transform: >
    $["x-az-demote-header"] = true;
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["x-ms-version"]
  transform: >
    $["x-az-demote-header"] = true;
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["Date"]
  transform: >
    $["x-az-demote-header"] = true;
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["x-ms-client-request-id"]
  transform: >
    $["x-az-demote-header"] = true;
```

### Clean up Failure response
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]..responses.default
  transform: >
    delete $.headers;
    $["x-az-response-name"] = "StorageErrorResult";
    $["x-az-create-exception"] = true;
    $["x-az-public"] = false;
```

### Fix doc comments
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/?comp=batch"].get.responses["200"].headers["Content-Type"]
  transform: >
    $.description = $.description.replace("<GUID>", "{GUID}");
- from: swagger-document
  where: $.parameters.MultipartContentType
  transform: >
    $.description = $.description.replace("<GUID>", "{GUID}");
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

### Delete all operations except SubmitBatch and operations
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    return {
        "/?comp=batch": $["/?comp=batch"],
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
        "IfNoneMatch": $.IfNoneMatch
    };

    $.AccessTierRequired["x-az-external"] = true;

    $.RehydratePriority["x-az-external"] = true;
    $.RehydratePriority["x-ms-enum"].modelAsString = false;

    $.DeleteSnapshots["x-az-external"] = true;
    $.DeleteSnapshots["x-ms-enum"].name = "DeleteSnapshotsOption";
    $.DeleteSnapshots.enum = [ "none", "include", "only" ];
    $.DeleteSnapshots["x-ms-enum"].values = [ { name: "none", value: null }, { name: "IncludeSnapshots", value: "include" }, { name: "OnlySnapshots", value: "only" }];
    $.DeleteSnapshots["x-az-enum-skip-value"] = "none";

    return $;
```

### Treat the API version as a parameter instead of a constant
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: >
    delete $.enum
```

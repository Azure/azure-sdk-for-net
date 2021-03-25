# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/728f856957c11aeb9a4f650cb7eff61ad34fe999/specification/storage/data-plane/Microsoft.BlobStorage/preview/2020-08-04/blob.json
```

### Move path parameters to constructor.
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.ContainerName["x-ms-parameter-location"];
    delete $.Blob["x-ms-parameter-location"];
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

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode["x-ms-enum"]
  transform: >
    $.name = "BlobErrorCode";
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
    delete $.BlobConditionMaxSize["x-ms-parameter-grouping"];
    delete $.BlobConditionAppendPos["x-ms-parameter-grouping"];
    delete $.SourceIfModifiedSince["x-ms-parameter-grouping"];
    delete $.SourceIfUnmodifiedSince["x-ms-parameter-grouping"];
    delete $.SourceIfMatch["x-ms-parameter-grouping"];
    delete $.SourceIfNoneMatch["x-ms-parameter-grouping"];
    delete $.SourceIfTags["x-ms-parameter-grouping"];
    delete $.IfSequenceNumberLessThanOrEqualTo["x-ms-parameter-grouping"];
    delete $.IfSequenceNumberLessThan["x-ms-parameter-grouping"];
    delete $.IfSequenceNumberEqualTo["x-ms-parameter-grouping"];
```

### Remove blob-Http-Headers parameter grouping
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.BlobCacheControl["x-ms-parameter-grouping"];
    delete $.BlobContentType["x-ms-parameter-grouping"];
    delete $.BlobContentMD5["x-ms-parameter-grouping"];
    delete $.BlobContentEncoding["x-ms-parameter-grouping"];
    delete $.BlobContentLanguage["x-ms-parameter-grouping"];
    delete $.BlobContentDisposition["x-ms-parameter-grouping"];
```

### Remove container-cpk-scope-info grouping
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.DefaultEncryptionScope["x-ms-parameter-grouping"];
    delete $.DenyEncryptionScopeOverride["x-ms-parameter-grouping"];
```

### Remove CPK and encryption scope parameter grouping
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.EncryptionKey["x-ms-parameter-grouping"];
    delete $.EncryptionKeySha256["x-ms-parameter-grouping"];
    delete $.EncryptionAlgorithm["x-ms-parameter-grouping"];
    delete $.EncryptionScope["x-ms-parameter-grouping"];
```

### Add containerName and blob as a parameter
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
        if (property.includes('filesystem'))
        {
            delete $[property];
        }
    }
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Metrics.type = "object";
```

### DataLakeStorageError
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.DataLakeStorageError;
```

### Change LeaseDuration and BreakPerson to a long
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.LeaseDuration.format = "int64";
    $.LeaseBreakPeriod.format = "int64";
```

### Fix BlobMetadata
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.BlobMetadata["properties"];
```

### Fix SourceUrl, PrevSnapshotUrl, CopySource
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.SourceUrl.format;
    delete $.PrevSnapshotUrl.format;
    delete $.CopySource.format;
```

### Fix GeoReplication
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.GeoReplication.properties.Status["x-ms-enum"];
    $.GeoReplication.properties.Status["x-ms-enum"] = {
        "name": "BlobGeoReplicationStatus",
        "modelAsString": false
    };
```

### Fix RehydratePriority
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.RehydratePriority["x-ms-enum"];
    $.RehydratePriority["x-ms-enum"] = {
        "name": "RehydratePriority",
        "modelAsString": false
    };
```

### Fix ArchieveStatus
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.ArchiveStatus["x-ms-enum"];
    $.ArchiveStatus["x-ms-enum"] = {
        "name": "ArchiveStatus",
        "modelAsString": false
    };
```

### Fix KeyInfo
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.KeyInfo.required;
    $.KeyInfo.required = [
        "Expiry"
    ];
```

### Fix Delimitor
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.Delimiter.required;
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

### Fix EncryptionAlgorithm
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.EncryptionAlgorithm.enum;
    $.EncryptionAlgorithm.enum = [
      "None",
      "AES256"
    ];
```

### Fix 304s
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{containerName}/{blob}"]
  transform: >
    $.get.responses["304"] = {
      "description": "The condition specified using HTTP conditional header(s) is not met.",
      "x-az-response-name": "ConditionNotMetError",
      "headers": { "x-ms-error-code": { "x-ms-client-name": "ErrorCode", "type": "string" } }
    };
```

### Don't buffer downloads and query

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='Blob_Query' || @.operationId=='Blob_Download')]
  transform: $["x-csharp-buffer-response"] = false;
```
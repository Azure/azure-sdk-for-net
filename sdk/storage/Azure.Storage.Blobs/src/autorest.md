# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/011761be1285d14feb41796b5d97df1126495c5c/specification/storage/data-plane/Microsoft.BlobStorage/preview/2020-06-12/blob.json
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

### Don't encode BlobName
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.Blob["x-ms-skip-url-encoding"] = true;
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

## DataLakeStorageError
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    delete $.DataLakeStorageError;
```
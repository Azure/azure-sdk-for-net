# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/b6472ffd34d5d4a155101b41b4eb1f356abff600/specification/storage/data-plane/Azure.Storage.Files.DataLake/stable/2025-01-05/DataLakeStorage.json
generation1-convenience-client: true
modelerfour:
    seal-single-value-enum-by-default: true

helper-namespace: Azure.Storage.Common
```

### Don't include file system or path in path - we have direct URIs.
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('/{filesystem}/{path}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/FileSystem") && false == param['$ref'].endsWith("#/parameters/Path"))});
        } 
        else if (property.includes('/{filesystem}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/FileSystem"))});
        }
    }
```

### Make sure Path is not encoded
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.Path["x-ms-skip-url-encoding"] = true;
```

### Ungroup parameter groups
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.CacheControl["x-ms-parameter-grouping"];
    delete $.ContentDisposition["x-ms-parameter-grouping"];
    delete $.ContentEncoding["x-ms-parameter-grouping"];
    delete $.ContentLanguage["x-ms-parameter-grouping"];
    delete $.ContentType["x-ms-parameter-grouping"];
    delete $.TransactionalContentMD5["x-ms-parameter-grouping"];
    delete $.ContentMD5["x-ms-parameter-grouping"];
    delete $.LeaseIdOptional["x-ms-parameter-grouping"];
    delete $.IfMatch["x-ms-parameter-grouping"];
    delete $.IfModifiedSince["x-ms-parameter-grouping"];
    delete $.IfNoneMatch["x-ms-parameter-grouping"];
    delete $.IfUnmodifiedSince["x-ms-parameter-grouping"];
    delete $.SourceIfMatch["x-ms-parameter-grouping"];
    delete $.SourceIfModifiedSince["x-ms-parameter-grouping"];
    delete $.SourceIfNoneMatch["x-ms-parameter-grouping"];
    delete $.SourceIfUnmodifiedSince["x-ms-parameter-grouping"];
    delete $.SourceLeaseId["x-ms-parameter-grouping"];
    delete $.EncryptionKey["x-ms-parameter-grouping"];
    delete $.EncryptionKeySha256["x-ms-parameter-grouping"];
    delete $.EncryptionAlgorithm["x-ms-parameter-grouping"];
```

### Fix Path
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Path.properties.lastModified.format = "date-time-rfc1123";
    delete $.Path.properties.contentLength;
    $.Path.properties.contentLength = {
        "type": "string"
    };
    delete $.Path.properties.isDirectory;
    $.Path.properties.isDirectory = {
        "type": "string"
    };
    delete $.Path.properties.eTag;
    $.Path.properties.etag = {
        "type": "string"
    };
```

### Fix append file consumes
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?action=append"]
  transform: >
    $.patch.consumes = [
      "application/octet-stream"
    ]
```

### Don't buffer downloads

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='Path_Read')]
  transform: $["x-csharp-buffer-response"] = false;
```

### Don't include FileSystem and Path in path - we have direct URIs.
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('/{filesystem}/{path}'))
        {
            var oldName = property;
            var newName = property.replace('/{filesystem}/{path}', '');
            if (!newName.includes('?'))
            {
              newName = newName + '?' + 'filesystem_path'
            }
            $[newName] = $[oldName];
            delete $[oldName];
        } 
        else if (property.includes('/{filesystem}'))
        {
            var oldName = property;
            var newName = property.replace('/{filesystem}', '');
            if (!newName.includes('?'))
            {
              newName = newName + '?' + 'filesystem'
            }
            $[newName] = $[oldName];
            delete $[oldName];
        }
    }
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

### Rename LeaseAction
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.LeaseAction["x-ms-enum"];
    $.LeaseAction["x-ms-enum"] = {
        "name": "DataLakeLeaseAction",
        "modelAsString": false
    };
```

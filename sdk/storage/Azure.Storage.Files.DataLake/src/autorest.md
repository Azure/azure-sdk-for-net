# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/e3850d6aa56eecad65262d0fc7815be0773bfb85/specification/storage/data-plane/Microsoft.StorageDataLake/stable/2020-06-12/DataLakeStorage.json
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

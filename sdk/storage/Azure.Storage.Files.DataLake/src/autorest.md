# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/6ce72c4ea25c40477ecf7e2867f3644bde40fb4f/specification/storage/data-plane/Microsoft.StorageDataLake/stable/2020-06-12/DataLakeStorage.json
```

### Added FileSystem and Path as parameters
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{filesystem}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/FileSystem"
            });
        };
        if (property.includes('{path}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/Path"
            });
        };
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
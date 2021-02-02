# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/bc0a3368a4e8ff55ed69dc498e69437ec92cf0b1/specification/storage/data-plane/Microsoft.StorageDataLake/stable/2020-02-10/DataLakeStorage.json
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
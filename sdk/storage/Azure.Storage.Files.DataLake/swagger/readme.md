# File Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate file storage
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/storage-dataplane-preview/specification/storage/data-plane/Microsoft.StorageDataLake/stable/2019-12-12/DataLakeStorage.json
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
    $.namespace = "Azure.Storage.Files.DataLake";
    $["client-name"] = "DataLakeRestClient";
    $["client-extensions-name"] = "FilesDataLakeExtensions";
    $["client-model-factory-name"] = "DataLakeModelFactory";
    $["x-az-skip-path-components"] = true;
    $["x-az-include-sync-methods"] = true;
    $["x-az-public"] = false;
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

### ApiVersionParameter
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: $.enum = ["2019-02-02"]
```

### MD5 to Hash
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ContentMD5["x-ms-client-name"]
  transform: return "contentHash";
- from: swagger-document
  where: $.parameters.FileContentMD5["x-ms-client-name"]
  transform: return "fileContentHash";
- from: swagger-document
  where: $.parameters.GetRangeContentMD5["x-ms-client-name"]
  transform: return "rangeGetContentHash";
```

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode
  transform: >
    $["x-ms-enum"].name = "DataLakeErrorCode";
```

### Hide StorageError
``` yaml
directive:
- from: swagger-document
  where: $.definitions.StorageError
  transform: >
    $["x-az-public"] = false;
    $.properties.Code = { "type": "string" };
- from: swagger-document
  where: $.definitions.DataLakeStorageError
  transform: >
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

### Temporarily work around proper JSON support for file permissions
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}?resource=filesystem"]
  transform: >
    delete $.get.responses["200"].schema;
    $.get.responses["200"].schema = {
        "type": "object",
        "format": "file"
    };
    $.get.responses["200"]["x-az-public"] = false;
- from: swagger-document
  where: $.definitions.StorageError
  transform: >
    $.type = "string";
    delete $.properties;
```

### /{filesystem}
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}"]
  transform: >
    $.put.responses["201"]["x-az-public"] = false;
    $.head.responses["200"]["x-az-public"] = false;
    $.patch.responses["200"]["x-az-public"] = false;
```

### /{filesystem}?resource=filesystem
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/"]
  transform: >
    $.get.responses["200"]["x-az-public"] = false;
```

### /{filesystem}/{path}
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}"]
  transform: >
    $.put.responses["201"]["x-az-public"] = false;
    $.delete.responses["200"]["x-az-public"] = false;
    $.head.responses["200"]["x-az-public"] = false;
    $.post.responses["200"]["x-az-public"] = false;
    $.get.responses["200"]["x-az-public"] = false;
    $.patch.responses["200"]["x-az-public"] = false;
```

### /{filesystem}/{path}?action=append"
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?action=append"]
  transform: >
    $.patch.responses["202"]["x-az-public"] = false;
```

### /{filesystem}/{path}?action=flush"
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?action=flush"]
  transform: >
    $.patch.responses["200"]["x-az-public"] = false;
```

### /{filesystem}/{path}?action=setAccessControl"
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?action=setAccessControl"]
  transform: >
    $.patch.responses["200"]["x-az-public"] = false;
```

### /{filesystem}/{path}?action=setAccessControlRecursive"
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?action=setAccessControlRecursive"]
  transform: >
    $.patch.responses["200"].schema = {
        "type": "object",
        "format": "file"
    };
    $.patch.responses["200"]["x-az-public"] = false;
```

### Hide FileSystemList/FileSystem/PathList/Path/
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.FileSystem["x-az-public"] = false;
    $.FileSystemList["x-az-public"] = false;
    $.PathList["x-az-public"] = false;
    $.Path["x-az-public"] = false;
```

### Hide AclFailedEntryList/SetAccessControlRecursiveResponse
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.AclFailedEntry["x-az-public"] = false;
    $.SetAccessControlRecursiveResponse["x-az-public"] = false;
```

### Hide PathSetAccessControlRecursiveMode
``` yaml
directive:
- from: swagger-document
  where: $.parameters.PathSetAccessControlRecursiveMode
  transform: >
    $["x-az-public"] = false;
```

### Treat the API version as a parameter instead of a constant
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: >
    delete $.enum
```

### Make PathSetExpiryResult internal
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{filesystem}/{path}?comp=expiry"]
  transform: >
    $.put.responses["200"]["x-az-public"] = false;
    $.put.responses["200"]["x-az-response-name"] = "PathSetExpiryInternal";
```

### Make PathExpiryOptions internal
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.PathExpiryOptions["x-az-public"] = false;
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Files.DataLake%2Fswagger%2Freadme.png)

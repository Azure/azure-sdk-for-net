# File Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate file storage
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/storage-dataplane-preview/specification/storage/data-plane/Microsoft.StorageDataLake/stable/2018-11-09/DataLakeStorage.json
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
    $["client-model-factory-name"] = "FilesDataLakeModelFactory";
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
    $["x-az-response-name"] = "StorageErrorResult";
    $["x-az-create-exception"] = true;
    $["x-az-public"] = false;
    $.headers["x-ms-error-code"]["x-az-demote-header"] = true;
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

### StorageError
``` yaml
directive:
- from: swagger-document
  where: $.definitions.StorageError
  transform: >
    $["x-az-public"] = false;
    $.properties.Code = { "type": "string" };
```

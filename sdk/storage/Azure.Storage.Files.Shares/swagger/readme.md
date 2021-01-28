# File Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate file storage
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/storage-dataplane-preview/specification/storage/data-plane/Microsoft.FileStorage/preview/2020-04-08/file.json
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
    $.namespace = "Azure.Storage.Files.Shares";
    $["client-name"] = "FileRestClient";
    $["client-extensions-name"] = "FilesExtensions";
    $["client-model-factory-name"] = "ShareModelFactory";
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
  transform: $.enum = ["2019-07-07"]
```

### /?restype=service&comp=properties
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.ShareServiceProperties) {
        $.ShareServiceProperties = $.StorageServiceProperties;
        delete $.StorageServiceProperties;
        $.ShareServiceProperties.xml = { "name": "StorageServiceProperties" };
    }
- from: swagger-document
  where: $.parameters
  transform: >
    if (!$.ShareServiceProperties) {
        const props = $.ShareServiceProperties = $.StorageServiceProperties;
        props.name = "ShareServiceProperties";
        props["x-ms-client-name"] = "properties";
        props.schema = { "$ref": props.schema.$ref.replace(/[#].*$/, "#/definitions/ShareServiceProperties") };
        delete $.StorageServiceProperties;
    }
- from: swagger-document
  where: $["x-ms-paths"]["/?restype=service&comp=properties"]
  transform: >
    const param = $.put.parameters[0];
    if (param && param["$ref"] && param["$ref"].endsWith("StorageServiceProperties")) {
        const path = param["$ref"].replace(/[#].*$/, "#/parameters/ShareServiceProperties");
        $.put.parameters[0] = { "$ref": path };
    }
    const def = $.get.responses["200"].schema;
    if (def && def["$ref"] && def["$ref"].endsWith("StorageServiceProperties")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/ShareServiceProperties");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### Make CORS allow null values
It should be possible to pass null for CORS to update service properties without changing existing rules.
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ShareServiceProperties
  transform: >
    $.properties.Cors["x-az-nullable-array"] = true;
```

### /?comp=list
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.SharesSegment) {
        $.SharesSegment = $.ListSharesResponse;
        delete $.ListSharesResponse;
        $.SharesSegment["x-az-public"] = false;
    }
- from: swagger-document
  where: $["x-ms-paths"]["/?comp=list"]
  transform: >
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("SharesSegment")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/SharesSegment");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### Hide ListSharesIncludeType
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ListSharesInclude
  transform: >
    $.items["x-az-public"] = false;
```

### /{shareName}?restype=share
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share"]
  transform: >
    $.put.responses["201"].description = "Success";
    $.put.responses["201"]["x-az-response-name"] = "ShareInfo";
    $.get.responses["200"]["x-az-response-name"] = "SharePropertiesInternal";
    $.get.responses["200"].headers["x-ms-share-quota"]["x-ms-client-name"] = "QuotaInGB";
```

### /{shareName}?restype=share&comp=snapshot
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=snapshot"]
  transform: >
    $.put.responses["201"]["x-az-response-name"] = "ShareSnapshotInfo";
```

### /{shareName}?restype=share&comp=properties
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=properties"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "ShareInfo";
    $.put.responses["200"].headers.ETag.description = "The ETag contains a value which represents the version of the share, in quotes.";
    $.put.responses["200"].headers["Last-Modified"].description = "Returns the date and time the share was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.";
```

### /{shareName}?restype=share&comp=metadata
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=metadata"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "ShareInfo";
    $.put.responses["200"].headers.ETag.description = "The ETag contains a value which represents the version of the share, in quotes.";
    $.put.responses["200"].headers["Last-Modified"].description = "Returns the date and time the share was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.";
```

### /{shareName}?restype=share&comp=acl
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=acl"]
  transform: >
    $.get.responses["200"].headers.ETag["x-az-demote-header"] = true;
    $.get.responses["200"].headers["Last-Modified"]["x-az-demote-header"] = true;
    $.put.responses["200"]["x-az-response-name"] = "ShareInfo";
    $.put.responses["200"].description = "Success";
    $.put.responses["200"].headers.ETag.description = "The ETag contains a value which represents the version of the share, in quotes.";
    $.put.responses["200"].headers["Last-Modified"].description = "Returns the date and time the share was last modified. Any operation that modifies the share or its properties or metadata updates the last modified time. Operations on files do not affect the last modified time of the share.";
- from: swagger-document
  where: $.parameters.ShareAcl
  transform: >
    $["x-ms-client-name"] = "permissions";
```

### /{shareName}?restype=share&comp=stats
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.ShareStatistics) {
        $.ShareStatistics = $.ShareStats;
        delete $.ShareStats;
        $.ShareStatistics.xml = { "name": "ShareStats" };
        $.ShareStatistics.properties.ShareUsageBytes.description = "The approximate size of the data stored in bytes, rounded up to the nearest gigabyte. Note that this value may not include all recently created or recently resized files.";
        $.ShareStatistics.properties.ShareUsageBytes.format = 'int64';
        $.ShareStatistics.properties.ShareUsageBytes['x-ms-client-name'] = 'ShareUsageInBytes';
    }
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=stats"]
  transform: >
    $.get.responses["200"].headers.ETag["x-az-demote-header"] = true;
    $.get.responses["200"].headers["Last-Modified"]["x-az-demote-header"] = true;
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("ShareStatistics")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/ShareStatistics");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### /{shareName}/{directory}?restype=directory
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?restype=directory"]
  transform: >
    $.put.responses["201"].headers["x-ms-request-server-encrypted"]["x-az-demote-header"] = true;
    $.put.responses["201"]["x-az-response-name"] = "RawStorageDirectoryInfo";
    $.put.responses["201"]["x-az-public"] = false;
    $.get.responses["200"]["x-az-response-name"] = "RawStorageDirectoryProperties";
    $.get.responses["200"]["x-az-public"] = false;
```

### /{shareName}/{directory}?restype=directory&comp=metadata
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?restype=directory&comp=metadata"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "RawStorageDirectoryInfo";
    $.put.responses["200"]["x-az-public"] = false;
    $.put.responses["200"].description = "Success, Directory created.";
    $.put.responses["200"].headers["x-ms-request-server-encrypted"]["x-az-demote-header"] = true;
    $.put.responses["200"].headers["Last-Modified"] = {
      "type": "string",
      "format": "date-time-rfc1123",
      "description": "Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory."
    };
```

### /{shareName}/{directory}?restype=directory&comp=properties
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?restype=directory&comp=properties"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "RawStorageDirectoryInfo";
    $.put.responses["200"].description = "Success, Directory created.";
    $.put.responses["200"].headers["x-ms-request-server-encrypted"]["x-az-demote-header"] = true;
    $.put.responses["200"].headers["Last-Modified"] = {
      "type": "string",
      "format": "date-time-rfc1123",
      "description": "Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory."
    };
```

### /{shareName}/{directory}?restype=directory&comp=list
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.FilesAndDirectoriesSegment) {
        $.FilesAndDirectoriesSegment = $.ListFilesAndDirectoriesSegmentResponse;
        delete $.ListFilesAndDirectoriesSegmentResponse;
        $.FilesAndDirectoriesSegment.required = ["ServiceEndpoint", "ShareName", "DirectoryPath", "NextMarker"];
        const path = $.FilesAndDirectoriesSegment.properties.Segment["$ref"].replace(/[#].*$/, "#/definitions/");
        $.FilesAndDirectoriesSegment.properties.DirectoryItems = {
            "type": "array",
            "items": { "$ref": path + "DirectoryItem" },
            "xml": { "name": "Entries", "wrapped": true }
        };
        $.FilesAndDirectoriesSegment.properties.FileItems = {
            "type": "array",
            "items": { "$ref": path + "FileItem" },
            "xml": { "name": "Entries", "wrapped": true }
        };
        delete $.FilesAndDirectoriesSegment.properties.Segment;
        $.FilesAndDirectoriesSegment["x-az-public"] = false;
        delete $.FilesAndDirectoriesListSegment;
    }
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?restype=directory&comp=list"]
  transform: >
    $.get.responses["200"].headers["Content-Type"]["x-az-demote-header"] = true;
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("FilesAndDirectoriesSegment")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/FilesAndDirectoriesSegment");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### StorageHandlesSegment
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.ShareFileHandle) {
        $.ShareFileHandle = $.HandleItem;
        delete $.HandleItem;
        $.ShareFileHandle.properties.OpenedOn = $.ShareFileHandle.properties.OpenTime;
        $.ShareFileHandle.properties.OpenedOn.xml = { "name": "OpenTime" };
        delete $.ShareFileHandle.properties.OpenTime;
        $.ShareFileHandle.properties.LastReconnectedOn = $.ShareFileHandle.properties.LastReconnectTime;
        $.ShareFileHandle.properties.LastReconnectedOn.xml = { "name": "LastReconnectTime" };
        delete $.ShareFileHandle.properties.LastReconnectTime;
    }
    if (!$.StorageHandlesSegment) {
        $.StorageHandlesSegment = $.ListHandlesResponse;
        delete $.ListHandlesResponse;
        $.StorageHandlesSegment["x-az-public"] = false;
        const path = $.StorageHandlesSegment.properties.HandleList.items.$ref.replace(/[#].*$/, "#/definitions/");
        $.StorageHandlesSegment.properties.Handles = {
            "type": "array",
            "items": { "$ref": path + "ShareFileHandle" },
            "xml": { "name": "Entries", "wrapped": true }
        };
        delete $.StorageHandlesSegment.properties.HandleList;
    }
```

### /{shareName}/{directory}?comp=listhandles
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?comp=listhandles"]
  transform: >
    $.get.responses["200"].headers["Content-Type"]["x-az-demote-header"] = true;
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("StorageHandlesSegment")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/StorageHandlesSegment");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### /{shareName}/{directory}/{fileName}?comp=listhandles
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=listhandles"]
  transform: >
    $.get.responses["200"].headers["Content-Type"]["x-az-demote-header"] = true;
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("StorageHandlesSegment")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/StorageHandlesSegment");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### /{shareName}/{directory}?comp=forceclosehandles
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}?comp=forceclosehandles"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "StorageClosedHandlesSegment";
```

### /{shareName}/{directory}/{fileName}?comp=forceclosehandles
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=forceclosehandles"]
  transform: >
    $.put.responses["200"]["x-az-response-name"] = "StorageClosedHandlesSegment";
```

### /{shareName}/{directory}/{fileName}
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}"]
  transform: >
    $.put.responses["201"]["x-az-response-name"] = "RawStorageFileInfo";
    $.put.responses["201"]["x-az-public"] = false;
    $.get.responses["200"].headers["Content-MD5"]["x-ms-client-name"] = "ContentHash";
    $.get.responses["200"].headers["x-ms-copy-source"].format = "url";
    $.get.responses["200"].headers["x-ms-copy-status"]["x-ms-enum"].name = "CopyStatus";
    $.get.responses["200"].headers["x-ms-content-md5"]["x-ms-client-name"] = "FileContentHash";
    $.get.responses["200"].headers["Content-Encoding"].type = "array";
    $.get.responses["200"].headers["Content-Encoding"].collectionFormat = "csv";
    $.get.responses["200"].headers["Content-Encoding"].items = { "type": "string" };
    $.get.responses["200"].headers["Content-Language"].type = "array";
    $.get.responses["200"].headers["Content-Language"].collectionFormat = "csv";
    $.get.responses["200"].headers["Content-Language"].items = { "type": "string" };
    $.get.responses["200"]["x-az-response-name"] = "FlattenedStorageFileProperties";
    $.get.responses["200"]["x-az-public"] = false;
    $.get.responses["200"]["x-az-response-schema-name"] = "Content";
    $.get.responses["200"]["x-az-stream"] = true;
    $.get.responses["206"].headers["Content-MD5"]["x-ms-client-name"] = "ContentHash";
    $.get.responses["206"].headers["x-ms-copy-source"].format = "url";
    $.get.responses["206"].headers["x-ms-copy-status"]["x-ms-enum"].name = "CopyStatus";
    $.get.responses["206"].headers["x-ms-content-md5"]["x-ms-client-name"] = "FileContentHash";
    $.get.responses["206"].headers["Content-Encoding"].type = "array";
    $.get.responses["206"].headers["Content-Encoding"].collectionFormat = "csv";
    $.get.responses["206"].headers["Content-Encoding"].items = { "type": "string" };
    $.get.responses["206"].headers["Content-Language"].type = "array";
    $.get.responses["206"].headers["Content-Language"].collectionFormat = "csv";
    $.get.responses["206"].headers["Content-Language"].items = { "type": "string" };
    $.get.responses["206"]["x-az-response-name"] = "FlattenedStorageFileProperties";
    $.get.responses["206"]["x-az-public"] = false;
    $.get.responses["206"]["x-az-response-schema-name"] = "Content";
    $.get.responses["206"]["x-az-stream"] = true;
    $.head.responses["200"].headers["Content-MD5"]["x-ms-client-name"] = "ContentHash";
    $.head.responses["200"].headers["Content-Encoding"].type = "array";
    $.head.responses["200"].headers["Content-Encoding"].collectionFormat = "csv";
    $.head.responses["200"].headers["Content-Encoding"].items = { "type": "string" };
    $.head.responses["200"].headers["Content-Language"].type = "array";
    $.head.responses["200"].headers["Content-Language"].collectionFormat = "csv";
    $.head.responses["200"].headers["Content-Language"].items = { "type": "string" };
    $.head.responses["200"].headers["x-ms-copy-status"]["x-ms-enum"].name = "CopyStatus";
    delete $.head.responses["200"].headers["x-ms-type"];
    $.head.responses["200"]["x-az-response-name"] = "RawStorageFileProperties";
    $.head.responses["200"]["x-az-public"] = false;
    $.head.responses.default = {
        "description": "Failure",
        "x-az-response-name": "FailureNoContent",
        "x-az-create-exception": true,
        "x-az-public": false,
        "headers": { "x-ms-error-code": { "x-ms-client-name": "ErrorCode", "type": "string" } }
    };
- from: swagger-document
  where: $.parameters.FileContentLanguage
  transform: >
    $.type = "array";
    $.collectionFormat = "csv";
    $.items = { "type": "string" };
- from: swagger-document
  where: $.parameters.FileContentEncoding
  transform: >
    $.type = "array";
    $.collectionFormat = "csv";
    $.items = { "type": "string" };
```

### /{shareName}/{directory}/{fileName}?comp=range&fromURL
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=range&fromURL"]
  transform: >
    $.put.responses["201"]["x-az-public"] = false;
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

### /{shareName}/{directory}/{fileName}?comp=properties
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=properties"]
  transform: >
    $.put.operationId = "File_SetProperties";
    $.put.responses["200"].description = "Success, File created.";
    $.put.responses["200"].headers["Last-Modified"].description = "Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory.";
    $.put.responses["200"]["x-az-response-name"] = "RawStorageFileInfo";
```

### /{shareName}/{directory}/{fileName}?comp=metadata
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=metadata"]
  transform: >
    $.put.responses["200"].description = "Success, File created.";
    $.put.responses["200"].headers["Last-Modified"] = {
        "type": "string",
        "format": "date-time-rfc1123",
        "description": "Returns the date and time the share was last modified. Any operation that modifies the directory or its properties updates the last modified time. Operations on files do not affect the last modified time of the directory."
    };
    $.put.responses["200"]["x-az-response-name"] = "RawStorageFileInfo";
```

### /{shareName}/{directory}/{fileName}?comp=range
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=range"]
  transform: >
    $.put.responses["201"].headers["Content-MD5"]["x-ms-client-name"] = "ContentHash";
    $.put.responses["201"]["x-az-response-name"] = "ShareFileUploadInfo";
```

### /{shareName}/{directory}/{fileName}?comp=rangelist
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=rangelist"]
  transform: >
    $.get.responses["200"]["x-az-response-name"] = "ShareFileRangeInfoInternal";
    $.get.responses["200"]["x-az-public"] = false;
```

### /{shareName}/{directory}/{fileName}?comp=copy
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=copy"]
  transform: >
    $.put.responses["202"].headers["x-ms-copy-status"]["x-ms-enum"].name = "CopyStatus";
    $.put.responses["202"]["x-az-response-name"] = "ShareFileCopyInfo";
- from: swagger-document
  where: $.parameters.CopySource
  transform: >
    $.format = "url";
```

### DirectoryItem
``` yaml
directive:
- from: swagger-document
  where: $.definitions.DirectoryItem
  transform: $["x-az-public"] = false
```

### FileItem
``` yaml
directive:
- from: swagger-document
  where: $.definitions.FileItem
  transform: $["x-az-public"] = false
```

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode["x-ms-enum"]
  transform: >
    $.name = "ShareErrorCode";
```

### FileProperty
``` yaml
directive:
- from: swagger-document
  where: $.definitions.FileProperty
  transform: >
    $["x-az-public"] = false;
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions.Metrics
  transform: >
    $.type = "object";
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


### ShareProperties properties renaming
``` yaml
directive:
- from: swagger-document
  where: $.definitions.SharePropertiesInternal
  transform: >
    $.properties.QuotaInGB = $.properties.Quota;
    $.properties.QuotaInGB.xml = { "name": "Quota"};
    delete $.properties.Quota;
    $.properties.Etag["x-ms-client-name"] = "ETag";
    delete $.required;
```

### Move Metadata from ShareItem to ShareProperties
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.SharePropertiesInternal.properties.Metadata = {"$ref": "#/definitions/Metadata"};
    delete $.ShareItemInternal.properties.Metadata;
```

### FilePermission
``` yaml
directive:
- from: swagger-document
  where: $.parameters.FilePermission
  transform: >
    $.description = "If specified the permission (security descriptor) shall be set for the directory/file. This header can be used if Permission size is &lt;= 8KB, else x-ms-file-permission-key header shall be used. Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl. Note: Only one of the x-ms-file-permission or x-ms-file-permission-key should be specified.";
```

### Times aren't required
``` yaml
directive:
- from: swagger-document
  where: $.parameters.FileCreationTime
  transform: >
    delete $.format;
- from: swagger-document
  where: $.parameters.FileLastWriteTime
  transform: >
    delete $.format;
```

### Temporarily work around proper JSON support for file permissions
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=filepermission"]
  transform: >
    delete $.put.consumes;
    $.put.responses["201"]["x-az-response-name"] = "PermissionInfo";
    delete $.get.produces;
- from: swagger-document
  where: $.parameters.SharePermission
  transform: >
    $.schema = { "type": "string" };
    $["x-ms-client-name"] = "sharePermissionJson";
- from: swagger-document
  where: $.definitions.SharePermission
  transform: >
    $.type = "string";
    delete $.required;
    delete $.properties;
```

### Prepend File prefix to service property types
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Metrics["x-ms-client-name"] = "ShareMetrics";
    $.Metrics.xml = { "name": "Metrics" };
    $.Metrics.properties.IncludeApis = $.Metrics.properties.IncludeAPIs;
    $.Metrics.properties.IncludeApis.xml = { "name": "IncludeAPIs"};
    delete $.Metrics.properties.IncludeAPIs;
    $.ShareServiceProperties.properties.HourMetrics.xml = { "name": "HourMetrics"};
    $.ShareServiceProperties.properties.MinuteMetrics.xml = { "name": "MinuteMetrics"};
    $.CorsRule["x-ms-client-name"] = "ShareCorsRule";
    $.CorsRule.xml = { "name": "CorsRule"};
    $.ShareServiceProperties.properties.Cors.xml.name = "Cors";
    $.RetentionPolicy["x-ms-client-name"] = "ShareRetentionPolicy";
    $.RetentionPolicy.xml = { "name": "RetentionPolicy"};
```

### Access Policy properties renaming
``` yaml
directive:
- from: swagger-document
  where: $.definitions.AccessPolicy
  transform: >
    $["x-ms-client-name"] = "ShareAccessPolicy";
    $.xml = {"name": "AccessPolicy"};
    $.properties.PolicyStartsOn = $.properties.Start;
    $.properties.PolicyStartsOn.xml = { "name": "Start"};
    delete $.properties.Start;
    $.properties.PolicyExpiresOn = $.properties.Expiry;
    $.properties.PolicyExpiresOn.xml = { "name": "Expiry"};
    delete $.properties.Expiry;
    $.properties.Permissions = $.properties.Permission;
    $.properties.Permissions.xml = { "name": "Permission"};
    delete $.properties.Permission;
```

### ShareQuota properties renaming
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ShareQuota
  transform: >
    $["x-ms-client-name"] = "quotaInGB";
```

### SignedIdentifier
``` yaml
directive:
- from: swagger-document
  where: $.definitions.SignedIdentifier
  transform: >
    $["x-ms-client-name"] = "ShareSignedIdentifier";
    $.xml = {"name": "SignedIdentifier"};
```

### Hide DeleteSnapshotsOptionType
``` yaml
directive:
- from: swagger-document
  where: $.parameters.DeleteSnapshots
  transform: >
    $["x-az-public"] = false;
```

### FileRangeWriteType
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=range"]
  transform: >
    $.put.parameters[3]["x-ms-enum"].name = "ShareFileRangeWriteType";
```

### Hide FileRange
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.FileRange["x-az-public"] = false;
```

### Hide ShareFileRangeList
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ShareFileRangeList["x-az-public"] = false;
```

### Hide ClearRange
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ClearRange["x-az-public"] = false;
```

### /{shareName}/{directory}/{fileName}?comp=lease&acquire
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=lease&acquire"]
  transform: >
    $.put.responses["201"].description = "The lease operation completed successfully.";
    $.put.responses["201"].headers["x-ms-lease-id"].description = "Uniquely identifies a file's lease";
    $.put.responses["201"]["x-az-response-name"] = "ShareFileLease";
```

### /{shareName}?restype=share&comp=lease&acquire
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=lease&acquire"]
  transform: >
    $.put.responses["201"].description = "The lease operation completed successfully.";
    $.put.responses["201"].headers["x-ms-lease-id"].description = "Uniquely identifies a file's lease";
    $.put.responses["201"]["x-az-response-name"] = "ShareFileLease";
```

### /{shareName}/{directory}/{fileName}?comp=lease&release
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=lease&release"]
  transform: >
    $.put.responses["200"].description = "The lease operation completed successfully.";
    $.put.responses["200"]["x-az-response-name"] = "FileLeaseReleaseInfo";
```

### /{shareName}?restype=share&comp=lease&release
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=lease&release"]
  transform: >
    $.put.responses["200"].description = "The lease operation completed successfully.";
    $.put.responses["200"]["x-az-response-name"] = "FileLeaseReleaseInfo";
```

### /{shareName}/{directory}/{fileName}?comp=lease&change
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=lease&change"]
  transform: >
    $.put.responses["200"].description = "The lease operation completed successfully.";
    $.put.responses["200"].headers["x-ms-lease-id"].description = "Uniquely identifies a files's lease";
    $.put.responses["200"]["x-az-response-name"] = "ShareFileLease";
```

### /{shareName}?restype=share&comp=lease&change
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=lease&change"]
  transform: >
    $.put.responses["200"].description = "The lease operation completed successfully.";
    $.put.responses["200"].headers["x-ms-lease-id"].description = "Uniquely identifies a files's lease";
    $.put.responses["200"]["x-az-response-name"] = "ShareFileLease";
```

### /{shareName}/{directory}/{fileName}?comp=lease&break
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=lease&break"]
  transform: >
    $.put.responses["202"]["x-az-response-name"] = "BrokenLease";
    $.put.responses["202"]["x-az-public"] = false;
```

### /{shareName}?restype=share&comp=lease&break
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=lease&break"]
  transform: >
    $.put.responses["202"]["x-az-response-name"] = "BrokenLease";
    $.put.responses["202"]["x-az-public"] = false;
```

### /{shareName}?restype=share&comp=lease&renew
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=lease&renew"]
  transform: >
    $.put.responses["200"].description = "The lease operation completed successfully.";
    $.put.responses["200"].headers["x-ms-lease-id"].description = "Uniquely identifies a files's lease";
    $.put.responses["200"]["x-az-response-name"] = "ShareFileLease";
```

### Make lease duration/break period a long
Lease Duration/Break Period are represented as a TimeSpan in the .NET client libraries, but TimeSpan.MaxValue would overflow an int. Because of this, we are changing the 
type used in the BlobRestClient from an int to a long. This will allow values larger than int.MaxValue (e.g. TimeSpan.MaxValue) to be successfully passed on to the service layer. 
``` yaml
directive:
- from: swagger-document
  where: $.parameters.LeaseDuration
  transform: >
    $.format = "int64";
- from: swagger-document
  where: $.parameters.LeaseBreakPeriod
  transform: >
    $.format = "int64";
```

### FileCopyPermissionCopyMode
``` yaml
directive:
- from: swagger-document
  where: $.parameters.FileCopyPermissionCopyMode
  transform: >
    $["x-ms-enum"]["name"] = "PermissionCopyMode";
```

### LeaseDuration
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-duration"]["x-ms-enum"].name = "ShareLeaseDuration";
    $.get.responses["206"].headers["x-ms-lease-duration"]["x-ms-enum"].name = "ShareLeaseDuration";
    $.head.responses["200"].headers["x-ms-lease-duration"]["x-ms-enum"].name = "ShareLeaseDuration";
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-duration"]["x-ms-enum"].name = "ShareLeaseDuration";
- from: swagger-document
  where: $.definitions.LeaseDuration
  transform: >
    $["x-ms-enum"]["name"] = "ShareLeaseDuration";
```

### LeaseState
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-state"]["x-ms-enum"].name = "ShareLeaseState";
    $.get.responses["206"].headers["x-ms-lease-state"]["x-ms-enum"].name = "ShareLeaseState";
    $.head.responses["200"].headers["x-ms-lease-state"]["x-ms-enum"].name = "ShareLeaseState";
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-state"]["x-ms-enum"].name = "ShareLeaseState";
- from: swagger-document
  where: $.definitions.LeaseState
  transform: >
    $["x-ms-enum"]["name"] = "ShareLeaseState";
```

### LeaseStatus
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-status"]["x-ms-enum"].name = "ShareLeaseStatus";
    $.get.responses["206"].headers["x-ms-lease-status"]["x-ms-enum"].name = "ShareLeaseStatus";
    $.head.responses["200"].headers["x-ms-lease-status"]["x-ms-enum"].name = "ShareLeaseStatus";
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share"]
  transform: >
    $.get.responses["200"].headers["x-ms-lease-status"]["x-ms-enum"].name = "ShareLeaseStatus";
- from: swagger-document
  where: $.definitions.LeaseStatus
  transform: >
    $["x-ms-enum"]["name"] = "ShareLeaseStatus";
```

### Rename ShareRestoreResult
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}?restype=share&comp=undelete"]
  transform: >
    $.put.responses["201"]["x-az-response-name"] = "ShareInfo";
```

### Rename ShareItem fields
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ShareItemInternal.properties.Deleted["x-ms-client-name"] = "IsDeleted";
    $.ShareItemInternal.properties.Version["x-ms-client-name"] = "VersionId";
```

### Rename ShareProperties fields
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.SharePropertiesInternal.properties.DeletedTime["x-ms-client-name"] = "DeletedOn";
```

### Rename DeleteSnapshotsOptionType
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.DeleteSnapshots["x-ms-enum"]["name"] = "ShareSnapshotsDeleteOptionInternal";
```

### Hide SharePropertiesInternal
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.SharePropertiesInternal["x-az-public"] = false;
```

### Hide SharePropertiesInternal
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ShareItemInternal["x-az-public"] = false;
```

### Treat the API version as a parameter instead of a constant
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: >
    delete $.enum
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Files.Shares%2Fswagger%2Freadme.png)

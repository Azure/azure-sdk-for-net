# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/4a93ab078fba7f087116283c8ed169f9b8e30397/specification/storage/data-plane/Microsoft.FileStorage/preview/2020-10-02/file.json
# https://github.com/Azure/autorest/issues/4075
skip-semantics-validation: true
```

### Don't include share name, directory, or file name in path - we have direct URIs.
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('/{shareName}/{directory}/{fileName}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/ShareName") && false == param['$ref'].endsWith("#/parameters/DirectoryPath") && false == param['$ref'].endsWith("#/parameters/FilePath"))});
        } 
        else if (property.includes('/{shareName}/{directory}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/ShareName") && false == param['$ref'].endsWith("#/parameters/DirectoryPath"))});
        }
        else if (property.includes('/{shareName}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/ShareName"))});
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

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode["x-ms-enum"]
  transform: >
    $.name = "ShareErrorCode";
```

### ShareFileRangeList
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.ShareFileRangeList.xml = {
        "name": "Ranges"
    };
```

### Add Last-Modified to SetMetadata
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=metadata"]
  transform: >
    $.put.responses["200"].headers["Last-Modified"] = {
        "type": "string",
        "format": "date-time-rfc1123",
        "description": "Returns the date and time the file was last modified. Any operation that modifies the file, including an update of the file's metadata or properties, changes the last-modified time of the file."
    }
```

### Add Content-MD5 to Put Range from URL
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{shareName}/{directory}/{fileName}?comp=range&fromURL"]
  transform: >
    $.put.responses["201"].headers["Content-MD5"] = {
        "type": "string",
        "format": "byte",
        "description": "This header is returned so that the client can check for message content integrity. The value of this header is computed by the File service; it is not necessarily the same value as may have been specified in the request headers."
    }
```

### Remove ShareName, Directory, and FileName - we have direct URIs
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('/{shareName}/{directory}/{fileName}'))
     {
       $[id.replace('/{shareName}/{directory}/{fileName}', '?shareName_dir_file')] = $[id];
       delete $[id];
     }
     else if (id.includes('/{shareName}/{directory}'))
     {
       $[id.replace('/{shareName}/{directory}', '?shareName_dir')] = $[id];
       delete $[id];
     }
     else if (id.includes('/{shareName}'))
     {
       $[id.replace('/{shareName}', '?shareName')] = $[id];
       delete $[id];
     }
   });
```

### Don't buffer downloads

``` yaml
directive:
- from: swagger-document
  where: $..[?(@.operationId=='File_Download')]
  transform: $["x-csharp-buffer-response"] = false;
```
# File Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate file storage
output-folder: ../src/Generated
clear-output-folder: false

# Use the Azure C# Track 2 generator
# use: C:\src\Storage\Swagger\Generator
# We can't use relative paths here, so use a relative path in generate.ps1
azure-track2-csharp: true
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Metrics.type = "object";
```

### Remove ShareSnapshot as a method parameter.
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.ShareSnapshot["x-ms-parameter-location"];
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

### Replace ShareName, Directory, and FileName with path
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.Path = {
      "name": "path",
      "in": "path",
      "required": true,
      "type": "string",
      "description": "path.",
      "x-ms-skip-url-encoding": true
    };
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{shareName}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/Path"
            });
        };
    }
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
   Object.keys($).map(id => {
     if (id.includes('{shareName}/{directory}/{fileName}'))
     {
       $[id.replace('{shareName}/{directory}/{fileName}', '{path}?restype=file')] = $[id];
       delete $[id];
     }
     if (id.includes('{shareName}/{directory}'))
     {
       $[id.replace('{shareName}/{directory}', '{path}?restype=directory')] = $[id];
       delete $[id];
     }
     if (id.includes('{shareName}'))
     {
       $[id.replace('{shareName}', '{path}')] = $[id];
       delete $[id];
     }
   });
```


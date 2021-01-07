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

### ErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode["x-ms-enum"]
  transform: >
    $.name = "ShareErrorCode";
```

### Add ShareName, Directory, and FileName as a parameters
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    $.ShareName = {
      "name": "shareName",
      "in": "path",
      "required": true,
      "type": "string",
      "x-ms-parameter-location": "method",
      "description": "The share name."
    };
- from: swagger-document
  where: $.parameters
  transform: >
    $.DirectoryName = {
      "name": "directory",
      "in": "path",
      "required": true,
      "type": "string",
      "x-ms-parameter-location": "method",
      "description": "The directory name."
    };
- from: swagger-document
  where: $.parameters
  transform: >
    $.FileName = {
      "name": "fileName",
      "in": "path",
      "required": true,
      "type": "string",
      "x-ms-parameter-location": "method",
      "description": "The file name."
    };
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{shareName}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/ShareName"
            });
        };
        if (property.includes('{directory}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/DirectoryName"
            });
        };
        if (property.includes('{fileName}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/FileName"
            });
        }
    }
```


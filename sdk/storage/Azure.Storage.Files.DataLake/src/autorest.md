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
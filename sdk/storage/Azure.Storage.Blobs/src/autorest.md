# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/011761be1285d14feb41796b5d97df1126495c5c/specification/storage/data-plane/Microsoft.BlobStorage/preview/2020-06-12/blob.json
```

### Move path parameters to constructor.
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.ContainerName["x-ms-parameter-location"];
```

### Add containerName and blob as a parameter
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{containerName}'))
        {
            if (!$[property].parameters)
            {
                $[property].parameters = [];
            }
            $[property].parameters.push({
                "$ref": "#/parameters/ContainerName"
            });
        };
        if (property.includes('{blob}'))
        {
            if (!$[property].parameters)
            {
                $[property].parameters = [];
            }
            $[property].parameters.push({
                "$ref": "#/parameters/Blob"
            });
        };
        if (property.includes('filesystem'))
        {
            delete $[property];
        }
    }
```
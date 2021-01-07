# Queue Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate queue storage
output-folder: ../src/Generated
clear-output-folder: false

# Use the Azure C# Track 2 generator
# use: C:\src\Storage\Swagger\Generator
# We can't use relative paths here, so use a relative path in generate.ps1
azure-track2-csharp: true
```

### GeoReplication
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.GeoReplication.properties.Status["x-ms-enum"].name = "QueueGeoReplicationStatus";
    $.GeoReplication.properties.Status["x-ms-enum"].modelAsString = false;
```

### Add queueName as a parameter
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{queueName}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/QueueName"
            });
        };
        if (property.includes('{messageid}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/MessageId"
            });
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
# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/a9dbc15442bf6e3d4d7c8e12d14f5871568ca614/specification/storage/data-plane/Microsoft.QueueStorage/preview/2018-03-28/queue.json
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

### Make QueueName a constructor parameter
``` yaml
directive:
- from: swagger-document
  where: $.parameters
  transform: >
    delete $.QueueName["x-ms-parameter-location"];
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
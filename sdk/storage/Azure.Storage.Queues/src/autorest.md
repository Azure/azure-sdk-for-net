# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
input-file:
    - https://raw.githubusercontent.com/Azure/azure-rest-api-specs/596d8d2a8c1c50bd6ebe60036143f4c4787fc816/specification/storage/data-plane/Microsoft.QueueStorage/stable/2018-03-28/queue.json
generation1-convenience-client: true
# https://github.com/Azure/autorest/issues/4075
skip-semantics-validation: true
modelerfour:
    seal-single-value-enum-by-default: true

helper-namespace: Azure.Storage.Common
```

### Don't include queue name or message ID path - we have direct URIs.
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('/{queueName}/messages/{messageid}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/QueueName") && false == param['$ref'].endsWith("#/parameters/MessageId"))});
        } 
        else if (property.includes('/{queueName}'))
        {
            $[property]["parameters"] = $[property]["parameters"].filter(function(param) { return (typeof param['$ref'] === "undefined") || (false == param['$ref'].endsWith("#/parameters/QueueName"))});
        }
    }
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


### Add messageId as a parameter
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('{messageid}'))
        {
            $[property].parameters.push({
                "$ref": "#/parameters/MessageId"
            });
        }
    }
```

### Remove queueName as a parameter - we have direct URIs
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]
  transform: >
    for (const property in $)
    {
        if (property.includes('/{queueName}'))
        {
            var oldName = property;
            var newName = property.replace('/{queueName}', '');
            $[newName] = $[oldName];
            delete $[oldName];
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

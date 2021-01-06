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
  where: $.parameters
  transform: >
    delete $.QueueName["x-ms-parameter-location"];
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      }
    ]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}?comp=metadata"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      },
      {
        "name": "comp",
        "in": "query",
        "required": true,
        "type": "string",
        "enum": [
          "metadata"
        ]
      }]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}?comp=acl"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      },
      {
        "name": "comp",
        "in": "query",
        "required": true,
        "type": "string",
        "enum": [
          "acl"
        ]
      }]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      }
    ]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages?visibilitytimeout={visibilityTimeout}&messagettl={messageTimeToLive}"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      },
      ]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages?peekonly=true"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      }
    ]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages/{messageid}?popreceipt={popReceipt}&visibilitytimeout={visibilityTimeout}"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      },
      {
        "$ref": "#/parameters/MessageId"
      }
    ]
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages/{messageid}?popreceipt={popReceipt}"]
  transform: >
    delete $.parameters;
    $.parameters = [
      {
        "$ref": "#/parameters/QueueName"
      },
      {
        "$ref": "#/parameters/MessageId"
      }
    ]
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Metrics.type = "object";
```
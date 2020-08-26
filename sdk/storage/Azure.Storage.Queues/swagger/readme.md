# Queue Storage
> see https://aka.ms/autorest

## Configuration
``` yaml
# Generate queue storage
input-file: https://raw.githubusercontent.com/Azure/azure-rest-api-specs/storage-dataplane-preview/specification/storage/data-plane/Microsoft.QueueStorage/preview/2018-03-28/queue.json
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
    $.namespace = "Azure.Storage.Queues";
    $["client-name"] = "QueueRestClient";
    $["client-extensions-name"] = "QueuesExtensions";
    $["client-model-factory-name"] = "QueuesModelFactory";
    $["x-az-skip-path-components"] = true;
    $["x-az-include-sync-methods"] = true;
    $["x-az-public"] = false;
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

### Ignore common headers
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["x-ms-request-id"]
  transform: >
    $["x-az-demote-header"] = true;
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["x-ms-version"]
  transform:
    $["x-az-demote-header"] = true;
- from: swagger-document
  where: $["x-ms-paths"]..responses..headers["Date"]
  transform:
    $["x-az-demote-header"] = true;
```

### QueueServiceProperties
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.QueueServiceProperties) {
        $.QueueServiceProperties = $.StorageServiceProperties;
        delete $.StorageServiceProperties;
        $.QueueServiceProperties.xml = { "name": "StorageServiceProperties" };
    }
- from: swagger-document
  where: $.parameters
  transform: >
    if (!$.QueueServiceProperties) {
        const props = $.QueueServiceProperties = $.StorageServiceProperties;
        props.name = "QueueServiceProperties";
        props["x-ms-client-name"] = "properties";
        props.schema = { "$ref": props.schema.$ref.replace(/[#].*$/, "#/definitions/QueueServiceProperties") };
        delete $.StorageServiceProperties;
    }
- from: swagger-document
  where: $["x-ms-paths"]["/?restype=service&comp=properties"]
  transform: >
    const param = $.put.parameters[0];
    if (param && param["$ref"] && param["$ref"].endsWith("StorageServiceProperties")) {
        const path = param["$ref"].replace(/[#].*$/, "#/parameters/QueueServiceProperties");
        $.put.parameters[0] = { "$ref": path };
    }
    const def = $.get.responses["200"].schema;
    if (def && def["$ref"] && def["$ref"].endsWith("StorageServiceProperties")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/QueueServiceProperties");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### Make CORS allow null values
It should be possible to pass null for CORS to update service properties without changing existing rules.
``` yaml
directive:
- from: swagger-document
  where: $.definitions.QueueServiceProperties
  transform: >
    $.properties.Cors["x-az-nullable-array"] = true;
```

### QueueServiceStatistics
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.QueueServiceStatistics) {
        $.QueueServiceStatistics = $.StorageServiceStats;
        delete $.StorageServiceStats;
        $.QueueServiceStatistics.xml = { "name": "StorageServiceStats" }
        $.QueueServiceStatistics.description = "Statistics for the storage service.";
    }
- from: swagger-document
  where: $["x-ms-paths"]["/?restype=service&comp=stats"].get.responses["200"]
  transform: >
    if ($.schema && $.schema.$ref && $.schema.$ref.endsWith("StorageServiceStats")) {
        const path = $.schema.$ref.replace(/[#].*$/, "#/definitions/QueueServiceStatistics");
        $.schema = { "$ref": path };
    }
```

### /?comp=list
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.QueuesSegment) {
        $.QueuesSegment = $.ListQueuesSegmentResponse;
        delete $.ListQueuesSegmentResponse;
        $.QueuesSegment["x-az-public"] = false;
        $.QueuesSegment.required = ["ServiceEndpoint"];
    }
- from: swagger-document
  where: $["x-ms-paths"]["/?comp=list"]
  transform: >
    const def = $.get.responses["200"].schema;
    if (!def["$ref"].endsWith("QueuesSegment")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/QueuesSegment");
        $.get.responses["200"].schema = { "$ref": path };
    }
```

### /{queueName}?comp=metadata
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}?comp=metadata"]
  transform: >
    $.get.responses["200"]["x-az-response-name"] = "QueueProperties";
```

### /{queueName}/messages/{messageid}?popreceipt={popReceipt}&visibilitytimeout={visibilityTimeout}
``` yaml
directive:
- from: swagger-document
  where: $["x-ms-paths"]["/{queueName}/messages/{messageid}?popreceipt={popReceipt}&visibilitytimeout={visibilityTimeout}"]
  transform: >
    $.put.responses["204"]["x-az-response-name"] = "UpdateReceipt";
    $.put.responses["204"].headers["x-ms-time-next-visible"]["x-ms-client-name"] = "NextVisibleOn";
```

### QueueErrorCode
``` yaml
directive:
- from: swagger-document
  where: $.definitions.ErrorCode
  transform: >
    $["x-ms-enum"].name = "QueueErrorCode";
```

### GeoReplication
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.QueueGeoReplication) {
        $.QueueGeoReplication = $.GeoReplication;
        delete $.GeoReplication;
        $.QueueGeoReplication.xml = {"name": "GeoReplication"};
        $.QueueGeoReplication.properties.Status["x-ms-enum"].name = "QueueGeoReplicationStatus";
        $.QueueGeoReplication.properties.Status["x-ms-enum"].modelAsString = false;
        const def = $.QueueServiceStatistics.properties.GeoReplication;
        if (!def["$ref"].endsWith("QueueGeoReplication")) {
            const path = def["$ref"].replace(/[#].*$/, "#/definitions/QueueGeoReplication");
            $.QueueServiceStatistics.properties.GeoReplication = {"$ref": path};
        }
        $.QueueGeoReplication.properties.LastSyncedOn = $.QueueGeoReplication.properties.LastSyncTime;
        delete $.QueueGeoReplication.properties.LastSyncTime;
        $.QueueGeoReplication.properties.LastSyncedOn.xml = { "name": "LastSyncTime" };
    }
```

### StorageError
``` yaml
directive:
- from: swagger-document
  where: $.definitions.StorageError
  transform: >
    $.properties.Code = { "type": "string" };
    $["x-az-public"] = false;
```

### Metrics
``` yaml
directive:
- from: swagger-document
  where: $.definitions.Metrics
  transform: >
    $.type = "object"
```


### QueueMessage
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.QueueSendMessage = $.QueueMessage;
    delete $.QueueMessage;
    $.QueueSendMessage["x-az-public"] = false;
    $.QueueSendMessage.xml = { "name": "QueueMessage" };
- from: swagger-document
  where: $.parameters.QueueMessage
  transform: >
    const path = $.schema["$ref"].replace(/[#].*$/, "#/definitions/QueueSendMessage");
    $.schema = {"$ref": path};
    $["x-ms-client-name"] = "message";
- from: swagger-document
  where: $.parameters.RequiredQueueMessage
  transform: >
    const path = $.schema["$ref"].replace(/[#].*$/, "#/definitions/QueueSendMessage");
    $.schema = {"$ref": path};
    $["x-ms-client-name"] = "message";
```

### DequeuedMessage
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.QueueMessage) {
        $.QueueMessage = $.DequeuedMessageItem;
        delete $.DequeuedMessageItem;

        $.QueueMessage.properties.NextVisibleOn = $.QueueMessage.properties.TimeNextVisible;
        $.QueueMessage.properties.NextVisibleOn.xml = {"name": "TimeNextVisible"};
        delete $.QueueMessage.properties.TimeNextVisible;

        $.QueueMessage.properties.InsertedOn = $.QueueMessage.properties.InsertionTime;
        $.QueueMessage.properties.InsertedOn.xml = {"name": "InsertionTime"};
        delete $.QueueMessage.properties.InsertionTime;

        $.QueueMessage.properties.ExpiresOn = $.QueueMessage.properties.ExpirationTime;
        $.QueueMessage.properties.ExpiresOn.xml = {"name": "ExpirationTime"};
        delete $.QueueMessage.properties.ExpirationTime;

        const count = $.QueueMessage.properties.DequeueCount;
        delete $.QueueMessage.properties.DequeueCount;
        $.QueueMessage.properties.DequeueCount = count;
    }
- from: swagger-document
  where: $.definitions.DequeuedMessagesList
  transform: >
    const def = $.items;
    if (!def["$ref"].endsWith("QueueMessage")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/QueueMessage");
        $.items = { "$ref": path };
    }
```

### EnqueuedMessage
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.SendReceipt) {
        $.SendReceipt = $.EnqueuedMessage;
        delete $.EnqueuedMessage;
    }
- from: swagger-document
  where: $.definitions.EnqueuedMessageList
  transform: >
    const def = $.items;
    if (!def["$ref"].endsWith("SendReceipt")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/SendReceipt");
        $.items = { "$ref": path };
    }
```

### EnqueuedMessage
``` yaml
directive:
- from: swagger-document
  where: $.definitions.EnqueuedMessage
  transform: >
    $.properties.NextVisibleOn = $.properties.TimeNextVisible;
    $.properties.NextVisibleOn.xml = {"name": "TimeNextVisible"};
    delete $.properties.TimeNextVisible;

    $.properties.InsertedOn = $.properties.InsertionTime;
    $.properties.InsertedOn.xml = {"name": "InsertionTime"};
    delete $.properties.InsertionTime;

    $.properties.ExpiresOn = $.properties.ExpirationTime;
    $.properties.ExpiresOn.xml = {"name": "ExpirationTime"};
    delete $.properties.ExpirationTime;
```

### PeekedMessage
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    if (!$.PeekedMessage) {
        $.PeekedMessage = $.PeekedMessageItem;
        delete $.PeekedMessageItem;

        $.PeekedMessage.properties.InsertedOn = $.PeekedMessage.properties.InsertionTime;
        $.PeekedMessage.properties.InsertedOn.xml = {"name": "InsertionTime"};
        delete $.PeekedMessage.properties.InsertionTime;

        $.PeekedMessage.properties.ExpiresOn = $.PeekedMessage.properties.ExpirationTime;
        $.PeekedMessage.properties.ExpiresOn.xml = {"name": "ExpirationTime"};
        delete $.PeekedMessage.properties.ExpirationTime;

        const count = $.PeekedMessage.properties.DequeueCount;
        delete $.PeekedMessage.properties.DequeueCount;
        $.PeekedMessage.properties.DequeueCount = count;
    }
- from: swagger-document
  where: $.definitions.PeekedMessagesList
  transform: >
    const def = $.items;
    if (!def["$ref"].endsWith("PeekedMessage")) {
        const path = def["$ref"].replace(/[#].*$/, "#/definitions/PeekedMessage");
        $.items = { "$ref": path };
    }
```

### ListQueuesInclude
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ListQueuesInclude
  transform: >
    $["x-az-public"] = false;
    $.items["x-az-public"] = false;
```

### AccessPolicy
``` yaml
directive:
- from: swagger-document
  where: $.definitions.SignedIdentifier.properties.AccessPolicy
  transform: >
    delete $.description;
- from: swagger-document
  where: $.definitions.SignedIdentifiers.items
  transform: >
    delete $.xml;
- from: swagger-document
  where: $.definitions.SignedIdentifier
  transform: >
    $["x-ms-client-name"] = "QueueSignedIdentifier";
    $.xml = {"name": "SignedIdentifier"};
- from: swagger-document
  where: $.parameters.QueueAcl
  transform: >
    $.name = "permissions";
```

### Set Start/Expiry nullable in AccessPolicy 
``` yaml
directive:
- from: swagger-document
  where: $.definitions.AccessPolicy
  transform: >
     delete $.required;
```

### Access Policy properties renaming
``` yaml
directive:
- from: swagger-document
  where: $.definitions.AccessPolicy
  transform: >
    $["x-ms-client-name"] = "QueueAccessPolicy";
    $.xml = {"name": "AccessPolicy"};
    $.properties.StartsOn = $.properties.Start;
    $.properties.StartsOn.xml = { "name": "Start"};
    delete $.properties.Start;
    $.properties.ExpiresOn = $.properties.Expiry;
    $.properties.ExpiresOn.xml = { "name": "Expiry"};
    delete $.properties.Expiry;
    $.properties.Permissions = $.properties.Permission;
    $.properties.Permissions.xml = { "name": "Permission"};
    delete $.properties.Permission;
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

### Timeout docs
``` yaml
directive:
- from: swagger-document
  where: $.parameters.Timeout
  transform: $.description = "The The timeout parameter is expressed in seconds. For more information, see <a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/setting-timeouts-for-queue-service-operations\">Setting Timeouts for Queue Service Operations.</a>";
```

### Force the API version higher
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: $.enum = [ "2018-11-09" ];
```

### Prepend Queue prefix to service property types
``` yaml
directive:
- from: swagger-document
  where: $.definitions
  transform: >
    $.Logging["x-ms-client-name"] = "QueueAnalyticsLogging";
    $.Logging.xml = { "name": "Logging"};
    $.QueueServiceProperties.properties.Logging.xml = { "name": "Logging"};
    $.Metrics["x-ms-client-name"] = "QueueMetrics";
    $.Metrics.xml = { "name": "Metrics" };
    $.Metrics.properties.IncludeApis = $.Metrics.properties.IncludeAPIs;
    $.Metrics.properties.IncludeApis.xml = { "name": "IncludeAPIs"};
    delete $.Metrics.properties.IncludeAPIs;
    $.QueueServiceProperties.properties.HourMetrics.xml = { "name": "HourMetrics"};
    $.QueueServiceProperties.properties.MinuteMetrics.xml = { "name": "MinuteMetrics"};
    $.CorsRule["x-ms-client-name"] = "QueueCorsRule";
    $.CorsRule.xml = { "name": "CorsRule"};
    $.QueueServiceProperties.properties.Cors.xml.name = "CorsRule";
    $.RetentionPolicy["x-ms-client-name"] = "QueueRetentionPolicy";
    $.RetentionPolicy.xml = { "name": "RetentionPolicy"};
```

### Treat the API version as a parameter instead of a constant
``` yaml
directive:
- from: swagger-document
  where: $.parameters.ApiVersionParameter
  transform: >
    delete $.enum
```

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Queues%2Fswagger%2Freadme.png)

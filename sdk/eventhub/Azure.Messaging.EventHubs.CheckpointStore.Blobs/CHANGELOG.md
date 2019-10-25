# Release History

## 1.0.0-preview.2 (2019-10-09)

### Event Hubs

- The Azure Event Hubs client library has included the Event Hubs fully qualified namespace as part of the checkpoint information, ensuring that there is no conflict between Event Hubs instances in different regions using the same Event Hub and consumer group names.  As a consequence, this library has been updated to reflect these changes.

## 1.0.0-preview.1 (2019-09-13)

Version 1.0.0-preview.1 is a preview of our efforts in creating a checkpoint store library that is developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as possible.  The principles that guide our efforts can be found in the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).
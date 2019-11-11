# Release History

## 1.0.0-preview.3 (2019-11-04)

### Acknowledgments 

Thank you to our developer community members who helped to make the Azure SDKs better with their contributions to this release:

- Vyacheslav Benedichuk _([GitHub](https://github.com/vbenedichuk))_

### Changes

#### Organization and naming

- For consistency with the official nomenclature of the Azure Storage Blobs service, the package has been renamed to `Azure.Messaging.EventHubs.CheckpointStore.Blobs` and the namespaces have also been adjusted to "Blobs."  
  _(A community contribution, courtesy of [vbenedichuk](https://github.com/vbenedichuk))_

- Some minor documentation updates to reflect the changes made to the `EventProcessorClient` and its associated namespaces.

## 1.0.0-preview.2 (2019-10-09)

### Changes

#### Event Hubs

- The Azure Event Hubs client library has included the Event Hubs fully qualified namespace as part of the checkpoint information, ensuring that there is no conflict between Event Hubs instances in different regions using the same Event Hub and consumer group names.  As a consequence, this library has been updated to reflect these changes.

## 1.0.0-preview.1 (2019-09-13)

Version 1.0.0-preview.1 is a preview of our efforts in creating a checkpoint store library that is developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as possible.  The principles that guide our efforts can be found in the [Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).
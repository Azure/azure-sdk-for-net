---
page_type: sample
languages:
- csharp
products:
- azure
- azure-event-hubs
name: Azure.Messaging.EventHubs samples for .NET
description: Samples for the Azure.Messaging.EventHubs client library
---

# Azure.Messaging.EventHubs Samples

The  Azure Event Hubs samples are accompanied by a [console application](./Program.cs) which you can use to execute and debug them interactively.  The simplest way to begin is to launch the project for debugging in Visual Studio or your preferred IDE and provide the Event Hubs connection information in response to the prompts.

Each of the samples is self-contained and focused on illustrating one specific scenario.  Each is numbered, with the lower numbers concentrating on basic scenarios and building to more complex scenarios as they increase; though each sample is independent, it will assume an understanding of the content discussed in earlier samples.

- [Hello world](./Sample01_HelloWorld.cs)
  An introduction to Event Hubs, illustrating how to create a client and explore an Event Hub.

- [Create an Event Hub client with custom options](./Sample02_ClientWithCustomOptions.cs)
  An introduction to Event Hubs, exploring additional options for creating the different Event Hub clients.

- [Publish an event to an Event Hub](./Sample03_PublishAnEvent.cs)
  An introduction to publishing events, using a simple Event Hub producer client.

- [Publish events using a partition key](./Sample04_PublishEventsWithPartitionKey.cs)
  An introduction to publishing events, using a partition key to group them together.

- [Publish a size-limited batch of events](./Sample05_PublishAnEventBatch.cs)
  An introduction to publishing events, using a size-aware batch to ensure the size does not exceed the transport size limits.

- [Publish events to a specific Event Hub partition](./Sample06_PublishEventsToSpecificPartitions.cs)
  An introduction to publishing events, using an Event Hub producer client that is associated with a specific partition.

- [Publish events with custom metadata](./Sample07_PublishEventsWithCustomMetadata.cs)
  An example of publishing events, extending the event data with custom metadata.

- [Consume events from an Event Hub partition](./Sample08_ConsumeEvents.cs)
  An introduction to consuming events, using a simple Event Hub consumer client.

- [Consume events from an Event Hub partition, limiting the period of time to wait for an event](./Sample09_ConsumeEventsWithMaximumWaitTime.cs)
  An introduction to consuming events, using an Event Hub consumer client with maximum wait time.

- [Consume events from a known position in the Event Hub partition](./Sample10_ConsumeEventsFromAKnownPosition.cs)
  An example of consuming events, starting at a well-known position in the Event Hub partition.

- [Consume events from all partitions of an Event Hub with the Event Processor](./Sample11_ConsumeEventsWithEventProcessor.cs)
  An example of consuming events from all Event Hub partitions at once, using the Event Processor client.

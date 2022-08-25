
# Mocking Client Types
Event Hubs is built to be entirely mockable, an important feature that allows for testing the library. The following snippets demonstrate how to mock each client type and relevant data types.

## `EventHubProducerClient`

### Testing Batching logic 
When writing an application that uses batches to send events to an Event Hub, you may have logic surrounding how you manipulate events when adding them to the batch. For example, if you have an application that occasionally sends events that are larger than the maximum size of a batch. One way to test this method is to mock the `EventHubProducerClient` and `EventDataBatch` types, and focus testing on the application-defined method instead.

Note: This scenario is simplified for illustrative purposes. 
```C# Snippet:EventHubs_Sample11_Batching
```

## `EventHubConsumerClient`

### Testing Event Hubs property-driven application logic
Applications may want to implement throttling logic when there are high volumes of events being published to the Event Hub. One way to implement this could be through querying properties of the Event Hub and its partitions. Note that querying the properties of Event Hubs often can negatively impact performance, so in production scenarios this needs to be done carefully.

```C# Snippet:EventHubs_Sample11_Properties
```
Mocking the properties above can be done in the same way for the `EventHubProducerClient`, since the properties are returned in a similar way.

## `EventProcessorClient`


## `EventProcessor<TPartition>`

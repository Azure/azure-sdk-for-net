
# Mocking Client Types
Event Hubs is built to be entirely mockable. This is an important feature that allows developers to write tests focused on their own application logic, even if they are dependent on the Event Hubs types.

The following snippets demonstrate how to mock each client type and relevant data types.

## Testing Batching logic

Some applications may need to manipulate events based on the result of trying to add them to a batch. For example, if an application occasionally sends events that are larger than the maximum size of a batch, it may need to split a large event into a few smaller ones. One way to test a method like this is to mock the `EventHubProducerClient` and `EventDataBatch` types, and focus testing on the application-defined method instead.

The following method illustrates a very simple way that an application could use a method that splits events.
```C# Snippet:EventHubs_Sample11_SimpleBatchingLogic
```

One way to test a method like this would be to use mocking client types.
```C# Snippet:EventHubs_Sample11_SimpleBatchingLogic_Test
```

## Testing Event Hub property-driven application logic

```C# Snippet:EventHubs_Sample11_SimplePropertiesLogic
```

```C# Snippet:EventHubs_Sample11_SimplePropertiesLLogicTest
```

Mocking the properties above can be done in the same way for the `EventHubProducerClient`, since the properties are returned in a similar way.

## Testing partition property-driven application logic

Applications may want to implement throttling logic when there are high volumes of events being published to the Event Hub. One way to implement this could be through querying properties of the Event Hub and its partitions. Note that repeatedly querying the properties of Event Hubs negatively impacts performance, so in production scenarios this needs to be done carefully.

```C# Snippet:EventHubs_Sample12_PartitionPropertiesLogic
```

```C# Snippet:EventHubs_Sample12_PartitionPropertiesLogic_Test
```




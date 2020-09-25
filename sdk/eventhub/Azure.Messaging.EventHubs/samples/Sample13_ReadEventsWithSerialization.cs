// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Avro;
using Avro.Generic;
using Azure.Data.SchemaRegistry;
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;
using Microsoft.Azure.Data.SchemaRegistry.ApacheAvro;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    ///   An introduction to reading all events available from an Event Hub.
    /// </summary>
    ///
    public class Sample13_ReadEventsWithSerialization : IEventHubsSchemaRegistrySample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample13_ReadEventsWithSerialization);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An introduction to reading all events available from an Event Hub using an ObjectSerializer.";

        /// <summary>
        ///   Runs the sample using the specified Event Hubs connection information.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub, sometimes known as its path, that the sample should run against.</param>
        /// <param name="schemaGroupName">The name of the schema group in the Schema Registry.</param>
        /// <param name="tenantId">The Azure Active Directory tenant that holds the service principal.</param>
        /// <param name="clientId">The Azure Active Directory client identifier of the service principal.</param>
        /// <param name="secret">The Azure Active Directory secret of the service principal.</param>
        ///
        public async Task RunAsync(string fullyQualifiedNamespace,
                                   string eventHubName,
                                   string schemaGroupName,
                                   string tenantId,
                                   string clientId,
                                   string secret)
        {
            // Service principal authentication is a means for applications to authenticate against Azure Active
            // Directory and consume Azure services. This is advantageous compared to using a connection string for
            // authorization, as it offers a far more robust mechanism for transparently updating credentials in place,
            // without an application being explicitly aware or involved.
            //
            // For this example, we'll take advantage of a service principal to publish and receive events.  To do so, we'll make
            // use of the ClientSecretCredential from the Azure.Identity library to enable the Event Hubs clients to perform authorization
            // using a service principal.

            ClientSecretCredential credential = new ClientSecretCredential(tenantId, clientId, secret);

            // This client is used to connect to Azure Schema Registry. This will allow us to serialize Avro messages without encoding
            // the schema into the message. Instead, the schema ID from the Azure Schema Registry will be used.

            SchemaRegistryClient schemaRegistryClient = new SchemaRegistryClient(fullyQualifiedNamespace, credential);

            // Creating the Avro serializer requires the SchemaRegistryClient. Setting AutoRegisterSchemas to true allows any schema
            // provided to Azure Schema Registry to be added to the registry automatically.

            SchemaRegistryAvroObjectSerializer avroSerializer = new SchemaRegistryAvroObjectSerializer(schemaRegistryClient, schemaGroupName,
                new SchemaRegistryAvroObjectSerializerOptions { AutoRegisterSchemas = true });

            // This defines the Message schema a single time to be used for all of our generic records.

            RecordSchema exampleSchema = (RecordSchema)Schema.Parse(
                "{\"type\":\"record\",\"name\":\"Message\",\"namespace\":\"ExampleSchema\",\"fields\":[{\"name\":\"Message\",\"type\":\"string\"}]}");

            // To start, we'll publish a small number of events using a producer client.  To ensure that our client is appropriately closed, we'll
            // take advantage of the asynchronous dispose when we are done or when an exception is encountered.

            await using (var producerClient = new EventHubProducerClient(fullyQualifiedNamespace, eventHubName, credential))
            {
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                GenericRecord firstEventRecord = new GenericRecord(exampleSchema);
                firstEventRecord.Add("Message", "Hello, Event Hubs!");
                EventData firstEvent = new EventData(new BinaryData(firstEventRecord, avroSerializer, typeof(GenericRecord)));
                eventBatch.TryAdd(firstEvent);

                GenericRecord secondEventRecord = new GenericRecord(exampleSchema);
                secondEventRecord.Add("Message", "The middle event is this one");
                EventData secondEvent = new EventData(new BinaryData(secondEventRecord, avroSerializer, typeof(GenericRecord)));
                eventBatch.TryAdd(secondEvent);

                GenericRecord thirdEventRecord = new GenericRecord(exampleSchema);
                thirdEventRecord.Add("Message", "Goodbye, Event Hubs!");
                EventData thirdEvent = new EventData(new BinaryData(thirdEventRecord, avroSerializer, typeof(GenericRecord)));
                eventBatch.TryAdd(thirdEvent);

                await producerClient.SendAsync(eventBatch);

                Console.WriteLine("The event batch has been published.");
            }

            // Now that the events have been published, we'll read back all events from the Event Hub using a consumer client.
            // It's important to note that because events are not removed from the partition when consuming, that if you're using
            // an existing Event Hub for the sample, you will see events that were published prior to running this sample as well
            // as those from the batch that we just sent.
            //
            // An Event Hub consumer is associated with a specific Event Hub and consumer group.  The consumer group is
            // a label that identifies one or more consumers as a set.  Often, consumer groups are named after the responsibility
            // of the consumer in an application, such as "Telemetry" or "OrderProcessing".  When an Event Hub is created, a default
            // consumer group is created with it, called "$Default."
            //
            // Each consumer has a unique view of the events in a partition that it reads from, meaning that events are available to all
            // consumers and are not removed from the partition when a consumer reads them.  This allows for one or more consumers to read and
            // process events from the partition at different speeds and beginning with different events without interfering with
            // one another.
            //
            // When events are published, they will continue to exist in the partition and be available for consuming until they
            // reach an age where they are older than the retention period.
            // (see: https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-faq#what-is-the-maximum-retention-period-for-events)
            //
            // In this example, we will create our consumer client using the default consumer group that is created with an Event Hub.
            // Our consumer will begin watching the partition at the very end, reading only new events that we will publish for it.

            await using (var consumerClient = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, fullyQualifiedNamespace, eventHubName, credential))
            {
                // To ensure that we do not wait for an indeterminate length of time, we'll stop reading after we receive three events.  For a
                // fresh Event Hub, those will be the three that we had published.  We'll also ask for cancellation after 30 seconds, just to be
                // safe.

                using CancellationTokenSource cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                int eventsRead = 0;
                int maximumEvents = 3;

                await foreach (PartitionEvent partitionEvent in consumerClient.ReadEventsAsync(cancellationSource.Token))
                {
                    BinaryData binaryData = partitionEvent.Data.BodyAsBinaryData;
                    GenericRecord eventRecord = binaryData.ToObject<GenericRecord>(avroSerializer);
                    string messageText = (string)eventRecord["Message"];
                    Console.WriteLine($"Event Read: { messageText }");
                    eventsRead++;

                    if (eventsRead >= maximumEvents)
                    {
                        break;
                    }
                }
            }

            // At this point, our clients have both passed their "using" scopes and have safely been disposed of.  We
            // have no further obligations.

            Console.WriteLine();
        }
    }
}

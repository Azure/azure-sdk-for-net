// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests.Samples
{
    public partial class EventGridSamples : SamplesBase<EventGridTestEnvironment>
    {
        // Example JSON payloads
        private readonly string jsonPayloadSampleOne = "[{ \"id\": \"2d1781af-3a4c\", \"topic\": \"/examples/test/payload\", \"subject\": \"\",  \"data\": { \"Name\": \"example\",\"Age\": 20 },\"eventType\": \"MyApp.Models.CustomEventType\",\"eventTime\": \"2018-01-25T22:12:19.4556811Z\",\"dataVersion\": \"1\"}]";

        private readonly string jsonPayloadSampleTwo = "[{ \"id\": \"2d1781af-3a4c\", \"source\": \"/examples/test/payload\", \"data\": { \"name\": \"example\",\"age\": 20 },\"type\": \"MyApp.Models.CustomEventType\",\"time\": \"2018-01-25T22:12:19.4556811Z\",\"specversion\": \"1\"}]";

        // This sample demonstrates how to parse EventGridEvents from JSON and access event data using AsSystemEventData()
        [Test]
        public void NonGenericReceiveAndDeserializeEventGridEvents()
        {
            #region Snippet:EGEventParseJson
            // Parse the JSON payload into a list of events using EventGridEvent.Parse
            EventGridEvent[] egEvents = EventGridEvent.Parse(jsonPayloadSampleOne);
            #endregion

            // Iterate over each event to access event properties and data
            #region Snippet:DeserializePayloadUsingAsSystemEventData
            foreach (EventGridEvent egEvent in egEvents)
            {
                // If the event is a system event, AsSystemEventData() should return the correct system event type
                if (egEvent.IsSystemEvent)
                {
                    switch (egEvent.AsSystemEventData())
                    {
                        case SubscriptionValidationEventData subscriptionValidated:
                            Console.WriteLine(subscriptionValidated.ValidationCode);
                            break;
                        case StorageBlobCreatedEventData blobCreated:
                            Console.WriteLine(blobCreated.BlobType);
                            break;
                        // Handle any other system event type
                        default:
                            Console.WriteLine(egEvent.EventType);
                            // we can get the raw Json for the event using GetData()
                            Console.WriteLine(egEvent.GetData().ToString());
                            break;
                    }
                }
                else
                {
                    switch (egEvent.EventType)
                    {
                        case "MyApp.Models.CustomEventType":
                            TestPayload deserializedEventData = egEvent.GetData<TestPayload>();
                            Console.WriteLine(deserializedEventData.Name);
                            break;
                        // Handle any other custom event type
                        default:
                            Console.Write(egEvent.EventType);
                            Console.WriteLine(egEvent.GetData().ToString());
                            break;
                    }
                }
            }
            #endregion
        }

        // This sample demonstrates how to parse CloudEvents from JSON and access event data using GetData<T>()
        [Test]
        public async Task GenericReceiveAndDeserializeEventGridEvents()
        {
            // Example of a custom ObjectSerializer used to deserialize the event payload
            JsonObjectSerializer myCustomSerializer = new JsonObjectSerializer(
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            #region Snippet:CloudEventParseJson
            // Parse the JSON payload into a list of events using CloudEvent.Parse
            CloudEvent[] cloudEvents = CloudEvent.Parse(jsonPayloadSampleTwo);
            #endregion

            // Iterate over each event to access event properties and data
            #region Snippet:DeserializePayloadUsingGenericGetData
            foreach (CloudEvent cloudEvent in cloudEvents)
            {
                switch (cloudEvent.Type)
                {
                    case "Contoso.Items.ItemReceived":
                        // By default, GetData uses JsonObjectSerializer to deserialize the payload
                        ContosoItemReceivedEventData itemReceived = cloudEvent.GetData<ContosoItemReceivedEventData>();
                        Console.WriteLine(itemReceived.ItemSku);
                        break;
                    case "MyApp.Models.CustomEventType":
                        // One can also specify a custom ObjectSerializer as needed to deserialize the payload correctly
                        TestPayload testPayload = await cloudEvent.GetDataAsync<TestPayload>(myCustomSerializer);
                        Console.WriteLine(testPayload.Name);
                        break;
                    case "Microsoft.Storage.BlobDeleted":
                        // Example for deserializing system events using GetData<T>
                        StorageBlobDeletedEventData blobDeleted = cloudEvent.GetData<StorageBlobDeletedEventData>();
                        Console.WriteLine(blobDeleted.BlobType);
                        break;
                }
            }
            #endregion
        }
    }
}

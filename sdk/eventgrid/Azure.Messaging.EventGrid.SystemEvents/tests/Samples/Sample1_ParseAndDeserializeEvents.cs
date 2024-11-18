// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests.Samples
{
    public partial class EventGridSamples
    {
        // Example JSON payloads
        private readonly string jsonPayloadSampleOne = "[{ \"id\": \"2d1781af-3a4c\", \"source\": \"/examples/test/payload\", \"subject\": \"\",  \"data\": { \"Name\": \"example\",\"Age\": 20 },\"type\": \"MyApp.Models.CustomEventType\",\"time\": \"2018-01-25T22:12:19.4556811Z\",\"specversion\": \"1.0\"}]";

        private readonly string jsonPayloadSampleTwo = "[{ \"id\": \"2d1781af-3a4c\", \"source\": \"/examples/test/payload\", \"data\": { \"name\": \"example\",\"age\": 20 },\"type\": \"MyApp.Models.CustomEventType\",\"time\": \"2018-01-25T22:12:19.4556811Z\",\"specversion\": \"1.0\"}]";

        // This sample demonstrates how to parse EventGridEvents from JSON and access event data using TryGetSystemEventData
        [Test]
        public void NonGenericReceiveAndDeserializeCloudEvents()
        {
            var httpContent = new BinaryData(jsonPayloadSampleOne).ToStream();
            // Parse the JSON payload into a list of events
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(BinaryData.FromStream(httpContent));

            // Iterate over each event to access event properties and data
            #region Snippet:SystemEventsDeserializePayloadUsingTryGetSystemEventData
            foreach (CloudEvent cloudEvent in cloudEvents)
            {
                // If the event is a system event, TryGetSystemEventData will return the deserialized system event
                if (cloudEvent.TryGetSystemEventData(out object systemEvent))
                {
                    switch (systemEvent)
                    {
                        case SubscriptionValidationEventData subscriptionValidated:
                            Console.WriteLine(subscriptionValidated.ValidationCode);
                            break;
                        case StorageBlobCreatedEventData blobCreated:
                            Console.WriteLine(blobCreated.BlobType);
                            break;
                        // Handle any other system event type
                        default:
                            Console.WriteLine(cloudEvent.Type);
                            // we can get the raw Json for the event using Data
                            Console.WriteLine(cloudEvent.Data.ToString());
                            break;
                    }
                }
                else
                {
                    switch (cloudEvent.Type)
                    {
                        case "MyApp.Models.CustomEventType":
                            TestPayload deserializedEventData = cloudEvent.Data.ToObjectFromJson<TestPayload>();
                            Console.WriteLine(deserializedEventData.Name);
                            break;
                        // Handle any other custom event type
                        default:
                            Console.Write(cloudEvent.Type);
                            Console.WriteLine(cloudEvent.Data.ToString());
                            break;
                    }
                }
            }
            #endregion
        }

        // This sample demonstrates how to parse CloudEvents from JSON and access event data using ToObjectFromJson
        [Test]
        public async Task GenericReceiveAndDeserializeEventGridEvents()
        {
            // Example of a custom ObjectSerializer used to deserialize the event payload
            JsonObjectSerializer myCustomSerializer = new JsonObjectSerializer(
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            var httpContent = new StreamContent(new BinaryData(jsonPayloadSampleTwo).ToStream());
            #region Snippet:SystemEventsCloudEventParseJson
            var bytes = await httpContent.ReadAsByteArrayAsync();
            // Parse the JSON payload into a list of events
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(new BinaryData(bytes));
            #endregion

            // Iterate over each event to access event properties and data
            #region Snippet:SystemEventsDeserializePayloadUsingGenericGetData
            foreach (CloudEvent cloudEvent in cloudEvents)
            {
                switch (cloudEvent.Type)
                {
                    case "Contoso.Items.ItemReceived":
                        // By default, ToObjectFromJson<T> uses System.Text.Json to deserialize the payload
                        ContosoItemReceivedEventData itemReceived = cloudEvent.Data.ToObjectFromJson<ContosoItemReceivedEventData>();
                        Console.WriteLine(itemReceived.ItemSku);
                        break;
                    case "MyApp.Models.CustomEventType":
                        // One can also specify a custom ObjectSerializer as needed to deserialize the payload correctly
                        TestPayload testPayload = cloudEvent.Data.ToObject<TestPayload>(myCustomSerializer);
                        Console.WriteLine(testPayload.Name);
                        break;
                    case SystemEventNames.StorageBlobDeleted:
                        // Example for deserializing system events using ToObjectFromJson<T>
                        StorageBlobDeletedEventData blobDeleted = cloudEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                        Console.WriteLine(blobDeleted.BlobType);
                        break;
                }
            }
            #endregion
        }

        internal class TestPayload
        {
            public TestPayload(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public TestPayload() { }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class ContosoItemReceivedEventData
        {
            public string ItemSku { get; set; }

            public string ItemUri { get; set; }
        }
    }
}

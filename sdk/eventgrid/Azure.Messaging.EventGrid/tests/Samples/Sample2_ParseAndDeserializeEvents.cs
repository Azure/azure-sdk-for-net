// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Messaging.EventGrid.SystemEvents;
using Azure.Messaging.ServiceBus;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests.Samples
{
    public partial class EventGridSamples : EventGridLiveTestBase
    {
        [Test]
        public async Task NonGenericReceiveAndDeserializeEventGridEvents()
        {
            // Create the ServiceBus client and receiver
            ServiceBusClient serviceBusClient = new ServiceBusClient("SERVICE BUS CONNECTION STRING");
            ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver("SERVICE BUS QUEUE NAME");

            ServiceBusReceivedMessage receivedMessage = await serviceBusReceiver.ReceiveMessageAsync();
            await serviceBusReceiver.CompleteMessageAsync(receivedMessage);

            #region Snippet:ParseJson
            // Event Grid delivers a single event per message when routing events to a Service Bus Queue or Topic
            // So egEvents should only have one event
            EventGridEvent egEvent = EventGridEvent.Parse(receivedMessage.Body)[0];

            // Another approach for parsing an event from a Service Bus message is to call `ToEventGridEvent` on the message body
            EventGridEvent egEventExtra = receivedMessage.Body.ToEventGridEvent();
            #endregion

            #region Snippet:DeserializePayloadUsingNonGenericGetData
            // Access event data by calling GetData() or GetData<T>()
            // If the event is a system event, GetData() should return the correct system event type
            switch (egEvent.GetData())
            {
                case SubscriptionValidationEventData subscriptionValidated:
                    Console.WriteLine(subscriptionValidated.ValidationCode);
                    break;
                case StorageBlobCreatedEventData blobCreated:
                    Console.WriteLine(blobCreated.BlobType);
                    break;
                case BinaryData unknownType:
                    // An unrecognized event type - GetData() returns BinaryData with the serialized JSON payload
                    if (egEvent.EventType == "MyApp.Models.CustomEventType")
                    {
                        // You can use BinaryData methods to deserialize the payload
                        TestPayload deserializedEventData = await unknownType.DeserializeAsync<TestPayload>();
                        Console.WriteLine(deserializedEventData.Name);
                    }
                    break;
            }
            #endregion
        }

        public async Task GenericReceiveAndDeserializeEventGridEvents()
        {
            JsonObjectSerializer myCustomSerializer = new JsonObjectSerializer(
            new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            });

            // Create the ServiceBus client and receiver
            ServiceBusClient serviceBusClient = new ServiceBusClient("SERVICE BUS CONNECTION STRING");
            ServiceBusReceiver serviceBusReceiver = serviceBusClient.CreateReceiver("SERVICE BUS QUEUE NAME");

            ServiceBusReceivedMessage receivedMessage = await serviceBusReceiver.ReceiveMessageAsync();
            await serviceBusReceiver.CompleteMessageAsync(receivedMessage);

            // Event Grid delivers a single event per message when routing events to a Service Bus Queue or Topic
            // So egEvents should only have one event
            EventGridEvent egEvent = EventGridEvent.Parse(receivedMessage.Body)[0];

            #region Snippet:DeserializePayloadUsingGenericGetData
            switch (egEvent.EventType)
            {
                case "Contoso.Items.ItemReceived":
                    // By default, GetData uses JsonObjectSerializer to deserialize the payload
                    ContosoItemReceivedEventData itemReceived = egEvent.GetData<ContosoItemReceivedEventData>();
                    Console.WriteLine(itemReceived.ItemSku);
                    break;
                case "MyApp.Models.CustomEventType":
                    // One can also specify a custom ObjectSerializer as needed to deserialize the payload correctly
                    TestPayload testPayload = await egEvent.GetDataAsync<TestPayload>(_myCustomSerializer);
                    Console.WriteLine(testPayload.Name);
                    break;
                case "Microsoft.EventGrid.SubscriptionValidationEvent":
                    SubscriptionValidationEventData subscriptionValidated = egEvent.GetData<SubscriptionValidationEventData>();
                    Console.WriteLine(subscriptionValidated.ValidationCode);
                    break;
            }
            #endregion
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class JobRouterChangeNotification : SamplesBase<RouterTestEnvironment>
    {
        // Example JSON payloads
        private readonly string jsonPayloadSampleOne = "{\"id\":\"1027db4a-17fe-4a7f-ae67-276c3120a29f\",\"topic\":\"/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}\",\"subject\":\"worker/{worker-id}/job/{job-id}\",\"data\":{\"workerId\":\"w100\",\"jobId\":\"7f1df17b-570b-4ae5-9cf5-fe6ff64cc712\",\"channelReference\":\"test-abc\",\"channelId\":\"FooVoiceChannelId\",\"queueId\":\"625fec06-ab81-4e60-b780-f364ed96ade1\",\"offerId\":\"525fec06-ab81-4e60-b780-f364ed96ade1\",\"offerTimeUtc\":\"2021-06-23T02:43:30.3847144Z\",\"expiryTimeUtc\":\"2021-06-23T02:44:30.3847674Z\",\"jobPriority\":5,\"jobLabels\":{\"Locale\":\"en-us\",\"Segment\":\"Enterprise\",\"Token\":\"FooToken\"},\"jobTags\":{\"Locale\":\"en-us\",\"Segment\":\"Enterprise\",\"Token\":\"FooToken\"}},\"eventType\":\"Microsoft.Communication.WorkerOfferIssued\",\"dataVersion\":\"1.0\",\"metadataVersion\":\"1\",\"eventTime\":\"2022-02-17T00:55:25.1736293Z\"}";

        // This is a temporary fix before Router events are on-boarded as system events
        internal class AcsRouterWorkerOfferIssuedEventData
        {
            public string WorkerId { get; set; } = default!;

            public string JobId { get; set; } = default!;

            public string ChannelReference { get; set; } = default!;

            public string ChannelId { get; set; } = default!;

            public string QueueId { get; set; } = default!;

            public string OfferId { get; set; } = default!;

            public DateTimeOffset OfferTimeUtc { get; set; } = default!;

            public DateTimeOffset ExpiryTimeUtc { get; set; } = default!;

            public int JobPriority { get; set; } = default!;

            public Dictionary<string, object> JobLabels { get; set; } = default!;

            public Dictionary<string, object> JobTags { get; set; } = default!;
        }

        [Test]
        public void ReceivedChangeNotification()
        {
            var httpContent = new BinaryData(jsonPayloadSampleOne).ToStream();
            #region Snippet:EGEventParseJson

            // Parse the JSON payload into a list of events
            EventGridEvent[] egEvents = EventGridEvent.ParseMany(BinaryData.FromStream(httpContent));

            #endregion Snippet:EGEventParseJson

            // Iterate over each event to access event properties and data

            #region Snippet:DeserializePayloadUsingAsSystemEventData
            string offerId;
            foreach (EventGridEvent egEvent in egEvents)
            {
                // This is a temporary fix before Router events are on-boarded as system events
                switch (egEvent.EventType)
                {
                    case "Microsoft.Communication.WorkerOfferIssued":
                        AcsRouterWorkerOfferIssuedEventData? deserializedEventData =
                            egEvent.Data.ToObjectFromJson<AcsRouterWorkerOfferIssuedEventData>();
                        Console.Write(deserializedEventData?.OfferId); // Offer Id
                        offerId = deserializedEventData?.OfferId ?? string.Empty;
                        break;
                    // Handle any other custom event type
                    default:
                        Console.Write(egEvent.EventType);
                        Console.WriteLine(egEvent.Data.ToString());
                        break;
                }
            }

            #endregion Snippet:DeserializePayloadUsingAsSystemEventData
        }
    }
}

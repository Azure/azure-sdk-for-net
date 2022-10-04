﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Helper class for parsing Acs call back events.
    /// </summary>
    public static class CallAutomationEventParser
    {
        /// <summary>
        /// Parsing a CallAutomation event from a CloudEvent.
        /// </summary>
        public const string EventPrefix = "Microsoft.Communication.";

        /// <summary>
        /// Parsing a CallAutomation event from a CloudEvent.
        /// </summary>
        /// <param name="cloudEvent"><see cref="CloudEvent"/>.</param>
        /// <returns>A <see cref="CallAutomationEventBase"/> object.</returns>
        public static CallAutomationEventBase Parse(CloudEvent cloudEvent)
        {
            return Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
        }

        /// <summary>
        /// Parsing a CallAutomation event from BinaryData.
        /// </summary>
        /// <param name="json">event json in BinaryData format.</param>
        /// <returns>A <see cref="CallAutomationEventBase"/> object.</returns>
        public static CallAutomationEventBase Parse(BinaryData json)
        {
            CloudEvent cloudEvent = CloudEvent.Parse(json);
            return Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
        }

        /// <summary>
        /// Parsing a CallAutomation event given the data and event type of the payload.
        /// </summary>
        /// <param name="eventData">the event data of a <see cref="CloudEvent"/> in string.</param>
        /// <param name="eventType">the event type of a <see cref="CloudEvent"/> in string.</param>
        /// <returns>An array of <see cref="CallAutomationEventBase"/> object.</returns>
        public static CallAutomationEventBase Parse(string eventData, string eventType)
        {
            return Deserialize(eventData, eventType);
        }

        /// <summary>
        /// Parsing CallAutomation events from an array of CloudEvent.
        /// </summary>
        /// <param name="cloudEvents"><see cref="CloudEvent"/>.</param>
        /// <returns>An array of <see cref="CallAutomationEventBase"/> object.</returns>
        public static CallAutomationEventBase[] ParseMany(CloudEvent[] cloudEvents)
        {
            var callAutomationEvents = new CallAutomationEventBase[cloudEvents.Length];
            for (int i = 0; i < cloudEvents.Length; i++)
            {
                var cloudEvent = cloudEvents[i];
                callAutomationEvents[i] = Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
            }
            return callAutomationEvents;
        }

        /// <summary>
        /// Parsing CallAutomation events from BinaryData.
        /// </summary>
        /// <param name="json"> events json in BinaryData format.</param>
        /// <returns>An array of <see cref="CallAutomationEventBase"/> object.</returns>
        public static CallAutomationEventBase[] ParseMany(BinaryData json)
        {
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(json);
            var callAutomationEvents = new CallAutomationEventBase[cloudEvents.Length];
            for (int i = 0; i < cloudEvents.Length; i++)
            {
                var cloudEvent = cloudEvents[i];
                callAutomationEvents[i] = Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
            }
            return callAutomationEvents;
        }

        /// <summary>
        /// Deserialize a CloudEvent to its corresponding CallAutomation Event.
        /// </summary>
        /// <param name="eventData">the event data of a <see cref="CloudEvent"/> in string.</param>
        /// <param name="type">the event type of a <see cref="CloudEvent"/> in string.</param>
        /// <returns>A <see cref="CallAutomationEventBase"/> object.</returns>
        private static CallAutomationEventBase Deserialize(string eventData, string type)
        {
            var eventType = type.Replace(EventPrefix, "");
            switch (eventType)
            {
                case nameof(AddParticipantsFailed):
                    return AddParticipantsFailed.Deserialize(eventData);
                case nameof(AddParticipantsSucceeded):
                    return AddParticipantsSucceeded.Deserialize(eventData);
                case nameof(CallConnected):
                    return CallConnected.Deserialize(eventData);
                case nameof(CallDisconnected):
                    return CallDisconnected.Deserialize(eventData);
                case nameof(CallTransferAccepted):
                    return CallTransferAccepted.Deserialize(eventData);
                case nameof(CallTransferFailed):
                    return CallTransferFailed.Deserialize(eventData);
                case nameof(ParticipantsUpdated):
                    return ParticipantsUpdated.Deserialize(eventData);
                case nameof(CallRecordingStateChanged):
                    return CallRecordingStateChanged.Deserialize(eventData);
                case nameof(PlayCompleted):
                    return PlayCompleted.Deserialize(eventData);
                case nameof(PlayFailed):
                    return PlayFailed.Deserialize(eventData);
                case nameof(RecognizeCompleted):
                    return RecognizeCompleted.Deserialize(eventData);
                case nameof(RecognizeFailed):
                    return RecognizeFailed.Deserialize(eventData);
                default:
                    return null;
            }
        }
    }
}

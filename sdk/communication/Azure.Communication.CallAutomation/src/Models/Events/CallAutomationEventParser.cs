// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Helper class for parsing Acs call back events.
    /// </summary>
    public static class CallAutomationEventParser
    {
        /// <summary>
        /// Parsing a CallAutomation event from a CloudEvent.
        /// </summary>
        private const string EventPrefix = "Microsoft.Communication.";

        /// <summary>
        /// Parsing a CallAutomation event from a CloudEvent.
        /// </summary>
        private const string EventSuffix = "EventData";

        /// <summary>
        /// Parsing a CallAutomation event from a CloudEvent.
        /// </summary>
        /// <param name="cloudEvent"><see cref="CloudEvent"/>.</param>
        /// <returns>A <see cref="CallAutomationEventData"/> object.</returns>
        public static CallAutomationEventData Parse(CloudEvent cloudEvent)
        {
            return Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
        }

        /// <summary>
        /// Parsing a CallAutomation event from BinaryData.
        /// </summary>
        /// <param name="json">event json in BinaryData format.</param>
        /// <returns>A <see cref="CallAutomationEventData"/> object.</returns>
        public static CallAutomationEventData Parse(BinaryData json)
        {
            CloudEvent cloudEvent = CloudEvent.Parse(json);
            return Deserialize(cloudEvent.Data.ToString(), cloudEvent.Type);
        }

        /// <summary>
        /// Parsing a CallAutomation event given the data and event type of the payload.
        /// </summary>
        /// <param name="eventData">the event data of a <see cref="CloudEvent"/> in string.</param>
        /// <param name="eventType">the event type of a <see cref="CloudEvent"/> in string.</param>
        /// <returns>An array of <see cref="CallAutomationEventData"/> object.</returns>
        public static CallAutomationEventData Parse(string eventData, string eventType)
        {
            return Deserialize(eventData, eventType);
        }

        /// <summary>
        /// Parsing CallAutomation events from an array of CloudEvent.
        /// </summary>
        /// <param name="cloudEvents"><see cref="CloudEvent"/>.</param>
        /// <returns>An array of <see cref="CallAutomationEventData"/> object.</returns>
        public static CallAutomationEventData[] ParseMany(CloudEvent[] cloudEvents)
        {
            var callAutomationEvents = new CallAutomationEventData[cloudEvents.Length];
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
        /// <returns>An array of <see cref="CallAutomationEventData"/> object.</returns>
        public static CallAutomationEventData[] ParseMany(BinaryData json)
        {
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(json);
            var callAutomationEvents = new CallAutomationEventData[cloudEvents.Length];
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
        /// <returns>A <see cref="CallAutomationEventData"/> object.</returns>
        private static CallAutomationEventData Deserialize(string eventData, string type)
        {
            var eventType = type.Replace(EventPrefix, "");
            eventType = eventType + EventSuffix;
            switch (eventType)
            {
                case nameof(AddParticipantFailedEventData):
                    return AddParticipantFailedEventData.Deserialize(eventData);
                case nameof(AddParticipantSucceededEventData):
                    return AddParticipantSucceededEventData.Deserialize(eventData);
                case nameof(CallConnectedEventData):
                    return CallConnectedEventData.Deserialize(eventData);
                case nameof(CallDisconnectedEventData):
                    return CallDisconnectedEventData.Deserialize(eventData);
                case nameof(CallTransferAcceptedEventData):
                    return CallTransferAcceptedEventData.Deserialize(eventData);
                case nameof(CallTransferFailedEventData):
                    return CallTransferFailedEventData.Deserialize(eventData);
                case nameof(ParticipantsUpdatedEventData):
                    return ParticipantsUpdatedEventData.Deserialize(eventData);
                case nameof(RecordingStateChangedEventData):
                    return RecordingStateChangedEventData.Deserialize(eventData);
                case nameof(PlayCompletedEventData):
                    return PlayCompletedEventData.Deserialize(eventData);
                case nameof(PlayFailedEventData):
                    return PlayFailedEventData.Deserialize(eventData);
                case nameof(PlayCanceledEventData):
                    return PlayCanceledEventData.Deserialize(eventData);
                case nameof(RecognizeCompletedEventData):
                    return RecognizeCompletedEventData.Deserialize(eventData);
                case nameof(RecognizeFailedEventData):
                    return RecognizeFailedEventData.Deserialize(eventData);
                case nameof(RecognizeCanceledEventData):
                    return RecognizeCanceledEventData.Deserialize(eventData);
                case nameof(RemoveParticipantSucceededEventData):
                    return RemoveParticipantSucceededEventData.Deserialize(eventData);
                case nameof(RemoveParticipantFailedEventData):
                    return RemoveParticipantFailedEventData.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionToneReceivedEventData):
                    return ContinuousDtmfRecognitionToneReceivedEventData.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionToneFailedEventData):
                    return ContinuousDtmfRecognitionToneFailedEventData.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionStoppedEventData):
                    return ContinuousDtmfRecognitionStoppedEventData.Deserialize(eventData);
                case nameof(SendDtmfCompletedEventData):
                    return SendDtmfCompletedEventData.Deserialize(eventData);
                case nameof(SendDtmfFailedEventData):
                    return SendDtmfFailedEventData.Deserialize(eventData);
                default:
                    return null;
            }
        }
    }
}

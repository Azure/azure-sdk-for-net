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
                case nameof(AddParticipantFailed):
                    return AddParticipantFailed.Deserialize(eventData);
                case nameof(AddParticipantSucceeded):
                    return AddParticipantSucceeded.Deserialize(eventData);
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
                case nameof(RecordingStateChanged):
                    return RecordingStateChanged.Deserialize(eventData);
                case nameof(TeamsRecordingStateChanged):
                    return TeamsRecordingStateChanged.Deserialize(eventData);
                case nameof(TeamsComplianceRecordingStateChanged):
                    return TeamsComplianceRecordingStateChanged.Deserialize(eventData);
                case nameof(PlayCompleted):
                    return PlayCompleted.Deserialize(eventData);
                case nameof(PlayFailed):
                    return PlayFailed.Deserialize(eventData);
                case nameof(PlayCanceled):
                    return PlayCanceled.Deserialize(eventData);
                case nameof(RecognizeCompleted):
                    return RecognizeCompleted.Deserialize(eventData);
                case nameof(RecognizeFailed):
                    return RecognizeFailed.Deserialize(eventData);
                case nameof(RecognizeCanceled):
                    return RecognizeCanceled.Deserialize(eventData);
                case nameof(RemoveParticipantSucceeded):
                    return RemoveParticipantSucceeded.Deserialize(eventData);
                case nameof(RemoveParticipantFailed):
                    return RemoveParticipantFailed.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionToneReceived):
                    return ContinuousDtmfRecognitionToneReceived.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionToneFailed):
                    return ContinuousDtmfRecognitionToneFailed.Deserialize(eventData);
                case nameof(ContinuousDtmfRecognitionStopped):
                    return ContinuousDtmfRecognitionStopped.Deserialize(eventData);
                case nameof(SendDtmfTonesCompleted):
                    return SendDtmfTonesCompleted.Deserialize(eventData);
                case nameof(SendDtmfTonesFailed):
                    return SendDtmfTonesFailed.Deserialize(eventData);
                case nameof(CancelAddParticipantFailed):
                    return CancelAddParticipantFailed.Deserialize(eventData);
                case nameof(CancelAddParticipantSucceeded):
                    return CancelAddParticipantSucceeded.Deserialize(eventData);
                case nameof(TranscriptionStarted):
                    return TranscriptionStarted.Deserialize(eventData);
                case nameof(TranscriptionUpdated):
                    return TranscriptionUpdated.Deserialize(eventData);
                case nameof(TranscriptionStopped):
                    return TranscriptionStopped.Deserialize(eventData);
                case nameof(TranscriptionFailed):
                    return TranscriptionFailed.Deserialize(eventData);
                case nameof(AnswerFailed):
                    return AnswerFailed.Deserialize(eventData);
                case nameof(CreateCallFailed):
                    return CreateCallFailed.Deserialize(eventData);
                #region Dialog
                case nameof(DialogCompleted):
                    return DialogCompleted.Deserialize(eventData);
                case nameof(DialogFailed):
                    return DialogFailed.Deserialize(eventData);
                case nameof(DialogConsent):
                    return DialogConsent.Deserialize(eventData);
                case nameof(DialogStarted):
                    return DialogStarted.Deserialize(eventData);
                case nameof(DialogHangup):
                    return DialogHangup.Deserialize(eventData);
                case nameof(DialogTransfer):
                    return DialogTransfer.Deserialize(eventData);
                case nameof(DialogSensitivityUpdate):
                    return DialogSensitivityUpdate.Deserialize(eventData);
                case nameof(DialogLanguageChange):
                    return DialogLanguageChange.Deserialize(eventData);
                case nameof(DialogUpdated):
                    return DialogUpdated.Deserialize(eventData);
                #endregion
                default:
                    return null;
            }
        }
    }
}

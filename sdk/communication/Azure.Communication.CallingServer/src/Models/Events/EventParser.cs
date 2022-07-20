// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// Helper class for parsing Acs call back events.
    /// </summary>
    public static class EventParser
    {
        #region event types
        private struct EventTypes
        {
            internal const string CallConnectedEventType = "Microsoft.Communication.CallConnected";

            internal const string CallDisconnectedEventType = "Microsoft.Communication.CallDisconnected";

            internal const string ToneReceivedEventType = "Microsoft.Communication.ToneReceived";

            internal const string CallRecordingStateChangedEventType = "Microsoft.Communication.CallRecordingStateChanged";

            internal const string PlayAudioResultEventType = "Microsoft.Communication.PlayAudioResult";

            internal const string ParticipantsUpdatedEventType = "Microsoft.Communication.ParticipantsUpdated";

            internal const string AddParticipantsSucceededEventType = "Microsoft.Communication.AddParticipantsSucceeded";

            internal const string AddParticipantsFailedEventType = "Microsoft.Communication.AddParticipantsFailed";

            internal const string TransferCallAcceptedEventType = "Microsoft.Communication.TransferCallAccepted";

            internal const string TransferCallFailedEventType = "Microsoft.Communication.TransferCallFailed";
        }
        #endregion

        /// <summary>
        /// Parsing an event from json.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static CallingServerEventBase Parse(string content) {
            CloudEvent cloudEvent = CloudEvent.Parse(BinaryData.FromString(content));

            if (cloudEvent != null && cloudEvent.Data != null)
            {
                if (cloudEvent.Type.Equals(EventTypes.AddParticipantsFailedEventType))
                {
                    return AddParticipantsFailedEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.AddParticipantsSucceededEventType))
                {
                    return AddParticipantsSucceededEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.CallConnectedEventType))
                {
                    return CallConnectedEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.CallDisconnectedEventType))
                {
                    return CallDisconnectedEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.TransferCallAcceptedEventType))
                {
                    return CallTransferAcceptedEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.TransferCallFailedEventType))
                {
                    return CallTransferFailedEvent.Deserialize(cloudEvent.Data.ToString());
                }
                else if (cloudEvent.Type.Equals(EventTypes.ParticipantsUpdatedEventType))
                {
                    return ParticipantsUpdatedEvent.Deserialize(cloudEvent.Data.ToString());
                }
            }

            return null;
        }
    }
}

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
        private const string EventPrefix = "Microsoft.Communication.";

        /// <summary>
        /// Parsing an event from json.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static CallAutomationEventBase Parse(string content)
        {
            CloudEvent cloudEvent = CloudEvent.Parse(BinaryData.FromString(content));
            var eventType = cloudEvent.Type.Replace(EventPrefix, "");

            if (cloudEvent != null && cloudEvent.Data != null)
            {
                switch (eventType)
                {
                    case nameof(AddParticipantsFailed):
                        return AddParticipantsFailed.Deserialize(cloudEvent.Data.ToString());
                    case nameof(AddParticipantsSucceeded):
                        return AddParticipantsSucceeded.Deserialize(cloudEvent.Data.ToString());
                    case nameof(CallConnected):
                        return CallConnected.Deserialize(cloudEvent.Data.ToString());
                    case nameof(CallDisconnected):
                        return CallDisconnected.Deserialize(cloudEvent.Data.ToString());
                    case nameof(CallTransferAccepted):
                        return CallTransferAccepted.Deserialize(cloudEvent.Data.ToString());
                    case nameof(CallTransferFailed):
                        return CallTransferFailed.Deserialize(cloudEvent.Data.ToString());
                    case nameof(ParticipantsUpdated):
                        return ParticipantsUpdated.Deserialize(cloudEvent.Data.ToString());
                    default:
                        return null;
                }
            }
            return null;
        }
     }
}

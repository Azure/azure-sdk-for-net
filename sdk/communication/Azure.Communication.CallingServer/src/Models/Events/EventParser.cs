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
        /// Parsing an event from a string.
        /// </summary>
        /// <param name="content"> event json in string format.</param>
        /// <returns>A <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase Parse(string content)
        {
            CloudEvent cloudEvent = CloudEvent.Parse(BinaryData.FromString(content));
            return Deserialize(cloudEvent);
        }

        /// <summary>
        /// Parsing an event from BinaryData.
        /// </summary>
        /// <param name="content"> event json in BinaryData format.</param>
        /// <returns>A <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase Parse(BinaryData content)
        {
            CloudEvent cloudEvent = CloudEvent.Parse(content);
            return Deserialize(cloudEvent);
        }

        /// <summary>
        /// Parsing an event from a CloudEvent.
        /// </summary>
        /// <param name="cloudEvent"><see cref="CloudEvent"/>.</param>
        /// <returns>A <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase Parse(CloudEvent cloudEvent)
        {
            return Deserialize(cloudEvent);
        }

        /// <summary>
        /// Parsing events from a string.
        /// </summary>
        /// <param name="content"> events json in string format.</param>
        /// <returns>An array of <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase[] ParseMany(string content)
        {
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(BinaryData.FromString(content));
            var callingServerEvents = new CallingServerEventBase[cloudEvents.Length];
            for (int i = 0; i < cloudEvents.Length; i++)
            {
                var cloudEvent = cloudEvents[i];
                callingServerEvents[i] = Deserialize(cloudEvent);
            }
            return callingServerEvents;
        }

        /// <summary>
        /// Parsing events from BinaryData.
        /// </summary>
        /// <param name="content"> events json in BinaryData format.</param>
        /// <returns>An array of <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase[] ParseMany(BinaryData content)
        {
            CloudEvent[] cloudEvents = CloudEvent.ParseMany(content);
            var callingServerEvents = new CallingServerEventBase[cloudEvents.Length];
            for (int i = 0; i < cloudEvents.Length; i++)
            {
                var cloudEvent = cloudEvents[i];
                callingServerEvents[i] = Deserialize(cloudEvent);
            }
            return callingServerEvents;
        }

        /// <summary>
        /// Parsing events from an array of CloudEvent.
        /// </summary>
        /// <param name="cloudEvents"><see cref="CloudEvent"/>.</param>
        /// <returns>An array of <see cref="CallingServerEventBase"/> object.</returns>
        public static CallingServerEventBase[] ParseMany(CloudEvent[] cloudEvents)
        {
            var callingServerEvents = new CallingServerEventBase[cloudEvents.Length];
            for (int i = 0; i < cloudEvents.Length; i++)
            {
                var cloudEvent = cloudEvents[i];
                callingServerEvents[i] = Deserialize(cloudEvent);
            }
            return callingServerEvents;
        }

        /// <summary>
        /// Deserialize a CloudEvent to its corresponding CallingServer Event.
        /// </summary>
        /// <param name="cloudEvent"><see cref="CloudEvent"/>.</param>
        /// <returns>A <see cref="CallingServerEventBase"/> object.</returns>
        private static CallingServerEventBase Deserialize(CloudEvent cloudEvent)
        {
            if (cloudEvent != null && cloudEvent.Data != null)
            {
                var eventType = cloudEvent.Type.Replace(EventPrefix, "");
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// Base type for all calling events.
    /// </summary>
    public abstract class CallEventBase
    {
        /// <summary>
        /// Deserialize calling event.
        /// </summary>
        /// <param name="eventType">The event type.</param>
        /// <param name="eventData">The event data.</param>
        /// <returns></returns>
        public static CallEventBase Deserialize(string eventType, string eventData)
        {
            Argument.AssertNotNullOrEmpty(eventType, nameof(eventType));
            Argument.AssertNotNullOrEmpty(eventData, nameof(eventData));

            switch (eventType)
            {
                case EventType.CallLegStateChangedEventValue:
                    {
                        return CallLegStateChangedEvent.Deserialize(eventData);
                    }
                case EventType.ToneReceivedEventValue:
                    {
                        return ToneReceivedEvent.Deserialize(eventData);
                    }
                case EventType.PlayAudioResultEventValue:
                    {
                        return PlayAudioResultEvent.Deserialize(eventData);
                    }
                case EventType.CallRecordingStateChangeEventValue:
                    {
                        return CallRecordingStateChangeEvent.Deserialize(eventData);
                    }
                case EventType.InviteParticipantsResultEventValue:
                    {
                        return InviteParticipantsResultEvent.Deserialize(eventData);
                    }
                case EventType.ParticipantsUpdatedEventValue:
                    {
                        return ParticipantsUpdatedEvent.Deserialize(eventData);
                    }
                default:
                    throw new System.NotSupportedException("Provided event type is not supported");
            }
        }
    }
}

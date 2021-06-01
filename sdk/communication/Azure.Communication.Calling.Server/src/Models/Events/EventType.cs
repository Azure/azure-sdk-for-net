// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The type of an event.
    /// </summary>
    public readonly struct EventType : IEquatable<EventType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> struct.
        /// </summary>
        /// <param name="value">The asset file type</param>
        public EventType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal const string CallLegStateChangedEventValue = "Microsoft.Communication.CallLegStateChanged";
        internal const string ToneReceivedEventValue = "Microsoft.Communication.DtmfReceived";
        internal const string PlayAudioResultEventValue = "Microsoft.Communication.PlayAudioResult";
        internal const string CallRecordingStateChangeEventValue = "Microsoft.Communication.CallRecordingStateChanged";
        internal const string InviteParticipantsResultEventValue = "Microsoft.Communication.InviteParticipantResult";
        internal const string ParticipantsUpdatedEventValue = "Microsoft.Communication.ParticipantsUpdated";

        /// <summary>
        /// The call leg state change event type.
        /// </summary>
        public static EventType CallLegStateChangedEvent { get; } = new EventType(CallLegStateChangedEventValue);

        /// <summary>
        /// The subscribe to tone event type.
        /// </summary>
        public static EventType ToneReceivedEvent { get; } = new EventType(ToneReceivedEventValue);

        /// <summary>
        /// The play audio result event type.
        /// </summary>
        public static EventType PlayAudioResultEvent { get; } = new EventType(PlayAudioResultEventValue);

        /// <summary>
        /// The call recording state change event type.
        /// </summary>
        public static EventType CallRecordingStateChangeEvent { get; } = new EventType(CallRecordingStateChangeEventValue);

        /// <summary>
        /// The invited participants result event type.
        /// </summary>
        public static EventType InviteParticipantsResultEvent { get; } = new EventType(InviteParticipantsResultEventValue);

        /// <summary>
        /// The call state change event type.
        /// </summary>
        public static EventType ParticipantsUpdatedEvent { get; } = new EventType(ParticipantsUpdatedEventValue);

        /// <summary>
        /// Determines if two <see cref="EventType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="EventType"/> to compare.</param>
        /// <param name="right">The second <see cref="EventType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(EventType left, EventType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="EventType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="EventType"/> to compare.</param>
        /// <param name="right">The second <see cref="EventType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(EventType left, EventType right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public bool Equals(EventType other)
        {
            return this._value == other._value;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is CallState && Equals((EventType)obj);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}

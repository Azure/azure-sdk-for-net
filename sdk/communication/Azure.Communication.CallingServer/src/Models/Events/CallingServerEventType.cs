// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The type of calling server event.
    /// </summary>
    public readonly struct CallingServerEventType : IEquatable<CallingServerEventType>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallingServerEventType"/> struct.
        /// </summary>
        /// <param name="value">The asset file type</param>
        public CallingServerEventType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal const string CallConnectionStateChangedEventValue = "Microsoft.Communication.CallConnectionStateChanged";
        internal const string ToneReceivedEventValue = "Microsoft.Communication.DtmfReceived";
        internal const string PlayAudioResultEventValue = "Microsoft.Communication.PlayAudioResult";
        internal const string CallRecordingStateChangeEventValue = "Microsoft.Communication.CallRecordingStateChanged";
        internal const string AddParticipantResultEventValue = "Microsoft.Communication.AddParticipantResult";
        internal const string ParticipantsUpdatedEventValue = "Microsoft.Communication.ParticipantsUpdated";

        /// <summary>
        /// The call connection state change event type.
        /// </summary>
        public static CallingServerEventType CallConnectionStateChangedEvent { get; } = new CallingServerEventType(CallConnectionStateChangedEventValue);

        /// <summary>
        /// The subscribe to tone event type.
        /// </summary>
        public static CallingServerEventType ToneReceivedEvent { get; } = new CallingServerEventType(ToneReceivedEventValue);

        /// <summary>
        /// The play audio result event type.
        /// </summary>
        public static CallingServerEventType PlayAudioResultEvent { get; } = new CallingServerEventType(PlayAudioResultEventValue);

        /// <summary>
        /// The call recording state change event type.
        /// </summary>
        public static CallingServerEventType CallRecordingStateChangeEvent { get; } = new CallingServerEventType(CallRecordingStateChangeEventValue);

        /// <summary>
        /// The add participant result event type.
        /// </summary>
        public static CallingServerEventType AddParticipantResultEvent { get; } = new CallingServerEventType(AddParticipantResultEventValue);

        /// <summary>
        /// The call state change event type.
        /// </summary>
        public static CallingServerEventType ParticipantsUpdatedEvent { get; } = new CallingServerEventType(ParticipantsUpdatedEventValue);

        /// <summary>
        /// Determines if two <see cref="CallingServerEventType"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CallingServerEventType"/> to compare.</param>
        /// <param name="right">The second <see cref="CallingServerEventType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CallingServerEventType left, CallingServerEventType right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CallingServerEventType"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CallingServerEventType"/> to compare.</param>
        /// <param name="right">The second <see cref="CallingServerEventType"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CallingServerEventType left, CallingServerEventType right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public bool Equals(CallingServerEventType other)
        {
            return this._value == other._value;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is CallingServerEventType && Equals((CallingServerEventType)obj);
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The states of a call.
    /// </summary>
    public readonly struct CallState : IEquatable<CallState>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallState"/> struct.
        /// </summary>
        /// <param name="value">The asset file type</param>
        public CallState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        internal const string UnknownValue = "unknown";
        internal const string IdleValue = "idle";
        internal const string IncomingValue = "incoming";
        internal const string EstablishingValue = "establishing";
        internal const string EstablishedValue = "established";
        internal const string HoldValue = "hold";
        internal const string UnholdValue = "unhold";
        internal const string TransferringValue = "transferring";
        internal const string RedirectingValue = "redirecting";
        internal const string TerminatingValue = "terminating";
        internal const string TerminatedValue = "terminated";

        /// <summary>
        /// Unknown not recognized.
        /// </summary>
        public static CallState Unknown { get; } = new CallState(UnknownValue);

        /// <summary>
        /// Initial State.
        /// </summary>
        public static CallState Idle { get; } = new CallState(IdleValue);

        /// <summary>
        ///  The call has just been received.
        /// </summary>
        public static CallState Incoming { get; } = new CallState(IncomingValue);

        /// <summary>
        /// The call establishment is in progress after initiating or accepting the call.
        /// </summary>
        public static CallState Establishing { get; } = new CallState(EstablishingValue);

        /// <summary>
        /// The call is established.
        /// </summary>
        public static CallState Established { get; } = new CallState(EstablishedValue);

        /// <summary>
        /// The call is on Hold.
        /// </summary>
        public static CallState Hold { get; } = new CallState(HoldValue);

        /// <summary>
        /// The call is Unhold.
        /// </summary>
        public static CallState Unhold { get; } = new CallState(UnholdValue);

        /// <summary>
        /// The call has initiated a transfer.
        /// </summary>
        public static CallState Transferring { get; } = new CallState(TransferringValue);

        /// <summary>
        /// The call has initiated a redirection.
        /// </summary>
        public static CallState Redirecting { get; } = new CallState(RedirectingValue);

        /// <summary>
        /// The call is terminating.
        /// </summary>
        public static CallState Terminating { get; } = new CallState(TerminatingValue);

        /// <summary>
        /// The call has terminated.
        /// </summary>
        public static CallState Terminated { get; } = new CallState(TerminatedValue);

        /// <summary>
        /// Determines if two <see cref="CallState"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CallState"/> to compare.</param>
        /// <param name="right">The second <see cref="CallState"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CallState left, CallState right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CallState"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CallState"/> to compare.</param>
        /// <param name="right">The second <see cref="CallState"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CallState left, CallState right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public bool Equals(CallState other)
        {
            return this._value == other._value;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is CallState && Equals((CallState)obj);
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

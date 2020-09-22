// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// A scope for a token.
    /// </summary>
    public readonly struct CommunicationTokenScope : IEquatable<CommunicationTokenScope>
    {
        internal const string VoIPValue = "voip";
        internal const string ChatValue = "chat";
        internal const string PstnValue = "pstn";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationTokenScope"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public CommunicationTokenScope(string value)
            => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary>
        /// Voice over IP.
        /// </summary>
        public static CommunicationTokenScope VoIP { get; } = new CommunicationTokenScope(VoIPValue);

        /// <summary>
        /// Chat.
        /// </summary>
        public static CommunicationTokenScope Chat { get; } = new CommunicationTokenScope(ChatValue);

        /// <summary>
        /// Public switched telephone network.
        /// </summary>
        public static CommunicationTokenScope Pstn { get; } = new CommunicationTokenScope(PstnValue);

        /// <summary>
        /// Determines if two <see cref="CommunicationTokenScope"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="CommunicationTokenScope"/> to compare.</param>
        /// <param name="right">The second <see cref="CommunicationTokenScope"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(CommunicationTokenScope left, CommunicationTokenScope right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="CommunicationTokenScope"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="CommunicationTokenScope"/> to compare.</param>
        /// <param name="right">The second <see cref="CommunicationTokenScope"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(CommunicationTokenScope left, CommunicationTokenScope right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="CommunicationTokenScope"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator CommunicationTokenScope(string value) => new CommunicationTokenScope(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is CommunicationTokenScope other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(CommunicationTokenScope other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}

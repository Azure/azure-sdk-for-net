// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// An action that will be executed.
    /// </summary>
    public readonly struct Action : IEquatable<Action>
    {
        internal const string AutoRenewValue = "AutoRenew";
        internal const string EmailContactsValue = "EmailContacts";

        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> structure.
        /// </summary>
        /// <param name="value">The string value of the instance.</param>
        public Action(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// An action that will auto-renew a certificate
        /// </summary>
        public static Action AutoRenew { get; } = new Action(AutoRenewValue);

        /// <summary>
        /// An action that will email certificate contacts
        /// </summary>
        public static Action EmailContacts { get; } = new Action(EmailContactsValue);

        /// <summary>
        /// Determines if two <see cref="Action"/> values are the same.
        /// </summary>
        /// <param name="left">The first <see cref="Action"/> to compare.</param>
        /// <param name="right">The second <see cref="Action"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are the same; otherwise, false.</returns>
        public static bool operator ==(Action left, Action right) => left.Equals(right);

        /// <summary>
        /// Determines if two <see cref="Action"/> values are different.
        /// </summary>
        /// <param name="left">The first <see cref="Action"/> to compare.</param>
        /// <param name="right">The second <see cref="Action"/> to compare.</param>
        /// <returns>True if <paramref name="left"/> and <paramref name="right"/> are different; otherwise, false.</returns>
        public static bool operator !=(Action left, Action right) => !left.Equals(right);

        /// <summary>
        /// Converts a string to a <see cref="Action"/>.
        /// </summary>
        /// <param name="value">The string value to convert.</param>
        public static implicit operator Action(string value) => new Action(value);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Action other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Action other) => string.Equals(_value, other._value, StringComparison.Ordinal);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc/>
        public override string ToString() => _value;
    }
}

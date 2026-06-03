// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Provides constructor, field, static members, Equals/GetHashCode/ToString
// and implicit conversions to/from StorageAccountNetworkRuleAction.
// Generated partial provides ==, !=, and implicit string operators.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The action of an IP ACL rule. </summary>
    public readonly partial struct StorageAccountIPRuleAction : IEquatable<StorageAccountIPRuleAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountIPRuleAction"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountIPRuleAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";

        /// <summary> Allow. </summary>
        public static StorageAccountIPRuleAction Allow { get; } = new StorageAccountIPRuleAction(AllowValue);

        /// <summary> Implicit conversion between the two equivalent extensible-enum representations. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator StorageAccountNetworkRuleAction(StorageAccountIPRuleAction value) => new StorageAccountNetworkRuleAction(value.ToString());

        /// <summary> Implicit conversion between the two equivalent extensible-enum representations. </summary>
        /// <param name="value"> The value. </param>
        public static implicit operator StorageAccountIPRuleAction(StorageAccountNetworkRuleAction value) => new StorageAccountIPRuleAction(value.ToString());

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountIPRuleAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageAccountIPRuleAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

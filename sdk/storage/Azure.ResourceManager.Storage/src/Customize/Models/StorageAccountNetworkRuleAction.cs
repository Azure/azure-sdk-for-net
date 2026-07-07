// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Provides constructor, field, static members, Equals/GetHashCode/ToString
// for the unified StorageAccountNetworkRuleAction type. Generated partial provides operators.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The action of virtual network rule or IP ACL rule. </summary>
    public readonly partial struct StorageAccountNetworkRuleAction : IEquatable<StorageAccountNetworkRuleAction>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="StorageAccountNetworkRuleAction"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public StorageAccountNetworkRuleAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";

        /// <summary> Allow. </summary>
        public static StorageAccountNetworkRuleAction Allow { get; } = new StorageAccountNetworkRuleAction(AllowValue);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountNetworkRuleAction other && Equals(other);
        /// <inheritdoc />
        public bool Equals(StorageAccountNetworkRuleAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

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
    public readonly partial struct StorageAccountIPRuleAction : IEquatable<StorageAccountIPRuleAction>
    {
        private readonly string _value;

        public StorageAccountIPRuleAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";

        public static StorageAccountIPRuleAction Allow { get; } = new StorageAccountIPRuleAction(AllowValue);

        // Backward-compatible: Implicit conversion to StorageAccountNetworkRuleAction.
        public static implicit operator StorageAccountNetworkRuleAction(StorageAccountIPRuleAction value) => new StorageAccountNetworkRuleAction(value.ToString());

        // Implicit conversion from unified StorageAccountNetworkRuleAction.
        public static implicit operator StorageAccountIPRuleAction(StorageAccountNetworkRuleAction value) => new StorageAccountIPRuleAction(value.ToString());

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountIPRuleAction other && Equals(other);
        public bool Equals(StorageAccountIPRuleAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}

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
    public readonly partial struct StorageAccountVirtualNetworkRuleAction : IEquatable<StorageAccountVirtualNetworkRuleAction>
    {
        private readonly string _value;

        public StorageAccountVirtualNetworkRuleAction(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AllowValue = "Allow";

        public static StorageAccountVirtualNetworkRuleAction Allow { get; } = new StorageAccountVirtualNetworkRuleAction(AllowValue);

        /// <summary> Implicit conversion to backward-compatible <see cref="StorageAccountNetworkRuleAction"/>. </summary>
        public static implicit operator StorageAccountNetworkRuleAction(StorageAccountVirtualNetworkRuleAction value) => new StorageAccountNetworkRuleAction(value.ToString());

        /// <summary> Implicit conversion from unified <see cref="StorageAccountNetworkRuleAction"/>. </summary>
        public static implicit operator StorageAccountVirtualNetworkRuleAction(StorageAccountNetworkRuleAction value) => new StorageAccountVirtualNetworkRuleAction(value.ToString());

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is StorageAccountVirtualNetworkRuleAction other && Equals(other);
        public bool Equals(StorageAccountVirtualNetworkRuleAction other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}

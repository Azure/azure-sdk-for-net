// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;

namespace Azure.ResourceManager.NetApp.Models
{
    public readonly partial struct ExcludeReplicationsFilter : IEquatable<ExcludeReplicationsFilter>
    {
        private readonly string _value;

        public ExcludeReplicationsFilter(string value)
        {
            _value = value;
        }

        public static ExcludeReplicationsFilter None { get; } = new ExcludeReplicationsFilter("None");
        public static ExcludeReplicationsFilter Deleted { get; } = new ExcludeReplicationsFilter("Deleted");

        public static implicit operator ExcludeReplicationsFilter(string value) => new ExcludeReplicationsFilter(value);
        public static implicit operator Exclude(ExcludeReplicationsFilter value) => new Exclude(value._value);
        public static implicit operator ExcludeReplicationsFilter(Exclude value) => new ExcludeReplicationsFilter(value.ToString());
        public static bool operator ==(ExcludeReplicationsFilter left, ExcludeReplicationsFilter right) => left.Equals(right);
        public static bool operator !=(ExcludeReplicationsFilter left, ExcludeReplicationsFilter right) => !left.Equals(right);

        public bool Equals(ExcludeReplicationsFilter other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        public override bool Equals(object obj) => obj is ExcludeReplicationsFilter other && Equals(other);
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        public override string ToString() => _value;
    }
}

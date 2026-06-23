// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ReplicationLinkState : IEquatable<ReplicationLinkState>
    {
        private readonly string _value;

        public ReplicationLinkState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PendingValue = "PENDING";
        private const string SeedingValue = "SEEDING";
        private const string CatchUpValue = "CATCH_UP";
        private const string SuspendedValue = "SUSPENDED";

        public static ReplicationLinkState Pending { get; } = new ReplicationLinkState(PendingValue);
        public static ReplicationLinkState Seeding { get; } = new ReplicationLinkState(SeedingValue);
        public static ReplicationLinkState CatchUp { get; } = new ReplicationLinkState(CatchUpValue);
        public static ReplicationLinkState Suspended { get; } = new ReplicationLinkState(SuspendedValue);

        public static bool operator ==(ReplicationLinkState left, ReplicationLinkState right) => left.Equals(right);
        public static bool operator !=(ReplicationLinkState left, ReplicationLinkState right) => !left.Equals(right);
        public static implicit operator ReplicationLinkState(string value) => new ReplicationLinkState(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ReplicationLinkState other && Equals(other);

        public bool Equals(ReplicationLinkState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct SqlServerSideLinkRole : IEquatable<SqlServerSideLinkRole>
    {
        private readonly string _value;

        public SqlServerSideLinkRole(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PrimaryValue = "Primary";
        private const string SecondaryValue = "Secondary";

        public static SqlServerSideLinkRole Primary { get; } = new SqlServerSideLinkRole(PrimaryValue);
        public static SqlServerSideLinkRole Secondary { get; } = new SqlServerSideLinkRole(SecondaryValue);

        public static bool operator ==(SqlServerSideLinkRole left, SqlServerSideLinkRole right) => left.Equals(right);
        public static bool operator !=(SqlServerSideLinkRole left, SqlServerSideLinkRole right) => !left.Equals(right);
        public static implicit operator SqlServerSideLinkRole(string value) => new SqlServerSideLinkRole(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SqlServerSideLinkRole other && Equals(other);

        public bool Equals(SqlServerSideLinkRole other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}

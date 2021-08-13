// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    // TODO: Populate this list of scopes

    public readonly partial struct SynapsePrincipalType : IEquatable<SynapsePrincipalType>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="SynapseRoleScope"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SynapsePrincipalType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string UserValue = "User";
        private const string GroupValue = "Group";
        private const string ServicePrincipalValue = "ServicePrincipal";

        /// <summary> Global scope. </summary>
        public static SynapsePrincipalType User { get; } = new SynapsePrincipalType(UserValue);
        public static SynapsePrincipalType Group { get; } = new SynapsePrincipalType(GroupValue);
        public static SynapsePrincipalType ServicePrincipal { get; } = new SynapsePrincipalType(ServicePrincipalValue);

        /// <summary> Determines if two <see cref="SynapseRoleScope"/> values are the same. </summary>
        public static bool operator ==(SynapsePrincipalType left, SynapsePrincipalType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SynapsePrincipalType"/> values are not the same. </summary>
        public static bool operator !=(SynapsePrincipalType left, SynapsePrincipalType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SynapseRoleScope"/>. </summary>
        public static implicit operator SynapsePrincipalType(string value) => new SynapsePrincipalType(value);
        /// <summary> Converts a <see cref="SynapseRoleScope"/> to a <see cref="RequestContent"/>. </summary>
        public static implicit operator RequestContent(SynapsePrincipalType scope) => RequestContent.Create(scope._value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SynapseRoleScope other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SynapsePrincipalType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

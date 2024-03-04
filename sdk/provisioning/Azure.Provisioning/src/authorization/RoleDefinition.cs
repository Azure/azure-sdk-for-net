// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Authorization
{
    /// <summary> Role definition. </summary>
    public readonly partial struct RoleDefinition : IEquatable<RoleDefinition>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RoleDefinition"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RoleDefinition(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Storage blob data contributor role.
        /// </summary>
        public static RoleDefinition StorageBlobDataContributor { get; } = new RoleDefinition("ba92f5b4-2d11-453d-a403-e96b0029c9fe");

        /// <summary>
        /// Storage queue data contributor role.
        /// </summary>
        public static RoleDefinition StorageQueueDataContributor { get; } = new RoleDefinition("974c5e8b-45b9-4653-ba55-5f855dd0fb88");

        /// <summary>
        /// Storage table data contributor role.
        /// </summary>
        public static RoleDefinition StorageTableDataContributor { get; } = new RoleDefinition("0a9a7e1f-b9d0-4cc4-a60d-0319b160aaa3");

        /// <summary>
        /// Key Vault administrator role.
        /// </summary>
        public static RoleDefinition KeyVaultAdministrator { get; } = new RoleDefinition("00482a5a-887f-4fb3-b363-3b7fe8e74483");

        /// <summary> Converts a string to a <see cref="RoleDefinition"/>. </summary>
        public static implicit operator RoleDefinition(string value) => new RoleDefinition(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => obj is RoleDefinition other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RoleDefinition other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

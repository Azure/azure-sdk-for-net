// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist)
// Old name: ContainerGroupIdentityAccessLevel, New name: IdentityAccessLevel

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="IdentityAccessLevel"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct ContainerGroupIdentityAccessLevel : IEquatable<ContainerGroupIdentityAccessLevel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessLevel"/>. </summary>
        public ContainerGroupIdentityAccessLevel(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));

        /// <summary> All. </summary>
        public static ContainerGroupIdentityAccessLevel All { get; } = new ContainerGroupIdentityAccessLevel(IdentityAccessLevel.All.ToString());
        /// <summary> System. </summary>
        public static ContainerGroupIdentityAccessLevel System { get; } = new ContainerGroupIdentityAccessLevel(IdentityAccessLevel.System.ToString());
        /// <summary> User. </summary>
        public static ContainerGroupIdentityAccessLevel User { get; } = new ContainerGroupIdentityAccessLevel(IdentityAccessLevel.User.ToString());

        /// <summary> Converts to the new type. </summary>
        public static implicit operator IdentityAccessLevel(ContainerGroupIdentityAccessLevel value) => new IdentityAccessLevel(value._value);
        /// <summary> Converts from the new type. </summary>
        public static implicit operator ContainerGroupIdentityAccessLevel(IdentityAccessLevel value) => new ContainerGroupIdentityAccessLevel(value.ToString());

        /// <inheritdoc />
        public static bool operator ==(ContainerGroupIdentityAccessLevel left, ContainerGroupIdentityAccessLevel right) => left.Equals(right);
        /// <inheritdoc />
        public static bool operator !=(ContainerGroupIdentityAccessLevel left, ContainerGroupIdentityAccessLevel right) => !left.Equals(right);
        /// <inheritdoc />
        public static implicit operator ContainerGroupIdentityAccessLevel(string value) => new ContainerGroupIdentityAccessLevel(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContainerGroupIdentityAccessLevel other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContainerGroupIdentityAccessLevel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

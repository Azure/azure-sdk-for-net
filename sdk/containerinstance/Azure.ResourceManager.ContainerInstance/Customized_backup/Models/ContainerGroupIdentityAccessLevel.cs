// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for IdentityAccessLevel. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerGroupIdentityAccessLevel : IEquatable<ContainerGroupIdentityAccessLevel>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessLevel"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerGroupIdentityAccessLevel(string value) { _value = value; }

        /// <summary> All. </summary>
        public static ContainerGroupIdentityAccessLevel All { get; } = new ContainerGroupIdentityAccessLevel("All");
        /// <summary> System. </summary>
        public static ContainerGroupIdentityAccessLevel System { get; } = new ContainerGroupIdentityAccessLevel("System");
        /// <summary> User. </summary>
        public static ContainerGroupIdentityAccessLevel User { get; } = new ContainerGroupIdentityAccessLevel("User");

        /// <summary> Converts from <see cref="IdentityAccessLevel"/>. </summary>
        public static implicit operator ContainerGroupIdentityAccessLevel(IdentityAccessLevel v) => new ContainerGroupIdentityAccessLevel(v.ToString());
        /// <summary> Converts to <see cref="IdentityAccessLevel"/>. </summary>
        public static implicit operator IdentityAccessLevel(ContainerGroupIdentityAccessLevel v) => new IdentityAccessLevel(v._value);
        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerGroupIdentityAccessLevel(string value) => new ContainerGroupIdentityAccessLevel(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerGroupIdentityAccessLevel left, ContainerGroupIdentityAccessLevel right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerGroupIdentityAccessLevel left, ContainerGroupIdentityAccessLevel right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerGroupIdentityAccessLevel other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerGroupIdentityAccessLevel other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

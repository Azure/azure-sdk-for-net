// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for Scheme. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerHttpGetScheme : IEquatable<ContainerHttpGetScheme>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerHttpGetScheme"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerHttpGetScheme(string value) { _value = value; }

        /// <summary> Http. </summary>
        public static ContainerHttpGetScheme Http { get; } = new ContainerHttpGetScheme("Http");
        /// <summary> Https. </summary>
        public static ContainerHttpGetScheme Https { get; } = new ContainerHttpGetScheme("Https");

        /// <summary> Converts from <see cref="Scheme"/>. </summary>
        public static implicit operator ContainerHttpGetScheme(Scheme v) => new ContainerHttpGetScheme(v.ToString());
        /// <summary> Converts to <see cref="Scheme"/>. </summary>
        public static implicit operator Scheme(ContainerHttpGetScheme v) => new Scheme(v._value);
        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerHttpGetScheme(string value) => new ContainerHttpGetScheme(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerHttpGetScheme left, ContainerHttpGetScheme right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerHttpGetScheme left, ContainerHttpGetScheme right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerHttpGetScheme other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerHttpGetScheme other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

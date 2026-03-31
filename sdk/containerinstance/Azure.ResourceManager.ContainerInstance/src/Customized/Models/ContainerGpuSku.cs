// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for GpuSku. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ContainerGpuSku : IEquatable<ContainerGpuSku>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ContainerGpuSku"/>. </summary>
        /// <param name="value"> The string value. </param>
        public ContainerGpuSku(string value) { _value = value; }

        /// <summary> K80. </summary>
        public static ContainerGpuSku K80 { get; } = new ContainerGpuSku("K80");
        /// <summary> P100. </summary>
        public static ContainerGpuSku P100 { get; } = new ContainerGpuSku("P100");
        /// <summary> V100. </summary>
        public static ContainerGpuSku V100 { get; } = new ContainerGpuSku("V100");

        /// <summary> Converts from <see cref="GpuSku"/>. </summary>
        public static implicit operator ContainerGpuSku(GpuSku v) => new ContainerGpuSku(v.ToString());
        /// <summary> Converts to <see cref="GpuSku"/>. </summary>
        public static implicit operator GpuSku(ContainerGpuSku v) => new GpuSku(v._value);
        /// <summary> Converts from string. </summary>
        public static implicit operator ContainerGpuSku(string value) => new ContainerGpuSku(value);

        /// <summary> Determines equality. </summary>
        public static bool operator ==(ContainerGpuSku left, ContainerGpuSku right) => left.Equals(right);
        /// <summary> Determines inequality. </summary>
        public static bool operator !=(ContainerGpuSku left, ContainerGpuSku right) => !left.Equals(right);

        /// <inheritdoc />
        public bool Equals(ContainerGpuSku other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is ContainerGpuSku other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

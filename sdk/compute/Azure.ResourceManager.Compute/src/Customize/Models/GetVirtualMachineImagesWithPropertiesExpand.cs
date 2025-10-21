// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The GetVirtualMachineImagesWithPropertiesExpand. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct GetVirtualMachineImagesWithPropertiesExpand : IEquatable<GetVirtualMachineImagesWithPropertiesExpand>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="GetVirtualMachineImagesWithPropertiesExpand"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public GetVirtualMachineImagesWithPropertiesExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PropertiesValue = "Properties";

        /// <summary> Properties. </summary>
        public static GetVirtualMachineImagesWithPropertiesExpand Properties { get; } = new GetVirtualMachineImagesWithPropertiesExpand(PropertiesValue);
        /// <summary> Determines if two <see cref="GetVirtualMachineImagesWithPropertiesExpand"/> values are the same. </summary>
        public static bool operator ==(GetVirtualMachineImagesWithPropertiesExpand left, GetVirtualMachineImagesWithPropertiesExpand right) => left.Equals(right);
        /// <summary> Determines if two <see cref="GetVirtualMachineImagesWithPropertiesExpand"/> values are not the same. </summary>
        public static bool operator !=(GetVirtualMachineImagesWithPropertiesExpand left, GetVirtualMachineImagesWithPropertiesExpand right) => !left.Equals(right);
        /// <summary> Converts a <see cref="string"/> to a <see cref="GetVirtualMachineImagesWithPropertiesExpand"/>. </summary>
        public static implicit operator GetVirtualMachineImagesWithPropertiesExpand(string value) => new GetVirtualMachineImagesWithPropertiesExpand(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GetVirtualMachineImagesWithPropertiesExpand other && Equals(other);
        /// <inheritdoc />
        public bool Equals(GetVirtualMachineImagesWithPropertiesExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}

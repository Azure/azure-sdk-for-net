// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat extensible enum used by SubscriptionResourceGetVirtualMachineImagesWithPropertiesOptions.
    // The previous SDK exposed this typed wrapper around the "expand" query parameter.
    // The new generator emits a plain `string expand` argument; we keep this struct
    // to preserve the public surface and convert via ToString() when forwarding.
    public readonly partial struct GetVirtualMachineImagesWithPropertiesExpand : IEquatable<GetVirtualMachineImagesWithPropertiesExpand>
    {
        private readonly string _value;

        public GetVirtualMachineImagesWithPropertiesExpand(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string PropertiesValue = "properties";

        public static GetVirtualMachineImagesWithPropertiesExpand Properties { get; } = new GetVirtualMachineImagesWithPropertiesExpand(PropertiesValue);

        public static bool operator ==(GetVirtualMachineImagesWithPropertiesExpand left, GetVirtualMachineImagesWithPropertiesExpand right) => left.Equals(right);
        public static bool operator !=(GetVirtualMachineImagesWithPropertiesExpand left, GetVirtualMachineImagesWithPropertiesExpand right) => !left.Equals(right);
        public static implicit operator GetVirtualMachineImagesWithPropertiesExpand(string value) => new GetVirtualMachineImagesWithPropertiesExpand(value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is GetVirtualMachineImagesWithPropertiesExpand other && Equals(other);

        public bool Equals(GetVirtualMachineImagesWithPropertiesExpand other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;

        public override string ToString() => _value;
    }
}
